using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IRAP.Global
{
    public class XMLHelper
    {
        /// <summary>
        /// 创建 XML 节点属性
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static XmlAttribute CreateAttribute(
            XmlDocument xml, 
            string name,
            string value)
        {
            XmlAttribute attr = xml.CreateAttribute(name);
            attr.Value = value;
            return attr;
        }
    }
}
