﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;

namespace IRAP.Interface.OPC
{
    public class TGetDevicesContent : TSoftlandContent
    {
        private TGetDevicesReqBody reqBody = new TGetDevicesReqBody();
        private TGetDevicesRspBody rspBody = new TGetDevicesRspBody();

        public TGetDevicesContent()
        {
            bodyRequest = new TGetDevicesReqBody();
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

        protected override void ResolveBody(XmlNode node)
        {
            TGetDevicesReqBody request =
                TGetDevicesReqBody.LoadFromXMLNode(node);
            if (request != null)
                bodyRequest = request;
        }
    }
}
