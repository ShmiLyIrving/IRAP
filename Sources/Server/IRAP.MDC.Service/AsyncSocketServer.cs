using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Configuration;
using System.Reflection;

namespace IRAP.MDC.Service
{
    public class StateObject
    {
        // Client socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousSocketListener
    {
        /// <summary>
        /// Socket 服务侦听端口默认值
        /// </summary>
        private const int defaultListenPort = 30000;
        /// <summary>
        /// Socket 服务最大连接数默认值
        /// </summary>
        private const int defaultMaxConnection = 10;
        /// <summary>
        /// 通讯报文的最大长度默认值
        /// </summary>
        private const int defaultMaxBufferSize = 1024;
        /// <summary>
        /// Socket 服务侦听端口
        /// </summary>
        private int listenPort = defaultListenPort;
        /// <summary>
        /// Socket 服务最大连接数
        /// </summary>
        private int maxConnection = defaultMaxConnection;
        /// <summary>
        /// 通讯报文的最大长度
        /// </summary>
        private int maxBufferSize = defaultMaxBufferSize;

        /// <summary>
        /// TCP/IP SocketServer
        /// </summary>
        private Socket listener = null;
        /// <summary>
        /// 是否继续在服务端口进行侦听
        /// </summary>
        private bool continueListen = true;

        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;


        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public AsynchronousSocketListener()
        {
            WriteLog.Instance.WriteBeginSplitter(className);

            string temp = "";
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            temp = config.AppSettings.Settings["SocketListenPort"].Value;
            Int32.TryParse(temp, out listenPort);
            if (listenPort == 0)
                listenPort = defaultListenPort;

            temp = config.AppSettings.Settings["MaxConnection"].Value;
            Int32.TryParse(temp, out maxConnection);
            if (maxConnection == 0)
                maxConnection = defaultMaxConnection;

            if (config.AppSettings.Settings["MaxBufferSize"] != null)
            {
                temp = config.AppSettings.Settings["MaxBufferSize"].Value;
                Int32.TryParse(temp, out maxBufferSize);
            }
            if (maxBufferSize == 0)
                maxBufferSize = defaultMaxBufferSize;
        }

        ~AsynchronousSocketListener()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (listener != null)
            {
                WriteLog.Instance.WriteEndSplitter(className);
                WriteLog.Instance.Write("");

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }

        public void Start()
        {
            Thread server = new Thread(new ThreadStart(StartListening));
            server.Start();
        }

        public void Stop()
        {
            continueListen = false;
            allDone.Set();
        }

        private void StartListening()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            // Data buffer for incoming data.
            byte[] bytes = new byte[maxBufferSize];

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, listenPort);

            // Create a TCP/IP socket.
            listener =
                new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(maxConnection);

                while (continueListen)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    WriteLog.Instance.Write("Waiting for a connection...", strProcedureName);
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing
                    allDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                WriteLog.Instance.Write(e.Message);
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(
                state.buffer,
                0,
                StateObject.BufferSize,
                0,
                new AsyncCallback(ReadCallback),
                state);
        }

        public void ReadCallback(IAsyncResult ar)
        {
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);
            string content = string.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.
                state.sb.Append(
                    Encoding.ASCII.GetString(
                        state.buffer,
                        0,
                        bytesRead));

                //content = state.sb.ToString();
                content = Encoding.ASCII.GetString(
                        state.buffer,
                        0,
                        bytesRead);

                Console.WriteLine(
                        "Read {0} bytes from socket [{1}].\nData:{2}",
                        content.Length,
                        handler.RemoteEndPoint.ToString(),
                        content);
                WriteLog.Instance.Write(
                    string.Format(
                        "Read {0} bytes from socket [{1}].Data:{2}",
                        content.Length,
                        handler.RemoteEndPoint.ToString(),
                        content),
                    strProcedureName);

                RecordData record = new RecordData(handler.RemoteEndPoint.ToString(), content);
                if (record.DataValid())
                {
                    #region 处理收到的数据
                    Thread dataRecording = new Thread(new ThreadStart(record.Record));
                    dataRecording.Start();
                    #endregion

                    // Echo the data back to the client.
                    Send(handler, "OK");
                }
                else
                {
                    Send(handler, "FALSE");
                }

                handler.BeginReceive(
                    state.buffer,
                    0,
                    StateObject.BufferSize,
                    0,
                    new AsyncCallback(ReadCallback),
                    state);
            }
        }

        private void Send(Socket handler, string data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            handler.BeginSend(
                byteData,
                0,
                byteData.Length,
                0,
                new AsyncCallback(SendCallback),
                handler);
        }

        private void SendCallback(IAsyncResult ar)
        {
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);

            try
            {
                // Retreive the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);
                WriteLog.Instance.Write(
                    string.Format(
                        "Sent {0} bytes to client [{1}].",
                        bytesSent,
                        handler.RemoteEndPoint.ToString()),
                    strProcedureName);

                //handler.Shutdown(SocketShutdown.Both);
                //handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                WriteLog.Instance.Write(e.Message, strProcedureName);
            }
        }
    }
}
