using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OPCAutomation;

namespace IRAP.BL.OPCGateway.Global.Entities
{
    public class TKepwareServer
    {
        private string address = "";
        private string name = "";
        TKepwareDeviceCollection devices =
            new TKepwareDeviceCollection();

        OPCServer server = new OPCServer();

        public TKepwareServer(string address, string name)
        {
            try
            {
                server.Connect(name, address);
            }
            catch (Exception error)
            {
                Exception err =
                    new Exception(
                        $"无法连接到KEPServer[{name}({address})]，[{error.Message}]");
                err.Data.Add("ErrCode", 900103);
                err.Data.Add("ErrText", err.Message);
                throw err;
            }

            this.address = address;
            this.name = name;

            OPCBrowser browser = server.CreateBrowser();
            browser.ShowBranches();
            browser.ShowLeafs(true);

            foreach (object tag in browser)
            {
                devices.Add(
                    address,
                    name,
                    tag.ToString());
            }
        }

        ~TKepwareServer()
        {
            if (server != null)
            {
                server.Disconnect();
                server = null;
            }
        }

        public string Address { get { return address; } }
        public string Name { get { return name; } }
        public TKepwareDeviceCollection Devices { get { return devices; } }
    }
}
