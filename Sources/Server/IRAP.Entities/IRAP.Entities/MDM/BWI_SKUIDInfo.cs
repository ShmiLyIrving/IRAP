using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    public class BWI_SKUIDInfo
    {
        public int Ordinal { get; set; }
        /// <summary>
        /// 物料标识
        /// </summary>
        public string SKUID { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品代码
        /// </summary>
        public string T102Code { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string T102Name { get; set; }
        /// <summary>
        /// 客户叶标识
        /// </summary>
        public int T105LeafID { get; set; }
        /// <summary>
        /// 客户代码
        /// </summary>
        public string T105Code { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string T105Name { get; set; }
        /// <summary>
        /// 地点叶标识
        /// </summary>
        public int T172LeafID { get; set; }
        /// <summary>
        /// 地点代码
        /// </summary>
        public string T172Code { get; set; }
        /// <summary>
        /// 地点名称
        /// </summary>
        public string T172Name { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string T172Addres { get; set; }
        /// <summary>
        /// 制造日期
        /// </summary>
        public string MFGDate { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public string StorageDate { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public long Qty { get; set; }
        /// <summary>
        /// 客户物料编码
        /// </summary>
        public string CPartNumber { get; set; }
        /// <summary>
        /// 销售编码
        /// </summary>
        public string SalePartNumber { get; set; }

        public BWI_SKUIDInfo Clone()
        {
            return MemberwiseClone() as BWI_SKUIDInfo;
        }
    }
}
