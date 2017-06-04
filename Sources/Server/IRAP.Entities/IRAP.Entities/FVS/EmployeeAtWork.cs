using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.FVS
{
    public class EmployeeAtWork
    {
        /// <summary>
        /// 员工工号
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 签到时间
        /// </summary>
        public string QdTime { get; set; }

        public EmployeeAtWork Clone()
        {
            return MemberwiseClone() as EmployeeAtWork;
        }
    }
}
