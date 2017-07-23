using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

using DevExpress.XtraEditors;

using IRAP.Entity.Kanban;

namespace IRAP.Client.GUI.MESPDC
{
    public class ScannerForSerialPort
    {
        private ListBoxControl barCodes = null;
        private StationPortInfo portInfo = null;
        private SerialPort serialPort = null;
        private string serialPortOpenError = "";

        public ScannerForSerialPort(
            ListBoxControl lstBarCodes, 
            StationPortInfo portInfo)
        {
            barCodes = lstBarCodes;
            this.portInfo = portInfo;

            Parity parity = (Parity)portInfo.Parity;
            StopBits stopBits = (StopBits)portInfo.StopBits;

            serialPort =
                new SerialPort(
                    portInfo.CommPort,
                    portInfo.BoudRate,
                    parity,
                    portInfo.ByteSize,
                    stopBits);
            serialPort.DataReceived += 
                new SerialDataReceivedEventHandler(OnDataReceived);

            try
            {
                serialPort.Open();
            }
            catch (Exception error)
            {
                serialPortOpenError = error.Message;
            }
        }

        ~ScannerForSerialPort()
        {
            Close();
        }

        /// <summary>
        /// 串口扫描枪是否打开
        /// </summary>
        public bool IsOpen
        {
            get { return serialPort.IsOpen; }
        }

        /// <summary>
        /// 串口扫描枪打开失败时得到的出错信息
        /// </summary>
        public string OpenErrorMessage
        {
            get { return serialPortOpenError; }
        }

        /// <summary>
        /// 打开串口扫描枪端口，准备接收扫描到的条码
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            serialPortOpenError = "";

            try
            {
                if (serialPort.IsOpen)
                    return true;

                serialPort.Open();
            }
            catch (Exception error)
            {
                serialPortOpenError = error.Message;
            }

            return serialPort.IsOpen;
        }

        /// <summary>
        /// 关闭串口扫描枪端口
        /// </summary>
        public void Close()
        {
            try
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
            }
            catch (Exception error)
            {
                serialPortOpenError = error.Message;
            }
        }

        protected void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string buffer = serialPort.ReadLine();
            buffer = 
                string.Format(
                    "{0}|{1}", 
                    portInfo.CommPort, 
                    buffer.Replace((char)13, (char)0).Replace((char)10, (char)0));

            barCodes.Invoke(new EventHandler(delegate { barCodes.Items.Add(buffer); }));
        }
    }
}