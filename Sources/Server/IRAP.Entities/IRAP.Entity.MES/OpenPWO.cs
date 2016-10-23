using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 未结工单信息
    /// </summary>
    public class OpenPWO
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工单签发事实编号
        /// </summary>
        public long PWOIssuingFactID { get; set; }
        /// <summary>
        /// 工单签发事实分区键
        /// </summary>
        public long TF482PK { get; set; }
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
        /// 班次代码
        /// </summary>
        public string T126Code { get; set; }
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
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public long OrderQty { get; set; }
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
        /// 工单类型代码
        /// </summary>
        public string PWOType { get; set; }
        /// <summary>
        /// 产品生命阶段
        /// </summary>
        public int T102S1 { get; set; }
        /// <summary>
        /// 工单控制属性(1-正常 2-插单 3-补单)
        /// </summary>
        public int PWOCtrlAttr { get; set; }

        /// <summary>
        /// 实际完成数量
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public double ActualQuantity { get; set; }
        [IRAPORMMap(ORMMap = false)]
        public int BTSStatus { get; set; }

        public OpenPWO Clone()
        {
            return MemberwiseClone() as OpenPWO;
        }
    }
}