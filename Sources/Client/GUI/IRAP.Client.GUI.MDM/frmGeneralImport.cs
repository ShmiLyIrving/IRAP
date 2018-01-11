using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList;

using IRAP.Entity.Kanban;
using IRAP.Entity.SSO;
using IRAP.Entity.UTS;
using IRAP.Global;
using IRAP.Client.User;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MDM
{
    public partial class frmGeneralImport : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        #region Debug
        private int _communityID = 60006;
        private long _sysLogID = 737942;
        private int _languageID = 30;
        private string _tvCtrlParameters = "19,2,1216,300,67327,17,(0:0;1:0;2:0;255:1),(),()";
        #endregion

        private MenuInfo menuInfo = null;
        private string message = "";

        private List<IRAPTreeViewNode> _treeData = new List<IRAPTreeViewNode>();
        private LinkedTreeTip _treeInfo = new LinkedTreeTip();
        private IRAPTreeViewNode _currentNode;
        private List<LeafSet> _leafSet = new List<LeafSet>();
        private LeafSet _currentLeaf = new LeafSet();
        private ImportParam _importPara = new ImportParam();
        private List<ImportMetaData> _importMetaData = new List<ImportMetaData>();
        private long _importLogId = -1;
        private bool _showPopUp = true;
        private DataTable _gridDataSource = new DataTable("grid");
        private int _firstErrorRow = 0;


        public frmGeneralImport()
        {
            InitializeComponent();
        }

        #region 创建树
        private void CreateTree()
        {
            if (_treeData == null || _treeData.Count == 0)
            {
                return;
            }
            treeList.DataSource = _treeData;
            treeList.FocusedNode = null;
        }

        private List<IRAPTreeViewNode> GetTreeList()
        {
            int errCode;
            string errText;
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);
            try
            {
                var paras = IRAPTreeClient.Instance.GetTreeViewCtrlParameters(IRAPUser.Instance.CommunityID, _tvCtrlParameters, _languageID, out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                else
                {
                    var lists = IRAPTreeClient.Instance.GetTreeViewList(IRAPUser.Instance.CommunityID, IRAPUser.Instance.SysLogID, paras, out errCode, out errText);
                    if (errCode != 0)
                    {
                        WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                        XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                    else
                    {
                        return lists;
                    }
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }
        #endregion

        #region 获取下拉列表信息
        private LinkedTreeTip GetLinkedTreeOfImpExp(int t19LeafID)
        {
            int errCode;
            string errText;
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                var lists = IRAPTreeClient.Instance.GetLinkedTreeOfImpExp(IRAPUser.Instance.CommunityID, t19LeafID, IRAPUser.Instance.SysLogID, out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                else if (lists == null || lists.Count == 0)
                {
                    return null;
                }
                else {
                    return lists[0];
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        private List<LeafSet> GetLeafSet()
        {
            int errCode;
            string errText;
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                var lists = IRAPTreeClient.Instance.GetAccessibleFilteredLeafSet(IRAPUser.Instance.CommunityID, _treeInfo.TreeID, 1, "", 255, this.comboBoxEdit1.Text, IRAPUser.Instance.SysLogID, out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                else {
                    return lists;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        private void SetSelectTitle()
        {

            var treeId = 0 - _currentNode.NodeID;

            _treeInfo = GetLinkedTreeOfImpExp(treeId);
            if (_treeInfo == null)
            {
                _treeInfo = new LinkedTreeTip();
                return;
            }
            //设置提示信息
            if (_treeInfo.TreeID == 0)
            {
                this.layoutItemSelect.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else {
                this.layoutItemSelect.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.layoutItemSelect.Text = _treeInfo.PromptStr;
            }
            var importErrType = GetErrTypesOfImport(treeId);
            SetImprotErrColor(importErrType);
        }

        /// <summary>
        /// 设置错误提示色块
        /// </summary>
        /// <param name="importErrType"></param>
        private void SetImprotErrColor(List<ImportErrorTypes> importErrType)
        {
            this.colorPanel1.InitColorPanel(importErrType);
        }

        private void SetDropDownList()
        {
            _leafSet = GetLeafSet();
            if (_leafSet == null || _leafSet.Count == 0)
            {
                return;
            }
            this.comboBoxEdit1.Properties.Items.Clear();
            foreach (LeafSet item in _leafSet)
            {
                this.comboBoxEdit1.Properties.Items.Add(item.LeafName);
            }
            //this.comboBoxEdit1.ShowPopup();
        }

        /// <summary>
        /// 获取导入校验错误类型清单
        /// </summary>
        /// <param name="t19LeafID"></param>
        /// <returns></returns>
        private List<ImportErrorTypes> GetErrTypesOfImport(int t19LeafID)
        {
            int errCode;
            string errText;
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                var lists = IRAPTreeClient.Instance.GetErrTypesOfImport(IRAPUser.Instance.CommunityID, t19LeafID, IRAPUser.Instance.SysLogID, out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                else {
                    return lists;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }
        #endregion

        #region 获取导入信息
        private LeafSet GetSelectItem(string selectText, List<LeafSet> leafSet)
        {
            if (leafSet == null || leafSet.Count == 0 || string.IsNullOrEmpty(selectText))
            {
                return null;
            }
            foreach (LeafSet leaf in leafSet)
            {
                if (selectText == leaf.LeafName)
                {
                    return leaf;
                }
            }
            return null;
        }

        private bool GetImportInfoXml()
        {
            int errCode;
            string errText;
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                IRAPTreeClient.Instance.GetImportInfoEntity(IRAPUser.Instance.CommunityID, -_currentNode.NodeID, _treeInfo.TreeID, _currentLeaf.LeafID, IRAPUser.Instance.SysLogID,
                    out _importPara, out _importMetaData, out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private bool CreateGridColumn()
        {
            this.gridView1.Columns.Clear();
            foreach (ImportMetaData item in _importMetaData)
            {
                GridColumn col = new GridColumn();
                col.FieldName = item.ColName;
                col.Caption = item.ColDisplayName;
                col.Name = item.ColName;
                col.Visible = Convert.ToInt32(item.Visible) == 1;
                col.OptionsColumn.AllowEdit = Convert.ToInt32(item.EditEnabled) == 1;
                col.Tag = item;
                this.gridView1.Columns.Add(col);
            }
            this.gridView1.BestFitColumns();
            return true;
        }

        #endregion

        #region 导入文件

        private DataTable OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Excel文件";
            ofd.FileName = "";
            ofd.Filter = "所有文件(*.*)|*.*|Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx";
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            string strName = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strName = ofd.FileName;
            }
            if (strName == "")
            {
                XtraMessageBox.Show("没有选择Excel文件！无法进行数据导入", "提示");
                return null;
            }
            else {
                var fileName = Path.GetFileName(strName);
                if (!FileNameValidate(fileName))
                {
                    return null;
                }
                if (!DeleteOldData(_importPara.DstTableName, _importLogId))
                {
                    return null;
                }
                try
                {
                    DataSet myDs = new DataSet();
                    string text = string.Format("Provider=Microsoft.Ace.OleDb.12.0 ; Data Source = '{0}';Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'", strName);
                    string excelFirstTableName = GetExcelFirstTableName(text);
                    if (string.IsNullOrEmpty(excelFirstTableName))
                    {
                        XtraMessageBox.Show("取消导入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                    myDs.Tables.Clear();
                    myDs.Clear();
                    OleDbConnection selectConnection = new OleDbConnection(text);
                    OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(string.Format("select * from [{0}]", excelFirstTableName), selectConnection);
                    oleDbDataAdapter.Fill(myDs);
                    return myDs.Tables[0];
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }

        /// <summary>
        /// 文件名合法性校验
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        private bool FileNameValidate(string fileName)
        {
            long partitioningKeySingle = IRAPUser.Instance.CommunityID * 10000;
            string uSSAddrIP = IRAPUSSAddr();
            if (uSSAddrIP == "9999")
            {
                XtraMessageBox.Show("获取社区级全局字串型参数清单发生错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _importLogId = ImportLog(uSSAddrIP, "NextUDFLogID");
            if (_importLogId == -1)
            {
                XtraMessageBox.Show("获取ImportLog发生错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var tableName = _importPara.DstTableName;//表名
            string fileNamePrefix = _importPara.FileNamePrefix;//文件名前缀
            string fileExtensionName = _importPara.FileExtensionName;//文件扩展名
            if (!string.IsNullOrEmpty(fileExtensionName))
            {
                if (fileExtensionName.IndexOf(',') == -1 && !fileName.EndsWith(fileExtensionName))
                {
                    XtraMessageBox.Show(string.Format("导入的文件扩展名不符合要求,可导入的文件扩展名有{0}", fileExtensionName), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string[] extensions = fileExtensionName.Split(',');
                bool isLegal = false;
                foreach (string extension in extensions)
                {
                    if (fileName.EndsWith(extension))
                    {
                        isLegal = true;
                        break;
                    }
                }
                if (!isLegal)
                {
                    XtraMessageBox.Show(string.Format("导入的文件扩展名不符合要求,可导入的文件扩展名有{0}", fileExtensionName), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            //验证文件名前缀是否合法
            if (!string.IsNullOrEmpty(fileNamePrefix))
            {
                if (fileName.Substring(0, fileNamePrefix.Length) != fileNamePrefix)
                {
                    XtraMessageBox.Show(string.Format("导入的文件名前缀不符合要求，要以{0}为前缀", fileNamePrefix), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private string IRAPUSSAddr()
        {
            try
            {
                int errCode = 0;
                string errText = "";

                string parameterID = "39";
                List<StrParamInfo> strparamInfo = new List<StrParamInfo>();
                IRAPSystemClient.Instance.sfn_IRAPStrParameters(IRAPUser.Instance.CommunityID, _languageID, parameterID, ref strparamInfo, out errCode, out errText);
                if (errCode == 0)
                {
                    return strparamInfo[0].ParameterValue;
                }
                return "9999";
            }
            catch (Exception ex)
            {
                return "9999";
            }
        }

        private long ImportLog(string hostIP, string sequenceName)
        {
            byte[] data = new byte[128];
            Socket newclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newclient.SendTimeout = 10;
            string ipadd = (string)hostIP;

            int port = Convert.ToInt32("13000");
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipadd), port);//服务器的IP和端口
            string sendcommand;
            try
            {
                //因为客户端只是用来向特定的服务器发送信息，所以不需要绑定本机的IP和端口。不需要监听。
                newclient.Connect(ie);
                sendcommand = string.Format("{0}|{1}", sequenceName, 1.ToString());
                newclient.Send(Encoding.ASCII.GetBytes(sendcommand));
                data = new byte[128];
                int recv = newclient.Receive(data);
                String TransactNostr = Encoding.ASCII.GetString(data, 0, recv);
                // newclient.Shutdown(SocketShutdown.Both);

                return Int64.Parse(TransactNostr);
            }
            catch (SocketException e)
            {
                // Console.WriteLine("unable to connect to server");
                // Console.WriteLine(e.ToString());
                newclient.Close();
                return -1;
            }
            finally
            {

                newclient.Close();
            }
        }

        /// <summary>
        /// 返回Excel第一个工作表表名
        /// </summary>
        /// <param name="connectstring">excel连接字符串</param>
        /// <returns></returns>
        private static string GetExcelFirstTableName(string connectstring)
        {
            using (OleDbConnection connection = new OleDbConnection(connectstring))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DataTable dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    List<string> lists = new List<string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        lists.Add(row[2].ToString());
                    }
                    using (SelectTableForm selectForm = new SelectTableForm(lists))
                    {
                        selectForm.ShowDialog();
                        if (selectForm.IsSelected)
                        {
                            return selectForm.SelectSheet;
                        }
                        else {
                            return null;
                        }
                    }
                }
                return null;
            }
        }

        private bool DeleteOldData(string tableName, long importLogId)
        {
            int errCode;
            string errText;
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                IRAPTreeClient.Instance.DeleteOldTableData(tableName, importLogId, out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 列名校验
        /// </summary>
        /// <param name="excelData">excel数据</param>
        /// <returns>校验是否通过</returns>
        private bool ColumnValidate(DataTable excelData)
        {
            CreateGridColumn();
            if (excelData == null || excelData.Rows.Count == 0 || excelData.Columns.Count == 0)
            {
                return false;
            }
            DataTable data = new DataTable("grid");
            foreach (ImportMetaData metaData in _importMetaData)
            {
                if (metaData.Nullable != 1)
                {
                    continue;
                }
                foreach (DataColumn column in excelData.Columns)
                {
                    if (column.ColumnName == metaData.ColName)
                    {
                        if (!ColumnDataTypeValidate(column.ColumnName, column.DataType, metaData.ColType))
                        {
                            return false;
                        }
                        DataColumn dataCol = new DataColumn(column.ColumnName, column.DataType);
                        dataCol.Caption = metaData.ColDisplayName;
                        data.Columns.Add(dataCol);
                    }
                }

            }
            _gridDataSource = data;
            return true;
        }

        /// <summary>
        /// 列类型检查
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="excelColumnType">excel中获取的列的数据类型</param>
        /// <param name="columnType">元数据中定义的列的数据类型</param>
        /// <returns>是否匹配</returns>
        private bool ColumnDataTypeValidate(string columnName, Type excelColumnType, string columnType)
        {
            if (string.IsNullOrEmpty(columnType))
            {
                XtraMessageBox.Show(string.Format("导入{0}列类型错误，应为{1}类型，当前类型{2}，请检查！", columnName, columnType, excelColumnType.ToString()), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            switch (excelColumnType.ToString())
            {
                default:
                    return true;
                case "System.Double":
                    switch (columnType)
                    {
                        case "bigint":
                        case "int":
                        case "decimal":
                        case "bit":
                            return true;
                    }
                    break;
                case "System.DateTime":
                    switch (columnType)
                    {
                        case "DateTime":
                            return true;
                    }
                    break;
            }
            XtraMessageBox.Show(string.Format("导入{0}列类型错误，应为{1}类型，当前类型{2}，请检查！", columnName, columnType, excelColumnType.ToString()), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;

        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="data">excel表中数据</param>
        /// <returns>是否成功</returns>
        private bool InsertData(DataTable data)
        {
            if (data.Rows.Count == 0)
            {
                XtraMessageBox.Show("导入的excel中无数据，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            foreach (DataRow row in data.Rows)
            {
                DataRow newRow = _gridDataSource.NewRow();
                foreach (DataColumn col in _gridDataSource.Columns)
                {
                    newRow[col.ColumnName] = row[col.ColumnName];
                }
                _gridDataSource.Rows.Add(newRow);
            }
            return true;
        }

        /// <summary>
        /// 将缓存数据保存到临时表中
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            int errCode;
            string errText;
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                var data = CreateDataCach();
                IRAPTreeClient.Instance.InsertTempTableData(_importPara.DstTableName, data, out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else {
                    return true;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 构建临时表数据
        /// </summary>
        /// <returns>；临时表数据</returns>
        private DataTable CreateDataCach()
        {
            DataTable dt = _gridDataSource.Copy();
            dt.Columns.Add("PartitioningKey", typeof(Int64));
            dt.Columns.Add("ImportLogID", typeof(Int64));
            dt.Columns.Add("T19LeafID", typeof(int));
            dt.Columns.Add("TxLeafID", typeof(int));
            dt.Columns.Add("SysLogID", typeof(Int64));
            dt.Columns.Add("ImportUnixTime", typeof(int));
            dt.Columns.Add("ErrCode", typeof(int));
            dt.Columns.Add("ErrText", typeof(string));
            dt.Columns.Add("BGColor", typeof(string));

            var coummunityID = IRAPUser.Instance.CommunityID * 10000;

            var time = GetUnxiTime();
            if (time == 0)
            {
                return null;
            }
            foreach (DataRow row in dt.Rows)
            {
                row["PartitioningKey"] = coummunityID;
                row["ImportLogID"] = _importLogId;
                row["T19LeafID"] = -_currentNode.NodeID;
                row["TxLeafID"] = _currentLeaf.LeafID;
                row["SysLogID"] = IRAPUser.Instance.SysLogID;
                row["ImportUnixTime"] = time;
                row["ErrCode"] = 0;
                row["ErrText"] = "通过";
                row["BGColor"] = "";
            }
            return dt;
        }


        /// <summary>
        /// 获取UnixTime
        /// </summary>
        /// <returns></returns>
        private int GetUnxiTime()
        {
            int errCode = 0;
            string errText = "";
            string strProcedureName =
              string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                var time = IRAPTreeClient.Instance.GetLocalUnixTime(out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return time;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
        #endregion

        #region 设置列格式
        /// <summary>
        /// 删除没有数据且配置为可空白的列
        /// </summary>
        private void DeleteEmptyColumn()
        {
            for (int i = 0; i < this.gridView1.Columns.Count; i++)
            {
                bool isNotEmpty = false;
                for (int j = 0; j < this.gridView1.RowCount; j++)
                {
                    var cell = this.gridView1.GetRowCellValue(j, this.gridView1.Columns[i]);
                    if (cell == null || string.IsNullOrEmpty(cell.ToString()))
                    {
                        continue;
                    }
                    isNotEmpty = true;
                    break;
                }
                if (isNotEmpty)
                {
                    continue;
                }
                var tag = this.gridView1.Columns[i].Tag as ImportMetaData;
                if (tag.Nullable == 0)
                {
                    continue;
                }
                this.gridView1.Columns.RemoveAt(i);
                i--;
            }
        }

        /// <summary>
        /// 删除空白行
        /// </summary>
        private void DeleteEmptyRow()
        {
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                var hasValue = false;
                for (int j = 0; j < this.gridView1.Columns.Count; j++)
                {
                    var currnetCol = this.gridView1.Columns[j];
                    var value = this.gridView1.GetRowCellValue(i, currnetCol);
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                    {
                        continue;
                    }
                    hasValue = true;
                    break;
                }
                if (hasValue)
                {
                    continue;
                }
                this.gridView1.DeleteRow(i);
                i--;
            }
        }

        /// <summary>
        /// 根据配置设置列格式
        /// </summary>
        private void SetColumnStyle()
        {
            foreach (GridColumn col in this.gridView1.Columns)
            {
                var tag = col.Tag as ImportMetaData;
                col.OptionsColumn.AllowEdit = tag.EditEnabled == 0 ? false : true;
                switch (tag.Alignment)
                {
                    default:
                    case "center":
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        break;
                    case "left":
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                        break;
                    case "right":
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        break;
                }
                for (int i = 0; i < this.gridView1.RowCount; i++)
                {
                    var color = this.gridView1.GetRowCellValue(i, col);
                    if (color == null || string.IsNullOrEmpty(color.ToString()))
                    {
                        continue;
                    }
                }
            }
        }
        #endregion

        #region 事件

        private void frmGeneralImport_Load(object sender, EventArgs e)
        {
            //_treeData = GetTreeList();
            //CreateTree();
        }

        private void treeList_AfterFocusNode(object sender, NodeEventArgs e)
        {
            var node = this.treeList.GetDataRecordByNode(e.Node) as IRAPTreeViewNode;
            if (node.NodeID > 0)
            {
                return;
            }
            _currentNode = node;
            ClearData();
            SetSelectTitle();
        }

        private void comboBoxEdit1_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearPanelData();
            var selectItem = this.comboBoxEdit1.SelectedText;
            _currentLeaf = GetSelectItem(selectItem, _leafSet);
            if (_currentLeaf == null)
            {
                return;
            }
            if (!GetImportInfoXml())
            {
                return;
            }
            this.btnImport.Enabled = CreateGridColumn();
            _showPopUp = false;
        }

        private void comboBoxEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (!this.layoutControlGroup2.Visible)
            {
                return;
            }
            SetDropDownList();
        }

        private void comboBoxEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!this.layoutControlGroup2.Visible)
                {
                    return;
                }
                if (this.comboBoxEdit1.IsPopupOpen)
                {
                    this.comboBoxEdit1.ClosePopup();
                }
                if (!_showPopUp)
                {
                    _showPopUp = true;
                    return;
                }
                this.comboBoxEdit1.ShowPopup();
                e.Handled = true;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.btnValidate.Enabled = false;
            var excelData = OpenFile();
            if (!ColumnValidate(excelData) || !InsertData(excelData))
            {
                return;
            }

            //todo:设置grid格式
            this.gridControl1.DataSource = _gridDataSource;
            DeleteEmptyColumn();
            DeleteEmptyRow();
            SetColumnStyle();
            SaveData();
            this.btnValidate.Enabled = true;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            this.btnLoad.Enabled = false;
            this.btnLoadPart.Enabled = false;
            SetStateLabel("", 0);

            var data = GetVerifyResult();
            _gridDataSource = data;
            this.gridControl1.DataSource = _gridDataSource;
            if (data == null || data.Rows.Count == 0)
            {
                SetStateLabel("验证不通过，请检查!", 1);
                return;
            }
            var correntNum = ColumnDataValidate();
            if (correntNum == this.gridView1.RowCount)
            {
                this.btnLoad.Enabled = true;
                SetStateLabel("验证通过!", 0);
                return;
            }
            SetStateLabel("验证不通过，请检查!", 1);
            if (correntNum > 0)
            {
                this.btnLoadPart.Enabled = true;
            }
            this.gridView1.SelectRows(_firstErrorRow, _firstErrorRow);

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Loading();
        }

        private void btnLoadPart_Click(object sender, EventArgs e)
        {
            Loading();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出数据信息";
            fileDialog.Filter = "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var extension = Path.GetExtension(fileDialog.FileName);
                try
                {
                    switch (extension)
                    {
                        case ".xls":
                            gridControl1.ExportToXls(fileDialog.FileName);
                            break;
                        case ".xlsx":
                            gridControl1.ExportToXlsx(fileDialog.FileName);
                            break;
                    }
                    MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("导出失败！", "提示", MessageBoxButtons.OK);
                }
            }
        }

        #endregion

        #region 验证

        /// <summary>
        /// 获取验证后的数据
        /// </summary>
        /// <returns>验证后的数据</returns>
        private DataTable GetVerifyResult()
        {
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                var data = IRAPTreeClient.Instance.GetDataAfterVerify(IRAPUser.Instance.CommunityID, -_currentNode.NodeID, _treeInfo.TreeID, _currentLeaf.LeafID, _importLogId, IRAPUser.Instance.SysLogID, _importPara.DstTableName, _importPara.ProcOnVerification, out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return data;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        /// <summary>
        /// 插入错误信息
        /// </summary>
        private int ColumnDataValidate()
        {
            _firstErrorRow = 0;
            int corrent = 0;
            var errCodeCol = this.gridView1.Columns["ErrCode"];
            var errTextCol = this.gridView1.Columns["ErrText"];
            var color = this.gridView1.Columns["BGColor"];
            if (errCodeCol == null || errTextCol == null)
            {
                return corrent;
            }
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                var errCode = this.gridView1.GetRowCellValue(i, errCodeCol);
                var currentRow = this.gridView1.GetRow(i) as DataRowView;
                if (errCode == null || Convert.ToInt32(errCode) == 0)
                {
                    currentRow.Row.RowError = "";
                    corrent++;
                    continue;
                }
                if (corrent == i)
                {
                    _firstErrorRow = i;
                }
                var errText = this.gridView1.GetRowCellValue(i, errTextCol);
                currentRow.Row.RowError = errText == null ? "" : errText.ToString();
                //var currentColor = this.gridView1.GetRowCellValue(i, color);
                //if (currentColor != null) {
                //    SetRowColor(i, currentColor.ToString(), "");
                //}
            }
            return corrent;
        }


        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var col = this.gridView1.Columns["BGColor"];
                var colValue = this.gridView1.GetRowCellValue(e.RowHandle, col);
                if (colValue == null || string.IsNullOrEmpty(colValue.ToString()))
                {
                    return;
                }
                var color = ConvertColorHx16ToRGB(colValue.ToString());
                e.Appearance.BackColor = color;
                //e.Appearance.BackColor2 = Color.SeaShell;
            }
        }

        //private void SetRowColor(int rowHandle,string bgColor,string value) { 
        //    var col = this.gridView1.Columns["BGColor"];
        //    var style = new DevExpress.XtraGrid.StyleFormatCondition(FormatConditionEnum.Equal,col,null,value);
        //    style.ApplyToRow = true;
        //    style.Appearance.BackColor = string.IsNullOrEmpty(bgColor) ? Color.Transparent : ConvertColorHx16ToRGB(bgColor);
        //}

        /// <summary>
        /// [颜色：16进制转成RGB]
        /// </summary>
        /// <param name="strColor">设置16进制颜色 [返回RGB]</param>
        /// <returns></returns>
        private static System.Drawing.Color ConvertColorHx16ToRGB(string strHxColor)
        {
            try
            {
                if (strHxColor.Length == 0)
                {//如果为空
                    return System.Drawing.Color.FromArgb(0, 0, 0);//设为黑色
                }
                else {//转换颜色
                    return System.Drawing.Color.FromArgb(System.Int32.Parse(strHxColor.Substring(1, 2), System.Globalization.NumberStyles.AllowHexSpecifier), System.Int32.Parse(strHxColor.Substring(3, 2), System.Globalization.NumberStyles.AllowHexSpecifier), System.Int32.Parse(strHxColor.Substring(5, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
                }
            }
            catch
            {//设为黑色
                return System.Drawing.Color.FromArgb(0, 0, 0);
            }
        }

        #endregion

        #region 加载/部分加载
        /// <summary>
        /// 获取加载后数据
        /// </summary>
        private DataTable GetLoadResult(int isLoadAll, int isLoadLog)
        {
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                var data = IRAPTreeClient.Instance.GetDataAfterLoad(IRAPUser.Instance.CommunityID, -_currentNode.NodeID, _treeInfo.TreeID, _currentLeaf.LeafID, _importLogId, IRAPUser.Instance.SysLogID, _importPara.DstTableName, _importPara.ProcOnLoad, isLoadAll, isLoadLog, out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return data;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        /// <summary>
        /// 加载
        /// </summary>
        private void Loading()
        {
            var isLoadAll = this.checkEditImportAll.Checked ? 1 : 0;
            var isLoadLog = this.checkEditLog.Checked ? 1 : 0;
            var data = GetLoadResult(isLoadAll, isLoadLog);
            if (data == null || data.Rows.Count == 0)
            {
                SetStateLabel("加载不通过，请检查！!", 1);
                return;
            }
            _gridDataSource = data;
            this.gridControl1.DataSource = _gridDataSource;
            var correntNum = ColumnDataValidate();
            if (correntNum == this.gridView1.RowCount)
            {
                SetStateLabel("加载通过！", 0);
                this.btnExport.Enabled = true;
                return;
            }
            SetStateLabel("加载不通过，请检查！!", 1);
            this.gridView1.SelectRows(_firstErrorRow, _firstErrorRow);
            if (correntNum > 0)
            {
                this.btnExport.Enabled = true;
            }
        }

        #endregion

        private void ClearData()
        {
            this.comboBoxEdit1.Text = "";
            ClearPanelData();
            this.colorPanel1.ClearLabel();
        }

        private void ClearPanelData()
        {
            _gridDataSource = null;
            this.gridControl1.DataSource = _gridDataSource;
            this.gridView1.Columns.Clear();
            this.btnLoadPart.Enabled = false;
            this.btnLoad.Enabled = false;
            this.btnImport.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnValidate.Enabled = false;
        }

        private void SetStateLabel(string errText, int errCode)
        {
            this.labelState.Text = errText;
            if (errCode != 0)
            {
                this.labelState.ForeColor = Color.Red;
            }
            else {
                this.labelState.ForeColor = Color.Green;
            }
        }

        private void frmGeneralImport_Shown(object sender, EventArgs e)
        {
            _communityID = IRAPUser.Instance.CommunityID;
            _sysLogID = IRAPUser.Instance.SysLogID;
            _languageID = IRAPUser.Instance.LanguageID;

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (this.Tag is MenuInfo)
                {
                    menuInfo = this.Tag as MenuInfo;

                    _tvCtrlParameters = menuInfo.TVCtrlParameters;

                    _treeData = GetTreeList();
                    CreateTree();
                }
                else
                {
                    WriteLog.Instance.Write("没有正确的传入菜单参数", strProcedureName);

                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        message = "Menu parameters is incorrect!";
                    else
                        message = "没有正确的传入菜单参数！";

                    IRAPMessageBox.Instance.ShowErrorMessage(
                        message,
                        caption);
                    return;
                }

            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }
    }
}