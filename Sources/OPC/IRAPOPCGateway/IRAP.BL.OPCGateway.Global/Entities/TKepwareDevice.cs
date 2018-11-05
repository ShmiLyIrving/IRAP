using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;

namespace IRAP.BL.OPCGateway.Global.Entities
{
    public class TKepwareDevice
    {
        private TKepwareTagCollection items =
            new TKepwareTagCollection();

        public string KepServAddr { get; set; }
        public string KepServName { get; set; }
        public string KepServChannel { get; set; }
        public string KepServDevice { get; set; }
        public TKepwareTagCollection Tags { get { return items; } }
    }
}
