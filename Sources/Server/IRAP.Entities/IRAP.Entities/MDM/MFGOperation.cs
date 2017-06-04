using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.MDM
{
    public class MFGOperation
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string T102Code { get; set; }
        /// <summary>
        /// 工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }
        /// <summary>
        /// 工序实体标识
        /// </summary>
        public int T216EntityID { get; set; }
        /// <summary>
        /// 工序代码
        /// </summary>
        public string T216Code { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string T216Name { get; set; }
        /// <summary>
        /// 工段叶标识
        /// </summary>
        public int T124LeafID { get; set; }
        /// <summary>
        /// 工段名称
        /// </summary>
        public string T124Name { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public string T216CodeAndName
        {
            get
            {
                return string.Format("[{0}]{1}", T216Code, T216Name);
            }
        }

        public MFGOperation Clone()
        {
            MFGOperation rlt = MemberwiseClone() as MFGOperation;

            return rlt;
        }
    }
}
