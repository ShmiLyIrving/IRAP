using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using IRAP.Global;

namespace IRAP.PLC.Collection
{
    internal class SystemParams
    {
        private static SystemParams _instance = null;

        private string attrFileName =
            string.Format(
                "{0}IRAP.ini",
                AppDomain.CurrentDomain.BaseDirectory);

        public SystemParams() { }

        public static SystemParams Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SystemParams();
                return _instance;
            }
        }

        /// <summary>
        /// 是否记录日志
        /// </summary>
        public bool WriteLog
        {
            get { return Global.WriteLog.Instance.IsWriteLog; }
            set { Global.WriteLog.Instance.IsWriteLog = value; }
        }

        /// <summary>
        /// ExCode
        /// </summary>
        public string ExCode
        {
            get { return IniFile.ReadString("ActiveMQ", "ExCode", "", attrFileName); }
            set { IniFile.WriteString("ActiveMQ", "ExCode", value, attrFileName); }
        }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string Filter
        {
            get { return IniFile.ReadString("ActiveMQ", "Filter", "", attrFileName); }
            set { IniFile.WriteString("ActiveMQ", "Filter", value, attrFileName); }
        }
        /// <summary>
        /// 程序自动更新配置文件来源
        /// </summary>
        public string UpgradeURL
        {
            get { return IniFile.ReadString("AutoUpgrade", "UpgradeURL", "", attrFileName); }
            set { IniFile.WriteString("AutoUpgrade", "UpgradeURL", value, attrFileName); }
        }

        /// <summary>
        /// ESB 队列所在地址
        /// </summary>
        public string ActiveMQ_URI
        {
            get { return IniFile.ReadString("ActiveMQ", "URI", "", attrFileName); }
            set { IniFile.WriteString("ActiveMQ", "URI", value, attrFileName); }
        }

        /// <summary>
        /// ESB 队列名称
        /// </summary>
        public string ActiveMQ_QueueName
        {
            get { return IniFile.ReadString("ActiveMQ", "QueueName", "", attrFileName); }
            set { IniFile.WriteString("ActiveMQ", "QueueName", value, attrFileName); }
        }

        public int DeviceType
        {
            get { return Tools.ConvertToInt32(IniFile.ReadString("System", "DeviceType", "0", attrFileName)); }
            set { IniFile.WriteString("System", "DeviceType", value.ToString(), attrFileName); }
        }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceCode
        {
            get { return IniFile.ReadString("System", "T133Code", "", attrFileName); }
            set { IniFile.WriteString("System", "T133Code", value, attrFileName); }
        }

        public string DataFileName
        {
            get { return IniFile.ReadString("System", "DataFileName", "", attrFileName); }
            set { IniFile.WriteString("System", "DataFileName", value, attrFileName); }
        }

        public string T216Code
        {
            get { return IniFile.ReadString("System", "T216Code", "", attrFileName); }
            set { IniFile.WriteString("System", "T216Code", value, attrFileName); }
        }

        /// <summary>
        /// 查询开始时间
        /// </summary>
        public DateTime BeginDT
        {
            get
            {
                string temp = IniFile.ReadString("System", "LastCheckPoint", "", attrFileName);
                DateTime lastCheckPoint;

                try { lastCheckPoint = DateTime.Parse(temp); }
                catch
                {
#if DEBUG
                    lastCheckPoint = DateTime.Parse("2016-10-8 16:00:00");
#else
                    lastCheckPoint = DateTime.Now;
                    IniFile.WriteString("System", "LastCheckPoint", lastCheckPoint.ToString(), attrFileName);
#endif
                }
                return lastCheckPoint;
            }
            set { IniFile.WriteString("System", "LastCheckPoint", value.ToString(), attrFileName); }
        }

        /// <summary>
        /// 查询时间段区间
        /// </summary>
        public int DeltaTimeSpan
        {
            get
            {
                int rlt = 5;
                try { rlt = int.Parse(IniFile.ReadString("System", "DeltaTimeSpan", "", attrFileName)); }
                catch { }
                return rlt;
            }
            set { IniFile.WriteString("System", "DeltaTimeSpan", value.ToString(), attrFileName); }
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

        private DateTime GetDateTime(string key)
        {
            DateTime rlt = DateTime.Now;
            if (ConfigurationManager.AppSettings[key] != null)
            {
                try { rlt = Convert.ToDateTime(ConfigurationManager.AppSettings[key]); }
                catch { }
            }
            return rlt;
        }
    }
}
