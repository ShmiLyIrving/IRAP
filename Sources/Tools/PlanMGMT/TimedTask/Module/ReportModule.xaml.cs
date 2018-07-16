using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlanMGMT.BLL;
using PlanMGMT.Utility;
using PlanMGMT.ViewModel;

namespace PlanMGMT.Module
{
    /// <summary>
    /// NoteListModule.xaml 的交互逻辑
    /// </summary>
    public partial class ReportModule : UserControl
    {
        public ReportModule()
        {
            InitializeComponent();
        }
    

        private void myCalender_SelectedDatesChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DateTime dt = (DateTime)(e.AddedItems[0]);
            if (dt != null)
            {
                ((ViewModel.ReportViewModel)base.DataContext).LoadCommand.Execute(dt);
            }
        }

        private void myCalender_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            DateTime dt = (DateTime)(e.AddedDate);
            if (dt != null)
            {
                ((ViewModel.ReportViewModel)base.DataContext).LoadCommand.Execute(dt);
            }
        }

        private void btnCommit_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModel.ReportViewModel)base.DataContext).CommitCommand.Execute(null);
        }
    }
}
