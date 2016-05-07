using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class CustomAction
    {
        protected ExtendEventHandler ExtendAction;
        protected int ordinal = 0;

        public CustomAction(XmlNode actionParams, ExtendEventHandler extendAction)
        {
            if (actionParams != null)
            {
                try
                {
                    ordinal = Convert.ToInt32(actionParams.Attributes["Ordinal"].ToString());
                }
                catch 
                {
                    ordinal = -1;
                }
            }

            ExtendAction += extendAction;
        }

        public int Ordinal
        {
            get { return ordinal; }
        }
    }
}