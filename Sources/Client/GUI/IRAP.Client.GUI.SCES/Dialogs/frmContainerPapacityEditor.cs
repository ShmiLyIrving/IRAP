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
using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.SCES.Dialogs
{
    public partial class frmContainerPapacityEditor : frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string productCode = "";
        private List<CapacityForT101OrT102> capacities =
            new List<CapacityForT101OrT102>();

        private string capacityLabel = "容器容量";

        public frmContainerPapacityEditor()
        {
            InitializeComponent();

            switch (IRAPUser.Instance.CommunityID)
            {
                case 60010:
                case 60030:
                    capacityLabel = "每杆数量";
                    break;
                default:
                    capacityLabel = "容器容量";
                    break;
            }

            Text = string.Format("{0}修改", capacityLabel);
            lblCurrentCapacity.Text = string.Format("原\"{0}\"", capacityLabel);
            lblNewCapacity.Text = string.Format("现\"{0}\"", capacityLabel);
        }

        public frmContainerPapacityEditor(
            string productCode): this()
        {
            try
            {
                capacities = GetContainerCapacity(productCode);

                if (capacities.Count > 0)
                    edtCurrentCapacity.Text = capacities[0].StdQty.ToString();
                else
                {
                    XtraMessageBox.Show(
                        string.Format(
                            "产品编号：[{0}]无法配置\"{1}\"",
                            productCode,
                            capacityLabel),
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    throw new Exception("无法配置");
                }
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message, 
                    "提示", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                throw error;
            }
        }

        private List<CapacityForT101OrT102> GetContainerCapacity(string productCode)
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
                List<CapacityForT101OrT102> datas = new List<CapacityForT101OrT102>();

                IRAPMDMClient.Instance.ufn_GetList_CapacityForT101OrT102(
                    IRAPUser.Instance.CommunityID,
                    productCode,
                    "",
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                    return datas;
                else
                    throw new Exception(errText);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);

                throw error;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private string GenerateAttrChangeXML()
        {
            string tmp = "";
            tmp =
                string.Format(
                    "<MDM T157LeafID=\"{0}\" TreeID=\"{1}\" " +
                    "LeafID=\"{2}\" StdQty=\"{3}\"/>",
                    capacities[0].T157LeafID,
                    capacities[0].TreeID,
                    capacities[0].LeafID,
                    edtNewCapacity.Text.Trim());

            return string.Format("<ROOT>{0}</ROOT>", tmp);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Tools.IsNumberic(edtNewCapacity.Text.Trim()))
            {
                XtraMessageBox.Show(
                    "输入的内容不是数值，请重新输入！",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                edtNewCapacity.Text = edtCurrentCapacity.Text;
                edtNewCapacity.Focus();
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
                string errText = "";

                IRAPMDMClient.Instance.usp_SaveRSAttr_T157RX(
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
                    edtNewCapacity.Focus();
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
