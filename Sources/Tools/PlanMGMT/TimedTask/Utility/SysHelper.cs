using System;

namespace PlanMGMT.Utility
{
    public class SysHelper
    {
        private Microsoft.Win32.RegistryKey registryKeyApp = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

        #region 自动启动

        /// <summary>
        /// 读取注册表
        /// </summary>
        /// <returns></returns>
        public string Read(string name)
        {
            if (registryKeyApp.GetValue(name) == null)
            {
                return "";
            }
            return registryKeyApp.GetValue(name).ToString();
        }
        /// <summary>
        /// 是否开机启动
        /// </summary>
        public bool IsAutoStartup()
        {
            string app = Read(PlanMGMT.Model.PM.ApplicationName).Trim();
            if (app.Length > 0 && app.EndsWith(".exe\""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 取消自动启动
        /// </summary>
        /// <param name="isRun">设置/取消自动启动</param>
        public void AutoStartup(bool isRun)
        {
            AutoStartup(isRun, Environment.CommandLine);
        }

        /// <summary>
        /// 系统设置/取消自动启动
        /// </summary>
        /// <param name="isRun">是否自动启动</param>
        /// <param name="exePath">系统执行路径（可增加配置参数）</param>
        public void AutoStartup(bool isRun, string exePath)
        {
            try
            {
                if (isRun)
                {
                    registryKeyApp.SetValue(PlanMGMT.Model.PM.ApplicationName, exePath);
                }
                else
                {
                    registryKeyApp.DeleteValue(PlanMGMT.Model.PM.ApplicationName, false);
                }
            }
            catch (Exception ex)
            {
                MSL.Tool.LogHelper.Instance.WriteLog("SysHelper AutoStartup\r\n"+ ex.ToString());
            }
        }

        #endregion
    }
}
