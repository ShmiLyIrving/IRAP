using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    public class Shift
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 班次叶标识
        /// </summary>
        public int T126LeafID { get; set; }
        /// <summary>
        /// 班次代码
        /// </summary>
        public string T126Code { get; set; }
        /// <summary>
        /// 班次名称
        /// </summary>
        public string T126Name { get; set; }

        public Shift Clone()
        {
            return MemberwiseClone() as Shift;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", T126Code, T126Name);
        }
    }
}
