using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IRAP.OPC.Entity;
using IRAP.OPC.Library;
using IRAP.Interface.OPC;
using OPCClient.Classes;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System.Reflection;
using IRAP.Global;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors;

namespace OPCClient.UserContols
{
    public partial class ucDeviceTagManage : OPCClient.UserContols.ucCustomBase
    {
        public ucDeviceTagManage()
        {
            InitializeComponent();
        }

        public ucDeviceTagManage(string title) : base(title)
        {
            InitializeComponent();
        }

        private void cmsDeviceList_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void tsmiImportDeviceTags_Click(object sender, EventArgs e)
        {
            if (tlDevices.FocusedNode != null&& tlDevices.FocusedNode.Level>0)
            {
                string devicecode = tlDevices.FocusedNode.Tag.ToString();
                using (Dialogs.dlgImportDeviceTag dlgImportTags = new Dialogs.dlgImportDeviceTag("导入设备标签",devicecode))
                {
                    dlgImportTags.ShowDialog();
                    if(dlgImportTags.DialogResult ==DialogResult.OK)
                    {
                        RefreshTreelist();
                        if (GetNode(devicecode) != null)
                        {
                            tlDevices.SetFocusedNode(GetNode(devicecode));
                        }
                    }
                }
            }
        }
        private TreeListNode GetNode(string devicenode)
        {
            TreeListNode node = null;
            foreach (TreeListNode tn in tlDevices.Nodes[0].Nodes)
            {
                if(tn.Tag.ToString() == devicenode)
                {
                    node = tn;
                }
            }
            return node;
        }
        private void RefreshTreelist()
        {
            tlDevices.Nodes[0].Nodes.Clear();
            if (IRAPOPCDevices.Instance.GetDevices().Count > 0)
            {
                foreach (var d in IRAPOPCDevices.Instance.Devices)
                {
                    TreeListNode tn = tlDevices.AppendNode(new object[] { d.DeviceName }, 0);
                    tn.Tag = d.DeviceCode;
                }
            }
            tlDevices.ExpandAll();
            tlDevices.SetFocusedNode(tlDevices.Nodes[0].Nodes[0]);
        }
        
        private void tlDevices_Load(object sender, EventArgs e)
        {
            RefreshTreelist();
        }

        private void tsmiLoadDevices_Click(object sender, EventArgs e)
        {
            string[] devicecode = new string[] { "" };
            using (Dialogs.dlgAddDevice dlgadddevice = new Dialogs.dlgAddDevice("添加设备",devicecode))
            {
                dlgadddevice.ShowDialog();
                if (dlgadddevice.DialogResult == DialogResult.OK)
                {
                    RefreshTreelist();
                    tlDevices.SetFocusedNode(GetNode(devicecode[0]));
                }
            }
        }

        private void tlDevices_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node!=null&&e.Node.Level > 0)
            {
                TGetDeviceTagsContent content = new TGetDeviceTagsContent();
                content.Head.ExCode = "GetDeviceTags";
                content.Request.ExCode = "GetDeviceTags";
                content.Request.DeviceCode = e.Node.Tag.ToString();
                content.ResolveResponse(OPCWSClient.Instance.WSCall(content.GenerateRequestContent()));
                if (content.Response.ErrCode == "0")
                {
                    if (e.Node.Tag != null)
                    {
                        this.gcTags.DataSource = content.Response.Details;
                        this.gridView1.BestFitColumns();
                    }
                }
                else
                {
                    XtraMessageBox.Show(content.Response.ErrCode + ":" + content.Response.ErrText);
                }
            }
        }

        private void tlDevices_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
                TreeList tree = sender as TreeList;
                TreeListHitInfo hitInfo = tree.CalcHitInfo(new Point(e.X, e.Y));
                if (hitInfo.Node != null&& hitInfo.HitInfoType == HitInfoType.Cell)
                {
                    TreeListNode node = hitInfo.Node;
                    tree.SetFocusedNode(hitInfo.Node);
                    
                    if (tree.FocusedNode != null)
                    {
                        switch (node.Level)
                        {
                            case 0:
                                tsmiDeleteDevice.Enabled = false;
                                tsmiImportDeviceTags.Enabled = false;
                                break;
                            default:
                                tsmiImportDeviceTags.Enabled = true;
                                tsmiDeleteDevice.Enabled = true;
                                break;
                        }
                    }
                }
                else
                {
                    tsmiImportDeviceTags.Enabled = false;
                    tsmiDeleteDevice.Enabled = false;
                }
                cmsDeviceList.Show(p);
            }
        }

        private void tsmiDeleteDevice_Click(object sender, EventArgs e)
        {
            DialogResult resault = XtraMessageBox.Show("是否删除所选设备？", "删除所选设备", MessageBoxButtons.OKCancel);
            if(resault ==DialogResult.OK)
            {
                TIRAPOPCLocDevice device = IRAPOPCDevices.Instance.GetDeviceWithDeviceCode(tlDevices.FocusedNode.Tag.ToString());
                TUpdateDeviceTagsContent content = new TUpdateDeviceTagsContent();
                content.Head.ExCode = "UpdateDeviceTags";
                content.Request.ExCode = "UpdateDeviceTags";
                content.Request.CommunityID = 60010;
                content.Request.UpdateType = 3;
                content.Request.DeviceName = device.DeviceName;
                content.Request.DeviceCode = device.DeviceCode;
                content.Request.KepServAddr = device.KepServerAddr;
                content.Request.KepServChannel = device.KepServerChannel;
                content.Request.KepServDevice = device.KepServerDevice;
                content.Request.KepServName = device.KepServerName;
    
                content.ResolveResponse(OPCWSClient.Instance.WSCall(content.GenerateRequestContent()));              
                if (content.Response.ErrCode == "0")
                {
                    RefreshTreelist();
                }
                else
                {
                    MessageBox.Show(content.Response.ErrCode + ":" + content.Response.ErrText);
                }
            }
        }

        private void tsmirefresh_Click(object sender, EventArgs e)
        {
            RefreshTreelist();
        }
        
    }
}
