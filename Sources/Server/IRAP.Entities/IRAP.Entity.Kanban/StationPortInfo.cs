using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class StationPortInfo
    {
        public string WorkUnitName { get; set; }
        public string WorkUnitCode { get; set; }
        public int WorkUnitLeaf { get; set; }
        public int StopBits { get; set; }
        public int Parity { get; set; }
        public int ByteSize { get; set; }
        public int BoudRate { get; set; }
        public string CommPort { get; set; }
        public bool IsComm { get; set; }
        public int Ordinal { get; set; }

        public StationPortInfo Clone()
        {
            StationPortInfo rlt = MemberwiseClone() as StationPortInfo;

            return rlt;
        }
    }
}