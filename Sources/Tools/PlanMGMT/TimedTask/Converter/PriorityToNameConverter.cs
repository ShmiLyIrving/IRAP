using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.Converter
{
    public class PriorityToNameConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "";

            if (Model.PM.HtPriority.ContainsKey(value.ToString()))
                return Model.PM.HtPriority[value.ToString()];
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
