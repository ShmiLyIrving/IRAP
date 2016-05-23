using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Configuration;

namespace IRAP.MDC.Service
{
    public class WriteLog
    {
        private static WriteLog _instance = null;
        private static object lockStatus = new object();

        private WriteLog()
        {
            logPath = string.Format(@"{0}Log\",
                                    AppDomain.CurrentDomain.BaseDirectory);
            AttributeFileName = FILE_ATTRIBUTE_WRITELOG;
            if (!Directory.Exists(logPath))
            {
                try
                {
                    Directory.CreateDirectory(logPath);
                }
                catch
                {
                    canCreateLogFile = false;
                }
            }
        }

        public static WriteLog Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WriteLog();
                return _instance;
            }
        }

        #region 属性定义
        public const string FILE_ATTRIBUTE_WRITELOG = "IRAP.ini";

        string attributeFileName = "";
        string logPath = "";
        string writeLogFileName = "IRAP";
        bool canCreateLogFile = true;

        public string AttributeFileName
        {
            get { return attributeFileName; }
            set
            {
                attributeFileName = string.Format("{0}{1}",
                                                  AppDomain.CurrentDomain.BaseDirectory,
                                                  value);
            }
        }

        public bool IsWriteLog
        {
            get
            {
                Configuration config =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                return config.AppSettings.Settings["WriteLog"].Value.ToString().ToUpper() == "TRUE";
            }
            set
            {
                Configuration config =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.AppSettings.Settings["WriteLog"].Value == null)
                    config.AppSettings.Settings.Add("WriteLog", true.ToString());
                else
                    config.AppSettings.Settings["WriteLog"].Value = value.ToString();

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        public string WriteLogFileName
        {
            get { return writeLogFileName; }
            set { writeLogFileName = value; }
        }
        #endregion

        #region 方法定义
        public void Write(string msg, string modeName = "COMM")
        {
            if (IsWriteLog && canCreateLogFile)
            {
                lock (lockStatus)
                {
                    string strLogFileName = string.Format("{0}{1}_{2}.log",
                                                          logPath,
                                                          writeLogFileName,
                                                          DateTime.Now.ToString("yyyy-MM-dd"));

                    StreamWriter sw = null;
                    if (File.Exists(strLogFileName))
                    {
                        while (true)
                        {
                            try
                            {
                                sw = File.AppendText(strLogFileName);
                                break;
                            }
                            catch
                            {
                                Thread.Sleep(10);
                            }
                        }
                    }
                    else
                    {
                        while (true)
                        {
                            try
                            {
                                sw = File.CreateText(strLogFileName);
                                break;
                            }
                            catch
                            {
                                Thread.Sleep(10);
                            }
                        }
                    }

                    try
                    {
                        if (msg.Trim() == "")
                        {
                            sw.WriteLine("");
                        }
                        else
                        {
                            sw.WriteLine(string.Format("{0} : [{1}][{2}]",
                                                       DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                                                       modeName,
                                                       msg));
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        if (sw != null)
                        {
                            sw.Close();
                        }
                    }
                }
            }
        }

        public void WriteBeginSplitter(string modeName)
        {
            string msg = " BEGIN ";
            msg = msg.PadLeft(msg.Length + 15, '=');
            msg = msg.PadRight(msg.Length + 15, '=');

            Write(msg, modeName);
        }

        public void WriteEndSplitter(string modeName)
        {
            string msg = " END ";
            msg = msg.PadLeft(msg.Length + 15, '=');
            msg = msg.PadRight(msg.Length + 15, '=');

            Write(msg, modeName);
        }
        #endregion
    }
}