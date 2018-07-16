using System;
using System.Windows.Data;
using TimedTask.Enums;
namespace TimedTask.Converter
{
    /// <summary>
    /// 任务列表显示模板 TaskDisplayToItemTemplateConverter
    /// </summary>
    public class TaskDisplayToItemTemplateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var type = (TaskListDisplay)value;

            string key = null;
            switch (type)
            {
                case TaskListDisplay.List:
                    key = "TaskListTitleTemplate";
                    break;
                case TaskListDisplay.Summary:
                    key = "TaskListSummaryTemplate";
                    break;
                default:
                    key = "TaskListTitleTemplate";
                    break;
            }
            return System.Windows.Application.Current.Resources[key];//MainWindow 窗口中的资源
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
            //throw new NotImplementedException();
        }
    }
}
