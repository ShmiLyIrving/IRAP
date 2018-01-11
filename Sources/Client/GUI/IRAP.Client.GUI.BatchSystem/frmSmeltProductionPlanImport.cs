using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.DPA;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.BatchSystem
{
    public partial class frmSmeltProductionPlanImport : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private const string DB_IMPORT_TABLENAME = "dpa_Imp_SmeltProductionPlan";

        private long importLogID = 0;

        public frmSmeltProductionPlanImport()
        {
            InitializeComponent();
        }

        private Exception BuildErrorObject(int errCode, string errText)
        {
            Exception error = new Exception(errText);
            error.Data["ErrCode"] = errCode;
            error.Data["ErrText"] = errText;
            return error;
        }

        /// <summary>
        /// 从 Excel 文件中获取 Sheet 名集合，从中选择一个 Sheet 名返回
        /// </summary>
        /// <param name="fileName">Excel 文件名</param>
        /// <returns></returns>
        private string GetExcelFirstSheetName(string fileName)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            using (ExcelHelper excel = new ExcelHelper(fileName))
            {
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    List<string> sheetNames = excel.GetExcelSheetNames();

                    using (Dialogs.frmSelectExcelSheet selectSheet =
                        new Dialogs.frmSelectExcelSheet(sheetNames))
                    {
                        if (selectSheet.ShowDialog() == DialogResult.OK)
                            return selectSheet.SelectSheetName;
                        else
                            return "";
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    throw BuildErrorObject(-1, error.Message);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        /// <summary>
        /// 从数据库表 dpa_Imp_SmeltProductionPlan 中移除指定 LogID 的记录
        /// </summary>
        /// <param name="importLogID"></param>
        private void RemoveDataFromDBTable(long importLogID)
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
                IRAPTreeClient.Instance.DeleteOldTableData(
                    DB_IMPORT_TABLENAME,
                    importLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    Exception error = new Exception(errText);
                    throw BuildErrorObject(errCode, errText);
                }
                return;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                throw BuildErrorObject(-1, error.Message);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 从 Excel 文件中读取指定工作表的数据，转换成 DataTable
        /// </summary>
        /// <param name="fileName">Excel文件名</param>
        /// <returns></returns>
        private DataTable ExcelSheet2DataTable(string fileName)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);

            if (!File.Exists(fileName))
            {
                string errText =
                    string.Format(
                        "没有找到文件 [{0}]。", fileName);
                WriteLog.Instance.Write(errText, strProcedureName);
                throw BuildErrorObject(-1, errText);
            }

            try
            {
                int errCode = 0;
                string errText = "";

                #region 获取数据导入日志标识
                if (importLogID == 0)
                {
                    IRAPUTSClient.Instance.msp_GetSequenceNo(
                        IRAPUser.Instance.CommunityID,
                        "NextUDFLogID",
                        1,
                        IRAPUser.Instance.SysLogID,
                        ref importLogID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode != 0)
                        throw
                            BuildErrorObject(
                                errCode,
                                string.Format(
                                    "获取数据导入日志标识时发生错误：{0}",
                                    errText));
                }
                #endregion

                DataSet ds = new DataSet();
                string sheetName = GetExcelFirstSheetName(fileName);

                if (sheetName == "")
                    return null;

                using (ExcelHelper excel = new ExcelHelper(fileName))
                {
                    return excel.ExcelToDataTable(sheetName, true);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                throw BuildErrorObject(-1, error.Message);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 检查需要导入的数据是否全部通过检验
        /// </summary>
        private bool CanBeImported()
        {
            List<dpa_Imp_SmeltProductionPlan> items =
                grdImportData.DataSource as List<dpa_Imp_SmeltProductionPlan>;
            foreach (dpa_Imp_SmeltProductionPlan item in items)
            {
                if (item.ErrCode != 0)
                    return false;
            }
            return true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                DataTable dt = ExcelSheet2DataTable(openFileDialog.FileName);

                List<dpa_Imp_SmeltProductionPlan> datas = new List<dpa_Imp_SmeltProductionPlan>();
                int i = 1;
                long partitioningKey = IRAPUser.Instance.CommunityID * 10000;
                foreach (DataRow dr in dt.Rows)
                {
                    datas.Add(
                        new dpa_Imp_SmeltProductionPlan()
                        {
                            PartitioningKey = partitioningKey,
                            ImportLogID = importLogID,
                            UnixTime = 0,
                            Ordinal = i++,
                            ErrCode = -1,
                            ErrText = "未校验",
                            ColName01 = dr[0].ToString(),
                            ColName02 = dr[1].ToString(),
                            ColName03 = dr[2].ToString(),
                            ColName04 = dr[3].ToString(),
                            ColName05 = dr[4].ToString(),
                            ColName06 = dr[5].ToString(),
                            ColName07 = dr[6].ToString(),
                            ColName08 = dr[7].ToString(),
                            ColName09 = dr[8].ToString(),
                            ColName10 = dr[9].ToString(),
                            ColName11 = dr[10].ToString(),
                        });
                }

                grdImportData.DataSource = datas;
                grdvImportData.BestFitColumns();
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            RemoveDataFromDBTable(importLogID);

            #region 将当前表格中的记录插入数据库中
            int errCode = 0;
            string errText = "";
            try
            {
                IRAPDPAClient.Instance.msp_InsertIntoSmeltProductionPlanTable(
                    grdImportData.DataSource as List<dpa_Imp_SmeltProductionPlan>,
                    out errCode,
                    out errText);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                          errText,
                          "提示信息",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region 检验指定 ImportLogID 的导入数据记录
            try
            {
                IRAPDPAClient.Instance.usp_PokaYoke_SmeltPWORelease(
                    IRAPUser.Instance.CommunityID,
                    importLogID,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                List<dpa_Imp_SmeltProductionPlan> datas = new List<dpa_Imp_SmeltProductionPlan>();
                IRAPDPAClient.Instance.mfn_GetList_SmeltProductionPlan(
                    IRAPUser.Instance.CommunityID,
                    importLogID,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);

                grdvImportData.BeginDataUpdate();
                grdImportData.DataSource = datas;
                grdvImportData.EndDataUpdate();
                grdvImportData.BestFitColumns();
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            #endregion
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (CanBeImported())
            {
                XtraMessageBox.Show(
                    "还有记录没有进行校验或者校验不通过，请修改后重新校验！",
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }
    }
}
