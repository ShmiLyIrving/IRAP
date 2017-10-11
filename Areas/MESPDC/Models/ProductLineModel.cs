using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MESPDC.Areas.MESPDC.Models
{
    /// <summary>
    /// IRAPMDM..ufn_GetList_ProcessOfProductLine
    /// </summary>
    public class ProductLineModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        public int ProcessID { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
    }
}