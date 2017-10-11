using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MESPDC.Areas.MESPDC.Models
{
    /// <summary>
    /// IRAPMES..ufn_GetList_InspectTypeOfProcess
    /// </summary>
    public class InspectTypeModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 检验类型
        /// </summary>
        public int InspectType { get; set; }
        /// <summary>
        /// 检验名称
        /// </summary>
        public string InspectName { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public int IsValid { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string  ColorStatus { get; set; }
        /// <summary>
        /// 调用函数名称
        /// </summary>
        public string FuncName { get; set; }
    }
}