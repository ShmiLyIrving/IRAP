using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Global
{
    public class TimeParser
    {
        /// <summary>
        /// 把秒转换成分钟
        /// </summary>
        public static int SecondToMinute(int second)
        {
            decimal mm = (decimal)((decimal)second / (decimal)60);
            return Convert.ToInt32(Math.Ceiling(mm));
        }

        /// <summary>
        /// 返回某年某月的最后一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>日</returns>
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            int day = lastDay.Day;
            return day;
        }

        /// <summary>
        /// 计算时间差
        /// </summary>
        public static string DateDiff(DateTime dateTime1, DateTime dateTime2)
        {
            string dateDiff = "";

            TimeSpan ts = dateTime2 - dateTime1;

            if (ts.TotalSeconds == 0)
            {
                dateDiff = "准时";
            }
            else
            {
                if (ts.TotalSeconds > 0)
                {
                    dateDiff = "提前";
                }
                else
                {
                    dateDiff = "延迟";
                }

                dateDiff = dateDiff + (ts.Days == 0 ? "" : Math.Abs(ts.Days).ToString() + "天");
                dateDiff = dateDiff + (ts.Hours == 0 ? "" : Math.Abs(ts.Hours).ToString() + "时");
                dateDiff = dateDiff + (ts.Minutes == 0 ? "" : Math.Abs(ts.Minutes).ToString() + "分");
                dateDiff = dateDiff + (ts.Seconds == 0 ? "" : Math.Abs(ts.Seconds).ToString() + "秒");
            }

            return dateDiff;
        }

        /// <summary>
        /// 当前时间转换成 Unix 时间
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long LocalTimeToUnix(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(datetime - sTime).TotalSeconds;
        }
    }
}
