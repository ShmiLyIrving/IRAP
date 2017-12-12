using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.OPC.Entity
{
    public class TIRAPOPCTagItem
    {
        public string TagName { get; set; }
        /// <summary>
        /// 标签的服务端句柄
        /// </summary>
        public int ServerHandle { get; set; }
    }
}
