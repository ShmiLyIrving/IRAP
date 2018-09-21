using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace IRAPGeneralGateway
{
    /// <summary>
    /// IRAP WebAPI 通用网关公共参数类
    /// </summary>
    public class TIRAPWebAPIGlobal
    {
        private static TIRAPWebAPIGlobal _instance = null;

        public static TIRAPWebAPIGlobal Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TIRAPWebAPIGlobal();
                return _instance;
            }
        }

        private string configurationFile = "";

        private TIRAPWebAPIGlobal()
        {
            configurationFile =
                string.Format(
                    "{0}.xml",
                    Assembly.GetCallingAssembly().Location.Replace(".dll", ""));
        }

        /// <summary>
        /// 通用网关参数配置持久化文件名
        /// </summary>
        public string ConfigurationFile
        {
            get { return configurationFile; }
        }
    }
}
