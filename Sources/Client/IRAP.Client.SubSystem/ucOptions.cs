using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.Entities.MDM;

namespace IRAP.Client.SubSystem
{
    public partial class ucOptions : DevExpress.XtraEditors.XtraUserControl
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        /// <summary>
        /// 选项一、二更改后的事件
        /// </summary>
        public event EventHandler OptionChanged;

        public ucOptions()
        {
            InitializeComponent();
        }

        public ProcessInfo SelectProduct
        {
            get
            {
                if (cboOptionsOne.SelectedItem != null)
                    return (ProcessInfo)cboOptionsOne.SelectedItem;
                else
                    return null;
            }
        }

        public WorkUnitInfo SelectWorkUnit
        {
            get
            {
                if (cboOptionsTwo.SelectedItem != null)
                    return (WorkUnitInfo)cboOptionsTwo.SelectedItem;
                else
                    return null;
            }
        }

        public void RefreshOptions()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 获取当前站点的可用产品/流程列表
                try
                {
                    AvailableWIPStations.Instance.GetWIPStations(
                        IRAPUser.Instance.CommunityID,
                        IRAPUser.Instance.SysLogID);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    XtraMessageBox.Show(
                        error.Message,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                #endregion

                #region 将获取的产品/流程列表加入下拉列表中
                cboOptionsOne.Properties.Items.Clear();
                foreach (WIPStation station in AvailableWIPStations.Instance.Stations)
                    cboOptionsOne.Properties.Items.Add(station);

                if (cboOptionsOne.Properties.Items.Count > 0)
                {
                    cboOptionsOne.SelectedIndex = 0;

                    try
                    {
                        CurrentOptions.Instance.OptionOne =
                            (WIPStation)cboOptionsOne.SelectedItem;

                        cboOptionsTwo.Properties.Items.Clear();
                        foreach (ProductViaStation product in CurrentOptions.Instance.OptionTwos)
                            cboOptionsTwo.Properties.Items.Add(product);
                        cboOptionsTwo.SelectedIndex = CurrentOptions.Instance.IndexOfOptionTwo;
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                    }
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 刷新当前的 OptionsTwo
        /// </summary>
        /// <param name="t102LeafID">产品叶标识</param>
        public void RefreshOptionTwo(int t102LeafID)
        {
            foreach (ProductViaStation product in AvailableProducts.Instance.Products)
            {
                if (product.T102LeafID == t102LeafID)
                {
                    CurrentOptions.Instance.OptionTwo = product;

                    cboOptionsTwo.SelectedIndex = CurrentOptions.Instance.IndexOfOptionTwo;
                }
            }
        }

        public void ResetCurrentOptions()
        {
            cboOptionsOne.Properties.Items.Clear();
            cboOptionsOne.Properties.Items.Add(CurrentOptions.Instance.OptionOne);
            cboOptionsOne.SelectedIndex = 0;

            cboOptionsTwo.Properties.Items.Clear();
            foreach (ProductViaStation product in CurrentOptions.Instance.OptionTwos)
                cboOptionsTwo.Properties.Items.Add(product);
            if (CurrentOptions.Instance.OptionTwo.T102LeafID != 0)
                cboOptionsTwo.SelectedIndex = CurrentOptions.Instance.IndexOfOptionTwo;

            if (OptionChanged != null)
                OptionChanged(this, new EventArgs());
        }

        private void ucOptions_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    if (Visible)
                    {
                        if (AvailableWIPStations.Instance.Stations.Count == 0)
                            RefreshOptions();
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            using (frmSelectOptions selectOptions = new frmSelectOptions())
            {
                if (selectOptions.ShowDialog() == DialogResult.OK)
                    ResetCurrentOptions();
            }
        }

        public void ShowSwitchButton(bool boolShowSwtichButton = true)
        {
            btnSwitch.Visible = boolShowSwtichButton;
        }

        private void cboOptionsOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOptionsOne.SelectedIndex >= 0)
                CurrentOptions.Instance.OptionOne = cboOptionsOne.SelectedItem as WIPStation;
            else
                CurrentOptions.Instance.OptionOne = null;
        }

        private void cboOptionsTwo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOptionsTwo.SelectedItem == null)
                CurrentOptions.Instance.OptionTwo = null;
            else
                CurrentOptions.Instance.OptionTwo = cboOptionsTwo.SelectedItem as ProductViaStation;
        }
    }
}
