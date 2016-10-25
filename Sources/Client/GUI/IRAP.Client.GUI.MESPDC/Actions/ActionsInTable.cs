using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class ActionsInTable : CustomAction, IUDFAction
    {
        public ActionsInTable(XmlNode actionParams, ExtendEventHandler extendAction)
            : base(actionParams, extendAction)
        {

        }

        public void DoAction()
        {
            throw new NotImplementedException();
        }
    }
}
