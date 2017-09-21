using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.SubSystem;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    /// <summary>
    /// 万能表单 OutputStr 返回值中定义的操作：
    /// 
    /// </summary>
    public class SelectChoiceAction : CustomAction, IUDFAction
    {
        int t107LeafID = 0;
        int t102LeafID = 0;

        public SelectChoiceAction(XmlNode actionParams, ExtendEventHandler extendAction, object tag)
            : base(actionParams, extendAction, tag)
        {
            t107LeafID = Tools.ConvertToInt32(actionParams.Attributes["T107LeafID"].Value);
            t102LeafID = Tools.ConvertToInt32(actionParams.Attributes["T102LeafID"].Value);
        }

        public void DoAction()
        {
            try
            {
                if (t107LeafID == 0)
                    AvailableWIPStations.Instance.Options.RefreshOptionOne(
                        CurrentOptions.Instance.OptionOne.T107LeafID);
                else
                    AvailableWIPStations.Instance.Options.RefreshOptionOne(t107LeafID);

                if (t102LeafID != 0)
                    AvailableWIPStations.Instance.Options.RefreshOptionTwo(t102LeafID);
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

    public class SelectChoiceFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction, object tag)
        {
            return new SelectChoiceAction(actionParams, extendAction, tag);
        }
    }
}
