using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.OPC.Entity
{
    public class TIRAPOPCServer
    {
        /// <summary>
        /// OPC 服务器的地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// OPC 服务器的名称
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0}[{1}]", Name, Address);
        }

        public TIRAPOPCServer Clone()
        {
            return MemberwiseClone() as TIRAPOPCServer;
        }
    }
}
