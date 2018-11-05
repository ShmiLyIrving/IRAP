using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.BL.OPCGateway.Global
{
    public class TKepwareServers
    {
        private static TKepwareServers _intance = null;

        private Entities.TKepwareServerCollection servers =
            new Entities.TKepwareServerCollection();

        private TKepwareServers() { }

        public static TKepwareServers Instance
        {
            get
            {
                if (_intance == null)
                    _intance = new TKepwareServers();
                return _intance;
            }
        }

        public Entities.TKepwareServerCollection Servers
        {
            get { return servers; }
        }
    }
}
