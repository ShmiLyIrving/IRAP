using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IRAP.Interface
{
    public class TCustomXMLArea
    {
        protected string GetNodeInnerText(XmlNode node, string nodeName)
        {
            try { return node.SelectSingleNode(nodeName).InnerText; }
            catch { throw new Exception(string.Format("{0} 节点没有定义", nodeName)); }
        }

        protected XmlNode AddXMLLeaf(
            XmlDocument doc,
            XmlNode parent,
            string leafName,
            string leafValue)
        {
            XmlElement child = doc.CreateElement(leafName);
            child.InnerText = leafValue;
            parent.AppendChild(child);

            return child;
        }
    }
}
