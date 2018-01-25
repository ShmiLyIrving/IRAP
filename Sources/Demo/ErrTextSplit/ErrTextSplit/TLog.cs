using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data;

namespace ErrTextSplit
{
    public class TLog
    {
        public long LogID { get; set; }
        public int PartitioningKey { get; set; }
        public DateTime TimeWritten { get; set; }
        public string ExCode { get; set; }
        public string CorrelationID { get; set; }
        public int WSDLParameterID { get; set; }
        public int RetryCycle { get; set; }
        public string ExChangeXML { get; set; }
        public string Properties { get; set; }
        public int ErrCode { get; set; }
        public string ErrText { get; set; }
        public long LinkedLogID { get; set; }
        public bool Retried { get; set; }
        public DateTime NextRetryTime { get; set; }

    }
}
