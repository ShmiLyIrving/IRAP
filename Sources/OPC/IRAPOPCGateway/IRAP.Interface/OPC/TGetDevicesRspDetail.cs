using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TGetDevicesRspDetail
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 设备代码
        /// </summary>
        public string DeviceCode { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// KepServer的IP地址
        /// </summary>
        public string KepServAddr { get; set; }
        /// <summary>
        /// KepServer的服务器名称
        /// </summary>
        public string KepServName { get; set; }
        /// <summary>
        /// KepServer中定义的Channel
        /// </summary>
        public string KepServChannel { get; set; }
        /// <summary>
        /// KepServer中定义的Device
        /// </summary>
        public string KepServDevice { get; set; }

        public TGetDevicesRspDetail Clone()
        {
            return MemberwiseClone() as TGetDevicesRspDetail;
        }

        public XmlNode GenerateXMLNode(XmlNode row)
        {
            return IRAPXMLUtils.GenerateXMLAttribute(row, this);
        }
    }
}
