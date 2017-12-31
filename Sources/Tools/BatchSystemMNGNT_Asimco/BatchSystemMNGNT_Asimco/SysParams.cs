using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using IRAP.Global;

namespace BatchSystemMNGNT_Asimco
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
        /// 数据库连接字符串
        /// </summary>
        public string DBConnectionString
        {
            get
            {
                return
                    string.Format(
                        "Server={0};initial catalog={1};UID={2};Password={3};" +
                        "Min Pool Size=2;Max Pool Size=60;",
                        DBAddress,
                        DBName,
                        DBUserID,
                        DBUserPWD);
            }
        }

        /// <summary>
        /// 数据库地址
        /// </summary>
        public string DBAddress
        {
            get { return GetString("Database Address"); }
            set { SaveParam("Database Address", value); }
        }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DBName
        {
            get { return GetString("Database Name"); }
            set { SaveParam("Database Name", value); }
        }

        /// <summary>
        /// 数据库用户
        /// </summary>
        public  string DBUserID
        {
            get { return GetString("Database UserID"); }
            set { SaveParam("Database UserID", value); }
        }

        /// <summary>
        /// 数据库用户登录密码
        /// </summary>
        public string DBUserPWD
        {
            get { return GetString("Database UserPWD"); }
            set { SaveParam("Database UserPWD", value); }
        }

        private void SaveParam(string key, string value)
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
