using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;

using IRAP.Global;

namespace IRAP.Client.Global.WarningLight
{
    public class ZLan6042 : WarningLight
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static int redStatus = 0;
        private static int yellowStatus = 0;
        private static int greenStatus = 0;

        private Socket clientSocket = null;

        private static ZLan6042 _instance = null;

        public ZLan6042()
        {
        }

        ~ZLan6042()
        {
            if (clientSocket != null)
            {
                if (clientSocket.Connected)
                {
                    byte[] data = new byte[12]
                    {
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x06,
                        0x01, 0x05, 0x00, 0x10, 0x00, 0x00,
                    };

                    data[9] = 0x10;
                    clientSocket.Send(data, data.Length, SocketFlags.None);
                    Thread.Sleep(100);
                    data[9] = 0x11;
                    clientSocket.Send(data, data.Length, SocketFlags.None);
                    Thread.Sleep(100);
                    data[9] = 0x12;
                    clientSocket.Send(data, data.Length, SocketFlags.None);
                    Thread.Sleep(100);
                }
            }
        }

        public static ZLan6042 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ZLan6042();
                return _instance;
            }
        }

        private void SetLightCmdWithStatus(ref byte[] data, int status)
        {
            if (status == 1)
            {
                data[10] = 0xff;
            }
            else
                data[10] = 0x00;
            data[11] = 0x00;
        }

        public override void SetLightStatus(int red, int yellow, int green)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            SetLightStatus("192.168.57.150", red, yellow, green);
        }

        public override void SetLightStatus(string ipAddress, int red, int yellow, int green)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            int port = 4196;

            WriteLog.Instance.Write(
                string.Format("建立 [{0}:{1}] 的 Socket 连接", ipAddress, port),
                strProcedureName);
            if (clientSocket == null)
            {
                clientSocket =
                    new Socket(
                        AddressFamily.InterNetwork,
                        SocketType.Stream,
                        ProtocolType.Tcp);
            }

            if (!clientSocket.Connected)
            {
                try
                {
                    IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                    clientSocket.Connect(ipep);
                }
                catch (SocketException ex)
                {
                    WriteLog.Instance.Write(
                        string.Format(
                            "无法连接告警灯控制盒[{0}:{1}]，原因：[{2}]", 
                            ipAddress,
                            port,
                            ex.Message),
                        strProcedureName);
                    return;
                }
            }

            if (clientSocket.Connected)
            {
                byte[] data = new byte[12]
                {
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x06,
                        0x01, 0x05, 0x00, 0x10, 0x00, 0x00,
                };

                if (red != redStatus)
                {
                    WriteLog.Instance.Write("发送控制红灯的继电器触点状态", strProcedureName);

                    redStatus = red;

                    data[9] = 0x10;
                    SetLightCmdWithStatus(ref data, red);

                    clientSocket.Send(data, data.Length, SocketFlags.None);
                    Thread.Sleep(50);
                }

                if (yellow != yellowStatus)
                {
                    WriteLog.Instance.Write("发送控制黄灯的继电器触点状态", strProcedureName);

                    yellowStatus = yellow;

                    data[9] = 0x11;
                    SetLightCmdWithStatus(ref data, yellow);

                    clientSocket.Send(data, data.Length, SocketFlags.None);
                    Thread.Sleep(50);
                }

                if (green != greenStatus)
                {
                    WriteLog.Instance.Write("发送控制绿灯的继电器触点状态", strProcedureName);

                    greenStatus = green;

                    data[9] = 0x12;
                    SetLightCmdWithStatus(ref data, green);

                    clientSocket.Send(data, data.Length, SocketFlags.None);
                    Thread.Sleep(50);
                }
            }
        }
    }
}
