using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace IRAPPrinterServer
{
    internal class SystemParams
    {
        #region 单例类
        private static SystemParams _instance = null;

        public static SystemParams Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SystemParams();
                return _instance;
            }
        }
        #endregion

        public SystemParams() { }

        /// <summary>
        /// 是否记录日志
        /// </summary>
        public bool WriteLog
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

        public string FilterString
        {
            get { return GetString("FilterString"); }
            set { SaveParams("FilterString", value); }
        }

        /// <summary>
        /// 生成 PDF 文件后再打印模式
        /// </summary>
        public bool GenPDFAndPrintMode
        {
            get { return GetBoolean("GenPDFAndPrint"); }
            set { SaveParams("GenPDFAndPrint", value.ToString()); }
        }

        /// <summary>
        /// 打印生成 PDF 文件的打印机名称(常量)
        /// </summary>
        public string PDFPrinter
        {
            get { return "Microsoft Print To PDF"; }
        }

        /// <summary>
        /// 能否打印输出为 PDF 文件
        /// </summary>
        public bool CanPrintToPDF { get; set; } = false;

        /// <summary>
        /// 打印输出的打印机名称
        /// </summary>
        public string PrinterName
        {
            get { return GetString("PrinterName"); }
            set { SaveParams("PrinterName", value); }
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
