﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IRAP.Client.Actions
{
    public interface IUDFActionFactory
    {
        IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction);
    }
}