using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace IRAP.BL.OPCGateway
{
    internal class TOPCGatewayGlobal
    {
        private static TOPCGatewayGlobal _instance = null;

        public static TOPCGatewayGlobal Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TOPCGatewayGlobal();
                return _instance;
            }
        }

        private TOPCGatewayGlobal()
        {
            configurationFile = 
                string.Format(
                    "{0}.xml",
                    Assembly.GetCallingAssembly().Location.Replace(".dll", ""));
        }

        private string configurationFile = "";

        public string ConfigurationFile { get { return configurationFile; } }
    }
}
