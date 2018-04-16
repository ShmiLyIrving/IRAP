using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    public class NotOnStationEquipment
    {

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 失效模式叶标识
        /// </summary>
        public int T133LeafID { get; set; }
        /// <summary>
        /// 失效模式实体标识
        /// </summary>
        public int T133EntityID { get; set; }
        /// <summary>
        /// 失效代码
        /// </summary>
        public string T133Code { get; set; }
        /// <summary>
        /// 失效模式名称
        /// </summary>
        public string T133Name { get; set; }
    }
}
