using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entity.MDM.Tables
{
    [Serializable()]
    [IRAPDB(TableName = "IRAPMDM..stb058")]
    public class Stb058
    {
        [IRAPKey()]
        public long PartitioningKey { get; set; }
        public int TreeID { get; set; }
        [IRAPKey()]
        public int LeafID { get; set; }
        public int NameID { get; set; }
        public string NodeName { get; set; }
        public int Father { get; set; }
        public double UDFOrdinal { get; set; }
        public int NodeDepth { get; set; }
        public int LeafStatus { get; set; }
        public int CSTRoot { get; set; }
        public int IconID { get; set; }
        public int EntityID { get; set; }
        public string Code { get; set; }
        public string AlternateCode { get; set; }
        public DateTime CreatedTime { get; set; }

        public Stb058 Clone()
        {
            return MemberwiseClone() as Stb058;
        }
    }
}