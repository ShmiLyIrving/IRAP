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
    public class WorkLog
    {
        public WorkLog(string d,string t)
        {
            Daily = d;
            TomorrowDaily = t;
        }
        /// <summary>
        /// 今日工作内容
        /// </summary>
        public string Daily { get; set; }
        /// <summary>
        ///明日工作计划
        /// </summary>
        public string TomorrowDaily { get; set; }
    }
}
