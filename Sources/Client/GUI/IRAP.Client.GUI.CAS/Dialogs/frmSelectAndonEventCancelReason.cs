using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using IRAP.Global;
using IRAP.Entities.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS.Dialogs
{
    public partial class frmSelectAndonEventCancelReason : IRAP.Client.Global.frmCustomBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static frmSelectAndonEventCancelReason _instance = null;

        private string caption = "";

        public frmSelectAndonEventCancelReason()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System tips";
            else
                caption = "系统信息";
        }

        public static frmSelectAndonEventCancelReason Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSelectAndonEventCancelReason();
                return _instance;
            }
        }

        public string GetReason(int communityID, long sysLogID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            string rlt = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int errCode = 0;
                string errText = "";
                List<AndonCancelReason> datas = new List<AndonCancelReason>();

                IRAPFVSClient.Instance.ufn_GetList_AndonCancelReason(
                    communityID,
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
                            "数据库中安灯事件撤销原因！",
                            caption);
                        return rlt;
                    }

                    foreach (AndonCancelReason data in datas)
                    {
                        cboCancelReason.Properties.Items.Add(data);
                    }

                    if (cboCancelReason.Properties.Items.Count > 0)
                        cboCancelReason.SelectedIndex = 0;
                    btnOK.Enabled = cboCancelReason.Properties.Items.Count > 0;
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
                return ((AndonCancelReason)cboCancelReason.SelectedItem).CancelReason;
            }
            else
                return rlt;
        }
    }
}
