using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.FVS
{
    public class OpenAndonEvent
    {
        /// <summary>
        /// 事实分区键
        /// </summary>
        public long PartitioningKey { get; set; }
        /// <summary>
        /// 事件标识
        /// </summary>
        public long EventID { get; set; }
        /// <summary>
        /// 事件类型叶标识
        /// </summary>
        public int T179LeafID { get; set; }
        /// <summary>
        /// 呼叫资源类型(211-工作中心 134-产线)
        /// </summary>
        public int ResourceTreeID { get; set; }
        /// <summary>
        /// 呼叫资源叶标识
        /// </summary>
        public int ResourceLeafID { get; set; }
        /// <summary>
        /// 呼叫资源描述
        /// </summary>
        public string ResourceName { get; set; }
        /// <summary>
        /// 是否停产
        /// </summary>
        public bool ProductionDown { get; set; }
        /// <summary>
        /// 已过时长(s)
        /// </summary>
        public int ElapsedSeconds { get; set; }
        /// <summary>
        /// 是否已响应
        /// </summary>
        public bool OnSiteResponded { get; set; }

        public OpenAndonEvent Clone()
        {
            return MemberwiseClone() as OpenAndonEvent;
        }

        public override string ToString()
        {
            return
                string.Format(
                    "[{0}][{1}]{2}",
                    ProductionDown ? "已停产" : "未停产",
                    OnSiteResponded ? "已响应" : "未响应",
                    ResourceName);
        }
    }
}
