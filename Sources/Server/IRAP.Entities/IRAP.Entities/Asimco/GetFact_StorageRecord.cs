using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Asimco
{
    public class GetFact_StorageRecord
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; } = 0;
        /// <summary>
        /// 入库库房代码
        /// </summary>
        public string T173Code { get; set; } = "";
        /// <summary>
        /// 入库库房名称
        /// </summary>
        public string T173NodeName { get; set; } = "";
        /// <summary>
        /// 库位代码
        /// </summary>
        public string T106Code { get; set; } = "";
        /// <summary>
        /// 库位名称
        /// </summary>
        public string T106NodeName { get; set; } = "";
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime BizDate { get; set; } = new DateTime(1, 1, 1);
        /// <summary>
        /// 操作员
        /// </summary>
        public string Operater { get; set; } = "";
        /// <summary>
        /// 制造订单号
        /// </summary>
        public string MONumber { get; set; } = "";
        /// <summary>
        /// 制造订单行号
        /// </summary>
        public int MOLineNo { get; set; } = 0;
        /// <summary>
        /// 生产事实号
        /// </summary>
        public long FactID { get; set; } = 0;
        /// <summary>
        /// 生产工单号
        /// </summary>
        public string WFInstanceID { get; set; } = "";

        public GetFact_StorageRecord Clone()
        {
            return MemberwiseClone() as GetFact_StorageRecord;
        }
    }
}
