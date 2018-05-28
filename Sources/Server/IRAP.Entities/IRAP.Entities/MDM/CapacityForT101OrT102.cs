using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
public    class CapacityForT101OrT102
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 树标识
        /// </summary>
        public int TreeID { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int LeafID { get; set; }
        /// <summary>
        /// 产品代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 容器类型叶标识
        /// </summary>
        public int T157LeafID { get; set; }
        /// <summary>
        /// 容器类型叶代码
        /// </summary>
        public string T157Code { get; set; }
        /// <summary>
        /// 容器类型名称
        /// </summary>
        public  string T157Name { get; set; }
        /// <summary>
        /// 每杆数量
        /// </summary>
        public int StdQty { get; set; }

        public CapacityForT101OrT102 Clone()
        {
            return MemberwiseClone() as CapacityForT101OrT102;
        }
    }
}
