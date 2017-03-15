using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    public class WIPStation
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
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
        /// 产线代码
        /// </summary>
        public string T134Code { get; set; }
        /// <summary>
        /// 工作中心叶标识
        /// </summary>
        public int T211LeafID { get; set; }
        /// <summary>
        /// 工作中心代码
        /// </summary>
        public string T211Code { get; set; }
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
        /// 工厂叶标识
        /// </summary>
        public int T181LeafID { get; set; }
        /// <summary>
        /// 工厂代码
        /// </summary>
        public string T181Code { get; set; }
        /// <summary>
        /// 公司叶标识
        /// </summary>
        public int T1002LeafID { get; set; }
        /// <summary>
        /// 公司代码
        /// </summary>
        public string T1002Code { get; set; }
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
        /// 主关联设备编号
        /// </summary>
        public string T133Code { get; set; }
        /// <summary>
        /// 主关联设备旧编号
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
        /// 是否代理记载前工序生产
        /// </summary>
        public long T107I1 { get; set; }
        /// <summary>
        /// 上次记载 Unix 时间
        /// </summary>
        public long T107I2 { get; set; }
        /// <summary>
        /// 在制品数量
        /// </summary>
        public long T107I3 { get; set; }
        /// <summary>
        /// 包装完成处理策略
        /// </summary>
        public long T107I4 { get; set; }
        /// <summary>
        /// 当前工单生产产品数量
        /// </summary>
        public long T107I5 { get; set; }
        /// <summary>
        /// 当前工单直通产品数量
        /// </summary>
        public long T107I6 { get; set; }
        /// <summary>
        /// 本班次生产产品数量
        /// </summary>
        public long T107I7 { get; set; }
        /// <summary>
        /// 本班次直通产品数量
        /// </summary>
        public long T107I8 { get; set; }
        /// <summary>
        /// 本工作日生产产品数量
        /// </summary>
        public long T107I9 { get; set; }
        /// <summary>
        /// 本工作日直通产品数量
        /// </summary>
        public long T107I10 { get; set; }
        /// <summary>
        /// 射频标识
        /// </summary>
        public string T107G1 { get; set; }
        /// <summary>
        /// 良品容器号
        /// </summary>
        public string T107G2 { get; set; }
        /// <summary>
        /// 不良品容器号
        /// </summary>
        public string T107G3 { get; set; }
        /// <summary>
        /// 图片文件路径名
        /// </summary>
        public string T107G4 { get; set; }
        /// <summary>
        /// 图片图像 Base64 编码
        /// </summary>
        public string T107G5 { get; set; }
        /// <summary>
        /// 正在生产的产品叶标识
        /// </summary>
        public int T107G6 { get; set; }
        /// <summary>
        /// 正在执行的生产工单号
        /// </summary>
        public string T107G7 { get; set; }
        /// <summary>
        /// 产出在制品存放容器号
        /// </summary>
        public string T107G8 { get; set; }
        /// <summary>
        /// 工位间通讯 FTP 地址
        /// </summary>
        public string T107G9 { get; set; }
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

        public WIPStation Clone()
        {
            return MemberwiseClone() as WIPStation;
        }
    }
}
