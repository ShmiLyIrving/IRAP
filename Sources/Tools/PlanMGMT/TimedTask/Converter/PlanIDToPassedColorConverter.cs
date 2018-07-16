using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PlanMGMT.Converter
{
    public class PlanIDToPassedColorConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "Transparent";
            Model.Plan p = BLL.PlanBLL.Instance.CurrentPlanList.Find(a => a.PlanID == (int)value);
            if(p.PlanEnd<DateTime.Now&&p.Status!=2)
            {
                return "Orange";
            }
            else
            {
                return "Transparent";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
