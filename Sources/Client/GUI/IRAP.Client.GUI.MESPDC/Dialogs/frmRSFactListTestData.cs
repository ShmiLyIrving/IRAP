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
using IRAP.Entities.MES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC.Dialogs
{
    public partial class frmRSFactListTestData : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private long rsFactPK = 0;
        private long factID = 0;
        private List<RSFactTestData> datas = new List<RSFactTestData>();

        public frmRSFactListTestData()
        {
            InitializeComponent();
        }

        private void GetTestData(long rsFactPK, long linkedFactID)
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

                IRAPMESClient.Instance.ufn_GetRSFact_TestData(
                    IRAPUser.Instance.CommunityID,
                    rsFactPK,
                    linkedFactID,
                    chkFailOnly.Checked,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                {
                    grdTestDatas.DataSource = datas;
                    grdvTestDatas.BestFitColumns();
                }
                else
                {
                    grdTestDatas.DataSource = null;
                    grdvTestDatas.BestFitColumns();

                    XtraMessageBox.Show(
                        string.Format(
                            "获取检查失效或者测试失败数据时发生错误：\n{0}",
                            errText),
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void ShowDialog(long rsFactPK, long linkedFactID, int metricNumber)
        {
            this.rsFactPK = rsFactPK;
            this.factID = linkedFactID;

            for (int i = 0; i < metricNumber; i++)
            {
                int idx = i + 5;
                if (idx < grdvTestDatas.Columns.Count)
                {
                    grdvTestDatas.Columns[i].Visible = true;
                }
            }

            GetTestData(rsFactPK, linkedFactID);

            ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkFailOnly_CheckedChanged(object sender, EventArgs e)
        {
            GetTestData(rsFactPK, factID);
        }
    }
}
