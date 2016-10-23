using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class Structure_FFTofAPWO
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 质量控制点工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }
        /// <summary>
        /// 质量控制点工序代码
        /// </summary>
        public string T216Code { get; set; }
        /// <summary>
        /// 质量控制点工序名称
        /// </summary>
        public string T216Name { get; set; }
        /// <summary>
        /// 质检在制品数
        /// </summary>
        public long NumQCWIPs { get; set; }
        /// <summary>
        /// 不良在制品数
        /// </summary>
        public long NumNGWIPs { get; set; }
        /// <summary>
        /// 一次通过率
        /// </summary>
        public decimal FTT { get; set; }

        public Structure_FFTofAPWO Clone()
        {
            return MemberwiseClone() as Structure_FFTofAPWO;
        }
    }
}