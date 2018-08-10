using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.MES
{
    public class TSHistory
    {
        /// <summary>
        /// 分区键
        /// </summary>
        public long RSFactPK { get; set; }
        /// <summary>
        /// 事实编号
        /// </summary>
        public long FactID { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public long TransactNo { get; set; }
        /// <summary>
        /// 维修时间(yyyy-mm-dd hh:mm:ss) show
        /// </summary>
        public string BizDateTime { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品编号 show
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 产品主标识 show
        /// </summary>
        public string WIPCode { get; set; }
        /// <summary>
        /// 产品副标识 show
        /// </summary>
        public string AltWIPCode { get; set; }
        /// <summary>
        /// 产品序列号 show
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 位置编号 show
        /// </summary>
        public string CompLocCode { get; set; }
        /// <summary>
        /// 物料代码 show
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 失效模式 show
        /// </summary>
        public string FailureMode { get; set; }
        /// <summary>
        /// 维修模式 show
        /// </summary>
        public string RepairMode { get; set; }
        /// <summary>
        /// 维修工人 show
        /// </summary>
        public string TSOperator { get; set; }
        /// <summary>
        /// 原物料追溯标识
        /// </summary>
        public string MaterialLabelSN0 { get; set; }
        /// <summary>
        /// 更换料追溯标识 show
        /// </summary>
        public string MaterialLabelSN1 { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public string MainWIPCode
        {
            get
            {
                if (AltWIPCode == "")
                    return WIPCode;
                else
                    return AltWIPCode;
            }
        }
    }
}
