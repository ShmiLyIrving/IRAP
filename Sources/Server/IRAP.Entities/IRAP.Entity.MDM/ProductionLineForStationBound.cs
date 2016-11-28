using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 站点绑定的生产线
    /// </summary>
    public class ProductionLineForStationBound
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 产线叶标识
        /// </summary>
        public int T134LeafID { get; set; }
        /// <summary>
        /// 产线代码
        /// </summary>
        public string T134Code { get; set; }
        /// <summary>
        /// 产线替代代码
        /// </summary>
        public string T134AltCode { get; set; }
        /// <summary>
        /// 产线名称
        /// </summary>
        public string T134NodeName { get; set; }
        /// <summary>
        /// 主机名
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// 是否绑定到安灯主机
        /// </summary>
        public bool BoundToAndonHost { get; set; }
        /// <summary>
        /// 是否停线
        /// </summary>
        public bool IsStoped { get; set; }

        public ProductionLineForStationBound Clone()
        {
            return MemberwiseClone() as ProductionLineForStationBound;
        }

        public override string ToString()
        {
            return string.Format("({0}){1}", T134Code, T134NodeName);
        }
    }
}