using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class UncheckedMoveBack
    {
        public string Rejecter { get; set; }
        public int Quantity { get; set; }
        public DateTime OperTime { get; set; }
        public Int64 TransactNo { get; set; }

        public UncheckedMoveBack Clone()
        {
            UncheckedMoveBack rlt = MemberwiseClone() as UncheckedMoveBack;

            return rlt;
        }
    }
}