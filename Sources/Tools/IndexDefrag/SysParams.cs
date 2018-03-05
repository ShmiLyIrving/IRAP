using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace IndexDefrag
{
    public class SysParams
    {
        private static SysParams _instance = null;
        private static readonly object syncRoot = new object();

        private SysParams()
        {

        }
        public static SysParams Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = new SysParams();
                }
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
        public bool ScanningLog
        {
            get { return GetBoolean("ScanningLog"); }
            set { SaveParams("ScanningLog", value.ToString()); }
        }

        /// <summary>
        /// 扫描完成后是否自动清理
        /// </summary>
        public bool AutoDefrag
        {
            get { return GetBoolean("AutoDefrag"); }
            set { SaveParams("AutoDefrag", value.ToString()); }
        }
        /// <summary>
        /// 是否开启定时清理
        /// </summary>
        public bool TimerDefrag
        {
            get;set;
        }
        /// <summary>
        /// 程序自动更新配置文件来源
        /// </summary>
        public string UpgradeURL
        {
            get { return GetString("UpgradeURL"); }
            set { SaveParams("UpgradeURL", value); }
        }
        /// <summary>
        /// 数据库地址
        /// </summary>
        public string DBServer
        {
            get { return GetString("DBServer"); }
            set { SaveParams("DBServer", value); }
        }
        /// <summary>
        /// 数据库用户名
        /// </summary>
        public string DBUid
        {
            get { return GetString("DBUid"); }
            set { SaveParams("DBUid", value); }
        }
        /// <summary>
        /// 数据库密码
        /// </summary>
        public string DBPwd
        {
            get { return Encrypt.Instance.DecryptString(GetString("DBPwd")); }
            set { SaveParams("DBPwd", Encrypt.Instance.EncryptString(value)); }
        }
        /// <summary>
        /// 索引碎片百分比阔值
        /// </summary>
        public string MaxAFP
        {
            get { return GetString("MaxAFP"); }
            set { SaveParams("MaxAFP", value); }
        }
        public string MaxFragmentCount
        {
            get { return GetString("MaxFragmentCount"); }
            set { SaveParams("MaxFragmentCount", value); }
        }
        /// <summary>
        /// 扫描时间间隔
        /// </summary>
        public string ScanningInertval
        {
            get { return GetString("ScanningInertval"); }
            set { SaveParams("ScanningInertval", value); }
        }
        /// <summary>
        /// 最多忽略扫描次数
        /// </summary>
        public string MaxIgnoreSacningTimes
        {
            get { return GetString("MaxIgnoreSacningTimes"); }
            set { SaveParams("MaxIgnoreSacningTimes", value); }
        }
        /// <summary>
        /// 扫描最大并行线程数
        /// </summary>
        public string MaxScanningThreadCount
        {
            get { return GetString("MaxScanningThreadCount"); }
            set { SaveParams("MaxScanningThreadCount", value); }
        }
        /// <summary>
        /// 清理最大并行线程数
        /// </summary>
        public string MaxDefragThreadCount
        {
            get { return GetString("MaxDefragThreadCount"); }
            set { SaveParams("MaxDefragThreadCount", value); }
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
