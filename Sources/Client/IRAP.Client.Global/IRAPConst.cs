using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Client.Global
{
    public class IRAPConst
    {
        private static IRAPConst _instance = null;

        private IRAPConst() { }

        public static IRAPConst Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPConst();
                return _instance;
            }
        }

        /// <summary>
        /// 当前编程语言标识
        /// </summary>
        public int IRAP_PROGLANGUAGEID { get { return 9; } }

        /// <summary>
        /// 安灯表格的行高
        /// </summary>
        public int ANDON_GRID_ROWHEIGHT { get { return 55; } }

        /// <summary>
        /// UDP 通讯消息接收端口号
        /// </summary>
        public int MESSAGE_LISTEN_PORT { get { return 17001; } }

        /// <summary>
        /// UDP 通讯消息发送端口号
        /// </summary>
        public int MESSAGE_SEND_PORT { get { return 17002; } }
    }
}
