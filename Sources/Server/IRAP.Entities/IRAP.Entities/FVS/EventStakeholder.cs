using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.FVS
{
    public class EventStakeholder
    {
        /// <summary>
        /// 安灯事件标识
        /// </summary>
        public long EventFactID { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string AgencyName { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 干系人工号
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 干系人姓名
        /// </summary>
        public string UserName { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public bool Choice { get; set; }

        public EventStakeholder Clone()
        {
            return MemberwiseClone() as EventStakeholder;
        }
    }
}
