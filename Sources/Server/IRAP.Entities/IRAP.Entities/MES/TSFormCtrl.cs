using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class TSFormCtrl
    {
        public int Ordinal { get; set; }
        public string CtrlName { get; set; }
        public bool IsValid { get; set; }

        public TSFormCtrl Clone()
        {
            return MemberwiseClone() as TSFormCtrl;
        }
    }
}
