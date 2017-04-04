using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VA_ITCMS2000
{
    /// <summary>
    /// 线程日志事件
    /// </summary>
    public delegate void ThreadLogEventHandler(int threadID, string message);
}