using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Net;
using System.Net.Sockets;

namespace IRAP.Global
{
    public class SocketPrint
    {
        private static string className =
        MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static SocketPrint _instance = null;

        public SocketPrint() { }

        public static SocketPrint Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SocketPrint();
                return _instance;
            }
        }

        /// <summary>
        /// 打印机 IP 地址
        /// </summary>
        public string PrinterAddress { get; set; }

        /// <summary>
        /// 打印机端口号
        /// </summary>
        public int PrinterPort { get; set; }

        public bool PrinterReady()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(PrinterAddress), PrinterPort);
            try
            {
                using (Socket socket =
                    new Socket(
                        AddressFamily.InterNetwork,
                        SocketType.Stream,
                        ProtocolType.Tcp))
                {
                    socket.Connect(endPoint);
                    return true;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                return false;
            }
        }

        public bool Print(string data)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(PrinterAddress), PrinterPort);
            try
            {
                using (Socket socket =
                    new Socket(
                        AddressFamily.InterNetwork,
                        SocketType.Stream,
                        ProtocolType.Tcp))
                {
                    socket.Connect(endPoint);

                    string[] arrayData = data.Split('\n');
                    for (int i = 0; i < arrayData.Length; i++)
                    {
                        WriteLog.Instance.Write(arrayData[i], strProcedureName);
                        byte[] bData = Encoding.Default.GetBytes(arrayData[i] + "\r\n");
                        socket.Send(bData);
                    }
                    return true;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                return false;
            }
        }
    }
}