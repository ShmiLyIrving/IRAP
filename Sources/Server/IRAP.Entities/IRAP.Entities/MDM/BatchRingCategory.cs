using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    public class BatchRingCategory
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 活塞环类别叶标识
        /// </summary>
        public int T131LeafID { get; set; }
        /// <summary>
        /// 活塞环类别代码
        /// </summary>
        public string T131Code { get; set; }
        /// <summary>
        /// 活塞环类别名称
        /// </summary>
        public string T131Name { get; set; }

        public override string ToString()
        {
            return T131Name;
        }

        public BatchRingCategory Clone()
        {
            return MemberwiseClone() as BatchRingCategory;
        }
    }
}
