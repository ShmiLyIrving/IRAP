using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Client.Actions
{
    public interface IUDFAction
    {
        void DoAction(
            bool printerMode,
            bool canGenerate,
            string generatePrinterName,
            string printerName);
    }
}