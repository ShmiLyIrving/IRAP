using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entity.FVS
{
    public class Dashboard_WorkUnitProductionProgress
    {
        private int productionProgress = 0;

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// 工位叶标识（不呈现）
        /// </summary>
        public int T107LeafID { get; set; }

        /// <summary>
        /// 工位实体标识（不呈现）
        /// </summary>
        public int T107EntityID { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string T107Name { get; set; }

        /// <summary>
        /// 背景颜色(#FFFFFF)
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// 生产工单号（不呈现）
        /// </summary>
        public string PWONo { get; set; }

        /// <summary>
        /// 制造订单号
        /// </summary>
        public string MONumber { get; set; }

        /// <summary>
        /// 制造订单行号
        /// </summary>
        public int MOLineNo { get; set; }

        /// <summary>
        /// 产品叶标识（不呈现）
        /// </summary>
        public int T102LeafID { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 待加工容器号
        /// </summary>
        public string InputContainerNo { get; set; }

        /// <summary>
        /// 已加工容器号
        /// </summary>
        public string OutputContainerNo { get; set; }

        /// <summary>
        /// 待加工产品数量
        /// </summary>
        public long QtyToMFG { get; set; }

        /// <summary>
        /// 已报工产品数量
        /// </summary>
        public long QtyCompleted { get; set; }

        /// <summary>
        /// 标准周期时间（ms)(转换成秒显示，带3位小数）
        /// </summary>
        public int StdCycleTime { get; set; }

        /// <summary>
        /// 开始生产时间(yyyy-mm-dd hh:mm)
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 应该结束时间(yyyy-mm-dd hh:mm)
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 生产进度状态
        /// </summary>
        /// <remarks>
        /// -1=未开工
        /// 0=正常 还未到应该结束时间
        /// 3=偏慢 当前已过结束时间小于等于10%
        /// 4=过慢 当前已过结束时间大于10%
        /// </remarks>
        public int ProductionProgress
        {
            get
            {
                if (MONumber == "")
                    return -1;
                else
                    return productionProgress;
            }
            set { productionProgress = value; }
        }

        /// <summary>
        /// 工单签发辅助事实分区键
        /// </summary>
        public long AF482PK { get; set; }

        /// <summary>
        /// 在制品工位分布表分区键
        /// </summary>
        public long WIPPK { get; set; }

        /// <summary>
        /// 工艺标识(C64ID)
        /// </summary>
        public int MethodID { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public double StdCycleSeconds
        {
            get { return Convert.ToDouble(StdCycleTime) / 1000; }
        }

        [IRAPORMMap(ORMMap = false)]
        public string ProductNoToShow
        {
            get
            {
                if (MONumber == "")
                    return "";
                else
                    return string.Format("{0}([{1}]->[{2}])",
                            ProductNo,
                            InputContainerNo,
                            OutputContainerNo);
            }
        }

        public Dashboard_WorkUnitProductionProgress Clone()
        {
            return this.MemberwiseClone() as Dashboard_WorkUnitProductionProgress;
        }
    }
}