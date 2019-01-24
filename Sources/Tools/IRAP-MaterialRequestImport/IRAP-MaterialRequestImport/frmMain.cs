using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using DevExpress.XtraEditors;
using DevExpress.XtraBars;

using IRAP.Global;

namespace IRAP_MaterialRequestImport
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private const string DB_IMPORT_TABLENAME = "dpa_Log_MaterialReq";

        public frmMain()
        {
            InitializeComponent();

            defaultLookAndFeel.LookAndFeel.SetSkinStyle("Xmas 2008 Blue");
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
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            using (TExcelHelper excel = new TExcelHelper(fileName))
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
        /// 从数据库表 dpa_Log_MaterialReq 中移除指定 LogID 的记录
        /// </summary>
        /// <param name="importLogID"></param>
        private void RemoveDataFromDBTable(long importLogID)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                TDBHelper.Instance.DeleteOldTableData(
                    DB_IMPORT_TABLENAME,
                    TIRAPUser.Instance.CommunityID,
                    importLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
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
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

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
                DataSet ds = new DataSet();
                string sheetName = GetExcelFirstSheetName(fileName);

                if (sheetName == "")
                    return null;

                using (TExcelHelper excel = new TExcelHelper(fileName))
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
        /// 检查需要导入的数据是否全部通过校验
        /// </summary>
        /// <returns></returns>
        private bool CanBeImported()
        {
            List<Tdpa_Log_MaterialReq> items =
                grdData.DataSource as List<Tdpa_Log_MaterialReq>;
            if (items == null)
            {
                return false;
            }
            else
            {
                foreach (Tdpa_Log_MaterialReq item in items)
                {
                    if (item.ErrCode != 0)
                        return false;
                }
                return true;
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            bsiUserInfo.Caption =
                $"{TIRAPUser.Instance.UserName}|" +
                $"{TIRAPUser.Instance.Agency.AgencyName}|" +
                $"{TIRAPUser.Instance.Role.RoleName}";
            bsiUserInfo.Hint =
                $"登录用户：({TIRAPUser.Instance.UserCode}){TIRAPUser.Instance.UserName}\n" +
                $"登录机构：({TIRAPUser.Instance.Agency.AgencyCode}){TIRAPUser.Instance.Agency.AgencyName}\n" +
                $"登录角色：({TIRAPUser.Instance.Role.RoleCode}){TIRAPUser.Instance.Role.RoleName}";

            bsiVersion.Caption =
                $"{Application.ProductVersion}";
            bsiVersion.Hint =
                $"产品版本：{Application.ProductVersion}";

            TIRAPUser.Instance.RecordRunAFunction(100);

            WindowState = FormWindowState.Maximized;
        }

        private void bbiReadFromExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = null;
                try
                {
                    TWaitting.Instance.ShowWaitForm("正在读取物料需求数据");
                    dt = ExcelSheet2DataTable(openFileDialog.FileName);
                }
                catch (Exception error)
                {
                    TWaitting.Instance.CloseWaitForm();
                    XtraMessageBox.Show(
                        $"在读取({openFileDialog.FileName})时发生错误，" +
                        $"可能是该文件被其它程序打开。错误信息：({error.Message})",
                        "出错啦",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                TWaitting.Instance.ShowWaitForm("正在整理数据");
                if (dt != null)
                {
                    List<Tdpa_Log_MaterialReq> datas =
                        new List<Tdpa_Log_MaterialReq>();
                    long partitioningKey = TIRAPUser.Instance.CommunityID * 10000;
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        datas.Add(
                            new Tdpa_Log_MaterialReq()
                            {
                                PartitioningKey = partitioningKey,
                                ImportID = TIRAPUser.Instance.SysLogID,
                                ImportDate = DateTime.Now,
                                Ordinal = i,
                                MaterialCode = dr[0].ToString(),
                                SrcLoc = dr[2].ToString(),
                                DstLoc = dr[3].ToString(),
                                RoutingCode = dr[4].ToString(),
                                Remark = dr[5].ToString(),
                                ErrCode = -1,
                                ErrText = "未检验",
                            });
                        try
                        {
                            datas[datas.Count - 1].ReqQty = Convert.ToInt64(dr[1].ToString());
                        }
                        catch { datas[datas.Count - 1].ReqQty = 0; }
                    }

                    grdData.DataSource = datas;
                    grdvDatas.BestFitColumns();
                }
                TWaitting.Instance.CloseWaitForm();
            }
        }

        private void bbiDataValidate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((grdData.DataSource as List<Tdpa_Log_MaterialReq>).Count <= 0)
            {
                XtraMessageBox.Show(
                    "没有读取到需要导入的物料需求数据",
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                TWaitting.Instance.ShowWaitForm("删除历史数据");
                RemoveDataFromDBTable(TIRAPUser.Instance.SysLogID);

                #region 将当前表格中的记录插入数据库中
                int errCode = 0;
                string errText = "";
                try
                {
                    TWaitting.Instance.ShowWaitForm("将读取到的数据上传到数据库中");
                    TDBHelper.Instance.msp_InsertIntoMaterialReq(
                        grdData.DataSource as List<Tdpa_Log_MaterialReq>,
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
                    TWaitting.Instance.ShowWaitForm("校验上传的数据");
                    TDBHelper.Instance.usp_PokaYoke_MaterialReq(
                        TIRAPUser.Instance.CommunityID,
                        TIRAPUser.Instance.SysLogID,
                        TIRAPUser.Instance.SysLogID,
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

                    TWaitting.Instance.ShowWaitForm("获取校验结果");
                    List<Tdpa_Log_MaterialReq> datas = 
                        TDBHelper.Instance.mfn_GetList_MaterialReq(
                            TIRAPUser.Instance.CommunityID,
                            TIRAPUser.Instance.SysLogID,
                            TIRAPUser.Instance.SysLogID,
                            out errCode,
                            out errText);
                    if (errCode != 0)
                    {
                        XtraMessageBox.Show(
                            errText,
                            "出错啦",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    grdvDatas.BeginDataUpdate();
                    grdData.DataSource = datas;
                    grdvDatas.EndDataUpdate();
                    grdvDatas.BestFitColumns();
                }
                catch (Exception error)
                {
                    TWaitting.Instance.CloseWaitForm();
                    XtraMessageBox.Show(
                        error.Message,
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                #endregion
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
            }
        }

        private void bbiDataUpload_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CanBeImported())
            {
                XtraMessageBox.Show(
                    "还有记录没有进行校验或者校验不通过，请修改后重新校验！",
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            int errCode = 0;
            string errText = "";

            try
            {
                TWaitting.Instance.ShowWaitForm("正在处理上传的数据");
                TDBHelper.Instance.usp_ImportMaterialReq(
                    TIRAPUser.Instance.CommunityID,
                    TIRAPUser.Instance.SysLogID,
                    TIRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                TWaitting.Instance.CloseWaitForm();

                if (errCode != 0)
                    XtraMessageBox.Show(
                        errText,
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                {
                    XtraMessageBox.Show(
                        errText,
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    grdvDatas.BeginDataUpdate();
                    grdData.DataSource = null;
                    grdvDatas.EndDataUpdate();
                    grdvDatas.BestFitColumns();
                }
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {

            }
        }
    }
}