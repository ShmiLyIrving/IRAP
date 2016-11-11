using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.FVS
{
    public class Func_EventsToConsultation
    {
        /// <summary>
        /// 事件标识
        /// </summary>
        public long EventFactID { get; set; }
        /// <summary>
        /// 事件类型
        /// </summary>
        public string  EventType { get; set; }
        /// <summary>
        /// 事件类型代码
        /// </summary>
        public string EventCode { get; set; }
        /// <summary>
        /// 事件描述
        /// </summary>
        public string EventDescription { get; set; }
        /// <summary>
        /// 对象实例
        /// </summary>
        public string WFInstanceID { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 干系人工号
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 干系人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 响应时间（00:00）
        /// </summary>
        public string RespondedTime { get; set; }

        public Func_EventsToConsultation Clone()
        {
            return MemberwiseClone() as Func_EventsToConsultation;
        }
    }

    /// <summary>
    /// 正在进行会诊的安灯事件
    /// </summary>
    public class EventToConsultation
    {
        private List<Stakeholder> stakeholders = new List<Stakeholder>();

        /// <summary>
        /// 事件标识
        /// </summary>
        public long EventFactID { get; set; }
        /// <summary>
        /// 事件类型
        /// </summary>
        public string EventType { get; set; }
        /// <summary>
        /// 事件类型代码
        /// </summary>
        public string EventCode { get; set; }
        /// <summary>
        /// 事件描述
        /// </summary>
        public string EventDescription { get; set; }
        /// <summary>
        /// 对象实例
        /// </summary>
        public string WFInstanceID { get; set; }


        public List<Stakeholder> Stakeholders
        {
            get { return stakeholders; }
        }

        public EventToConsultation Clone()
        {
            EventToConsultation rlt = MemberwiseClone() as EventToConsultation;

            return rlt;
        }

        public override string ToString()
        {
            return EventDescription;
        }
    }

    public class Stakeholder
    {
        /// <summary>
        /// 角色
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 干系人工号
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 干系人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 响应时间（00:00）
        /// </summary>
        public string RespondedTime { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Choice { get; set; }

        public Stakeholder Clone()
        {
            return MemberwiseClone() as Stakeholder;
        }
    }
}
