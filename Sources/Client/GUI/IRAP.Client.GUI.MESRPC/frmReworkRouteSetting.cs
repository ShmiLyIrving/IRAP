using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global.GUI;
using IRAP.Client.Global.Enums;
using IRAP.Entities.MES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESRPC
{
    public partial class frmReworkRouteSetting : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<OpenReworkPWO> pwos = new List<OpenReworkPWO>();

        public frmReworkRouteSetting()
        {
            InitializeComponent();
        }

        #region 自定义函数
        private void GetOpenReworkPWOs()
        {
            string strProcedureName = 
                string.Format("{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                WriteLog.Instance.Write("获取需要配置返工路由表的工单列表", strProcedureName);
                try
                {
                    int errCode = 0;
                    string errText = "";

                    IRAPMESClient.Instance.ufn_GetList_OpenReworkPWOs(
                        IRAPUser.Instance.CommunityID,
                        IRAPUser.Instance.SysLogID,
                        ref pwos,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    grdPWOs.DataSource = pwos;
                    grdvPWOs.BestFitColumns();
                    grdvPWOs.LayoutChanged();
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);

                    grdPWOs.DataSource = null;
                    grdvPWOs.LayoutChanged();
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
        #endregion

        private void frmReworkRouteSetting_Load(object sender, EventArgs e)
        {
            GetOpenReworkPWOs();
        }

        private void grdvPWOs_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                btnConfiguration.Visible = false;
            else
            {
                OpenReworkPWO pwo = pwos[e.FocusedRowHandle];

                switch (pwo.PWOStatus)
                {
                    case 1:
                        btnConfiguration.Visible = true;
                        btnConfiguration.Text = "新建返工配置";
                        miConfiguration.Enabled = true;
                        miConfiguration.Text = btnConfiguration.Text;
                        break;
                    case 2:
                    case 3:
                    case 4:
                        btnConfiguration.Visible = true;
                        btnConfiguration.Text = "修改返工配置";

                        miConfiguration.Enabled = true;
                        miConfiguration.Text = btnConfiguration.Text;
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        btnConfiguration.Visible = true;
                        btnConfiguration.Text = "查看返工配置";

                        miConfiguration.Enabled = true;
                        miConfiguration.Text = btnConfiguration.Text;
                        break;
                    default:
                        btnConfiguration.Visible = false;
                        miConfiguration.Enabled = false;
                        break;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            int rowHandle = grdvPWOs.FocusedRowHandle;
            GetOpenReworkPWOs();
            if (rowHandle >= 0 && rowHandle < pwos.Count)
            {
                grdvPWOs.FocusedRowHandle = rowHandle;
            }
            else
            {
                if (pwos.Count > 0)
                    grdvPWOs.FocusedRowHandle = 0;
            }
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            using (frmReworkRouterConfiguration formConfig = new frmReworkRouterConfiguration())
            {
                OpenReworkPWO reworkPWO = pwos[grdvPWOs.FocusedRowHandle];
                formConfig.ReworkPWO = reworkPWO;

                switch (btnConfiguration.Text)
                {
                    case "新建返工路由":
                        formConfig.Mode = EditStatus.New;
                        break;
                    case "修改返工路由":
                        formConfig.Mode = EditStatus.Edit;
                        break;
                    case "查看返工路由":
                        formConfig.Mode = EditStatus.Browse;
                        break;
                }

                formConfig.ShowDialog();

                btnRefresh.PerformClick();
            }
        }

        private void miConfiguration_Click(object sender, EventArgs e)
        {
            btnConfiguration.PerformClick();
        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }
    }
}
