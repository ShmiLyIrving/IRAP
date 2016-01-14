using System.ComponentModel;
using System.Reflection;

namespace IRAP.UFMPS.Library
{
    public enum TDocumentProcessType
    {
        [Description("FTP上传")]
        FTP = 0,
        [Description("移动到指定文件夹")]
        MoveTo = 1,
        [Description("执行存储过程")]
        CallStoreProcedure = 2,
        [Description("导入指定数据表 - 多线程处理")]
        InsertIntoTableThread = 3,
        [Description("导入制定数据表 - 单线程处理")]
        InsertIntoTableWithSingle = 4,
    };
}