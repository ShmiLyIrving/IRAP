using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.Entity.Kanban;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.SubSystem
{
    public partial class frmSelectOptions : IRAP.Client.Global.frmCustomBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string caption = "";
        private string cultureName = "";

        public frmSelectOptions()
        {
            InitializeComponent();

            cultureName = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToUpper();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System tip";
            else
                caption = "系统信息";
        }

        private void ShowCaption(WIPStation station)
        {
            if (station.IsWorkFlowNode)
            {
                switch (cultureName)
                {
                    case "EN":
                        Text = "Please select A WORKFLOW NODE and A WORKFLOW";
                        splitContainerControl1.Panel1.Text = "Please select a WORKFLOW NODE:";
                        splitContainerControl1.Panel2.Text = "Please select a WORKFLOW:";
                        splitContainerControl2.Panel2.Text = "Search for the current workflow list based on the entered name or code";
                        break;
                    default:
                        Text = "选择【工作流结点】和【工作流】";
                        splitContainerControl1.Panel1.Text = "请选择工作流结点：";
                        splitContainerControl1.Panel2.Text = "请选择工作流：";
                        splitContainerControl2.Panel2.Text = "根据输入的名称和代码在当前工作流列表中查找";
                        break;
                }
            }
            else
            {
                switch (cultureName)
                {
                    case "EN":
                        Text = "Please select a WIP STATION and a PRODUCT";
                        splitContainerControl1.Panel1.Text = "Please select a WIP STATION:";
                        splitContainerControl1.Panel2.Text = "Please select a PRODUCT:";
                        splitContainerControl2.Panel2.Text = "Search for the current product list based on the entered name or code";
                        break;
                    default:
                        Text = "选择【工位】和【产品】";
                        splitContainerControl1.Panel1.Text = "请选择工位：";
                        splitContainerControl1.Panel2.Text = "请选择产品：";
                        splitContainerControl2.Panel2.Text = "根据输入的名称和代码在当前产品列表中查找";
                        break;
                }
            }
        }

        private void frmSelectOptions_Load(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (AvailableWIPStations.Instance.Stations.Count <= 0)
                    AvailableWIPStations.Instance.GetWIPStations(
                        IRAPUser.Instance.CommunityID,
                        IRAPUser.Instance.SysLogID);

                lstOptionOnes.DataSource = AvailableWIPStations.Instance.Stations;
                lstOptionOnes.DisplayMember = "WIPStationName";
                lstOptionOnes.SelectedIndex =
                    AvailableWIPStations.Instance.IndexOf(
                        CurrentOptions.Instance.OptionOne);

                ShowCaption(CurrentOptions.Instance.OptionOne);
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void lstOptionTwos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstOptionTwos.Items.Clear();
            if (lstOptionOnes.SelectedItem != null)
            {
                WIPStation station = lstOptionOnes.SelectedItem as WIPStation;
                try
                {
                    ShowCaption(station);

                    AvailableProducts.Instance.GetProducts(
                        IRAPUser.Instance.CommunityID,
                        IRAPUser.Instance.SysLogID,
                        station.T107LeafID,
                        station.IsWorkFlowNode);

                    lstOptionTwos.DataSource = AvailableProducts.Instance.Products;
                    lstOptionTwos.DisplayMember = "ProductViaStationName";
                    lstOptionTwos.SelectedIndex =
                        AvailableProducts.Instance.IndexOf(
                            CurrentOptions.Instance.OptionTwo);
                }
                catch (Exception error)
                {
                    XtraMessageBox.Show(
                        error.Message,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    Refresh();
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
#if 歌乐
            #region 根据当前选择的产品和工序，确定当前登录操作员能否操作（根据技能矩阵进行判断）
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                IRAPMESClient.Instance.usp_PokaYoke_OperatorSkill(
                    IRAPUser.Instance.CommunityID,
                    ((ProcessInfo)lstProcesses.SelectedItem).T102LeafID,
                    ((WorkUnitInfo)lstWorkUnits.SelectedItem).WorkUnitLeaf,
                    1,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format(
                        "({0}){1}", 
                        errCode, 
                        errText), 
                    strProcedureName);
                if (errCode != 0)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText, 
                        Text);
                    return;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                XtraMessageBox.Show(
                    string.Format(
                        "在校验操作工技能时，发生异常：{0}", 
                        error.Message),
                    Text, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            #endregion
#endif

            CurrentOptions.Instance.OptionOne = (WIPStation)lstOptionOnes.SelectedItem;
            try
            {
                if (lstOptionTwos.SelectedItem == null)
                    CurrentOptions.Instance.OptionTwo = new ProductViaStation();
                else
                    CurrentOptions.Instance.OptionTwo = (ProductViaStation)lstOptionTwos.SelectedItem;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(
                    error.Message,
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmSelectOptions_Paint(object sender, PaintEventArgs e)
        {
            btnSelect.Enabled =
                (lstOptionOnes.SelectedItem != null);
        }

        private void lstWorkUnits_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void lstWorkUnits_DoubleClick(object sender, EventArgs e)
        {
            Refresh();
            if (btnSelect.Enabled)
                btnSelect.PerformClick();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            lstOptionTwos.DataSource = AvailableProducts.Instance.Products;
            lstOptionTwos.DisplayMember = "ProductViaStationName";
            lstOptionTwos.SelectedIndex =
                AvailableProducts.Instance.IndexOf(
                    CurrentOptions.Instance.OptionTwo);
            lstOptionTwos_SelectedIndexChanged(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<ProductViaStation> filterProducts = new List<ProductViaStation>();
                foreach (ProductViaStation product in CurrentOptions.Instance.OptionTwos)
                {
                    if (product.T102Name.IndexOf(edtSearchCondition.Text.Trim()) >= 0||
                        product.T102Code.IndexOf(edtSearchCondition.Text.Trim()) >= 0)
                    {
                        filterProducts.Add(product);
                    }
                }

                lstOptionTwos.DataSource = filterProducts;
                lstOptionTwos.DisplayMember = "ProductViaStationName";
                if (filterProducts.Count > 0)
                {
                    lstOptionTwos.SelectedIndex = 0;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                IRAPMessageBox.Instance.ShowErrorMessage(error.Message, caption);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void edtSearchCondition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnSearch.PerformClick();
        }
    }
}
