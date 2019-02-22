using System;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;

namespace IRAP.Client.Actions
{
    public class UDFActions
    {
        public static void DoActions(
            string actionParams, 
            bool printerMode,
            bool canGenerate,
            string generatePrinterName,
            string printerName,
            ExtendEventHandler extendAction)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(actionParams);

            foreach (XmlNode node in xmlDoc.SelectNodes("ROOT/Action"))
            {
                string factoryName = node.Attributes["Action"].Value.ToString();
                if (factoryName != "")
                {
                    IUDFActionFactory factory =
                        (IUDFActionFactory)Assembly.Load("IRAP.Client.Actions").CreateInstance(
                            string.Format(
                                "IRAP.Client.Actions.{0}Factory",
                                factoryName));
                    if (factory != null)
                    {
                        IUDFAction action = factory.CreateAction(node, extendAction);

                        try
                        {
                            action.DoAction(
                                printerMode,
                                canGenerate,
                                generatePrinterName,
                                printerName);
                        }
                        catch (Exception error)
                        {
                            throw error;
                        }
                    }
                }
            }
        }

        public static void DoActions(
            XmlNode xmlNode,
            bool printerMode,
            bool canGenerate,
            string generatePrinterName,
            string printerName,
            ExtendEventHandler extendAction)
        {
            foreach (XmlNode node in xmlNode.SelectNodes("ROOT/Action"))
            {
                string factoryName = node.Attributes["Action"].Value.ToString();
                if (factoryName != "")
                {
                    IUDFActionFactory factory =
                        (IUDFActionFactory)Assembly.Load("IRAP.Client.Actions").CreateInstance(
                            string.Format(
                                "IRAP.Client.Actions.{0}Factory",
                                factoryName));
                    if (factory != null)
                    {
                        IUDFAction action = factory.CreateAction(node, extendAction);

                        try
                        {
                            action.DoAction(
                                printerMode,
                                canGenerate,
                                generatePrinterName,
                                printerName);
                        }
                        catch (Exception error)
                        {
                            throw error;
                        }
                    }
                }
            }
        }
    }
}