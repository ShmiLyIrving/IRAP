using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlanMGMT.BLL;
using Visifire.Charts;

namespace PlanMGMT.Module
{
    /// <summary>
    /// MainModule.xaml 的交互逻辑
    /// </summary>
    public partial class MainModule : System.Windows.Controls.UserControl
    {

        private string _info;//统计信息
        private Dictionary<string, string> _dic;

        private List<string> strListx = new List<string>();
        private List<string> strListy = new List<string>();

        public MainModule()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            strListx = new List<string>();
            strListy = new List<string>();
            Simon.Children.Clear();
            this._info = "";
            this._dic = new Dictionary<string, string>();

            this._dic.Add("进行中任务", BLL.PlanBLL.Instance.RunningTaskCnt().ToString());
            this._dic.Add("未开始任务", BLL.PlanBLL.Instance.UnStartTaskCnt().ToString());
            this._dic.Add("暂停中任务", BLL.PlanBLL.Instance.StopTaskCnt().ToString());
            this._dic.Add("已延期任务", BLL.PlanBLL.Instance.PastTaskCnt().ToString());

            if (this._dic.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in this._dic)
                {
                    strListx.Add(kvp.Key);
                    strListy.Add(kvp.Value.ToString());
                    this._info += "您有" + kvp.Key + " " + kvp.Value + " 条\r\n\r\n";
                }
            }
            this.txtStatistical.Text = this._info;

            Chart chart = Helper.Instance.CreatePie("任务统计图",760,510,strListx, strListy);
            if (chart != null)
            {
                chart.BorderThickness = new Thickness(0);
                Simon.Children.Add(chart);
            }
        }

        #region 点击事件
        //点击事件
        void dataPoint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //DataPoint dp = sender as DataPoint;
            //MessageBox.Show(dp.YValue.ToString());
        }
        #endregion
    }
}
