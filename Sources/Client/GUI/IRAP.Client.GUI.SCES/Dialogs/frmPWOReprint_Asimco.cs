using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using IRAP.Global;

namespace IRAP.Client.GUI.SCES.Dialogs
{
    public partial class frmPWOReprint_Asimco : IRAP.Client.Global.frmCustomBase
    {
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private int t173LeafID = 0;

        public frmPWOReprint_Asimco()
        {
            InitializeComponent();
        }

        public frmPWOReprint_Asimco(int t173LeafID) : this()
        {
            this.t173LeafID = t173LeafID;
        }
    }
}
