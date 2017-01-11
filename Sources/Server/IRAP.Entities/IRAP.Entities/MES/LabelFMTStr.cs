using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class LabelFMTStr
    {
        public int Ordinal { get; set; }
        public string PrintPort { get; set; }
        public string TemplateFMTStr { get; set; }
        public string FilePath { get; set; }

        public LabelFMTStr Clone()
        {
            return MemberwiseClone() as LabelFMTStr;
        }
    }
}
