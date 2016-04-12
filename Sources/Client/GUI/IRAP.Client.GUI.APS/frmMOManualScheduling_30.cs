using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Telerik.WinControls.UI;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.Entity.Kanban;
using IRAP.Entity.APS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.APS
{
    public partial class frmMOManualScheduling_30 : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private static string className = 
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private string moPattern = "";
        private List<LeafSetEx> areas = new List<LeafSetEx>();
        private List<ManufacturingOrder> orders = new List<ManufacturingOrder>();
        private bool showRunning = false;
        private MenuInfo menuInfo = null;

        public frmMOManualScheduling_30()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取工段列表
        /// </summary>
        private void GetT124Items()
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    124,
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    ref areas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode == 0)
                {
                    LeafSetEx_ComparerByLeafID comparer = new LeafSetEx_ComparerByLeafID();
                    areas.Sort(comparer);

                    foreach (LeafSetEx area in areas)
                    {
                        cboAreas.Items.Add(
                            new RadListDataItem(
                                area.CodeAndName,
                                area.Clone()));
                    }

                    if (cboAreas.Items.Count > 1)
                        cboAreas.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(
                        errText, 
                        "获取工段列表", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                MessageBox.Show(
                    error.Message, 
                    "获取工段列表", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmMOManualScheduling_30_Shown(object sender, EventArgs e)
        {
            GetT124Items();
        }

        /// <summary>
        /// 获取制造订单格式字符串
        /// </summary>
        public void GetMOPattern()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据制造订单格式串获得制造订单列表
        /// </summary>
        public void GetOrdersWithMOPattern()
        {
            throw new System.NotImplementedException();
        }

        public string GetMinSchedulingTime(int orderIndex)
        {
            throw new System.NotImplementedException();
        }

        public string GetMaxSchedulingTime(int orderIndex)
        {
            throw new System.NotImplementedException();
        }

        private void frmMOManualScheduling_30_Activated(object sender, EventArgs e)
        {
            if (Tag is MenuInfo)
                menuInfo = (MenuInfo) Tag;

            if (moPattern == "")
            {
                GetMOPattern();
                GetOrdersWithMOPattern();
            }
        }
    }
}
