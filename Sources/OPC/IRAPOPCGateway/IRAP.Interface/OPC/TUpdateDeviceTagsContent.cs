using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TUpdateDeviceTagsContent : TSoftlandContent
    {
        public TUpdateDeviceTagsContent()
        {
            bodyResponse = new TUpdateDeviceTagsRspBody();
        }

        public TUpdateDeviceTagsReqBody RequestBody
        {
            get { return bodyRequest as TUpdateDeviceTagsReqBody; }
        }

        public TUpdateDeviceTagsRspBody ResponseBody
        {
            get { return bodyResponse as TUpdateDeviceTagsRspBody; }
        }

        protected override void ResolveBody(XmlNode node)
        {
            TUpdateDeviceTagsReqBody request =
                TUpdateDeviceTagsReqBody.LoadFromXMLNode(node);
            if (request != null)
                bodyRequest = request;
        }
    }
}
