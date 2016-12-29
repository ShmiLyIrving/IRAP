using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entities.MES
{
    public class ToDoPWOFromWorkUnit
    {
        private Quantity quantityPWO = new Quantity();
        private Quantity quantityNotGood = new Quantity();

        /// <summary>
        /// 优先顺序
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
        /// 存货编码（产品编码）
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 存货名称(产品名称）
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string ProductAlterCode { get; set; }
        /// <summary>
        /// 存放库位
        /// </summary>
        public string T106Code { get; set; }
        /// <summary>
        /// 工单开始时间
        /// </summary>
        public string PWOStartTime { get; set; }
        /// <summary>
        /// 工序停留时间
        /// </summary>
        public string ProcessWaitTime { get; set; }
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

        public ToDoPWOFromWorkUnit Clone()
        {
            ToDoPWOFromWorkUnit rlt = MemberwiseClone() as ToDoPWOFromWorkUnit;
            rlt.quantityPWO = quantityPWO.Clone();
            rlt.quantityNotGood = quantityNotGood.Clone();

            return rlt;
        }
    }
}
