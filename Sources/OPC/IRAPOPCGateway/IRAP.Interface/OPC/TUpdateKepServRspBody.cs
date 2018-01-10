using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TUpdateKepServRspBody : TSoftlandBody
    {
        private string excode;
        /// <summary>
        /// 交易代码
        /// </summary>
        public string ExCode
        {
            get { return "UpdateKepServ"; }
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

        protected override XmlNode GenerateUserDefineNode()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode result = xml.CreateElement("Result");

            XmlNode node = xml.CreateElement("Param");
            node = IRAPXMLUtils.GenerateXMLAttribute(node, this);
            result.AppendChild(node);

            return result;
        }
        public static TUpdateKepServRspBody LoadFromXMLNode(XmlNode node)
        {
            TUpdateKepServRspBody rlt = new TUpdateKepServRspBody();
            rlt = IRAPXMLUtils.LoadValueFromXMLNode(GetEX(node), rlt) as TUpdateKepServRspBody;
            return rlt;
        }
    }
}
