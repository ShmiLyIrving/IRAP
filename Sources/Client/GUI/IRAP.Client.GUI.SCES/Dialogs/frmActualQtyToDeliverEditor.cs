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
    public partial class frmActualQtyToDeliverEditor : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public frmActualQtyToDeliverEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 实际库存量
        /// </summary>
        public long ActualQtyInStore { get; set; }
        /// <summary>
        /// 实际配送量
        /// </summary>
        public long ActualQtyToDeliver { get; set; }
        /// <summary>
        /// 生产工单的事实编号
        /// </summary>
        public long OrderFactID { get; set; }
        /// <summary>
        /// 子项树标识
        /// </summary>
        public int SubTreeID { get; set; }
        /// <summary>
        /// 子项叶标识
        /// </summary>
        public int SubLeafID { get; set; }

        private void frmActualQtyToDeliverEditor_Shown(object sender, EventArgs e)
        {
            edtCurrentActualQtyToDeliver.Text = ActualQtyToDeliver.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Tools.IsNumberic(edtNewActualQtyToDeliver.Text.Trim()))
            {
                XtraMessageBox.Show(
                    "输入的内容不是数值，请重新输入！",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                edtNewActualQtyToDeliver.Text = edtCurrentActualQtyToDeliver.Text;
                edtNewActualQtyToDeliver.Focus();
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

                IRAPSCESClient.Instance.usp_SaveFact_PWODeliveryQty(
                    IRAPUser.Instance.CommunityID,
                    OrderFactID,
                    Tools.ConvertToInt64(edtNewActualQtyToDeliver.Text.Trim()),
                    SubTreeID,
                    SubLeafID,
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
                    edtNewActualQtyToDeliver.Focus();
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
