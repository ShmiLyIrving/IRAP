using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.FVS
{
    /// <summary>
    /// 工单物料配送监控看板实体类
    /// </summary>
    public class Dashboard_MODelivery
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 产品族叶标识
        /// </summary>
        public int T132LeafID { get; set; }
        /// <summary>
        /// 背景颜色(#FFFFFF)
        /// </summary>
        public string BackgroundColor { get; set; }
        /// <summary>
        /// 事实分区键
        /// </summary>
        public  long PartitioningKey { get; set; }
        /// <summary>
        /// 工单签发事实编号
        /// </summary>
        public  long FactID { get; set; }
        /// <summary>
        /// 生产工单号
        /// </summary>
        public  string PWONo { get; set; }
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
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 排定生产时间
        /// </summary>
        public string ScheduledStartTime { get; set; }
        /// <summary>
        /// 要求送达时间
        /// </summary>
        public string RequiredArrivalTime { get; set; }
        /// <summary>
        /// 实际送达时间
        /// </summary>
        public string ActualArrivalTime { get; set; }
        /// <summary>
        /// 剩余分钟数
        /// </summary>
        public int ResidueMinutes { get; set; }
        /// <summary>
        /// 配送进度状态
        /// (0=正常 3=偏慢 4=过慢) 
        /// </summary>
        public int DLVProgress { get; set; }
        /// <summary>
        /// 容器编号
        /// </summary>
        public string ContainerNo { get; set; }
        /// <summary>
        /// 配送数量
        /// </summary>
        public long MaterialQty { get; set; }

        public Dashboard_MODelivery Clone()
        {
            return MemberwiseClone() as Dashboard_MODelivery;
        }
    }
}
