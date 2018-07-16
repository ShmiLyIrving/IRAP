using System;
using System.Collections.Generic;
using System.Globalization;
using PlanMGMT.Entity;
using System.Linq;
using System.Text;

namespace PlanMGMT.Converter
{
    public class ConvBlueConverter : System.Windows.Data.IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null && values[1] == null)
                return "false";
            List<DateTime> ds = values[1] as List<DateTime>;
            if(ds ==null)
                return "false";
            DateTime c =System.Convert.ToDateTime(values[0]);
            foreach(DateTime d in ds)
            {
                if (c.Date == d.Date)
                    return "true";                  
            }
            return "false";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
