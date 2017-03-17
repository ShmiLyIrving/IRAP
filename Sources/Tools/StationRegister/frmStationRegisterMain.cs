using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.WCF.Client.Method;

namespace StationRegister
{
    public partial class frmStationRegisterMain : Form
    {
        public frmStationRegisterMain()
        {
            InitializeComponent();
        }

        private void frmStationRegisterMain_Load(object sender, EventArgs e)
        {
            string macAddr = "";

            // 如果配置文件中设置了 MAC 地址，并且指明使用 MAC 地址，则读取该配置的 MAC 地址
            string strCFGFileName = string.Format(@"{0}\IRAP.ini",
                AppDomain.CurrentDomain.BaseDirectory);
            bool usingVirtualAddr = IniFile.ReadBool(
                "Virtual Station",
                "Virtual Station Used",
                false,
                strCFGFileName);
            if (usingVirtualAddr)
            {
                macAddr = IniFile.ReadString(
                        "Virtual Station",
                        "Virtual Station",
                        "",
                        strCFGFileName);
            }

            if (macAddr.Trim() != "")
                cboMadAddress.Properties.Items.Add(macAddr);

            string macAddresses = RDPClientMAC.GetRDPMacAddress();
            string[] arrMacAddress = macAddresses.Split(';');
            for (int i = 0; i < arrMacAddress.Length; i++)
                cboMadAddress.Properties.Items.Add(arrMacAddress[i]);

            if (cboMadAddress.Properties.Items.Count > 0)
                cboMadAddress.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (cboMadAddress.SelectedItem == null)
            {
                cboMadAddress.Focus();
                return;
            }
            if (edtCommunityID.Text.Trim() == "")
            {
                edtCommunityID.Focus();
                return;
            }
            if (edtFuncGroupID.Text.Trim() == "")
            {
                edtFuncGroupID.Focus();
                return;
            }
            if (edtTemplateSTN.Text.Trim() == "")
            {
                edtTemplateSTN.Focus();
                return;
            }

            int errCode = 0;
            string errText = "";

            try
            {
                IRAPSystemClient.Instance.ssp_RegistStation(
                    cboMadAddress.SelectedItem as string,
                    Tools.ConvertToInt32(edtCommunityID.Text),
                    Tools.ConvertToInt32(edtFuncGroupID.Text),
                    edtTemplateSTN.Text,
                    out errCode,
                    out errText);
                XtraMessageBox.Show("站点注册完成！");                
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(error.Message);
            }
        }
    }
}
