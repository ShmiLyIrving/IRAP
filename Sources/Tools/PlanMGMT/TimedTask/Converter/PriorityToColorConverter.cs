using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.Converter
{
    public class PriorityToColorConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string[] colors = { "#957AFF", "#FF61E5", "#54DDFF", "#4DFF4D", "#FFDC2E", "#FF9991", "#37FF05", "#6B659E", "#FF85C6" };
            if (value == null)
                return colors[0];

            int tmp = Int32.Parse(value.ToString());
            return colors[tmp];
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
