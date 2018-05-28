using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Linq;

using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Repository;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global.GUI;
using IRAP.Entity.MDM;
using IRAP.Entity.Kanban;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MDM
{
    public partial class frmOperationManager_30 : frmCustomFuncBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<ProcessOperation> listProcessOperations = new List<ProcessOperation>();
        private DataTable dtProcessOperations = new DataTable();
        private DataTable dtProcess = new DataTable();
        private DataTable dtSections = new DataTable();
        private DataTable dtParts = new DataTable();
        private object gridViewProcess;

        public frmOperationManager_30()
        {
            InitializeComponent();

            InitGridView();
        }

        private void InitGridView()
        {
            grdvProcesses.OptionsView.ShowGroupPanel = false;
            grdvProcesses.OptionsView.ShowIndicator = true;
            grdvProcesses.IndicatorWidth = 40;
            grdvProcesses.OptionsSelection.MultiSelect = false;
            grdvProcesses.VertScrollVisibility = ScrollVisibility.Auto;
            grdvProcesses.HorzScrollVisibility = ScrollVisibility.Never;
            grdvProcesses.OptionsMenu.EnableColumnMenu = false;
            grdvProcesses.OptionsBehavior.Editable = true;
            grdvProcesses.OptionsCustomization.AllowFilter = false;
            grdvProcesses.OptionsCustomization.AllowSort = false;
            grdvProcesses.OptionsBehavior.AllowAddRows = DefaultBoolean.True;
        }

        private void GetProcessOperations()
        {
            int errCode = 0;
            string errText = "";

            try
            {
                IRAPMDMClient.Instance.ufn_GetList_ProcessOperations(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref listProcessOperations,
                    out errCode,
                    out errText);
                if (errCode == 0)
                {
                    dtProcessOperations = new DataTable();
                    dtProcessOperations.Columns.Add("Level", typeof(int));
                    dtProcessOperations.Columns.Add("T216Leaf", typeof(int));
                    dtProcessOperations.Columns.Add("T216Code", typeof(string));
                    dtProcessOperations.Columns.Add("T216Name", typeof(string));
                    dtProcessOperations.Columns.Add("T116Leaf", typeof(int));
                    dtProcessOperations.Columns.Add("T116Name", typeof(string));
                    dtProcessOperations.Columns.Add("T124Leaf", typeof(int));
                    dtProcessOperations.Columns.Add("T124Name", typeof(string));
                    dtProcessOperations.Columns.Add("T123Leaf", typeof(int));
                    dtProcessOperations.Columns.Add("T123Name", typeof(string));
                    foreach (ProcessOperation model in listProcessOperations)
                    {
                        DataRow dr = dtProcessOperations.NewRow();
                        dr["Level"] = model.Ordinal;
                        dr["T216Leaf"] = model.T216Leaf;
                        dr["T216Code"] = model.T216Code;
                        dr["T216Name"] = model.T216Name;
                        dr["T116Leaf"] = model.T116Leaf;
                        dr["T116Name"] = model.T116Name;
                        dr["T124Leaf"] = model.T124Leaf;
                        dr["T124Name"] = model.T124Name;
                        dr["T123Leaf"] = model.T123Leaf;
                        dr["T123Name"] = model.T123Name;
                        dtProcessOperations.Rows.Add(dr);
                    }
                    grdProcesses.DataSource = dtProcessOperations;
                }
                else
                {
                    XtraMessageBox.Show(
                        errText,
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            GetAccessibleLeafSetExs(repositoryItemLookUpEdit1, 116, 1, ref dtProcess);
            GetAccessibleLeafSetExs(repositoryItemLookUpEdit2, 124, 1, ref dtSections);
            GetAccessibleLeafSetExs(repositoryItemLookUpEdit3, 123, 1, ref dtParts);
        }

        private void GetAccessibleLeafSetExs(
            RepositoryItemLookUpEdit combobox,
            int treeID,
            int scenarioIndex,
            ref DataTable dt)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<LeafSetEx> list = new List<LeafSetEx>();
                try
                {
                    IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                        IRAPUser.Instance.CommunityID,
                        treeID,
                        scenarioIndex,
                        IRAPUser.Instance.SysLogID,
                        ref list,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("id", typeof(int));
                        dt.Columns.Add("text", typeof(string));
                        foreach (LeafSetEx model in list)
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = model.LeafID;
                            dr[1] = model.LeafName;
                            dt.Rows.Add(dr);
                        }
                        combobox.ValueMember = "id";
                        combobox.DisplayMember = "text";
                        combobox.NullText = string.Empty;
                        combobox.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show(
                            errText,
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    MessageBox.Show(
                        error.Message,
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void SaveProcessOperation(
            ref int t216Leaf,
            string t216Code,
            string t216Name,
            int t116Leaf,
            int t124Leaf,
            int t123Leaf,
            out int errCode,
            out string errText)
        {
            errCode = 0;
            errText = "";
            try
            {
                IRAPMDMClient.Instance.usp_SaveAttr_ProcessOperation(
                    IRAPUser.Instance.CommunityID,
                        ref t216Leaf,
                        t216Code,
                        t216Name,
                        t116Leaf,
                        t124Leaf,
                        t123Leaf,
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    error.Message,
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }

        private bool HadEdited(
            int index,
            ref string t216Code,
            ref string t216Name,
            ref int t116Leaf,
            ref int t124Leaf,
            ref int t123Leaf)
        {
            bool result = false;
            if (index + 1 <= listProcessOperations.Count)
            {
                if (!t216Code.Equals(listProcessOperations[index].T216Code))
                {
                    result = true;
                }
                else
                {
                    t216Code = "";
                }
                if (!t216Name.Equals(listProcessOperations[index].T216Name))
                {
                    result = true;
                }
                else
                {
                    t216Name = "";
                }
                if (t116Leaf != listProcessOperations[index].T116Leaf)
                {
                    result = true;
                }
                else
                {
                    t116Leaf = 0;
                }
                if (t124Leaf != listProcessOperations[index].T124Leaf)
                {
                    result = true;
                }
                else
                {
                    t124Leaf = 0;
                }
                if (t123Leaf != listProcessOperations[index].T123Leaf)
                {
                    result = true;
                }
                else
                {
                    t123Leaf = 0;
                }
            }
            else
            {
                if (!IsAllEmptyText(index)) result = true;
            }
            return result;
        }

        /// <summary>
        /// 获取Excel文件数据列表
        /// </summary>
        public DataTable ExcelToDT(string filePath)
        {
            IWorkbook workbook;
            try
            {
                using (FileStream file =
                    new FileStream(
                        filePath,
                        FileMode.Open,
                        FileAccess.Read))
                {
                    workbook = new XSSFWorkbook(file);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            ISheet sheet = workbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            DataTable dt = new DataTable();

            //一行最后一个方格的编号 即总的列数  
            for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
            {
                dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
            }
            if (dt.Columns.Count == 0) return dt;
            int r = 0;
            while (rows.MoveNext())
            {
                if (r == 0)
                {
                    r++;
                    continue;
                }
                IRow row = (XSSFRow)rows.Current;
                DataRow dr = dt.NewRow();

                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);

                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private bool CheckAllProcessCode(out string errText)
        {
            bool result = false;
            errText = "";
            int rowIndex = 0;
            foreach (DataRow dr in dtProcessOperations.Rows)
            {
                string t216Code = dr["T216Code"].ToString();
                if (!string.IsNullOrEmpty(t216Code))
                {
                    var query = from tb in dtProcessOperations.AsEnumerable()
                                where tb.Field<string>("T216Code") == t216Code
                                select tb;
                    if (query.Count() > 1)
                    {
                        errText = string.Format("第{0}行工序代码出现重复！", rowIndex + 1);
                        return true;
                    }
                }
                rowIndex++;
            }
            return result;
        }

        private bool CheckProcessOperation(out string errText)
        {
            bool result = true;
            errText = "";
            for (int i = 0; i < grdvProcesses.RowCount; i++)
            {
                if (i + 1 <= listProcessOperations.Count)
                {
                    if (IsAllEmptyText(i))
                    {
                        errText = string.Format("第{0}行记录不能全部编辑为空！", i + 1);
                        return false;
                    }
                }
                for (int j = 0; j < grdvProcesses.Columns.Count; j++)
                {
                    string text =
                        grdvProcesses.GetRowCellDisplayText(
                            i,
                            grdvProcesses.Columns[j]).ToString();
                    if (string.IsNullOrEmpty(text))
                    {
                        if (!IsAllEmptyText(i))
                        {
                            errText =
                                string.Format(
                                    "第{0}行第{1}列值不能为空，请填写！",
                                    i + 1,
                                    j + 2);
                            return false;
                        }
                    }
                }
            }
            return result;
        }

        private bool IsAllEmptyText(int rowIndex)
        {
            bool result = true;
            for (int c = 0; c < grdvProcesses.Columns.Count; c++)
            {
                string text =
                    grdvProcesses.GetRowCellDisplayText(
                        rowIndex,
                        grdvProcesses.Columns[c]).ToString();
                if (!string.IsNullOrEmpty(text)) return false;
            }
            return result;
        }

        private void frmOperationManager_30_Shown(object sender, EventArgs e)
        {
            GetProcessOperations();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            grdvProcesses.AddNewRow();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(
                "请确定是否保存修改记录？",
                "提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int errCode = 0;
                string errText = "";
                if (!CheckProcessOperation(out errText))
                {
                    XtraMessageBox.Show(
                        errText,
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                if (CheckAllProcessCode(out errText))
                {
                    XtraMessageBox.Show(
                        errText,
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                Boolean allRight = true;
                int editNum = 0;
                for (int i = 0; i < dtProcessOperations.Rows.Count; i++)
                {
                    int t216Leaf = 0;
                    string t216Code = "";
                    string t216Name = "";
                    int t116Leaf = 0;
                    string t116Name = "";
                    int t124Leaf = 0;
                    string t124Name = "";
                    int t123Leaf = 0;
                    string t123Name = "";

                    int.TryParse(dtProcessOperations.Rows[i]["T216Leaf"].ToString(), out t216Leaf);
                    t216Code = dtProcessOperations.Rows[i]["T216Code"].ToString();
                    t216Name = dtProcessOperations.Rows[i]["T216Name"].ToString();
                    int.TryParse(dtProcessOperations.Rows[i]["T116Leaf"].ToString(), out t116Leaf);
                    t116Name = dtProcessOperations.Rows[i]["T116Name"].ToString();
                    int.TryParse(dtProcessOperations.Rows[i]["T124Leaf"].ToString(), out t124Leaf);
                    t124Name = dtProcessOperations.Rows[i]["T124Name"].ToString();
                    int.TryParse(dtProcessOperations.Rows[i]["T123Leaf"].ToString(), out t123Leaf);
                    t123Name = dtProcessOperations.Rows[i]["T123Name"].ToString();
                    if (HadEdited(i, ref t216Code, ref t216Name, ref t116Leaf, ref t124Leaf, ref t123Leaf))
                    {
                        SaveProcessOperation(
                            ref t216Leaf,
                            t216Code,
                            t216Name,
                            t116Leaf,
                            t124Leaf,
                            t123Leaf,
                            out errCode,
                            out errText);
                        if (errCode == 0)
                        {
                            editNum++;
                            //更新内存表
                            dtProcessOperations.Rows[i]["T216Leaf"] = t216Leaf;
                            //更新List
                            //Boolean HadEditList = false;
                            //for (int m = 0; m < listProcessOperations.Count; m++)
                            //{
                            //    if (listProcessOperations[m].T216Leaf == t216Leaf)
                            //    {
                            //        listProcessOperations[m].T216Code = t216Code;
                            //        listProcessOperations[m].T216Name = t216Name;
                            //        listProcessOperations[m].T123Leaf = t123Leaf;
                            //        listProcessOperations[m].T123Name = t123Name;
                            //        listProcessOperations[m].T124Leaf = t124Leaf;
                            //        listProcessOperations[m].T124Name = t124Name;
                            //        listProcessOperations[m].T116Leaf = t116Leaf;
                            //        listProcessOperations[m].T116Name = t116Name;
                            //        HadEditList = true;
                            //        break;
                            //    }
                            //}
                            //if (!HadEditList)
                            //{
                            //    TEntityProcessOperation newOP = new TEntityProcessOperation();
                            //    newOP.T123Leaf = t216Leaf;
                            //    newOP.T216Code = t216Code;
                            //    newOP.T216Name = t216Name;
                            //    newOP.T123Leaf = t123Leaf;
                            //    newOP.T123Name = t123Name;
                            //    newOP.T124Leaf = t124Leaf;
                            //    newOP.T124Name = t124Name;
                            //    newOP.T116Leaf = t116Leaf;
                            //    newOP.T116Name = t116Name;
                            //    listProcessOperations.Add(newOP);
                            //} 
                        }
                        else
                        {
                            allRight = false;
                            XtraMessageBox.Show(
                                errText,
                                "提示",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            break;
                        }
                    }
                }
                if (allRight && editNum > 0)
                {
                    GetProcessOperations();
                    XtraMessageBox.Show(
                        "保存成功！",
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                if (allRight && editNum == 0)
                {
                    XtraMessageBox.Show(
                        "没有需要保存的数据！",
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (Dialogs.frmProcessOperationEdit frmImport = new Dialogs.frmProcessOperationEdit())
            {
                if (frmImport.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = ExcelToDT(frmImport.FileName);
                    if (dt.Columns.Count != 2)
                    {
                        XtraMessageBox.Show(
                            "请检查导入的文件模版是否符合规范！",
                            "提示",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    grdvProcesses.AddNewRow();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string t216Code = dr[0].ToString();
                        string t216Name = dr[1].ToString();
                        int newIndex = grdvProcesses.RowCount - 1;
                        grdvProcesses.AddNewRow();
                        grdvProcesses.SetRowCellValue(newIndex, gridColumn1, t216Code);
                        grdvProcesses.SetRowCellValue(newIndex, gridColumn2, t216Name);
                    }
                    grdvProcesses.DeleteSelectedRows();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetProcessOperations();
        }

        private void grdvProcesses_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.VisibleIndex == 0)
            {
                var query = from tb in dtProcessOperations.AsEnumerable()
                            where tb.Field<string>("T216Code") == e.Value.ToString()
                            select tb;
                if (query.Count() > 1)
                {
                    XtraMessageBox.Show(
                        "存在重复记录:" + e.Value.ToString() + "，请重命名代码！",
                        "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void grdvProcesses_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
