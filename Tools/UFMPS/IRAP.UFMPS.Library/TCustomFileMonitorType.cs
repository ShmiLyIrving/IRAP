using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRAP.UFMPS.Library
{
    public abstract class TCustomFileMonitorType
    {
        private bool isBackupFile = false;
        public bool IsBackupFile
        {
            get { return isBackupFile; }
            set { isBackupFile = value; }
        }

        private string backupFileFloder = "";
        public string BackupFileFloder
        {
            get { return backupFileFloder; }
            set { DirectoryCheck(value); }
        }

        private string directory = "";
        public string Directory
        {
            get { return directory; }
            set { DirectoryCheck(value); }
        }

        public abstract void CheckWatchedFileName(string fileName);
        public abstract void Load();
        public abstract void Save();

        private string DirectoryCheck(string directory)
        {
            string rlt = "";

            rlt = directory.Trim();
            if (rlt.Length > 0)
            {
                if (rlt.Substring(rlt.Length - 1, 1) != @"\")
                {
                    rlt = rlt + @"\";
                }
            }
            return rlt;
        }
    }
}
