using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraTab;

namespace OPCClient.UserContols
{
    public partial class ucOPCMonitor : OPCClient.UserContols.ucCustomBase
    {
        public ucOPCMonitor()
        {
            InitializeComponent();

            AfterConstructor();
        }

        public ucOPCMonitor(string title) : base(title)
        {
            InitializeComponent();

            AfterConstructor();
        }

        private void AfterConstructor()
        {
            foreach (ServerAddress server in ServerAddresses.Instance.Items)
            {
                XtraTabPage page = new XtraTabPage();
                page.Text = string.Format("OPCServer：[{0}]", server.Address);

                ucOPCServer newUC = new ucOPCServer(page.Text);
                newUC.Dock = DockStyle.Fill;
                page.Controls.Add(newUC);

                tcOPCMonitors.TabPages.Add(page);
            }
        }
    }
}
