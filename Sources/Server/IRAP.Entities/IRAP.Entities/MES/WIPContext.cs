using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    /// <summary>
    /// 在制品上下文信息
    /// </summary>
    public class WIPContext
    {
        public int Ordinal { get; set; }
        public int T121Leaf { get; set; }
        public int T117Leaf { get; set; }
        public int NumSubWIPs { get; set; }
        public  string T102Code { get; set; }
        public string T120Code { get; set; }
        public string T107Code { get; set; }
        public string T126Code { get; set; }
        public string T1Code { get; set; }
        public string T134Code { get; set; }
        public string T181Code { get; set; }
        public string T1002Code { get; set; }
        public int T102Leaf { get; set; }
        public int T120Leaf { get; set; }
        public int T107Leaf { get; set; }
        public int T126Leaf { get; set; }
        public int T1Leaf { get; set; }
        public int T134Leaf { get; set; }
        public int T181Leaf { get; set; }
        public int T1002Leaf { get; set; }
        public string PWONo { get; set; }

        public WIPContext Clone()
        {
            return MemberwiseClone() as WIPContext;
        }
    }
}
