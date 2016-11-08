using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.MDM
{
    public class AndonCallPerson
    {
        /// <summary>
        /// 序号
        /// </summary>{get;set;}
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
        /// 呼叫对象名称
        /// </summary>
        public string T2NodeName { get; set; }
        /// <summary>
        /// 呼叫对象代码标识
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 呼叫对象姓名
        /// </summary>
        public string UserName { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public bool Choice { get; set; }

        public AndonCallPerson Clone()
        {
            return MemberwiseClone() as AndonCallPerson;
        }
    }
}