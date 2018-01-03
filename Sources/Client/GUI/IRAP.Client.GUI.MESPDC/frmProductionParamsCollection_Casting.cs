using DevExpress.XtraEditors;
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
                var data = IRAPMESProductionClient.Instance.GetInfoContent(_communityID,_sysLogID, out errCode, out errText);
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
        #region 事件
        //todo:删除此行
        private void simpleButton1_Click(object sender, EventArgs e) {
            frmProductionParamsCollection_Casting_Load(sender, e);
        }

        private void frmProductionParamsCollection_Casting_Load(object sender, EventArgs e) {
            var furnaces = GetFurnaces();
        }
        #endregion

        
       
    }
}
