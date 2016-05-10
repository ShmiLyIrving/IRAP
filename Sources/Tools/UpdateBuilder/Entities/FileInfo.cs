using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

using IRAP.Global;

namespace UpdateBuilder
{
    public class FileInfo
    {
        private Version currentVerion = new Version("0.0.0.0");
        private bool fileExists = false;
        private string fileName = "";
        private Version oldVersion = new Version("0.0.0.0");
        private string currentMD5 = "";
        private string oldMD5 = "";
        private bool selected = true;

        /// <summary>
        /// 当前版本
        /// </summary>
        public Version CurrentVersion
        {
            get { return currentVerion; }
        }

        /// <summary>
        /// 文件是否存在
        /// </summary>
        public bool FileExists
        {
            get { return fileExists; }
        }

        /// <summary>
        /// 文件名称（包含路径）
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                fileExists = File.Exists(value);

                if (fileExists)
                {
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(value);
                    if (fvi.FileVersion != null)
                        currentVerion = new Version(fvi.FileVersion);
                    else
                        currentVerion = new Version("0.0.0.0");

                    currentMD5 = Tools.GetMD5HashFromFile(value);
                }
                else
                {
                    currentVerion = new Version("0.0.0.0");
                    currentMD5 = "";
                }
            }
        }

        /// <summary>
        /// 是否需要更新
        /// </summary>
        public bool NeedUpgraded
        {
            get { return currentMD5 != oldMD5; }
        }

        /// <summary>
        /// 新版本号
        /// </summary>
        public Version OldVersion
        {
            get { return oldVersion; }
            set { oldVersion = value; }
        }

        /// <summary>
        /// 当前文件的MD5值
        /// </summary>
        public string CurrentMD5
        {
            get { return currentMD5; }
        }

        /// <summary>
        /// 新的MD5值
        /// </summary>
        public string OldMD5
        {
            get { return oldMD5; }
            set { oldMD5 = value; }
        }

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
    }
}
