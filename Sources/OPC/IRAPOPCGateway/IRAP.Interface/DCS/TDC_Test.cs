using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.DCS
{
    /// <summary>
    /// 测试数据采集（Test Data Collection）接口规范
    /// </summary>
    public class TDC_TestContent : TSoftlandContent
    {
        public TDC_TestContent(
            TSoftlandBody requestBody,
            TSoftlandBody responseBody,
            TSoftlandLog requestLog,
            TSoftlandLog responseLog)
        {
            bodyRequest = requestBody;
            bodyResponse = responseBody;
            logRequest = requestLog;
            logResponse = responseLog;
        }

        public TDC_TestReqBody Request
        {
            get { return bodyRequest as TDC_TestReqBody; }
            set { bodyRequest = value; }
        }
    }

    public class TDC_TestReqBody : TSoftlandBody
    {
        private List<TDC_TestReqBodyTD> testDatas = new List<TDC_TestReqBodyTD>();
        private List<TDC_TestReqBodyPFM> pfms = new List<TDC_TestReqBodyPFM>();
        private List<TDC_TestReqBodyRecipe> recipes = new List<TDC_TestReqBodyRecipe>();

        /// <summary>
        /// 接口标识
        /// </summary>
        public string ExCode { get { return "DC_Test"; } }
        /// <summary>
        /// 社区标识
        /// </summary>
        public int CommunityID { get; set; }
        /// <summary>
        /// 操作工用户代码
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 系统登录标识
        /// </summary>
        public long SysLogID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 在制品主标识代码
        /// </summary>
        public string WIPCode { get; set; }
        /// <summary>
        /// 在制品副标识代码
        /// </summary>
        public string AltWIPCode { get; set; }
        /// <summary>
        /// 产品序列号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 生产工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 在制品容器编号
        /// </summary>
        public string ContainerNo { get; set; }
        /// <summary>
        /// 在制品站位代码
        /// </summary>
        public string WIPStationCode { get; set; }
        /// <summary>
        /// 工艺配方标识
        /// </summary>
        public string RecipeID { get; set; }
        /// <summary>
        /// 子在制品数
        /// </summary>
        public int NumSubWIPs { get; set; }
        /// <summary>
        /// 开始测试时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 截止测试时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 第几次测试
        /// </summary>
        public int CntOfTests { get; set; }
        /// <summary>
        /// 测试结论
        /// </summary>
        public int TestCnclusion { get; set; }
        /// <summary>
        /// 测试步数
        /// </summary>
        public int TestSteps { get; set; }
        /// <summary>
        /// 测量值数
        /// </summary>
        public int NumOfMetrics { get; set; }

        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public List<TDC_TestReqBodyTD> TestDatas
        {
            get { return testDatas; }
        }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public List<TDC_TestReqBodyPFM> PossibleFailureModes
        {
            get { return pfms; }
        }
        [IRAPXMLNodeAttrORMap(IsORMap = false)]
        public List<TDC_TestReqBodyRecipe> Recipes
        {
            get { return recipes; }
        }

        protected override XmlNode GenerateUserDefineNode()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode result = xml.CreateElement("Parameters");

            XmlNode node = xml.CreateElement("Param");
            node = IRAPXMLUtils.GenerateXMLAttribute(node, this);
            result.AppendChild(node);

            node = xml.CreateElement("ParamXML");
            result.AppendChild(node);

            XmlNode rowSet = xml.CreateElement("TestData");
            node.AppendChild(rowSet);
            for (int i = 0; i < testDatas.Count; i++)
            {
                testDatas[i].Ordinal = i + 1;

                XmlNode row = xml.CreateElement("Row");
                row = testDatas[i].GenerateXMLNode(row);
                rowSet.AppendChild(row);
            }

            rowSet = xml.CreateElement("PossibleFailures");
            node.AppendChild(rowSet);
            for (int i = 0; i < pfms.Count; i++)
            {
                pfms[i].Ordinal = i + 1;

                XmlNode row = xml.CreateElement("Row");
                row = pfms[i].GenerateXMLNode(row);
                rowSet.AppendChild(row);
            }

            rowSet = xml.CreateElement("Recipe");
            node.AppendChild(rowSet);
            for (int i = 0; i < recipes.Count; i++)
            {
                recipes[i].Ordinal = i + 1;

                XmlNode row = xml.CreateElement("Row");
                row = recipes[i].GenerateXMLNode(row);
                rowSet.AppendChild(row);
            }

            return result;
        }
    }

    /// <summary>
    /// DC_Test 请求报文中的测试数据行集类
    /// </summary>
    public class TDC_TestReqBodyTD : TSoftlandRowSet
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 测试项叶标识
        /// </summary>
        public int T128LeafID { get; set; }
        /// <summary>
        /// 测试项名称
        /// </summary>
        public string MetricName { get; set; }
        /// <summary>
        /// 低限值
        /// </summary>
        public long LowLimit { get; set; }
        /// <summary>
        /// 测试通过标准
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
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }
        /// <summary>
        /// 单项测试结论（P=通过；F=失败）
        /// </summary>
        public string Conclusion { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 影像Base64转换（JPG格式）
        /// </summary>
        public string ImageBase64 { get; set; }
        /// <summary>
        /// 第1个测量值
        /// </summary>
        public string Metric01 { get; set; }
        /// <summary>
        /// 第2个测量值
        /// </summary>
        public long Metric02 { get; set; }
        /// <summary>
        /// 第3个测量值
        /// </summary>
        public long Metric03 { get; set; }
        /// <summary>
        /// 第4个测量值
        /// </summary>
        public long Metric04 { get; set; }
        /// <summary>
        /// 第5个测量值
        /// </summary>
        public long Metric05 { get; set; }
        /// <summary>
        /// 第6个测量值
        /// </summary>
        public long Metric06 { get; set; }
        /// <summary>
        /// 第7个测量值
        /// </summary>
        public long Metric07 { get; set; }
        /// <summary>
        /// 第8个测量值
        /// </summary>
        public long Metric08 { get; set; }
        /// <summary>
        /// 第9个测量值
        /// </summary>
        public long Metric09 { get; set; }
        /// <summary>
        /// 第10个测量值
        /// </summary>
        public long Metric10 { get; set; }
        /// <summary>
        /// 第11个测量值
        /// </summary>
        public long Metric11 { get; set; }
        /// <summary>
        /// 第12个测量值
        /// </summary>
        public long Metric12 { get; set; }
        /// <summary>
        /// 第13个测量值
        /// </summary>
        public long Metric13 { get; set; }
        /// <summary>
        /// 第14个测量值
        /// </summary>
        public long Metric14 { get; set; }
        /// <summary>
        /// 第15个测量值
        /// </summary>
        public long Metric15 { get; set; }
        /// <summary>
        /// 第16个测量值
        /// </summary>
        public long Metric16 { get; set; }
        /// <summary>
        /// 第17个测量值
        /// </summary>
        public long Metric17 { get; set; }
        /// <summary>
        /// 第18个测量值
        /// </summary>
        public long Metric18 { get; set; }
        /// <summary>
        /// 第19个测量值
        /// </summary>
        public long Metric19 { get; set; }
        /// <summary>
        /// 第20个测量值
        /// </summary>
        public long Metric20 { get; set; }
        /// <summary>
        /// 第21个测量值
        /// </summary>
        public long Metric21 { get; set; }
        /// <summary>
        /// 第22个测量值
        /// </summary>
        public long Metric22 { get; set; }
        /// <summary>
        /// 第23个测量值
        /// </summary>
        public long Metric23 { get; set; }
        /// <summary>
        /// 第24个测量值
        /// </summary>
        public long Metric24 { get; set; }
        /// <summary>
        /// 第25个测量值
        /// </summary>
        public long Metric25 { get; set; }
        /// <summary>
        /// 第26个测量值
        /// </summary>
        public long Metric26 { get; set; }
        /// <summary>
        /// 第27个测量值
        /// </summary>
        public long Metric27 { get; set; }
        /// <summary>
        /// 第28个测量值
        /// </summary>
        public long Metric28 { get; set; }
        /// <summary>
        /// 第29个测量值
        /// </summary>
        public long Metric29 { get; set; }
        /// <summary>
        /// 第30个测量值
        /// </summary>
        public long Metric30 { get; set; }
        /// <summary>
        /// 第31个测量值
        /// </summary>
        public long Metric31 { get; set; }
        /// <summary>
        /// 第32个测量值
        /// </summary>
        public long Metric32 { get; set; }

        public TDC_TestReqBodyTD Clone()
        {
            return MemberwiseClone() as TDC_TestReqBodyTD;
        }
    }

    /// <summary>
    /// DC_Test 请求报文中的可能失效模式行集类
    /// </summary>
    public class TDC_TestReqBodyPFM : TSoftlandRowSet
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 部件位置编号
        /// </summary>
        public string CompLocCode { get; set; }
        /// <summary>
        /// 物料代码（无位置编号时禁止空值）
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 失效模式代码
        /// </summary>
        public string DefectCode { get; set; }
        /// <summary>
        /// 根源工序代码（产品工艺流程上的工序）
        /// </summary>
        public string RootOperationCode { get; set; }
        /// <summary>
        /// 缺陷类型代码（参见《Q-JSY 004-2016 制造缺陷类型分类与代码》）
        /// </summary>
        public string DefectTypeCode { get; set; }
        /// <summary>
        /// 缺陷责任代码（参见《Q-JSY 005-2016 制造缺陷责任分类与代码》）
        /// </summary>
        public string DefectOwner { get; set; }
        /// <summary>
        /// 缺陷点数（DPMO计算用途）
        /// </summary>
        public int CntDefect { get; set; }
        /// <summary>
        /// 缺陷影像（JPG格式）
        /// </summary>
        public string DefectImageBase64 { get; set; }

        public TDC_TestReqBodyPFM Clone()
        {
            return MemberwiseClone() as TDC_TestReqBodyPFM;
        }
    }

    /// <summary>
    /// DC_Test 请求报文中的测试时有效的工艺配方与工艺参数行集类
    /// </summary>
    public class TDC_TestReqBodyRecipe : TSoftlandRowSet
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工艺参数编号
        /// </summary>
        public string MethodParamCode { get; set; }
        /// <summary>
        /// 工艺参数名称
        /// </summary>
        public string MethodParamName { get; set; }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }
        /// <summary>
        /// 设定目标值
        /// </summary>
        public long TargetValue { get; set; }
        /// <summary>
        /// 实际值
        /// </summary>
        public long ActualValue { get; set; }
        /// <summary>
        /// 低限值
        /// </summary>
        public long LowLimit { get; set; }
        /// <summary>
        /// 高限值
        /// </summary>
        public long HighLImit { get; set; }
        /// <summary>
        /// 控制低限
        /// </summary>
        public long CtrlLowLimit { get; set; }
        /// <summary>
        /// 控制高限
        /// </summary>
        public long CtrlHighLimit { get; set; }

        public TDC_TestReqBodyRecipe Clone()
        {
            return MemberwiseClone() as TDC_TestReqBodyRecipe;
        }
    }
}
