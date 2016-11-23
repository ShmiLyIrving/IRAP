using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;

namespace IRAP.Client.GUI.MESRPT
{
    public partial class frmRPT_PWOHistoryTracking_30 : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private static string className = "IRAP.Client.GUI.MESRPT.frmRPT_PWOHistoryTracking_30";
        private DataTable dtProductGroup = null;
        //List<TEntityMOExecution> reportList = new List<TEntityMOExecution>();

        public frmRPT_PWOHistoryTracking_30()
        {
            InitializeComponent();
            InitGridView();
            InitDateTime();
        }
        private void InitDateTime()
        {
            dateTimeStart.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            dateTimeStart.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;

            dateTimeStart.Properties.DisplayFormat.FormatString= "G";
            dateTimeStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateTimeStart.Properties.EditFormat.FormatString = "G";
            dateTimeStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateTimeStart.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm;ss";

            dateTimeEnd.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            dateTimeEnd.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;

            dateTimeEnd.Properties.DisplayFormat.FormatString = "G";
            dateTimeEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateTimeEnd.Properties.EditFormat.FormatString = "G";
            dateTimeEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateTimeEnd.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm;ss"; 
        }
        private void InitGridView()
        {
            this.gdvMOExecution.OptionsView.ShowGroupPanel = false;
            this.gdvMOExecution.OptionsView.ShowIndicator = true;
            this.gdvMOExecution.IndicatorWidth = 40;
            this.gdvMOExecution.OptionsSelection.MultiSelect = false; 
            this.gdvMOExecution.OptionsMenu.EnableColumnMenu = false;
            this.gdvMOExecution.OptionsBehavior.Editable = false;  
        }
        private void GetProductGroupList()
        {
            //string strProcedureName = className + ".GetProductGroupList";
            //WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            //try
            //{
            //    int errCode = 0;
            //    string errText = "";
            //    List<TEntityProductGroup> list = new List<TEntityProductGroup>();
            //    try
            //    {
            //        IRAPMDMClient.Instance.ufn_GetList_ProductGroup(
            //            IRAPUser.Instance.CommunityID, 
            //            IRAPUser.Instance.SysLogID,
            //            ref list,
            //            out errCode,
            //            out errText);
            //        WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
            //        if (errCode == 0)
            //        {
            //            dtProductGroup = new DataTable();
            //            dtProductGroup.Columns.Add("id", typeof(int));
            //            dtProductGroup.Columns.Add("text", typeof(string));
            //            foreach (TEntityProductGroup model in list)
            //            {
            //                DataRow dr = dtProductGroup.NewRow();
            //                dr[0] = model.T132LeafID;
            //                dr[1] = model.T132NodeName;
            //                dtProductGroup.Rows.Add(dr); 
            //            }
            //            lpProductGroup.Properties.ValueMember = "id";
            //            lpProductGroup.Properties.DisplayMember = "text";
            //            lpProductGroup.Properties.NullText = string.Empty;
            //            lpProductGroup.Properties.DataSource = dtProductGroup;
            //            lpProductGroup.ItemIndex = 0;
            //        }
            //        else
            //        {
            //            MessageBox.Show(errText, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    catch (Exception error)
            //    {
            //        WriteLog.Instance.Write(error.Message, strProcedureName);
            //        MessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //}
            //finally
            //{
            //    WriteLog.Instance.WriteEndSplitter(strProcedureName);
            //}
        }
        private void GetPWOHistoryTrackingRPT(int communityID, int t132LeafID, string SearchStartTime, string SearchEndTime)
        {
            //string strProcedureName = className + "GetPWOHistoryTrackingRPT";
            //WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            //try
            //{
            //    int errCode = 0;
            //    string errText = "";
            //    List<TEntityMOExecution> list = new List<TEntityMOExecution>();
            //    try
            //    {
            //        IRAPKanbanClient.Instance.ufn_GetReport_MOExecution(
            //            IRAPUser.Instance.CommunityID, 
            //            t132LeafID,
            //            SearchStartTime,
            //            SearchEndTime,
            //            IRAPUser.Instance.SysLogID,
            //            ref reportList,
            //            out errCode,
            //            out errText);
            //        WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
            //        if (errCode == 0)
            //        {
            //            grdMOExecution.DataSource = reportList;
            //            gdvMOExecution.BestFitColumns();
            //        }
            //        else
            //        {
            //            MessageBox.Show(errText, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    catch (Exception error)
            //    {
            //        WriteLog.Instance.Write(error.Message, strProcedureName);
            //        MessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //}
            //finally
            //{
            //    WriteLog.Instance.WriteEndSplitter(strProcedureName);
            //}
        }

        private void frmRPT_PWOHistoryTracking_30_Load(object sender, EventArgs e)
        {
            GetProductGroupList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int t132LeafID = 0;
            int.TryParse(lpProductGroup.EditValue.ToString(), out t132LeafID);
            if (t132LeafID <= 0)
            {
                XtraMessageBox.Show("请选择产品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } 

            if (dateTimeStart.EditValue == null)
            {
                XtraMessageBox.Show("请选择开始时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string startTime = Convert.ToDateTime(dateTimeStart.EditValue.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            if (dateTimeEnd.EditValue == null)
            {
                XtraMessageBox.Show("请选择结束时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string endTime = Convert.ToDateTime(dateTimeEnd.EditValue.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            if (DateTime.Parse(startTime) >= DateTime.Parse(endTime))
            {
                XtraMessageBox.Show("开始时间不能大于等于结束时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (DateTime.Parse(startTime).Year != DateTime.Parse(endTime).Year)
            {
                XtraMessageBox.Show("开始时间与结束时间必须在同一年！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            GetPWOHistoryTrackingRPT(IRAPUser.Instance.CommunityID, t132LeafID, startTime, endTime);
        }
        
    }
}
