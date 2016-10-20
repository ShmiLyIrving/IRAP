using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 用于监视器的 KPI 指标名
    /// </summary>
    public class KPIToMonitor
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// KPI 指标名
        /// </summary>
        public string KPIName { get; set; }

        public KPIToMonitor Clone()
        {
            return MemberwiseClone() as KPIToMonitor;
        }
    }
}