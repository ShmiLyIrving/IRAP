using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel;
using System.Reflection;

using IRAP.Global;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class PWOOutputDetailAction : CustomAction, IUDFAction
    {
        private int scenario = 0;
        private string irapCacheAddr = "";

        private XmlNode paramNode = null;
        private XmlNode rowsNode = null;

        public PWOOutputDetailAction(
            XmlNode actionParam, 
            ExtendEventHandler extendAction, 
            ref object tag)
            : base(actionParam, extendAction, ref tag)
        {
            try
            {
                if (actionParam.Attributes["IRAPCacheAddr"] != null)
                {
                    irapCacheAddr = actionParam.Attributes["IRAPCacheAddr"].Value;
                }
                if (actionParam.Attributes["Scenario"] != null)
                {
                    scenario =
                        Tools.ConvertToInt32(
                            actionParam.Attributes["Scenario"].Value,
                            0);
                }

                if (irapCacheAddr.Trim() == "")
                {
                    throw new Exception("Redis 服务地址没有配置");
                }
                if (scenario != 3 && scenario != 4)
                {
                    throw new Exception("Scenario 的值只能是 3 或者 4");
                }

                paramNode = actionParam.SelectSingleNode("Param");
                if (paramNode == null)
                {
                    throw new Exception("Action 节点中未找到 Param 子节点");
                }

                rowsNode = actionParam.SelectSingleNode("Rows");
                if (rowsNode == null)
                {
                    throw new Exception("Action 节点中未找到 Rows 子节点");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DoAction()
        {
            XmlDocument xml = new XmlDocument();

            XmlNode fatherNode = xml.CreateElement("Softland");
            xml.AppendChild(fatherNode);

            XmlNode childNode = xml.CreateElement("Redis");
            fatherNode.AppendChild(childNode);
            fatherNode = childNode;

            childNode = xml.CreateElement("ExCode");
            childNode.InnerText = "WIPCount";
            fatherNode.AppendChild(childNode);

            childNode = xml.CreateElement("Value");
            fatherNode.AppendChild(childNode);
            fatherNode = childNode;

            childNode = xml.CreateElement("Parameters");
            fatherNode.AppendChild(childNode);
            fatherNode = childNode;

            childNode = xml.CreateElement("Action");
            childNode.Attributes.Append(
                xml.CreateAttribute("Scenario")).Value =
                scenario.ToString();
            fatherNode.AppendChild(childNode);

            fatherNode.AppendChild(xml.ImportNode(paramNode, true));
            fatherNode.AppendChild(xml.ImportNode(rowsNode, true));

            GetResponseContent response = new GetResponseContent(Post(xml.OuterXml));
            if (response.RtnCode != 0)
                throw new Exception(response.RtnMessage);
        }

        private string Post(string input)
        {
            string strProcedure =
                string.Format(
                    "{0}.{1}",
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name);

            irapCacheAddr = $"{irapCacheAddr}/MES".Replace("//MES", "/MES");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(irapCacheAddr);
            request.Method = "POST";

            //request.ContentType = "application/xml;charset=UTF-8;";
            request.ContentType = "application/stream;";
            request.KeepAlive = false;
            request.AllowAutoRedirect = true;
            request.CookieContainer = new System.Net.CookieContainer();

            request.Timeout = 30000; //1分钟
            try
            {
                WriteLog.Instance.Write(
                    string.Format(
                        "发送请求报文：[{0}]",
                        input),
                    strProcedure);
                string resXml = string.Empty;
                var stream = request.GetRequestStream();
                byte[] bodyBytes = Encoding.UTF8.GetBytes(input);
                stream.Write(bodyBytes, 0, bodyBytes.Length);
                stream.Flush();
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader =
                    new StreamReader(
                        response.GetResponseStream(),
                        Encoding.UTF8))
                {
                    resXml = reader.ReadToEnd();
                }
                WriteLog.Instance.Write(
                    string.Format("接收到响应报文：[{0}]", resXml),
                    strProcedure);
                return resXml;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class PWOOutputDetailFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(
            XmlNode actionParams, 
            ExtendEventHandler extendAction, 
            ref object tag)
        {
            return new PWOOutputDetailAction(actionParams, extendAction, ref tag);
        }
    }

    internal class GetResponseContent
    {
        public XmlDocument xdoc = new XmlDocument();
        public XmlNode Param, DetailXml;
        public int RtnCode = 9999;
        public string RtnMessage = "";

        public GetResponseContent(string content)
        {
            try
            {
                xdoc.LoadXml(content);
                RtnCode = int.Parse(xdoc.SelectNodes("/Softland/Head/RtnCode")[0].InnerXml);
                RtnMessage = xdoc.SelectNodes("/Softland/Head/RtnMessage")[0].InnerXml;

                if (RtnCode == 0)
                {
                    Param = xdoc.SelectSingleNode("/Softland/Body/Result/Parameters/Param");
                    DetailXml = xdoc.SelectSingleNode("/Softland/Body/Result/Parameters/Rows");
                }

                if (DetailXml == null)
                {
                    DetailXml = xdoc.CreateElement("Rows");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
