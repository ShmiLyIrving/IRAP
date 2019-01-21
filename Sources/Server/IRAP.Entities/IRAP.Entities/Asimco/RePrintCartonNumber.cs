using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Asimco
{
    public class RePrintCartonNumber
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
        /// 内箱数量
        /// </summary>
        public long BoxCnt { get; set; }
        /// <summary>
        /// 外箱包含产品数量
        /// </summary>
        public long CartonQty { get; set; }
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
        public string Carton102Code { get; set; }
    }
}
