using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.Global.WarningLight;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class SendToControlBoxAction : CustomAction, IUDFAction
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string controlBoxType = "";
        private List<int> relaies = new List<int>();
        private ICustomCtrlBox controlBox = null;

        public SendToControlBoxAction(XmlNode actionParams, ExtendEventHandler extendAction, ref object tag)
            : base(actionParams, extendAction, ref tag)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (actionParams.Attributes["ControlBoxType"] != null)
            {
                controlBoxType = actionParams.Attributes["ControlBoxType"].Value.ToUpper();
            }

            WriteLog.Instance.Write(
                string.Format(
                    "ControlBoxType={0}",
                    controlBoxType),
                strProcedureName);

            if (controlBoxType == "")
                return;

            XmlNode child = null;
            child = actionParams.FirstChild;
            while (child != null)
            {
                if (child.Name.ToUpper() == controlBoxType)
                {
                    try
                    {
                        controlBox =
                            (ICustomCtrlBox)Assembly.Load(
                                "IRAP.Client.GUI.MESPDC").CreateInstance(
                                string.Format(
                                    "IRAP.Client.GUI.MESPDC.Actions.CtrlBox_{0}",
                                    controlBoxType));
                        if (controlBox != null)
                        {
                            controlBox.Init(child);
                        }
                    }
                    catch (Exception ex)
                    {
                        string errText =
                            string.Format("无法创建控制盒对象，原因：[{0}]", ex.Message);

                        WriteLog.Instance.Write(errText, strProcedureName);
                        XtraMessageBox.Show(
                            errText,
                            "错误消息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else if (child.Name.ToUpper() == "RELAY")
                {
                    if (child.Attributes["Value"].Value.ToUpper() == "ON")
                        relaies.Add(1);
                    else
                        relaies.Add(0);
                }

                child = child.NextSibling;
            }
        }

        public void DoAction()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (controlBox == null)
            {
                return;
            }

            controlBox.Send(relaies);
        }
    }

    public class SendToControlBoxFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction, ref object tag)
        {
            return new SendToControlBoxAction(actionParams, extendAction, ref tag);
        }
    }

    internal interface ICustomCtrlBox
    {
        void Init(XmlNode node);
        void Send(List<int> relaies);
    }

    internal class CtrlBox_ZLAN6042 : ICustomCtrlBox
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string strIPAddress = "";

        public void Init(XmlNode node)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (node.Attributes["IPAddress"] != null)
            {
                strIPAddress = node.Attributes["IPAddress"].Value;
            }

            WriteLog.Instance.Write(
                string.Format("IPAddress={0}", strIPAddress),
                strProcedureName);
        }

        public void Send(List<int> relaies)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            int red = 0;
            int yellow = 0;
            int green = 0;

            if (relaies.Count >= 1)
                red = relaies[0];
            if (relaies.Count >= 2)
                yellow = relaies[1];
            if (relaies.Count >= 3)
                green = relaies[2];

            WriteLog.Instance.Write(
                string.Format(
                    "设置控制盒继电器触点状态：Red={0}|Yellow={1}|Green={2}",
                    red, yellow, green),
                strProcedureName);
            ZLan6042.Instance.SetLightStatus(strIPAddress, red, yellow, green);
        }
    }
}