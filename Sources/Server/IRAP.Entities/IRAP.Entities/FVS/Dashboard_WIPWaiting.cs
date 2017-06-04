using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.FVS
{
    public class Dashboard_WIPWaiting
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 产品族叶标识
        /// </summary>
        public int  T132LeafID { get; set; }
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
        /// 等待分钟数
        /// </summary>
        public int MinutesWaited { get; set; }
        /// <summary>
        /// 等待状态
        /// (0=正常 3=偏长 4=过长)
        /// </summary>
        public int DLVProgress { get; set; }
        /// <summary>
        /// 容器编号
        /// </summary>
        public string ContainerNo { get; set; }
        /// <summary>
        /// 在制品数量
        /// </summary>
        public long WIPQty { get; set; }
        /// <summary>
        /// 滞在工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }
        /// <summary>
        /// 滞在工序名称
        /// </summary>
        public string T216Name { get; set; }

        public Dashboard_WIPWaiting Clone()
        {
            return MemberwiseClone() as Dashboard_WIPWaiting;
        }
    }
}
