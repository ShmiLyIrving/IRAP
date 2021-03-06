﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class UDFActions
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public static void DoActions(
            string actionParams, 
            ExtendEventHandler extendAction,
            ref object tag)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(actionParams);

            foreach (XmlNode node in xmlDoc.SelectNodes("ROOT/Action"))
            {
                string factoryName = node.Attributes["Action"].Value.ToString();
                WriteLog.Instance.Write(
                    string.Format("FactoryName={0}", factoryName),
                    strProcedureName);
                
                if (factoryName != "")
                {
                    factoryName =
                        string.Format(
                            "IRAP.Client.GUI.MESPDC.Actions.{0}Factory",
                            factoryName);

                    IUDFActionFactory factory =
                        (IUDFActionFactory)Assembly.Load("IRAP.Client.GUI.MESPDC").CreateInstance(factoryName);
                    if (factory != null)
                    {
                        IUDFAction action = factory.CreateAction(node, extendAction, ref tag);

                        try
                        {
                            WriteLog.Instance.Write(
                                string.Format(
                                    "执行类[{0}]中的动作",
                                    action.GetType().Name),
                                strProcedureName);
                            action.DoAction();
                            WriteLog.Instance.Write("执行完成", strProcedureName);
                        }
                        catch (Exception error)
                        {
                            XtraMessageBox.Show(
                                error.Message, 
                                "系统信息", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                            throw error;
                        }
                    }
                    else
                    {
                        WriteLog.Instance.Write(
                            string.Format("无法创建工厂对象[{0}]", factoryName),
                            strProcedureName);
                        throw new Exception($"无法创建工厂对象[{factoryName}]");
                    }
                }
            }
        }
    }
}
