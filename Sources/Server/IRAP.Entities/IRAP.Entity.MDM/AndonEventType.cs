using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 安灯事件类型
    /// </summary>
    public class AndonEventType
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 事件类型叶标识
        /// </summary>
        public int EventTypeLeaf { get; set; }
        /// <summary>
        /// 事件类型代码
        /// </summary>
        public string EventTypeCode { get; set; }
        /// <summary>
        /// 事件类型名称
        /// </summary>
        public string EventTypeName { get; set; }
        /// <summary>
        /// 呼叫对象选项标题
        /// </summary>
        public string CaptionName { get; set; }
        /// <summary>
        /// 是否可用（被许可）
        /// </summary>
        public bool Available { get; set; }
        /// <summary>
        /// 当前产线该事件类型被呼叫状态：
        /// 0-禁用（灰色）；
        /// 1-无事件（绿色）；
        /// 2-有非停线事件（黄色）；
        /// 3-有停线事件（红色）。
        /// </summary>
        public int Status { get; set; }

        public override string ToString()
        {
            return EventTypeName;
        }

        public AndonEventType Clone()
        {
            return MemberwiseClone() as AndonEventType;
        }
    }
}