using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class AndonEventKanbanMDR
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 事件事实编号
        /// </summary>
        public long FactID { get; set; }
        /// <summary>
        /// 呼叫时间
        /// </summary>
        public string CallingTime { get; set; }
        /// <summary>
        /// 产线代码
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 产线名称
        /// </summary>
        public string LineName { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 需求数量
        /// </summary>
        public long QtyRequired { get; set; }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int QtyScale { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }
        /// <summary>
        /// 是否已停产
        /// </summary>
        public string ProductionStatus { get; set; }
        /// <summary>
        /// 责任团队
        /// </summary>
        public string ResponsibleTeamName { get; set; }
        /// <summary>
        /// 是否已响应
        /// </summary>
        public string RespondingStatus { get; set; }
        /// <summary>
        /// 已过时间（分钟）
        /// </summary>
        public int ElapsedTimeInMinutes { get; set; }

        public AndonEventKanbanMDR Clone()
        {
            AndonEventKanbanMDR rlt = MemberwiseClone() as AndonEventKanbanMDR;

            return rlt;
        }
    }
}