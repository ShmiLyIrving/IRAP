using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IRAP.Entities.MES
{
    /// <summary>
    /// 人工检查
    /// </summary>
    public class Inspecting
    {
        private WIPIDCode mainWIPIDCode = new WIPIDCode();
        private List<SubWIPIDCodeInfo_Inspecting> subWIPIDCodes = new List<SubWIPIDCodeInfo_Inspecting>();

        public Inspecting()
        {
            ScanTime = DateTime.Now;
        }

        public WIPIDCode MainWIPIDCode
        {
            get { return mainWIPIDCode; }
            set { mainWIPIDCode = value; }
        }

        public List<SubWIPIDCodeInfo_Inspecting> SubWIPIDCodes
        {
            get { return subWIPIDCodes; }
            set { subWIPIDCodes = value; }
        }

        /// <summary>
        /// 条码扫描时间
        /// </summary>
        public DateTime ScanTime { get; set; }
    }

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

    /// <summary>
    /// 子在制品标识
    /// </summary>
    public class SubWIPIDCodeInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 子在制品分组标识
        /// </summary>
        public int SubWIPGroupID { get; set; }
        /// <summary>
        /// 子在制品主标识代码
        /// </summary>
        public string SubWIPIDCode { get; set; }
        /// <summary>
        /// 质量控制状态
        /// </summary>
        public long QCStatus { get; set; }
        /// <summary>
        /// 是否已报废
        /// </summary>
        public bool Scrapped { get; set; }
        /// <summary>
        /// 生产任务种类叶标识
        /// </summary>
        public int PWOCategoryLeaf { get; set; }

        public SubWIPIDCodeInfo Clone()
        {
            SubWIPIDCodeInfo rlt = MemberwiseClone() as SubWIPIDCodeInfo;

            return rlt;
        }
    }

    /// <summary>
    /// 用于人工检查的子在制品标识信息
    /// </summary>
    public class SubWIPIDCodeInfo_Inspecting : SubWIPIDCodeInfo
    {
        private List<InspectingFailureItem> failureItems = new List<InspectingFailureItem>();
        private DataTable failureItemsDT = null;

        public SubWIPIDCodeInfo_Inspecting()
        {
            failureItemsDT = new DataTable("InspectingItems");
            failureItemsDT.Columns.Add("T101LeafID", typeof(int));
            failureItemsDT.Columns.Add("T110LeafID", typeof(int));
            failureItemsDT.Columns.Add("T118LeafID", typeof(int));
            failureItemsDT.Columns.Add("T216LeafID", typeof(int));
            failureItemsDT.Columns.Add("T183LeafID", typeof(int));
            failureItemsDT.Columns.Add("T184LeafID", typeof(int));
            failureItemsDT.Columns.Add("CntDefect", typeof(int));

            InspectingStatus = 1;
        }

        /// <summary>
        /// 检查结论
        /// </summary>
        public int InspectingStatus { get; set; }
        public List<InspectingFailureItem> FailureItems
        {
            get { return failureItems; }
            set { failureItems = value; }
        }
        public DataTable FailureItemsDT
        {
            get { return failureItemsDT; }
            set { failureItemsDT = value; }
        }

        public void GetListFromDataTable()
        {
            failureItems.Clear();
            foreach (DataRow dr in failureItemsDT.Rows)
            {
                InspectingFailureItem item = new InspectingFailureItem();

                try { item.T101LeafID = (int)dr["T101LeafID"]; }
                catch { item.T101LeafID = 0; }
                try { item.T110LeafID = (int)dr["T110LeafID"]; }
                catch { item.T110LeafID = 0; }
                try { item.T118LeafID = (int)dr["T118LeafID"]; }
                catch { item.T118LeafID = 0; }
                try { item.T216LeafID = (int)dr["T216LeafID"]; }
                catch { item.T216LeafID = 0; }
                try { item.T183LeafID = (int)dr["T183LeafID"]; }
                catch { item.T183LeafID = 0; }
                try { item.T184LeafID = (int)dr["T184LeafID"]; }
                catch { item.T184LeafID = 0; }
                try { item.CntDefect = (int)dr["CntDefect"]; }
                catch { item.CntDefect = 0; }

                failureItems.Add(item);
            }
        }

        public void PutListIntoDataTable()
        {
            failureItemsDT.Clear();
            foreach (InspectingFailureItem item in failureItems)
            {
                failureItemsDT.Rows.Add(new object[]
                    {
                        item.T101LeafID,
                        item.T110LeafID,
                        item.T118LeafID,
                        item.T216LeafID,
                        item.T183LeafID,
                        item.T184LeafID,
                        item.CntDefect,
                    });
            }
        }
    }

    /// <summary>
    /// 检查失效项
    /// </summary>
    public class InspectingFailureItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int T101LeafID { get; set; }
        /// <summary>
        /// 部件位置叶标识
        /// </summary>
        public int T110LeafID { get; set; }
        /// <summary>
        /// 失效模式叶标识
        /// </summary>
        public int T118LeafID { get; set; }
        public int T216LeafID { get; set; }
        /// <summary>
        /// 缺陷分类叶标识
        /// </summary>
        public int T183LeafID { get; set; }
        public int T184LeafID { get; set; }
        /// <summary>
        /// 缺陷点数
        /// </summary>
        public int CntDefect { get; set; }

        public InspectingFailureItem Clone()
        {
            InspectingFailureItem rlt = MemberwiseClone() as InspectingFailureItem;

            return rlt;
        }
    }
}
