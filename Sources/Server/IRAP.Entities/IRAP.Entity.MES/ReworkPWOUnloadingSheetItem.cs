using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 返工工单卸料表项
    /// </summary>
    public class ReworkPWOUnloadingSheetItem
    {
        private Quantity unloadQuantity = new Quantity();

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工位叶标识
        /// </summary>
        public int T107LeafID { get; set; }
        /// <summary>
        /// 工位代码
        /// </summary>
        public string T107Code { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string T107Name { get; set; }
        /// <summary>
        /// 设备叶标识
        /// </summary>
        public int T133LeafID { get; set; }
        /// <summary>
        /// 设备代码
        /// </summary>
        public string T133Code { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string T133Name { get; set; }
        /// <summary>
        /// 料槽叶标识
        /// </summary>
        public int T108LeafID { get; set; }
        /// <summary>
        /// 料槽编号
        /// </summary>
        public string SlotCode { get; set; }
        /// <summary>
        /// 部件位置叶标识
        /// </summary>
        public int T110LeafID { get; set; }
        /// <summary>
        /// 部件位置编号
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// 材料叶标识
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
        /// 物料描述
        /// </summary>
        public string MaterialDesc { get; set; }
        /// <summary>
        /// 卸料数量
        /// </summary>
        public long UnloadQty
        {
            get { return unloadQuantity.IntValue; }
            set { unloadQuantity.IntValue = value; }
        }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int QtyScale
        {
            get { return unloadQuantity.Scale; }
            set { unloadQuantity.Scale = value; }
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure
        {
            get { return unloadQuantity.UnitOfMeasure; }
            set { unloadQuantity.UnitOfMeasure = value; }
        }
        /// <summary>
        /// 卸料是否报废
        /// </summary>
        public bool ScrapOnUnloading { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public Quantity UnloadQuantity
        {
            get { return unloadQuantity; }
        }

        public ReworkPWOUnloadingSheetItem Clone()
        {
            ReworkPWOUnloadingSheetItem rlt = MemberwiseClone() as ReworkPWOUnloadingSheetItem;

            rlt.unloadQuantity = unloadQuantity.Clone();

            return rlt;
        }
    }
}