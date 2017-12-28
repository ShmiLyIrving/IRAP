using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entities.MES
{
    /// <summary>
    /// 返工工单信息
    /// </summary>
    public class OpenReworkPWO
    {
        private Quantity pwoQuantity = new Quantity();

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// 工单签发事实编号
        /// </summary>
        public long PWOIssuingFactID { get; set; }

        /// <summary>
        /// 工单签发事实分区键
        /// </summary>
        public long TF482PK { get; set; }

        /// <summary>
        /// 返工工单号
        /// </summary>
        public string PWONo { get; set; }

        /// <summary>
        /// 返工产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }

        /// <summary>
        /// 返工产品编号
        /// </summary>
        public string ProductNo { get; set; }

        /// <summary>
        /// 返工产品名称
        /// </summary>
        public string ProductDesc { get; set; }

        /// <summary>
        /// 返工产品族叶标识
        /// </summary>
        public int T132LeafID { get; set; }

        /// <summary>
        /// 返工数量
        /// </summary>
        public long PWOQty
        {
            get { return pwoQuantity.IntValue; }
            set { pwoQuantity.IntValue = value; }
        }

        /// <summary>
        /// 放大数量级
        /// </summary>
        public int QtyScale
        {
            get { return pwoQuantity.Scale; }
            set { pwoQuantity.Scale = value; }
        }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure
        {
            get { return pwoQuantity.UnitOfMeasure; }
            set { pwoQuantity.UnitOfMeasure = value; }
        }

        [IRAPORMMap(ORMMap = false)]
        public Quantity PWOQuantity
        {
            get { return pwoQuantity; }
        }

        /// <summary>
        /// 产线叶标识
        /// </summary>
        public int T134LeafID { get; set; }

        /// <summary>
        /// 产线代码
        /// </summary>
        public string LineCode { get; set; }

        /// <summary>
        /// 产线名称
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 返工依据
        /// </summary>
        public string ReworkBasis { get; set; }

        /// <summary>
        /// 容器编号
        /// </summary>
        public string ContainerNo { get; set; }

        /// <summary>
        /// 排定返工开始时间
        /// </summary>
        public string ScheduledStartTime { get; set; }

        /// <summary>
        /// 返工工单状态
        /// </summary>
        /// <remarks>
        /// 1-工单新创建
        /// 2-工艺已设置
        /// 3-工装已备齐
        /// 4-物料已备齐
        /// 5-返工已开始
        /// 6-返工被搁置
        /// 7-工单已取消
        /// 8-工单已提交
        /// 9-工单已关闭
        /// </remarks>
        public int PWOStatus { get; set; }

        public OpenReworkPWO Clone()
        {
            OpenReworkPWO rlt = MemberwiseClone() as OpenReworkPWO;

            rlt.PWOQty = this.PWOQty;
            rlt.QtyScale = this.QtyScale;
            rlt.UnitOfMeasure = this.UnitOfMeasure;

            return rlt;
        }
    }
}
