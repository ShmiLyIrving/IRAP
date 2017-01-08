using System.Windows.Forms;

namespace IRAPPrinterServer
{
    public delegate void LogOutputHandler(string msg, string modeName, ToolTipIcon icon);
    public delegate void AppendMessageContext(string context);
}