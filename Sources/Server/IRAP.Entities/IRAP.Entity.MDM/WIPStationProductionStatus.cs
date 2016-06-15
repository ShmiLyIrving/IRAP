using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using IRAPShared;
using IRAP.Global;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 站点产品状态
    /// </summary>
    public class WIPStationProductionStatus
    {
        private int ordinal = 0;
        private int t107LeafID = 0;
        private string t107Code = "";
        private string t107Name = "";
        private int t102LeafID_InProduction = 0;
        private string t102Code_InProduction = "";
        private string pwoNo_InExecution = "";
        private string containerNo = "";
        private string containerNo_Output = "";
        private byte[] t107Image;
        private Image t107Picture = null;
        private string nextPWOToExecute = "";
        private string nextContainerNo = "";
        private string atStoreLocCode = "";
        private string dstStoreLocCode = "";

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }

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
        /// 正在生产的产品叶标识
        /// </summary>
        public int T102LeafID_InProduction { get; set; }

        /// <summary>
        /// 正在生产的产品编号
        /// </summary>
        public string T102Code_InProduction { get; set; }

        /// <summary>
        /// 正在执行的生产工单号
        /// </summary>
        public string PWONo_InExecution { get; set; }

        /// <summary>
        /// 正在执行工单签发时间
        /// </summary>
        public int PWOCreatedUnixTime_Current { get; set; }

        /// <summary>
        /// 待加工容器编号
        /// </summary>
        public string ContainerNo { get; set; }

        /// <summary>
        /// 已加工容器编号
        /// </summary>
        public string ContainerNo_Output { get; set; }

        /// <summary>
        /// 工位图片流
        /// </summary>
        public byte[] T107Image
        {
            get { return t107Image; }
            set
            {
                t107Image = value;
                try
                {
                    t107Picture = Tools.BytesToImage(value);
                }
                finally { }
            }
        }

        /// <summary>
        /// 工位图片
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public Image T107Picture
        {
            get { return t107Picture; }
        }

        /// <summary>
        /// 接下来要执行的生产工单
        /// </summary>
        public string NextPWOToExecute { get; set; }

        /// <summary>
        /// 下一张工单签发时间
        /// </summary>
        public int PWOCreatedUnixTime_Next { get; set; }

        /// <summary>
        /// 下一个工单的容器号
        /// </summary>
        public string NextContainerNo { get; set; }

        /// <summary>
        /// 下一个工单在制品/原材料获取位置
        /// </summary>
        public string AtStoreLocCode { get; set; }

        /// <summary>
        /// 当前工序完工后的目标存放库位
        /// </summary>
        public string DstStoreLocCode { get; set; }

        /// <summary>
        /// 正在生产的工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }
        /// <summary>
        /// 正在生产的设备叶标识
        /// </summary>
        public int T133LeafID { get; set; }
        /// <summary>
        /// SPC 控制图类型：0=不控制；373564=彩虹图；373565=XBar-R图
        /// </summary>
        public int T47LeafID { get; set; }
        /// <summary>
        /// SPC 控制的参数叶标识
        /// </summary>
        public int T20LeafID { get; set; }
        /// <summary>
        /// 控制线下限（XBar-R图有效）
        /// </summary>
        public long LCL { get; set; }
        /// <summary>
        /// 控制线上限（XBar-R图有效）
        /// </summary>
        public long UCL { get; set; }
        /// <summary>
        /// 控制线设置日期
        /// </summary>
        public string CLSetDate { get; set; }

        public WIPStationProductionStatus Clone()
        {
            WIPStationProductionStatus rlt = MemberwiseClone() as WIPStationProductionStatus;

            if (rlt.t107Picture == null)
                rlt.t107Picture = Tools.BytesToImage(rlt.t107Image);

            return rlt;
        }
    }
}