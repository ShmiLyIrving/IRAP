using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Threading;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.MDC.Service
{
    public class TTCPServer
    {
        private static TTCPServer _instance = null;

        private bool running = false;
        private TcpListener listener = null;

        public static TTCPServer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TTCPServer();
                return _instance;
            }
        }


        /// <summary>
        /// 是否继续在服务端口进行侦听
        /// </summary>
        private bool continueListen = true;
        /// <summary>
        /// 在册测量仪表清单
        /// </summary>
        private List<RegInstrument> instruments = new List<RegInstrument>();

        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private TTCPServer() { }

        private void Run()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, TSysParams.Instance.ListenPort);
                listener = new TcpListener(ipEndPoint);
                listener.Start();
                WriteLog.Instance.Write(
                    string.Format(
                        "TCP 服务在 [{0}] 端口开始侦听......",
                        TSysParams.Instance.ListenPort),
                    strProcedureName);

                running = true;
                while (running)
                {
                    try
                    {
                        TcpClient connection = listener.AcceptTcpClient();
                        WriteLog.Instance.Write(
                            string.Format(
                                "收到来自 [{0}] 的连接请求",
                                connection.Client.RemoteEndPoint.ToString()),
                            strProcedureName);

                        ClientHandler handler = new ClientHandler(connection);
                        handler.StartRead();
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(
                            string.Format("运行时错误：[{0}]", error.Message),
                            strProcedureName);
                    }
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(
                    string.Format("运行时错误：[{0}]", error.Message),
                    strProcedureName);
            }
            finally
            {
                listener.Stop();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void ThreadRun()
        {
            Thread tcpServer = new Thread(new ThreadStart(Run));
            tcpServer.IsBackground = true;
            tcpServer.Start();
        }

        public void Stop()
        {
            running = false;
        }
    }
}
