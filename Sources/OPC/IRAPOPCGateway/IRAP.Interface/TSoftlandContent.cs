using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace IRAP.Interface
{
    public class TSoftlandContent
    {
        protected TSoftlandHead head = new TSoftlandHead();
        protected TSoftlandBody bodyRequest = null;
        protected TSoftlandBody bodyResponse = null;
        protected TSoftlandLog logRequest = null;
        protected TSoftlandLog logResponse = null;

        public TSoftlandHead Head
        {
            get { return head; }
        }

        private void ResolveHead(XmlNode node)
        {
            try
            {
                head.Resolve(node);
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                throw error;
            }
        }

        private string FormatXML(XmlDocument xml)
        {
            StringWriter sw = new StringWriter();
            using (XmlTextWriter writer = new XmlTextWriter(sw))
            {
                writer.Indentation = 2;
                writer.Formatting = Formatting.Indented;
                xml.WriteContentTo(writer);
                writer.Close();
            }
            return sw.ToString();
        }

        protected virtual void ResolveRequestBody(XmlNode node) { }
        protected virtual void ResolveRequestLog(XmlNode node) { }
        protected virtual void ResolveResponseBody(XmlNode node) { }
        protected virtual void ResolveResponseLog(XmlNode node) { }

        /// <summary>
        /// 解析请求报文 XML 串
        /// </summary>
        /// <param name="xmlString"></param>
        public void ResolveRequest(string xmlString)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(xmlString);
            }
            catch (Exception error)
            {
                string errText =
                    string.Format(
                        "在解析 XML 串的时候发生错误：[{0}]",
                        error.Message);
                Debug.WriteLine(errText);

                throw new Exception(errText);
            }

            XmlNode headNode = xml.SelectSingleNode("Softland/Head");
            if (headNode == null)
            {
                string errText = "XML 串不符合 WebAPI 不符合接口规范定义，没有找到 Softland/Head 节点";
                Debug.WriteLine(errText);
                throw new Exception(errText);
            }
            else
            {
                ResolveHead(headNode);
            }

            XmlNode bodyNode = xml.SelectSingleNode("Softland/Body");
            if (bodyNode == null)
            {
                string errText = "XML 串不符合 WebAPI 不符合接口规范定义，没有找到 Softland/Body 节点";
                Debug.WriteLine(errText);
                throw new Exception(errText);
            }
            else
                ResolveRequestBody(bodyNode);

            XmlNode logNode = xml.SelectSingleNode("Softland/Log");
            if (logNode != null)
                ResolveRequestLog(logNode);
        }

        /// <summary>
        /// 解析响应报文 XML 串
        /// </summary>
        /// <param name="xmlString"></param>
        public void ResolveResponse(string xmlString)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(xmlString);
            }
            catch (Exception error)
            {
                string errText =
                    string.Format(
                        "在解析 XML 串的时候发生错误：[{0}]",
                        error.Message);
                Debug.WriteLine(errText);

                throw new Exception(errText);
            }

            XmlNode headNode = xml.SelectSingleNode("Softland/Head");
            if (headNode == null)
            {
                string errText = "XML 串不符合 WebAPI 不符合接口规范定义，没有找到 Softland/Head 节点";
                Debug.WriteLine(errText);
                throw new Exception(errText);
            }
            else
            {
                ResolveHead(headNode);
            }

            XmlNode bodyNode = xml.SelectSingleNode("Softland/Body");
            if (bodyNode == null)
            {
                string errText = "XML 串不符合 WebAPI 不符合接口规范定义，没有找到 Softland/Body 节点";
                Debug.WriteLine(errText);
                throw new Exception(errText);
            }
            else
                ResolveResponseBody(bodyNode);

            XmlNode logNode = xml.SelectSingleNode("Softland/Log");
            if (logNode != null)
                ResolveResponseLog(logNode);
        }

        public string GenerateResponseContent()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.CreateElement("Softland");
            xml.AppendChild(root);

            root.AppendChild(xml.ImportNode(head.Generate(), true));

            if (bodyResponse != null)
                root.AppendChild(xml.ImportNode(bodyResponse.Generate(), true));
            if (logResponse != null)
                root.AppendChild(xml.ImportNode(logResponse.Generate(), true));

            return FormatXML(xml);
        }

        public string GenerateRequestContent()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.CreateElement("Softland");
            xml.AppendChild(root);

            root.AppendChild(xml.ImportNode(head.Generate(), true));
            if (bodyRequest != null)
                root.AppendChild(xml.ImportNode(bodyRequest.Generate(), true));
            if (logRequest != null)
                root.AppendChild(xml.ImportNode(logRequest.Generate(), true));

            return FormatXML(xml);
        }
    }

    public class TSoftlandHead : TCustomXMLArea
    {
        public string ExCode { get; set; }
        public string CorrelationID { get; set; }
        public string CommunityID { get; set; }
        public string SysLogID { get; set; }
        public string UserCode { get; set; }
        public string AgencyLeaf { get; set; }
        public string RoleLeaf { get; set; }
        public string StationID { get; set; }
        public string UnixTime { get; set; }

        public void Resolve(XmlNode head)
        {
            ExCode = GetNodeInnerText(head, "ExCode");
            CorrelationID = GetNodeInnerText(head, "CorrelationID");
            CommunityID = GetNodeInnerText(head, "CommunityID");
            SysLogID = GetNodeInnerText(head, "SysLogID");
            UserCode = GetNodeInnerText(head, "UserCode");
            AgencyLeaf = GetNodeInnerText(head, "AgencyLeaf");
            RoleLeaf = GetNodeInnerText(head, "RoleLeaf");
            StationID = GetNodeInnerText(head, "StationID");
            UnixTime = GetNodeInnerText(head, "UnixTime");
        }

        public XmlNode Generate()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode head = xmlDoc.CreateElement("Head");
            AddXMLLeaf(xmlDoc, head, "ExCode", ExCode);
            AddXMLLeaf(xmlDoc, head, "CorrelationID", CorrelationID);
            AddXMLLeaf(xmlDoc, head, "CommunityID", CommunityID);
            AddXMLLeaf(xmlDoc, head, "SysLogID", SysLogID);
            AddXMLLeaf(xmlDoc, head, "UserCode", UserCode);
            AddXMLLeaf(xmlDoc, head, "AgencyLeaf", AgencyLeaf);
            AddXMLLeaf(xmlDoc, head, "RoleLeaf", RoleLeaf);
            AddXMLLeaf(xmlDoc, head, "StationID", StationID);
            AddXMLLeaf(xmlDoc, head, "UnixTime", UnixTime);

            return head;
        }
    }

    public abstract class TSoftlandBody : TCustomXMLArea
    {
        protected abstract XmlNode GenerateUserDefineNode();

        public virtual XmlNode Generate()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode node = xml.CreateElement("Body");

            node.AppendChild(xml.ImportNode(GenerateUserDefineNode(), true));

            return node;
        }
        public static XmlNode GetRspBodyNode(XmlNode node)
        {
            if (!node.HasChildNodes)
            {
                Exception error = new Exception();
                error.Data["ErrCode"] = "900001";
                error.Data["ErrText"] = string.Format("XML 节点 [{0}] 是空节点", node.Name);
                throw error;
            }
            // 筛选出第一个 Result 节点，其余的 Result 节点忽略
            XmlNode resultNode = null;
            XmlNode rlt = null;
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "Result")
                {
                    resultNode = child;
                    break;
                }
            }
            // 如果不存在 Result 节点，则返回 null 值
            if (resultNode == null)
            {
                Exception error = new Exception();
                error.Data["ErrCode"] = "900001";
                error.Data["ErrText"] = string.Format("XML 节点 [{0}] 是空节点", resultNode.Name);
                throw error;
            }

            // 筛选出ParamXML 节点并返回
            foreach (XmlNode child in resultNode.ChildNodes)
            {
                if (child.Name == "ParamXML")
                {
                    rlt = child;
                    break;
                }
            }
            // 如果不存在 ParamXML 节点，则返回 null 值
            if (rlt == null)
            {
                Exception error = new Exception();
                error.Data["ErrCode"] = "900001";
                error.Data["ErrText"] = string.Format("XML 节点 [{0}] 中没有找到 ParamXML 节点", resultNode.Name);
                return null;
            }
            return rlt;
        }
        public static XmlNode GetEX(XmlNode node)
        {
            // 筛选出第一个 Result 节点，其余的 Result 节点忽略
            XmlNode resultNode = null;
            XmlNode rlt = null;
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "Result")
                {
                    resultNode = child;
                    break;
                }
            }
            // 如果不存在 Result 节点，则返回 null 值
            if (resultNode == null)
            {
                Exception error = new Exception();
                error.Data["ErrCode"] = "900001";
                error.Data["ErrText"] = string.Format("XML 节点 [{0}] 是空节点", resultNode.Name);
                throw error;
            }

            // 筛选出Param 节点并返回
            foreach (XmlNode child in resultNode.ChildNodes)
            {
                if (child.Name == "Param")
                {
                    rlt = child;
                    break;
                }
            }
            // 如果不存在 Param 节点，则返回 null 值
            if (rlt == null)
            {
                Exception error = new Exception();
                error.Data["ErrCode"] = "900001";
                error.Data["ErrText"] = string.Format("XML 节点 [{0}] 中没有找到 Param 节点", resultNode.Name);
                throw error;
            }
            return rlt;
        }
        public XmlNode GenerateXMLNode(XmlDocument xml, XmlNode row)
        {
            PropertyInfo[] fields = GetType().GetProperties();
            row.Attributes.RemoveAll();
            foreach (PropertyInfo field in fields)
            {
                XmlAttribute attr = xml.CreateAttribute(field.Name);

                if (field.GetValue(this, null) == null)
                    attr.Value = "";
                else
                    attr.Value = field.GetValue(this, null).ToString();
                row.Attributes.Append(attr);
            }

            return row;
        }
    }

    public abstract class TSoftlandLog : TCustomXMLArea
    {
        protected abstract XmlNode GenerateUserDefineNode();

        public virtual XmlNode Generate()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode node = xml.CreateElement("Log");

            node.AppendChild(xml.ImportNode(GenerateUserDefineNode(), true));

            return node;
        }
    }
}
