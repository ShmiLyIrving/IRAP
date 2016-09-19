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
        /// <summary>
        /// 串口通讯中的停止位：
        /// 0 - 不使用停止位（不支持）；
        /// 1 - 使用 1 个停止位；
        /// 2 - 使用 2 个停止位；
        /// 3 - 使用1.5个停止位；
        /// </summary>
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