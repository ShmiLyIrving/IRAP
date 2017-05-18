using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    /// <summary>
    /// 质量问题柏拉图中的失效模式
    /// </summary>
    public class FailureModeOfPallet
    {
        /// <summary>
        /// 序列号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 失效模式LeafID
        /// </summary>
        public int T118LeafID { get; set; }
        /// <summary>
        /// 失效模式代码
        /// </summary>
        public string T118Code { get; set; }
        /// <summary>
        /// 失效模式名称
        /// </summary>
        public string T118Name { get; set; }
        /// <summary>
        /// 失效模式对应的不良个数
        /// </summary>
        public int FailureQty { get; set; }
        /// <summary>
        /// 累积比率，以分数呈现
        /// </summary>
        public decimal FailRate { get; set; }

        public FailureModeOfPallet Clone()
        {
            return MemberwiseClone() as FailureModeOfPallet;
        }
    }
}
