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
        private string excode;
        public string ExCode {
            get { return "GetDevices"; }
            set { excode = value; }
        }
        public string ErrCode { get; set; }
        public string ErrText { get; set; }
        public List<TGetDevicesRspDetail> Details
        {
            get { return details; }
        }

        public TGetDevicesRspBody()
        {
        }
        public static TGetDevicesRspBody LoadFromXMLNode(XmlNode node)
        {
            TGetDevicesRspBody rlt = new TGetDevicesRspBody();
            rlt = IRAPXMLUtils.LoadValueFromXMLNode(GetEX(node), rlt) as TGetDevicesRspBody;
            XmlNode paramxml = GetRspBodyNode(node);
            if (paramxml != null&& paramxml.FirstChild.Name =="Row")
            {
                foreach(XmlNode child in paramxml.ChildNodes)
                {
                    rlt.Details.Add(TGetDevicesRspDetail.LoadFromXMLNode(child));
                }
            }
            return rlt;
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
