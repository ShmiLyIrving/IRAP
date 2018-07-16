using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanMGMT.Model
{
    public class Area
    {
        public int ID { get; set; }
        public int ZoneID { get; set; }
        public string AreaCode { get; set; }
        public string Name { get; set; }
    }
    public class Zone //: ModelBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
