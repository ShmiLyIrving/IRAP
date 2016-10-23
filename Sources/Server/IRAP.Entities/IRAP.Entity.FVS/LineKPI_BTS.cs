using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;
using IRAP.Global;

namespace IRAP.Entity.FVS
{
    public class LineKPI_BTS
    {
        private Quantity planQuantity = new Quantity();
        private Quantity btsQuantity = new Quantity();
        private Quantity actualQuantity = new Quantity();

        /// <summary>
        /// KPI指标名(BTS)
        /// </summary>
        public string KPIName { get; set; }
        /// <summary>
        /// KPI值(% 为单位，不必换算，加上 % 即可)
        /// </summary>
        public decimal KPIValue { get; set; }
        /// <summary>
        /// 应完成百分比
        /// </summary>
        public decimal BTSProgress { get; set; }
        /// <summary>
        /// 实际完成百分比
        /// </summary>
        public decimal ActualProgress { get; set; }
        /// <summary>
        /// 累计进度状态；
        /// 0-正常(95%--105%)   绿色；
        /// 1-偏快(105%--110%)  淡黄；
        /// 2-过快(大于 110%)       深黄；
        /// 3-偏慢(90%--95%)    桃红；
        /// 4-过慢(小于 90%)        大红
        /// </summary>
        public int BTSStatus { get; set; }
        /// <summary>
        /// 颜色RGB值(6位16进制)
        /// </summary>
        public string RGBColor { get; set; }
        /// <summary>
        /// 生产工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 数量放大数量级
        /// </summary>
        public int QtyScale
        {
            get { return planQuantity.Scale; }
            set
            {
                planQuantity.Scale = value;
                btsQuantity.Scale = value;
                actualQuantity.Scale = value;
            }
        }
        /// <summary>
        /// 计量单位（前台呈现暂时不用）
        /// </summary>
        public string UnitOfMeasure
        {
            get { return planQuantity.UnitOfMeasure; }
            set
            {
                planQuantity.UnitOfMeasure = value;
                btsQuantity.UnitOfMeasure = value;
                actualQuantity.UnitOfMeasure = value;
            }
        }
        /// <summary>
        /// 计划产量
        /// </summary>
        public long PlanQty
        {
            get { return planQuantity.IntValue; }
            set { planQuantity.IntValue = value; }
        }
        /// <summary>
        /// 实际开始时间
        /// </summary>
        public string ActualStartTime { get; set; }
        /// <summary>
        /// 至指定时间应完成产量
        /// </summary>
        public long BTSQty
        {
            get { return btsQuantity.IntValue; }
            set { btsQuantity.IntValue = value; }
        }
        /// <summary>
        /// 实际完成数量
        /// </summary>
        public long ActualQty
        {
            get { return actualQuantity.IntValue; }
            set { actualQuantity.IntValue = value; }
        }

        [IRAPORMMap(ORMMap = false)]
        public Quantity PlanQuantity
        {
            get { return planQuantity; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity BTSQuantity
        {
            get { return BTSQuantity; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity ActualQuantity
        {
            get { return actualQuantity; }
        }

        public LineKPI_BTS Clone()
        {
            LineKPI_BTS rlt = MemberwiseClone() as LineKPI_BTS;
            rlt.planQuantity = planQuantity.Clone();
            rlt.btsQuantity = btsQuantity.Clone();
            rlt.actualQuantity = actualQuantity.Clone();

            return rlt;
        }
    }
}