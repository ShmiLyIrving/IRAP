using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Asimco
{
    public class PackageClient
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 产线叶标识
        /// </summary>
        public int T105LeafID { get; set; }
        /// <summary>
        /// 产线代码
        /// </summary>
        public string T105Code { get; set; }
        /// <summary>
        /// 产线名称
        /// </summary>
        public string T105Name { get; set; }
        /// <summary>
        /// 外箱数量
        /// </summary>
        public long NumberOfCarton { get; set; }
        /// <summary>
        /// 外箱包含内箱数量
        /// </summary>
        public long NumberOfBox { get; set; }

        public override string ToString()
        {
            return T105Name;
        }
    }
}
