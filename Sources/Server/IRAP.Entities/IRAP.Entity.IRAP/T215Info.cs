using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.IRAP
{
    public class T215Info
    {
        public int Ordinal { get; set; }
        public int T215LeafID { get; set; }
        public string OptionCode { get; set; }
        public string OptionName { get; set; }

        public T215Info Clone()
        {
            return MemberwiseClone() as T215Info;
        }
    }
}