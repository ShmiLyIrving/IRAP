using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Reflection;

using IRAP.OPC.Entity;
using IRAP.Global;

namespace IRAP.OPC.Library
{
    public class TIRAPLocOPCDevices
    {
        private static TIRAPLocOPCDevices _instance = null;

        public static TIRAPLocOPCDevices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TIRAPLocOPCDevices();
                return _instance;
            }
        }

        private List<TIRAPOPCLocDevice> items = new List<TIRAPOPCLocDevice>();

        private TIRAPLocOPCDevices() { }

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

        public List<TIRAPOPCLocDevice> Devices
        {
            get { return items; }
        }

        public int Count
        {
            get { return items.Count; }
        }

        /// <summary>
        /// 新增一个设备及其标签信息
        /// </summary>
        /// <param name="device">设备及其标签信息对象</param>
        /// <param name="dataFileName"></param>
        /// <returns></returns>
        public int Add(TIRAPOPCLocDevice device, string dataFileName)
        {
            ModifyDataFile(1, device, dataFileName);
            items.Add(device);

            return items.Count - 1;
        }

        public void Modify(TIRAPOPCLocDevice device, string dataFileName)
        {
            ModifyDataFile(1, device, dataFileName);
            TIRAPOPCLocDevice old = GetDeviceWithDeviceCode(device.DeviceCode);
            items.Remove(old);
            items.Add(device);
        }

        /// <summary>
        /// 删除指定设备代码的设备及其标签信息
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="dataFileName"></param>
        public void Remove(string deviceCode, string dataFileName)
        {
            TIRAPOPCLocDevice findRlt = null;
            foreach (TIRAPOPCLocDevice item in items)
            {
                if (item.DeviceCode == deviceCode)
                {
                    findRlt = item;
                    break;
                }
            }
            if (findRlt != null)
            {
                ModifyDataFile(2, findRlt, dataFileName);
                items.Remove(findRlt);
            }
            else
            {
                Exception error = new Exception();
                error.Data["ErrCode"] = "900201";
                error.Data["ErrText"] = string.Format("编号为[{0}]的设备未在系统中注册", deviceCode);
                throw error;
            }
        }

        /// <summary>
        /// 编辑指定设备及其标签信息
        /// </summary>
        /// <param name="type">编辑类别：1-保存；2-删除</param>
        /// <param name="device">设备对象</param>
        /// <param name="dataFileName">本地持久化文件名</param>
        public void ModifyDataFile(int type, TIRAPOPCLocDevice device, string dataFileName)
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
                IRAPXMLUtils.GetChildNodeWithPropertyValue(
                    devicesNode,
                    "DeviceCode",
                    device.DeviceCode);
            if (deviceNode != null)
            {
                devicesNode.RemoveChild(deviceNode);
            }

            if (type == 1)
            {
                #region 添加设备节点
                deviceNode = xml.ImportNode(device.GenerateXMLNode(), true);
                devicesNode.AppendChild(deviceNode);
                #endregion
            }

            // 保存 XML 到文件
            xml.Save(dataFileName);
        }

        /// <summary>
        /// 从指定的 XML 文件中加载设备的 OPC 标签信息
        /// </summary>
        /// <param name="dataFileName"></param>
        public void Load(string dataFileName)
        {
            items.Clear();

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
                TIRAPOPCLocDevice device = TIRAPOPCLocDevice.LoadFromXMLNode(child);
                if (device != null)
                    items.Add(device);
            }
        }

        /// <summary>
        /// 根据设备代码获取设备对象
        /// </summary>
        /// <param name="code">设备代码</param>
        /// <returns>设备对象</returns>
        public TIRAPOPCLocDevice GetDeviceWithDeviceCode(string code)
        {
            foreach (TIRAPOPCLocDevice device in items)
            {
                if (device.DeviceCode == code)
                    return device;
            }
            return null;
        }
    }
}
