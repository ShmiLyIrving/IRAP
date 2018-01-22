using IRAPShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES { 

    public class WaitingSmelt {
        /// <summary>
        /// 熔炼事实号
        /// </summary>
        public long FactID { get; set; }

        /// <summary>
        /// 熔炼炉次号
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 材质叶标识 
        /// </summary>
        public int T131LeafID { get; set; }

        /// <summary>
        /// 操作工工号
        /// </summary>
        public string OperatorCode { get; set; }

        /// <summary>
        /// 操作工姓名
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 预计开始生产时间
        /// </summary>
        public string PlanStartDate { get; set; }

        /// <summary>
        /// 生产开始时间
        /// </summary>
        public DateTime BatchStartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string BatchEndDate { get; set; }
    }

    public class OrderInfo {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// 热定型事实号
        /// </summary>
        public long FactID { get; set; }

        /// <summary>
        /// 热定型容次号
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 生产开始时间
        /// </summary>
        public string BatchStartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string BatchEndDate { get; set; }
         
        /// <summary>
        /// 班次代码
        /// </summary>
        public int T102LeafID { get; set; }

        /// <summary>
        /// 物料号
        /// </summary>
        public string T102Code { get; set; }

        /// <summary>
        /// 班次信息
        /// </summary>
        public string T102Name { get; set; }

        /// <summary>
        /// 班次代码
        /// </summary>
        public int T107LeafID { get; set; }

        /// <summary>
        /// 工位代码
        /// </summary>
        public string T107Code { get; set; }

        /// <summary>
        /// 工位名称信息
        /// </summary>
        public string T107Name { get; set; }

        /// <summary>
        /// 班次信息
        /// </summary>
        public int T126LeafID { get; set; }

        /// <summary>
        /// 班次代码
        /// </summary>
        public string T126Code { get; set; }

        /// <summary>
        /// 班次信息
        /// </summary>
        public string T126Name { get; set; }

        /// <summary>
        /// 设备代码
        /// </summary>
        public int T133LeafID { get; set; }

        /// <summary>
        /// 设备代码
        /// </summary>
        public string T133Code { get; set; }

        /// <summary>
        /// 班次信息
        /// </summary>
        public string T133Name { get; set; }

        /// <summary>
        /// 材质叶标识
        /// </summary>
        public int T131LeafID { get; set; }

        /// <summary>
        /// 材质代码
        /// </summary>
        public string T131Code { get; set; }

        /// <summary>
        /// 材质信息
        /// </summary>
        public string T131Name { get; set; }

        /// <summary>
        /// 工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }

        /// <summary>
        /// 班次代码
        /// </summary>
        public string T216Code { get; set; }

        /// <summary>
        /// 班次信息
        /// </summary>
        public string T216Name { get; set; }

        /// <summary>
        /// 生产工单号
        /// </summary>
        public string PWONo { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string MONumber { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public int MOLineNo { get; set; }

        /// <summary>
        /// 型板号
        /// </summary>
        public string PlateNo { get; set; }

        /// <summary>
        /// 造型机台号
        /// </summary>
        public string MachineModelling { get; set; }

        /// <summary>
        /// 叠数
        /// </summary>
        public int FoldNumber { get; set; }
         
        public string WIPCode { get; set; }
         
        public string AltWIPCode { get; set; }
         
        public string SerialNumber { get; set; }
         
        public string LotNumber { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public long Qty { get; set; }

        /// <summary>
        /// 材质
        /// </summary>
        public string Texture { get; set; }

        /// <summary>
        /// 热定型质检状态
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
        /// 熔炼状态
        /// </summary>
        public int PWOStatus { get; set; }

        /// <summary>
        /// 是否需要打印
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public bool IsPrint { get; set; }

        
    }

    public class SmeltMaterialItem {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// 原材料叶标识
        /// </summary>
        public int T101LeafID { get; set; }

        /// <summary>
        /// 原材料代码
        /// </summary>
        public string T101Code { get; set; }

        /// <summary>
        /// 原材料名称
        /// </summary>
        public string T101Name { get; set; }

        /// <summary>
        /// 默认放大数量级
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// 历史记录  暂时不用考略
        /// </summary>
        public string DataXML { get; set; } 
    }
     
    public class SmeltMethodItem {

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// 检验项目叶标识
        /// </summary>
        public int T20LeafID { get; set; }

        /// <summary>
        /// 检验项目代码
        /// </summary>
        public string T20Code { get; set; }

        /// <summary>
        /// 检验项目名称
        /// </summary>
        public string T20Name { get; set; }

        /// <summary>
        /// 默认放大数量级
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// 历史记录  暂时不用考略
        /// </summary>
        public string DataXML { get; set; } 
    }

    public class SmeltBatchProductionInfo {
        /// <summary>
        /// 熔炼事实号
        /// </summary>
        public long FactID { get; set; }

        /// <summary>
        /// 熔炼炉次号
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
        /// 材质叶标识
        /// </summary>
        public int T131LeafID { get; set; }

        /// <summary>
        /// 材质代码
        /// </summary>
        public string T131Code { get; set; }

        /// <summary>
        /// 材质信息
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
        /// 是否正在生产  1 有在产产品  0 没有在产产品
        /// </summary>
        public int InProduction { get; set; }
    }

    public class SmeltMethodItemByOpType {
        /// <summary>
        /// 检验项目叶标识
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// 检验项目叶标识
        /// </summary>
        public int T20LeafID { get; set; }

        /// <summary>
        /// 检验项目代码
        /// </summary>
        public string T20Code { get; set; }

        /// <summary>
        /// 检验项目名称
        /// </summary>
        public string T20Name { get; set; }

        /// <summary>
        /// 默认放大数量级
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// 历史记录
        /// </summary>
        public string DataXML { get; set; }
    }

    public class SmeltBatchMaterial {
        /// <summary>
        /// 熔炼事实号
        /// </summary>
        public long Ordinal { get; set; }

        /// <summary>
        /// 物料叶标识
        /// </summary>
        public string T101LeafID { get; set; }

        /// <summary>
        /// 物料号
        /// </summary>
        public string T101Code { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public int LotNumber { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public long Qty { get; set; }
    }
}
