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
    public class TDBConnections
    {
        private static TDBConnections _instance = null;

        public static TDBConnections Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TDBConnections();
                return _instance;
            }
        }

        private List<TEntityDBConnection> dbs = new List<TEntityDBConnection>();

        private TDBConnections()
        {
            Load(TIRAPWebAPIGlobal.Instance.ConfigurationFile);
        }

        /// <summary>
        /// 从 XML 节点的子节点中导入已注册的交易代码列表
        /// </summary>
        /// <param name="parentNode">XML 节点(ExCodes)</param>
        public void Load(XmlNode parentNode)
        {
            foreach (XmlNode node in parentNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    TEntityDBConnection connection = new TEntityDBConnection();
                    connection =
                        IRAPXMLUtils.LoadValueFromXMLNode(
                            node,
                            connection) as TEntityDBConnection;

                    dbs.Add(connection);
                }
            }
        }

        /// <summary>
        /// 从指定文件名的 XML 文件中导入已注册的交易代码列表
        /// </summary>
        /// <param name="dataFileName">交易代码列表所在的 XML 文件名</param>
        public void Load(string dataFileName)
        {
            dbs.Clear();

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

            XmlNode parentNode = xml.SelectSingleNode("root/Configuration/DBConnections");
            if (parentNode != null)
            {
                Load(parentNode);
            }
            else
            {
                Debug.WriteLine("配置文件中没有找到 root/Configuration/DBConnections 节点(请注意大小写)");
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
                if (node.Name == "DBConnections")
                {
                    rootNode.RemoveChild(node);
                }
            }

            XmlNode excodeNode = xml.CreateElement("DBConnections");
            rootNode.AppendChild(excodeNode);

            foreach (TEntityDBConnection connection in dbs)
            {
                XmlNode node = xml.CreateElement("Connection");
                node = IRAPXMLUtils.GenerateXMLAttribute(node, connection);
                excodeNode.AppendChild(node);
            }

            xml.Save(dataFileName);
        }

        /// <summary>
        /// 获取第一个可用的数据库连接配置
        /// </summary>
        public TEntityDBConnection GetFirstConnection()
        {
            if (dbs.Count > 0)
                return dbs[0];
            else
            {
                return new TEntityDBConnection()
                {
                    DBType = "SQLServer",
                    ConnectionString = "Server=192.168.57.221;initial catalog=IRAP;UID=sa;"+
                        "Password=irap!209420;Min Pool Size=2;Max Pool Size=60;",
                    Encrypt = false,
                };
            }
        }
    }
}
