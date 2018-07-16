// 版权所有：
// 文 件  名：ConfigHelper.cs
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace PlanMGMT.Utility
{
    /// <summary>
    /// xml操作类
    /// </summary>
    public class ConfigHelper
    {
        #region 变量
        private XmlDocument xmlDoc;
        private string xmlfilepath = string.Empty;
        private const string ROOT_NODE = "Configuration";
        #endregion

        /// <summary>
        /// 构造函数，导入Xml文件
        /// </summary>
        /// <param name="xmlFile">文件路径或xml文件文本</param>
        public ConfigHelper(string xmlFile)
        {
            xmlDoc = new XmlDocument();
            xmlfilepath = xmlFile;
            xmlDoc.Load(xmlFile);   //载入Xml文档
        }
        /// <summary>
        /// 析构函数
        /// </summary>
        ~ConfigHelper()
        {
            if (xmlDoc != null)
                xmlDoc = null;  //释放XmlDocument对象
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="filePath">文件虚拟路径</param>
        public void Save()
        {
            xmlDoc.Save(xmlfilepath);
        }
        /// <summary>
        /// 查询指定节点的指定节点值
        /// </summary>
        /// <param name="strNode">节点名</param>
        public XmlNode GetXmlNode(string strNode)
        {
            return xmlDoc.SelectSingleNode(strNode);
        }
        /// <summary>
        /// 节点查询，返回节点值
        /// </summary>
        /// <param name="nodePath">节点的路径 如:Data/ArticleInfo/ArticleTitle</param>
        /// <returns></returns>
        public string SelectNodeText(string nodePath)
        {
            string _nodeTxt = xmlDoc.SelectSingleNode(nodePath).InnerText;
            if (_nodeTxt == null || _nodeTxt == "")
                return "";
            else
                return _nodeTxt;
        }
        /// <summary>
        /// 设置节点值
        /// </summary>
        /// <param name="xPath">节点名</param>
        /// <param name="xmlNodeValue">节点值</param>
        public void SetXmlNodeValue(string xPath, string xmlNodeValue)
        {
            try
            {
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xPath);
                xmlNode.InnerText = xmlNodeValue;
            }
            catch (XmlException xmle)
            {
                throw xmle;
            }
        }
        /// <summary>
        /// 获取配置项值
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <returns></returns>
        public string GetValue(string nodeName)
        {
            string obj = SelectNodeText(ROOT_NODE + "/" + nodeName);
            if (obj == null)
                obj = String.Empty;

            return obj.Trim();
        }
        /// <summary>
        /// 设置配置项值
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="nodeVal">节点值</param>
        /// <returns></returns>
        public void SetValue(string nodeName, string nodeVal)
        {
            SetXmlNodeValue(ROOT_NODE + "/" + nodeName, nodeVal);
        }
    }
}
