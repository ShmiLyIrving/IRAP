using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IRAP.Client.Global.GUI
{
    public partial class frmCustomKanbanBase : IRAP.Client.Global.GUI.frmCustomFuncBase
    {

        /// <summary>
        /// 当需要切换下一功能时触发
        /// </summary>
        public event SwitchToNextFunctionHandler OnSwitch;

        public frmCustomKanbanBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主框架菜单
        /// </summary>
        public RadRibbonBar SystemMenu { get; set; }

        /// <summary>
        /// 系统登录标识
        /// </summary>
        public long SysLogID { get; set; }
    }

    public delegate void SwitchToNextFunctionHandler(int itemID);
}
