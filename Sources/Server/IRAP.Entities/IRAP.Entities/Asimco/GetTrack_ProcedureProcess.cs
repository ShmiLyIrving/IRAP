using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Asimco
{
    public class GetTrack_ProcedureProcess
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
        /// 日期时间
        /// </summary>
        public string BizDateTime { get; set; }
        /// <summary>
        /// 业务操作标识
        /// </summary>
        public int OpID { get; set; }
        /// <summary>
        /// 业务操作类型
        /// </summary>
        public int OpType { get; set; }
        /// <summary>
        /// 业务操作类型名称
        /// </summary>
        public string OpTypeStr { get; set; }
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
        /// 工位叶标识
        /// </summary>
        public int T107LeafID { get; set; }
        /// <summary>
        /// 工位代码
        /// </summary>
        public string T107Code { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string T107Name { get; set; }
        /// <summary>
        /// 设备代码
        /// </summary>
        public string T133Code { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string T133Name { get; set; }
        /// <summary>
        /// 产线代码
        /// </summary>
        public string T134Code { get; set; }
        /// <summary>
        /// 产线名称
        /// </summary>
        public string T134Name { get; set; }
        /// <summary>
        /// 班次名称
        /// </summary>
        public string T126Name { get; set; }
        /// <summary>
        /// 班组名称
        /// </summary>
        public string T1Name { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string OperatorCode { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 执行工序的第几个步骤
        /// </summary>
        public long OperationStep { get; set; }
        /// <summary>
        /// 在制品第几次在本工位生产
        /// </summary>
        public long ProductionTimes { get; set; }
        /// <summary>
        /// 在制品生产数量
        /// </summary>
        public long QtyOfProduct { get; set; }
        /// <summary>
        /// 数量放大级
        /// </summary>
        public int QtyScale { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }
        /// <summary>
        /// 在制品在本工序生产周期时间
        /// </summary>
        public long CycleTime { get; set; }
        /// <summary>
        /// 行集事实分区键
        /// </summary>
        public long RSFactPK { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 报废数量
        /// </summary>
        public long ScrappedQty { get; set; }
        /// <summary>
        /// 关联事实号
        /// </summary>
        public long LinkedFactID { get; set; }

        public GetTrack_ProcedureProcess Clone()
        {
            return MemberwiseClone() as GetTrack_ProcedureProcess;
        }
    }
}
