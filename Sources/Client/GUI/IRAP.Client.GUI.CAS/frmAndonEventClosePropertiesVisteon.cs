using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using IRAP.Global;
using IRAP.Client.Global.GUI.Dialogs;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.Entities.SSO;
using IRAP.WCF.Client.Method;
using IRAP.Entity.FVS;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmAndonEventClosePropertiesVisteon : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private UserInfo userInfo = new UserInfo();

        bool isShowMessageBeforeActive = false;
        public frmAndonEventClosePropertiesVisteon()
        {
            InitializeComponent();
        }

        private void GetT144Leaf(int T134LeafID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            int errCode = 0;
            string errText = "";
            List<AnomalyCauseType> datas = new List<AnomalyCauseType>();

            rgpT144Leaf.Properties.Items.Clear();
            rgpT144Leaf.SelectedIndex = -1;

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPFVSClient.Instance.ufn_GetList_AnomalyCauseTypes(
                    IRAPUser.Instance.CommunityID,
                    T134LeafID,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    foreach (AnomalyCauseType data in datas)
                    {
                        rgpT144Leaf.Properties.Items.Add(
                            new RadioGroupItem()
                            {
                                Description = data.T144Name,
                                Value = data,
                            });
                    }
                }
                else
                {
                    isShowMessageBeforeActive = true;
                    IRAPMessageBox.Instance.Show(
                        errText,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }


        int t144LeafID = 0;
        public void GetT144LeafID(long eventFactID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            int errCode = 0;
            string errText = "";
            List<AnomalyCauseType> datas = new List<AnomalyCauseType>();
                rgpT144Leaf.Properties.Items.Clear();
                rgpT144Leaf.SelectedIndex = -1;
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);

            try
            {
                IRAPFVSClient.Instance.ufn_GetT144LeafID(
                    IRAPUser.Instance.CommunityID,
                    eventFactID,
                    IRAPUser.Instance.SysLogID,
                    ref t144LeafID,
                    out errCode,
                    out errText
                    );
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if(errCode==0)
                {
                    if (t144LeafID >= 0)
                    {
                        foreach (RadioGroupItem item in rgpT144Leaf.Properties.Items)
                        {
                            AnomalyCauseType data = item.Value as AnomalyCauseType;
                            if (data.T144LeafID == t144LeafID)
                            {
                                rgpT144Leaf.SelectedIndex = rgpT144Leaf.Properties.Items.IndexOf(item);
                            }
                        }
                    }
                    else if(t144LeafID < 0)
                    {
                        rgpT144Leaf.SelectedIndex = 0;
                        rgpT144Leaf.Properties.Items.Add(new RadioGroupItem());
                    }

                }
                else
                {
                    isShowMessageBeforeActive = true;
                    IRAPMessageBox.Instance.Show(
                        errText,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
           finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
        /// <summary>
        /// 确定按钮测试获取值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show(rgpT144Leaf.SelectedIndex.ToString());
            MessageBox.Show(memoEdit1.Text);
        }
    }
}
