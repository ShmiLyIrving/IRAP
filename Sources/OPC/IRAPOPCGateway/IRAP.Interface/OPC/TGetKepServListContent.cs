using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IRAP.Interface.OPC
{
    public class TGetKepServListContent : TSoftlandContent
    {
        public TGetKepServListContent()
        {
            bodyResponse = new TGetKepServListRspBody();
            bodyRequest = new TGetKepServListReqBody();
        }

        public TGetKepServListReqBody Request
        {
            get { return bodyRequest as TGetKepServListReqBody; }
        }

        public TGetKepServListRspBody Response
        {
            get { return bodyResponse as TGetKepServListRspBody; }
        }

        protected override void ResolveRequestBody(XmlNode node)
        {
            TGetKepServListReqBody request =
                TGetKepServListReqBody.LoadFromXMLNode(node);
            if (request != null)
                bodyRequest = request;
        }
        protected override void ResolveResponseBody(XmlNode node)
        {
            TGetKepServListRspBody response =
                TGetKepServListRspBody.LoadFromXMLNode(node);
            if (response != null)
                bodyResponse = response;
        }
    }
}
