using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Windows.Forms;
using System.Data;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class MultipleCommandAction : CustomAction, IUDFAction
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string sqlCommand = "";

        public MultipleCommandAction(
            XmlNode actionParams, 
            ExtendEventHandler extendAction,
            ref object tag)
            : base(actionParams, extendAction, ref tag)
        {
            if (actionParams.Attributes["SQLCommand"] != null)
                sqlCommand = actionParams.Attributes["SQLCommand"].Value;
        }

        public void DoAction()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (sqlCommand == "")
            {
                XtraMessageBox.Show(
                    "没有设置行动数据源，无法执行！",
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
                    sqlCommand,
                    ref dt,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("[{0}]{1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            UDFActions.DoActions(
                                dr[0].ToString(),
                                ExtendAction, 
                                ref tag);
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(
                                string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                                    error.Message,
                                    error.StackTrace),
                                strProcedureName);
                        }
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

    public class MultipleCommandFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction, ref object tag)
        {
            return new MultipleCommandAction(actionParams, extendAction, ref tag);
        }
    }
}