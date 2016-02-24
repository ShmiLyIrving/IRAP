using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 工单历史数据查询结果行
    /// </summary>
    public class Report_MOExecution
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string MONumber { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public int MOLineNo { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 要求开工时间
        /// </summary>
        public string ScheduleStartTime { get; set; }
        /// <summary>
        /// 要求完工时间
        /// </summary>
        public string ScheduleCloseTime { get; set; }
        /// <summary>
        /// 实际开工时间
        /// </summary>
        public string ActualStartTime { get; set; }
        /// <summary>
        /// 实际完工时间
        /// </summary>
        public string ActualCloseTime { get; set; }
        /// <summary>
        /// 订单量
        /// </summary>
        public int OrderQty { get; set; }
        /// <summary>
        /// 提料数
        /// </summary>
        public int MaterialQty { get; set; }
        /// <summary>
        /// 正品数
        /// </summary>
        public int WIPQty { get; set; }
        /// <summary>
        /// 废品率（本工序前）
        /// </summary>
        public double ScrapRate { get; set; }

        public Report_MOExecution Clone()
        {
            Report_MOExecution rlt = MemberwiseClone() as Report_MOExecution;

            return rlt;
        }
    }
}