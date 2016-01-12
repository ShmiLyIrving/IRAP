using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRAP.UFMPS.Library
{
    public class TFileMonitorNormal : TCustomFileMonitorType
    {
        private bool isKeepUndealedFile = false;
        public bool IsKeepUndealedFile
        {
            get { return isKeepUndealedFile; }
            set { isKeepUndealedFile = value; }
        }

        private string keepUndealedFloder = "";
        public string KeepUndealedFloder
        {
            get { return keepUndealedFloder; }
            set { keepUndealedFloder = value; }
        }

        private List<string> watchFileExts = new List<string>();
        public List<string> WatchFileExts
        {
            get { return watchFileExts; }
        }

        public override void CheckWatchedFileName(string fileName)
        {
            
        }

        public override void Load()
        {
            
        }

        public override void Save()
        {
            
        }
    }
}
