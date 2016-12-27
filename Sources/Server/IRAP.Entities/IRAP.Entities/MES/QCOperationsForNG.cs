using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    /// <summary>
    /// 送修在制品修复转出工序
    /// </summary>
    public class QCOperationsForNG
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

        public QCOperationsForNG Clone()
        {
            return MemberwiseClone() as QCOperationsForNG;
        }
    }
}