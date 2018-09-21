using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using IRAPGeneralGateway;
using IRAPGeneralGateway.Entities;

namespace IRAPGeneralGatewayConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 加载配置文件中的交易代码配置信息列表
                TExCodes.Instance.Load(TIRAPWebAPIGlobal.Instance.ConfigurationFile);
                // 加载配置文件中的注册客户端配置信息列表
                TRegistClients.Instance.Load(TIRAPWebAPIGlobal.Instance.ConfigurationFile);

                ServiceHost _host = new ServiceHost(typeof(TIRAPGeneralWebAPIService));

                _host.Open();

                Console.WriteLine("服务已启动......");
                Console.ReadLine();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                Console.ReadLine();
            }
        }
    }
}
