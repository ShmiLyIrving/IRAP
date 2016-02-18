using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class EntityProductLine
    {
        public int PartitioningKey { get; set; }
        public int T134LeafID { get; set; }
        public int T134EntityID { get; set; }
        public string T134Code { get; set; }
        public string T134AltCode { get; set; }
        public string T134NodeName { get; set; }

        public EntityProductLine Clone()
        {
            EntityProductLine rlt = MemberwiseClone() as EntityProductLine;

            return rlt;
        }
    }
}