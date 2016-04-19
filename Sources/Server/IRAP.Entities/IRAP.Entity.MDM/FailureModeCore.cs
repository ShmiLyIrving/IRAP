using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 产品失效模式
    /// </summary>
    public class FailureModeCore
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 失效模式叶标识
        /// </summary>
        public int T118LeafID { get; set; }
        /// <summary>
        /// 失效代码
        /// </summary>
        public string T118Code { get; set; }
        /// <summary>
        /// 失效名称
        /// </summary>
        public string T118Name { get; set; }

        public FailureModeCore Clone()
        {
            return MemberwiseClone() as FailureModeCore;
        }
    }
}