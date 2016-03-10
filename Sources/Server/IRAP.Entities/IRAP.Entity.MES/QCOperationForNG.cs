using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 修复转出工序
    /// </summary>
    public class QCOperationForNG
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

        public QCOperationForNG Clone()
        {
            return MemberwiseClone() as QCOperationForNG;
        }
    }
}