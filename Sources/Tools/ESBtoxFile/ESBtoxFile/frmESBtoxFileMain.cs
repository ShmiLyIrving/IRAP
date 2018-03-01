using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Xml;
using System.IO;

using DevExpress.XtraEditors;

using IRAP.Global;

namespace ESBtoxFile
{
    public partial class frmESBtoxFileMain : DevExpress.XtraEditors.XtraForm
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<string> wait4WriteToxFile = new List<string>();
        private List<DoActionFromESB> consumers = new List<DoActionFromESB>();

        private bool canClosed = false;
        private FormWindowState formStatus = FormWindowState.Normal;
        private object lockArea = new object();

        public frmESBtoxFileMain()
        {
            InitializeComponent();
        }
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

            DoActionFromESB consumer =
                new DoActionFromESB(
                    SysParams.Instance.ActiveMQ_URI,
                    SysParams.Instance.ActiveMQ_QueueName,
                    SysParams.Instance.ExCode,
                    SysParams.Instance.FilterString);
            consumer.OutputLog += OutputLog;
            consumer.Write2Queue += WriteToContextQueue;

            consumer.Start();

            consumers.Add(consumer);
        }

        private void WriteToContextQueue(string context)
        {
            lock (lockArea)
            {
                wait4WriteToxFile.Add(context);
            }
        }

        private void OutputLog(string msg, string modeName, ToolTipIcon icon)
        {
            WriteLog.Instance.Write(msg, modeName);

            edtLogs.Text += string.Format("{0}\r\n", msg);
            edtLogs.SelectionStart = edtLogs.Text.Length;
            edtLogs.ScrollToCaret();

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
            //方便操作工不隐藏窗口
            //return;
            formStatus = FormWindowState.Minimized;

            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;

            Hide();
            ShowInTaskbar = false;
        }

        private void ShowForm()
        {
            formStatus = FormWindowState.Normal;
            Show();
            ShowInTaskbar = true;
            Activate();
            SetForegroundWindow(Process.GetCurrentProcess().MainWindowHandle);
        }

        private void SaveToXMLFile(string fileNameTemp, string message)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (message != "")
            {
                try
                {
                    XmlDocument readXml = new XmlDocument();
                    readXml.LoadXml(message);

                    XmlNode node = readXml.SelectSingleNode("/Softland/Head/CorrelationID");
                    if (node == null)
                    {
                        OutputLog(
                            "消息报文头不标准，没有找到 [CorrelationID] 节点",
                            strProcedureName,
                            ToolTipIcon.Error);
                        return;
                    }
                    string correlationID = node.InnerText;

                    node = readXml.SelectSingleNode("/Softland/Head/UnixTime");
                    if (node == null)
                    {
                        OutputLog(
                            "消息报文头不标准，没有找到 [UnixTime] 节点",
                            strProcedureName,
                            ToolTipIcon.Error);
                        return;
                    }
                    DateTime msgTime = TimeParser.UnixToLocalTime(Convert.ToInt64(node.InnerText));

                    msgTime = msgTime.AddSeconds(8 * 60 * 60);
                    fileNameTemp = fileNameTemp.Replace("[ExCode]", SysParams.Instance.ExCode);
                    fileNameTemp = fileNameTemp.Replace("[CorrelationID]", correlationID);
                    fileNameTemp = fileNameTemp.Replace("[DateTime]", msgTime.ToString("yyyyMMddHHmmss"));

                    string fileFullPathName =
                        string.Format(
                            @"{0}\{1}.xml.tmp",
                            SysParams.Instance.LocalFileSaveLocation,
                            fileNameTemp);
                    fileFullPathName.Replace(@"\\", @"\");

                    XmlNode nodeBody = readXml.SelectNodes("/Softland/Body")[0];

                    XmlDocument writeXml = new XmlDocument();
                    XmlDeclaration xmldec = writeXml.CreateXmlDeclaration("1.0", "utf-8", "yes");

                    XmlNode writeRootNode = null;
                    if (SysParams.Instance.XmlRootNodeName != "")
                        writeRootNode = writeXml.CreateElement(SysParams.Instance.XmlRootNodeName);
                    else
                        writeRootNode = writeXml.CreateElement("Root");

                    writeRootNode.InnerXml = nodeBody.InnerXml;
                    //writeXml.InsertAfter(writeRootNode, xmldec);
                    writeXml.AppendChild(xmldec);
                    writeXml.AppendChild(writeRootNode);

                    string fileName = fileFullPathName;
                    string trueFileName = fileFullPathName.Substring(0, fileFullPathName.Length - 4);

                    //writeXml.Save(fileName);
                    var utf8WithBom = new System.Text.UTF8Encoding(false);  // 用true来指定包含bom
                    StreamWriter swr = null;
                    try
                    {
                        //更新数据库状态不需要再打了

                        swr = new StreamWriter(fileName, false, utf8WithBom);
                        writeXml.Save(swr);
                        OutputLog(
                            string.Format(
                                "[{0}] 生成完毕！",
                                trueFileName),
                            strProcedureName,
                            ToolTipIcon.Info);
                    }
                    catch (Exception e)
                    {
                        OutputLog("生成文件错误：" + e.Message, strProcedureName, ToolTipIcon.Error);
                    }
                    finally
                    {
                        if (swr != null)
                        {
                            swr.Close();
                            swr.Dispose();
                        }
                    }
                    //重命名文件
                    File.Move(fileName, trueFileName);
                }
                catch (Exception error)
                {
                    OutputLog(error.Message, strProcedureName, ToolTipIcon.Error);
                }
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (formStatus == FormWindowState.Minimized)
            {
                ShowForm();
            }
            else
            {
                HideForm();
            }
        }

        private void frmESBtoxFileMain_Load(object sender, EventArgs e)
        {
            defaultLookAndFeel.LookAndFeel.SkinName = "Blue";
            //方便操作工自动开始采集 
            btnStart_Click(sender, e);
        }

        private void frmESBtoxFileMain_Shown(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmESBtoxFileMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClosed)
            {
                e.Cancel = false;
                notifyIcon.Visible = false;
            }
            else
            {
                e.Cancel = true;
                HideForm();
            }
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            canClosed = true;
            Close();
        }

        private void tsmiConfiguration_Click(object sender, EventArgs e)
        {
            using (frmSysParams frmParams = new frmSysParams())
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

        private void timerWriteToxFile_Tick(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            timerWriteToxFile.Enabled = false;

            try
            {
                if (wait4WriteToxFile.Count <= 0)
                {
                    return;
                }
                string _dataDir = SysParams.Instance.LocalFileSaveLocation;
                string[] fileList = Directory.GetFiles(_dataDir, "*.xml" );
                if (fileList.Length > 0)
                {
                    Thread.Sleep(500);               
                    //目录下有文件就不继续生成文件了！
                    return;
                }
               
                string temp = wait4WriteToxFile[0];
                lock (lockArea)
                {
                    wait4WriteToxFile.RemoveAt(0);
                }

                if (!Directory.Exists(SysParams.Instance.LocalFileSaveLocation))
                    Directory.CreateDirectory(SysParams.Instance.LocalFileSaveLocation);

                switch (SysParams.Instance.FileType)
                {
                    case "XML 文件":
                        SaveToXMLFile(
                            SysParams.Instance.LocalFileName,
                            temp);
                        break;
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
                            //UDFActions.DoActions(
                            //    node,
                            //    null);
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
                timerWriteToxFile.Enabled = true;
            }
        }
    }
}