using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.FVS
{
    public class AndonCancelReason
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 撤销原因
        /// </summary>
        public string CancelReason { get; set; }

        public AndonCancelReason Clone()
        {
            return MemberwiseClone() as AndonCancelReason;
        }

        public override string ToString()
        {
            return CancelReason;
        }
    }
}
