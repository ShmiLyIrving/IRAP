// 文 件 名：Project.cs
// 功能描述：自动运行实体
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.Model
{
    public class Project
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 项目状态
        /// </summary>
        public short Status { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string InCharge { get; set; }
        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? PlanStartTime { get; set; }
        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime? PlanEndTime { get; set; }
        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? ActualStartTime { get; set; }
        /// <summary>
        /// 实际结束时间
        /// </summary>
        public DateTime? ActualEndTime { get; set; }
        /// <summary>
        /// 项目分类
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 项目大小
        /// </summary>
        public decimal ProjectAmount { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// 客户联系人
        /// </summary>
        public string CustomerPM { get; set; }
        public override string ToString()
        {
            return ProjectName;
        }
    }
}
