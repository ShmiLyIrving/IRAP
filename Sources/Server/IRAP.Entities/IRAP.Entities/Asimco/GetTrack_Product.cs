using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Asimco
{
    public class GetTrack_Product
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
        /// 生产任务种类叶标识
        /// </summary>
        public int T103LeafID { get; set; }
        /// <summary>
        /// 成本中心叶标识
        /// </summary>
        public int T139LeafID { get; set; }
        /// <summary>
        /// 部件编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 部件描述
        /// </summary>
        public string ProductDesc { get; set; }
        /// <summary>
        /// 产品层级
        /// </summary>
        public int NodeDepth { get; set; }
        /// <summary>
        /// 上层产品实体标识
        /// </summary>
        public int FatherProductID { get; set; }
        /// <summary>
        /// 上层产品编号
        /// </summary>
        public string FatherProductNo { get; set; }
        /// <summary>
        /// 部件主标识代码
        /// </summary>
        public string PrimaryPartIDCode { get; set; }
        /// <summary>
        /// 部件生产批次号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 部件生产日期
        /// </summary>
        public string MFGDate { get; set; }
        /// <summary>
        /// 生产工单签发事实号
        /// </summary>
        public long FactID { get; set; }
        /// <summary>
        /// 生产工单号
        /// </summary>
        public string WFInstanceID { get; set; }

        public GetTrack_Product Clone()
        {
            return MemberwiseClone() as GetTrack_Product;
        }
    }
}
