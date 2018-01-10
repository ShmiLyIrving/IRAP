using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IRAP.Interface.OPC
{
    public class TGetDeviceTagsContent : TSoftlandContent
    {
        public TGetDeviceTagsContent()
        {
            bodyResponse = new TGetDeviceTagsRspBody();
            bodyRequest = new TGetDeviceTagsReqBody();
        }

        public TGetDeviceTagsReqBody Request
        {
            get { return bodyRequest as TGetDeviceTagsReqBody; }
        }

        public TGetDeviceTagsRspBody Response
        {
            get { return bodyResponse as TGetDeviceTagsRspBody; }
        }

        protected override void ResolveRequestBody(XmlNode node)
        {
            TGetDeviceTagsReqBody request =
                TGetDeviceTagsReqBody.LoadFromXMLNode(node);
            if (request != null)
                bodyRequest = request;
        }
        protected override void ResolveResponseBody(XmlNode node)
        {
            TGetDeviceTagsRspBody reponse =
                TGetDeviceTagsRspBody.LoadFromXMLNode(node);
            if (reponse != null)
                bodyResponse = reponse;
        }
    }
}
