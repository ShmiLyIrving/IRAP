using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PlanMGMT.Converter
{
    public class StatusToColorBGConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "White";//绿色 #FFDC1720:红色
            string color = "";
            switch ((short)value)
            {
                case 0:
                    color= "#FF538D9E";
                    break;
                case 1:
                    color = "#FF3F52A8";
                    break;
                case 2:
                    color = "#FF009309";
                    break;
                case 3:
                    color = "#FFDC1720";
                    break;           
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
