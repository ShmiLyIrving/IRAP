using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.WebAPI.Entities.IRAP
{
    /// <summary>
    /// 万能表单存储过程响应报文类
    /// </summary>
    public class TRespUDFForm
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        public string ExCode { get; set; }
        /// <summary>
        /// Action 执行 XML 字符串
        /// </summary>
        public string OutputStr { get; set; }
    }
}
