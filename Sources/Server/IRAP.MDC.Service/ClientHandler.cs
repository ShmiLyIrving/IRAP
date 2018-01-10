using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;

using IRAP.Global;

namespace IRAP.MDC.Service
{
    internal class ClientHandler
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private TcpClient connection = null;
        private NetworkStream stream = null;

        public ClientHandler(TcpClient connection)
        {
            this.connection = connection;
            stream = this.connection.GetStream();
        }

        ~ClientHandler()
        {
            stream.Close();
        }

        private void SendResponse(string response)
        {
            byte[] sendMSG = Encoding.ASCII.GetBytes(response);
            stream.Write(sendMSG, 0, sendMSG.Length);
        }

        public void StartRead()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int readSize = 0;
                byte[] buffer = new byte[11];

                stream.ReadTimeout = 100;
                readSize = stream.Read(buffer, 0, 11);
                if (readSize == 0)
                {
                    WriteLog.Instance.Write("未收到数据", strProcedureName);
                    SendResponse("FALSE");
                    return;
                }

                #region 整理收到的通讯数据，去除不可见字符
                List<byte> temp = new List<byte>();
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] >= 32 && buffer[i] <= 126)
                        temp.Add(buffer[i]);
                    else
                        break;
                }
                #endregion

                string content = Encoding.ASCII.GetString(temp.ToArray());
                WriteLog.Instance.Write(
                    string.Format(
                        "从 [{0}] 读取到 [{1}] 字节，内容： [{2}]",
                        connection.Client.RemoteEndPoint.ToString(),
                        content.Length,
                        content),
                    strProcedureName);

                RecordData record =
                    new RecordData(
                        connection.Client.RemoteEndPoint.ToString(),
                        content);
                if (record.DataValid())
                {
                    #region 处理收到的数据
                    Thread dataRecording = new Thread(new ThreadStart(record.Record));
                    dataRecording.Start();
                    #endregion

                    SendResponse("OK");
                }
                else
                    SendResponse("FALSE");
            }
            catch (Exception error)
            {
                SendResponse("FALSE");
                WriteLog.Instance.Write(error.Message, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
