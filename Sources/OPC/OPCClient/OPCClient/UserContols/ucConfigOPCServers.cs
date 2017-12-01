using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OPCClient.UserContols
{
    public partial class ucConfigOPCServers : OPCClient.UserContols.ucCustomBase
    {
        public ucConfigOPCServers()
        {
            InitializeComponent();

            AfterConstructor();
        }

        public ucConfigOPCServers(string title) : base(title)
        {
            InitializeComponent();

            AfterConstructor();
        }

        private void AfterConstructor()
        {
            grdOPCServers.DataSource = ServerAddresses.Instance.Items;
        }
    }
}
