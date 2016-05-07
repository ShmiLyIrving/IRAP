using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using IRAP.Global;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public abstract class CustomPrint
    {
        public CustomPrint(XmlNode actionParams)
        {
        }

        public abstract void DoPrint(string dataToPrint);
    }

    public class CustomPrintFactory
    {
        public static CustomPrint CreateInstance(XmlNode actionParams)
        {
            if (actionParams.Attributes["PrintType"] == null)
                return null;

            string printType = actionParams.Attributes["PrintType"].Value.ToString();
            switch (printType.ToUpper())
            {
                case "LPT":
                    return new PrintToLPT(actionParams);
                case "SOCKET":
                    return new PrintToSocket(actionParams);
                default:
                    return null;
            }
        }
    }

    public class PrintToLPT : CustomPrint
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private string strLPTPort = "LPT1";

        public PrintToLPT(XmlNode actionParams)
            : base(actionParams)
        {
            try
            {
                strLPTPort = actionParams.Attributes["PrintTo"].Value.ToString();
            }
            catch { }
        }

        public override void DoPrint(string dataToPrint)
        {
            string strProcedureName =
                string.Format(
                "{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                WriteLog.Instance.Write(
                    string.Format(
                        "向端口[{0}]发送打印内容[{1}]",
                        strLPTPort,
                        dataToPrint),
                    strProcedureName);
                using (LPTPrint print = new LPTPrint())
                {
                    try
                    {
                        print.LPTWrite(strLPTPort, dataToPrint);
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        XtraMessageBox.Show(
                            error.Message,
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }

    public class PrintToSocket : CustomPrint
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private string printerIPAddress = "";
        private int printerPort = 0;

        public PrintToSocket(XmlNode actionParams)
            : base(actionParams)
        {
            string temp = "";
            try { temp = actionParams.Attributes["PrintToAddress"].Value; }
            catch { temp = ""; }
            if (temp != "")
                printerIPAddress = temp;

            try { temp = actionParams.Attributes["PrintToPort"].Value; }
            catch { temp = ""; }
            if (temp != "")
                try { printerPort = Int32.Parse(temp); }
                catch { }
        }

        public override void DoPrint(string dataToPrint)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                WriteLog.Instance.Write(
                    string.Format(
                        "向打印机[{0}：{1}]发送打印内容[{2}]",
                        printerIPAddress,
                        printerPort,
                        dataToPrint),
                    strProcedureName);

                try
                {
                    SocketPrint.Instance.PrinterAddress = printerIPAddress;
                    SocketPrint.Instance.PrinterPort = printerPort;

                    if (SocketPrint.Instance.PrinterReady())
                        SocketPrint.Instance.Print(dataToPrint);
                    else
                    {
                        WriteLog.Instance.Write(string.Format("打印机[{0}:{1}]离线，无法打印！",
                                SocketPrint.Instance.PrinterAddress,
                                SocketPrint.Instance.PrinterPort),
                            strProcedureName);
                        XtraMessageBox.Show(string.Format("打印机[{0}:{1}]离线，无法打印！",
                                SocketPrint.Instance.PrinterAddress,
                                SocketPrint.Instance.PrinterPort),
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    XtraMessageBox.Show(error.Message,
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
