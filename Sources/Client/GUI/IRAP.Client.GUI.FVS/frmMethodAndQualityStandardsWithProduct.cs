using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.FVS;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.FVS
{
    public partial class frmMethodAndQualityStandardsWithProduct : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private PWOSurveillance pwo = null;
        private List<MethodStandard> methodStandards = new List<MethodStandard>();
        private List<QualityStandard> qualityStandards = new List<QualityStandard>();

        public frmMethodAndQualityStandardsWithProduct()
        {
            InitializeComponent();
        }

        public PWOSurveillance PWO
        {
            get { return pwo; }
            set
            {
                pwo = value;

                if (pwo != null)
                {
                    string strProcedureName =
                        string.Format(
                            "{0}.{1}",
                            className,
                            MethodBase.GetCurrentMethod().Name);

                    WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                    try
                    {
                        Text = string.Format("[{0}]的工艺参数和质量标准", pwo.ProductName);

                        int errCode = 0;
                        string errText = "";

                        try
                        {
                            IRAPMDMClient.Instance.ufn_GetList_MethodStandard(
                                IRAPUser.Instance.CommunityID,
                                pwo.T102LeafID,
                                pwo.T216LeafID,
                                "",
                                IRAPUser.Instance.SysLogID,
                                ref methodStandards,
                                out errCode,
                                out errText);
                            WriteLog.Instance.Write(
                                string.Format("({0}){1}", errCode, errText), 
                                strProcedureName);
                            if (errCode == 0)
                            {
                                grdMethodStandards.DataSource = methodStandards;
                                for (int i = 0; i < grdvMethodStandards.Columns.Count; i++)
                                {
                                    grdvMethodStandards.Columns[i].BestFit();
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show(
                                    errText, 
                                    "系统信息", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
                            }

                            IRAPMDMClient.Instance.ufn_GetList_QualityStandard(
                                IRAPUser.Instance.CommunityID,
                                pwo.T102LeafID,
                                pwo.T216LeafID,
                                "",
                                IRAPUser.Instance.SysLogID,
                                ref qualityStandards,
                                out errCode,
                                out errText);
                            WriteLog.Instance.Write(
                                string.Format("({0}){1}", errCode, errText), 
                                strProcedureName);
                            if (errCode == 0)
                            {
                                grdQualityStandards.DataSource = qualityStandards;
                                for (int i = 0; i < grdvQualityStandards.Columns.Count; i++)
                                {
                                    grdvQualityStandards.Columns[i].BestFit();
                                }
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
                            WriteLog.Instance.Write(error.Message, strProcedureName);
                            XtraMessageBox.Show(
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
            }
        }
    }
}
