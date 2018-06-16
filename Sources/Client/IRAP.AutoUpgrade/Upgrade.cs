using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Globalization;

using DevExpress.XtraEditors;

using IRAP.Global;

namespace IRAP.AutoUpgrade
{
    public class Upgrade
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        /// <summary>
        /// 是否可以自动升级
        /// 只读属性，如果设置配置文件，并且文件中含有升级源，则改值为true，否则为false
        /// </summary>
        private bool canUpgrade = false;
        private static Upgrade _instance = null;
        /// <summary>
        /// 当前应用运行根目录
        /// </summary>
        private string rootPath = "";
        /// <summary>
        /// 升级源配置文件名（包含路径）
        /// </summary>
        private string upgradeCFGFileName = "";
        /// <summary>
        /// 升级文件所在远程 URL
        /// </summary>
        private string urlAddress = "";
        /// <summary>
        /// 升级配置文件 URL
        /// </summary>
        private string urlCFGFileName = "";
        /// <summary>
        /// 是否静默升级
        /// </summary>
        private bool silent = false;

        protected Upgrade()
        {
            string platform = Environment.OSVersion.Platform.ToString();
            switch (platform)
            {
                case "WinCE":
                    rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                    break;
                case "Win32NT":
                    rootPath = Directory.GetCurrentDirectory();
                    break;
            }

            string[] tmpFiles = Directory.GetFiles(rootPath, "*.$$$");
            for (int i = 0; i < tmpFiles.Length; i++)
            {
                try
                {
                    File.Delete(tmpFiles[i]);
                }
                catch { }
            }
        }

        /// <summary>
        /// 是否可以自动升级
        /// </summary>
        public bool CanUpgrade
        {
            get { return canUpgrade; }
        }

