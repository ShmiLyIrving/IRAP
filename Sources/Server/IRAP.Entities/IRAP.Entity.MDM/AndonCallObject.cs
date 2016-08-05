using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 安灯呼叫对象
    /// </summary>
    public class AndonCallObject
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 呼叫对象树标识
        /// </summary>
        public int TreeID { get; set; }
        /// <summary>
        /// 呼叫对象叶标识
        /// </summary>
        public int LeafID { get; set; }
        /// <summary>
        /// 呼叫对象实体标识
        /// </summary>
        public int EntityID { get; set; }
        /// <summary>
        /// 呼叫对象代码标识
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 呼叫对象名称
        /// </summary>
        public string ObjectDesc { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public bool Choice { get; set; }

        public AndonCallObject Clone()
        {
            return MemberwiseClone() as AndonCallObject;
        }
    }
}