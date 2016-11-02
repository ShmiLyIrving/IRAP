using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.SCES
{
    public class ProductionFlowCard
    {
        /// <summary>
        /// 自增序列号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品编码(存货编码)
        /// </summary>
        public string T102Code { get; set; }
        /// <summary>
        /// 产品名称(产品规格)
        /// </summary>
        public string T102NodeName { get; set; }
        /// <summary>
        /// 生产工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 流转卡号
        /// </summary>
        public long PWOIssuingFactID { get; set; }
        /// <summary>
        /// 生产订单号
        /// </summary>
        public string MONumber { get; set; }
        /// <summary>
        /// 生产订单行号
        /// </summary>
        public string MOLineNo { get; set; }
        /// <summary>
        /// 工单数量(投入数量)
        /// </summary>
        public int OrderQty { get; set; }
        /// <summary>
        /// 生产开始时间(投入时间)
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 子项物料清单
        /// </summary>
        public string MaterialList { get; set; }
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
        public string T134NodeName { get; set; }
        /// <summary>
        /// 工作中心叶标识
        /// </summary>
        public int T211LeafID { get; set; }
        /// <summary>
        /// 工作中心代码
        /// </summary>
        public string T211Code { get; set; }
        /// <summary>
        /// 工作中心名称
        /// </summary>
        public string T211NodeName { get; set; }
        /// <summary>
        /// 工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }
        /// <summary>
        /// 工序
        /// </summary>
        public string T216Name { get; set; }
        /// <summary>
        /// 设备
        /// </summary>
        public string T133Name { get; set; }
        /// <summary>
        /// 存放位置
        /// </summary>
        public string T106Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public ProductionFlowCard Clone()
        {
            return MemberwiseClone() as ProductionFlowCard;
        }
    }
}
