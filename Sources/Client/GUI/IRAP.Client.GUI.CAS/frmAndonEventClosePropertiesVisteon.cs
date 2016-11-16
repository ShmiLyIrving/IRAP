using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.Global.GUI.Dialogs;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.Entities.SSO;
using IRAP.WCF.Client.Method;
using IRAP.Entity.FVS;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmAndonEventClosePropertiesVisteon : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private int t134LeafID = 0;

        public frmAndonEventClosePropertiesVisteon()
        {
            InitializeComponent();
        }

        public int T134LeafID
        {
            get { return t134LeafID; }
            set
            {
                t134LeafID = value;

                if (t134LeafID == 0)
                {
                    rgpT144Leaf.Properties.Items.Clear();
                    rgpT144Leaf.SelectedIndex = -1;
                }
                else
                {
                    GetT144Leaf(t134LeafID);
                }
            }
        }

        public string Remark
        {
            get
            {
                return edtRemark.Text;
            }
        }

        public int T144LeafID
        {
            get
            {
                if (rgpT144Leaf.SelectedIndex >= 0)
                {
                    int idx = rgpT144Leaf.SelectedIndex;
                    if (rgpT144Leaf.Properties.Items[idx].Value is AnomalyCauseType)
                    {
                        AnomalyCauseType type = rgpT144Leaf.Properties.Items[idx].Value as AnomalyCauseType;
                        return type.T144LeafID;
                    }
                    else
                        return 0;
                }
                else
                    return 0;
            }
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rgpT144Leaf.SelectedIndex < 0)
            {
                IRAPMessageBox.Instance.Show(
                    "请选择【现场原因】！",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
