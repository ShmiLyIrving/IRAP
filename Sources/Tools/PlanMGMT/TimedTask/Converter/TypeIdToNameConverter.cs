// 版权所有：
// 文 件  名：TypeIdToNameConverter.cs
// 功能描述：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;

using System.Text;

namespace PlanMGMT.Converter
{
    public class TypeIdToNameConverter : System.Windows.Data.IValueConverter//此接口有以下两个方法
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null ||
                Model.PM.NoteTypeHt == null ||
                Model.PM.NoteTypeHt.Count == 0)
                return "";

            if (Model.PM.NoteTypeHt.ContainsKey(value))
                return Model.PM.NoteTypeHt[value];

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
