using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace xFiletoESB
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

        /// <summary>
        /// 程序自动更新配置文件来源
        /// </summary>
        public string UpgradeURL
        {
            get { return GetString("UpgradeURL"); }
            set { SaveParams("UpgradeURL", value); }
        }

        /// <summary>
        /// ESB 队列所在地址
        /// </summary>
        public string ActiveMQ_URI
        {
            get { return GetString("ActiveMQ_URI"); }
            set { SaveParams("ActiveMQ_URI", value); }
        }

        /// <summary>
        /// ESB 队列名称
        /// </summary>
        public string ActiveMQ_QueueName
        {
            get { return GetString("ActiveMQ_QueueName"); }
            set { SaveParams("ActiveMQ_QueueName", value); }
        }

        /// <summary>
        /// ESB 交易号
        /// </summary>
        public string ExCode
        {
            get { return GetString("ExCode"); }
            set { SaveParams("ExCode", value); }
        }

        /// <summary>
        /// ESB 消息过滤字符串
        /// </summary>
        public string FilterString
        {
            get { return GetString("Filter string"); }
            set { SaveParams("Filter string", value); }
        }

        /// <summary>
        /// 本地文件保存路径
        /// </summary>
        public string LocalFileSaveLocation
        {
            get { return GetString("Local file location"); }
            set { SaveParams("Local file location", value); }
        }

        /// <summary>
        ///备份文件保存路径 
        /// </summary>
        public string BackupFileSaveLocation
        {
            get { return GetString("backup file location"); }
            set { SaveParams("Backup file location", value); }
        }

        public string UnreadableFileSaveLocation
        {
            get { return GetString("Unreadable file location"); }
            set { SaveParams("Unreadable file location", value); }
        }

        /// <summary>
        /// 本地文件文件名
        /// </summary>
        public string LocalFileName
        {
            get { return GetString("Local file name"); }
            set { SaveParams("Local file name", value); }
        }

        /// <summary>
        /// 本地文件类型
        /// </summary>
        public string FileType
        {
            get { return GetString("Local file type"); }
            set { SaveParams("Local file type", value); }
        }

        /// <summary>
        /// XML 文件类型中的根节点名称
        /// </summary>
        public string XmlRootNodeName
        {
            get { return GetString("Xml root node name"); }
            set { SaveParams("Xml root node name", value); }
        }

        /// <summary>
        /// 是否允许同时运行多个实例
        /// </summary>
        public bool MultiInstance
        {
            get { return GetString("Multi Instance").ToUpper() == "TRUE"; }
            set { SaveParams("Multi Instance", value.ToString()); }
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
