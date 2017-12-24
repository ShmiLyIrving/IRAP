using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.IO;

using IRAP.Global;

namespace IRAPGeneralGateway.Entities
{
    public class TExCodes
    {
        private static TExCodes _instance = null;

        public static TExCodes Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TExCodes();
                return _instance;
            }
        }

        private Dictionary<string, TExCodeEntity> excodes = new Dictionary<string, TExCodeEntity>();

        private TExCodes() { }

        public Dictionary<string, TExCodeEntity> ExCodes
        {
            get { return excodes; }
        }

        public void AddItem(TExCodeEntity exCode)
        {
            if (excodes.ContainsKey(exCode.ExCode))
                excodes.Add(exCode.ExCode, exCode);
        }

        /// <summary>
        /// 从 XML 节点的子节点中导入已注册的交易代码列表
        /// </summary>
        /// <param name="parentNode">XML 节点(ExCodes)</param>
        public void Load(XmlNode parentNode)
        {
            foreach (XmlNode node in parentNode.ChildNodes)
            {
                TExCodeEntity exCode = new TExCodeEntity();
                exCode = IRAPXMLUtils.LoadValueFromXMLNode(node, exCode) as TExCodeEntity;

                AddItem(exCode);
            }
        }

        /// <summary>
        /// 从指定文件名的 XML 文件中导入已注册的交易代码列表
        /// </summary>
        /// <param name="dataFileName">交易代码列表所在的 XML 文件名</param>
        public void Load(string dataFileName)
        {
            excodes.Clear();

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

            XmlNode parentNode = xml.SelectSingleNode("root/Configuration/ExCodes");
            if (parentNode != null)
            {
                Load(parentNode);
            }
            else
            {
                Debug.WriteLine("配置文件中没有找到 root/Configuration/ExCodes 节点(请注意大小写)");
            }
        }

        /// <summary>
        /// 将注册到内存中的交易代码列表持久化到指定的本地 XML 文件中
        /// </summary>
        /// <param name="dataFileName">持久化的本地 XML 文件名</param>
        public void Save(string dataFileName)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode rootNode = null;
            
            if (!File.Exists(dataFileName))
            {
                xml.AppendChild(xml.CreateXmlDeclaration("1.0", "utf-8", ""));
                rootNode = xml.AppendChild(xml.CreateElement("root"));
                rootNode = rootNode.AppendChild(xml.CreateElement("Configuration"));
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

                rootNode = xml.SelectSingleNode("root/Configuration");
                if (rootNode == null)
                {
                    Debug.WriteLine(
                        string.Format(
                            "[{0}] 文件中不存在 root/Configuration 根节点"));
                    return;
                }
            }

            // 在 rootNode 的第一层子节点中查找 ExCodes 节点，如果没有找到则创建
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Name == "ExCodes")
                {
                    rootNode.RemoveChild(node);
                }
            }

            XmlNode excodeNode = xml.CreateElement("ExCodes");
            rootNode.AppendChild(excodeNode);

            foreach (TExCodeEntity excode in excodes.Values)
            {
                XmlNode node = xml.CreateElement("ExCode");
                node = IRAPXMLUtils.GenerateXMLAttribute(node, excode);
                excodeNode.AppendChild(node);
            }

            xml.Save(dataFileName);
        }
    }
}
