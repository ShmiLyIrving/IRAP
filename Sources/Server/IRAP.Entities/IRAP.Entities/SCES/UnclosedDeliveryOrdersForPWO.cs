using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entities.SCES
{
    public class UnclosedDeliveryOrdersForPWO
    {
        /// <summary>
        /// 辅助事实分区键
        /// </summary>
        public long AF482PK { get; set; }
        /// <summary>
        /// 排产事实编号
        /// </summary>
        public long FactID { get; set; }
        /// <summary>
        /// 制造订单号
        /// </summary>
        public string MONumber { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public int MOLineNo { get; set; }
        /// <summary>
        /// 生产工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductDesc { get; set; }
        /// <summary>
        /// 工单数量
        /// </summary>
        public long OrderQty { get; set; }
        /// <summary>
        /// 排定生产时间
        /// </summary>
        public string ScheduledStartTime { get; set; }
        /// <summary>
        /// 要求配送物料号
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 要求配送物料名称
        /// </summary>
        public string MaterialDesc { get; set; }
        /// <summary>
        /// 要求配送数量
        /// </summary>
        public long QtyToDeliver { get; set; }
        /// <summary>
        /// 要求送达时间
        /// </summary>
        public string RequestedArrivalTime { get; set; }
        /// <summary>
        /// 实际配送时间
        /// </summary>
        public string MaterialDeliverTime { get; set; }
        /// <summary>
        /// 实际配送数量
        /// </summary>
        public long QtyDelivered { get; set; }
        /// <summary>
        /// 配送使用的容器
        /// </summary>
        public string ContainerNo { get; set; }
        /// <summary>
        /// 生产工单状态：
        /// 1-新签发
        /// 2-ATP检查通过
        /// 3-工装已备
        /// 4-物料已备
        /// 5-已开始生产
        /// 6-已暂停生产
        /// 7-工单已撤销
        /// 8-工单已提交
        /// 9-工单已关闭
        /// </summary>
        public int PWOStatus { get; set; }
        /// <summary>
        /// 准时配送状态（0=待确定 1=准时 2=不准时）
        /// </summary>
        public int OTDStatus { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public string PWOStatusString
        {
            get
            {
                switch (PWOStatus)
                {
                    case 1:
                        return "新签发";
                    case 2:
                        return "ATP检查通过";
                    case 3:
                        return "工装已备";
                    case 4:
                        return "物料已备";
                    case 5:
                        return "已开始生产";
                    case 6:
                        return "已暂停生产";
                    case 7:
                        return "工单已撤销";
                    case 8:
                        return "工单已提交";
                    case 9:
                        return "工单已关闭";
                    default:
                        return "";
                }
            }
        }


        [IRAPORMMap(ORMMap = false)]
        public string OTDStatusString
        {
            get
            {
                switch (OTDStatus)
                {
                    case 0:
                        return "不确定";
                    case 1:
                        return "准时";
                    case 2:
                        return "过期";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// 配送时间差
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public string DeliverTimeSpan
        {
            get
            {
                if (MaterialDeliverTime == "")
                {
                    return TimeParser.DateDiff(
                        DateTime.Now,
                        Tools.ConvertToDateTime(RequestedArrivalTime));
                }
                else
                {
                    return TimeParser.DateDiff(
                        Tools.ConvertToDateTime(RequestedArrivalTime),
                        Tools.ConvertToDateTime(MaterialDeliverTime));
                }
            }
        }

        /// <summary>
        /// 配送状态
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public string DeliverStatusString
        {
            get
            {
                if (QtyDelivered == 0)
                {
                    return "未配送";
                }
                else
                {
                    return "已配送";
                }
            }
        }

        public UnclosedDeliveryOrdersForPWO Clone()
        {
            UnclosedDeliveryOrdersForPWO rlt =
                MemberwiseClone() as UnclosedDeliveryOrdersForPWO;

            return rlt;
        }
    }
}
