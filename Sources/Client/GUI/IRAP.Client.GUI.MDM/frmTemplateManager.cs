using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using FastReport;
using FastReport.Data;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global.GUI.Dialogs;
using IRAP.Entity.Kanban;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MDM
{
    public partial class frmTemplateManager : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private AvailableSite currentTemplate = new AvailableSite();
        private List<LeafSetEx> datas = new List<LeafSetEx>();
        private string tempTemplateFile =
            string.Format(
                @"{0}Temp\temp.frx",
                AppDomain.CurrentDomain.BaseDirectory);

        public frmTemplateManager(AvailableSite site)
        {
            InitializeComponent();

            currentTemplate = site;

            string directory = Path.GetDirectoryName(tempTemplateFile);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        private void CreateFRParameter(
            Report report,
            string paramName,
            string paramValue,
            string paramDesc)
        {
            if (report.Parameters.FindByName(paramName) == null)
                report.Parameters.Add(
                    new Parameter(paramName)
                    {
                        Value = paramValue,
                        Description = paramDesc,
                    });
            else
                report.Parameters.FindByName(paramName).Value = paramValue;
        }

        private void CreateFRParameter(
            Report report,
            string paramName,
            double paramValue,
            string paramDesc)
        {
            if (report.Parameters.FindByName(paramName) == null)
                report.Parameters.Add(
                    new Parameter(paramName)
                    {
                        Value = paramValue,
                        Description = paramDesc,
                    });
            else
                report.Parameters.FindByName(paramName).Value = paramValue;
        }

        private void SetReportParameters(Report report)
        {
            CreateFRParameter(report, "SendAddress", "上海浦东外高桥保税区华京路328号", "供货方地址");
            CreateFRParameter(report, "CustomerCode", "123ABC456F", "客户代码");
            CreateFRParameter(report, "CustomerName", "深圳市比亚迪供应链管理有限公司", "收货方名称");
            CreateFRParameter(report, "ReceiveAddress", "NO.2 YADI RD, HIGH TXC. & ABCD", "收货方地址");
            CreateFRParameter(report, "CustomerPartNumber", "3500310U2263", "客户零件号");
            CreateFRParameter(report, "SupplierPartNumber", "18122405", "供应商零件号");
            CreateFRParameter(report, "PartName", "前制动钳总成(左)", "零件名称");
            CreateFRParameter(report, "Quantity", 150, "数量");
            CreateFRParameter(report, "ContainerNo", "6OYK00427", "托盘号");
            CreateFRParameter(report, "ProductDate", "2016年10月20日", "生产日期");
            CreateFRParameter(report, "CustomerSN", "16B00002L211393500310U2263", "客户条码");
            CreateFRParameter(report, "SupplierCode", "ABCD1234", "供应商代码");
        }

        private string LoadTemplateFromDB(int t117LeafID)
        {
            string rlt = "";

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
                TemplateContent data = new TemplateContent();

                IRAPMDMClient.Instance.ufn_GetInfo_TemplateFMTStr(
                    IRAPUser.Instance.CommunityID,
                    t117LeafID,
                    IRAPUser.Instance.SysLogID,
                    ref data,
                    out errCode,
                    out errText);
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                if (errCode == 0)
                {
                    rlt = data.TemplateFMTStr;
                }
                else
                {
                    IRAPMessageBox.Instance.Show(errText, "获取标签模板", MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                IRAPMessageBox.Instance.Show(error.Message, "获取标签模板", MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

            return rlt;
        }

        private void GetTemplateList()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                lstTemplates.Items.Clear();

                int errCode = 0;
                string errText = "";

                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    117,
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    foreach (LeafSetEx data in datas)
                        if (data.Code.ToUpper() == "FRX")
                            lstTemplates.Items.Add(data);

                    if (currentTemplate.T117LeafID != 0)
                    {
                        for (int i = 0; i < lstTemplates.Items.Count; i++)
                        {
                            if ((lstTemplates.Items[i] as LeafSetEx).LeafID == currentTemplate.T117LeafID)
                            {
                                lstTemplates.SelectedItem = lstTemplates.Items[i];
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmTemplateManager_Shown(object sender, EventArgs e)
        {
            lblCurrentTemplateName.Text = currentTemplate.T117Name;

            GetTemplateList();
        }

        private void lstTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTemplates.SelectedItem == null)
            {
                report.Preview = null;
                previewControl.Clear();
                return;
            }

            LeafSetEx item = lstTemplates.SelectedItem as LeafSetEx;
            if (item.LeafID != 0)
            {
                string template = LoadTemplateFromDB(item.LeafID);
                report.Clear();
                report.LoadFromString(template);
                SetReportParameters(report);
                report.Preview = previewControl;

                if (report.Prepare())
                {
                    report.ShowPrepared();
                    previewControl.ZoomWholePage();
                }
            }
        }

        private void lblCurrentTemplateName_Click(object sender, EventArgs e)
        {
            if (currentTemplate.T117LeafID != 0)
            {
                string template = LoadTemplateFromDB(currentTemplate.T117LeafID);
                report.Clear();
                report.LoadFromString(template);
                SetReportParameters(report);
                report.Preview = previewControl;

                if (report.Prepare())
                {
                    report.ShowPrepared();
                    previewControl.ZoomWholePage();
                }
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (lstTemplates.SelectedItem == null)
                e.Cancel = true;
        }

        private void tsmiReplace_Click(object sender, EventArgs e)
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

                IRAPMDMClient.Instance.usp_SaveFact_C75(
                    IRAPUser.Instance.CommunityID,
                    currentTemplate.CorrelationID,
                    (lstTemplates.SelectedItem as LeafSetEx).LeafID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    Close();
                }
                else
                {
                    IRAPMessageBox.Instance.Show(
                        errText,
                        "系统信息",
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                IRAPMessageBox.Instance.Show(
                    error.Message,
                    "系统信息",
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);

            if (File.Exists(tempTemplateFile))
                File.Delete(tempTemplateFile);

            // 给新的标签模板取个名字
            LeafSetEx data = lstTemplates.SelectedItem as LeafSetEx;
            string newTemplateName =
                GetString.Instance.Show(
                    "给新的标签模板取个名",
                    "请给新的标签模板设置一个名称：",
                    data.LeafName);
            if (newTemplateName.Trim() == "")
                newTemplateName = "未取名的标签模板";

            // 将当前的标签模板作为样本，新增新模板
            report.Save(tempTemplateFile);
            report.FileName = tempTemplateFile;
            if (report.Design(true))
            {
                report.Load(tempTemplateFile);
                string templateContext = report.SaveToString();

                #region 保存修改后的模板内容
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    int errCode = 0;
                    string errText = "";
                    int newLeafID = 0;

                    IRAPMDMClient.Instance.usp_SaveFact_IRAP117Node(
                        IRAPUser.Instance.CommunityID,
                        117,
                        "A",
                        currentTemplate.T117LeafID,
                        "FRX",
                        "",
                        newTemplateName,
                        templateContext,
                        IRAPUser.Instance.SysLogID,
                        ref newLeafID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode != 0)
                    {
                        IRAPMessageBox.Instance.Show(
                            errText,
                            "新增模板失败",
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        GetTemplateList();
                        for (int i = 0; i < lstTemplates.Items.Count; i++)
                        {
                            LeafSetEx temp = lstTemplates.Items[i] as LeafSetEx;
                            if (temp.LeafID == newLeafID)
                            {
                                lstTemplates.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    IRAPMessageBox.Instance.Show(
                        error.Message,
                        "系统信息",
                        MessageBoxIcon.Error);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
                #endregion

                lstTemplates_SelectedIndexChanged(null, null);
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (File.Exists(tempTemplateFile))
            {
                File.Delete(tempTemplateFile);
            }

            // 将未修改前的模板保存到临时文件中
            report.Save(tempTemplateFile);
            // 保存未修改前的模板内容，作为是否保存的依据
            string oldTemplate = report.SaveToString();

            report.FileName = tempTemplateFile;
            if (report.Design(true))
            {
                report.Load(tempTemplateFile);
                string newTemplate = report.SaveToString();

                #region 保存修改后的模板内容
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    int errCode = 0;
                    string errText = "";
                    int newLeafID = 0;
                    LeafSetEx data = lstTemplates.SelectedItem as LeafSetEx;

                    IRAPMDMClient.Instance.usp_SaveFact_IRAP117Node(
                        IRAPUser.Instance.CommunityID,
                        117,
                        "U",
                        data.LeafID,
                        "FRX",
                        "",
                        data.LeafName,
                        newTemplate,
                        IRAPUser.Instance.SysLogID,
                        ref newLeafID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode != 0)
                    {
                        IRAPMessageBox.Instance.Show(
                            errText,
                            "保存模板失败",
                            MessageBoxIcon.Error);
                        report.LoadFromString(oldTemplate);
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    IRAPMessageBox.Instance.Show(
                        error.Message,
                        "系统信息",
                        MessageBoxIcon.Error);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
                #endregion

                lstTemplates_SelectedIndexChanged(null, null);
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (IRAPMessageBox.Instance.Show(
                "是否要删除当前选择的标签模板？",
                "系统信息",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    int errCode = 0;
                    string errText = "";
                    int newLeafID = 0;

                    IRAPMDMClient.Instance.usp_SaveFact_IRAP117Node(
                        IRAPUser.Instance.CommunityID,
                        117,
                        "D",
                        (lstTemplates.SelectedItem as LeafSetEx).LeafID,
                        "",
                        "",
                        "",
                        "",
                        IRAPUser.Instance.SysLogID,
                        ref newLeafID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode != 0)
                    {
                        IRAPMessageBox.Instance.Show(errText, "系统信息", MessageBoxIcon.Error);
                    }
                    else
                    {
                        GetTemplateList();
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    IRAPMessageBox.Instance.Show(
                        error.Message,
                        "系统信息",
                        MessageBoxIcon.Error);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }

                

            }
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            if (lstTemplates.SelectedItem == null)
            {
                return;
            }

            LeafSetEx data = lstTemplates.SelectedItem as LeafSetEx;

            // 给标签模板取个名字
            string newTemplateName =
                GetString.Instance.Show(
                    "重命名",
                    string.Format(
                        "您想将标签模板[{0}]更换成：",
                        data.LeafName),
                    data.LeafName);
            if (newTemplateName.Trim() != "")
            {
                string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);

                #region 保存修改后的模板内容
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    int errCode = 0;
                    string errText = "";
                    int newLeafID = 0;

                    IRAPMDMClient.Instance.usp_SaveFact_IRAP117Node(
                        IRAPUser.Instance.CommunityID,
                        117,
                        "U",
                        data.LeafID,
                        "FRX",
                        "",
                        newTemplateName,
                        report.SaveToString(),
                        IRAPUser.Instance.SysLogID,
                        ref newLeafID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode != 0)
                    {
                        IRAPMessageBox.Instance.Show(
                            errText,
                            "重命名失败",
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        data.LeafName = newTemplateName;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    IRAPMessageBox.Instance.Show(
                        error.Message,
                        "系统信息",
                        MessageBoxIcon.Error);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
                #endregion
            }
        }
    }
}
