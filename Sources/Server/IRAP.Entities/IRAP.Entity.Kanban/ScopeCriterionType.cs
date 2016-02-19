using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    /// <summary>
    /// 比较类型
    /// </summary>
    public class ScopeCriterionType
    {
        /// <summary>
        /// 序列
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 类型编码
        /// </summary>
        public string TypeCode { get; set; }
        /// <summary>
        /// 类型示意
        /// </summary>
        public string TypeHint { get; set; }

        public ScopeCriterionType Clone()
        {
            ScopeCriterionType rlt = MemberwiseClone() as ScopeCriterionType;

            return rlt;
        }
    }
}