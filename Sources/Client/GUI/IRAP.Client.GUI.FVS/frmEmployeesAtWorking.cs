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
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.FVS
{
    public partial class frmEmployeesAtWorking : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public frmEmployeesAtWorking()
        {
            InitializeComponent();
        }

        private void GetEmployeesAtWork()
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
                List<EmployeeAtWork> datas = new List<EmployeeAtWork>();

                IRAPFVSClient.Instance.ufn_GetInfo_AtWork(
                    IRAPUser.Instance.CommunityID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    grdEmployees.DataSource = datas;
                    grdvEmployees.BestFitColumns();
                }
                else
                {
                    grdEmployees.DataSource = null;

                    XtraMessageBox.Show(
                        errText,
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

        private void frmEmployeesAtWorking_Shown(object sender, EventArgs e)
        {
            GetEmployeesAtWork();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetEmployeesAtWork();
        }
    }
}
