using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.FVS
{
    public class AndonEventFact
    {
        /// <summary>
        /// 事件标识
        /// </summary>
        public long EventFactID { get; set; }
        /// <summary>
        /// 事件叶标志
        /// </summary>
        public string EventLeafID { get; set; }
        /// <summary>
        /// 事件代码
        /// </summary>
        public string EventCode { get; set; }
        /// <summary>
        /// 事件名称
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// 事件描述
        /// </summary>
        public string EventDescription { get; set; }
        /// <summary>
        /// 呼叫人编号
        /// </summary>
        public string CallUserCode { get; set; }
        /// <summary>
        /// 呼叫人姓名
        /// </summary>
        public string CallUserName { get; set; }
        /// <summary>
        /// 责任人编号
        /// </summary>
        public string RespondUserCode { get; set; }
        /// <summary>
        /// 责任人姓名
        /// </summary>
        public string RespondUserName { get; set; }
        /// <summary>
        /// 呼叫时间
        /// </summary>
        public DateTime CallingTime { get; set; }
        /// <summary>
        /// 响应时间
        /// </summary>
        public DateTime RespondingTime { get; set; }
        /// <summary>
        /// 关闭时间
        /// </summary>
        public DateTime ClosingTime { get; set; }

        public AndonEventFact Clone()
        {
            return MemberwiseClone() as AndonEventFact;
        }
    }
}
