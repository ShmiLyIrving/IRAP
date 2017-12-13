using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Reflection;

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
        /// <param name="parentNode">节点</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="propertyValue">属性值</param>
        /// <returns>子节点</returns>
        private XmlNode GetChildNodeWithPropertyValue(
            XmlNode parentNode,
            string propertyName,
            string propertyValue)
        {
            foreach (XmlNode node in parentNode.ChildNodes)
            {
                if (node.Attributes[propertyName] != null)
                {
                    if (node.Attributes[propertyName].Value == propertyValue)
                        return node;
                }
            }
            return null;
        }

        /// <summary>
        /// 在节点中增加属性
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="attrName">属性名</param>
        /// <param name="attrValue">属性值</param>
        /// <returns></returns>
        private XmlNode AddNodeAttribute(XmlNode node, string attrName, string attrValue)
        {
            XmlAttribute attr = node.OwnerDocument.CreateAttribute(attrName);
            attr.Value = attrValue;
            node.Attributes.Append(attr);

            return node;
        }

        public List<TIRAPOPCDevice> Devices
        {
            get { return opcDevices; }
        }

        public int Count
        {
            get { return opcDevices.Count; }
        }

        public int Add(TIRAPOPCDevice device, string dataFileName)
        {
            opcDevices.Add(device);
            Save(device, dataFileName);

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
                    GetChildNodeWithPropertyValue(
                        devicesNode,
                        "DeviceCode", 
                        device.DeviceCode);
                if (deviceNode != null)
                {
                    devicesNode.RemoveChild(deviceNode);
                }

                #region 添加设备节点
                deviceNode = xml.ImportNode(device.GenerateXMLNode(), true);
                devicesNode.AppendChild(deviceNode);
                #endregion

                // 保存 XML 到文件
                xml.Save(dataFileName);
            }
        }

        /// <summary>
        /// 从指定的 XML 文件中加载设备的 OPC 标签信息
        /// </summary>
        /// <param name="dataFileName"></param>
        public void Load(string dataFileName)
        {
            opcDevices.Clear();

            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(dataFileName);
            }
            catch (Exception error)
            {
                Debug.WriteLine(string.Format("加载[{0}]文件时出错：[{1}]", dataFileName, error.Message));
                return;
            }

            XmlNode devicesNode = xml.SelectSingleNode("root/Devices");
            if (devicesNode == null)
            {
                Debug.WriteLine("文件[{0}]中没有 Devices 节点。");
                return;
            }

            foreach (XmlNode child in devicesNode.ChildNodes)
            {
                TIRAPOPCDevice device = TIRAPOPCDevice.LoadFromXMLNode(child);
                if (device != null)
                    opcDevices.Add(device);
            }
        }

        /// <summary>
        /// 根据设备代码获取设备对象
        /// </summary>
        /// <param name="code">设备代码</param>
        /// <returns>设备对象</returns>
        public TIRAPOPCDevice GetDeviceWithDeviceCode(string code)
        {
            foreach (TIRAPOPCDevice device in opcDevices)
            {
                if (device.DeviceCode == code)
                    return device;
            }
            return null;
        }
    }
}
