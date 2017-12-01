using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace OPCClient.UserContols
{
    public partial class ucConfigSysParams : OPCClient.UserContols.ucCustomBase
    {
        public ucConfigSysParams()
        {
            InitializeComponent();

            InitData();
        }

        public ucConfigSysParams(string title) : base(title)
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            edtESBAddress.Text = SysParams.Instance.ESB.ESBAddress;
            edtESBQueueName.Text = SysParams.Instance.ESB.ESBQueue;
            edtESBFilterString.Text = SysParams.Instance.ESB.ESBFilterSring;

            edtExCode.Text = SysParams.Instance.Content.ExCode;
            edtCommunityID.Text = SysParams.Instance.Content.CommunityID.ToString();
            edtSysLogID.Text = SysParams.Instance.Content.SysLogID.ToString();
            edtUserCode.Text = SysParams.Instance.Content.UserCode;
            edtAgencyLeaf.Text = SysParams.Instance.Content.AgencyLeaf.ToString();
            edtRoleLeaf.Text = SysParams.Instance.Content.RoleLeaf.ToString();
            edtStationID.Text = SysParams.Instance.Content.StationID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SysParams.Instance.ESB.ESBAddress = edtESBAddress.Text.Trim();
            SysParams.Instance.ESB.ESBQueue = edtESBQueueName.Text.Trim();
            SysParams.Instance.ESB.ESBFilterSring = edtESBFilterString.Text.Trim();

            SysParams.Instance.Content.ExCode = edtExCode.Text.Trim();
            SysParams.Instance.Content.CommunityID = Convert.ToInt32(edtCommunityID.Text);
            SysParams.Instance.Content.SysLogID = Convert.ToInt64(edtSysLogID.Text);
            SysParams.Instance.Content.UserCode = edtUserCode.Text.Trim();
            SysParams.Instance.Content.AgencyLeaf = Convert.ToInt32(edtAgencyLeaf.Text);
            SysParams.Instance.Content.RoleLeaf = Convert.ToInt32(edtRoleLeaf.Text);
            SysParams.Instance.Content.StationID = edtStationID.Text.Trim();

            SysParams.Instance.Save();

            XtraMessageBox.Show(
                "参数已经保存",
                "系统信息",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
