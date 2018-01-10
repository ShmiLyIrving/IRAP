using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TGetKepServListRspDetail
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// KepServer的IP地址
        /// </summary>
        public string KepServAddr { get; set; }
        /// <summary>
        /// KepServer的服务器名称
        /// </summary>
        public string KepServName { get; set; }

        public TGetKepServListRspDetail Clone()
        {
            return MemberwiseClone() as TGetKepServListRspDetail;
        }
        public static TGetKepServListRspDetail LoadFromXMLNode(XmlNode node)
        {
            if (node.Name != "Row")
                return null;

            TGetKepServListRspDetail rlt = new TGetKepServListRspDetail();
            rlt = IRAPXMLUtils.LoadValueFromXMLNode(node, rlt) as TGetKepServListRspDetail;
            return rlt;
        }
        public XmlNode GenerateXMLNode(XmlNode row)
        {
            return IRAPXMLUtils.GenerateXMLAttribute(row, this);
        }
    }
}
