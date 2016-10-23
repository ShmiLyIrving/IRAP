using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class Dashboard_KPI
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 资源类型（134-产线 211-工作中心）
        /// </summary>
        public int ResourceTreeID { get; set; }
        /// <summary>
        /// 资源叶标识
        /// </summary>
        public int ResourceLeafID { get; set; }
        /// <summary>
        /// 资源代码（产线代码/工作中心代码）
        /// </summary>
        public string ResourceCode { get; set; }
        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceName { get; set; }
        /// <summary>
        /// OEE目标值
        /// </summary>
        public decimal TargetKPIValue { get; set; }
        /// <summary>
        /// 当前OEE值(本工作日开始以来)
        /// </summary>
        public decimal CurrentKPIValue { get; set; }
        /// <summary>
        /// KPI状态(0-未生产[灰色];1-正常[绿色];2-告警[黄色];3-异常[红色]
        /// </summary>
        public int KPIStatus { get; set; }

        public Dashboard_KPI Clone()
        {
            return MemberwiseClone() as Dashboard_KPI;
        }
    }
}