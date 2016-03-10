using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 未结生产工单
    /// </summary>
    public class OpenProductionWorkOrder
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工单签发事实编号
        /// </summary>
        public long PWOIssuingFactID { get; set; }
        /// <summary>
        /// 工单签发事实分区键
        /// </summary>
        public long TF482PK { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产线叶标识
        /// </summary>
        public int T134LeafID { get; set; }
        /// <summary>
        /// 生产工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 制造订单号
        /// </summary>
        public string MONumber { get; set; }
        /// <summary>
        /// 制造订单行号
        /// </summary>
        public int MOLineNo { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public long OrderQty { get; set; }
        /// <summary>
        /// 排定生产时间
        /// </summary>
        public string ScheduledStartTime { get; set; }
        /// <summary>
        /// 在制品容器号
        /// </summary>
        public string ContainerNo { get; set; }
        /// <summary>
        /// 生产工单状态
        /// </summary>
        public int PWOStatus { get; set; }

        public OpenProductionWorkOrder Clone()
        {
            OpenProductionWorkOrder rlt = MemberwiseClone() as OpenProductionWorkOrder;

            return rlt;
        }
    }
}