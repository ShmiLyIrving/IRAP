using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class FailureMode
    {
        public string FailureName { get; set; }
        public string FailureCode { get; set; }
        public int FailureLeaf { get; set; }
        public int FailureID { get; set; }
        public int Ordinal { get; set; }

        public FailureMode Clone()
        {
            FailureMode rlt = MemberwiseClone() as FailureMode;

            return rlt;
        }
    }
}