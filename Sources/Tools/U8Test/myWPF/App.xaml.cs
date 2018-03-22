using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace myWPF
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void MyApplication_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                Window myXamlWindow = new MainWindow();
                myXamlWindow.Show();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
                WriteLog.Instance.Write(
                           string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               error.Message,
                               error.StackTrace),
                           "");
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter("退出");
                WriteLog.Instance.Write("");
            }
        }

    }
}
