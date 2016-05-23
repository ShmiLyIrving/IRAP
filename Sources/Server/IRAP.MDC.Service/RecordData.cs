using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace IRAP.MDC.Service
{
    public class RecordData
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string source = "";
        private string data = "";

        public RecordData(string source, string data)
        {
            this.source = source;
            this.data = data;
        }

        public void Record()
        {

        }
    }
}