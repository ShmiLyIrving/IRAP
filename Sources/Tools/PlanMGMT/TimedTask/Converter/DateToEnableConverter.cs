using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PlanMGMT.Converter
{
    public class DateToEnableConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value ==null)
            {
                return false;
            }
            DateTime dt = System.Convert.ToDateTime(value);
            if (BLL.ReportBLL.Instance.GetCurLog(dt)==null&&dt<=DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
