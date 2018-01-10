using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TUpdateDeviceTagsRspBody : TSoftlandBody
    {
        private string exCode;
        public string ExCode
        {
            get { return "UpdateDeviceTags"; }
            set { exCode = value; }
        }
        public string ErrCode { get; set; }
        public string ErrText { get; set; }

        protected override XmlNode GenerateUserDefineNode()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode result = xml.CreateElement("Result");

            XmlNode node = xml.CreateElement("Param");
            node = IRAPXMLUtils.GenerateXMLAttribute(node, this);
            result.AppendChild(node);

            return result;
        }
        public static TUpdateDeviceTagsRspBody LoadFromXMLNode(XmlNode node)
        {
            TUpdateDeviceTagsRspBody rlt = new TUpdateDeviceTagsRspBody();
            rlt = IRAPXMLUtils.LoadValueFromXMLNode(GetEX(node), rlt) as TUpdateDeviceTagsRspBody;
            return rlt;
        }
    }
}
