using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 工段信息
    /// </summary>
    public class ProcessSegment
    {
        public int Ordinal { get; set; }
        public int T124LeafID { get; set; }
        public string T124NodeName { get; set; }
        public string T124Code { get; set; }

        public ProcessSegment Clone()
        {
            return MemberwiseClone() as ProcessSegment;
        }
    }
}