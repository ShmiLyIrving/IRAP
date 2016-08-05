using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace IRAP.Client.GUI.CAS.Enums
{
    public enum LightStatus
    {
        [Description("灭")]
        Off = 0,
        [Description("亮")]
        On = 1,
        [Description("闪烁")]
        Flash = 2,
    }
}