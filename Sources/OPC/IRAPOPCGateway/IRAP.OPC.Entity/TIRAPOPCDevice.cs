using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;

using IRAP.Global;
using IRAP.Interface.OPC;

namespace IRAP.OPC.Entity
{
    public class TIRAPOPCDevice
    {
        private List<TIRAPOPCKepDeviceTagInfo> tags = new List<TIRAPOPCKepDeviceTagInfo>();

        public TIRAPOPCDevice() { }

        public TIRAPOPCDevice(TUpdateDeviceTagsReqBody request)
        {
            DeviceCode = request.DeviceCode;
            DeviceName = request.DeviceName;
            KepServerAddr = request.KepServAddr;
            KepServerName = request.KepServName;
            KepServerChannel = request.KepServChannel;
            KepServerDevice = request.KepServDevice;

            string prefix = string.Format("{0}.{1}", KepServerChannel, KepServerDevice);
            foreach (TUpdateDeviceTagsReqDetail detail in request.Details)
            {
                tags.Add(new TIRAPOPCKepDeviceTagInfo(detail, prefix));
            }
        }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceCode { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// KepServer IP 地址
        /// </summary>
        public string KepServerAddr { get; set; }
        /// <summary>
        /// KepServer 名称
        /// </summary>
        public string KepServerName { get; set; }
        /// <summary>
        /// KepServer 定义的 Channel
        /// </summary>
        public string KepServerChannel { get; set; }
        /// <summary>
        /// KepServer 定义的 Device
        /// </summary>
        public string KepServerDevice { get; set; }

        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public List<TIRAPOPCKepDeviceTagInfo> Tags
        {
            get { return tags; }
        }

        public XmlNode GenerateXMLNode()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode node = xml.CreateElement("Device");

            node = IRAPXMLUtils.GenerateXMLAttribute(node, this);
            foreach (TIRAPOPCKepDeviceTagInfo tag in tags)
            {
                node.AppendChild(xml.ImportNode(tag.GenerateXMLNode(), true));
            }

            return node;
        }

        public static TIRAPOPCDevice LoadFromXMLNode(XmlNode node)
        {
            if (node.Name == "Device")
            {
                TIRAPOPCDevice device = new TIRAPOPCDevice();
                device = IRAPXMLUtils.LoadValueFromXMLNode(node, device) as TIRAPOPCDevice;

                foreach (XmlNode child in node.ChildNodes)
                {
                    TIRAPOPCKepDeviceTagInfo tag = TIRAPOPCKepDeviceTagInfo.LoadFromXMLNode(child);
                    if (tag != null)
                        device.Tags.Add(tag);
                }

                return device;
            }
            else
                return null;
        }
    }
}
