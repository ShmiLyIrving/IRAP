using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    /// <summary>
    /// 待关闭的安灯事件
    /// </summary>
    public class AndonEventToClose
    {
        /// <summary>
        /// 安灯事件标识
        /// </summary>
        public long EventFactID { get; set; }
        /// <summary>
        /// 安灯事件类型
        /// </summary>
        public string EventType { get; set; }
        /// <summary>
        /// 安灯事件描述
        /// </summary>
        public string EventDescription { get; set; }
        /// <summary>
        /// 是否已停产
        /// </summary>
        public bool ProductionDown { get; set; }
        /// <summary>
        /// 呼叫时间
        /// </summary>
        public string CallingTime { get; set; }
        /// <summary>
        /// 响应时间
        /// </summary>
        public string RespondingTime { get; set; }
        /// <summary>
        /// 第一响应人
        /// </summary>
        public string FirstResponder { get; set; }
        /// <summary>
        /// 已过时间（分钟）
        /// </summary>
        public int TimeElapsed { get; set; }
        /// <summary>
        /// 业务操作标识
        /// </summary>
        public int OpID { get; set; }
        /// <summary>
        /// 关联的停线事件
        /// </summary>
        public long StopEventFactID { get; set; }

        public AndonEventToClose Clone()
        {
            AndonEventToClose rlt = MemberwiseClone() as AndonEventToClose;

            return rlt;
        }
    }
}