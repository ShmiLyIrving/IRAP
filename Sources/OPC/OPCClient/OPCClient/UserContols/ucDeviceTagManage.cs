using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            if (tlDevices.FocusedNode == null)
            {
                e.Cancel = true;
            }
            else
            {
                switch (tlDevices.FocusedNode.Level)
                {
                    case 0:
                        tsmiLoadDevices.Visible = true;
                        tsmiSplitter1.Visible = false;
                        tsmiImportDeviceTags.Visible = false;
                        break;
                    default:
                        tsmiLoadDevices.Visible = false;
                        tsmiSplitter1.Visible = false;
                        tsmiImportDeviceTags.Visible = true;
                        break;
                }
            }
        }
    }
}
