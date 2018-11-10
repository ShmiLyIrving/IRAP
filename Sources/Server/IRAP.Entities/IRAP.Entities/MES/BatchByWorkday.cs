using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class BatchByWorkday
    {
        /// <summary>
        /// 热定型容次号
        /// </summary>
        /// <returns></returns>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 生产开始时间
        /// </summary>
        public string BatchStartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string BatchEndDate { get; set; }

        public override string ToString()
        {
            return BatchNumber;
        }

        public BatchByWorkday Clone()
        {
            return MemberwiseClone() as BatchByWorkday;
        }
    }
}
