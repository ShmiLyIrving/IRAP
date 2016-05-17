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
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_MDVO.Controls
{
    public partial class ucMethodStandard : ucCustomDocumentKanban
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public ucMethodStandard()
        {
            InitializeComponent();
        }

        #region 自定义函数
        private List<MethodStandard> GetMethodStandards()
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<MethodStandard> rlt = new List<MethodStandard>();

                IRAPMDMClient.Instance.ufn_GetList_MethodStandard(
                    communityID,
                    t102LeafID,
                    t216LeafID,
                    "",
                    sysLogID,
                    ref rlt,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode == 0)
                {
                    rlt = (from standard in rlt
                           where !standard.Reference
                           select standard).ToList<MethodStandard>();
                    return rlt;
                }
                else
                {
                    throw new Exception(string.Format("({0}){1}", errCode, errText));
                }

            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(string.Format("{0}\n{1}", error.Message, error.StackTrace), strProcedureName);
                throw error;
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
                    List<MethodStandard> datas = GetMethodStandards();
                    grdMethodStandards.DataSource = datas;
                    grdvMethodStandards.BestFitColumns();
                }
                catch (Exception error)
                {
                    XtraMessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
