using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace IRAP.Global
{
    public class AppFileInfo
    {
        private Version currentVersion = new Version("0.0.0.0");
        private string fileName = "";
        private bool fileExists = false;
        private Version newVersion = new Version("0.0.0.0");
        private bool chkecked = false;

        /// <summary>
        /// 文件当前版本号
        /// </summary>
        public Version CurrentVersion
        {
            get { return currentVersion; }
        }

        /// <summary>
        /// 文件名（包括路径）
        /// </summary>
        public string FileName
        {
            get { return fileName; } 
            set
            {
                if (File.Exists(value))
                {
                    FileVersionInfo version = FileVersionInfo.GetVersionInfo(value);
                    currentVersion = new Version(version.FileVersion);
                    fileName = value;
                    fileExists = true;
                }
                else
                {
                    fileExists = false;
                    currentVersion = new Version("0.0.0.0");
                }
            }
        }

        /// <summary>
        /// 文件是否存在
        /// </summary>
        public Boolean FileExists
        {
            get { return fileExists; }
        }

        /// <summary>
        /// 文件新版本号
        /// </summary>
        public Version NewVersion
        {
            get { return newVersion; }
            set { newVersion = value; }
        }

        /// <summary>
        /// 是否需要更新
        /// </summary>
        public bool NeedUpgraded
        {
            get
            {
                return newVersion > currentVersion;
            }
        }

        /// <summary>
        /// 文件是否需要升级
        /// </summary>
        public bool Checked
        {
            get { return this.chkecked; }
            set { this.chkecked = value; }
        }

        public override string ToString()
        {
            return Path.GetFileName(this.fileName);
        }
    }
}
