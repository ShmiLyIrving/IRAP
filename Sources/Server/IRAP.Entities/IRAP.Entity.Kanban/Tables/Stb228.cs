using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entity.Kanban
{
    [Serializable()]
    [IRAPDB(TableName = "IRAP..stb228")]
    public class Stb228
    {
        [IRAPKey()]
        public long PartitioningKey { get; set; }
        [IRAPKey()]
        public string RefreshingType { get; set; }
        [IRAPKey()]
        public string HostName { get; set; }
    }
}