using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TDeviceTagValueRWRspBody : TSoftlandBody
    {
        private string excode;
        private List<TDeviceTagValueRWRspBodyTag> reads =
            new List<TDeviceTagValueRWRspBodyTag>();

        /// <summary>
        /// 交易代码
        /// </summary>
        public string ExCode
        {
            get { return "DeviceTagValueRW"; }
            set { excode = value; }
        }
        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrText { get; set; }

        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public List<TDeviceTagValueRWRspBodyTag> ReadTags { get { return reads; } }

        public static TDeviceTagValueRWRspBody LoadFromXMLNode(XmlNode node)
        {
            TDeviceTagValueRWRspBody rlt = new TDeviceTagValueRWRspBody();
            rlt = IRAPXMLUtils.LoadValueFromXMLNode(GetEX(node), rlt) as TDeviceTagValueRWRspBody;
            XmlNode paramxml = GetRspBodyNode(node);
            //if (paramxml != null && paramxml.ChildNodes.Count > 0)
            //{
            //    foreach (XmlNode child in paramxml.ChildNodes)
            //    {
            //        rlt.Details.Add(TGetDeviceTagsRspDetail.LoadFromXMLNode(child));
            //    }
            //}
            return rlt;
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

            for (int i = 0; i < reads.Count; i++)
            {
                reads[i].Ordinal = i + 1;

                XmlNode row = xml.CreateElement("Read");
                row = reads[i].GenerateXMLNode(row);
                node.AppendChild(row);
            }

            return result;
        }
    }

    public class TDeviceTagValueRWRspBodyTag
    {
        public int Ordinal { get; set; }
        public string TagName { get; set; }
        public string TagValue { get; set; }

        public XmlNode GenerateXMLNode(XmlNode row)
        {
            return IRAPXMLUtils.GenerateXMLAttribute(row, this);
        }
    }
}
