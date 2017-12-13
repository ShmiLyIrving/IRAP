using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;
using IRAP.Interface.OPC;

namespace IRAP.OPC.Entity
{
    public class TIRAPOPCKepDeviceTagInfo
    {
        public TIRAPOPCKepDeviceTagInfo() { }

        public TIRAPOPCKepDeviceTagInfo(TUpdateDeviceTagsReqDetail detail, string prefix)
        {
            if (!detail.TagName.Contains(prefix))
                TagName = string.Format("{0}.{1}", prefix, detail.TagName);
            DataType = detail.DataType;
            Description = detail.Description;
        }

        public string TagName { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string Address { get; set; }
        public string DataType { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string RespectDataType { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string ClientAccess { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string ScanRate { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string Scaling { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string RawLow { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string RawHigh { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string ScaledLow { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string ScaledHigh { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string ScaledDataType { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string ClampLow { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string ClampHigh { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string EngUnits { get; set; }
        public string Description { get; set; }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string NegateValue { get; set; }
        /// <summary>
        /// 实时标签值
        /// </summary>
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string Value { get; set; }
        /// <summary>
        /// 标签值取得时间
        /// </summary>
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string Timestamp { get; set; }
        /// <summary>
        /// 质量
        /// </summary>
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string Quality { get; set; }

        public XmlNode GenerateXMLNode()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode node = xml.CreateElement("Tag");
            return IRAPXMLUtils.GenerateXMLAttribute(node, this);
        }

        public static TIRAPOPCKepDeviceTagInfo LoadFromXMLNode(XmlNode node)
        {
            if (node.Name == "Tag")
            {
                TIRAPOPCKepDeviceTagInfo rlt = new TIRAPOPCKepDeviceTagInfo();
                return IRAPXMLUtils.LoadValueFromXMLNode(node, rlt) as TIRAPOPCKepDeviceTagInfo;
            }
            else
                return null;
        }
    }
}
