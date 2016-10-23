using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace IRAP.Client.Global.Enums
{
    /// <summary>
    /// KPI 状态
    /// </summary>
    public enum KPIStatus
    {
        [Description("未生产")]
        ksNotProduced = 0,
        [Description("正常")]
        ksRegular = 1,
        [Description("警告")]
        ksWarning = 2,
        [Description("异常")]
        ksAbnormal = 3,
    }
}