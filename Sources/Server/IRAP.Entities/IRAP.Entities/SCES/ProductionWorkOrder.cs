using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entities.SCES
{
    public class ProductionWorkOrder
    {
        private Quantity plannedQuantity = new Quantity();

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
        /// 行号
        /// </summary>
        public int MOLineNo { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductDesc { get; set; }
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
        /// 排产数量
        /// </summary>
        public long PlannedQty
        {
            get { return plannedQuantity.IntValue; }
            set { plannedQuantity.IntValue = value; }
        }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale
        {
            get { return plannedQuantity.Scale; }
            set { plannedQuantity.Scale = value; }
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure
        {
            get { return plannedQuantity.UnitOfMeasure; }
            set { plannedQuantity.UnitOfMeasure = value; }
        }
        /// <summary>
        /// 计划开工日期
        /// </summary>
        public string PlannedStartDate { get; set; }
        /// <summary>
        /// 计划完工日期
        /// </summary>
        public string PlannedCloseDate { get; set; }
        /// <summary>
        /// 排定投产时间
        /// </summary>
        public string ScheduledStartTime { get; set; }
        /// <summary>
        /// 辅助事实分区键
        /// </summary>
        public long AF482PK { get; set; }

        [IRAPORMMap(ORMMap =false)]
        public Quantity PlannedQuantity
        {
            get { return plannedQuantity; }
        }
        [IRAPORMMap(ORMMap = false)]
        public string RequireDeliveryTime
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(this.ScheduledStartTime).AddMinutes(-30).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch
                {
                    return "日期格式错误";
                }
            }
        }

        public ProductionWorkOrder Clone()
        {
            ProductionWorkOrder rlt = MemberwiseClone() as ProductionWorkOrder;
            rlt.plannedQuantity = plannedQuantity.Clone();

            return rlt;
        }
    }

    public class ProductionWorkOrderEx
    {
        private Quantity plannedQuantity = new Quantity();

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
        /// 行号
        /// </summary>
        public int MOLineNo { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductDesc { get; set; }
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
        /// 排产数量
        /// </summary>
        public long PlannedQty
        {
            get { return plannedQuantity.IntValue; }
            set { plannedQuantity.IntValue = value; }
        }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale
        {
            get { return plannedQuantity.Scale; }
            set { plannedQuantity.Scale = value; }
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure
        {
            get { return plannedQuantity.UnitOfMeasure; }
            set { plannedQuantity.UnitOfMeasure = value; }
        }
        /// <summary>
        /// 计划开工日期
        /// </summary>
        public string PlannedStartDate { get; set; }
        /// <summary>
        /// 计划完工日期
        /// </summary>
        public string PlannedCloseDate { get; set; }
        /// <summary>
        /// 排定投产时间
        /// </summary>
        public string ScheduledStartTime { get; set; }
        /// <summary>
        /// 辅助事实分区键
        /// </summary>
        public long AF482PK { get; set; }
        /// <summary>
        /// 行集事实分区键
        /// </summary>
        public long FP482PK { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public Quantity PlannedQuantity
        {
            get { return plannedQuantity; }
        }
        [IRAPORMMap(ORMMap = false)]
        public string RequireDeliveryTime
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(this.ScheduledStartTime).AddMinutes(-30).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch
                {
                    return "日期格式错误";
                }
            }
        }
        /// <summary>
        /// 子项物料叶标识
        /// </summary>
        public int SubLeafID { get; set; }
        /// <summary>
        /// 子项物料号
        /// </summary>
        public string SubMaterialCode { get; set; }
        /// <summary>
        /// 子项物料名称
        /// </summary>
        public string SubMaterialDesc { get; set; }
        /// <summary>
        /// 产品中心/厂家信息
        /// </summary>
        public string GateWayWC { get; set; }

        public ProductionWorkOrderEx Clone()
        {
            ProductionWorkOrderEx rlt = MemberwiseClone() as ProductionWorkOrderEx;
            rlt.plannedQuantity = plannedQuantity.Clone();

            return rlt;
        }
    }
}
