using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 标准类型
    /// </summary>
    public class StandardType
    {
        /// <summary>
        /// 标准序号
        /// </summary>
        public int StandardID { get; set; }

        /// <summary>
        /// 标准名称
        /// </summary>
        public string StandardName { get; set; }

        public StandardType Clone()
        {
            return MemberwiseClone() as StandardType;
        }
    }
}