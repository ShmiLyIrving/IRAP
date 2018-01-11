using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IRAP.Interface.OPC;
using IRAP.OPC.Entity;
using IRAP.Global;
using OPCClient.Classes;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace OPCClient.Dialogs
{
    public partial class dlgAddDevice:UDFdialog
    {
        string[] devicecode;
        public dlgAddDevice()
        {
            InitializeComponent();            
        }
        public dlgAddDevice(string title,string[] DeviceCode):base(title)
        {
            InitializeComponent();
            SetLabelMouseDown();
            devicecode = DeviceCode;
            cboKepServAddr.Properties.NullText = "请选择服务器地址...";
            foreach (var server in IRAPOPCServers.Instance.Items)
            {
                cboKepServAddr.Properties.Items.Add(server);
            }

            cboKepServAddr.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (BlankValidate())
            {
                TUpdateDeviceTagsContent content = new TUpdateDeviceTagsContent();
                content.Head.ExCode = "UpdateDeviceTags";
                content.Request.ExCode = "UpdateDeviceTags";
                content.Request.UpdateType = 1;
                content.Request.DeviceName = edtDeviceName.Text;
                content.Request.DeviceCode = edkDeviceCode.Text;
                content.Request.KepServAddr = cboKepServAddr.Text;
                content.Request.KepServChannel = edtKepServChannel.Text;
                content.Request.KepServDevice = edtKepServDevice.Text;
                content.Request.KepServName = edtKepServName.Text;
                content.ResolveResponse(OPCWSClient.Instance.WSCall(content.GenerateRequestContent()));

                if (content.Response.ErrCode == "0")
                {
                    this.DialogResult = DialogResult.OK;
                    devicecode[0] = content.Request.DeviceCode;
                }
                else
                {
                    XtraMessageBox.Show(content.Response.ErrCode + ":" + content.Response.ErrText);
                }
            }
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cboKepServAddr_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.edtKepServName.Text = (this.cboKepServAddr.SelectedItem as IRAPOPCServer).Name;
        }
    }
}
