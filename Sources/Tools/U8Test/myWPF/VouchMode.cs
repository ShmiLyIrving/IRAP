using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myWPF
{
    public class AuditMode
    {
        public AuditMode(int id,string mode,string name)
        {
            VouchType = id;
            Mode = mode;
            Name = name;
        }
        public int VouchType;
        public string Mode;
        public string Name;

        public override string ToString()
        {
            return Name;
        }
    }
}
