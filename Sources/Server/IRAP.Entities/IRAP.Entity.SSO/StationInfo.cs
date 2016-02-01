using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.SSO
{
    public class StationInfo
    {
        public string StationID { get; set; }

        public string HostName { get; set; }

        public string IPAddress { get; set; }

        public string Configuration { get; set; }

        /// <summary>
        /// 站点数值型参数
        /// </summary>
        public long StationParameter { get; set; }

        /// <summary>
        /// 站点字串型参数
        /// </summary>
        public string StationStrParameters { get; set; }

        /// <summary>
        /// 主机数值型参数
        /// </summary>
        public long HostParameter { get; set; }

        /// <summary>
        /// 主机字串型参数
        /// </summary>
        public string HostStrParameters { get; set; }

        public bool IsTDCAgent { get; set; }

        public bool IsPDCAgent { get; set; }

        public bool ProcessSelectable { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }

        public string LoginTime { get; set; }

        public StationInfo Clone()
        {
            return MemberwiseClone() as StationInfo;
        }
    }
}