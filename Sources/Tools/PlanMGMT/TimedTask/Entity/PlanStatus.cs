// 文 件 名：Department.cs
// 功能描述：自动运行实体
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.Entity
{
    public class PlanStatus
    {
        public PlanStatus(short idx,string name)
        {
            StatusIndex = idx;
            StatusName = name;
        }
        /// <summary>
        /// 计划状态索引
        /// </summary>
        public short StatusIndex { get; set; }
        /// <summary>
        /// 计划状态名称
        /// </summary>
        public string StatusName { get; set; }
        public override string ToString()
        {
            return StatusName;
        }
    }
}
