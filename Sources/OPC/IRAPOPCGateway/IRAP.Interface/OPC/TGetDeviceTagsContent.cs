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
        }

        public TGetDeviceTagsReqBody Request
        {
            get { return bodyRequest as TGetDeviceTagsReqBody; }
        }

        public TGetDeviceTagsRspBody Response
        {
            get { return bodyResponse as TGetDeviceTagsRspBody; }
        }

        protected override void ResolveBody(XmlNode node)
        {
            TGetDeviceTagsReqBody request =
                TGetDeviceTagsReqBody.LoadFromXMLNode(node);
            if (request != null)
                bodyRequest = request;
        }
    }
}
