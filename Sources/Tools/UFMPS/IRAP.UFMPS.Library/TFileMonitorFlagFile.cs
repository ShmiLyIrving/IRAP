using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRAP.UFMPS.Library
{
    public class TFileMonitorFlagFile : TCustomFileMonitorType
    {
        private string dataFileFloder = "";
        public string DataFileFloder
        {
            get { return dataFileFloder; }
            set { dataFileFloder = value; }
        }

        private string dataFileExt = "";
        public string DataFileExt
        {
            get { return dataFileExt; }
            set { dataFileExt = value; }
        }

        private int dataFileNameType = -1;
        public int DataFileNameType
        {
            get { return dataFileNameType; }
            set { dataFileNameType = value; }
        }

        private string flagFileName = "";
        public string FlagFileName
        {
            get { return flagFileName; }
            set { flagFileName = value; }
        }

        public override void CheckWatchedFileName(string fileName)
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
