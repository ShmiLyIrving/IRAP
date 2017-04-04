using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VA_ITCMS2000
{
    public class SysParams : Param
    {
        private static SysParams _instance = null;

        private DBConnectParam dbParams = new DBConnectParam();
        private ITCMS2000Param vaParams = new ITCMS2000Param();

        private SysParams() { }

        public static SysParams Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SysParams();
                return _instance;
            }
        }

        public DBConnectParam DBParams
        {
            get { return dbParams; }
        }

        /// <summary>
        /// 数据库刷新记录间隔时间
        /// </summary>
        public int RefreshTimeSpan
        {
            get
            {
                string tmp = GetString("RefreshTimeSpan");
                int rlt = 0;
                if (int.TryParse(tmp, out rlt))
                    return rlt;
                else
                    return 100;
            }
            set { SaveParam("RefreshTimeSpan", value.ToString()); }
        }

        /// <summary>
        /// 广播消息过滤字符串
        /// </summary>
        public string StationID
        {
            get { return GetString("StationID"); }
            set { SaveParam("StationID", value); }
        }

        /// <summary>
        /// 当前程序的运行模式：
        /// DEBUG/RELEASE
        /// </summary>
        public string RunMode
        {
            get { return GetString("Runtime Mode"); }
        }

        public ITCMS2000Param VAParams
        {
            get { return vaParams; }
        }
    }
}
