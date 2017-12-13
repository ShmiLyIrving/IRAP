using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TUpdateDeviceTagsReqBody : TSoftlandBody
    {
        private List<TUpdateDeviceTagsReqDetail> details = new List<TUpdateDeviceTagsReqDetail>();

        public string ExCode { get; set; }
        /// <summary>
        /// 社区标识
        /// </summary>
        public int CommunityID { get; set; }
        /// <summary>
        /// 更新模式
        /// </summary>
        public int UpdateType { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceName { get; set; }
        public string KepServAddr { get; set; }
        public string KepServName { get; set; }
        public string KepServChannel { get; set; }
        public string KepServDevice { get; set; }

        /// <summary>
        /// 请求报文中的行集
        /// </summary>
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public List<TUpdateDeviceTagsReqDetail> Details
        {
            get { return details; }
        }

        protected override XmlNode GenerateUserDefineNode()
        {
            return null;
        }

        public static TUpdateDeviceTagsReqBody LoadFromXMLNode(XmlNode node)
        {
            if (!node.HasChildNodes)
            {
                Exception error = new Exception();
                error.Data["ErrCode"] = "900001";
                error.Data["ErrText"] = string.Format("XML 节点 [{0}] 是空节点", node.Name);
                throw error;
            }

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
            TUpdateDeviceTagsReqBody rlt = null;
            foreach (XmlNode child in paramNode.ChildNodes)
            {
                if (child.Name == "Param")
                {
                    rlt = new TUpdateDeviceTagsReqBody();
                    rlt = IRAPXMLUtils.LoadValueFromXMLNode(child, rlt) as TUpdateDeviceTagsReqBody;
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
                    foreach (XmlNode row in child.ChildNodes)
                    {
                        if (row.Name == "Row")
                            rlt.Details.Add(TUpdateDeviceTagsReqDetail.LoadFromXMLNode(row));
                    }
                    break;
                }
            }
            return rlt;
        }
    }
}
