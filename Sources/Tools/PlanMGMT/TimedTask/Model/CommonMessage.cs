using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PlanMGMT
{
    public class CommonMessage:Message
    {        
        public CommonMessage()
        { }
        public CommonMessage(string fromid,string toid,string content):base(MessageType.Commom,fromid,toid,content)
        {   
        }
        public override XmlDocument GenerateSendXml(XmlDocument doc)
        {
            XmlNode n = IRAPXMLUtils.GenerateXMLAttribute(doc.FirstChild.FirstChild.FirstChild, this);
            doc.FirstChild.FirstChild.RemoveAll();
            doc.FirstChild.FirstChild.AppendChild(n);
            return doc;
        }
    }
}
