using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.MDM
{
    public class FailureModeByWorkUnit
    {
        public FailureModeByWorkUnit()
        {
            Qty = 0;
        }

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 报废代码叶标识
        /// </summary>
        public int T118LeafID { get; set; }
        /// <summary>
        /// 报废代码标识
        /// </summary>
        public int T118EntityID { get; set; }
        /// <summary>
        /// 报废代码
        /// </summary>
        public string T118Code { get; set; }
        /// <summary>
        /// 报废代码
        /// </summary>
        public string T118NodeName { get; set; }

        /// <summary>
        /// 报废数量
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public long Qty { get; set; }

        public FailureModeByWorkUnit Clone()
        {
            return MemberwiseClone() as FailureModeByWorkUnit;
        }

        public override string ToString()
        {
            return string.Format("[{0}]{1}", T118Code, T118NodeName);
        }
    }
}
