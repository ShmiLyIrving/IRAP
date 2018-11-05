using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TGetDeviceTagsRspDetail
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// 标签数据类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 标签描述
        /// </summary>
        public string Description { get; set; }

        public TGetDeviceTagsRspDetail()
        {
            Ordinal = 0;
            TagName = "";
            DataType = "";
            Description = "";
        }

        public TGetDeviceTagsRspDetail Clone()
        {
            return MemberwiseClone() as TGetDeviceTagsRspDetail;
        }

        public XmlNode GenerateXMLNode(XmlNode row)
        {
            return IRAPXMLUtils.GenerateXMLAttribute(row, this);
        }
        public static TGetDeviceTagsRspDetail LoadFromXMLNode(XmlNode node)
        {
            if (node.Name != "Row")
                return null;

            TGetDeviceTagsRspDetail rlt = new TGetDeviceTagsRspDetail();
            rlt = IRAPXMLUtils.LoadValueFromXMLNode(node, rlt) as TGetDeviceTagsRspDetail;
            return rlt;
        }
    }
}
