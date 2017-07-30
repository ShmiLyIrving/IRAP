using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class BatchPWOInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 事实编号
        /// </summary>
        public long FactID { get; set; }
        /// <summary>
        /// 容次号
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
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string T102Code { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string T102Name { get; set; }
        /// <summary>
        /// 工位叶标识
        /// </summary>
        public string T107LeafID { get; set; }
        /// <summary>
        /// 工位代码
        /// </summary>
        public string T107Code { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string T107Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int T126LeafID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string T126Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string T126Name { get; set; }
        /// <summary>
        /// 设备叶标识
        /// </summary>
        public int T133LeafID { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        public string T133Code { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string T133Name { get; set; }
        /// <summary>
        /// 环别叶标识
        /// </summary>
        public int T131LeafID { get; set; }
        /// <summary>
        /// 环别代码
        /// </summary>
        public string T131Code { get; set; }
        /// <summary>
        /// 环别名称
        /// </summary>
        public string T131Name { get; set; }
        /// <summary>
        /// 工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }
        /// <summary>
        /// 工序代码
        /// </summary>
        public string T216Code { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string T216Name { get; set; }
        /// <summary>
        /// 生产工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 产品标识代码
        /// </summary>
        public string WIPCode { get; set; }
        /// <summary>
        /// 产品替代标识代码
        /// </summary>
        public string AltWIPCode { get; set; }
        /// <summary>
        /// 产品序列号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 工单批次号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 生产工单数量
        /// </summary>
        public long Qty { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public string Texture { get; set; }
        /// <summary>
        /// 质检状态
        /// </summary>
        public long QCStatus { get; set; }
        /// <summary>
        /// 质检时间
        /// </summary>
        public string IQCTime { get; set; }
        /// <summary>
        /// 质检确认时间
        /// </summary>
        public string IQCConfirmTime { get; set; }
        /// <summary>
        /// 工单状态
        /// </summary>
        public int PWOStatus { get; set; }

        public BatchPWOInfo Clone()
        {
            return MemberwiseClone() as BatchPWOInfo;
        }
    }
}
