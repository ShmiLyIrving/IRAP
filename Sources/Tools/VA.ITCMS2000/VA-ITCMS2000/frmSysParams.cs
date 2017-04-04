using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VA_ITCMS2000
{
    public partial class frmSysParams : Form
    {
        public frmSysParams()
        {
            InitializeComponent();
        }

        private void SaveParams()
        {
            SysParams.Instance.DBParams.DBAddress = edtDBAddress.Text.Trim();
            SysParams.Instance.DBParams.DBUserID = edtDBUserID.Text.Trim();
            SysParams.Instance.DBParams.DBUserPWD = edtDBUserPWD.Text.Trim();
            SysParams.Instance.DBParams.DBName = edtDBName.Text.Trim();

            SysParams.Instance.RefreshTimeSpan = Convert.ToInt32(edtRefreshTimeSpan.Value);
            SysParams.Instance.StationID = edtStationID.Text.Trim();

            SysParams.Instance.VAParams.Address = edtIPServAddr.Text.Trim();
            SysParams.Instance.VAParams.UserID = edtIPServUserID.Text.Trim();
            SysParams.Instance.VAParams.UserPWD = edtIPServUserPWD.Text.Trim();
        }

        private void LoadParams()
        {
            edtDBAddress.Text = SysParams.Instance.DBParams.DBAddress;
            edtDBUserID.Text = SysParams.Instance.DBParams.DBUserID;
            edtDBUserPWD.Text = SysParams.Instance.DBParams.DBUserPWD;
            edtDBName.Text = SysParams.Instance.DBParams.DBName;

            edtRefreshTimeSpan.Value = Convert.ToDecimal(SysParams.Instance.RefreshTimeSpan);
            edtStationID.Text = SysParams.Instance.StationID;

            edtIPServAddr.Text = SysParams.Instance.VAParams.Address;
            edtIPServUserID.Text = SysParams.Instance.VAParams.UserID;
            edtIPServUserPWD.Text = SysParams.Instance.VAParams.UserPWD;
        }

        private void frmSysParams_Load(object sender, EventArgs e)
        {
            LoadParams();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveParams();

            btnCancel.PerformClick();
        }
    }
}
