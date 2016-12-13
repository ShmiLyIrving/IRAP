using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IRAP.Client.User;
using IRAP.Global;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmKanbanAI : IRAP.Client.Global.GUI.frmCustomKanbanBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private DataTable dtHosts = null;
        private int currentCommunityID = 0;
        public frmKanbanAI()
        {
            InitializeComponent();
        }

        private void frmMonitorHostName_Activated(object sender, EventArgs e)
        {
            currentCommunityID = IRAPUser.Instance.CommunityID;
            grdHosts.MainView = BandedGridViewHost;
            GetLoginList();
            this.timer1.Interval = 60000;
            this.timer1.Enabled = true;
        }

        private void ufn_GetList_IsLogin()
        {
            string strProcedureName =
                 string.Format(
                     "{0}.{1}",
                     className,
                     MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
               

                try
                {
                   
                }
                catch (Exception ex)
                {
                    WriteLog.Instance.Write(errText, strProcedureName);
                    XtraMessageBox.Show(ex.ToString(), "系统信息", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    SetConnectionStatus(false);
                }
                return;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

        }

        private void GetLoginList()
        {
            dtHosts = new DataTable();
            int colCount = 8;
            for (int i = 0; i < colCount; i++)
            {
                dtHosts.Columns.Add("Pic" + i.ToString(), typeof(Image));
            }
            for (int i = 0; i < colCount; i++)
            {
                dtHosts.Columns.Add("Des" + i.ToString(), typeof(string));
            }
            //IList<OnLine> onlineHosts = ufn_GetList_IsLogin();
            //if (onlineHosts.Count > 0)
            //{
            //    int actualRowCount = onlineHosts.Count / colCount;
            //    for (int i = 0; i < actualRowCount; i++)
            //    {
            //        DataRow dr = dtHosts.NewRow();
            //        for (int j = 0; j < colCount; j++)
            //        {
            //            int index = i * colCount + j;
            //            string picFieldName = "Pic" + j.ToString();
            //            string desFieldName = "Des" + j.ToString();
            //            if (onlineHosts[index].HostStatus == 0)
            //            {
            //                dr[picFieldName] = IRAP.Client.Global.Resources.Properties.Resources.Computer0;
            //            }
            //            else
            //            {
            //                dr[picFieldName] = IRAP.Client.Global.Resources.Properties.Resources.Computer1;
            //            }
            //            dr[desFieldName] = onlineHosts[index].HostName;
            //        }
            //        dtHosts.Rows.Add(dr);
            //    }
            //    int unFillCol = onlineHosts.Count % colCount;
            //    if (unFillCol > 0)
            //    {
            //        DataRow dr = dtHosts.NewRow();
            //        for (int j = 0; j < unFillCol; j++)
            //        {
            //            int index = actualRowCount * colCount + j;
            //            string picFieldName = "Pic" + j.ToString();
            //            string desFieldName = "Des" + j.ToString();
            //            if (onlineHosts[index].HostStatus == 0)
            //            {
            //                dr[picFieldName] = IRAP.Client.Global.Resources.Properties.Resources.Computer0;
            //            }
            //            else
            //            {
            //                dr[picFieldName] = IRAP.Client.Global.Resources.Properties.Resources.Computer1;
            //            }
            //            dr[desFieldName] = onlineHosts[index].HostName;
            //        }
            //       dtHosts.Rows.Add(dr);
            //    }
            //}
            //grdHosts.DataSource = dtHosts;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            try
            {
                GetLoginList();
            }
            finally
            {
                this.timer1.Enabled = true;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetLoginList();
        }
    }
}
