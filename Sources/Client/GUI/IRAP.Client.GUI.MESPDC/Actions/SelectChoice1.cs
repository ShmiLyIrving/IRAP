using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using IRAP.Client.SubSystem;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    /// <summary>
    /// 万能表单 OutputStr 返回值中定义的操作：
    /// 
    /// </summary>
    public class SelectChoice1Action : CustomAction, IUDFAction
    {
        string searchName = "";
        int searchValue = 0;

        public SelectChoice1Action(XmlNode actionParams, ExtendEventHandler extendAction)
            : base(actionParams, extendAction)
        {
            searchName = actionParams.Attributes["ObjectName"].Value.ToString();
            try
            {
                searchValue = Convert.ToInt32(actionParams.Attributes["ObjectValue"].Value.ToString());
            }
            catch
            {
                searchValue = -1;
            }
        }

        public void DoAction()
        {
            try
            {
                AvailableWIPStations.Instance.Options.RefreshOptionTwo(searchValue);
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

    public class SelectChoice1Factory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction)
        {
            return new SelectChoice1Action(actionParams, extendAction);
        }
    }
}
