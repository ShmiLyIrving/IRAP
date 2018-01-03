﻿using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using IRAP.Client.GUI.MESPDC.UserControls;
using IRAP.Client.User;
using IRAP.Entities.MES;
using IRAP.Global;
using IRAP.WCF.Client.Method;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.MESPDC {
    public partial class frmProductionParamsCollection_Casting : IRAP.Client.Global.GUI.frmCustomFuncBase {
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        #region Debug
        private int _communityID = 60030;
        private int _sysLogID = 227556;
        #endregion
        

        public frmProductionParamsCollection_Casting() {
            InitializeComponent();
        }

        private List<ProductionParam> GetFurnaces() {
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var data = IRAPMESProductionClient.Instance.GetFurnaceLists(_communityID,_sysLogID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return data;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        private void CreateFurnaceTabPages(List<ProductionParam> furnaces) {
            #region 参数检查
            if (furnaces == null || furnaces.Count == 0) {
                return;
            }
            #endregion
            foreach (ProductionParam furnace in furnaces) {
                CreateNewFurnacePage(furnace);
            }

        }

        private void CreateNewFurnacePage(ProductionParam furnaceData) {
            XtraTabPage tabPage = new XtraTabPage();
            tabPage.Text = furnaceData.T107Name;
            tabPage.Name = furnaceData.T107Name;
            ucFurnace furnaceControl = new ucFurnace(furnaceData);
            furnaceControl.Dock = DockStyle.Fill;
            tabPage.Controls.Add(furnaceControl);
            this.tabPageControl.TabPages.Add(tabPage);
        }

        private void ClearPage() {
            this.tabPageControl.TabPages.Clear();
        }

        #region 事件
        //todo:删除此行
        private void simpleButton1_Click(object sender, EventArgs e) {
            frmProductionParamsCollection_Casting_Load(sender, e);
        }

        private void frmProductionParamsCollection_Casting_Load(object sender, EventArgs e) {
            ClearPage();
            var furnaces = GetFurnaces();
            CreateFurnaceTabPages(furnaces);
        }
        #endregion

        
       
    }
}
