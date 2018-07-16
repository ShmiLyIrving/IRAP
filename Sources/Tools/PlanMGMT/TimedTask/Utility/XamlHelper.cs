// 版权所有：
// 文 件  名：UIControlHelper.cs
// 功能描述：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace PlanMGMT.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class XamlHelper
    {
        private static XamlHelper _instance;
        private static object _lock = new object();//使用static object作为互斥资源
        private static readonly object _obj = new object();

        #region 单例
        /// <summary>
        /// 
        /// </summary>
        private XamlHelper() { }

        /// <summary>
        /// 返回唯一实例
        /// </summary>
        public static XamlHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_obj)
                    {
                        //if (_instance == null)
                        //{
                        _instance = new XamlHelper();
                        //}
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region 设置控件属性

        /// <summary>
        /// 设置控件文本
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="text">文本</param>
        public void SetControlText(System.Windows.Controls.Control control, string text)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if (control is System.Windows.Controls.Label)
                {
                    System.Windows.Controls.Label lbl = (System.Windows.Controls.Label)control;
                    lbl.Content = text;
                }
                else if (control is System.Windows.Controls.TextBox)
                {
                    System.Windows.Controls.TextBox txt = (System.Windows.Controls.TextBox)control;
                    txt.Text = text;
                }
            }));
        }

        /// <summary>
        /// 设置Boder背景图片
        /// </summary>
        /// <param name="boder"></param>
        /// <param name="imgPath"></param>
        public void SetBackground(System.Windows.Controls.Border boder, string imgPath)
        {
            if (String.IsNullOrEmpty(imgPath) || !File.Exists(imgPath))
                return;

            try
            {
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(imgPath));
                brush.Stretch = Stretch.Fill;
                boder.Background = brush;
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region 加载XAML

        /// <summary>
        /// 从外部文件加载
        /// </summary>
        /// <param name="path">绝对路径</param>
        /// <param name="ctr"></param>
        public void LoadXamlByFile(string path, System.Windows.Controls.StackPanel ctr)
        {
            try
            {
                XmlTextReader xmlreader = new XmlTextReader(path);
                UIElement obj = XamlReader.Load(xmlreader) as UIElement;
                ctr.Children.Add((UIElement)obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region ComBox 添加项
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="dic"></param>
        public void CboAdd(ComboBox cbo, Dictionary<string, string> dic)
        {
            if (dic == null || dic.Count == 0)
                return;

            cbo.DisplayMemberPath = "Name";
            cbo.SelectedValuePath = "Value";

            MyItem mi = new MyItem();
            cbo.Items.Clear();

            foreach (KeyValuePair<string, string> kvp in dic)
            {
                mi = new MyItem();
                mi.Name = kvp.Key;
                mi.Value = kvp.Value;
                cbo.Items.Add(mi);
            }
        }
        /// <summary>
        /// ComBox 添加项
        /// </summary>
        private struct MyItem
        {
            public string Name { set; get; }
            public string Value { set; get; }
        }
        #endregion
    }
}
