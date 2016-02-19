using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class MessageToSend
    {
        public int Ordinal { get; set; }
        public string DstIPAddress { get; set; }
        public int MsgCheckSum { get; set; }
        public string MsgContent { get; set; }
        public long SysLogID { get; set; }

        public MessageToSend Clone()
        {
            MessageToSend rlt = MemberwiseClone() as MessageToSend;

            return rlt;
        }
    }
}