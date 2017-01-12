using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.DPA
{
    [IRAPDB(TableName = "IRAPDPA..xdr_MethodParams")]
    public class xdr_MethodParams
    {
        /// <summary>
        /// 全局序号
        /// </summary>
        [IRAPKey(IsKey = true)]
        public long ID { get; set; }
        /// <summary>
        /// 分区键
        /// </summary>
        [IRAPKey(IsKey = true)]
        public long PartitioningKey { get; set; }
        /// <summary>
        /// 参数采集时间
        /// </summary>
        public long CollectingTime { get; set; }
        /// <summary>
        /// 设备代码
        /// </summary>
        public string EquipmentCode { get; set; }
        /// <summary>
        /// 工序代码
        /// </summary>
        public string OperationCode { get; set; }
        /// <summary>
        /// 工步号
        /// </summary>
        public int StepNo { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 参数代码
        /// </summary>
        public string ParamCode { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParamName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 参数采集模式
        /// </summary>
        public int CollectMode { get; set; }
        /// <summary>
        /// 低限值
        /// </summary>
        public long LowLimit { get; set; }
        /// <summary>
        /// 标准
        /// </summary>
        public string Criterion { get; set; }
        /// <summary>
        /// 高限值
        /// </summary>
        public long HighLimit { get; set; }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UnitOfMeasure { get; set; }
        /// <summary>
        /// 结论
        /// </summary>
        public string Conclusion { get; set; }
        /// <summary>
        /// 参数值 1
        /// </summary>
        public long Metric01 { get; set; }
        /// <summary>
        /// 参数值 2
        /// </summary>
        public long Metric02 { get; set; }
        /// <summary>
        /// 参数值 3
        /// </summary>
        public long Metric03 { get; set; }
        /// <summary>
        /// 参数值 4
        /// </summary>
        public long Metric04 { get; set; }
        /// <summary>
        /// 参数值 5
        /// </summary>
        public long Metric05 { get; set; }

        public xdr_MethodParams Clone()
        {
            return MemberwiseClone() as xdr_MethodParams;
        }
    }
}
