using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Threading;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraVerticalGrid.Rows;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global;
using IRAP.Client.Global.Enums;
using IRAP.Entities.MDM;
using IRAP.Entities.MES;
using IRAP.Entities.IRAP;
using IRAP.WCF.Client.Method;
using IRAP.Client.GUI.BatchSystem.Dialogs;
using IRAP.Client.GUI.BatchSystem.Tools;
using IRAP.Client.GUI.BatchSystem.Entities;

namespace IRAP.Client.GUI.BatchSystem.UserControls
{
    public partial class ucPrdtParams_Furnace : DevExpress.XtraEditors.XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string caption = "";

        private WIPStation stationInfo = null;
        private List<FurnaceInfo> batchNos = new List<FurnaceInfo>();
        private FurnaceInfo currentFurnace = null;
        /// <summary>
        /// 生产过程参数数据表
        /// </summary>
        private DataTable dtParams = new DataTable();
        /// <summary>
        /// 生产过程参数集
        /// </summary>
        private List<ProductionProcessParam> ppp = new List<ProductionProcessParam>();

        /// <summary>
        /// 暂存的已备料的信息文件名
        /// </summary>
        private string tempMaterialPreparationFile = "";

        public ucPrdtParams_Furnace()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System information";
            else
                caption = "系统信息";

            ilstBatchNos.Items.Clear();

