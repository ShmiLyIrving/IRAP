using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.WebAPI.Entities
{
    /// <summary>
    /// IRAP 标准请求报文类
    /// </summary>
    public class TIRAPCustomRequestContent
    {
        /// <summary>
        /// 社区标识
        /// </summary>
        public int CommunityID { get; set; }
        /// <summary>
        /// 系统登录标识
        /// </summary>
        public long SysLogID { get; set; }
    }
}
