using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PlanMGMT.Converter
{
    public class CodeToPlanConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            ObservableCollection<Model.Plan> PlanList = new ObservableCollection<Model.Plan>();
            foreach(var plan in BLL.PlanBLL.Instance.CurrentPlanList)
            {
                if(plan.InCharge == value.ToString())
                {
                    PlanList.Add(plan);
                }
            }
            return PlanList;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
