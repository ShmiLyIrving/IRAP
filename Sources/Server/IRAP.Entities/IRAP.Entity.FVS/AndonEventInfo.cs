using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class AndonEventInfo
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

        public override string ToString()
        {
            return string.Format("{0}:{1}", CallingTime, EventDescription);
        }

        public AndonEventInfo Clone()
        {
            AndonEventInfo rlt = MemberwiseClone() as AndonEventInfo;

            return rlt;
        }
    }
}