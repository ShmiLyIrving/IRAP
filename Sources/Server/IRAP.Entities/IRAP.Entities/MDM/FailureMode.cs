using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    /// <summary>
    /// 失效模式
    /// </summary>
    public class FailureMode
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 缺陷标识
        /// </summary>
        public int FailureID { get; set; }
        /// <summary>
        /// 缺陷叶标识
        /// </summary>
        public int FailureLeaf { get; set; }
        /// <summary>
        /// 失效代码
        /// </summary>
        public string FailureCode { get; set; }
        /// <summary>
        /// 失效名称
        /// </summary>
        public string FailureName { get; set; }

        public FailureMode Clone()
        {
            return MemberwiseClone() as FailureMode;
        }
    }
}
