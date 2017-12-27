using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace IRAP.WebAPI.Enums
{
    /// <summary>
    /// 报文类别枚举类型
    /// </summary>
    [Flags()]
    public enum TContentType
    {
        /// <summary>
        /// JSON 格式的报文
        /// </summary>
        [Description("JSON 格式的报文")]
        JSON = 1,
        /// <summary>
        /// XML 格式的报文
        /// </summary>
        [Description("XML 格式的报文")]
        XML
    }
}
