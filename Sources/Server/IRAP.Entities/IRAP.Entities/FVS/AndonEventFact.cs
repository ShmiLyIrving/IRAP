using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.FVS
{
    public class AndonEventFact
    {
        private string respondUserCode = "";
        private string respondUserName = "";

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
        public string RespondUserCode
        {
            get
            {
                if (RespondingTime.Trim() == "")
                    return "";
                else
                    return respondUserCode;
            }
            set { respondUserCode = value; }
        }
        /// <summary>
        /// 责任人姓名
        /// </summary>
        public string RespondUserName
        {
            get
            {
                if (RespondingTime.Trim() == "")
                    return "";
                else
                    return respondUserName;
            }
            set { respondUserName = value; }
        }
        /// <summary>
        /// 呼叫时间
        /// </summary>
        public string CallingTime { get; set; }
        /// <summary>
        /// 响应时间
        /// </summary>
        public string RespondingTime { get; set; }
        /// <summary>
        /// 关闭时间
        /// </summary>
        public string ClosingTime { get; set; }

        /// <summary>
        /// 安灯关闭时间
        /// </summary>
        [IRAPORMMap(ORMMap =false)]
        public string EventClosingTime
        {
            get
            {
                if (RespondingTime.Trim() == "")
                    return "";
                else
                    return ClosingTime;
            }
        }
        /// <summary>
        /// 安灯取消时间
        /// </summary>
        /// <remarks>
        /// 如果响应时间为空白，则关闭时间就是取消时间
        /// </remarks>
        [IRAPORMMap(ORMMap = false)]
        public string EventCancelTime
        {
            get
            {
                if (RespondingTime.Trim() == "")
                    return ClosingTime;
                else
                    return "";
            }
        }

        public AndonEventFact Clone()
        {
            return MemberwiseClone() as AndonEventFact;
        }
    }
}
