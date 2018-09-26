using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.MDM
{
    public class WIPStation
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 是否工作流结点
        /// </summary>
        public bool IsWorkFlowNode { get; set; }
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
        /// 产线替代代码
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
        /// 工作中心替代代码
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
        /// 公司替代代码
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
        /// 设备叶标识
        /// </summary>
        public int T133LeafID { get; set; }
        /// <summary>
        /// 设备实体标识
        /// </summary>
        public int T133EntityID { get; set; }
        /// <summary>
        /// 设备代码
        /// </summary>
        public string T133Code { get; set; }
        /// <summary>
        /// 设备替代代码
        /// </summary>
        public string T133AltCode { get; set; }
        /// <summary>
        /// 直连下一工位叶标识
        /// </summary>
        public int T107LeafID_Next { get; set; }
        /// <summary>
        /// 直连上一工位叶标识
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
        /// 是否代理记载前工序生产
        /// </summary>
        public long T107I01 { get; set; }
        /// <summary>
        /// 上次记载 Unix 时间
        /// </summary>
        public long T107I02 { get; set; }
        /// <summary>
        /// 包装完成处理策略
        /// </summary>
        public long T107I03 { get; set; }
        /// <summary>
        /// 在制品数量
        /// </summary>
        public long T107I04 { get; set; }
        /// <summary>
        /// 当前工单生产产品数量
        /// </summary>
        public long T107I05 { get; set; }
        /// <summary>
        /// 当前工单直通产品数量
        /// </summary>
        public long T107I06 { get; set; }
        /// <summary>
        /// 本班次生产产品数量
        /// </summary>
        public long T107I07 { get; set; }
        /// <summary>
        /// 本班次直通产品数量
        /// </summary>
        public long T107I08 { get; set; }
        /// <summary>
        /// 本工作日生产产品数量
        /// </summary>
        public long T107I09 { get; set; }
        /// <summary>
        /// 本工作日直通产品数量
        /// </summary>
        public long T107I10 { get; set; }
        /// <summary>
        /// 预留备用
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
        /// 图片图像 Base64 编码
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
        /// 工位间通讯 FTP 地址
        /// </summary>
        public string T107G09 { get; set; }
        /// <summary>
        /// 工位间通讯 FTP 端口
        /// </summary>
        public int T107G10 { get; set; }
        /// <summary>
        /// 工位间通讯 FTP 用户名
        /// </summary>
        public string T107G11 { get; set; }
        /// <summary>
        /// 工位间通讯 FTP 密码
        /// </summary>
        public string T107G12 { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public string WIPStationName
        {
            get { return ToString(); }
        }
        public override string ToString()
        {
            if (T107AltCode != "")
                return string.Format("[{0}]{1}", T107AltCode, T107Name);
            else
                return string.Format("{2}[{0}]【{1}】", T107Code, T216Code, T107Name);
        }

        public WIPStation Clone()
        {
            return MemberwiseClone() as WIPStation;
        }
    }

    public class WIPStation_CompareByT133AltCode : IComparer<WIPStation>
    {
        public int Compare(WIPStation x, WIPStation y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    return x.T133AltCode.CompareTo(y.T133AltCode);
                }
            }
        }
    }
}
