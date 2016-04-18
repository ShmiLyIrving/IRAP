using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entity.Kanban
{
    public class LeafSetEx
    {
        /// <summary>
        /// 叶标识
        /// </summary>
        public int LeafID { get; set; }

        /// <summary>
        /// 实体标识
        /// </summary>
        public int EntityID { get; set; }

        /// <summary>
        /// 实体代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 实体名称
        /// </summary>
        public string LeafName { get; set; }

        /// <summary>
        /// 叶状态
        /// </summary>
        public int LeafStatus { get; set; }

        /// <summary>
        /// 分区键
        /// </summary>
        public long PartitioningKey { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public string CodeAndName
        {
            get
            {
                if (Code.Trim() == "")
                    return LeafName;
                else
                    return string.Format("[{0}]{1}", Code, LeafName);
            }
        }

        public override string ToString()
        {
            return CodeAndName;
        }

        public LeafSetEx Clone()
        {
            return MemberwiseClone() as LeafSetEx;
        }
    }

    public class LeafSetEx_ComparerByLeafID : IComparer<LeafSetEx>
    {
        public int Compare(LeafSetEx x, LeafSetEx y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    return x.LeafID.CompareTo(y.LeafID);
                }
            }
        }
    }
}