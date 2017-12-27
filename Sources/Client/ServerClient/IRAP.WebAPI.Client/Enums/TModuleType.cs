using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace IRAP.WebAPI.Enums
{
    /// <summary>
    /// 模块类别枚举类型
    /// </summary>
    [Flags()]
    public enum TModuleType
    {
        /// <summary>
        /// 授权认证类别
        /// </summary>
        [Description("授权认证类别")]
        OpenAuth = 1,
        /// <summary>
        /// 数据交换类别
        /// </summary>
        [Description("数据交换类别")]
        Exchange,
    }
}
