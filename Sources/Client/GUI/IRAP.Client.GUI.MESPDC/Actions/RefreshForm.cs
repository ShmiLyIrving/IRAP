using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class RefreshFormAction : CustomAction, IUDFAction
    {
        public RefreshFormAction(XmlNode actionParam, ExtendEventHandler extendAction, object tag)
            : base(actionParam, extendAction, tag)
        {
        }

        public void DoAction()
        {
            if (ExtendAction != null)
            {
                ExtendAction();
            }
        }
    }

    public class RefreshFormFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction, object tag)
        {
            return new RefreshFormAction(actionParams, extendAction, tag);
        }
    }
}
