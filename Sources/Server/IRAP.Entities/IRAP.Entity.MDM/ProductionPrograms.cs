using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 生产程序
    /// </summary>
    public class ProductionPrograms
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 生产程序叶标识
        /// </summary>
        public int T200LeafID { get; set; }
        /// <summary>
        /// 生产程序名
        /// </summary>
        public string T200Code { get; set; }
        /// <summary>
        /// 生产程序描述
        /// </summary>
        public string T200Name { get; set; }
        /// <summary>
        /// 是否支持柔性加载
        /// </summary>
        public bool FlexibleLoaded { get; set; }
        /// <summary>
        /// 是否要求防错
        /// </summary>
        public bool PokaYokeRequired { get; set; }
        /// <summary>
        /// 是否来自模板（供参考）
        /// </summary>
        public bool Reference { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public string CodeAndName
        {
            get
            {
                if (T200Code.Trim() == "")
                    return T200Name;
                else
                    return string.Format("{0}-{1}", T200Code, T200Name);
            }
        }

        public override string ToString()
        {
            return T200Code;
        }

        public ProductionPrograms Clone()
        {
            return MemberwiseClone() as ProductionPrograms;
        }
    }
}