using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.WebService.Client.UES
{
    /// <summary>
    /// 在制品标识信息
    /// </summary>
    public class EntityWIPIDInfo
    {
        public string ExCode { get; set; }
        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 系统登录标识
        /// </summary>
        public long SysLogID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 在制品主标识代码
        /// </summary>
        public string WIPCode { get; set; }
        /// <summary>
        /// 在制品副标识代码
        /// </summary>
        public string AltWIPCode { get; set; }
        /// <summary>
        /// 在制品序列号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 生产批次号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 生产工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 在制品容器编号
        /// </summary>
        public string ContainerNo { get; set; }
        /// <summary>
        /// 子在制品数
        /// </summary>
        public int NumSubWIPs { get; set; }
        /// <summary>
        /// 在制品数量
        /// </summary>
        public long WIPQty { get; set; }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }
        /// <summary>
        /// 工位代码
        /// </summary>
        public string WIPStationCode { get; set; }
        /// <summary>
        /// 工序代码
        /// </summary>
        public string OperationCode { get; set; }
        /// <summary>
        /// 到达本工序时间(yyyy-mm-dd hh:mm:ss.fff
        /// </summary>
        public string MoveInTime { get; set; }
        /// <summary>
        /// 进入队列时间(yyyy-mm-dd hh:mm:ss.fff
        /// </summary>
        public string QueueInTime { get; set; }
        public int T133LeafID { get; set; }
        public int T216LeafID { get; set; }
        public int T20LeafID { get; set; }
        public int T47LeafID { get; set; }
        public long LCL { get; set; }
        public long UCL { get; set; } 

        public EntityWIPIDInfo Clone()
        {
            return MemberwiseClone() as EntityWIPIDInfo;
        }
    }
}
