using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpdateBuilder
{
    public class FileInfo
    {
        private Version currentVerion = new Version("0.0.0.0");
        private bool fileExists = false;
        private string fileName = "";
        private Version newVersion = new Version("0.0.0.0");
        private string currentMD5 = "";
        private string newMD5 = "";
        private bool checked=true;

        /// <summary>
        /// 当前版本
        /// </summary>
        public Version CurrentVersion
        {
            get { return currentVerion; }
            set { currentVerion = value; }
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
            set { fileName = value; }
        }

        /// <summary>
        /// 是否需要更新
        /// </summary>
        public bool NeedUpgraded
        {
            get { return currentMD5 != newMD5; }
        }

        /// <summary>
        /// 新版本号
        /// </summary>
        public Version NewVersion
        {
            get { return newVersion; }
            set { newVersion = value; }
        }

        /// <summary>
        /// 当前文件的MD5值
        /// </summary>
        public string CurrentMD5
        {
            get { return currentMD5; }
            set { currentMD5 = value; }
        }

        /// <summary>
        /// 新的MD5值
        /// </summary>
        public string NewMD5
        {
            get { return newMD5; }
            set { newMD5 = value; }
        }

        public bool Checked
        {
            get { return checked; }
        }
    }
}
