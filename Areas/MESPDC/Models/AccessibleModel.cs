using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MESPDC.Areas.MESPDC.Models
{
    /// <summary>
    /// IRAP..sfn_AccessibleLeafSetEx  产线
    /// </summary>
    public class AccessibleModel
    {
        /// <summary>
        /// 分区键
        /// </summary>
        public Int64 PartitioningKey { get; set; }
        /// <summary>
        /// 叶标识
        /// </summary>
        public int LeafID { get; set; }
        /// <summary>
        /// 实体标识
        /// </summary>
        public int EntityID { get; set; }
        /// <summary>
        /// 实体代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public string LeafName { get; set; }
        /// <summary>
        /// 叶状态
        /// </summary>
        public int LeafStatus { get; set; }

    }
    /// <summary>
    /// IRAPMES..ufn_GetList_InspectType
    /// </summary>
    public class InspectType_S_Model
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 检验类型名称
        /// </summary>
        public string InspectName { get; set; }
        /// <summary>
        /// 检验类型
        /// </summary>
        public int InspectType { get; set; }

    }
}