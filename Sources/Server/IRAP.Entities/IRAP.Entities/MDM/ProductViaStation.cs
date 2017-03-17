using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.MDM
{
    /// <summary>
    /// 指定工位的产品信息/指定工作流结点的流程信息
    /// </summary>
    public class ProductViaStation
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
        /// 产品实体标识
        /// </summary>
        public int T102EntityID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string T102Code { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string T102Name { get; set; }
        /// <summary>
        /// 物料类型叶标识
        /// </summary>
        public int T127LeafID { get; set; }
        /// <summary>
        /// 物料类型代码
        /// </summary>
        public string T127Code { get; set; }
        /// <summary>
        /// 工艺路线叶标识
        /// </summary>
        public int T120LeafID { get; set; }
        /// <summary>
        /// 产品系列叶标识
        /// </summary>
        public int T132LeafID { get; set; }
        /// <summary>
        /// 生产任务种类叶标识
        /// </summary>
        public int T103LeafID { get; set; }
        /// <summary>
        /// 生产任务种类实体标识
        /// </summary>
        public int T103EntityID { get; set; }
        /// <summary>
        /// 根物料代码
        /// </summary>
        public string T103Code { get; set; }
        /// <summary>
        /// 产品项目结点标识
        /// </summary>
        public int T103NodeID { get; set; }
        /// <summary>
        /// 产品项目代码
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// 生产制造策略叶标识
        /// </summary>
        public int T213LeafID { get; set; }
        /// <summary>
        /// 制造模式叶标识
        /// </summary>
        public int T141LeafID { get; set; }
        /// <summary>
        /// 生产方式叶标识
        /// </summary>
        public int T152LeafID { get; set; }
        /// <summary>
        /// 可追溯性叶标识
        /// </summary>
        public int T153LeafID { get; set; }
        /// <summary>
        /// 排产频度叶标识
        /// </summary>
        public int T214LeafID { get; set; }
        /// <summary>
        /// 工艺模板叶标识
        /// </summary>
        public int T258LeafID { get; set; }
        /// <summary>
        /// 工艺图纸叶标识
        /// </summary>
        public int T278LeafID { get; set; }
        /// <summary>
        /// 工艺图号
        /// </summary>
        public string T278Code { get; set; }
        /// <summary>
        /// 标识类型叶标识
        /// </summary>
        public int T121LeafID { get; set; }
        /// <summary>
        /// 标识类型代码
        /// </summary>
        public string T121Code { get; set; }
        /// <summary>
        /// 工艺标识(C64ID)
        /// </summary>
        public int MethodID { get; set; }
        /// <summary>
        /// 质量控制点序号
        /// </summary>
        public int QCCheckPointOrdinal { get; set; }
        /// <summary>
        /// 产品生命阶段
        /// </summary>
        public int T102S1 { get; set; }
        /// <summary>
        /// 物料拉动机制
        /// </summary>
        public int T102S2 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public int T102S3 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public int T102S4 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public int T102S5 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public int T102S6 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public int T102S7 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public int T102S8 { get; set; }
        /// <summary>
        /// 最低合理库存
        /// </summary>
        public long T102I01 { get; set; }
        /// <summary>
        /// 最高合理库存
        /// </summary>
        public long T102I02 { get; set; }
        /// <summary>
        /// 产品标准成本
        /// </summary>
        public long T102I03 { get; set; }
        /// <summary>
        /// 数量放大数量级
        /// </summary>
        public int T102I04 { get; set; }
        /// <summary>
        /// 生产用最小包装数量
        /// </summary>
        public long T102I05 { get; set; }
        /// <summary>
        /// 生产用最小包装重量
        /// </summary>
        public long T102I06 { get; set; }
        /// <summary>
        /// 生产用最小包装体积
        /// </summary>
        public long T102I07 { get; set; }
        /// <summary>
        /// 运输用最小包装数量
        /// </summary>
        public long T102I08 { get; set; }
        /// <summary>
        /// 运输用最小包装重量
        /// </summary>
        public long T102I09 { get; set; }
        /// <summary>
        /// 运输用最小包装体积
        /// </summary>
        public long T102I10 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long T102I11 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long T102I12 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long T102I13 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long T102I14 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long T102I15 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long T102I16 { get; set; }
        /// <summary>
        /// 序列号在条码中的起始位
        /// </summary>
        public int T102G01 { get; set; }
        /// <summary>
        /// 序列号在条码中的终止位
        /// </summary>
        public int T102G02 { get; set; }
        /// <summary>
        /// 产品序列号样式
        /// </summary>
        public string T102G03 { get; set; }
        /// <summary>
        /// 序列号或批次号前缀
        /// </summary>
        public string T102G04 { get; set; }
        /// <summary>
        /// 日期班次格式
        /// </summary>
        public string T102G05 { get; set; }
        /// <summary>
        /// 产品硬件版本号
        /// </summary>
        public string T102G06 { get; set; }
        /// <summary>
        /// 产品版本号
        /// </summary>
        public string T102G07 { get; set; }
        /// <summary>
        /// 产品型号标志
        /// </summary>
        public string T102G08 { get; set; }
        /// <summary>
        /// 序号位数
        /// </summary>
        public string T102G09 { get; set; }
        /// <summary>
        /// 下一序号
        /// </summary>
        public int T102G10 { get; set; }
        /// <summary>
        /// 序列代码
        /// </summary>
        public string T102G11 { get; set; }
        /// <summary>
        /// 校验位
        /// </summary>
        public string T102G12 { get; set; }
        /// <summary>
        /// 序号进制
        /// </summary>
        public int T102G13 { get; set; }
        /// <summary>
        /// 序号重置周期
        /// </summary>
        public string T102G14 { get; set; }
        /// <summary>
        /// 序列号后缀
        /// </summary>
        public string T102G15 { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string T102G16 { get; set; }
        /// <summary>
        /// 产品结构简图Base64编码
        /// </summary>
        public string T102G17 { get; set; }
        /// <summary>
        /// 是否禁止工艺路由防错
        /// </summary>
        public bool C64S01 { get; set; }
        /// <summary>
        /// 是否要求物料装料防错
        /// </summary>
        public bool C64S02 { get; set; }
        /// <summary>
        /// 是否要求周期时间防错
        /// </summary>
        public bool C64S03 { get; set; }
        /// <summary>
        /// 是否要求停滞时间防错
        /// </summary>
        public bool C64S04 { get; set; }
        /// <summary>
        /// 是否要求型号混装防错
        /// </summary>
        public bool C64S05 { get; set; }
        /// <summary>
        /// 是否要求用料质量防错
        /// </summary>
        public bool C64S06 { get; set; }
        /// <summary>
        /// 是否要求连续失效防错
        /// </summary>
        public bool C64S07 { get; set; }
        /// <summary>
        /// 是否进行维修次数限制
        /// </summary>
        public bool C64S08 { get; set; }
        /// <summary>
        /// 是否要求标签约束防错
        /// </summary>
        public bool C64S09 { get; set; }
        /// <summary>
        /// 是否要求序列唯一防错
        /// </summary>
        public bool C64S10 { get; set; }
        /// <summary>
        /// 是否要求自主维护防错
        /// </summary>
        public bool C64S11 { get; set; }
        /// <summary>
        /// 是否要求预防维护防错
        /// </summary>
        public bool C64S12 { get; set; }
        /// <summary>
        /// 是否要求仪表计量防错
        /// </summary>
        public bool C64S13 { get; set; }
        /// <summary>
        /// 是否要求员工技能防错
        /// </summary>
        public bool C64S14 { get; set; }
        /// <summary>
        /// 是否要求能源质量防错
        /// </summary>
        public bool C64S15 { get; set; }
        /// <summary>
        /// 是否要求生产准备防错
        /// </summary>
        public bool C64S16 { get; set; }
        /// <summary>
        /// 是否要求工艺参数防错
        /// </summary>
        public bool C64S17 { get; set; }
        /// <summary>
        /// 是否要求工装相容防错
        /// </summary>
        public bool C64S18 { get; set; }
        /// <summary>
        /// 是否要求工装寿命防错
        /// </summary>
        public bool C64S19 { get; set; }
        /// <summary>
        /// 是否要求生产程序防错
        /// </summary>
        public bool C64S20 { get; set; }
        /// <summary>
        /// 是否要求湿度敏感防错
        /// </summary>
        public bool C64S21 { get; set; }
        /// <summary>
        /// 是否要求环境相容防错
        /// </summary>
        public bool C64S22 { get; set; }
        /// <summary>
        /// 是否要求过量生产防错
        /// </summary>
        public bool C64S23 { get; set; }
        /// <summary>
        /// 是否要求单个流动防错
        /// </summary>
        public bool C64S24 { get; set; }
        /// <summary>
        /// 是否要求线边库容防错
        /// </summary>
        public bool C64S25 { get; set; }
        /// <summary>
        /// 是否要求先进先出防错
        /// </summary>
        public bool C64S26 { get; set; }
        /// <summary>
        /// 是否要求包装齐套防错
        /// </summary>
        public bool C64S27 { get; set; }
        /// <summary>
        /// 是否要求客户认证防错
        /// </summary>
        public bool C64S28 { get; set; }
        /// <summary>
        /// 保留备用防错选项
        /// </summary>
        public bool C64S29 { get; set; }
        /// <summary>
        /// 保留备用防错选项
        /// </summary>
        public bool C64S30 { get; set; }
        /// <summary>
        /// 保留备用防错选项
        /// </summary>
        public bool C64S31 { get; set; }
        /// <summary>
        /// 保留备用防错选项
        /// </summary>
        public bool C64S32 { get; set; }
        /// <summary>
        /// 是否全流程首工序
        /// </summary>
        public bool C64S33 { get; set; }
        /// <summary>
        /// 是否工段首工序
        /// </summary>
        public bool C64S34 { get; set; }
        /// <summary>
        /// 是否产品分型工序
        /// </summary>
        public bool C64S35 { get; set; }
        /// <summary>
        /// 是否标识合并工序
        /// </summary>
        public bool C64S36 { get; set; }
        /// <summary>
        /// 是否标识创建工序
        /// </summary>
        public bool C64S37 { get; set; }
        /// <summary>
        /// 是否标签打印工序
        /// </summary>
        public bool C64S38 { get; set; }
        /// <summary>
        /// 是否物料扣料点
        /// </summary>
        public bool C64S39 { get; set; }
        /// <summary>
        /// 是否产出报工点
        /// </summary>
        public bool C64S40 { get; set; }
        /// <summary>
        /// 是否返工起始点
        /// </summary>
        public bool C64S41 { get; set; }
        /// <summary>
        /// 是否允许产品报废
        /// </summary>
        public bool C64S42 { get; set; }
        /// <summary>
        /// 是否设置良率告警
        /// </summary>
        public bool C64S43 { get; set; }
        /// <summary>
        /// 是否设置效率告警
        /// </summary>
        public bool C64S44 { get; set; }
        /// <summary>
        /// 是否设置停工告警
        /// </summary>
        public bool C64S45 { get; set; }
        /// <summary>
        /// 是否设置参数告警（工艺/能源/环境）
        /// </summary>
        public bool C64S46 { get; set; }
        /// <summary>
        /// 是否部署MES站点
        /// </summary>
        public bool C64S47 { get; set; }
        /// <summary>
        /// 是否采集设备数据
        /// </summary>
        public bool C64S48 { get; set; }
        /// <summary>
        /// 是否采集能源数据
        /// </summary>
        public bool C64S49 { get; set; }
        /// <summary>
        /// 是否实施自动控制
        /// </summary>
        public bool C64S50 { get; set; }
        /// <summary>
        /// 是否进行彩虹图控制
        /// </summary>
        public bool C64S51 { get; set; }
        /// <summary>
        /// 是否进行XBar图控制
        /// </summary>
        public bool C64S52 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public bool C64S53 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public bool C64S54 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public bool C64S55 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public bool C64S56 { get; set; }
        /// <summary>
        /// 标准周期时间
        /// </summary>
        public long C64I01 { get; set; }
        /// <summary>
        /// 观察周期时间(月度平均实际周期时间)
        /// </summary>
        public long C64I02 { get; set; }
        /// <summary>
        /// 标准生产批量
        /// </summary>
        public long C64I03 { get; set; }
        /// <summary>
        /// 测试数据通道数（限测试及有料+测试工序）
        /// </summary>
        public long C64I04 { get; set; }
        /// <summary>
        /// 新增缺陷机会数
        /// </summary>
        public long C64I05 { get; set; }
        /// <summary>
        /// 新增物理部件或化学成份数
        /// </summary>
        public long C64I06 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long C64I07 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long C64I08 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long C64I09 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long C64I10 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long C64I11 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long C64I12 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long C64I13 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long C64I14 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long C64I15 { get; set; }
        /// <summary>
        /// 保留备用
        /// </summary>
        public long C64I16 { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public string ProductViaStationName
        {
            get { return ToString(); }
        }
        public override string ToString()
        {
            return string.Format("[{0}] {1}", T102Code, T102Name);
        }

        public ProductViaStation Clone()
        {
            ProductViaStation rlt = MemberwiseClone() as ProductViaStation;

            return rlt;
        }
    }
}
