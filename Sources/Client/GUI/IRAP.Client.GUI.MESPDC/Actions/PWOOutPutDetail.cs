using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using IRAP.Global;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class PWOOutputDetailAction : CustomAction, IUDFAction
    {
        private Scenario scene = Scenario.未设置;
        private string irapCacheAddr = "";
        private string pwoNo = "";
        XmlNode nodeParam = null;
        XmlNode nodeRows = null;
        private long ut = 0;
        private long actualTaktTime = 0;
        private long pwoExecTime = 0;
        private long actualOutput = 0;
        private DateTime actualStartTime = DateTime.Now;

        public PWOOutputDetailAction(XmlNode actionParam, ExtendEventHandler extendAction, ref object tag)
            : base(actionParam, extendAction, ref tag)
        {
            try
            {
                nodeParam = 
                    actionParam.ChildNodes[0] == null ? null : actionParam.ChildNodes[0];
                nodeRows = 
                    actionParam.ChildNodes[1] == null ? null : actionParam.ChildNodes[1];

                if (actionParam.Attributes["IRAPCacheAddr"] != null && 
                    !string.IsNullOrEmpty(actionParam.Attributes["IRAPCacheAddr"].Value))
                {
                    irapCacheAddr = actionParam.Attributes["IRAPCacheAddr"].Value;
                }
                if (actionParam.Attributes["Scenario"] != null && 
                    !string.IsNullOrEmpty(actionParam.Attributes["Scenario"].Value))
                {
                    switch (actionParam.Attributes["Scenario"].Value)
                    {
                        case "1":
                            scene = Scenario.获取工单产出报工明细;
                            break;
                        case "2":
                            scene = Scenario.从详细计划表获取并推送入缓存;
                            break;
                        case "3":
                            scene = Scenario.WIPPattern报工推送入缓存;
                            break;
                        case "4":
                            scene = Scenario.从缓存中删除WIPPattern报工数据;
                            break;
                        default:
                            scene = Scenario.未设置;
                            break;
                    }
                }
                if (actionParam.ChildNodes[0] != null && 
                    actionParam.ChildNodes[0].Attributes["PWONo"] != null && 
                    !string.IsNullOrEmpty(actionParam.ChildNodes[0].Attributes["PWONo"].Value))
                {
                    pwoNo = actionParam.ChildNodes[0].Attributes["PWONo"].Value;
                }

                if (nodeParam != null)
                {
                    if (nodeParam.Attributes["UT"] != null)
                    {
                        ut = Tools.ConvertToInt64(nodeParam.Attributes["UT"].ToString());
                    }
                    if (nodeParam.Attributes["ActualTaktTime"] != null)
                    {
                        actualTaktTime =
                            Tools.ConvertToInt64(
                                nodeParam.Attributes["ActualTaktTime"].ToString());
                    }
                    if (nodeParam.Attributes["PWOExecTime"] != null)
                    {
                        pwoExecTime =
                            Tools.ConvertToInt64(
                                nodeParam.Attributes["PWOExecTime"].ToString());
                    }
                    if (nodeParam.Attributes["ActualOutput"] != null)
                    {
                        actualOutput =
                            Tools.ConvertToInt64(
                                nodeParam.Attributes["ActualOutput"].ToString());
                    }
                    if (nodeParam.Attributes["ActualStartTime"] != null)
                    {
                        actualStartTime =
                            Tools.ConvertToDateTime(
                                nodeParam.Attributes["ActualStartTime"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DoAction()
        {
            if (string.IsNullOrEmpty(irapCacheAddr))
            {
                throw new Exception("报文未设置Redis服务器地址");
            }
            switch (scene)
            {
                case Scenario.未设置:
                    throw new Exception("报文未设置场景");
                case Scenario.获取工单产出报工明细:
                    throw new Exception("暂不支持获取工单产出报工明细");
                case Scenario.WIPPattern报工推送入缓存:
                    if (nodeParam == null)
                    {
                        throw new Exception("报文缺少节点Param");
                    }
                    if (string.IsNullOrEmpty(pwoNo))
                    {
                        throw new Exception("报文未设置工单号");
                    }
                    ResponseContent res = GetListByPWONo(pwoNo);
                    if (res.RtnCode != 0 && res.RtnCode != 888)
                    {
                        throw new Exception(res.RtnMessage);
                    }
                    else
                    {
                        if (res.DetailXml == null && res.DetailXml.ChildNodes.Count == 0)
                        {
                            throw new Exception("缺少子板信息");
                        }
                        RequestContent request = new RequestContent();
                        request.PWONo = pwoNo;
                        if (res.Param == null)
                        {
                            request.Param = request.xdoc.ImportNode(nodeParam, true);
                        }
                        else
                        {
                            request.Param = request.xdoc.ImportNode(res.Param, true);
                        }
                        int ordinal = 1;
                        foreach (XmlNode r in nodeRows.ChildNodes)
                        {
                            int flag = 0;
                            foreach (XmlNode detail in res.DetailXml.ChildNodes)
                            {
                                if (detail.Attributes["WIPCode"].InnerXml == r.Attributes["WIPCode"].InnerXml)
                                {
                                    flag = 1;
                                    if (detail.Attributes["OutputTime"] == null)
                                    {
                                        XmlAttribute a = res.xdoc.CreateAttribute("OutputTime");
                                        detail.Attributes.Append(a);
                                    }
                                    detail.Attributes["OutputTime"].InnerXml = r.Attributes["OutputTime"].InnerXml;
                                    if (detail.Attributes["OutputUnixTime"] == null)
                                    {
                                        XmlAttribute a = res.xdoc.CreateAttribute("OutputUnixTime");
                                        detail.Attributes.Append(a);
                                    }
                                    detail.Attributes["OutputUnixTime"].InnerXml = r.Attributes["OutputUnixTime"].InnerXml;
                                    if (detail.Attributes["Ordinal"] == null)
                                    {
                                        XmlAttribute a = res.xdoc.CreateAttribute("Ordinal");
                                        detail.Attributes.Append(a);
                                    }
                                    detail.Attributes["Ordinal"].InnerXml = (ordinal++).ToString();
                                    request.DetailXml.AppendChild(request.xdoc.ImportNode(detail, true));
                                    break;
                                }
                            }
                            if (flag == 0)        //未找到
                            {
                                XmlNode n = request.xdoc.ImportNode(r, true);

                                actualOutput++;
                                ut += actualTaktTime;
                                pwoExecTime = Convert.ToInt64((DateTime.Now - actualStartTime).TotalMilliseconds);

                                if (request.Param.Attributes["UT"] == null)
                                {
                                    request.Param.Attributes.Append(
                                        request.xdoc.CreateAttribute("UT"));
                                }
                                request.Param.Attributes["UT"].Value = ut.ToString();
                                if (request.Param.Attributes["ActualStartTime"] == null)
                                {
                                    request.Param.Attributes.Append(
                                        request.xdoc.CreateAttribute("ActualStartTime"));
                                }
                                request.Param.Attributes["ActualStartTime"].Value = 
                                    actualStartTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                if (request.Param.Attributes["PWOExecTime"] == null)
                                {
                                    request.Param.Attributes.Append(
                                        request.xdoc.CreateAttribute("PWOExecTime"));
                                }
                                request.Param.Attributes["PWOExecTime"].Value = 
                                    pwoExecTime.ToString();
                                if (request.Param.Attributes["ActualOutput"] == null)
                                {
                                    request.Param.Attributes.Append(
                                        request.xdoc.CreateAttribute("ActualOutput"));
                                }
                                request.Param.Attributes["ActualOutput"].Value =
                                    actualOutput.ToString();

                                if (n.Attributes["Ordinal"] == null)
                                {
                                    XmlAttribute a = request.xdoc.CreateAttribute("Ordinal");
                                    a.InnerXml = (ordinal++).ToString();
                                    n.Attributes.Append(a);
                                }
                                request.DetailXml.AppendChild(n);
                            }
                        }
                        ResponseContent response = new ResponseContent(Post(request.GenerateRequestContent()));
                        MessageBox.Show(response.RtnMessage);
                    }
                    break;
                case Scenario.从缓存中删除WIPPattern报工数据:
                    if (nodeParam == null)
                    {
                        throw new Exception("报文缺少节点Param");
                    }
                    if (string.IsNullOrEmpty(pwoNo))
                    {
                        throw new Exception("报文未设置工单号");
                    }
                    ResponseContent responseContent = GetListByPWONo(pwoNo);
                    if (responseContent.RtnCode != 0 && responseContent.RtnCode != 888)
                    {
                        throw new Exception(responseContent.RtnMessage);
                    }
                    else
                    {
                        if (responseContent.DetailXml == null && 
                            responseContent.DetailXml.ChildNodes.Count == 0)
                        {
                            throw new Exception("缺少子板信息");
                        }

                        RequestContent request = new RequestContent();
                        request.PWONo = pwoNo;
                        if (responseContent.Param == null)
                        {
                            request.Param = request.xdoc.ImportNode(nodeParam, true);
                        }
                        else
                        {
                            request.Param = 
                                request.xdoc.ImportNode(
                                    responseContent.Param, 
                                    true);
                        }

                        request.DetailXml =
                            request.xdoc.ImportNode(
                                responseContent.DetailXml,
                                true);

                        int ordinal = 1;
                        foreach (XmlNode r in nodeRows.ChildNodes)
                        {
                            foreach (XmlNode detail in request.DetailXml.ChildNodes)
                            {
                                if (detail.Attributes["WIPCode"].Value == r.Attributes["WIPCode"].Value)
                                {
                                    request.xdoc.RemoveChild(detail);

                                    actualOutput--;
                                    ut -= actualTaktTime;
                                    pwoExecTime = Convert.ToInt64((DateTime.Now - actualStartTime).TotalMilliseconds);

                                    if (request.Param.Attributes["UT"] == null)
                                    {
                                        request.Param.Attributes.Append(
                                            request.xdoc.CreateAttribute("UT"));
                                    }
                                    request.Param.Attributes["UT"].Value = ut.ToString();
                                    if (request.Param.Attributes["ActualStartTime"] == null)
                                    {
                                        request.Param.Attributes.Append(
                                            request.xdoc.CreateAttribute("ActualStartTime"));
                                    }
                                    request.Param.Attributes["ActualStartTime"].Value =
                                        actualStartTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                    if (request.Param.Attributes["PWOExecTime"] == null)
                                    {
                                        request.Param.Attributes.Append(
                                            request.xdoc.CreateAttribute("PWOExecTime"));
                                    }
                                    request.Param.Attributes["PWOExecTime"].Value =
                                        pwoExecTime.ToString();
                                    if (request.Param.Attributes["ActualOutput"] == null)
                                    {
                                        request.Param.Attributes.Append(
                                            request.xdoc.CreateAttribute("ActualOutput"));
                                    }
                                    request.Param.Attributes["ActualOutput"].Value =
                                        actualOutput.ToString();

                                    break;
                                }
                            }

                            ordinal = 1;
                            foreach (XmlNode row in request.DetailXml.ChildNodes)
                            {
                                if (row.Attributes["Ordinal"] == null)
                                {
                                    row.Attributes.Append(
                                        request.xdoc.CreateAttribute("Ordinal"));
                                }
                                row.Attributes["Ordinal"].Value = ordinal.ToString();
                                ordinal++;
                            }
                        }
                        ResponseContent response = new ResponseContent(Post(request.GenerateRequestContent()));
                        MessageBox.Show(response.RtnMessage);
                    }
                    break;

            }
        }

        private string Post(string input)
        {
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
                string resXml = string.Empty;
                var stream = request.GetRequestStream();
                byte[] bodyBytes = Encoding.UTF8.GetBytes(input);
                stream.Write(bodyBytes, 0, bodyBytes.Length);
                stream.Flush();
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                {
                    resXml = reader.ReadToEnd();
                }
                return resXml;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private ResponseContent GetListByPWONo(string PwoNo)
        {

            string content = 
                $"<Softland><Redis><ExCode>GET</ExCode><Key>PWOInExecution={pwoNo}"+
                "</Key><Std>1</Std></Redis></Softland>";
            ResponseContent res = new ResponseContent(Post(content));
            return res;
        }
    }

    public class PWOOutputDetailFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction, ref object tag)
        {
            return new PWOOutputDetailAction(actionParams, extendAction, ref tag);
        }
    }

    public enum Scenario
    {
        未设置 = 0,
        获取工单产出报工明细 = 1,
        从详细计划表获取并推送入缓存 = 2,
        WIPPattern报工推送入缓存 = 3,
        从缓存中删除WIPPattern报工数据 = 4
    }

    public class RequestContent
    {
        public XmlDocument xdoc = new XmlDocument();
        public XmlNode Param, DetailXml;
        public string PWONo;
        public RequestContent()
        {
            DetailXml = xdoc.CreateElement("Rows");
        }

        public string GenerateRequestContent()
        {
            try
            {
                string request =
                    $"<Softland><Redis><ExCode>SET</ExCode><Key>PWOInExecution={PWONo}" +
                    "</Key><Value><Parameters></Parameters></Value></Redis></Softland>";
                xdoc.LoadXml(request);
                xdoc.SelectNodes("/Softland/Redis/Value/Parameters")[0].AppendChild(Param);
                xdoc.SelectNodes("/Softland/Redis/Value/Parameters")[0].AppendChild(DetailXml);
                return xdoc.InnerXml;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class ResponseContent
    {
        public XmlDocument xdoc = new XmlDocument();
        public XmlNode Param, DetailXml;
        public int RtnCode = 9999;
        public string RtnMessage = "";

        public ResponseContent(string content)
        {
            try
            {
                xdoc.LoadXml(content);
                RtnCode = int.Parse(xdoc.SelectNodes("/Softland/Head/RtnCode")[0].InnerXml);
                RtnMessage = xdoc.SelectNodes("/Softland/Head/RtnMessage")[0].InnerXml;
                if (RtnCode == 0)
                {
                    Param = xdoc.SelectNodes("/Softland/Body/Result/Parameters/Param")[0];
                    DetailXml = xdoc.SelectNodes("/Softland/Body/Result/Parameters/Rows")[0];
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
