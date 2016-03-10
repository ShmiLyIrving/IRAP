using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 子在制品信息
    /// </summary>
    public class SubWIPIDCodeInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 子在制品分组标识
        /// </summary>
        public int SubWIPGroupID { get; set; }
        /// <summary>
        /// 子在制品主标识代码
        /// </summary>
        public string SubWIPIDCode { get; set; }
        /// <summary>
        /// 质量控制状态
        /// </summary>
        public long QCStatus { get; set; }
        /// <summary>
        /// 是否已报废
        /// </summary>
        public bool Scrapped { get; set; }
        /// <summary>
        /// 生产任务种类叶标识
        /// </summary>
        public int PWOCategoryLeaf { get; set; }

        public SubWIPIDCodeInfo Clone()
        {
            SubWIPIDCodeInfo rlt = MemberwiseClone() as SubWIPIDCodeInfo;

            return rlt;
        }
    }
}