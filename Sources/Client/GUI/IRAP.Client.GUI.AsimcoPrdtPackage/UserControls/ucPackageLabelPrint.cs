using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonsPanelControl;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global;
using IRAP.Entities.Asimco;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.AsimcoPrdtPackage.UserControls
{
    public partial class ucPackageLabelPrint : XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<PackageLine> lines = new List<PackageLine>();

        public ucPackageLabelPrint()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取当前待打印包装标签的订单
        /// </summary>
        /// <param name="moNumber"></param>
        /// <param name="productNo"></param>
        /// <returns></returns>
        private List<WaitPackageSO> GetCurrentPackageSOs(
            string moNumber, string productNo)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";


            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<WaitPackageSO> datas = new List<WaitPackageSO>();

                AsimcoPackageClient.Instance.ufn_GetList_WaitPackageSO(
                    IRAPUser.Instance.CommunityID,
                    moNumber,
                    productNo,
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

        /// <summary>
        /// 获取当前配置的包装生产线清单
        /// </summary>
        /// <returns></returns>
        private List<PackageLine> GetPackageLines()
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";


            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<PackageLine> datas = new List<PackageLine>();

                AsimcoPackageClient.Instance.ufn_GetList_PackageLine(
                    IRAPUser.Instance.CommunityID,
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

        private void RefreshPackageSOs()
        {
            List<WaitPackageSO> datas = GetCurrentPackageSOs("", "");
            grdPackageSOs.DataSource = datas;
            grdvPackageSOs.BestFitColumns();
        }

        private void ucPackageLabelPrint_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                RefreshPackageSOs();
                lines = GetPackageLines();
            }
        }

        private void btnLabelPrint_Click(object sender, EventArgs e)
        {
            int idx = grdvPackageSOs.GetFocusedDataSourceRowIndex();
            if (idx >= 0)
            {
                List<WaitPackageSO> datas = 
                    grdPackageSOs.DataSource as List<WaitPackageSO>;

                using (Editor.frmPackageLabelPrint form =
                    new Editor.frmPackageLabelPrint(
                        datas[idx],
                        lines))
                {
                    if (form.ShowDialog() != DialogResult.Cancel)
                    {
                        RefreshPackageSOs();
                    }
                }
            }
        }

        private void gpcPackageSOs_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            GroupBoxButton button = e.Button as GroupBoxButton;
            switch (button.Caption)
            {
                case "刷新订单":
                    RefreshPackageSOs();

                    break;
                default:
                    break;
            }
        }
    }
}
