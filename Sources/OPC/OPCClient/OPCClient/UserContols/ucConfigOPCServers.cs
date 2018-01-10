using DevExpress.XtraEditors;
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
            grdOPCServers.DataSource = IRAPOPCServers.Instance.Items;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (Dialogs.dlgAddorModifyServer dlgaddormodifyserver = new Dialogs.dlgAddorModifyServer("添加服务器"))
            {
                dlgaddormodifyserver.ShowDialog();
                grdOPCServers.RefreshDataSource();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rlt = XtraMessageBox.Show("确定要删除该服务器？", "删除", MessageBoxButtons.OKCancel);
            if (rlt == DialogResult.OK)
            {
                IRAPOPCServers.Instance.UpdateKepServ(IRAPOPCServers.Instance.Items[grdvOPCServers.GetFocusedDataSourceRowIndex()].Address, IRAPOPCServers.Instance.Items[grdvOPCServers.GetFocusedDataSourceRowIndex()].Name, 3);
                grdOPCServers.RefreshDataSource();
            }
        }
    }
}
