using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 返工工单返工工位
    /// </summary>
    public class ReworkRouter
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 当前工位叶标识
        /// </summary>
        public int T107LeafID1 { get; set; }
        /// <summary>
        /// 当前工位名称
        /// </summary>
        public string T107Code1 { get; set; }
        /// <summary>
        /// 当前工位名称
        /// </summary>
        public string T107Name1 { get; set; }
        /// <summary>
        /// 下一工位叶标识
        /// </summary>
        public int T107LeafID2 { get; set; }
        /// <summary>
        /// 下一工位代码
        /// </summary>
        public string T107Code2 { get; set; }
        /// <summary>
        /// 下一工位名称
        /// </summary>
        public string T107Name2 { get; set; }
        /// <summary>
        /// 当前工序类型叶标识
        /// </summary>
        public int T116LeafID { get; set; }

        public ReworkRouter Clone()
        {
            ReworkRouter rlt = MemberwiseClone() as ReworkRouter;

            return rlt;
        }
    }
}