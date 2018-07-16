using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PlanMGMT
{
    public abstract class Message
    {
        private MessageType type;
        private string fromID;
        private string toID;
        private string content;
        private string sendtime;
        private string sendxml;

        public MessageType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string FromID
        {
            get
            {
                return fromID;
            }

            set
            {
                fromID = value;
            }
        }

        public string ToID
        {
            get
            {
                return toID;
            }

            set
            {
                toID = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public string Sendxml
        {
            get
            {
                return sendxml;
            }

            set
            {
                sendxml = value;
            }
        }

        public string Sendtime
        {
            get
            {
                return sendtime;
            }

            set
            {
                sendtime = value;
            }
        }
        public Message()
        { }
        public Message(MessageType type, string fromid, string toid, string content)
        {
            Type = type;
            FromID = fromid;
            ToID = toid;
            Content = content;
            Sendtime = DateTime.Now.ToString();
        }
        public  abstract XmlDocument GenerateSendXml(XmlDocument doc);
    }
}
