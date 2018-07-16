using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PlanMGMT.Utility;
using PlanMGMT.Model;

namespace PlanMGMT.View
{
    /// <summary>
    /// Config.xaml 的交互逻辑
    /// </summary>
    public partial class Config : Window
    {
        private List<Entity.BackGround> bgs = new List<Entity.BackGround>();
        public Config()
        {
            InitializeComponent();
            bgs.Add(new Entity.BackGround(0,"蓝", PM.StartPath + "\\Bg\\bg.jpg"));
            bgs.Add(new Entity.BackGround(1, "青", PM.StartPath + "\\Bg\\bg1.png"));
            bgs.Add(new Entity.BackGround(2, "深", PM.StartPath + "\\Bg\\bg2.png"));
            bgs.Add(new Entity.BackGround(3, "红", PM.StartPath + "\\Bg\\bg3.png"));
            bgs.Add(new Entity.BackGround(4, "自定义", ""));
            cboBg.ItemsSource = bgs;
            this.MouseLeftButtonDown += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed) this.DragMove();
            };
            this.btnClose.Click += (s, e) =>
            {
                this.Close();
            };
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboBg.SelectedIndex != -1)
            {
                if ((cboBg.SelectedItem as Entity.BackGround).index != 4)
                {
                    txtimgpath.IsEnabled = false;
                    btnOpenAppImg.IsEnabled = false;
                    (this.Owner as MainWindow).SetBackground((cboBg.SelectedItem as Entity.BackGround).ImagePath);
                    ((ViewModel.ConfigViewModel)base.DataContext).BgImg = (cboBg.SelectedItem as Entity.BackGround).ImagePath;
                }
                else
                {
                    this.txtimgpath.IsEnabled = true;
                    btnOpenAppImg.IsEnabled = true;
                }
            }
        }
    }
}
