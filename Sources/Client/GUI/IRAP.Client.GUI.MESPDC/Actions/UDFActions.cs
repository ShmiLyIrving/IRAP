using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class UDFActions
    {
        public static void DoActions(string actionParams, ExtendEventHandler extendAction)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(actionParams);

            foreach (XmlNode node in xmlDoc.SelectNodes("ROOT/Action"))
            {
                string factoryName = node.Attributes["Action"].Value.ToString();
                if (factoryName != "")
                {
                    IUDFActionFactory factory = 
                        (IUDFActionFactory)Assembly.Load("IRAP.Client.GUI.MESPDC").CreateInstance(
                            string.Format(
                                "IRAP.Client.GUI.MESPDC.Actions.{0}Factory", 
                                factoryName));
                    if (factory != null)
                    {
                        IUDFAction action = factory.CreateAction(node, extendAction);

                        try
                        {
                            action.DoAction();
                        }
                        catch (Exception error)
                        {
                            XtraMessageBox.Show(
                                error.Message, 
                                "系统信息", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
