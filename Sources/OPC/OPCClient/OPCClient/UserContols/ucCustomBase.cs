using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace OPCClient.UserContols
{
    public partial class ucCustomBase : DevExpress.XtraEditors.XtraUserControl
    {
        public ucCustomBase()
        {
            InitializeComponent();

            lblTitle.Text = "";
        }

        public ucCustomBase(string title) : this()
        {
            lblTitle.Text = title;
        }
    }
}
