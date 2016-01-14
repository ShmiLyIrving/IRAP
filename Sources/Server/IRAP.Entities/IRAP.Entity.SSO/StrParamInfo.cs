using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.SSO
{
    /// <summary>
    /// 全局参数
    /// </summary>
    public class StrParamInfo
    {
        /// <summary>
        /// 参数标识
        /// </summary>
        public int ParameterID { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// 字符串参数值
        /// </summary>
        public string ParameterValue { get; set; }
        /// <summary>
        /// 最后设置者(用户代码)
        /// </summary>
        public string UpdatedBy { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime TimeUpdated { get; set; }

        public StrParamInfo Clone()
        {
            return this.MemberwiseClone() as StrParamInfo;
        }
    }
}
