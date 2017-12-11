using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using IRAP.BL.OPCGateway;
using IRAP.OPC.Entity;
using IRAP.OPC.Library;

namespace IRAPOPCGatewayHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ServiceHost _host = new ServiceHost(typeof(OPCGatewayService));
                //_host.Open();

                //TKepServerListener kepServer = new TKepServerListener();
                //kepServer.Init("127.0.0.1", "Kepware.KEPServerEX.V5");

                //Console.WriteLine("IRAP-OPC 服务网关已启动");

                TOPCGatewayServiceControl.Instance.Start();

                bool quitSystem = false;
                do
                {
                    Console.WriteLine("按 <Q> 健退出服务");
                    string cmd = Console.ReadLine();
                    switch (cmd.ToUpper())
                    {
                        case "Q":
                            quitSystem = true;
                            break;
                        case "EDIT":
                            //kepServer.WriteTagValue("Channel1.Device1.COMPOS_02", "true");
                            break;
                        case "NEWDEVICE":
                            TIRAPOPCDevice device = new TIRAPOPCDevice()
                            {
                                DeviceCode = "10010",
                                KepServerAddr = "127.0.0.1",
                                KepServerName = "KepServer.KEPServerEX.V5",
                            };
                            TIRAPOPCDevices.Instance.Save(
                                device,
                                string.Format(
                                    "{0}IRAP.BL.OPCGateway.xml",
                                    AppDomain.CurrentDomain.BaseDirectory));
                            break;
                    }
                    Console.WriteLine("");
                } while (!quitSystem);

                TOPCGatewayServiceControl.Instance.Stop();
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
