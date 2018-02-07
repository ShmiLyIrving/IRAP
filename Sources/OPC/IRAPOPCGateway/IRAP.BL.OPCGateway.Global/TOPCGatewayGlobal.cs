using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;

using IRAP.Global;

namespace IRAP.OPCGateway.Global
{
    public class TOPCGatewayGlobal
    {
        private static TOPCGatewayGlobal _instance = null;

        public static TOPCGatewayGlobal Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TOPCGatewayGlobal();
                return _instance;
            }
        }

        private TOPCGatewayGlobal()
        {
            configurationFile =
                string.Format(
                    "{0}.xml",
                    Assembly.GetCallingAssembly().Location.Replace(".dll", ""));
            configurationFile = configurationFile.Replace(".Global", "");

            esbParam = new ESBConfigurationParam(configurationFile);
            webAPIParam = new WebAPIParam(configurationFile);
            sysParams = new SysParams(configurationFile);
        }

        private string configurationFile = "";
        private ESBConfigurationParam esbParam = null;
        private WebAPIParam webAPIParam = null;
        private SysParams sysParams = null;

        /// <summary>
        /// 配置文件名
        /// </summary>
        public string ConfigurationFile { get { return configurationFile; } }
        /// <summary>
        /// ESB 参数
        /// </summary>
        public ESBConfigurationParam ESBParam { get { return esbParam; } }
        /// <summary>
        /// WebAPI 参数
        /// </summary>
        public WebAPIParam WebAPIParam { get { return webAPIParam; } }
        /// <summary>
        /// 系统参数
        /// </summary>
        public SysParams SysParams { get { return sysParams; } }
    }

    /// <summary>
    /// ESB 参数配置
    /// </summary>
    public class ESBConfigurationParam
    {
        /// <summary>
        /// ESB 服务器地址
        /// </summary>
        public string BrokeUri { get; set; }
        /// <summary>
        /// 队列名称
        /// </summary>
        public string QueueName { get; set; }
        /// <summary>
        /// 过滤字符串
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// 交易代码
        /// </summary>
        public string ExCode { get; set; }

        public ESBConfigurationParam() { }

        public ESBConfigurationParam(string fileName)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(fileName);
            }
            catch (Exception)
            {
                return;
            }

            XmlNode parentNode = xml.SelectSingleNode("root/ESBParams");
            foreach (XmlNode childNode in parentNode.ChildNodes)
            {
                if (childNode.Name == "ESBParam")
                {
                    BrokeUri = IRAPXMLUtils.GetXMLNodeAttributeValue(childNode, "BrokeUri");
                    QueueName = IRAPXMLUtils.GetXMLNodeAttributeValue(childNode, "QueueName");
                    Filter = IRAPXMLUtils.GetXMLNodeAttributeValue(childNode, "Filter");
                    ExCode = IRAPXMLUtils.GetXMLNodeAttributeValue(childNode, "ExCode");

                    break;
                }
            }
        }
    }

    /// <summary>
    /// WebAPI 参数配置
    /// </summary>
    public class WebAPIParam
    {
        /// <summary>
        /// WebAPI 服务地址
        /// </summary>
        public string BrokeUri { get; set; }
        /// <summary>
        /// 报文格式：JSON; XML
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// 客户端标识
        /// </summary>
        public string ClientID { get; set; }

        public WebAPIParam() { }

        public WebAPIParam(string fileName)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(fileName);
            }
            catch (Exception)
            {
                return;
            }

            XmlNode parentNode = xml.SelectSingleNode("root/WebAPI");
            if (parentNode != null)
            {
                BrokeUri = IRAPXMLUtils.GetXMLNodeAttributeValue(parentNode, "BrokeUri");
                ContentType = IRAPXMLUtils.GetXMLNodeAttributeValue(parentNode, "ContentType");
                ClientID = IRAPXMLUtils.GetXMLNodeAttributeValue(parentNode, "ClientID");
            }
        }
    }

    /// <summary>
    /// 系统参数配置
    /// </summary>
    public class SysParams
    {
        /// <summary>
        /// 社区标识
        /// </summary>
        public int CommunityID { get; set; }
        /// <summary>
        /// 系统登录标识
        /// </summary>
        public long SysLogID { get; set; }

        public SysParams(string fileName)
        {
            Settings settings = new Settings(fileName);
            if (settings["CommunityID"] != null)
                try { CommunityID = Convert.ToInt32(settings["CommunityID"]); }
                catch { CommunityID = 0; }
            if (settings["SysLogID"] != null)
                try { SysLogID = Convert.ToInt64(settings["SysLogID"]); }
                catch { SysLogID = 1; }
        }
    }

    public class Settings
    {
        private List<Setting> settings = new List<Setting>();

        public Settings(string fileName)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(fileName);
            }
            catch { return; }

            XmlNode rootNode = xml.SelectSingleNode("root/SystemParams");
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Name == "Param")
                {
                    settings.Add(
                        new Setting()
                        {
                            Key = IRAPXMLUtils.GetXMLNodeAttributeValue(node, "Key"),
                            Value = IRAPXMLUtils.GetXMLNodeAttributeValue(node, "Value"),
                        });
                }
            }
        }

        public string this[string key]
        {
            get
            {
                foreach (Setting setting in settings)
                {
                    if (setting.Key == key)
                        return setting.Value;
                }
                return null;
            }
        }

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < settings.Count)
                    return settings[index].Value;
                else
                    return null;
            }
        }
    }

    public class Setting
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
