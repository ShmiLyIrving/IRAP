using System.ComponentModel;
using System.Reflection;

namespace IRAP.UFMPS.Library
{
    public enum TThreadStartMark
    {
        [Description("文件导入完成")]
        FileDealCompleted = 0,
        [Description("导入表空白")]
        TableIsEmpty = 1,
    }
}