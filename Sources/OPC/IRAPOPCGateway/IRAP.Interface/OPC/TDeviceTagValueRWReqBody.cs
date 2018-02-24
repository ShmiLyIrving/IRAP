using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TDeviceTagValueRWReqBody : TSoftlandBody
    {
        private TDeviceTagValueRWReqBodyTags writeTags = new TDeviceTagValueRWReqBodyTags();
        private TDeviceTagValueRWReqBodyTags readTags = new TDeviceTagValueRWReqBodyTags();
        private TDeviceTagValueRWReqBodyFlagTags flagTags = new TDeviceTagValueRWReqBodyFlagTags();

        /// <summary>
        /// 交易代码
        /// </summary>
        public string ExCode { get; set; }
        /// <summary>
        /// 社区标识
        /// </summary>
        public int CommunityID { get; set; }
        /// <summary>
        /// KepServer的服务器名称
        /// </summary>
        public string KepServName { get; set; }

        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public TDeviceTagValueRWReqBodyTags WriteTags { get { return writeTags; } }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public TDeviceTagValueRWReqBodyTags ReadTags { get { return readTags; } }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public TDeviceTagValueRWReqBodyFlagTags FlagTags { get { return flagTags; } }

        protected override XmlNode GenerateUserDefineNode()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode Parameters = xml.CreateElement("Parameters");

            XmlNode node = xml.CreateElement("Param");
            node = GenerateXMLNode(xml, node);
            Parameters.AppendChild(node);

            return Parameters;
        }

        public static TDeviceTagValueRWReqBody LoadFromXMLNode(XmlNode node)
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

            // 筛选出第一个 Param 节点并解析生成 TDeviceTagValueRWReqBody 对象，其余节点忽略
            TDeviceTagValueRWReqBody rlt = null;
            foreach (XmlNode child in paramNode.ChildNodes)
            {
                if (child.Name == "Param")
                {
                    rlt = new TDeviceTagValueRWReqBody();
                    rlt = IRAPXMLUtils.LoadValueFromXMLNode(child, rlt) as TDeviceTagValueRWReqBody;
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

            foreach (XmlNode child in paramNode.ChildNodes)
            {
                if (child.Name == "ParamXML")
                {
                    foreach (XmlNode actionType in child.ChildNodes)
                    {
                        if (actionType.Name == "Write")
                            rlt.WriteTags.LoadFromXMLNode(actionType);
                        if (actionType.Name == "Read")
                            rlt.ReadTags.LoadFromXMLNode(actionType);
                        if (actionType.Name == "Flag")
                            rlt.FlagTags.LoadFromXMLNode(actionType);
                    }
                }
            }

            return rlt;
        }
    }

    public class TDeviceTagValueRWReqBodyTag
    {
        public int Ordinal { get; set; }
        public string TagName { get; set; }
        public string TagValue { get; set; }

        public static TDeviceTagValueRWReqBodyTag LoadFromXMLNode(XmlNode node)
        {
            if (node.Name != "Tag")
                return null;

            TDeviceTagValueRWReqBodyTag rlt = new TDeviceTagValueRWReqBodyTag();
            rlt = IRAPXMLUtils.LoadValueFromXMLNode(node, rlt) as TDeviceTagValueRWReqBodyTag;
            return rlt;
        }
    }

    public class TDeviceTagValueRWReqBodyTags
    {
        protected List<TDeviceTagValueRWReqBodyTag> tags =
            new List<TDeviceTagValueRWReqBodyTag>();

        public List<TDeviceTagValueRWReqBodyTag> Tags { get { return tags; } }

        public virtual void LoadFromXMLNode(XmlNode node)
        {
            tags.Clear();

            foreach (XmlNode child in node.ChildNodes)
            {
                TDeviceTagValueRWReqBodyTag tag =
                    TDeviceTagValueRWReqBodyTag.LoadFromXMLNode(child);
                if (tag != null)
                    tags.Add(tag);
            }
        }
    }

    public class TDeviceTagValueRWReqBodyFlagTags : TDeviceTagValueRWReqBodyTags
    {
        public int TimeOut { get; set; }

        public override void LoadFromXMLNode(XmlNode node)
        {
            base.LoadFromXMLNode(node);

            if (node.Attributes["TimeOut"] != null)
                TimeOut = Tools.ConvertToInt32(node.Attributes["TimeOut"].Value);
            else
                TimeOut = 30;
        }
    }
}
