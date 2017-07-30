using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace IRAP.Client.Global.Enums
{
    public enum ProductionStatus
    {
        [Description("空闲")]
        Idle = 0,
        [Description("正在生产")]
        Busy = 1,
    }
}