            string directory = $"{AppDomain.CurrentDomain.BaseDirectory}Temp\\";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            tempMaterialPreparationFile = $"{directory}MaterialPreparation.mp";
        }

        public ucPrdtParams_Furnace(WIPStation station) : this()
        {
            stationInfo = station;
        }

        private T LoadFromFile<T>(string fileName)
        {
            string buffer = "";

            if (File.Exists(fileName))
            {
                StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    buffer += temp;
                }
                sr.Close();
            }

            if (buffer != "")
            {
                return JSONHelper.GetObjectFromJSON<T>(buffer);
            }
            else
            {
                return Activator.CreateInstance<T>();
            }
        }

        private void SaveToFile(string fileName, string fileContent)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            byte[] data = Encoding.UTF8.GetBytes(fileContent);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }

        private void InitFurnaceInfo(FurnaceInfo furnace)
        {
            switch (furnace.PrdtStatus)
            {
                case ProductionStatus.Idle:
                    if (furnace != null)
                    {
                        grdPWOs.DataSource = furnace.PWOs;
                    }
                    else
                    {
                        grdPWOs.DataSource = null;
                    }
                    grdvPWOs.BestFitColumns();

                    edtOperatorCode.Text = "";
                    lblBatchNo.Text = "";
                    lblProductTimeSpan.Text = "";

                    GetMethodStandards(0, 0, "");

                    break;
                case ProductionStatus.Busy:
                    TWaitting.Instance.ShowWaitForm("初始化生产过程参数......");
                    try
                    {
                        grdPWOs.DataSource = furnace.PWOs;
                        grdvPWOs.BestFitColumns();

                        edtOperatorCode.Text = $"{furnace.OperatorCode}[{furnace.OperatorName}]";
                        lblBatchNo.Text = furnace.BatchNumber;

                        // 如果当前生产批次号中有工单，则获取生产过程参数
                        if (furnace.PWOs.Count > 0)
                        {
                            GetMethodStandards(0, stationInfo.T216LeafID, furnace.BatchNumber);
                        }
                        else
                        {
                            GetMethodStandards(0, 0, "");
                        }
                    }
                    finally
                    {
                        TWaitting.Instance.CloseWaitForm();
                    }
                    break;
            }

            Refresh();

            if (edtOperatorCode.Enabled)
            {
                edtOperatorCode.Focus();
            }
        }

        /// <summary>
        /// 获取当前站点的生产信息
        /// </summary>
        /// <returns></returns>
        private List<BatchProductInfo> GetWorkUnitProductionInfo()
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
                List<BatchProductInfo> datas = new List<BatchProductInfo>();

                IRAPMESClient.Instance.ufn_GetList_BatchProduct(
                    IRAPUser.Instance.CommunityID,
                    stationInfo.T107LeafID,
                    stationInfo.T216LeafID,
                    stationInfo.T133LeafID,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                return datas;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据 ID 卡的卡号查找操作工
        /// </summary>
        /// <param name="idCode">ID 卡卡号</param>
        /// <returns></returns>
        private STB006 GetUserInfoWithIDCode(string idCode)
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
                List<STB006> users = new List<STB006>();

                IRAPUserClient.Instance.mfn_GetList_Users(
                    IRAPUser.Instance.CommunityID,
                    "",
                    idCode,
                    ref users,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return null;
                }
                else
                {
                    if (users.Count == 0)
                    {
                        XtraMessageBox.Show(
                            string.Format(
                                "未找到[{0}]的用户",
                                idCode),
                            caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return null;
                    }
                    else
                    {
                        return users[0];
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 生成生产开始的输入参数 XML 串
        /// </summary>
        /// <param name="pwos"></param>
        /// <returns></returns>
        private string GenerateBatchProductionStartXML(List<EntityBatchPWO> pwos)
        {
            string rlt = "";
            int idx = 1;
            foreach (EntityBatchPWO pwo in pwos)
            {
                rlt +=
                    string.Format(
                        "<RF25 Ordinal=\"{0}\" T102LeafID=\"{1}\" " +
                        "T216LeafID=\"{2}\" WIPCode=\"\" LotNumber=\"{3}\" " +
                        "Texture=\"{4}\" PWONo=\"{5}\" BatchLot=\"\" " +
                        "Qty=\"{6}\" Scale=\"0\" />\n",
                        idx++,
                        pwo.T102LeafID,
                        stationInfo.T216LeafID,
                        pwo.LotNumber,
                        pwo.Texture,
                        pwo.PWONo,
                        pwo.Quantity);
            }
            rlt = string.Format("<RSFact>\n{0}</RSFact>", rlt);

            return rlt;
        }

        /// <summary>
        /// 获取检验项目及检验值
        /// </summary>
        /// <param name="t131LeafID">工序叶标识</param>
        /// <param name="t216LeafID">环别叶标识</param>
        /// <param name="batchNumber">炉次号</param>
        private void GetMethodStandards(
            int t131LeafID,
            int t216LeafID,
            string batchNumber)
        {
            if (t131LeafID == 0 && t216LeafID==0 && string.IsNullOrEmpty(batchNumber))
            {
                ppp = new List<ProductionProcessParam>();
                InitMethodParamsGrid(ppp);
                return;
            }

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

                IRAPMDMClient.Instance.ufn_GetList_MethodItems(
                    IRAPUser.Instance.CommunityID,
                    t131LeafID,
                    t216LeafID,
                    batchNumber,
                    IRAPUser.Instance.SysLogID,
                    ref ppp,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        string.Format("在获取生产过程参数时发生错误：[{0}]", errText),
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    InitMethodParamsGrid(ppp);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 初始化生产过程参数列表
        /// </summary>
        /// <param name="ppParams"></param>
        private void InitMethodParamsGrid(List<ProductionProcessParam> ppParams)
        {
            dtParams.Clear();
            dtParams.Columns.Clear();

            vgrdMethodParams.Rows.Clear();

            foreach (ProductionProcessParam param in ppParams)
            {
                string colName = string.Format("Column{0}", param.Ordinal);
                DataColumn dc = dtParams.Columns.Add(colName, typeof(string));
                dc.Caption = param.T20Name;

                EditorRow row = new EditorRow();
                row.Properties.Caption = param.T20Name;
                row.Properties.FieldName = colName;
                vgrdMethodParams.Rows.Add(row);
            }

            for (int i = 0; i < dtParams.Columns.Count; i++)
            {
                List<PPParamValue> values = ppParams[i].ResolveDataXML();
                for (int j = 0; j < values.Count; j++)
                {
                    DataRow dr = null;
                    if (dtParams.Rows.Count < j + 1)
                    {
                        dr = dtParams.NewRow();
                        dtParams.Rows.Add(dr);
                    }
                    else
                    {
                        dr = dtParams.Rows[j];
                    }

                    dr[i] = values[j].Metric01;
                }
            }

            vgrdMethodParams.DataSource = dtParams;
            vgrdMethodParams.BestFit();
        }

        private void ucPrdtParams_Furnace_Load(object sender, EventArgs e)
        {
            // 获取当前设备正在生产的炉次信息列表
            List<BatchProductInfo> datas = GetWorkUnitProductionInfo();
            // 数据库函数对象集转换成程序对象集
            foreach (BatchProductInfo data in datas)
            {
                if (data.BatchNumber.Trim() != "")
                {
                    batchNos.Add(FurnaceInfo.Mapper(data));
                }
            }

            // 添加到 ImageListBox 控件中
            foreach (FurnaceInfo batch in batchNos)
            {
                ilstBatchNos.Items.Add(batch, -1);
            }
            ilstBatchNos.Items.Add(new FurnaceInfo(), -1);
        }

        private void ucPrdtParams_Furnace_Enter(object sender, EventArgs e)
        {
            if (currentFurnace != null)
            {
                if (currentFurnace.InProduction != 1)
                {
                    edtOperatorCode.Focus();
                }
            }
        }

        private void ucPrdtParams_Furnace_Paint(object sender, PaintEventArgs e)
        {
            if (currentFurnace == null)
            {
                edtOperatorCode.Enabled = false;

                btnSelectMaterialPreparation.Enabled = false;

                btnParamNew.Enabled = false;
                btnParamRemove.Enabled = false;

                btnBegin.Enabled = false;
                btnTerminate.Enabled = false;
                btnEnd.Enabled = false;
            }
            else
            {
                switch (currentFurnace.PrdtStatus)
                {
                    case ProductionStatus.Idle:
                        edtOperatorCode.Enabled = true;

                        btnSelectMaterialPreparation.Enabled = true;

                        btnParamNew.Enabled = false;
                        btnParamRemove.Enabled = false;

                        btnBegin.Enabled = true;
                        btnTerminate.Enabled = false;
                        btnEnd.Enabled = false;

                        break;
                    case ProductionStatus.Busy:

                        edtOperatorCode.Enabled = false;

                        btnSelectMaterialPreparation.Enabled = false;

                        if (dtParams.Columns.Count > 0)
                        {
                            btnParamNew.Enabled = true;
                            btnParamRemove.Enabled = true;
                        }
                        else
                        {
                            btnParamNew.Enabled = false;
                            btnParamRemove.Enabled = false;
                        }

                        btnBegin.Enabled = false;
                        btnTerminate.Enabled = true;
                        btnEnd.Enabled = true;

                        break;
                }
            }
        }

        private void edtOperatorCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (currentFurnace != null && currentFurnace.InProduction != 1)
                {
                    if (edtOperatorCode.Text.Trim() != "")
                    {
                        STB006 currentOperator =
                            GetUserInfoWithIDCode(edtOperatorCode.Text.Trim());
                        if (currentOperator != null)
                        {
                            edtOperatorCode.Text =
                                string.Format(
                                    "{0}[{1}]",
                                    currentOperator.UserName,
                                    currentOperator.UserCode);
                            currentFurnace.OperatorCode = currentOperator.UserCode;
                            currentFurnace.OperatorName = currentOperator.UserName;
                        }
                        else
                        {
                            edtOperatorCode.Text = "";
                            currentFurnace.OperatorCode = "";
                            currentFurnace.OperatorName = "";
                        }
                    }
                    else
                    {
                        edtOperatorCode.Text = "";
                        currentFurnace.OperatorCode = "";
                        currentFurnace.OperatorName = "";
                    }
                }
                else
                {
                    edtOperatorCode.Text = "";
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            if (currentFurnace != null)
            {
                if (currentFurnace.PrdtStatus == ProductionStatus.Busy)
                {
                    TimeSpan span = now - currentFurnace.BatchStartDate;
                    lblProductTimeSpan.Text = "";
                    if (span.Days != 0)
                        lblProductTimeSpan.Text = string.Format("{0}天", span.Days);
                    if (span.Hours != 0)
                        lblProductTimeSpan.Text += string.Format("{0}小时", span.Hours);
                    if (span.Minutes != 0)
                        lblProductTimeSpan.Text += string.Format("{0}分钟", span.Minutes);
                    if (span.Seconds != 0)
                        lblProductTimeSpan.Text += string.Format("{0}秒", span.Seconds);

                    lblProductTimeSpan.Text =
                        string.Format(
                            "从 {0} 开始，已过 {1}",
                            currentFurnace.BatchStartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                            lblProductTimeSpan.Text);
                }
            }
        }

        private void btnMaterialPreparation_Click(object sender, EventArgs e)
        {
            using (frmMaterialPreparation frmMP = 
                new frmMaterialPreparation(stationInfo))
            {
                frmMP.ShowDialog();
            }
        }

        private void btnSelectMaterialPreparation_Click(object sender, EventArgs e)
        {
            TMaterialPreparationInfos mps =
                LoadFromFile<TMaterialPreparationInfos>(tempMaterialPreparationFile);
            TMaterialPreparationInfo mp = null;

            using (frmSelectMaterialPreparation formSelect =
                new frmSelectMaterialPreparation(mps))
            {
                if (formSelect.ShowDialog() == DialogResult.OK)
                {
                    mp = formSelect.MP;
                }
            }

            if (mp != null)
            {
                grdvPWOs.BeginDataUpdate();
                if (currentFurnace != null)
                {
                    currentFurnace.MPDescription = mp.Title;
                    currentFurnace.PWOs.Clear();

                    foreach (EntityBatchPWO pwo in mp.PWOs)
                    {
                        currentFurnace.PWOs.Add(pwo.Clone());
                    }
                }
                grdvPWOs.EndDataUpdate();

                grdvPWOs.BestFitColumns();
            }
            else
            {
                XtraMessageBox.Show("没有选择备料信息，或者无备料信息");
            }
        }

        private void ilstBatchNos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ilstBatchNos.SelectedItem != null)
            {
                currentFurnace = (ilstBatchNos.SelectedItem as ImageListBoxItem).Value as FurnaceInfo;
                InitFurnaceInfo(currentFurnace);
            }
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";

            if (currentFurnace == null)
            {
                XtraMessageBox.Show(
                    "程序问题，请联系开发人员予以解决！",
                    strProcedureName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            #region 数据检验
            if (currentFurnace.OperatorCode.Trim() == "")
            {
                XtraMessageBox.Show(
                    "请刷卡记录您的身份！",
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                edtOperatorCode.Focus();
                return;
            }
            if (currentFurnace.PWOs.Count <= 0)
            {
                if (XtraMessageBox.Show(
                    "没有添加工单信息！\n    如果该炉次是试样，请忽略提示信息，" +
                    "点击“Yes”按钮，否则请点击“No”按钮",
                    "提问",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    XtraMessageBox.Show(
                        "还没有添加工单信息，请至少增加一个生产工单！",
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    btnPWONew.Focus();
                    return;
                }
            }
            #endregion

            #region 记录生产开始
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                string batchNumber = "";

                IRAPMESClient.Instance.usp_SaveFact_BatchProductionStart(
                    IRAPUser.Instance.CommunityID,
                    stationInfo.T216LeafID,
                    stationInfo.T107LeafID,
                    currentFurnace.OperatorCode,
                    0,
                    GenerateBatchProductionStartXML(currentFurnace.PWOs),
                    IRAPUser.Instance.SysLogID,
                    out batchNumber,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        string.Format("在生产开始时发生错误：[{0}]", errText),
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    currentFurnace.BatchNumber = batchNumber;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            #endregion

            #region 生产开始成功后
            currentFurnace.BatchStartDate = DateTime.Now;
            currentFurnace.PrdtStatus = ProductionStatus.Busy;

            batchNos.Add(currentFurnace);
            ImageListBoxItem item = ilstBatchNos.SelectedItem as ImageListBoxItem;
            item.Description = currentFurnace.BatchNumber;

            InitFurnaceInfo(currentFurnace);

            ilstBatchNos.Items.Add(new FurnaceInfo(), -1);

            // 从备料列表中删除已经开始生产的备料
            if (currentFurnace.MPDescription != "")
            {
                TMaterialPreparationInfos mps =
                    LoadFromFile<TMaterialPreparationInfos>(tempMaterialPreparationFile);
                for (int i = 0; i < mps.Count; i++)
                {
                    if (mps.Items[i].Title == currentFurnace.MPDescription)
                    {
                        mps.Items.RemoveAt(i);
                        break;
                    }
                }
                SaveToFile(tempMaterialPreparationFile, mps.ToJSON());
            }
            #endregion
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            if (currentFurnace != null)
            {
                if (
                    IRAPMessageBox.Instance.Show(
                        $"是否要终止当前炉次【{currentFurnace.BatchNumber}】的生产？",
                        "生产终止",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    int errCode = 0;
                    string errText = "";

                    IRAPMESClient.Instance.usp_SaveFact_BatchBreakProduction(
                        IRAPUser.Instance.CommunityID,
                        stationInfo.T216LeafID,
                        stationInfo.T107LeafID,
                        currentFurnace.BatchNumber,
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode != 0)
                    {
                        XtraMessageBox.Show(
                            $"在生产终止时发生错误：[{errText}]",
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        ilstBatchNos.Items.RemoveAt(ilstBatchNos.SelectedIndex);
                        batchNos.Remove(currentFurnace);

                        ilstBatchNos.SelectedIndex = 0;
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (currentFurnace != null)
            {
                string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    int errCode = 0;
                    string errText = "";

                    IRAPMESClient.Instance.usp_SaveFact_BatchProductionEnd(
                        IRAPUser.Instance.CommunityID,
                        stationInfo.T216LeafID,
                        stationInfo.T107LeafID,
                        currentFurnace.BatchNumber,
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode != 0)
                    {
                        XtraMessageBox.Show(
                            $"在生产结束时发生错误：[{errText}]",
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        ilstBatchNos.Items.RemoveAt(ilstBatchNos.SelectedIndex);
                        batchNos.Remove(currentFurnace);

                        ilstBatchNos.SelectedIndex = 0;
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }
    }

    internal class FurnaceInfo
    {
        private string batchNumber = "";
        private List<EntityBatchPWO> pwos = new List<EntityBatchPWO>();

        /// <summary>
        /// 炉次号
        /// </summary>
        public string BatchNumber
        {
            get
            {
                if (InProduction == 1)
                {
                    return batchNumber;
                }
                else
                {
                    return "<新炉次>";
                }
            }

            set { batchNumber = value; }
        }
        /// <summary>
        /// 操作工工号
        /// </summary>
        public string OperatorCode { get; set; }
        /// <summary>
        /// 操作工姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 生产开始时间
        /// </summary>
        public DateTime BatchStartDate { get; set; }
        /// <summary>
        /// 是否正在生产
        /// </summary>
        public int InProduction { get; set; }
        public ProductionStatus PrdtStatus
        {
            get
            {
                if (InProduction == 1)
                {
                    return ProductionStatus.Busy;
                }
                else {
                    return ProductionStatus.Idle;
                }
            }
            set
            {
                if (value == ProductionStatus.Busy)
                {
                    InProduction = 1;
                }
                else
                {
                    InProduction = 0;
                }
            }
        }
        /// <summary>
        /// 正在生产的工单列表
        /// </summary>
        public List<EntityBatchPWO> PWOs
        {
            get { return pwos; }
            set { pwos = value; }
        }
        /// <summary>
        /// 选取的备料列表简介
        /// </summary>
        public string MPDescription { get; set; }

        public FurnaceInfo()
        {
            OperatorCode = "";
            OperatorName = "";
            BatchStartDate = DateTime.Now;
        }

        public override string ToString()
        {
            return BatchNumber;
        }

        public static FurnaceInfo Mapper(BatchProductInfo s)
        {
            FurnaceInfo d = Activator.CreateInstance<FurnaceInfo>();
            try
            {
                var Types = s.GetType();//获得类型  
                var Typed = typeof(FurnaceInfo);
                foreach (PropertyInfo sp in Types.GetProperties())//获得类型的属性字段  
                {
                    foreach (PropertyInfo dp in Typed.GetProperties())
                    {
                        if (dp.Name == sp.Name)//判断属性名是否相同  
                        {
                            dp.SetValue(d, sp.GetValue(s, null), null);//获得s对象属性的值复制给d对象的属性  
                        }
                    }
                }

                d.PWOs = s.GetPWOsFromXML();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return d;
        }
    }
}
