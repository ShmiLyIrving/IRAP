using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace IRAP.Client.Global.Enums
{
    /// <summary>
    /// 编辑状态
    /// </summary>
    public enum EditStatus
    {
        [Description("浏览")]
        Browse = 0,
        [Description("新增")]
        New = 1,
        [Description("编辑")]
        Edit = 2,
        [Description("删除")]
        Delete = 3,
    }
}