        public static Upgrade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Upgrade();
                return _instance;
            }
        }

        /// <summary>
        /// 升级源配置文件名（包含路径）
        /// </summary>
        public string UpgradeCFGFileName
        {
            get { return upgradeCFGFileName; }
            set
            {
                string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);

                upgradeCFGFileName = value;

                // 如果升级源没有配置，则不能升级
                if (!File.Exists(upgradeCFGFileName))
                {
                    WriteLog.Instance.Write(
                        string.Format(
                            "升级配置文件 [{0}] 不存在！", value),
                        strProcedureName);
                    canUpgrade = false;
                    return;
                }

                try
                {
                    using (FileStream fs =
                        new FileStream(upgradeCFGFileName, FileMode.Open, FileAccess.Read))
                    {
                        XmlReaderSettings xmlSettings = new XmlReaderSettings()
                        {
                            ConformanceLevel = ConformanceLevel.Fragment,
                            IgnoreComments = true,
                            IgnoreWhitespace = true,
                        };

                        using (XmlReader xr = XmlReader.Create(fs, xmlSettings))
                        {
                            while (xr.Read())
                            {
                                if (xr.NodeType == XmlNodeType.Element && xr.HasAttributes)
                                {
                                    if (xr.Name.ToUpper() == "UPGRADE")
                                    {
                                        urlCFGFileName = xr.GetAttribute("URL");

                                        string[] paths = urlCFGFileName.Split('/');
                                        urlAddress = "";
                                        for (int i = 0; i < paths.Length - 1; i++)
                                        {
                                            urlAddress += paths[i] + "/";
                                        }

                                        canUpgrade = true;
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// 升级文件所在远程 URL
        /// </summary>
        public string URLAddress
        {
            get { return urlAddress; }
        }

        /// <summary>
        /// 升级配置文件 URL
        /// </summary>
        public string URLCFGFileName
        {
            get { return urlCFGFileName; }
            set
            {
                urlCFGFileName = value;

                string[] paths = urlCFGFileName.Split('/');
                urlAddress = "";
                for (int i = 0; i < paths.Length - 1; i++)
                {
                    urlAddress += paths[i] + "/";
                }

                canUpgrade = true;
            }
        }

        /// <summary>
        /// 是否静默升级
        /// </summary>
        public bool Silent
        {
            get { return silent; }
            set { silent = value; }
        }

        /// <summary>
        /// 开始自动升级应用程序
        /// </summary>
        /// <returns>
        ///  0：无需升级
        /// -1：升级完成，或者部分升级完成，需要重启程序
        /// -2：升级失败，退出程序
        /// </returns>
        public int Do()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            string dstFileName =
                string.Format(@"{0}\upgrade.xml", rootPath);

            try
            {
                try
                {
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        frmShowUpgrade.Instance.Message = "Downloading upgrade configuration file...";
                    else
                        frmShowUpgrade.Instance.Message = "正在下载升级配置文件......";
                    WriteLog.Instance.Write(
                        frmShowUpgrade.Instance.Message,
                        strProcedureName);
                    if (File.Exists(dstFileName))
                        File.Delete(dstFileName);

                    string errText = "";
                    if (DownloadFile(urlCFGFileName, dstFileName, true, out errText) != 0)
                    {
                        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                            frmShowUpgrade.Instance.Message =
                                string.Format(
                                    "Upgrade configuration file downloaded failed: {0}",
                                    errText);
                        else
                            frmShowUpgrade.Instance.Message =
                                string.Format(
                                    "升级配置文件下载失败：{0}",
                                    errText);
                        WriteLog.Instance.Write(
                            frmShowUpgrade.Instance.Message,
                            strProcedureName);
                        Thread.Sleep(1000);
                        return 0;
                    }

                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        frmShowUpgrade.Instance.Message =
                            "Parsing upgrade configuration file...";
                    else
                        frmShowUpgrade.Instance.Message = "升级配置文件下载完成，正在解析......";
                    WriteLog.Instance.Write(
                        frmShowUpgrade.Instance.Message,
                        strProcedureName);
                    List<FileInfo> files = GetUpgradeFilesFromXML(dstFileName);
                    if (files == null)
                        return 0;
                    else
                    {
                        int upgradeFailureCount = 0;
                        int upgradeSuccessCount = 0;
                        foreach (FileInfo file in files)
                        {
                            if (file.NeedUpgraded)
                            {
                                if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                                    frmShowUpgrade.Instance.Message =
                                        string.Format(
                                            "Updating [{0}]...",
                                            Path.GetFileName(file.FileName));
                                else
                                    frmShowUpgrade.Instance.Message =
                                        string.Format(
                                            "正在更新[{0}]...",
                                            Path.GetFileName(file.FileName));
                                WriteLog.Instance.Write(
                                    frmShowUpgrade.Instance.Message,
                                    strProcedureName);
                                if (DownloadFile(
                                    string.Format(
                                        @"{0}/{1}",
                                        urlAddress,
                                        Path.GetFileName(file.FileName)),
                                    file.FileName,
                                    true,
                                    out errText) != 0)
                                {
                                    upgradeFailureCount++;
                                    WriteLog.Instance.Write(errText, strProcedureName);
                                }
                                else
                                {
                                    upgradeSuccessCount++;
                                }
                            }
                        }

                        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                            frmShowUpgrade.Instance.Message =
                                string.Format(
                                    "This update to update the success of the [{0}] file, " +
                                    "the failure to update the [{1}] file",
                                    upgradeSuccessCount,
                                    upgradeFailureCount);
                        else
                            frmShowUpgrade.Instance.Message =
                                string.Format(
                                    "本次升级更新成功 [{0}] 个文件，更新失败 [{1}] 个文件",
                                    upgradeSuccessCount, upgradeFailureCount);
                        WriteLog.Instance.Write(
                            frmShowUpgrade.Instance.Message,
                            strProcedureName);

                        if (upgradeFailureCount > 0 && !silent)
                        {
                            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                                XtraMessageBox.Show(
                                    string.Format(
                                        "There is a {0} files upgrade failed, " +
                                        "once again run will be re upgrade!",
                                        upgradeFailureCount),
                                    "Auto upgrade",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            else
                                XtraMessageBox.Show(
                                    string.Format(
                                        "有 {0} 个文件升级失败，再次运行时将会重新升级！",
                                        upgradeFailureCount),
                                    "自动升级",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            return -1;
                        }

                        if (upgradeSuccessCount > 0 && !silent)
                        {
                            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                                XtraMessageBox.Show(
                                    string.Format(
                                        "There are {0} files to upgrade successfully, " +
                                        "the program will be automatically closed. Please re run!",
                                        upgradeSuccessCount),
                                    "Auto upgrade",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            else
                                XtraMessageBox.Show(
                                    string.Format(
                                        "有 {0} 个文件升级成功，程序将会自动关闭。请重新运行！",
                                        upgradeSuccessCount),
                                    "自动升级",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

                            using (Command cmd = new Command())
                            {
                                try
                                {
                                    cmd.RunProgram("ewfmgr c: -commit");
                                }
                                catch { }

                            return -1;
                        }

                        return 0;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    if (!silent)
                        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                            XtraMessageBox.Show(
                                string.Format(
                                    "Program upgrade failed because of {0}",
                                    error.Message),
                                "Auto upgrade",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                        else
                            XtraMessageBox.Show(
                                string.Format(
                                    "程序升级失败，原因：{0}",
                                    error.Message),
                                "自动升级",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                    return -2;
                }
            }
            finally
            {
                if (File.Exists(dstFileName))
                    File.Delete(dstFileName);

                frmShowUpgrade.Instance.Message = "";

                //try
                //{
                //    using (Command cmd = new Command())
                //    {
                //        cmd.RunCmd("ewfmgr c: -commit");
                //    }
                //}
                //catch (Exception error)
                //{
                //    WriteLog.Instance.Write(error.Message, strProcedureName);
                //}
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        public int DownloadFile(
            string url,
            string dstFileName,
            bool overWrite,
            out string errText)
        {
            if (File.Exists(dstFileName))
            {
                if (!overWrite)
                {
                    errText = string.Format("文件[{0}]已经存在！", dstFileName);
                    return 1;
                }
            }

            try
            {
                // 下载文件的临时文件名
                string tempFileName =
                    string.Format("{0}.tmp", dstFileName);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    BinaryReader sr = new BinaryReader(response.GetResponseStream());
                    long fileLength = response.ContentLength;
                    byte[] content = sr.ReadBytes((Int32)fileLength);

                    FileStream fs = new FileStream(tempFileName, FileMode.Create);
                    BinaryWriter fw = new BinaryWriter(fs);
                    try
                    {
                        fw.Write(content, 0, (Int32)fileLength);
                    }
                    finally
                    {
                        fw.Close();
                    }
                }

                if (File.Exists(dstFileName))
                {
                    string tmpFileName = string.Format("{0}.$$$", dstFileName);
                    if (File.Exists(tmpFileName))
                        File.Delete(tmpFileName);
                    File.Move(dstFileName, tmpFileName);
                }
                File.Move(tempFileName, dstFileName);

                errText = string.Format("[{0}]文件下载完成！", dstFileName);
                return 0;
            }
            catch (Exception error)
            {
                errText = error.Message;
                return -1;
            }
        }

        /// <summary>
        /// 解析升级配置文件，返回升级文件列表
        /// </summary>
        public List<FileInfo> GetUpgradeFilesFromXML(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            List<FileInfo> filesToUpgrade = new List<FileInfo>();

            //using (FileStream fs = 
            //    new FileStream(fileName, FileMode.Open, FileAccess.Read))
            //{
            //    XmlReaderSettings xmlSettings = new XmlReaderSettings()
            //    {
            //        ConformanceLevel = ConformanceLevel.Fragment,
            //        IgnoreComments = true,
            //        IgnoreWhitespace = true,
            //    };

                //using (XmlReader xr = XmlReader.Create(fs, xmlSettings))
                //{
                //    while (xr.Read())
                //    {
                //        if (xr.NodeType == XmlNodeType.Element && xr.HasAttributes)
                //        {
                //            if (xr.Name.ToUpper() == "FILE")
                //            {
                //                FileInfo file = new FileInfo();
                //                file.FileName =
                //                    string.Format(
                //                        @"{0}\{1}",
                //                        rootPath,
                //                        xr.GetAttribute("name"));
                //                file.NewMD5 = xr.GetAttribute("md5");

                //                filesToUpgrade.Add(file);
                //            }
                //        }
                //    }
                //}
            //}

            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);

            try
            {
                foreach (XmlNode node in xml.SelectNodes("root/File"))
                {
                    filesToUpgrade.Add(
                        new FileInfo()
                        {
                            FileName = string.Format(@"{0}\{1}", rootPath, node.Attributes["name"].Value),
                            NewMD5 = node.Attributes["md5"].Value,
                        });
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                MessageBox.Show(error.StackTrace);

                throw error;
            }

            return filesToUpgrade;
        }
    }
}
