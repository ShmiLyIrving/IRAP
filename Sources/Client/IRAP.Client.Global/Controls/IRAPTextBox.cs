using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IRAP.Client.Global.Controls
{
    public class IRAPTextBox : RadTextBox
    {
        public bool EnterMoveNextControl { get; set; }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (EnterMoveNextControl && e.KeyCode == Keys.Return)
                SendKeys.Send("{tab}");
            else
                base.OnKeyDown(e);
        }
    }
}
