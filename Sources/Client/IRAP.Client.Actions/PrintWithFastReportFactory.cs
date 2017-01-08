using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IRAP.Client.Actions
{
    public class PrintWithFastReportFactory :
        CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(
            XmlNode actionParams,
            ExtendEventHandler extendAction)
        {
            return new PrintWithFastReportAction(
                actionParams,
                extendAction);
        }
    }
}