using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.DBUtility
{
    public enum TEffentNextType
    {
        /// <summary>
        /// 对其它语句无任何影响
        /// </summary>
        None,
        /// <summary>
        /// 当前语句必须为 “SELECT COUNT(1) FROM ..." 格式，如果存在则继续执行，不存在则回滚事务
        /// </summary>
        WhenHaveContinue,
        /// <summary>
        /// 当前语句必须为 “SELECT COUNT(1) FROM ..." 格式，如果不存在则继续执行，存在则回滚事务
        /// </summary>
        WhenNoHaveContinue,
        /// <summary>
        /// 当前语句影响到的行数必须大于 0，否则回滚事务
        /// </summary>
        ExecuteEffectRows,
        /// <summary>
        /// 引发事件：当前语句必须为 "SELECT COUNT(1) FROM ..." 格式，如果不存在则继续执行，存在则回滚事务
        /// </summary>
        SolicitationEvent
    }
}
