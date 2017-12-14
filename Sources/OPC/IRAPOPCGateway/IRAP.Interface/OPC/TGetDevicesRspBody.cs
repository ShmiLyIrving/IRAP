using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TGetDevicesRspBody : TSoftlandBody
    {
        private List<TGetDevicesRspDetail> details = new List<TGetDevicesRspDetail>();

        public string ExCode { get { return "GetDevices"; } }
        public string ErrCode { get; set; }
        public string ErrText { get; set; }

        public TGetDevicesRspBody()
        {
        }

        public void AddDeviceDetail(TGetDevicesRspDetail item)
        {
            details.Add(item);
        }

        protected override XmlNode GenerateUserDefineNode()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode result = xml.CreateElement("Result");

            XmlNode node = xml.CreateElement("Param");
            node = IRAPXMLUtils.GenerateXMLAttribute(node, this);
            result.AppendChild(node);

            node = xml.CreateElement("ParamXML");
            result.AppendChild(node);

            for (int i = 0; i < details.Count; i++)
            {
                details[i].Ordinal = i + 1;

                XmlNode row = xml.CreateElement("Row");
                row = details[i].GenerateXMLNode(row);
                node.AppendChild(row);
            }

            return result;
        }
    }
}
