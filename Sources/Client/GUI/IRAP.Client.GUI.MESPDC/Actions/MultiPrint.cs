using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;
using System.Windows.Forms;
using System.Data;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class MultiPrint : CustomAction, IUDFAction
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private CustomPrint print = null;
        private string sqlCmd = "";

        public MultiPrint(XmlNode actionParams, ExtendEventHandler extendAction)
            : base(actionParams, extendAction)
        {
            print = CustomPrintFactory.CreateInstance(actionParams);
            if (actionParams.Attributes["DataCommand"] != null)
                sqlCmd = actionParams.Attributes["DataCommand"].Value.ToString();
        }

        public void DoAction()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (print == null)
            {

                XtraMessageBox.Show(
                    "不支持当前的打印方式",
                    "系统提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (sqlCmd == "")
            {
                XtraMessageBox.Show(
                    "没有设置打印数据源，无法打印！",
                    "系统提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                DataTable dt = new DataTable();
                IRAPUTSClient.Instance.GetDataTableWithSQL(
                    sqlCmd,
                    ref dt,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("[{0}]{1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        print.DoPrint(dr[0].ToString());
                    }
                else
                {
                    XtraMessageBox.Show(errText, strProcedureName);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }

    public class MultiPrintFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction)
        {
            return new MultiPrint(actionParams, extendAction);
        }
    }
}
