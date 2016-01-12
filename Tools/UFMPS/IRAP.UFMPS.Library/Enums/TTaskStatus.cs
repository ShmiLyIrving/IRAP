using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace IRAP.UFMPS.Library
{
    public enum TTaskStatus
    {
        [Description("停止")]
        taskStopped = 0,
        [Description("运行中")]
        taskRunning = 1,
        [Description("暂停")]
        taskPaused = 2,
        [Description("终止")]
        taskTerminated = 3
    };
}
