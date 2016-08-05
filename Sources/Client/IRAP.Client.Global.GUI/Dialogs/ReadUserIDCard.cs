using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.Global.GUI.Dialogs
{
    /// <summary>
    /// 读取用户的 ID 卡，获取用户身份信息
    /// </summary>
    public class ReadUserIDCard
    {
        private static ReadUserIDCard _instance = null;
        private DialogResult dialogResult = DialogResult.None;

        public static ReadUserIDCard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ReadUserIDCard();
                return _instance;
            }
        }

        public DialogResult DialogResult
        {
            get { return dialogResult; }
        }

        public string Execute()
        {
            return Execute("");
        }

        public string Execute(string notifyMessage)
        {
            using (frmReadUserIDCard readUserIDCard = new frmReadUserIDCard())
            {
                if (notifyMessage != "")
                {
                    readUserIDCard.Caption = notifyMessage;
                }

                dialogResult = readUserIDCard.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    return readUserIDCard.UserIDCardNo;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
