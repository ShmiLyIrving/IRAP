using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PlanMGMT.Model;
using PlanMGMT.Utility;

namespace PlanMGMT.View
{
    /// <summary>
    /// Config.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed) this.DragMove();
            };
            this.btnClose.Click += (s, e) =>
            {
                this.Close();
            };
            this.KeyDown += (s, e) =>
            {
                if (e.Key == Key.Enter) btnLogin_Click(null, null);
            };
            this.chkisSavePass.IsChecked = (bool?) PM.isSavePass;
            this.chkisAutoLogin.IsChecked = (bool?)PM.isAutoLogin;
            if(!string.IsNullOrEmpty(PM.UserCode))
            {
                this.txtuid.Text = PM.UserCode;
            }
            if(PM.isSavePass)
            {
                this.txtpwd.Password = PM.UserPass;
            }          
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Control.Loading load = new Control.Loading(() => { System.Threading.Thread.Sleep(500); });
            load.Msg = "稍等。。。";
            load.Owner = this;
            load.Start();
            load.ShowDialog();
            Error rt = new Error();
            rt = LoginBLL.Instance.ssp_login(txtuid.Text, txtpwd.Password);
            if (rt.ErrCode != 0)
            {
                Helper.Instance.AlertWarning(rt.ErrText);
            }
            else
            {
                ProU.Instance.PspUser = LoginBLL.Instance.GetUser(txtuid.Text, txtpwd.Password);
                PM.isAutoLogin = (bool)chkisAutoLogin.IsChecked;
                PM.isSavePass = (bool)chkisSavePass.IsChecked;
                PM.UserCode = txtuid.Text;
                PM.UserPass = txtpwd.Password;
                ConfigHelper config = new ConfigHelper(PM.Config);
                config.SetValue("isSavePass", PM.isSavePass == true ? "1" : "0");
                config.SetValue("isAutoLogin", PM.isAutoLogin == true ? "1" : "0");
                config.SetValue("UserCode", PM.UserCode);
                if (PM.isSavePass)
                    config.SetValue("UserPass", Encrypt.Instance.EncryptString(PM.UserPass));
                config.Save();
                this.DialogResult = true;
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (PM.isAutoLogin)
            {
                //System.Windows.Forms.Application.DoEvents();
                //Thread.Sleep(3000);
                btnLogin_Click(null, null);
            }
        }
    }
}
