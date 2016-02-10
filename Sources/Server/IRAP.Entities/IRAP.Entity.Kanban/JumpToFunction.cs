using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class JumpToFunction
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal
        {
            get; set;
        }

        /// <summary>
        /// 跳转功能叶标识
        /// </summary>
        public int JumpToT3LeafID
        {
            get; set;
        }

        /// <summary>
        /// 跳转前等待时间（秒）
        /// </summary>
        public int WaitForSeconds
        {
            get; set;
        }

        public override string ToString()
        {
            return JumpToT3LeafID.ToString();
        }

        public JumpToFunction Clone()
        {
            return MemberwiseClone() as JumpToFunction;
        }
    }
}
