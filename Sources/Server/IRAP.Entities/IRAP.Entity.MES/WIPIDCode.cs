using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 在制品 WIPIDCode 信息
    /// </summary>
    public class WIPIDCode
    {
        /// <summary>
        /// 条码状态
        /// </summary>
        public int BarcodeStatus { get; set; }
        /// <summary>
        /// 路由状态
        /// </summary>
        public int RoutingStatus { get; set; }
        /// <summary>
        /// 子在制品数
        /// </summary>
        public int NumOfSubWIPs { get; set; }
        /// <summary>
        /// 在制品主标识代码样式
        /// </summary>
        public string WIPPattern { get; set; }
        /// <summary>
        /// 在制品主标识代码
        /// </summary>
        public string WIPCode { get; set; }
        /// <summary>
        /// 在制品副标识代码
        /// </summary>
        public string AltWIPCode { get; set; }
        /// <summary>
        /// 在制品序列号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 在制品批次号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 隶属产品叶标识
        /// </summary>
        public int ProductLeaf { get; set; }
        /// <summary>
        /// 滞在工艺路线叶标识
        /// </summary>
        public int ProcessLeaf { get; set; }
        /// <summary>
        /// 滞在工位叶标识
        /// </summary>
        public int WorkUnitLeaf { get; set; }
        /// <summary>
        /// 在制品容器号
        /// </summary>
        public string ContainerNo { get; set; }
        /// <summary>
        /// 在制品条码状态描述
        /// </summary>
        public string BarcodeStatusStr { get; set; }
        /// <summary>
        /// 在制品路由状态描述
        /// </summary>
        public string RoutingStatusStr { get; set; }
        /// <summary>
        /// 隶属产品编号
        /// </summary>
        public string T102Code { get; set; }
        /// <summary>
        /// 滞在工艺路线代码
        /// </summary>
        public string T120Code { get; set; }
        /// <summary>
        /// 滞在工位代码
        /// </summary>
        public string T107Code { get; set; }
        /// <summary>
        /// 当前班次代码
        /// </summary>
        public string T126Code { get; set; }
        /// <summary>
        /// 当前班组代码
        /// </summary>
        public string T1Code { get; set; }
        /// <summary>
        /// 当前产线代码
        /// </summary>
        public string T134Code { get; set; }
        /// <summary>
        /// 当前工厂代码
        /// </summary>
        public string T181Code { get; set; }
        /// <summary>
        /// 当前公司代码
        /// </summary>
        public string T1002Code { get; set; }
        /// <summary>
        /// 隶属产品叶标识[102]
        /// </summary>
        public int T102Leaf { get; set; }
        /// <summary>
        /// 滞在工艺路线叶标识[120]
        /// </summary>
        public int T120Leaf { get; set; }
        /// <summary>
        /// 滞在工位叶标识[107]
        /// </summary>
        public int T107Leaf { get; set; }
        /// <summary>
        /// 当前班次叶标识[126]
        /// </summary>
        public int T126Leaf { get; set; }
        /// <summary>
        /// 当前班组叶标识[1]
        /// </summary>
        public int T1Leaf { get; set; }
        /// <summary>
        /// 当前产线叶标识[134]
        /// </summary>
        public int T134Leaf { get; set; }
        /// <summary>
        /// 当前工厂叶标识[181]
        /// </summary>
        public int T181Leaf { get; set; }
        /// <summary>
        /// 当前公司叶标识[1002]
        /// </summary>
        public int T1002Leaf { get; set; }
        /// <summary>
        /// 在制品数量
        /// </summary>
        public long Metric01 { get; set; }
        /// <summary>
        /// 工段累计制造周期时间
        /// </summary>
        public long Metric02 { get; set; }
        /// <summary>
        /// 总累计制造周期时间
        /// </summary>
        public long Metric03 { get; set; }
        /// <summary>
        /// 累计物料成本
        /// </summary>
        public long Metric04 { get; set; }
        /// <summary>
        /// 累计设备成本
        /// </summary>
        public long Metric05 { get; set; }
        /// <summary>
        /// 累计人工成本
        /// </summary>
        public long Metric06 { get; set; }
        /// <summary>
        /// 累计能耗成本
        /// </summary>
        public long Metric07 { get; set; }
        /// <summary>
        /// 检查失效次数
        /// </summary>
        public long Metric08 { get; set; }
        /// <summary>
        /// 测试失败次数
        /// </summary>
        public long Metric09 { get; set; }
        /// <summary>
        /// 累计维修次数
        /// </summary>
        public long Metric10 { get; set; }
        /// <summary>
        /// 累计返工次数
        /// </summary>
        public long Metric11 { get; set; }
        /// <summary>
        /// 累计报废数量
        /// </summary>
        public long Metric12 { get; set; }
        /// <summary>
        /// 在制品质量状态
        /// </summary>
        public long QCStatus { get; set; }
        /// <summary>
        /// 生产工单编号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 到达当前工位时间
        /// </summary>
        public DateTime MoveInTime { get; set; }

        public WIPIDCode Clone()
        {
            WIPIDCode rlt = MemberwiseClone() as WIPIDCode;

            return rlt;
        }
    }
}