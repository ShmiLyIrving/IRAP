using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entity.FVS
{
    /// <summary>
    /// 制造订单跟踪看板内容
    /// </summary>
    public class Dashboard_MOTrack
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
        /// 分区键
        /// </summary>
        public long PartitioningKey { get; set; }

        /// <summary>
        /// 事实编号
        /// </summary>
        public long FactID { get; set; }

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
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 计划开工日期
        /// </summary>
        public string PlannedStartDate { get; set; }

        /// <summary>
        /// 计划完工日期
        /// </summary>
        public string PlannedCloseDate { get; set; }

        /// <summary>
        /// 排定生产时间
        /// </summary>
        public string ScheduledStartTime { get; set; }

        /// <summary>
        /// 实际开工时间
        /// </summary>
        public string ActualStartTime { get; set; }

        /// <summary>
        /// 要求完工时间
        /// </summary>
        public string ScheduledCloseTime { get; set; }

        /// <summary>
        /// 工单执行进度
        /// </summary>
        /// <remarks>0=正常 1=偏快 2=过快 3=偏慢 4=过慢</remarks>
        public int PWOProgress { get; set; }

        /// <summary>
        /// 滞在工序名
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public long OrderQty { get; set; }

        /// <summary>
        /// 提料数量
        /// </summary>
        public long MaterialQty { get; set; }

        /// <summary>
        /// 正品数量
        /// </summary>
        public long WIPQty { get; set; }

        /// <summary>
        /// 废品率（本工序前）
        /// </summary>
        public decimal ScrapRate { get; set; }

        /// <summary>
        /// 进度百分比(%)
        /// </summary>
        public decimal ProgressPercentage { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public decimal ActualScrapRate
        {
            get { return ScrapRate / 100; }
        }

        [IRAPORMMap(ORMMap = false)]
        public decimal ActualProgressPercentage
        {
            get { return ProgressPercentage / 100; }
        }

        public Dashboard_MOTrack Clone()
        {
            return this.MemberwiseClone() as Dashboard_MOTrack;
        }
    }
}
