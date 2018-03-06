using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Data;
using System.Reflection;

namespace IndexDefrag
{
    public class XmlFile
    {
        private static XmlFile instance =null;
        private static readonly object lockobject = new object();
        private static readonly object lockstate = new object();
        private static readonly object syncLock = new object();
        private static XmlDocument xmlIAUConfig;
        public string XMLPath = string.Format("{0}OutputStr.xml",AppDomain.CurrentDomain.BaseDirectory);
        public static XmlFile Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (instance == null)
                        instance = new XmlFile();
                }
                return instance;
            }
        }
        public XmlFile()
        {
            Initialization();
        }
        //初始化，设置Server节点
        public void Initialization()
        {
            try
            {
                lock (lockstate)
                {
                    XmlDocument XMLDoc = new XmlDocument();
                    if (!File.Exists(XMLPath) || File.ReadAllText(XMLPath, System.Text.Encoding.Default) == "")
                    {
                        XMLDoc.InnerXml = $"<?xml version=\"1.0\" encoding=\"utf-8\"?><!DOCTYPE DataAccess[]><Servers><Server DBServer =\"{SysParams.Instance.DBServer}\"></Server></Servers>";
                    }
                    else
                    {

                        XMLDoc.Load(XMLPath);
                        XmlNode root = XMLDoc.ChildNodes[2];
                        XmlNode server = XMLUtils.GetChildNodeWithPropertyValue(root,"DBServer", SysParams.Instance.DBServer);
                        if (server == null)
                        {
                            XmlElement s = XMLDoc.CreateElement("Server");
                            s.Attributes.Append(XMLDoc.CreateAttribute("DBServer")).Value =SysParams.Instance.DBServer;
                            root.AppendChild(s);
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
            catch(Exception e)
            {
                WriteLog.Instance.Write(
                           string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               e.Message,
                               e.StackTrace),
                           string.Format(
                    "{0}.{1}",
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name));
                throw e;
            }
        }

        //获取某个节点的值
        public String GetValue(String key)
        {
            xmlIAUConfig = new XmlDocument();
            xmlIAUConfig.Load(XMLPath);
            String value;
            String path = @"/Servers/appSettings/add[@Key='" + key + "']";
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
        public void ReadAccumChecked(DataTable dt)
        {
            try
            {
                xmlIAUConfig = new XmlDocument();
                xmlIAUConfig.Load(XMLPath);
                foreach (XmlNode xmlserver in xmlIAUConfig.ChildNodes[2].ChildNodes)
                {
                    if (xmlserver.HasChildNodes)
                    {
                        if(xmlserver.Attributes["DBServer"].Value.ToString().Trim()==SysParams.Instance.DBServer)
                        {
                            if (xmlserver.HasChildNodes)
                            {
                                foreach (XmlNode xmlDB in xmlserver.ChildNodes)
                                {
                                    if (xmlDB.HasChildNodes)
                                    {
                                        foreach (XmlNode xmltable in xmlDB.ChildNodes)
                                        {
                                            DataRow r = dt.NewRow();
                                            r["dataBaseID"] = int.Parse(xmlDB.Attributes["dataBaseID"].Value);
                                            r["Tableid"] = int.Parse(xmltable.Attributes["Tableid"].Value);
                                            r["AccumChecked"] = int.Parse(xmltable.Attributes["AccumChecked"].Value);
                                            dt.Rows.Add(r);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                WriteLog.Instance.Write(
                           string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               e.Message,
                               e.StackTrace),
                           string.Format(
                    "{0}.{1}",
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name));
                throw e;
            }
        }
        public void SaveAccumChecked(DataTable dt)
        {
            try
            {
                lock (lockobject)
                {
                    xmlIAUConfig = new XmlDocument();
                    xmlIAUConfig.Load(XMLPath);
                    string path = @"/Servers/Server[@DBServer='" + SysParams.Instance.DBServer + "']";
                    XmlNodeList xmlServers = xmlIAUConfig.SelectNodes(path);
                    if (xmlServers.Count == 1)          //找到Server
                    {
                        XmlElement xmlServer = (XmlElement)xmlServers[0];
                        foreach (DataRow r in dt.Rows)
                        {                            
                            if (!xmlServer.HasChildNodes)    //不含有DB节点
                            {
                                throw new Exception("未找到DB节点");
                            }
                            else                               //含有DB节点
                            {
                                string path2 = @"DB[@dataBaseID='" + r["dataBaseID"].ToString() + "']";
                                XmlNodeList xmlDBs = xmlServer.SelectNodes(path2);
                                if (xmlDBs.Count == 1)             //找到对应DB节点
                                {
                                    XmlElement xmlDB = (XmlElement)xmlDBs[0];
                                    if (!xmlDB.HasChildNodes)                //无table节点
                                    {
                                        throw new Exception("IAUConfig配置信息设置错误:没有table节点");
                                    }
                                    else                        //有table节点
                                    {
                                        string path3 = @"Table[@Tableid ='" + r["Tableid"].ToString() + "' ]";
                                        XmlNodeList xmlTables = xmlDB.SelectNodes(path3);
                                        if (xmlTables.Count == 1)        //找到对应table
                                        {
                                            XmlElement xmltable = (XmlElement)xmlTables[0];
                                            xmltable.Attributes["AccumChecked"].InnerText = r["AccumChecked"].ToString();
                                        }
                                        else                //未找到对应table
                                        {
                                            throw new Exception("未找到对应table");
                                        }
                                    }
                                }
                                else if (xmlDBs.Count == 0)                      //未找到对应DB节点
                                {
                                    throw new Exception("未找到对应节点");
                                }
                                else
                                {
                                    throw new Exception("IAUConfig配置信息设置错误：dataBaseid值为" + r["dataBaseID"].ToString() + "的DB的元素个数不唯一");
                                }
                            }
                        }
                    }
                    else                                //未找到Server节点
                    {
                        throw new Exception("IAUConfig配置信息设置错误：DBServer值为" + SysParams.Instance.DBServer + "的Server的元素个数不为1");
                    }

                    StreamWriter swriter = new StreamWriter(XMLPath);
                    XmlTextWriter xw = new XmlTextWriter(swriter);
                    xw.Formatting = Formatting.Indented;
                    xmlIAUConfig.WriteTo(xw);
                    xw.Close();
                    swriter.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int GetAccumChecked(string DBAdress, int dataBaseID, int Tableid)
        {
            try
            {
                xmlIAUConfig = new XmlDocument();
                xmlIAUConfig.Load(XMLPath);
                foreach (XmlNode xmlserver in xmlIAUConfig.ChildNodes[2].ChildNodes)
                {
                    if (xmlserver.HasChildNodes)
                    {
                        if (xmlserver.Attributes["DBServer"].Value.ToString().Trim() == DBAdress && xmlserver.HasChildNodes)
                        {
                            foreach (XmlNode xmlDB in xmlserver.ChildNodes)
                            {
                                if (xmlDB.Attributes["dataBaseID"].Value.ToString().Trim() == dataBaseID.ToString() && xmlDB.HasChildNodes)
                                {
                                    foreach (XmlNode xmltable in xmlDB.ChildNodes)
                                    {
                                        if (xmltable.Attributes["Tableid"].Value.ToString().Trim() == Tableid.ToString())
                                        {
                                            return int.Parse(xmltable.Attributes["AccumChecked"].Value.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                WriteLog.Instance.Write(
                           string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               e.Message,
                               e.StackTrace),
                           string.Format(
                    "{0}.{1}",
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name));
                throw e;
            }
            return 0;
        }
        /// <summary>
        /// 保存表的索引的 database,table,index 信息
        /// </summary>
        /// <param name="db"></param>
        /// <param name="dbtable"></param>
        public void SavaDBInfo(DB db,DBTable dbtable)
        {
            try
            {
                lock (lockobject)
                {
                    xmlIAUConfig = new XmlDocument();
                    xmlIAUConfig.Load(XMLPath);
                    string path = @"/Servers/Server[@DBServer='" + SysParams.Instance.DBServer + "']";
                    XmlNodeList xmlServers = xmlIAUConfig.SelectNodes(path);
                    if (xmlServers.Count == 1)          //找到Server
                    {
                        XmlElement xmlServer = (XmlElement)xmlServers[0];
                        if (!xmlServer.HasChildNodes)    //不含有DB节点
                        {
                            XmlElement xmldb = xmlIAUConfig.CreateElement("DB");
                            xmldb = (XmlElement)XMLUtils.GenerateXMLAttribute(xmldb, db);
                            xmldb.AppendChild(XMLUtils.GenerateXMLAttribute(xmlIAUConfig.CreateElement("Table"), dbtable));
                            xmlServer.AppendChild(xmldb);
                        }
                        else                               //含有DB节点
                        {
                            string path2 = @"DB[@dataBaseID='" + db.dataBaseID + "']";
                            XmlNodeList xmlDBs = xmlServer.SelectNodes(path2);
                            if (xmlDBs.Count == 1)             //找到对应DB节点
                            {
                                XmlElement xmlDB = (XmlElement)xmlDBs[0];
                                if (!xmlDB.HasChildNodes)                //无table节点
                                {
                                    throw new Exception("IAUConfig配置信息设置错误:没有table节点");
                                }
                                else                        //有table节点
                                {
                                    string path3 = @"Table[@Tableid ='" + dbtable.Tableid + "' ]";
                                    XmlNodeList xmlTables = xmlDB.SelectNodes(path3);
                                    if (xmlTables.Count == 1)        //找到对应table
                                    {
                                        XmlElement xmltable = (XmlElement)xmlTables[0];
                                        xmltable = (XmlElement)XMLUtils.GenerateXMLAttribute(xmltable, dbtable);
                                    }
                                    else                //未找到对应table
                                    {
                                        XmlElement xmltable = xmlIAUConfig.CreateElement("Table");
                                        xmltable = (XmlElement)XMLUtils.GenerateXMLAttribute(xmltable, dbtable);
                                        xmlDB.AppendChild(xmltable);
                                    }
                                }
                            }
                            else if(xmlDBs.Count == 0)                      //未找到对应DB节点
                            {
                                XmlElement xmldb = xmlIAUConfig.CreateElement("DB");
                                xmldb = (XmlElement)XMLUtils.GenerateXMLAttribute(xmldb, db);
                                xmldb.AppendChild(XMLUtils.GenerateXMLAttribute(xmlIAUConfig.CreateElement("Table"), dbtable));
                                xmlServer.AppendChild(xmldb);
                            }
                            else
                            {
                                throw new Exception("IAUConfig配置信息设置错误：dataBaseid值为" + db.dataBaseID + "的DB的元素个数不唯一");
                            }
                        }
                    }
                    else                                //未找到Server节点
                    {
                        throw new Exception("IAUConfig配置信息设置错误：DBAdress值为" + SysParams.Instance.DBServer + "的Server的元素个数不为1");
                    }

                    StreamWriter swriter = new StreamWriter(XMLPath);
                    XmlTextWriter xw = new XmlTextWriter(swriter);
                    xw.Formatting = Formatting.Indented;
                    xmlIAUConfig.WriteTo(xw);
                    xw.Close();
                    swriter.Close();
                }
            }
            catch(Exception e)
            {
                WriteLog.Instance.Write(
                           string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               e.Message,
                               e.StackTrace),
                           string.Format(
                    "{0}.{1}",
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name));
                throw e;
            }
        }
        //修改某个节点为某值,如果strValue 为null 则删除该节点,如果找不到strKey，则增加节点
        public void SavaConfig(string strKey, string strValue)
        {
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
                XmlNodeList nodes = XMLDoc.SelectNodes("Servers/appSettings");
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
