using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PlanMGMT.Converter
{
    public class UserCodeColor2Converter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "#FF3F52A8";
            if((string)value==Utility.ProU.Instance.PspUser.UserCode)
            {
                return "Black";
            }
            else
            {
                return "#FF3F52A8";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
