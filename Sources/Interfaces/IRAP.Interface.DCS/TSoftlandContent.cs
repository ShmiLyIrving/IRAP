using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IRAP.Interface.DCS
{
    public class TSoftlandContent
    {
        protected TSoftlandHead head = new TSoftlandHead();
        protected TSoftlandBody body = null;
        protected TSoftlandLog log = null;
    }

    public class TSoftlandHead : TCustomXMLArea
    {
        public string ExCode { get; set; }
        public string CorrelationID { get; set; }
        public string CommunityID { get; set; }
        public string SysLogID { get; set; }
        public string UserCode { get; set; }
        public string AgencyLeaf { get; set; }
        public string RoleLeaf { get; set; }
        public string StationID { get; set; }
        public string UnixTime { get; set; }

        public void Resolve(XmlNode head)
        {
            ExCode = GetNodeInnerText(head, "ExCode");
            CorrelationID = GetNodeInnerText(head, "CorrelationID");
            CommunityID = GetNodeInnerText(head, "CommunityID");
            SysLogID = GetNodeInnerText(head, "SysLogID");
            UserCode = GetNodeInnerText(head, "UserCode");
            AgencyLeaf = GetNodeInnerText(head, "AgencyLeaf");
            RoleLeaf = GetNodeInnerText(head, "RoleLeaf");
            StationID = GetNodeInnerText(head, "StationID");
            UnixTime = GetNodeInnerText(head, "UnixTime");
        }

        public XmlNode Generate()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode head = xmlDoc.CreateElement("Head");
            AddXMLLeaf(xmlDoc, head, "ExCode", ExCode);
            AddXMLLeaf(xmlDoc, head, "CorrelationID", CorrelationID);
            AddXMLLeaf(xmlDoc, head, "CommunityID", CommunityID);
            AddXMLLeaf(xmlDoc, head, "SysLogID", SysLogID);
            AddXMLLeaf(xmlDoc, head, "UserCode", UserCode);
            AddXMLLeaf(xmlDoc, head, "AgencyLeaf", AgencyLeaf);
            AddXMLLeaf(xmlDoc, head, "RoleLeaf", RoleLeaf);
            AddXMLLeaf(xmlDoc, head, "StationID", StationID);
            AddXMLLeaf(xmlDoc, head, "UnixTime", UnixTime);

            return head;
        }
    }

    public class TSoftlandBody : TCustomXMLArea
    {
    }

    public class TSoftlandLog : TCustomXMLArea
    {
    }
}
