using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entity.IRAP
{
    [Serializable()]
    [IRAPDB(TableName ="IRAP..stb052")]
    public class Stb052
    {
        [IRAPKey()]
        public long PartitioningKey { get; set; }
        public int TreeID { get; set; }
        [IRAPKey()]
        public int NodeID { get; set; }
        public string Code { get; set; }
        public int NameID { get; set; }
        public string NodeName { get; set; }
        public int Father { get; set; }
        public double UDFOrdinal { get; set; }
        public int NodeDepth { get; set; }
        public int NodeStatus { get; set; }
        public int CSTRoot { get; set; }
        public int IconID { get; set; }

        public Stb052 Clone()
        {
            return MemberwiseClone() as Stb052;
        }
    }
}