using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace IRAP.Global
{
    public class XmlFile
    {
        private static XmlDocument xmlIAUConfig;
      
        private static void Initialization(string XMLPath)
        {
            if (!File.Exists(XMLPath) || File.ReadAllText(XMLPath, System.Text.Encoding.Default) == "")
            {
                XmlDocument XMLDoc = new XmlDocument();
                //XMLDoc.InnerXml = File.ReadAllText(@"D:\\2.txt", System.Text.Encoding.Default);
                XMLDoc.InnerXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><!DOCTYPE DataAccess[]><DataAccess><appSettings></appSettings></DataAccess>";
                StreamWriter swriter = new StreamWriter(XMLPath);
                XmlTextWriter xw = new XmlTextWriter(swriter);
                xw.Formatting = Formatting.Indented;
                XMLDoc.WriteTo(xw);
                xw.Close();
                swriter.Close();
            }
        }
        //获取某个节点的值
        public static String GetValue(String key, string XMLPath)
        {
            Initialization(XMLPath);
            xmlIAUConfig = new XmlDocument();
            xmlIAUConfig.Load(XMLPath);
            String value;
            String path = @"/DataAccess/appSettings/add[@Key='" + key + "']";
            XmlNodeList xmlAdds = xmlIAUConfig.SelectNodes(path);

            if (xmlAdds.Count == 1)
            {
                XmlElement xmlAdd = (XmlElement)xmlAdds[0];

                value = xmlAdd.GetAttribute("Value");
            }
            else
            {
                throw new Exception("IAUConfig配置信息设置错误：键值为" + key + "的元素不等于1");
            }

            return value;
        }
        //修改某个节点为某值,如果strValue 为null 则删除该节点,如果没有strKey，则增加节点
        public static void SavaConfig(string strKey, string strValue, string XMLPath)
        {
            Initialization(XMLPath);
            XmlDocument XMLDoc = new XmlDocument();
            XMLDoc.Load(XMLPath);
            XmlNodeList list = XMLDoc.GetElementsByTagName("add");
            int flag = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Attributes[0].Value == strKey)
                {
                    if (strValue != null)
                    {
                        list[i].Attributes[1].Value = strValue;
                    }
                    else
                    {
                        list[i].ParentNode.RemoveChild(list[i]);
                    }
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                XmlElement xmlElement = XMLDoc.CreateElement("add");
                xmlElement.SetAttribute("Key", strKey);
                xmlElement.SetAttribute("Value", strValue);
                XmlNodeList nodes = XMLDoc.SelectNodes("DataAccess/appSettings");
                if (nodes.Count == 1)
                {
                    nodes[0].AppendChild(xmlElement);
                }
                else
                {
                    throw new Exception("IAUConfig配置信息格式错误");
                }
            }
            StreamWriter swriter = new StreamWriter(XMLPath);
            XmlTextWriter xw = new XmlTextWriter(swriter);
            xw.Formatting = Formatting.Indented;
            XMLDoc.WriteTo(xw);
            xw.Close();
            swriter.Close();
        }
    }
}
