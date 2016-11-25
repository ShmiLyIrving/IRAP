using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Kanban
{
    /// <summary>
    /// 时间期间
    /// </summary>
    public class Period
    {
        public DateTime BeginDT { get; set; }
        public DateTime EndDT { get; set; }

        public Period Clone()
        {
            return MemberwiseClone() as Period;
        }

        public override string ToString()
        {
            return string.Format(
                "{0} - {1}",
                BeginDT.ToString("G"),
                EndDT.ToString("G"));
        }
    }
}