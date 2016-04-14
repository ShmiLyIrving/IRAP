using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using IRAP.Client.Global;
using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystems;

namespace IRAP.Client.Global.GUI
{
    public partial class frmCustomFuncBase : frmCustomBase
    {
        protected static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private ucOptions barOptions = null;
        private bool refreshGUIOptions = false;

        public frmCustomFuncBase()
        {
            InitializeComponent();
        }

        [Browsable(true), Description("界面激活后，是否需要刷新“选项一”和“选项二”")]
        public bool RefreshGUIOptions
        {
            get { return refreshGUIOptions; }
            set { refreshGUIOptions = value; }
        }

        public ucOptions Options
        {
            get { return barOptions; }
            set { barOptions = value; }
        }

        private void frmCustomFuncBase_Shown(object sender, EventArgs e)
        {
            lblFuncName.Text = Text;
        }

        private void frmCustomFuncBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (barOptions != null)
            {
                barOptions.Visible = false;
                barOptions.ShowSwitchButton();
            }
        }

        private void frmCustomFuncBase_Activated(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (barOptions != null)
                {
                    barOptions.Visible = false;
                    barOptions.ShowSwitchButton();

                    if (IRAPUser.Instance.RefreshGUIOptions)
                        barOptions.RefreshOptions();
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WindowState = FormWindowState.Maximized;
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
