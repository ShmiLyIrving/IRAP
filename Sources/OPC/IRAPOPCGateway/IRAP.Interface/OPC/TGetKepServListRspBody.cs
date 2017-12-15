using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TGetKepServListRspBody : TSoftlandBody
    {
        private List<TGetKepServListRspDetail> items = new List<TGetKepServListRspDetail>();

        /// <summary>
        /// 交易代码
        /// </summary>
        public string ExCode { get { return "GetKepServList"; } }
        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrText { get; set; }

        /// <summary>
        /// 请求报文中的行集
        /// </summary>
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public List<TGetKepServListRspDetail> Items
        {
            get { return items; }
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

            for (int i = 0; i < items.Count; i++)
            {
                items[i].Ordinal = i + 1;
                XmlNode child = xml.CreateElement("Row");
                node.AppendChild(IRAPXMLUtils.GenerateXMLAttribute(child, items[i]));
            }

            return result;
        }
    }
}
