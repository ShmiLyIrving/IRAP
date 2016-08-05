using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    public class WIPStationSPCMonitor
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工位叶标识
        /// </summary>
        public int T107LeafID { get; set; }
        /// <summary>
        /// 工位实体标识
        /// </summary>
        public int T107EntityID { get; set; }
        /// <summary>
        /// 工位代码
        /// </summary>
        public string T107Code { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string T107Name { get; set; }
        /// <summary>
        /// 正在生产的产品叶标识
        /// </summary>
        public int T102LeafID_InProduction { get; set; }
        /// <summary>
        /// 正在生产的产品编号
        /// </summary>
        public string T102Code_InProduction { get; set; }
        /// <summary>
        /// 正在执行的生产工单号
        /// </summary>
        public string PWONo_InExecution { get; set; }
        /// <summary>
        /// 正在执行工单签发时间
        /// </summary>
        public int PWOCreatedUnixTime_Current { get; set; }
        /// <summary>
        /// 待加工容器编号
        /// </summary>
        public string ContainerNo { get; set; }
        /// <summary>
        /// 已加工容器编号
        /// </summary>
        public string ContainerNo_Output { get; set; }
        /// <summary>
        /// 工位图片
        /// </summary>
        public byte[] T107Image { get; set; }
        /// <summary>
        /// 正在生产的工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }
        /// <summary>
        /// 正在生产的设备叶标识
        /// </summary>
        public int T133LeafID { get; set; }
        /// <summary>
        /// SPC控制图类型：
        /// 0=不控制；
        /// 373564=彩虹图；
        /// 373565=XBar-R图
        /// </summary>
        public int T47LeafID { get; set; }
        /// <summary>
        /// SPC控制的参数叶标识
        /// </summary>
        public int T20LeafID { get; set; }
        /// <summary>
        /// 控制线下限（XBar-R图有效）
        /// </summary>
        public long LCL { get; set; }
        /// <summary>
        /// 控制线上限（XBar-R图有效）
        /// </summary>
        public long UCL { get; set; }
        /// <summary>
        /// 控制线设置日期
        /// </summary>
        public string CLSetDate { get; set; }
        /// <summary>
        /// 过程检超时告警阀门值(ms)
        /// </summary>
        public long TimeOutThreshold { get; set; }

        public WIPStationSPCMonitor Clone()
        {
            WIPStationSPCMonitor rlt = MemberwiseClone() as WIPStationSPCMonitor;

            return rlt;
        }
    }
}