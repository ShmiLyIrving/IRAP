using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Client.GUI.MESPDC.Entities
{
    public class EntityPWO
    {
        /// <summary>
        /// 工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 产品物料号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 产品物料名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public string TextureCode { get; set; }
        /// <summary>
        /// 工单生产数量
        /// </summary>
        public long Quantity { get; set; }

        public EntityPWO Clone()
        {
            return MemberwiseClone() as EntityPWO;
        }
    }
}
