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
    public class Priority
    {
        public Priority(short idx,string name)
        {
            PriorityIndex = idx;
            PriorityName = name;
        }
        /// <summary>
        /// 计划优先级索引
        /// </summary>
        public short PriorityIndex;
        /// <summary>
        /// 计划优先级名称
        /// </summary>
        public string PriorityName;
        public override string ToString()
        {
            return PriorityName;
        }
    }
}
