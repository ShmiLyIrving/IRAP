using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    public class StationEquipment
    {

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 设备叶标识
        /// </summary>
        public int T133LeafID { get; set; }
        /// <summary>
        /// 设备实体标识
        /// </summary>
        public int T133EntityID { get; set; }
        /// <summary>
        /// 设备代码
        /// </summary>
        public string T133Code { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string T133Name { get; set; }
    }
}
