using IRAP.Global;

namespace IRAP.Entity.FVS
{
    /// <summary>
    /// 生产工单监控信息
    /// </summary>
    public class PWOSurveillance
    {
        Quantity pwOrderQuantity = new Quantity();
        Quantity wipQuantity = new Quantity();
        Quantity scrapedQuantity = new Quantity();

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
        /// 生产批号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 生产工单数量
        /// </summary>
        public long PWOrderQty
        {
            get { return pwOrderQuantity.IntValue; }
            set { pwOrderQuantity.IntValue = value; }
        }
        /// <summary>
        /// 在制品数量
        /// </summary>
        public long WIPQty
        {
            get { return wipQuantity.IntValue; }
            set { wipQuantity.IntValue = value; }
        }
        /// <summary>
        /// 在制品容器编号
        /// </summary>
        public string ContainerNo { get; set; }
        /// <summary>
        /// 工位累计加工时间(min)
        /// </summary>
        public int StationMFGTime { get; set; }
        /// <summary>
        /// 工段制程时间(min)
        /// </summary>
        public int ThroughPutTime { get; set; }
        /// <summary>
        /// 累计制造周期时间(min)
        /// </summary>
        public int AccumMCT { get; set; }
        /// <summary>
        /// 废品数量
        /// </summary>
        public long ScrapedQty
        {
            get { return scrapedQuantity.IntValue; }
            set { scrapedQuantity.IntValue = value; }
        }
        /// <summary>
        /// 一次性通过率(%)
        /// </summary>
        public double FPYPercentage { get; set; }
        /// <summary>
        /// 滞在工位代码
        /// </summary>
        public string AtStationCode { get; set; }
        /// <summary>
        /// 滞在工位名称
        /// </summary>
        public string AtStationName { get; set; }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale
        {
            get { return pwOrderQuantity.Scale; }
            set
            {
                pwOrderQuantity.Scale = value;
                wipQuantity.Scale = value;
                scrapedQuantity.Scale = value;
            }
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure
        {
            get { return pwOrderQuantity.UnitOfMeasure; }
            set
            {
                pwOrderQuantity.UnitOfMeasure = value;
                wipQuantity.UnitOfMeasure = value;
                scrapedQuantity.UnitOfMeasure = value;
            }
        }
        /// <summary>
        /// 滞在工位叶标识
        /// </summary>
        public int T107LeafID { get; set; }
        /// <summary>
        /// 产品实体标识
        /// </summary>
        public int T102EntityID { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }

        public PWOSurveillance Clone()
        {
            PWOSurveillance rlt = MemberwiseClone() as PWOSurveillance;

            rlt.pwOrderQuantity = pwOrderQuantity.Clone();
            rlt.wipQuantity = wipQuantity.Clone();
            rlt.scrapedQuantity = scrapedQuantity.Clone();

            return rlt;
        }
    }
}