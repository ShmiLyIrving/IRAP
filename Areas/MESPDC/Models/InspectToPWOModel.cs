using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MESPDC.Areas.MESPDC.Models
{
    /// <summary>
    /// IRAPMES..ufn_GetFactList_InspectToPWO
    /// </summary>
    public class InspectToPWOModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 工单状态（int）
        /// </summary>
        public int PWOStatus { get; set; }
        /// <summary>
        /// 工单状态名称
        /// </summary>
        public string PWOStatusStr { get; set; }
    }
}