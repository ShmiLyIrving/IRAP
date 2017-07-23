using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class BatchByEquipment
    {
        /// <summary>
        /// 炉次号
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 生产开始时间
        /// </summary>
        public string BatchStartDate { get; set; }
        /// <summary>
        /// 生产结束时间
        /// </summary>
        public string BatchEndDate { get; set; }
        /// <summary>
        /// 班次叶标识
        /// </summary>
        public int T126LeafID { get; set; }
        /// <summary>
        /// 班次代码
        /// </summary>
        public string T126Code { get; set; }
        /// <summary>
        /// 班次名称
        /// </summary>
        public string T126Name { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        public string T133Code { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string T133Name { get; set; }
        /// <summary>
        /// 工序代码
        /// </summary>
        public string T216Code { get; set; }
        /// <summary>
        /// 工序叶标识
        /// </summary>
        public string T216LeafID { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string T216Name { get; set; }

        public BatchByEquipment Clone()
        {
            return MemberwiseClone() as BatchByEquipment;
        }
    }
}
