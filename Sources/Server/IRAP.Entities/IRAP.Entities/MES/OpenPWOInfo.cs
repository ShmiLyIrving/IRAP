using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class OpenPWOInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工单签发/变更事实编号
        /// </summary>
        public long PWOIssuingFactID { get; set; }
        /// <summary>
        /// 工单签发/变更交易号
        /// </summary>
        public long PWOIssuingTransNo { get; set; }
        /// <summary>
        /// 工单签发临时事实分区键
        /// </summary>
        public long TF482PK { get; set; }
        /// <summary>
        /// 工单签发辅助事实分区键
        /// </summary>
        public long AF482PK { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产线叶标识
        /// </summary>
        public int T134LeafID { get; set; }
        /// <summary>
        /// 班次叶标识
        /// </summary>
        public int T126LeafID { get; set; }
        /// <summary>
        /// 生产工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 替代工单号
        /// </summary>
        public string AltPWONo { get; set; }
        /// <summary>
        /// 生产批次号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 工单类型(N-正常 T-试产 R-返工)
        /// </summary>
        public string PWOTypeCode { get; set; }
        /// <summary>
        /// 制造订单号
        /// </summary>
        public string MONumber { get; set; }
        /// <summary>
        /// 制造订单行号
        /// </summary>
        public int MOLineNo { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public long OrderQty { get; set; }
        /// <summary>
        /// 操作工人数
        /// </summary>
        public decimal NumOperators { get; set; }
        /// <summary>
        /// 创建时Unix时间
        /// </summary>
        public int CreatedUnixTime { get; set; }
        /// <summary>
        /// 排定生产开始时间
        /// </summary>
        public string ScheduledStartTime { get; set; }
        /// <summary>
        /// 排定生产结束时间
        /// </summary>
        public string ScheduledCloseTime { get; set; }
        /// <summary>
        /// 实际生产开始时间
        /// </summary>
        public string ActualStartTime { get; set; }
        /// <summary>
        /// 在制品容器号
        /// </summary>
        public string ContainerNo { get; set; }
        /// <summary>
        /// 生产工单状态
        /// </summary>
        public int PWOStatus { get; set; }
        /// <summary>
        /// 生产工单优先级
        /// </summary>
        public int PWOPriority { get; set; }
        /// <summary>
        /// 是否急单
        /// </summary>
        public bool EmergencyOrder { get; set; }
        /// <summary>
        /// 工单控制属性
        /// (1-计划 2-变更 3-插单 4-补单)
        /// </summary>
        public int PWOCtrlAttr { get; set; }

        public OpenPWOInfo Clone()
        {
            return MemberwiseClone() as OpenPWOInfo;
        }
    }
}
