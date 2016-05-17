using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Entity.MDM;
using IRAP.Entity.MDM.Tables;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_MDVO.Controls
{
    public partial class ucInspectStandard : ucCustomDocumentKanban
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public ucInspectStandard()
        {
            InitializeComponent();
        }

        #region 自定义函数
        private List<QualityStandard> GetInspectStandards()
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
                List<InspectionStandard> datas = new List<InspectionStandard>();
                List<QualityStandard> rlt = new List<QualityStandard>();

                IRAPMDMClient.Instance.ufn_GetList_InspectionStandard(
                    communityID,
                    t102LeafID,
                    t216LeafID,
                    "",
                    sysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    datas = (from standard in datas
                             where !standard.Reference
                             select standard).ToList<InspectionStandard>();

                    foreach (InspectionStandard standard in datas)
                    {
                        rlt.Add(new QualityStandard()
                        {
                            Ordinal = standard.Ordinal,
                            T20LeafID = standard.T20LeafID,
                            ParameterName = standard.ParameterName,
                            LowLimit = standard.LowLimit,
                            Criterion = standard.Criterion,
                            HighLimit = standard.HighLimit,
                            Scale = standard.Scale,
                            UnitOfMeasure = standard.UnitOfMeasure,
                            QtyForFirstInspection = standard.QtyForFirstInspection,
                            QtyforInProcessInspection = standard.QtyForInProcessInspection,
                            InProcessInspectionBatchSize = standard.InProcessInspectionBatchSize,
                            QtyForLastInspection = standard.QtyForLastInspection,
                            FullInspection = standard.FullInspection,
                            Reference = standard.Reference,
                        });
                    }

                    return rlt;
                }
                else
                {
                    throw new Exception(
                        string.Format("({0}){1}", errCode, errText));
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(
                    string.Format("{0}\n{1}", error.Message, error.StackTrace),
                    strProcedureName);
                throw error;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private Image GetProductImage()
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
                GenAttr_Product data = new GenAttr_Product();

                IRAPMDMClient.Instance.ufn_GetProductSketch(
                    communityID,
                    t102LeafID,
                    sysLogID,
                    ref data,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText), 
                    strProcedureName);
                if (errCode == 0)
                {
                    return data.ProductImage;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(
                    string.Format("{0}\n{1}", error.Message, error.StackTrace), 
                    strProcedureName);
                return null;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private Image GetProcessOperationImage()
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
                GenAttr_ProcessOperation data = new GenAttr_ProcessOperation();

                IRAPMDMClient.Instance.ufn_GetProcessOperationGenAttr(
                    communityID,
                    t216LeafID,
                    sysLogID,
                    ref data,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode == 0)
                {
                    return Tools.BytesToImage(data.OperationSketch);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(string.Format("{0}\n{1}", error.Message, error.StackTrace), strProcedureName);
                return null;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {
            if (communityID > 0 && t102LeafID > 0 && t216LeafID > 0 && sysLogID > 0)
            {
                timer.Enabled = false;

                try
                {
                    List<QualityStandard> datas = GetInspectStandards();
                    grdInspectStandards.DataSource = datas;
                    grdvInspectStandards.BestFitColumns();

                    picProductImage.Image = GetProcessOperationImage();
                }
                catch (Exception error)
                {
                    XtraMessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ucInspectStandard_Resize(object sender, EventArgs e)
        {
            grdInspectStandards.Width = Width / 2;
        }
    }
}
