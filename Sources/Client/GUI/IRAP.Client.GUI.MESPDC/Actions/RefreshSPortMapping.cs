using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class RefreshSPortMapping : CustomAction, IUDFAction
    {
        private List<ScannerView> views = null;

        private string sportName = "";
        private int workUnitLeaf = 0;
        private string workUnitCode = "";
        private string workUnitName = "";

        public RefreshSPortMapping(XmlNode actionParams, ExtendEventHandler extendAction, ref object tag) : 
            base(actionParams, extendAction, ref tag)
        {
            if (tag is List<ScannerView>)
                views = tag as List<ScannerView>;

            if (actionParams.Attributes["PortName"] != null)
                sportName = actionParams.Attributes["PortName"].Value;
            if (actionParams.Attributes["WorkUnitLeaf"] != null)
                workUnitLeaf = Tools.ConvertToInt32(actionParams.Attributes["WorkUnitLeaf"].Value, -1);
            if (actionParams.Attributes["WorkUnitCode"] != null)
                workUnitCode = actionParams.Attributes["WorkUnitCode"].Value;
            if (actionParams.Attributes["WorkUnitName"] != null)
                workUnitName = actionParams.Attributes["WorkUnitName"].Value;
        }

        public void DoAction()
        {
            if (views == null)
                return;

            if (workUnitLeaf >= 0)
                foreach (ScannerView view in views)
                {
                    if (view.PortName.ToUpper() == sportName.ToUpper())
                    {
                        view.WorkUnitLeafID = workUnitLeaf;
                        view.WorkUnitCode = workUnitCode;
                        view.WorkUnitName = workUnitName;
                    }
                }
        }
    }

    public class RefreshSPortMappingFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction, ref object tag)
        {
            return new RefreshSPortMapping(actionParams, extendAction, ref tag);
        }
    }
}
