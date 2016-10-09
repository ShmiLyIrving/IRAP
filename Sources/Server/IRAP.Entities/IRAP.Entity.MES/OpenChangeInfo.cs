using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 变更明细内容
    /// </summary>
    public class OpenChangeInfo
    {
        /// <summary>
        /// 事实编号
        /// </summary>
        public long FactID { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public long TransactNo { get; set; }
        /// <summary>
        /// 变更类别叶标识
        /// </summary>
        public int T276LeafID { get; set; }
        /// <summary>
        /// 变更类别名称
        /// </summary>
        public string T276Name { get; set; }
        /// <summary>
        /// 变更号
        /// </summary>
        public string ECorAlertNo { get; set; }
        /// <summary>
        /// 变更内容
        /// </summary>
        public string ChangeContent { get; set; }
        /// <summary>
        /// 预计实施日期
        /// </summary>
        public string ToImplementDate { get; set; }
        /// <summary>
        /// 预计关闭日期
        /// </summary>
        public string ToCloseDate { get; set; }
        /// <summary>
        /// 实际实施日期
        /// </summary>
        public string ActualImplementDate { get; set; }

        public OpenChangeInfo Clone()
        {
            return MemberwiseClone() as OpenChangeInfo;
        }
    }
}