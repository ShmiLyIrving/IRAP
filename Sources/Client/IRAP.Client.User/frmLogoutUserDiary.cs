using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.User
{
    public partial class frmLogoutUserDiary : IRAP.Client.Global.frmCustomBase
    {
        public frmLogoutUserDiary()
        {
            InitializeComponent();
        }

        public string UserDiary
        {
            get { return edtUserDiary.Text; }
            set { edtUserDiary.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
