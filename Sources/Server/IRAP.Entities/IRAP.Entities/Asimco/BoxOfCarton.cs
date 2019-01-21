using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Asimco
{
    public class BoxOfCarton
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 外箱序号
        /// </summary>
        public string CartonNumber { get; set; }
        /// <summary>
        /// 外箱产品号
        /// </summary>
        public string CartonProductNo { get; set; }
        /// <summary>
        /// 外箱产品名称
        /// </summary>
        public string CartonProductName { get; set; }
        /// <summary>
        /// 内箱序号
        /// </summary>
        public int OrdinalOfCarton { get; set; }
        /// <summary>
        /// 内箱标签号
        /// </summary>
        public string BoxNumber { get; set; }
        /// <summary>
        /// 内箱零件代码（物料号）
        /// </summary>
        public string BoxMaterialNo { get; set; }
        /// <summary>
        /// 内箱零件名称
        /// </summary>
        public string BoxMaterialName { get; set; }
        /// <summary>
        /// 内箱零件数量
        /// </summary>
        public long MaterialQty { get; set; }
        /// <summary>
        /// 机型
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 图号（零件号）
        /// </summary>
        public string DrawingID { get; set; }
        /// <summary>
        /// 材质（环别）
        /// </summary>
        public string MaterialCategory { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 筒号
        /// </summary>
        public string CylinderID { get; set; }
        /// <summary>
        /// 供应商代码（客户赋予的供应商代码）
        /// </summary>
        public string SupplyCode { get; set; }
        /// <summary>
        /// 产线代码
        /// </summary>
        public string T134Code { get; set; }
        /// <summary>
        /// 产线名称
        /// </summary>
        public string T134Name { get; set; }
        /// <summary>
        /// 产线替代代码（包装线代码）
        /// </summary>
        public string T134AlternateCode { get; set; }
        /// <summary>
        /// 标签叶标识
        /// </summary>
        public int T117LeafID { get; set; }
        /// <summary>
        /// 打印份数
        /// </summary>
        public int PrintQty { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }
    }
}
