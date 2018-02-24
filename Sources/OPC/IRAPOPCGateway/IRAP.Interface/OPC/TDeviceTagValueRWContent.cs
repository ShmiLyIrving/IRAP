using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IRAP.Interface.OPC
{
    public class TDeviceTagValueRWContent : TSoftlandContent
    {
        public TDeviceTagValueRWContent()
        {
            bodyResponse = new TDeviceTagValueRWRspBody();
            bodyRequest = new TDeviceTagValueRWReqBody();
        }

        public TDeviceTagValueRWReqBody Request
        {
            get { return bodyRequest as TDeviceTagValueRWReqBody; }
        }

        public TDeviceTagValueRWRspBody Response
        {
            get { return bodyResponse as TDeviceTagValueRWRspBody; }
        }

        protected override void ResolveRequestBody(XmlNode node)
        {
            TDeviceTagValueRWReqBody request =
                TDeviceTagValueRWReqBody.LoadFromXMLNode(node);
            if (request != null)
                bodyRequest = request;
        }
        protected override void ResolveResponseBody(XmlNode node)
        {
            TDeviceTagValueRWRspBody reponse =
                TDeviceTagValueRWRspBody.LoadFromXMLNode(node);
            if (reponse != null)
                bodyResponse = reponse;
        }
    }
}