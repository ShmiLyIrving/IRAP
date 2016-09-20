using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO.Ports;
using System.Reflection;
using System.Windows.Forms;

using IRAP.Global;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class SerialPortOutputAction : CustomAction, IUDFAction
    {
        private string className =
          MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string portName = "COM1";
        private int baudRate = 9600;
        private Parity parity = Parity.None;
        private int dataBits = 8;
        private StopBits stopBits = StopBits.One;
        private string dataType = "";
        private string data = "";

        public SerialPortOutputAction(XmlNode actionParams, ExtendEventHandler extendAction)
            : base(actionParams, extendAction)
        {
            portName = actionParams.Attributes["PortName"].Value;
            int.TryParse(actionParams.Attributes["BaudRate"].Value, out baudRate);
            parity = (Parity)Convert.ToInt32(actionParams.Attributes["Parity"].Value);
            dataBits = Convert.ToInt32(actionParams.Attributes["DataBits"].Value);
            stopBits = (StopBits)Convert.ToInt32(actionParams.Attributes["StopBits"].Value);

            dataType = actionParams.Attributes["DataType"].Value;
            data = actionParams.Attributes["Data"].Value;
        }

        public void DoAction()
        {
            string strProcedureName =
                string.Format(
                "{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                SerialPort port = new SerialPort(portName, baudRate, parity, dataBits, stopBits);

                WriteLog.Instance.Write(
                    string.Format("打开串口 [{0}]。", portName),
                    strProcedureName);
                port.Open();

                if (port.IsOpen)
                {
                    if (dataType.ToUpper() == "ASCII")
                    {
                        WriteLog.Instance.Write(
                            string.Format(
                                "向串口 [{0}] 输出 [{1}]。",
                                portName,
                                data),
                            strProcedureName);
                        port.WriteLine(data);
                        WriteLog.Instance.Write(
                            string.Format(
                                "向串口 [{0}] 输出完成。",
                                portName),
                            strProcedureName);
                    }

                    if (dataType.ToUpper() == "HEX")
                    {
                        byte[] writeBuffer = Tools.HexStringToByteArray(data);
                        WriteLog.Instance.Write(
                            string.Format(
                                "向串口 [{0}] 输出 [{1}]。",
                                portName,
                                data),
                            strProcedureName);
                        port.Write(writeBuffer, 0, writeBuffer.Length);
                        WriteLog.Instance.Write(
                            string.Format(
                                "向串口 [{0}] 输出完成。",
                                portName),
                            strProcedureName);
                    }

                    port.Close();
                }
                else
                {
                    string errMsg = string.Format("无法打开串口[{0}]！", portName);
                    IRAPMessageBox.Instance.Show(
                        errMsg,
                        "串口输出",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    WriteLog.Instance.Write(errMsg, strProcedureName);
                }
            }
            catch (Exception error)
            {
                IRAPMessageBox.Instance.Show(
                    error.Message, 
                    "串口输出", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                WriteLog.Instance.Write(error.Message, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }

    public class SerialPortOutputFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction)
        {
            return new SerialPortOutputAction(actionParams, extendAction);
        }
    }
}