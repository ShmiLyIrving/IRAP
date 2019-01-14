using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketClient
{
    class Program
    {
        //private static Socket clientSocket;

        static void Main(string[] args)
        {
            //IPHostEntry hostInfo = Dns.GetHostEntry(@"irap.vicp.net");
            //IPAddress[] ips = hostInfo.AddressList;
            ////IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.57.11"), 30000);
            //IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ips[0].ToString()), 40000);
            ////IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("114.222.29.177"), 40000);
            ////clientSocket = new Socket(ipep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //try
            //{
            //    //clientSocket.Connect(ipep);
            //    string outBufferStr;
            //    byte[] outBuffer = new byte[1024];
            //    byte[] inBuffer = new byte[1024];
            //    while (true)
            //    {
            //        outBufferStr = Console.ReadLine();
            //        outBuffer = Encoding.ASCII.GetBytes(outBufferStr);

            //        using (Socket client = new Socket(ipep.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
            //        {
            //            client.Connect(ipep);
            //            client.Send(outBuffer, outBuffer.Length, SocketFlags.None);
            //            client.Receive(inBuffer, SocketFlags.None);
            //            Console.WriteLine(Encoding.ASCII.GetString(inBuffer).Trim());
            //            client.Shutdown(SocketShutdown.Both);
            //            client.Close();
            //        }
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("服务未开启！");
            //    Console.ReadLine();
            //}

            #region 根据对象获取对象类名的测试
            TSampleClassA objA = new TSampleClassA();
            Console.WriteLine(objA.GetType().Name);
            Console.ReadLine();
            #endregion
        }
    }

    public class TCustomSampleClass
    {

    }

    public class TSampleClassA : TCustomSampleClass
    {

    }
}
