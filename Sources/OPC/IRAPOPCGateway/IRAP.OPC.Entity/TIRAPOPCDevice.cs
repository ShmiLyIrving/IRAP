using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.OPC.Entity
{
    public class TIRAPOPCDevice
    {
        private List<KepDeviceTagInfo> tags = new List<KepDeviceTagInfo>();

        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceCode { get; set; }
        /// <summary>
        /// KepServer IP 地址
        /// </summary>
        public string KepServerAddr { get; set; }
        /// <summary>
        /// KepServer 名称
        /// </summary>
        public string KepServerName { get; set; }

        public List<KepDeviceTagInfo> Tags
        {
            get { return tags; }
        }
    }

    public class KepDeviceTagInfo
    {
        public string TagName { get; set; }
        public string Address { get; set; }
        public string DataType { get; set; }
        public string RespectDataType { get; set; }
        public string ClientAccess { get; set; }
        public string ScanRate { get; set; }
        public string Scaling { get; set; }
        public string RawLow { get; set; }
        public string RawHigh { get; set; }
        public string ScaledLow { get; set; }
        public string ScaledHigh { get; set; }
        public string ScaledDataType { get; set; }
        public string ClampLow { get; set; }
        public string ClampHigh { get; set; }
        public string EngUnits { get; set; }
        public string Description { get; set; }
        public string NegateValue { get; set; }
        /// <summary>
        /// 实时标签值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 标签值取得时间
        /// </summary>
        public string Timestamp { get; set; }
        /// <summary>
        /// 质量
        /// </summary>
        public string Quality { get; set; }
    }
}
