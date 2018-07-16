using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.Converter
{
    public class StatusToBtnContentConverter : System.Windows.Data.IValueConverter//此接口有以下两个方法
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "";
            switch ((short)value)
            {
                case 0:
                    return "开始";
                case 1:
                    return "结束";
                default:
                    return "结束";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
