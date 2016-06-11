using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.SSO
{
    public class EntityCIDInfo
    {
        public int Validity { get; set; }
        public int Sex { get; set; }
        public DateTime Birthday { get; set; }

        public EntityCIDInfo Clone()
        {
            return MemberwiseClone() as EntityCIDInfo;
        }
    }
}
