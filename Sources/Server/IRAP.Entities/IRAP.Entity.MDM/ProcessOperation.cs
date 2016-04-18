using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 工序
    /// </summary>
    public class ProcessOperation
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工序叶标识
        /// </summary>
        public int T216Leaf { get; set; }
        /// <summary>
        /// 工序代码
        /// </summary>
        public string T216Code { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string T216Name { get; set; }
        /// <summary>
        /// 工序类型叶标识
        /// </summary>
        public int T116Leaf { get; set; }
        /// <summary>
        /// 工序类型名称
        /// </summary>
        public string T116Name { get; set; }
        /// <summary>
        /// 工段叶标识
        /// </summary>
        public int T124Leaf { get; set; }
        /// <summary>
        /// 工段名称
        /// </summary>
        public string T124Name { get; set; }
        /// <summary>
        /// 生产在制品部位叶标识
        /// </summary>
        public int T123Leaf { get; set; }
        /// <summary>
        /// 生产在制品部位
        /// </summary>
        public string T123Name { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]-{1}", T216Code, T216Name);
        }

        public ProcessOperation Clone()
        {
            return MemberwiseClone() as ProcessOperation;
        }
    }
}