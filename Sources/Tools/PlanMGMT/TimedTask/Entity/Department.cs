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
    public class Department
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public int deptid { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string deptname { get; set;}
        public override string ToString()
        {
            return deptname;
        }
    }
}
