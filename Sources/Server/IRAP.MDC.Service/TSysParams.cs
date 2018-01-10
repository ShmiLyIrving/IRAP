using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using IRAP.Global;

namespace IRAP.MDC.Service
{
    internal class TSysParams
    {
        private static TSysParams _instance = null;

        public static TSysParams Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TSysParams();
                return _instance;
            }
        }

        /// <summary>
        /// Socket 服务侦听端口默认值
        /// </summary>
        private const int defaultListenPort = 30000;
        /// <summary>
        /// Socket 服务最大连接数默认值
        /// </summary>
        private const int defaultMaxConnection = 10;
        /// <summary>
        /// 社区标识
        /// </summary>
        private int communityID = 60010;
        /// <summary>
        /// 通讯报文的最大长度默认值
        /// </summary>
        private const int defaultMaxBufferSize = 1024;
        /// <summary>
        /// Socket 服务侦听端口
        /// </summary>
        private int listenPort = defaultListenPort;
        /// <summary>
        /// Socket 服务最大连接数
        /// </summary>
        private int maxConnection = defaultMaxConnection;
        /// <summary>
        /// 通讯报文的最大长度
        /// </summary>
        private int maxBufferSize = defaultMaxBufferSize;

        private TSysParams()
        {
            #region 获取系统配置参数
            if (ConfigurationManager.AppSettings["CommunityID"] != null)
                communityID =
                    Tools.ConvertToInt32(
                        ConfigurationManager.AppSettings["CommunityID"].ToString(),
                        60010);
            #endregion

            #region 获取通讯配置参数
            if (ConfigurationManager.AppSettings["SocketListenPort"] != null)
                listenPort =
                    Tools.ConvertToInt32(
                        ConfigurationManager.AppSettings["SocketListenPort"],
                        defaultListenPort);

            if (ConfigurationManager.AppSettings["MaxConnection"] != null)
                maxConnection =
                    Tools.ConvertToInt32(
                        ConfigurationManager.AppSettings["MaxConnection"],
                        defaultMaxConnection);

            if (ConfigurationManager.AppSettings["MaxBufferSize"] != null)
                maxBufferSize =
                    Tools.ConvertToInt32(
                        ConfigurationManager.AppSettings["MaxBufferSize"],
                        defaultMaxBufferSize);
            #endregion
        }

        /// <summary>
        /// 社区标识
        /// </summary>
        public int CommunityID { get { return communityID; } }
        /// <summary>
        /// Socket 服务侦听端口
        /// </summary>
        public int ListenPort { get { return listenPort; } }
        /// <summary>
        /// Socket 服务最大连接数
        /// </summary>
        public int MaxConnection { get { return MaxConnection; } }
        /// <summary>
        /// 通讯报文的最大长度
        /// </summary>
        public int MaxBufferSize { get { return MaxBufferSize; } }
    }
}
