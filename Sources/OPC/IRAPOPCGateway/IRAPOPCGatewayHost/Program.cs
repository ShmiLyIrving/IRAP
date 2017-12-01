using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using IRAP.BL.OPCGateway;

namespace IRAPOPCGatewayHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost _host = new ServiceHost(typeof(OPCGatewayService));
                _host.Open();
                Console.WriteLine("IRAP-OPC 服务网关已启动");
                Console.WriteLine("按 <Enter> 健退出服务");
                Console.ReadLine();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                Console.WriteLine(error.StackTrace);
                Console.WriteLine("按 <Enter> 健退出服务");
                Console.ReadLine();
            }
        }
    }
}
