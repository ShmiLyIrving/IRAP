using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Kanban
{
    /// <summary>
    /// 时间期间类型
    /// </summary>
    public class PeriodType
    {
        /// <summary>
        /// 期间类型标识
        /// </summary>
        public int PeriodTypeID { get; set; }
        /// <summary>
        /// 期间类型代码
        /// </summary>
        public string PeriodTypeCode { get; set; }
        /// <summary>
        /// 期间类型名称
        /// </summary>
        public string PeriodTypeName { get; set; }

        public PeriodType Clone()
        {
            PeriodType rlt = MemberwiseClone() as PeriodType;

            return rlt;
        }

        public override string ToString()
        {
            return PeriodTypeName;
        }
    }
}