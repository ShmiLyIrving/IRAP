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
    public partial class ucToolingStandard : ucCustomDocumentKanban
    {
        private string className = 
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private DataTable dtLifeControlMode = null;

        public ucToolingStandard()
        {
            InitializeComponent();

            DataTable dtLifeControlMode = new DataTable();
            dtLifeControlMode.Columns.Add("ID", typeof(int));
            dtLifeControlMode.Columns.Add("Name", typeof(string));
            dtLifeControlMode.Rows.Add(new object[] { 0, "不控制" });
            dtLifeControlMode.Rows.Add(new object[] { 1, "按时间" });
            dtLifeControlMode.Rows.Add(new object[] { 2, "按产量" });
            riluLifeControlMode.DataSource = dtLifeControlMode;
            riluLifeControlMode.DisplayMember = "Name";
            riluLifeControlMode.ValueMember = "ID";
            riluLifeControlMode.NullText = "";
        }

        #region 自定义函数
        private List<ToolingStandard> GetToolingStandards()
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
                List<ToolingStandard> rlt = new List<ToolingStandard>();

                IRAPMDMClient.Instance.ufn_GetList_ToolingStandard(
                    communityID,
                    t102LeafID,
                    t216LeafID,
                    "",
                    sysLogID,
                    ref rlt,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText), 
                    strProcedureName);
                if (errCode == 0)
                {
                    rlt = (from standard in rlt
                           where !standard.Reference
                           select standard).ToList<ToolingStandard>();
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
                    string.Format(
                        "{0}\n{1}", 
                        error.Message, 
                        error.StackTrace), 
                    strProcedureName);
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
            if (communityID > 0 && t102LeafID > 0 && t216LeafID > 0)
            {
                timer.Enabled = false;

                try
                {
                    List<ToolingStandard> datas = GetToolingStandards();
                    grdToolingStandards.DataSource = datas;
                    grdvToolingStandards.BestFitColumns();
                }
                catch (Exception error)
                {
                    XtraMessageBox.Show(
                        error.Message, 
                        "系统信息", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show(
                    string.Format(
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}", 
                        communityID, 
                        t102LeafID, 
                        t216LeafID));
            }
        }
    }
}
