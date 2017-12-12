using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;

using IRAP.OPC.Entity;

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

        public int Load(string cfgFileName)
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
                    TIRAPOPCServer server = new TIRAPOPCServer();
                    if (child.Attributes["Address"] != null)
                        server.Address = child.Attributes["Address"].Value.Trim();
                    if (child.Attributes["Name"] != null)
                        server.Name = child.Attributes["Name"].Value.Trim();

                    if (server.Address != "" && server.Name != "")
                        servers.Add(server);
                }
            }
            else
            {
                Debug.WriteLine("配置文件中没有找到 root/OPCServers 节点(请注意大小写)");
            }

            return servers.Count;
        }
    }
}
