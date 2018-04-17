using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.SCES
{
    public class RMTransferForPWO
    {
        /// <summary>
        /// 排产事实编号
        /// </summary>
        public long FactID { get; set; }
        /// <summary>
        /// 制造订单号
        /// </summary>
        public string MONumber { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public int MOLineNo { get; set; }
        /// <summary>
        /// 生产工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductDesc { get; set; }
        /// <summary>
        /// 工单数量
        /// </summary>
        public long OrderQty { get; set; }
        /// <summary>
        /// 排定生产时间
        /// </summary>
        public string ScheduledStartTime { get; set; }
        /// <summary>
        /// 要求配送物料号
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 要求配送物料名称
        /// </summary>
        public string MaterialDesc { get; set; }
        /// <summary>
        /// 要求配送数量
        /// </summary>
        public long QtyToDeliver { get; set; }
        /// <summary>
        /// 要求送达时间
        /// </summary>
        public string RequestedArrivalTime { get; set; }
        /// <summary>
        /// 实际配送时间
        /// </summary>
        public string MaterialDeliverTime { get; set; }
        /// <summary>
        /// 实际送达时间
        /// </summary>
        public string ActualArrivalTime { get; set; }
        /// <summary>
        /// 实际配送数量
        /// </summary>
        public long QtyDelivered { get; set; }
        /// <summary>
        /// 配送人姓名
        /// </summary>
        public string Deliverer { get; set; }
        /// <summary>
        /// 准时配送状态（1=准时 2=不准时）
        /// </summary>
        public int OTDStatus { get; set; }

        public RMTransferForPWO Clone()
        {
            return MemberwiseClone() as RMTransferForPWO;
        }
    }
}
