using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;
using System.Reflection;

namespace IRAP.Interface.OPC
{
    public class TGetDevicesReqBody : TSoftlandBody
    {
        public string ExCode { get; set; }
        public string KepServAddr { get; set; }
        public string KepServName { get; set; }

        protected override XmlNode GenerateUserDefineNode()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode Parameters = xml.CreateElement("Parameters");

            XmlNode node = xml.CreateElement("Param");
            node = GenerateXMLNode(xml, node);
            Parameters.AppendChild(node);

            return Parameters;
        }

        public static TGetDevicesReqBody LoadFromXMLNode(XmlNode node)
        {
            // 筛选出第一个 Parameters 节点，其余的 Parameters 节点忽略
            XmlNode paramNode = null;
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "Parameters")
                {
                    paramNode = child;
                    break;
                }
            }
            // 如果不存在 Parameters 节点，则返回 null 值
            if (paramNode == null)
            {
                Exception error = new Exception();
                error.Data["ErrCode"] = "900001";
                error.Data["ErrText"] = string.Format("XML 节点 [{0}] 是空节点", paramNode.Name);
                throw error;
            }

            // 筛选出第一个 Param 节点并解析生成 TUpdateDeviceTagsReqBody 对象，其余节点忽略
            TGetDevicesReqBody rlt = null;
            foreach (XmlNode child in paramNode.ChildNodes)
            {
                if (child.Name == "Param")
                {
                    rlt = new TGetDevicesReqBody();
                    rlt = IRAPXMLUtils.LoadValueFromXMLNode(child, rlt) as TGetDevicesReqBody;
                    break;
                }
            }
            // 如果不存在 Param 节点，则返回 null 值
            if (rlt == null)
            {
                Exception error = new Exception();
                error.Data["ErrCode"] = "900001";
                error.Data["ErrText"] = string.Format("XML 节点 [{0}] 中没有找到 Param 节点", paramNode.Name);
                throw error;
            }

            return rlt;
        }
    }
}
