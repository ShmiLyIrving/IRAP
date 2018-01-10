using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TUpdateDeviceTagsReqDetail
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// KepServer 定义的标签名称
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// KepServer 定义的标签数据类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// KepServer 定义的标签描述
        /// </summary>
        public string Description { get; set; }

        public TUpdateDeviceTagsReqDetail Clone()
        {
            return MemberwiseClone() as TUpdateDeviceTagsReqDetail;
        }

        public static TUpdateDeviceTagsReqDetail LoadFromXMLNode(XmlNode node)
        {
            if (node.Name != "Row")
                return null;

            TUpdateDeviceTagsReqDetail rlt = new TUpdateDeviceTagsReqDetail();
            rlt = IRAPXMLUtils.LoadValueFromXMLNode(node, rlt) as TUpdateDeviceTagsReqDetail;
            return rlt;
        }
        public XmlNode GenerateXMLNode(XmlNode row)
        {
            return IRAPXMLUtils.GenerateXMLAttribute(row, this);
        }
    }
}
