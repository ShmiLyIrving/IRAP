using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Shapes;

namespace PlanMGMT.View
{
    /// <summary>
    /// About.xaml 的交互逻辑
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            //PlanMGMT.Utility.ControlHelper.Instance.SetBackground(this.mainBoder, PlanMGMT.Model.PModel.AppBgImg);

            StringBuilder sbMsg = new StringBuilder();
            sbMsg.Append("版 本 号：V");
            sbMsg.Append(Helper.Instance.GetVersion() + "\r\n");

            this.txtInfo.Text = sbMsg.ToString();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", PlanMGMT.Model.PM.StartPath + "\\" + "说明.txt");
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnLink_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as System.Windows.Documents.Hyperlink).CommandParameter != null)
            {
                string link = (sender as System.Windows.Documents.Hyperlink).CommandParameter.ToString();
                System.Diagnostics.Process.Start("iexplore.exe", link);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void txtInfo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount >1)
            {
                System.Diagnostics.Process.Start(PlanMGMT.Model.PM.StartPath + "\\Bg\\2048\\"+ "2048.exe");
            }
        }
    }
}
