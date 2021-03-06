﻿using System;
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
            bodyRequest = new TUpdateDeviceTagsReqBody();
        }

        public TUpdateDeviceTagsReqBody Request
        {
            get { return bodyRequest as TUpdateDeviceTagsReqBody; }
        }

        public TUpdateDeviceTagsRspBody Response
        {
            get { return bodyResponse as TUpdateDeviceTagsRspBody; }
        }

        protected override void ResolveRequestBody(XmlNode node)
        {
            TUpdateDeviceTagsReqBody request =
                TUpdateDeviceTagsReqBody.LoadFromXMLNode(node);
            if (request != null)
                bodyRequest = request;
        }
        protected override void ResolveResponseBody(XmlNode node)
        {
            TUpdateDeviceTagsRspBody response =
                TUpdateDeviceTagsRspBody.LoadFromXMLNode(node);
            if (response != null)
                bodyResponse = response;
        }
    }
}
