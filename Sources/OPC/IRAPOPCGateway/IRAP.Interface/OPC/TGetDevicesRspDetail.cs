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
        /// KepServer的IP地址
        /// </summary>
        public string KepServerAddr { get; set; }
        /// <summary>
        /// KepServer的服务器名称
        /// </summary>
        public string KepServerName { get; set; }
        /// <summary>
        /// KepServer中定义的Channel
        /// </summary>
        public string KepServerChannel { get; set; }
        /// <summary>
        /// KepServer中定义的Device
        /// </summary>
        public string KepServerDevice { get; set; }

        public TGetDevicesRspDetail Clone()
        {
            return MemberwiseClone() as TGetDevicesRspDetail;
        }

        public XmlNode GenerateXMLNode(XmlNode row)
        {
            return IRAPXMLUtils.GenerateXMLAttribute(row, this);
        }
        public static TGetDevicesRspDetail LoadFromXMLNode(XmlNode node)
        {
            if (node.Name != "Row")
                return null;

            TGetDevicesRspDetail rlt = new TGetDevicesRspDetail();
            rlt = IRAPXMLUtils.LoadValueFromXMLNode(node, rlt) as TGetDevicesRspDetail;
            return rlt;
        }
    }
}
