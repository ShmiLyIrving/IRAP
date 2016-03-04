using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 目标仓储地点信息
    /// </summary>
    public class DstDeliveryStoreSite
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 目标仓储地点叶标识
        /// </summary>
        public int T173LeafID { get; set; }
        /// <summary>
        /// 目标仓储地点实体标识
        /// </summary>
        public int T173EntityID { get; set; }
        /// <summary>
        /// 目标仓储地点代码
        /// </summary>
        public string T173Code { get; set; }
        /// <summary>
        /// 目标仓储地点 ERP 代码
        /// </summary>
        public string T173AltCode { get; set; }
        /// <summary>
        /// 目标仓储地点名称
        /// </summary>
        public string T173Name { get; set; }
        /// <summary>
        /// 目标仓储地点供应链势
        /// </summary>
        public int Potential { get; set; }
        /// <summary>
        /// 目标仓储地点收料库位
        /// </summary>
        public int T106LeafID_Recv { get; set; }
        /// <summary>
        /// 目标仓储地点收料人部门
        /// </summary>
        public int T1LeafID_Recv { get; set; }

        public DstDeliveryStoreSite Clone()
        {
            return MemberwiseClone() as DstDeliveryStoreSite;
        }
    }
}