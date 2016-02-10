using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Client.Global
{
    public class AppOperationLog
    {
        public AppOperationLog(DateTime time, int errCode, string errText)
        {
            Time = time;
            ErrCode = errCode;
            ErrText = errText;
        }

        public AppOperationLog()
        {
        }

        public DateTime Time { get; set; }

        public int ErrCode { get; set; }

        public string ErrText { get; set; }
    }
}