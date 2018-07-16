// 文 件 名：Plan.cs
// 功能描述：自动运行实体
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.Model
{
    /// <summary>
    /// 计划实体
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// 计划ID
        /// </summary>
        public int PlanID { get; set; }
        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime? BizTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectID { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string InCharge { get; set; }
        /// <summary>
        /// 协作人
        /// </summary>
        public string CoCharge { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        public short Priority { get; set; }
        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? PlanStart { get; set; }
        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime? PlanEnd { get; set; }
        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? ActualStart { get; set; }
        /// <summary>
        /// 实际结束时间
        /// </summary>
        public DateTime? ActualEnd { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        public short Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 变更次数
        /// </summary>
        public short ChangeCount { get; set; }
        /// <summary>
        /// 是否已检查
        /// </summary>
        public int Checked { get; set; }
        /// <summary>
        /// 难度系数
        /// </summary>
        public float HardRate { get; set; }
        /// <summary>
        /// 依赖项
        /// </summary>
        public int DependOn { get; set; }
        /// <summary>
        /// 花费时间
        /// </summary>
        public int CostMinutes { get; set; }
    }
}
