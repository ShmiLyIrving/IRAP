using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using IRAP.Global;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class PrintToLPTAction : CustomAction, IUDFAction
    {
        private string className =
          MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private string strLPTPort = "LPT1";
        private string strData = "";

        public PrintToLPTAction(XmlNode actionParams, ExtendEventHandler extendAction, object tag)
            : base(actionParams, extendAction, tag)
        {
            try
            {
                strLPTPort = actionParams.Attributes["PrintTo"].Value.ToString();
            }
            catch { }
            strData = actionParams.Attributes["Data"].Value.ToString();
        }

        public void DoAction()
        {
            string strProcedureName =
                string.Format(
                "{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                WriteLog.Instance.Write(
                    string.Format("向端口[{0}]发送打印内容[{1}]", strLPTPort, strData), 
                    strProcedureName);
                using (LPTPrint print = new LPTPrint())
                {
                    try
                    {
                        print.LPTWrite(strLPTPort, strData);
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        XtraMessageBox.Show(
                            error.Message, 
                            "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }

    public class PrintToLPTFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction, object tag)
        {
            return new PrintToLPTAction(actionParams, extendAction, tag);
        }
    }
}
