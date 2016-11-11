using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.FVS
{
    /// <summary>
    /// 已经响应的安灯事件信息
    /// </summary>
    public class AndonRspedEventInfo
    {
        /// <summary>
        /// 事件标识
        /// </summary>
        public long EventFactID { get; set; }
        /// <summary>
        /// 事件类型
        /// </summary>
        public string EventType { get; set; }
        /// <summary>
        /// 事件描述
        /// </summary>
        public string EventDescription { get; set; }
        /// <summary>
        /// 是否已停产
        /// </summary>
        public bool ProductionDown { get; set; }
        /// <summary>
        /// 呼叫时间(hh:mm)
        /// </summary>
        public string CallingTime { get; set; }
        /// <summary>
        /// 已过时长(分钟)
        /// </summary>
        public int TimeElapsed { get; set; }
        /// <summary>
        /// 业务操作标识
        /// </summary>
        public int OpID { get; set; }
        /// <summary>
        /// 安灯事件隶属关系：
        /// 0-通知了别人，但我可响应；
        /// 1-通知我的，还未响应；
        /// 2-别人已响应，但追加呼叫我的
        /// </summary>
        public int AndonEventOwnership { get; set; }

        public AndonRspedEventInfo Clone()
        {
            return MemberwiseClone() as AndonRspedEventInfo;
        }

        public override string ToString()
        {
            return EventDescription;
        }
    }
}