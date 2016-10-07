using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 一点课受训者信息
    /// </summary>
    public class OPLTrainee
    {
        /// <summary>
        /// 员工工号
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string UserName { get; set; }

        public OPLTrainee Clone()
        {
            return MemberwiseClone() as OPLTrainee;
        }
    }
}