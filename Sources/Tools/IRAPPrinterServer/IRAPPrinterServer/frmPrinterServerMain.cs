using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Xml;
using System.Runtime.InteropServices;
using System.Diagnostics;

using IRAP.Global;
using IRAP.Client.Actions;

namespace IRAPPrinterServer
{
    public partial class frmPrinterServerMain : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<string> wait4Print = new List<string>();
        private List<DoActionFromESB> consumers = new List<DoActionFromESB>();

        private bool canClosed = false;
        private object lockArea = new object();

        public frmPrinterServerMain()
        {
            InitializeComponent();
        }

        #region 自定义函数
        private void ClearConsumers()
        {
            for (int i = 0; i < consumers.Count; i++)
            {
                consumers[i].Stop();

                consumers[i].OutputLog -= OutputLog;
                consumers[i].Write2Queue -= WriteToContextQueue;

                consumers[i] = null;
            }
            consumers.Clear();
        }

        private void InitConsumers()
        {
            ClearConsumers();

            if (SystemParams.Instance.DeviceCode != "")
            {
                string[] t133Codes = SystemParams.Instance.DeviceCode.Split(',');
                for (int i = 0; i < t133Codes.Length; i++)
                {
                    DoActionFromESB consumer =
                        new DoActionFromESB(
                            SystemParams.Instance.ActiveMQ_URI,
                            SystemParams.Instance.ActiveMQ_QueueName,
                            t133Codes[i]);
                    consumer.OutputLog += OutputLog;
                    consumer.Write2Queue += WriteToContextQueue;

                    consumer.Start();

                    consumers.Add(consumer);
                }
            }
        }

        private void WriteToContextQueue(string context)
        {
            lock (lockArea)
            {
                wait4Print.Add(context);
            }
        }

        private void OutputLog(string msg, string modeName, ToolTipIcon icon)
        {
            WriteLog.Instance.Write(msg, modeName);

            memoEdit1.Text += string.Format("{0}\r\n", msg);
            memoEdit1.SelectionStart = memoEdit1.Text.Length;
            memoEdit1.ScrollToCaret();

            ShowMessageInBalloon(msg, icon, 5000);
        }

        private void ShowMessageInBalloon(
            string msg,
            ToolTipIcon icon = ToolTipIcon.None,
            int timeout = 1000)
        {
            string caption = "";
            switch (icon)
            {
                case ToolTipIcon.Error:
                    caption = "错误消息";
                    break;
                case ToolTipIcon.Info:
                    caption = "提示信息";
                    break;
                case ToolTipIcon.None:
                    caption = "";
                    break;
                case ToolTipIcon.Warning:
                    caption = "警告信息";
                    break;
            }
            notifyIcon.ShowBalloonTip(timeout, caption, msg, icon);
        }

        private void HideForm()
        {
            Hide();
            ShowInTaskbar = false;
        }

        private void ShowForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
            SetForegroundWindow(Process.GetCurrentProcess().MainWindowHandle);
        }
        #endregion

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowForm();
            }
            else
            {
                WindowState = FormWindowState.Minimized;
                HideForm();
            }
        }

        private void frmPrinterServerMain_Shown(object sender, EventArgs e)
        {
            timerPrint.Enabled = true;

            InitConsumers();
        }

        private void timerPrint_Tick(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            timerPrint.Enabled = false;

            try
            {
                if (wait4Print.Count <= 0)
                {
                    return;
                }

                string temp = wait4Print[0];
                lock (lockArea)
                {
                    wait4Print.RemoveAt(0);
                }

                // 打印
                if (temp != "")
                {
                    try
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(temp);

                        foreach (XmlNode node in xmlDoc.SelectNodes("Softland/Body"))
                        {
                            UDFActions.DoActions(
                                node,
                                null);
                        }
                    }
                    catch (Exception error)
                    {
                        OutputLog(error.Message, strProcedureName, ToolTipIcon.Error);
                    }
                }
            }
            finally
            {
                timerPrint.Enabled = true;
            }
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            canClosed = true;
            Close();
        }

        private void tsmiConfiguration_Click(object sender, EventArgs e)
        {
            using (frmSystemParams frmParams = new frmSystemParams())
            {
                frmParams.ShowDialog();

                ClearConsumers();
                Thread.Sleep(100);
                InitConsumers();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            InitConsumers();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ClearConsumers();
        }

        private void frmPrinterServerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClosed)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                HideForm();
            }
        }

        private void frmPrinterServerMain_Resize(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    HideForm();
                    break;
            }
        }
    }
}
