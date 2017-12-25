using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;

using IRAP.Global;

namespace IRAP.BL.OPCGateway
{
    internal class TOPCGatewayGlobal
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

            esbParam = new ESBConfigurationParam(configurationFile);
        }

        private string configurationFile = "";
        private ESBConfigurationParam esbParam = null;

        /// <summary>
        /// 配置文件名
        /// </summary>
        public string ConfigurationFile { get { return configurationFile; } }
        /// <summary>
        /// ESB 参数
        /// </summary>
        public ESBConfigurationParam ESBParam { get { return esbParam; } }
    }

    /// <summary>
    /// ESB 参数配置
    /// </summary>
    internal class ESBConfigurationParam
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
}
