using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class AndonEventKanbanQCR
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
        /// 失效代码
        /// </summary>
        public string FailureCode { get; set; }
        /// <summary>
        /// 失效名称
        /// </summary>
        public string FailureName { get; set; }
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

        public AndonEventKanbanQCR Clone()
        {
            AndonEventKanbanQCR rlt = MemberwiseClone() as AndonEventKanbanQCR;

            return rlt;
        }
    }
}