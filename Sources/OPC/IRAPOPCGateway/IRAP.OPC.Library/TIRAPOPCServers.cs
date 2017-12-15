using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.IO;

using IRAP.OPC.Entity;
using IRAP.Global;

namespace IRAP.OPC.Library
{
    public class TIRAPOPCServers
    {
        private static TIRAPOPCServers _instance = null;

        public static TIRAPOPCServers Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TIRAPOPCServers();
                return _instance;
            }
        }

        private List<TIRAPOPCServer> servers = new List<TIRAPOPCServer>();

        private TIRAPOPCServers() { }

        public List<TIRAPOPCServer> Servers
        {
            get { return servers; }
        }

        /// <summary>
        /// 从指定的持久化文件中加载 KepwareServer 信息
        /// </summary>
        /// <param name="cfgFileName"></param>
        /// <returns></returns>
        public int LoadFromDataFile(string cfgFileName)
        {
            servers.Clear();

            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(cfgFileName);
            }
            catch (Exception error)
            {
                Debug.WriteLine(string.Format("加载[{0}]文件时出错：[{1}]", cfgFileName, error.Message));
                return servers.Count;
            }

            XmlNode parentNode = xml.SelectSingleNode("root/OPCServers");
            if (parentNode != null)
            {
                foreach (XmlNode child in parentNode.ChildNodes)
                {
                    TIRAPOPCServer server = TIRAPOPCServer.LoadFromXMLNode(child);
                    if (server != null)
                        servers.Add(server);
                }
            }
            else
            {
                Debug.WriteLine("配置文件中没有找到 root/OPCServers 节点(请注意大小写)");
            }

            return servers.Count;
        }

        /// <summary>
        /// 将 KepwareServer 信息持久化
        /// </summary>
        /// <param name="type">编辑类别：1-保存；2-删除</param>
        /// <param name="server">KepwareServer对象</param>
        /// <param name="dataFileName">本地持久化文件名</param>
        public void ModifyDataFile(int type, TIRAPOPCServer server, string dataFileName)
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
            XmlNode serversNode = null;
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Name == "OPCServers")
                {
                    serversNode = node;
                    break;
                }
            }
            if (serversNode == null)
            {
                serversNode = xml.CreateElement("OPCServers");
                rootNode.AppendChild(serversNode);
            }

            // 在 OPCServers 节点中查找指定 Address 的 OPCServer 子节点，如果找到则从 Devices 节点中删除
            XmlNode serverNode =
                IRAPXMLUtils.GetChildNodeWithPropertyValue(
                    serversNode,
                    server);
            if (serverNode != null)
            {
                serversNode.RemoveChild(serverNode);
            }

            if (type == 1)
            {
                #region 添加设备节点
                serverNode = xml.ImportNode(server.GenerateXMLNode(), true);
                serversNode.AppendChild(serverNode);
                #endregion
            }

            // 保存 XML 到文件
            xml.Save(dataFileName);
        }

        /// <summary>
        /// 根据地址和名称获取 TIRAPOPCServer 对象
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="name">名称</param>
        /// <returns>TIRAPOPCServer 对象</returns>
        public TIRAPOPCServer GetServerWithAddrAndName(string address, string name)
        {
            foreach (TIRAPOPCServer server in servers)
            {
                if (server.Address == address && server.Name == name)
                    return server;
            }

            return null;
        }

        /// <summary>
        /// 增加新的 KepwareServer
        /// </summary>
        /// <param name="server">KepwareServer 对象</param>
        /// <param name="dataFileName">本地持久化文件名</param>
        public void Add(TIRAPOPCServer server, string dataFileName)
        {
            if (GetServerWithAddrAndName(server.Address, server.Name) != null)
            {
                Exception error = new Exception();
                error.Data["ErrCode"] = "900102";
                error.Data["ErrText"] =
                    string.Format(
                        "KepServer[{0}({1})]已在系统中注册",
                        server.Address,
                        server.Name);
                throw error;
            }

            ModifyDataFile(1, server, dataFileName);
            servers.Add(server);
        }

        /// <summary>
        ///  删除已有的 KepwareServer
        /// </summary>
        /// <param name="servAddr">KepwareServer 地址</param>
        /// <param name="servName">KepwareServer 名称</param>
        /// <param name="dataFileName">本地持久化文件名</param>
        public void Remove(string servAddr, string servName, string dataFileName)
        {
            TIRAPOPCServer server = GetServerWithAddrAndName(servAddr, servName);
            if (server == null)
            {
                Exception error = new Exception();
                error.Data["ErrCode"] = "900101";
                error.Data["ErrText"] =
                    string.Format(
                        "KepServer[{0}({1})]未在系统中注册",
                        server.Address,
                        server.Name);
                throw error;
            }

            ModifyDataFile(2, server, dataFileName);
            servers.Remove(server);
        }
    }
}
