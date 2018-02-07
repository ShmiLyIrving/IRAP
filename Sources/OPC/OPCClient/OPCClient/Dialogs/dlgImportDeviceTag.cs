using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using IRAP.OPC.Library;
using IRAP.Interface.OPC;
using IRAP.OPC.Entity;
using OPCClient.Classes;
using DevExpress.XtraEditors.DXErrorProvider;

namespace OPCClient.Dialogs
{
    public partial class dlgImportDeviceTag: UDFdialog
    {
        private List<TIRAPOPCKepDeviceTagInfo> tags = new List<TIRAPOPCKepDeviceTagInfo>();
        private TIRAPOPCLocDevice device;

        public dlgImportDeviceTag()
        {
            InitializeComponent();
        }
        public dlgImportDeviceTag(string title,string DeviceCode) : base(title)
        {
            InitializeComponent();
            SetLabelMouseDown();
            this.device = IRAPOPCDevices.Instance.GetDeviceWithDeviceCode(DeviceCode);
        }

        private string[] SplitCSVLine(string line)
        {
            List<string> a = new List<string>();

            string tmp = "";
            bool record = false;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '\"')
                {
                    record = !record;
                }
                else
                {
                    if (line[i] == ',')
                    {
                        if (record)
                        {
                            tmp += line[i];
                        }
                        else
                        {
                            a.Add(tmp);
                            tmp = "";
                        }
                    }
                    else
                        tmp += line[i];
                }
            }
            if (tmp != "" || a.Count > 0)
                a.Add(tmp);

            return a.ToArray();
        }

        private void edtFileName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            openFileDialog.Title = "选择设备标签文件";
            openFileDialog.Filter = "设备标签文件(*.CSV)|*.CSV|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                edtFileName.Text = openFileDialog.FileName;

                tags.Clear();

                bool isFirst = true;

                using (StreamReader sr = 
                    new StreamReader(
                        openFileDialog.FileName, 
                        Encoding.Default))
                {
                    string srTemp = "";
                    while ((srTemp = sr.ReadLine()) != null)
                    {
                        if (isFirst && chkIncludeTitle.Checked)
                        {
                            isFirst = false;
                            continue;
                        }

                        string[] tagInfo = SplitCSVLine(srTemp);

                        TIRAPOPCKepDeviceTagInfo tag = new TIRAPOPCKepDeviceTagInfo();

                        tag.TagName = tagInfo[0].Replace("\"", "");
                        tag.Address = tagInfo[1].Replace("\"", "");
                        tag.DataType = tagInfo[2].Replace("\"", "");
                        tag.RespectDataType = tagInfo[3].Replace("\"", "");
                        tag.ClientAccess = tagInfo[4].Replace("\"", "");
                        tag.ScanRate = tagInfo[5].Replace("\"", "");
                        tag.Scaling = tagInfo[6].Replace("\"", "");
                        tag.RawLow = tagInfo[7].Replace("\"", "");
                        tag.RawHigh = tagInfo[8].Replace("\"", "");
                        tag.ScaledLow = tagInfo[9].Replace("\"", "");
                        tag.ScaledHigh = tagInfo[10].Replace("\"", "");
                        tag.ScaledDataType = tagInfo[11].Replace("\"", "");
                        tag.ClampLow = tagInfo[12].Replace("\"", "");
                        tag.ClampHigh = tagInfo[13].Replace("\"", "");
                        tag.EngUnits = tagInfo[14].Replace("\"", "");
                        tag.Description = tagInfo[15].Replace("\"", "");
                        tag.NegateValue = tagInfo[16].Replace("\"", "");


                        tags.Add(tag);
                    }
                }

                grdTags.DataSource = tags;
                grdvTags.BestFitColumns();
            }
        }

        private void dlgImportDeviceTag_Load(object sender, EventArgs e)
        {
            this.cboKepServAddr.Text = device.KepServerAddr;
            this.edtKepServChannel.Text = device.KepServerChannel;
            this.edtKepServDevice.Text = device.KepServerDevice;
            this.edtKepServName.Text = device.KepServerName;
            cboKepServAddr.Properties.NullText = "请选择服务器地址...";
            foreach (var server in IRAPOPCServers.Instance.Items)
            {
                cboKepServAddr.Properties.Items.Add(server);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (BlankValidate())
            {
                if (this.tags.Count > 0)
                {
                    TUpdateDeviceTagsContent content = new TUpdateDeviceTagsContent();
                    content.Head.ExCode = "UpdateDeviceTags";
                    content.Request.ExCode = "UpdateDeviceTags";
                    content.Request.CommunityID = 60010;
                    content.Request.UpdateType = 2;
                    content.Request.DeviceName = device.DeviceName;
                    content.Request.DeviceCode = device.DeviceCode;
                    content.Request.KepServAddr = cboKepServAddr.Text;
                    content.Request.KepServChannel = edtKepServChannel.Text;
                    content.Request.KepServDevice = edtKepServDevice.Text;
                    content.Request.KepServName = edtKepServName.Text;

                    List<TUpdateDeviceTagsReqDetail> details = new List<TUpdateDeviceTagsReqDetail>();
                    foreach (TIRAPOPCKepDeviceTagInfo tag in tags)
                    {
                        TUpdateDeviceTagsReqDetail detail = new TUpdateDeviceTagsReqDetail();
                        detail.DataType = tag.DataType;
                        detail.Description = tag.Description;
                        detail.TagName = tag.TagName;
                        content.Request.Details.Add(detail);
                    }
                    content.ResolveResponse(OPCWSClient.Instance.WSCall(content.GenerateRequestContent()));
                    if (content.Response.ErrCode != "0")
                    {
                        XtraMessageBox.Show(content.Response.ErrCode + ":" + content.Response.ErrText);
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    XtraMessageBox.Show("您尚未选择要导入的标签文件!");
                }
            }
        }

        private void cboKepServAddr_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.edtKepServName.Text = (this.cboKepServAddr.SelectedItem as IRAPOPCServer).Name;
        }
    }
}