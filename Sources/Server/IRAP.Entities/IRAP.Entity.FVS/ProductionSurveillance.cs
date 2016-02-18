using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    /// <summary>
    /// 生产监控结果
    /// </summary>
    public class ProductionSurveillance
    {
        /// <summary>
        /// 工厂结构结点标识
        /// </summary>
        public int T134NodeID { get; set; }
        /// <summary>
        /// 工厂结构结点名称
        /// </summary>
        public string T134NodeName { get; set; }
        /// <summary>
        /// 产线或工作中心树标识(134/211)
        /// </summary>
        public int TreeID { get; set; }
        /// <summary>
        /// 产线或工作中心叶标识
        /// </summary>
        public int LeafID { get; set; }
        /// <summary>
        /// 产线或工作中心代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 产线或工作中心名称
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 自定义遍历序
        /// </summary>
        public double UDFOrdinal { get; set; }
        /// <summary>
        /// 事件类型叶标识
        /// </summary>
        public int T179LeafID { get; set; }
        /// <summary>
        /// 事件类型实体标识
        /// </summary>
        public int T179EntityID { get; set; }
        /// <summary>
        /// 事件类型代码
        /// </summary>
        public string T179Code { get; set; }
        /// <summary>
        /// 事件类型名称
        /// </summary>
        public string T179NodeName { get; set; }
        /// <summary>
        /// 资源状态
        /// </summary>
        /// <value>0=未开通 1=正常 2=非停线 3=停线</value>
        public int ResourceStatus { get; set; }
        /// <summary>
        /// 已过时间(s)
        /// </summary>
        public int ElapsedSeconds { get; set; }
        /// <summary>
        /// 是否响应
        /// </summary>
        public bool OnSiteResponded { get; set; }

        public ProductionSurveillance Clone()
        {
            ProductionSurveillance rlt = MemberwiseClone() as ProductionSurveillance;

            return rlt;
        }
    }
}