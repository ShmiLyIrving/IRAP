using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class EntityBatchPWO
    {
        /// <summary>
        /// 事实编号
        /// </summary>
        public long FactID { get; set; }
        /// <summary>
        /// 工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品物料号
        /// </summary>
        public string T102Code { get; set; }
        /// <summary>
        /// 产品物料名称
        /// </summary>
        public string T102Name { get; set; }
        /// <summary>
        /// 产品标识代码
        /// </summary>
        public string WIPCode { get; set; }
        /// <summary>
        /// 工单批次号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 产品序列号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 产品替代标识代码
        /// </summary>
        public string AltWIPCode { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public string Texture { get; set; }
        /// <summary>
        /// 容次号
        /// </summary>
        public string BatchLot { get; set; }
        /// <summary>
        /// 工单生产数量
        /// </summary>
        public long Quantity { get; set; }

        public EntityBatchPWO Clone()
        {
            return MemberwiseClone() as EntityBatchPWO;
        }
    }
}
