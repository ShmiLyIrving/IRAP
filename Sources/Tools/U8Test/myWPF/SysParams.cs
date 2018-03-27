using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace myWPF
{
    public class SysParams
    {
        private static SysParams _instance = null;

        private SysParams()
        {

        }
        public static SysParams Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SysParams();
                return _instance;
            }
        }
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public bool IsWriteLog
        {
            get { return GetBoolean("WriteLog"); }
            set { SaveParams("WriteLog", value.ToString()); }
        }
        public bool bCheck
        {
            get { return GetBoolean("bCheck"); }
            set { SaveParams("bCheck", value.ToString()); }
        }
        public bool bBeforCheckStock
        {
            get { return GetBoolean("bBeforCheckStock"); }
            set { SaveParams("bBeforCheckStock", value.ToString()); }
        }


        /// <summary>
        /// 程序自动更新配置文件来源
        /// </summary>
        public string UpgradeURL
        {
            get { return GetString("UpgradeURL"); }
            set { SaveParams("UpgradeURL", value); }
        }
        public string U8ServerIP
        {
            get { return GetString("U8ServerIP"); }
            set { SaveParams("U8ServerIP", value); }
        }
        public string U8uid
        {
            get { return GetString("U8uid"); }
            set { SaveParams("U8uid", value); }
        }
        public string U8pwd
        {
            get { return Encrypt.Instance.DecryptString(GetString("U8pwd")); }
            set { SaveParams("U8pwd", Encrypt.Instance.EncryptString(value)); }
        }
        public string U8VouchCode
        {
            get { return GetString("U8VouchCode"); }
            set { SaveParams("U8VouchCode", value); }
        }


        private void SaveParams(string key, string value)
        {
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] == null)
                config.AppSettings.Settings.Add(key, value);
            else
                config.AppSettings.Settings[key].Value = value;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private string GetString(string key)
        {
            string rlt = "";
            if (ConfigurationManager.AppSettings[key] != null)
            {
                rlt = ConfigurationManager.AppSettings[key];
            }
            return rlt;
        }

        private bool GetBoolean(string key)
        {
            bool rlt = false;
            if (ConfigurationManager.AppSettings[key] != null)
            {
                try { rlt = Convert.ToBoolean(ConfigurationManager.AppSettings[key]); }
                catch { rlt = false; }
            }
            return rlt;
        }
    }
}
