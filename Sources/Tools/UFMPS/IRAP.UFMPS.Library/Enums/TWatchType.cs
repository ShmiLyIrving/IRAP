using System.ComponentModel;
using System.Reflection;

namespace IRAP.UFMPS.Library
{
    public enum TWatchType
    {
        [Description("普通")]
        Normal = 0,
        [Description("信号旗")]
        SignalFlag
    };
}