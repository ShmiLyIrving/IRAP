using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entities.SCES
{
    public class MaterialToDeliver
    {
        private Quantity suggestedQuantityToPick = new Quantity();
        private Quantity inStoreQuantity = new Quantity();
        private Quantity actualQuantityToDeliver = new Quantity();
        private Quantity usageQuantity = new Quantity();
        private Quantity atpQuantity = new Quantity();
        private Quantity containerCapacityQuantity = new Quantity();

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 物料树标识(101/102)
        /// </summary>
        public int TreeID { get; set; }
        /// <summary>
        /// 物料叶标识
        /// </summary>
        public int LeafID { get; set; }
        /// <summary>
        /// 物料号
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialDesc { get; set; }
        /// <summary>
        /// 物料批号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 物料生产日期
        /// </summary>
        public string MFGDate { get; set; }
        /// <summary>
        /// 物料材质
        /// </summary>
        public string T131Code { get; set; }
        /// <summary>
        /// 建议发料量
        /// </summary>
        public long SuggestedQtyToPick
        {
            get { return suggestedQuantityToPick.IntValue; }
            set { suggestedQuantityToPick.IntValue = value; }
        }
        /// <summary>
        /// 源库位本批次库存量(符合FIFO)
        /// </summary>
        public long QtyInStore
        {
            get { return inStoreQuantity.IntValue; }
            set { inStoreQuantity.IntValue = value; }
        }
        /// <summary>
        /// 实际发出量
        /// </summary>
        public long ActualQtyToDeliver
        {
            get { return actualQuantityToDeliver.IntValue; }
            set { actualQuantityToDeliver.IntValue = value; }
        }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale
        {
            get { return suggestedQuantityToPick.Scale; }
            set
            {
                suggestedQuantityToPick.Scale = value;
                inStoreQuantity.Scale = value;
                actualQuantityToDeliver.Scale = value;
                usageQuantity.Scale = value;
                atpQuantity.Scale = value;
                containerCapacityQuantity.Scale = value;
            }
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure
        {
            get { return suggestedQuantityToPick.UnitOfMeasure; }
            set
            {
                suggestedQuantityToPick.UnitOfMeasure = value;
                inStoreQuantity.UnitOfMeasure = value;
                actualQuantityToDeliver.UnitOfMeasure = value;
                usageQuantity.UnitOfMeasure = value;
                atpQuantity.UnitOfMeasure = value;
                containerCapacityQuantity.UnitOfMeasure = value;
            }
        }
        /// <summary>
        /// 实际数量分解
        /// </summary>
        public string ActualQtyDecompose { get; set; }
        /// <summary>
        /// 当前库房叶标识
        /// </summary>
        public int T173LeafID { get; set; }
        /// <summary>
        /// 当前库房代码
        /// </summary>
        public string T173Code { get; set; }
        /// <summary>
        /// 当前库房名称
        /// </summary>
        public string T173Name { get; set; }
        /// <summary>
        /// 滞在库位叶标识
        /// </summary>
        public int AtT106LeafID { get; set; }
        /// <summary>
        /// 滞在库位代码
        /// </summary>
        public string AtStoreLocCode { get; set; }
        /// <summary>
        /// 目标车间代码
        /// </summary>
        public string DstWorkShopCode { get; set; }
        /// <summary>
        /// 目标车间名称
        /// </summary>
        public string DstWorkShopDesc { get; set; }
        /// <summary>
        /// 目标线边库位叶标识
        /// </summary>
        public int DstT106LeafID { get; set; }
        /// <summary>
        /// 目标线边库位代码
        /// </summary>
        public string DstT106Code { get; set; }
        /// <summary>
        /// 用量
        /// </summary>
        public long UsageQty
        {
            get { return usageQuantity.IntValue; }
            set { usageQuantity.IntValue = value; }
        }
        /// <summary>
        /// 报废率(%)
        /// </summary>
        public decimal ScrapPercentage { get; set; }
        /// <summary>
        /// 齐套数量
        /// </summary>
        public long ATPQty
        {
            get { return atpQuantity.IntValue; }
            set { atpQuantity.IntValue = value; }
        }
        /// <summary>
        /// 容器容量
        /// </summary>
        public long ContainerCapacity
        {
            get { return containerCapacityQuantity.IntValue; }
            set { containerCapacityQuantity.IntValue = value; }
        }
        /// <summary>
        /// 0--无  1--打印配料单  2--通知分单  3--通知包装拆分
        /// </summary>
        public int ActionCode { get; set; }
        /// <summary>
        /// 每车棒数（仅双环镀铬库）
        /// </summary>
        public int StickQty { get; set; }
        /// <summary>
        /// 每棒数量（仅双环镀铬库）
        /// </summary>
        public long PerStickQty { get; set; }

        /// <summary>
        /// 建议发料量
        /// </summary>
        [IRAPORMMap(ORMMap =false)]
        public Quantity SuggestedQuantityToPick
        {
            get { return suggestedQuantityToPick; }
        }
        /// <summary>
        /// 源库位本批次库存量(符合FIFO)
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public Quantity QuantityInStore
        {
            get { return inStoreQuantity; }
        }
        /// <summary>
        /// 实际配送量
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public Quantity ActualQuantityToDeliver
        {
            get { return actualQuantityToDeliver; }
        }
        /// <summary>
        /// 用量
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public Quantity UsageQuantity
        {
            get { return usageQuantity; }
        }
        /// <summary>
        /// 齐套数量
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public Quantity ATPQuantity
        {
            get { return atpQuantity; }
        }
        /// <summary>
        /// 容器容量
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public Quantity ContainerCapacityQuantity
        {
            get { return containerCapacityQuantity; }
        }

        public MaterialToDeliver Clone()
        {
            MaterialToDeliver rlt = MemberwiseClone() as MaterialToDeliver;
            rlt.suggestedQuantityToPick = suggestedQuantityToPick.Clone();
            rlt.inStoreQuantity = inStoreQuantity.Clone();
            rlt.actualQuantityToDeliver = actualQuantityToDeliver.Clone();
            rlt.usageQuantity = usageQuantity.Clone();
            rlt.atpQuantity = atpQuantity.Clone();
            rlt.containerCapacityQuantity = containerCapacityQuantity.Clone();

            return rlt;
        }
    }
}