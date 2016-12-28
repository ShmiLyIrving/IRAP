using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using System.Reflection;
using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Entities.MES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC.Dialogs
{
    public partial class frmSelectDestT216LeafID : IRAP.Client.Global.frmCustomBase
    {
        private static string className = 
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static frmSelectDestT216LeafID instance = null;

        private string caption = "";

        public frmSelectDestT216LeafID()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System tips";
            else
                caption = "系统信息";
        }

        public static frmSelectDestT216LeafID Instance
        {
            get
            {
                if (instance == null)
                    instance = new frmSelectDestT216LeafID();
                return instance;
            }
        }

        public int DestT216LeafID(int communityID, int t102LeafID, int srcT107LeafID, long sysLogID)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);
            int rlt = -1;

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int errCode = 0;
                string errText = "";
                List<QCOperationsForNG> datas = new List<QCOperationsForNG>();

                IRAPMESTSClient.Instance.ufn_GetList_QCOperationsForNG(
                    communityID,
                    t102LeafID,
                    srcT107LeafID,
                    sysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode == 0)
                {
                    if (datas.Count == 0)
                    {
                        IRAPMessageBox.Instance.ShowErrorMessage(
                            "数据库中尚未配置当前产品修复后的返回工序列表！", 
                            caption);
                        return rlt;
                    }

                    foreach (QCOperationsForNG data in datas)
                    {
                        cboDestT216LeafIDs.Properties.Items.Add(data);
                    }

                    if (cboDestT216LeafIDs.Properties.Items.Count > 0)
                        cboDestT216LeafIDs.SelectedIndex = 0;
                    btnOK.Enabled = cboDestT216LeafIDs.Properties.Items.Count > 0;
                }
                else
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(errText, caption);
                    return rlt;
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

            if (this.ShowDialog() == DialogResult.OK)
            {
                return ((QCOperationsForNG)cboDestT216LeafIDs.SelectedItem).T216Leaf;
            }
            else
                return rlt;
        }
    }
}
