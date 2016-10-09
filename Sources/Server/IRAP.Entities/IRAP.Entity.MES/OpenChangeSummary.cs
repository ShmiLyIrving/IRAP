using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 变更事项类别汇总信息
    /// </summary>
    public class OpenChangeSummary
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int  Ordinal { get; set; }
        /// <summary>
        /// 变更类别结点标识
        /// </summary>
        public int T276NodeID { get; set; }
        /// <summary>
        /// 变更类别结点名称
        /// </summary>
        public string T276Name { get; set; }
        /// <summary>
        /// 是否存在此类变更
        /// </summary>
        public bool Existence { get; set; }

        public OpenChangeSummary Clone()
        {
            return MemberwiseClone() as OpenChangeSummary;
        }
    }
}