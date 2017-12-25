using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IRAP.Interface.OPC
{
    public class TUpdateKepServContent : TSoftlandContent
    {
        public TUpdateKepServContent()
        {
            bodyResponse = new TUpdateKepServRspBody();
        }

        /// <summary>
        /// 请求报文对象
        /// </summary>
        public TUpdateKepServReqBody Request
        {
            get { return bodyRequest as TUpdateKepServReqBody; }
        }

        /// <summary>
        /// 响应报文对象
        /// </summary>
        public TUpdateKepServRspBody Response
        {
            get { return bodyResponse as TUpdateKepServRspBody; }
        }

        protected override void ResolveRequestBody(XmlNode node)
        {
            TUpdateKepServReqBody request =
                TUpdateKepServReqBody.LoadFromXMLNode(node);
            if (request != null)
                bodyRequest = request;
        }
    }
}
