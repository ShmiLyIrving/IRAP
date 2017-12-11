using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;

using IRAP.OPC.Entity;

namespace IRAP.OPC.Library
{
    public class TIRAPOPCDevices
    {
        private static TIRAPOPCDevices _instance = null;

        public static TIRAPOPCDevices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TIRAPOPCDevices();
                return _instance;
            }
        }

        private List<TIRAPOPCDevice> opcDevices = new List<TIRAPOPCDevice>();

        private TIRAPOPCDevices() { }

        /// <summary>
        /// 在节点的子节点中查找指定属性名和值的子节点
        /// </summary>
        /// <param name="nodes">节点</param>
        /// <param name="childName">子节点名</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="deviceCode"></param>
        /// <returns>子节点</returns>
        private XmlNode GetDeviceNodeWithDeviceCode(
            XmlNode nodes,
            string childName,
            string propertyName, 
            string deviceCode)
        {
            XmlNode rlt = null;

            foreach (XmlNode node in nodes)
            {
                if (node.Name == childName)
                {
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        if (childNode.Name == propertyName)
                        {
                            if (childNode.InnerText == deviceCode)
                            {
                                rlt = node;
                                break;
                            }
                        }
                    }

                    if (rlt != null)
                        break;
                }
            }

            return rlt;
        }

        /// <summary>
        /// 在节点中增加子节点
        /// </summary>
        /// <param name="parentNode">父节点</param>
        /// <param name="nodeName">子节点名</param>
        /// <param name="innerText">子节点值</param>
        /// <returns></returns>
        private XmlNode AddChildNode(XmlNode parentNode, string nodeName, string innerText)
        {
            XmlNode child = parentNode.OwnerDocument.CreateElement(nodeName);
            child.InnerText = innerText;
            parentNode.AppendChild(child);

            return child;
        }

        public List<TIRAPOPCDevice> Devices
        {
            get { return opcDevices; }
        }

        public int Count
        {
            get { return opcDevices.Count; }
        }

        public int Add(TIRAPOPCDevice device)
        {
            opcDevices.Add(device);
            return opcDevices.Count - 1;
        }

        /// <summary>
        /// 保存指定设备的 OPC 标签信息
        /// </summary>
        /// <param name="device"></param>
        public void Save(TIRAPOPCDevice device, string dataFileName)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode rootNode = null;

            if (!File.Exists(dataFileName))
            {
                xml.AppendChild(xml.CreateXmlDeclaration("1.0", "utf-8", ""));
                rootNode = xml.CreateElement("root");
                xml.AppendChild(rootNode);
            }
            else
            {
                try
                {
                    xml.Load(dataFileName);
                }
                catch (Exception error)
                {
                    Debug.WriteLine(string.Format("加载[{0}]文件时出错：[{1}]", dataFileName, error.Message));
                    return;
                }

                rootNode = xml.SelectSingleNode("root");
                if (rootNode == null)
                {
                    Debug.WriteLine(
                        string.Format(
                            "[{0}] 文件中不存在 root 根节点"));
                    return;
                }

                // 在第一层子节点中查找 Device 节点，若没有找到则创建该节点
                XmlNode devicesNode = null;
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    if (node.Name == "Devices")
                    {
                        devicesNode = node;
                        break;
                    }
                }
                if (devicesNode == null)
                {
                    devicesNode = xml.CreateElement("Devices");
                    rootNode.AppendChild(devicesNode);
                }

                // 在 Devices 节点中查找指定 DeviceCode 的 Device 子节点，如果找到则从 Devices 节点中删除
                XmlNode deviceNode = 
                    GetDeviceNodeWithDeviceCode(
                        devicesNode,
                        "Device",
                        "DeviceCode", 
                        device.DeviceCode);
                if (deviceNode != null)
                {
                    devicesNode.RemoveChild(deviceNode);
                }

                // 添加设备节点
                deviceNode = xml.CreateElement("Device");
                devicesNode.AppendChild(deviceNode);

                AddChildNode(deviceNode, "DeviceCode", device.DeviceCode);
                AddChildNode(deviceNode, "KepServerAddr", device.KepServerAddr);
                AddChildNode(deviceNode, "KepServerName", device.KepServerName);

                // 保存 XML 到文件
                xml.Save(dataFileName);
            }
        }
    }
}
