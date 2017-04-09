using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entities.APS
{
    public class ManufacturingOrder
    {
        private Quantity orderQuantity = new Quantity();
        private Quantity finishedQuantity = new Quantity();
        private Quantity atpQuantity = new Quantity();

        /// <summary>
        /// 优先顺序
        /// </summary>
        public int PriorityOrdinal { get; set; }
        /// <summary>
        /// 制造订单号
        /// </summary>
        public string MONo { get; set; }
        /// <summary>
        /// 制造订单行号
        /// </summary>
        public int MOLineNo { get; set; }
        /// <summary>
        /// 产品编号（含半成品）
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductDesc { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public long OrderQty
        {
            get { return orderQuantity.IntValue; }
            set { orderQuantity.IntValue = value; }
        }
        /// <summary>
        /// 完工数量
        /// </summary>
        public long FinishedQty
        {
            get { return finishedQuantity.IntValue; }
            set { finishedQuantity.IntValue = value; }
        }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale
        {
            get { return orderQuantity.Scale; }
            set
            {
                orderQuantity.Scale = value;
                finishedQuantity.Scale = value;
                atpQuantity.Scale = value;
            }
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure
        {
            get { return orderQuantity.UnitOfMeasure; }
            set
            {
                orderQuantity.UnitOfMeasure = value;
                finishedQuantity.UnitOfMeasure = value;
                atpQuantity.UnitOfMeasure = value;
            }
        }
        /// <summary>
        /// 计划投产日期
        /// </summary>
        public string PlannedStartDate { get; set; }
        /// <summary>
        /// 计划完工日期
        /// </summary>
        public string PlannedEndDate { get; set; }
        /// <summary>
        /// 排定生产时间
        /// </summary>
        public string ScheduledStartTime { get; set; }
        /// <summary>
        /// 实际生产时间
        /// </summary>
        public string ActualStartTime { get; set; }
        /// <summary>
        /// 订单状态
        /// 0-新创建
        /// 1-已确认
        /// 2-已锁定
        /// 3-待发布
        /// 4-已发布
        /// 5-已分单
        /// 6-已备料
        /// 7-已投产
        /// 8-已完工
        /// 9-差异完工
        /// </summary>
        public int MOLineStatus { get; set; }
        /// <summary>
        /// 当前物料可供生产数量
        /// </summary>
        public long ATPQty
        {
            get { return atpQuantity.IntValue; }
            set { atpQuantity.IntValue = value; }
        }
        /// <summary>
        /// 预计物料备齐时间
        /// </summary>
        public string EstimatedATPTime { get; set; }
        /// <summary>
        /// 分单交易号
        /// </summary>
        public long DispatchingTransNo { get; set; }
        /// <summary>
        /// 分单首个事实编号
        /// </summary>
        public long DispatchingFactID { get; set; }
        /// <summary>
        /// 产线叶标识
        /// </summary>
        public int T134LeafID { get; set; }
        /// <summary>
        /// 产线代码
        /// </summary>
        public string T134Code { get; set; }
        /// <summary>
        /// 产线名称
        /// </summary>
        public string T134Name { get; set; }
        /// <summary>
        /// 工单签发辅助事实表分区键
        /// </summary>
        public long AF482PK { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public Quantity OrderQuantity
        {
            get { return orderQuantity; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity FinishedQuantity
        {
            get { return finishedQuantity; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity ATPQuantity
        {
            get { return atpQuantity; }
        }

        public ManufacturingOrder Clone()
        {
            ManufacturingOrder rlt = MemberwiseClone() as ManufacturingOrder;

            rlt.orderQuantity = this.orderQuantity.Clone();
            rlt.finishedQuantity = this.finishedQuantity.Clone();
            rlt.atpQuantity = this.atpQuantity.Clone();

            return rlt;
        }
    }
}
