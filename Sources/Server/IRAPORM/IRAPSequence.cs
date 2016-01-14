using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace IRAPORM
{
        public class IRAPSequence
        {
            public static Int64 GetSequenceNo(string ipAddress, string sequenceName, Int64 count)
            {
                byte[] data = new byte[128];
                Socket newclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //newclient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                string ipadd = ipAddress;
                int port = Convert.ToInt32("13000");
                IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipadd), port);//服务器的IP和端口
                string sendcommand;
                try
                {
                    newclient.Connect(ie);
                    sendcommand = string.Format("{0}|{1}", sequenceName, count.ToString());
                    newclient.Send(Encoding.ASCII.GetBytes(sendcommand));
                    int recv = newclient.Receive(data);
                    String TransactNostr = Encoding.ASCII.GetString(data, 0, recv);
                    newclient.Close();
                    // System.GC.Collect();
                    return Int64.Parse(TransactNostr);
                }
                catch (SocketException e)
                {
                    // Console.WriteLine("unable to connect to server");
                    // Console.WriteLine(e.ToString());
                    newclient.Close();
                    return -1;
                }
            }
        }
    }