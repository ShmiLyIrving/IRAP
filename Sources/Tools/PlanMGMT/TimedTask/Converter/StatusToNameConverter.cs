using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.Converter
{
    public class StatusToNameConverter : System.Windows.Data.IValueConverter//此接口有以下两个方法
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "";

            string tmp = "";
            switch (value.ToString())
            {
                case "0": tmp = "未开始"; break;
                case "1": tmp = "进行中"; break;
                case "2": tmp = "已完成"; break;
                case "3": tmp = "暂停"; break;
                default: tmp = "未知"; break;
            }
            return tmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
