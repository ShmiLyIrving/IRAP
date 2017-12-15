using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;
using IRAP.Interface.OPC;

namespace IRAP.OPC.Entity
{
    public class TIRAPOPCServer
    {
        /// <summary>
        /// OPC 服务器的地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// OPC 服务器的名称
        /// </summary>
        public string Name { get; set; }

        public TIRAPOPCServer() { }

        public TIRAPOPCServer(TUpdateKepServReqBody request)
        {
            Address = request.KepServAddr;
            Name = request.KepServName;
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]", Name, Address);
        }

        public TIRAPOPCServer Clone()
        {
            return MemberwiseClone() as TIRAPOPCServer;
        }

        public XmlNode GenerateXMLNode()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode node = xml.CreateElement("OPCServer");

            node = IRAPXMLUtils.GenerateXMLAttribute(node, this);

            return node;
        }

        public static TIRAPOPCServer LoadFromXMLNode(XmlNode node)
        {
            if (node.Name == "OPCServer")
            {
                TIRAPOPCServer server = new TIRAPOPCServer();
                server = IRAPXMLUtils.LoadValueFromXMLNode(node, server) as TIRAPOPCServer;

                if ((server.Address != "") && (server.Name != ""))
                    return server;
                else
                    return null;
            }
            else
                return null;
        }
    }
}
