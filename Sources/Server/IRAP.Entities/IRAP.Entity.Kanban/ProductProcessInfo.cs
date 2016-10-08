using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class ProductProcessInfo
    {
        /// <summary>
        /// 产品叶标识
        /// </summary>{get;set;}
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品代码
        /// </summary>
        public string T102Code { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string T102NodeName { get; set; }
        /// <summary>
        /// 生产流程叶标识
        /// </summary>
        public int T120LeafID { get; set; }
        /// <summary>
        /// 生产流程代码
        /// </summary>
        public string T120Code { get; set; }
        /// <summary>
        /// 生产流程名称
        /// </summary>
        public string T120NodeName { get; set; }

        public ProductProcessInfo Clone()
        {
            return MemberwiseClone() as ProductProcessInfo;
        }
    }
}