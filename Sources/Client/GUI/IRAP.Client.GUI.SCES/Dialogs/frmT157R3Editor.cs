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
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.SCES.Dialogs
{
    public partial class frmT157R3Editor : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public frmT157R3Editor()
        {
            InitializeComponent();

            StickQty = 0;
            PerStickQty = 0;
        }

        /// <summary>
        /// 每车棒数
        /// </summary>
        public int StickQty { get; set; }
        /// <summary>
        /// 每棒数量
        /// </summary>
        public long PerStickQty { get; set; }

        public int TreeID { get; set; }
        public int LeafID { get; set; }

        private void frmT157R3Editor_Shown(object sender, EventArgs e)
        {
            edtCurrentStickQty.Text = StickQty.ToString();
            edtCurrentPerStickQty.Text = PerStickQty.ToString();

            edtNewStickQty.Focus();
        }

        private string GenerateAttrChangeXML()
        {
            string tmp = "";
            tmp =
                string.Format(
                    "<MDM T157LeafID=\"{0}\" TreeID=\"{1}\" " +
                    "LeafID=\"{2}\" StickStdQty=\"{3}\" StickQty=\"{4}\"/>",
                    0,
                    TreeID,
                    LeafID,
                    edtNewPerStickQty.Text,
                    edtNewStickQty.Text);

            return string.Format("<ROOT>{0}</ROOT>", tmp);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Tools.IsNumberic(edtNewStickQty.Text.Trim()))
            {
                XtraMessageBox.Show(
                    "输入的内容不是数值，请重新输入！",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                edtNewStickQty.Text = edtCurrentStickQty.Text;
                edtNewStickQty.Focus();
                return;
            }

            if (!Tools.IsNumberic(edtNewPerStickQty.Text.Trim()))
            {
                XtraMessageBox.Show(
                    "输入的内容不是数值，请重新输入！",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                edtNewPerStickQty.Text = edtCurrentPerStickQty.Text;
                edtNewPerStickQty.Focus();
                return;
            }

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "未执行";

                IRAPMDMClient.Instance.usp_SaveRSAttr_T157R3(
                    IRAPUser.Instance.CommunityID,
                    GenerateAttrChangeXML(),
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show(
                        errText,
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    edtNewStickQty.Focus();
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
