using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace IRAP.Global
{
    public class SetSystemDateTime
    {
        [DllImport("kernel32.dll")]
        private static extern void GetLocalTime(SystemTime st);
        [DllImport("kernel32.dll")]
        private static extern void SetLocalTime(SystemTime st);

        /// <summary>
        /// 重置系统当前时间
        /// </summary>
        /// <param name="dt"></param>
        public static void SetSystemTime(DateTime dt)
        {
            SystemTime newTime = new SystemTime();
            GetLocalTime(newTime);
            newTime.vYear = (ushort)dt.Year;
            newTime.vMonth = (ushort)dt.Month;
            newTime.vDay = (ushort)dt.Day;
            newTime.vHour = (ushort)dt.Hour;
            newTime.vMinute = (ushort)dt.Minute;
            newTime.vSecond = (ushort)dt.Second;
            SetLocalTime(newTime);
        }
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    internal class SystemTime
    {
        public ushort vYear;
        public ushort vMonth;
        public ushort vDayOfWeek;
        public ushort vDay;
        public ushort vHour;
        public ushort vMinute;
        public ushort vSecond;
    }
}