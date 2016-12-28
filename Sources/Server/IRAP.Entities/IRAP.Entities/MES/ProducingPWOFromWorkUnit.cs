using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entities.MES
{
    /// <summary>
    /// 当前正在生产的工单
    /// </summary>
    public class ProducingPWOFromWorkUnit
    {
        private Quantity quantityPWO = new Quantity();
        private Quantity quantityNotGood = new Quantity();

        /// <summary>
        /// 序列号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 工单数量
        /// </summary>
        public long PWOQty
        {
            get { return quantityPWO.IntValue; }
            set { quantityPWO.IntValue = value; }
        }
        /// <summary>
        /// 工单开始时间
        /// </summary>
        public string PWOStartTime { get; set; }
        /// <summary>
        /// 计划入库时间
        /// </summary>
        public string PlannedCloseTime { get; set; }
        /// <summary>
        /// 设备LeafID
        /// </summary>
        public int T133LeafID { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string T133Name { get; set; }
        /// <summary>
        /// 工位LeafID
        /// </summary>
        public int T107LeafID { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string T107Name { get; set; }
        /// <summary>
        /// 不合格品
        /// </summary>
        public long NotGoodQty
        {
            get { return quantityNotGood.IntValue; }
            set { quantityNotGood.IntValue = value; }
        }
        /// <summary>
        /// 合格率
        /// </summary>
        public decimal GoodRate { get; set; }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale
        {
            get { return quantityPWO.Scale; }
            set
            {
                quantityPWO.Scale = value;
                quantityNotGood.Scale = value;
            }
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure
        {
            get { return quantityNotGood.UnitOfMeasure; }
            set
            {
                quantityPWO.UnitOfMeasure = value;
                quantityNotGood.UnitOfMeasure = value;
            }
        }

        [IRAPORMMap(ORMMap = false)]
        /// <summary>
        /// 工单数量
        /// </summary>
        public Quantity PWOQuantity
        {
            get { return quantityPWO; }
        }
        [IRAPORMMap(ORMMap = false)]
        /// <summary>
        /// 不合格品
        /// </summary>
        public Quantity NotGoodQuantity
        {
            get { return quantityNotGood; }
        }

        public ProducingPWOFromWorkUnit Clone()
        {
            ProducingPWOFromWorkUnit rlt = MemberwiseClone() as ProducingPWOFromWorkUnit;
            rlt.quantityPWO = quantityPWO.Clone();
            rlt.quantityNotGood = quantityNotGood.Clone();

            return rlt;
        }
    }
}
