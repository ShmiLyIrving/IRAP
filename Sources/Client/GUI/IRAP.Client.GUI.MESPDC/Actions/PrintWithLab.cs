using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using IRAP.Global;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class PrintWithLabAction : CustomAction, IUDFAction
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private StringBuilder labFileName = new StringBuilder();
        private string cnt = "1";
        private StringBuilder var0 = new StringBuilder();
        private StringBuilder var1 = new StringBuilder();
        private StringBuilder var2 = new StringBuilder();
        private StringBuilder var3 = new StringBuilder();
        private StringBuilder var4 = new StringBuilder();
        private StringBuilder var5 = new StringBuilder();
        private StringBuilder var6 = new StringBuilder();
        private StringBuilder var7 = new StringBuilder();
        private StringBuilder var8 = new StringBuilder();


        [DllImport(
            "PrintLabel.dll",
            CharSet = CharSet.Ansi,
            PreserveSig = false,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int PrintLabel(
            StringBuilder fileName,
            int cnt,
            StringBuilder var0,
            StringBuilder var1,
            StringBuilder var2,
            StringBuilder var3,
            StringBuilder var4,
            StringBuilder var5,
            StringBuilder var6,
            StringBuilder var7,
            StringBuilder var8);

        public PrintWithLabAction(XmlNode actionParams, ExtendEventHandler extendAction)
            : base(actionParams, extendAction)
        {
            if (actionParams.Attributes["Template"] != null)
                labFileName.Append(actionParams.Attributes["Template"].Value);
            if (actionParams.Attributes["Cnt"] != null)
                cnt = actionParams.Attributes["Cnt"].Value;
            if (actionParams.Attributes["Var0"] != null)
                var0.Append(actionParams.Attributes["Var0"].Value);
            if (actionParams.Attributes["Var1"] != null)
                var1.Append(actionParams.Attributes["Var1"].Value);
            if (actionParams.Attributes["Var2"] != null)
                var2.Append(actionParams.Attributes["Var2"].Value);
            if (actionParams.Attributes["Var3"] != null)
                var3.Append(actionParams.Attributes["Var3"].Value);
            if (actionParams.Attributes["Var4"] != null)
                var4.Append(actionParams.Attributes["Var4"].Value);
            if (actionParams.Attributes["Var5"] != null)
                var5.Append(actionParams.Attributes["Var5"].Value);
            if (actionParams.Attributes["Var6"] != null)
                var6.Append(actionParams.Attributes["Var6"].Value);
            if (actionParams.Attributes["Var7"] != null)
                var7.Append(actionParams.Attributes["Var7"].Value);
            if (actionParams.Attributes["Var8"] != null)
                var8.Append(actionParams.Attributes["Var8"].Value);
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
                    string.Format(
                        "调用打印动态链接库 PrintLabel.dll，输入参数：" +
                        "Template={0}|Cnt={1}|Ver0={2}|Var1={3}|Var2={4}" +
                        "Var3={5}|Var4={6}|Var5={7}|Var6={8}|Var7={9}|Var8={10}",
                        labFileName,
                        cnt,
                        var0,
                        var1,
                        var2,
                        var3,
                        var4,
                        var5,
                        var6,
                        var7,
                        var8),
                    strProcedureName);

                PrintLabel(
                    labFileName, 
                    Convert.ToInt32(cnt), 
                    var0, 
                    var1, 
                    var2, 
                    var3, 
                    var4, 
                    var5, 
                    var6, 
                    var7, 
                    var8);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                IRAPMessageBox.Instance.Show(
                    error.Message,
                    "标签打印",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                WriteLog.Instance.Write(error.Message, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }

    public class PrintWithLabFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction)
        {
            return new PrintWithLabAction(actionParams, extendAction);
        }
    }
}