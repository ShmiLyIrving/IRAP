using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TGetDeviceTagsRspBody : TSoftlandBody
    {
        private List<TGetDeviceTagsRspDetail> details = new List<TGetDeviceTagsRspDetail>();
        private string excode;
        /// <summary>
        /// 交易代码
        /// </summary>
        public string ExCode {
            get { return "GetDeviceTags"; }
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
        /// <summary>
        /// 设备代码
        /// </summary>
        public string DeviceCode { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// KepServer的IP地址
        /// </summary>
        public string KepServAddr { get; set; }
        /// <summary>
        /// KepServer的服务器名称
        /// </summary>
        public string KepServName { get; set; }
        /// <summary>
        /// KepServer定义的Channel名称
        /// </summary>
        public string KepServChannel { get; set; }
        /// <summary>
        /// KepServer定义的Device名称
        /// </summary>
        public string KepServDevice { get; set; }

        /// <summary>
        /// 获取设备标签清单响应报文的行集报文
        /// </summary>
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public List<TGetDeviceTagsRspDetail> Details
        {
            get { return details; }
        }
        public static TGetDeviceTagsRspBody LoadFromXMLNode(XmlNode node)
        {
            TGetDeviceTagsRspBody rlt = new TGetDeviceTagsRspBody();
            rlt = IRAPXMLUtils.LoadValueFromXMLNode(GetEX(node), rlt) as TGetDeviceTagsRspBody;
            XmlNode paramxml = GetRspBodyNode(node);
            if (paramxml != null && paramxml.ChildNodes.Count>0)
            {
                foreach (XmlNode child in paramxml.ChildNodes)
                {
                    rlt.Details.Add(TGetDeviceTagsRspDetail.LoadFromXMLNode(child));
                }
            }
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
