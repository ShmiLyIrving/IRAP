using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class BatchProductInfo
    {
        public BatchProductInfo()
        {
            BatchStartDate = DateTime.Now;
        }

        /// <summary>
        /// 热定型容次号
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 操作工工号
        /// </summary>
        public string OperatorCode { get; set; }
        /// <summary>
        /// 操作工姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 生产开始时间
        /// </summary>
        public DateTime BatchStartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string BatchEndDate { get; set; }
        /// <summary>
        /// 班次代码
        /// </summary>
        public string T126Code { get; set; }
        /// <summary>
        /// 班次信息
        /// </summary>
        public string T126Name { get; set; }
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
        /// 正在生产的工单信息
        /// </summary>
        public string BatchDataXML { get; set; }
        /// <summary>
        /// 待检验的检验标准信息列表  --暂时从前台调用其他接口获取
        /// </summary>
        public string MethodDataXML { get; set; }
        /// <summary>
        /// 是否正在生产
        /// </summary>
        public int InProduction { get; set; }

        public BatchProductInfo Clone()
        {
            return MemberwiseClone() as BatchProductInfo;
        }
    }
}
