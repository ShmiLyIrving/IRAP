using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.WebAPI.Entities.SCES
{
    /// <summary>
    /// DeliveryOrdersOnRoad 交易的请求报文类
    /// </summary>
    public class TREQDeliveryOrdersOnRoad : TIRAPCustomRequestContent
    {
        /// <summary>
        /// 目标库房叶标识
        /// </summary>
        public int DstT173LeafID { get; set; }
    }
}
