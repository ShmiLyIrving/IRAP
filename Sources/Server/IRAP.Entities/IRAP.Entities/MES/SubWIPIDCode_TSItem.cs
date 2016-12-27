using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    /// <summary>
    /// 故障维修中每个子板的维修项目
    /// </summary>
    public class SubWIPIDCode_TSItem
    {
        /// <summary>
        /// 器件位号
        /// </summary>
        public int T110LeafID { get; set; }
        public int T101LeafID { get; set; }
        /// <summary>
        /// 失效模式
        /// </summary>
        public int T118LeafID { get; set; }
        /// <summary>
        /// 失效点数
        /// </summary>
        public int FailurePointCount { get; set; }
        /// <summary>
        /// 根源工序
        /// </summary>
        public int T216LeafID { get; set; }
        /// <summary>
        /// 失效性质
        /// </summary>
        public int T183LeafID { get; set; }
        /// <summary>
        /// 失效责任
        /// </summary>
        public int T184LeafID { get; set; }
        /// <summary>
        /// 维修模式
        /// </summary>
        public int T119LeafID { get; set; }
        /// <summary>
        /// 追溯参考值
        /// </summary>
        public string TrackReferenceValue { get; set; }
        /// <summary>
        /// 是否检查失效项
        /// </summary>
        public bool IsInspectItem { get; set; }

        public SubWIPIDCode_TSItem Clone()
        {
            return MemberwiseClone() as SubWIPIDCode_TSItem;
        }
    }
}
