using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class MessageToSend
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 目标 IP 地址
        /// </summary>
        public string DstIPAddress { get; set; }
        /// <summary>
        /// 消息校验和
        /// </summary>
        public int MsgCheckSum { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgContent { get; set; }
        /// <summary>
        /// 目标站点系统登录标识
        /// </summary>
        public long SysLogID { get; set; }

        public MessageToSend Clone()
        {
            MessageToSend rlt = MemberwiseClone() as MessageToSend;

            return rlt;
        }
    }
}