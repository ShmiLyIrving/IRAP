// 版权所有：
// 文 件  名：DateToString.cs
// 功能描述：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;

using System.Text;

namespace PlanMGMT.Converter
{
    public class EnableToBtnContentConverter : System.Windows.Data.IValueConverter//此接口有以下两个方法
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "";

            string tmp = (string)value;
            return tmp == "1" ? "禁用" : "启用";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

