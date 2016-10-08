using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 操作工技能矩阵
    /// </summary>
    public class OperatorSkillMatrix
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }
        /// <summary>
        /// 工序代码
        /// </summary>
        public string T216Code { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string T216Name { get; set; }
        /// <summary>
        /// 员工工号
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 是否线长/拉长/班长
        /// </summary>
        public bool IsTeamLeader { get; set; }
        /// <summary>
        /// 资质等级
        /// 1=优秀(绿卡) 2=合格(黄卡) 3=培训(红卡)
        /// </summary>
        public int QualificationLevel { get; set; }
        /// <summary>
        /// 是否在岗(在本产线签到未签退)
        /// </summary>
        public bool IsOnLine { get; set; }

        public OperatorSkillMatrix Clone()
        {
            return MemberwiseClone() as OperatorSkillMatrix;
        }
    }
}