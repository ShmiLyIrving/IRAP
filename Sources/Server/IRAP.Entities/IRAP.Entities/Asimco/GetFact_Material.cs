using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Asimco
{
    public class GetFact_Material
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; } = 0;
        /// <summary>
        /// 事实编号
        /// </summary>
        public long FactID { get; set; } = 0;
        /// <summary>
        /// 部件编号叶标识
        /// </summary>
        public int T101LeafID { get; set; } = 0;
        /// <summary>
        /// 部件编号
        /// </summary>
        public string T101Code { get; set; } = "";
        /// <summary>
        /// 部件名称
        /// </summary>
        public string T101Name { get; set; } = "";
        /// <summary>
        /// 供应商叶标识
        /// </summary>
        public int T104LeafID { get; set; } = 0;
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string T104Code { get; set; } = "";
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string T104Name { get; set; } = "";
        /// <summary>
        /// 采购订单号
        /// </summary>
        public string PONumber { get; set; } = "";
        /// <summary>
        /// 采购订单行号
        /// </summary>
        public int POLineNo { get; set; } = 0;
        /// <summary>
        /// 收料数量
        /// </summary>
        public long RecvQty { get; set; } = 0;
        /// <summary>
        /// 批次号
        /// </summary>
        public string LotNumber { get; set; } = "";
        /// <summary>
        /// 收料批次号
        /// </summary>
        public string RecvBatchNo { get; set; } = "";
        /// <summary>
        /// 材质
        /// </summary>
        public string Text { get; set; } = "";
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale { get; set; } = 0;
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; } = "";
        /// <summary>
        /// 姓名
        /// </summary>
        public string ApplicantName { get; set; } = "";
        /// <summary>
        /// 分区键
        /// </summary>
        public long RF31PK { get; set; } = 0;

        public GetFact_Material Clone()
        {
            return MemberwiseClone() as GetFact_Material;
        }
    }
}
