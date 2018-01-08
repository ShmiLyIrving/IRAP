using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES {
    public class ProductionParam {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// 是否工作流路由结点
        /// </summary>
        public long IsWorkFlowNode { get; set; }

        /// <summary>
        /// 工位叶标识
        /// </summary>
        public int T107LeafID { get; set; }

        /// <summary>
        /// 工位实体标识
        /// </summary>
        public int T107EntityID { get; set; }

        /// <summary>
        /// 工位代码
        /// </summary>
        public string T107Code { get; set; }

        /// <summary>
        /// 工序代码
        /// </summary>
        public string T107AltCode { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string T107Name { get; set; }

        /// <summary>
        /// 产线叶标识
        /// </summary>
        public int T134LeafID { get; set; }

        /// <summary>
        /// 产线实体标识
        /// </summary>
        public int T134EntityID { get; set; }

        /// <summary>
        /// 产线代码
        /// </summary>
        public string T134Code { get; set; }

        /// <summary>
        /// 产线地址码
        /// </summary>
        public string T134AltCode { get; set; }

        /// <summary>
        /// 工作中心叶标识
        /// </summary>
        public int T211LeafID { get; set; }

        /// <summary>
        /// 工作中心实体标识
        /// </summary>
        public int T211EntityID { get; set; }

        /// <summary>
        /// 工作中心代码
        /// </summary>
        public string T211Code { get; set; }

        /// <summary>
        /// 工作中心地址码
        /// </summary>
        public string T211AltCode { get; set; }

        /// <summary>
        /// 工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }

        /// <summary>
        /// 工序实体标识
        /// </summary>
        public int T216EntityID { get; set; }

        /// <summary>
        /// 工序代码
        /// </summary>
        public string T216Code { get; set; }

        /// <summary>
        /// 工序替代代码
        /// </summary>
        public string T216AltCode { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
        public string T216Name { get; set; }

        /// <summary>
        /// 工厂叶标识
        /// </summary>
        public int T181LeafID { get; set; }

        /// <summary>
        /// 工厂实体标识
        /// </summary>
        public int T181EntityID { get; set; }

        /// <summary>
        /// 工厂代码
        /// </summary>
        public string T181Code { get; set; }

        /// <summary>
        /// 工厂替代代码
        /// </summary>
        public string T181AltCode { get; set; }

        /// <summary>
        /// 公司叶标识
        /// </summary>
        public int T1002LeafID { get; set; }

        /// <summary>
        /// 公司实体标识
        /// </summary>
        public int T1002EntityID { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        public string T1002Code { get; set; }

        /// <summary>
        /// 公司替代代码（邓白氏码）
        /// </summary>
        public string T1002AltCode { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string T1002Name { get; set; }

        /// <summary>
        /// 工序类型叶标识
        /// </summary>
        public int T116LeafID { get; set; }

        /// <summary>
        /// 工段叶标识
        /// </summary>
        public int T124LeafID { get; set; }

        /// <summary>
        /// 主关联设备叶标识
        /// </summary>
        public int T133LeafID { get; set; }

        /// <summary>
        /// 主关联设备实体标识
        /// </summary>
        public int T133EntityID { get; set; }

        /// <summary>
        /// 主关联设备编号
        /// </summary>
        public string T133Code { get; set; }

        /// <summary>
        /// 主关联设备替代代码
        /// </summary>
        public string T133AltCode { get; set; }

        /// <summary>
        /// 连续流/单件流下一工位叶标识
        /// </summary>
        public int T107LeafID_Next { get; set; }

        /// <summary>
        /// 连续流/单件流上一工位叶标识
        /// </summary>
        public int T107LeafID_Prev { get; set; }

        /// <summary>
        /// 工位生产状态
        /// </summary>
        public int T107S1 { get; set; }

        /// <summary>
        /// 预留备用
        /// </summary>
        public int T107S2 { get; set; }

        /// <summary>
        /// 预留备用
        /// </summary>
        public int T107S3 { get; set; }

        /// <summary>
        /// 预留备用
        /// </summary>
        public int T107S4 { get; set; }

        /// <summary>
        /// 预留备用
        /// </summary>
        public int T107S5 { get; set; }

        /// <summary>
        /// 预留备用
        /// </summary>
        public int T107S6 { get; set; }

        /// <summary>
        /// 预留备用
        /// </summary>
        public int T107S7 { get; set; }

        /// <summary>
        /// 预留备用
        /// </summary>
        public int T107S8 { get; set; }

        /// <summary>
        /// 工位叶标识
        /// </summary>
        public int T107I01 { get; set; }

        /// <summary>
        /// 是否代理记载前工序生产
        /// </summary>
        public long T107I02 { get; set; }

        /// <summary>
        /// 上次记载Unix时间
        /// </summary>
        public long T107I03 { get; set; }

        /// <summary>
        /// 在制品数量
        /// </summary>
        public long T107I04 { get; set; }

        /// <summary>
        /// 包装完成处理策略
        /// </summary>
        public long T107I05 { get; set; }

        /// <summary>
        /// 当前工单生产产品数量
        /// </summary>
        public long T107I06 { get; set; }

        /// <summary>
        /// 当前工单直通产品数量
        /// </summary>
        public long T107I07 { get; set; }

        /// <summary>
        /// 本班次生产产品数量
        /// </summary>
        public long T107I08 { get; set; }

        /// <summary>
        /// 本班次直通产品数量
        /// </summary>
        public long T107I09 { get; set; }

        /// <summary>
        /// 本工作日生产产品数量
        /// </summary>
        public long T107I10 { get; set; }

        /// <summary>
        /// 本工作日直通产品数量
        /// </summary>
        public long T107I11 { get; set; }

        /// <summary>
        /// 预留备用
        /// </summary>
        public long T107I12 { get; set; }

        /// <summary>
        /// 预留备用
        /// </summary>
        public long T107I13 { get; set; }

        /// <summary>
        /// 预留备用
        /// </summary>
        public long T107I14 { get; set; }

        /// <summary>
        /// 预留备用
        /// </summary>
        public long T107I15 { get; set; }

        /// <summary>
        /// 预留备用
        /// </summary>
        public long T107I16 { get; set; }

        /// <summary>
        /// 射频标识
        /// </summary>
        public string T107G01 { get; set; }

        /// <summary>
        /// 良品容器号
        /// </summary>
        public string T107G02 { get; set; }

        /// <summary>
        /// 不良品容器号
        /// </summary>
        public string T107G03 { get; set; }

        /// <summary>
        /// 图片文件路径名
        /// </summary>
        public string T107G04 { get; set; }

        /// <summary>
        /// 图片图像Base64编码
        /// </summary>
        public string T107G05 { get; set; }

        /// <summary>
        /// 正在生产的产品叶标识
        /// </summary>
        public int T107G06 { get; set; }

        /// <summary>
        /// 正在执行的生产工单号
        /// </summary>
        public string T107G07 { get; set; }

        /// <summary>
        /// 产出在制品存放容器号
        /// </summary>
        public string T107G08 { get; set; }

        /// <summary>
        /// 工位间通讯FTP地址
        /// </summary>
        public string T107G09 { get; set; }

        /// <summary>
        /// 工位间通讯FTP端口
        /// </summary>
        public int T107G10 { get; set; }

        /// <summary>
        /// 工位间通讯FTP用户名
        /// </summary>
        public string T107G11 { get; set; }

        /// <summary>
        /// 工位间通讯FTP密码
        /// </summary>
        public string T107G12 { get; set; }
    }

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
}
