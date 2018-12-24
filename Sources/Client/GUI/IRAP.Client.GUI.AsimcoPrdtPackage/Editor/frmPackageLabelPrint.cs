using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Entities.Asimco;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.AsimcoPrdtPackage.Editor
{
    public partial class frmPackageLabelPrint : frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private WaitPackageSO so = null;

        public frmPackageLabelPrint()
        {
            InitializeComponent();
        }

        public frmPackageLabelPrint(
            WaitPackageSO so,
            List<PackageLine> lines) : base()
        {
            this.so = so;

            foreach (PackageLine line in lines)
            {
                cboPackageLines.Properties.Items.Add(line);
            }
        }

        /// <summary>
        /// 根据订单号和行号获取客户
        /// </summary>
        /// <param name="moNumber"></param>
        /// <param name="moLineNo"></param>
        /// <returns></returns>
        private List<PackageClient> GetCustomersFromPrdt(
            string moNumber, int moLineNo)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";


            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<PackageClient> datas = new List<PackageClient>();

                AsimcoPackageClient.Instance.ufn_GetList_PackageClient(
                    IRAPUser.Instance.CommunityID,
                    moNumber,
                    moLineNo,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode != 0)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(errText);
                }

                return datas;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmPackageLabelPrint_Shown(object sender, EventArgs e)
        {
            if (so != null)
            {
                List<PackageClient> customers =
                    GetCustomersFromPrdt(
                        so.SONumber,
                        so.SOLineNo);

                int idx = -1;
                for (int i = 0; i < customers.Count; i++)
                {
                    if (customers[i].T105Code == so.CustomerCode)
                    {
                        idx = i;
                    }
                    cboPackageLines.Properties.Items.Add(customers[i]);
                }

                cboPackageLines.SelectedIndex = idx;
                cboPackageLines.Enabled = idx < 0;
            }
        }
    }
}
