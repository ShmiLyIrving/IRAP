using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;

namespace IRAP.Interface.OPC
{
    public class TGetDevicesContent : TSoftlandContent
    {
        public TGetDevicesContent()
        {
            bodyResponse = new TGetDevicesRspBody();
        }

        public TGetDevicesRspBody Response
        {
            get { return bodyResponse as TGetDevicesRspBody; }
        }

        public TGetDevicesReqBody Request
        {
            get { return bodyRequest as TGetDevicesReqBody; }
        }

        protected override void ResolveRequestBody(XmlNode node)
        {
            TGetDevicesReqBody request =
                TGetDevicesReqBody.LoadFromXMLNode(node);
            if (request != null)
                bodyRequest = request;
        }
    }
}
