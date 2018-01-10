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
    public delegate void Refreshserver();
    public partial class ucOPCMonitor : OPCClient.UserContols.ucCustomBase
    {
        public ucOPCMonitor()
        {
            InitializeComponent();
        }

        public ucOPCMonitor(string title,ref Refreshserver re) : base(title)
        {
            InitializeComponent();
            re = AfterConstructor;
        }

        private void AfterConstructor()
        {
            tcOPCMonitors.TabPages.Clear();
            foreach (IRAPOPCServer server in IRAPOPCServers.Instance.Items)
            {
                XtraTabPage page = new XtraTabPage();
                page.Text = string.Format("OPCServer：[{0}]", server.Address);

                ucOPCServer newUC = new ucOPCServer(page.Text);
                newUC.Dock = DockStyle.Fill;
                page.Controls.Add(newUC);

                tcOPCMonitors.TabPages.Add(page);
            }
        }

        private void ucOPCMonitor_Load(object sender, EventArgs e)
        {
            AfterConstructor();
        }
    }
}
