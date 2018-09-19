using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class SubWIPIDCodes_TS
    {
        public int Ordinal { get; set; }
        public string PartNumber { get; set; }
        public string SubWIPIDCode { get; set; }
        public long LinkedFactID { get; set; }
        public int PWOCategoryLeaf { get; set; }
        public int T132Leaf { get; set; }
    }
}
