using IRAP.Global;
using IRAPShared;

namespace IRAP.Entities.MDM
{
    /// <summary>
    /// 当前版本装料表项
    /// </summary>
    public class CurrentLoadingSheetItem
    {
        private Quantity usageQuantity = new Quantity();

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// 工序步骤
        /// </summary>
        public int StepNo { get; set; }

        /// <summary>
        /// 料槽叶标识
        /// </summary>
        public int T108LeafID { get; set; }

        /// <summary>
        /// 料槽编号
        /// </summary>
        public string SlotCode { get; set; }

        /// <summary>
        /// 原辅材料叶标识
        /// </summary>
        public int T101LeafID { get; set; }

        /// <summary>
        /// 半成品叶标识
        /// </summary>
        public int T102LeafID { get; set; }

        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialCode { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// 用量或配方百分比
        /// </summary>
        public long UsageQty
        {
            get { return usageQuantity.IntValue; }
            set { usageQuantity.IntValue = value; }
        }

        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale
        {
            get { return usageQuantity.Scale; }
            set { usageQuantity.Scale = value; }
        }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure
        {
            get { return usageQuantity.UnitOfMeasure; }
            set { usageQuantity.UnitOfMeasure = value; }
        }

        /// <summary>
        /// 是否实时扣料
        /// </summary>
        public bool BackflushOnMR { get; set; }

        /// <summary>
        /// 料槽容量
        /// </summary>
        public long SlotCapacity { get; set; }

        /// <summary>
        /// 加接料告警阀门值
        /// </summary>
        public long FeedingAlarmingThreshold { get; set; }

        /// <summary>
        /// 预估抛料率
        /// </summary>
        public decimal EstimatedScrapRate { get; set; }

        /// <summary>
        /// 抛料告警阀门值
        /// </summary>
        public decimal ScrapingAlarmingThreshold { get; set; }

        /// <summary>
        /// 流量低限值(流程制造用)
        /// </summary>
        public long FluxLowLimit { get; set; }

        /// <summary>
        /// 流量高限值(流程制造用)
        /// </summary>
        public long FluxHighLimit { get; set; }

        /// <summary>
        /// 加料时间偏移量低限(ms)
        /// </summary>
        public int FeedingTimeOffsetLowLimit { get; set; }

        /// <summary>
        /// 加料时间偏移量高限(ms)
        /// </summary>
        public int FeedingTimeOffsetHighLimit { get; set; }

        /// <summary>
        /// 部件位置清单
        /// </summary>
        public string ComponentLocList { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public Quantity UsageQuantity
        {
            get { return usageQuantity; }
        }

        public CurrentLoadingSheetItem Clone()
        {
            CurrentLoadingSheetItem rlt = MemberwiseClone() as CurrentLoadingSheetItem;

            rlt.UsageQty = this.UsageQty;
            rlt.Scale = this.Scale;
            rlt.UnitOfMeasure = this.UnitOfMeasure;

            return rlt;
        }
    }
}
