using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class TrendFTTofAPWO
    {
        /// <summary>
        /// 序号
        /// </summary>{get;set;}
        public int Ordinal { get; set; }
        /// <summary>
        /// 班次第Ordinal个工作小时中点(hh:mm)
        /// </summary>
        /// <returns></returns>
        public string WorkingHourMiddleTime { get; set; }
        /// <summary>
        /// 一次性通过率(%)
        /// </summary>
        public decimal FTTRate { get; set; }
        /// <summary>
        /// 一次性通过率目标值
        /// </summary>
        public decimal FTTTarget { get; set; }
        /// <summary>
        /// 小时期间开始
        /// </summary>
        public DateTime BeginDT { get; set; }
        /// <summary>
        /// 小时期间结束
        /// </summary>
        public DateTime EndDT { get; set; }
        /// <summary>
        /// 小时期间开始UnixTime
        /// </summary>
        public int BeginUnixTime { get; set; }
        /// <summary>
        /// 小时期间结束UnixTime
        /// </summary>
        public int EndUnixTime { get; set; }

        public TrendFTTofAPWO Clone()
        {
            return MemberwiseClone() as TrendFTTofAPWO;
        }
    }
}