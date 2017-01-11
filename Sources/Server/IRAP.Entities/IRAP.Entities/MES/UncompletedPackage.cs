using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class UncompletedPackage
    {
        /// <summary>
        /// 交易号（0表示没有未完成箱包装)
        /// </summary>
        public long TransactNo { get; set; }             
        /// <summary>
        /// 箱内已包装产品数量
        /// </summary>
        public long NumQtyInCarton { get; set; }      
        /// <summary>
        /// 产品序列号
        /// </summary>
        public string PalletSerialNumber { get; set; } 
        /// <summary>
        /// 当前包装是铲板的第几层
        /// </summary>
        public int LayerNumOfPallet { get; set; }  
        /// <summary>
        /// 当前包装是本层的第几箱
        /// </summary>
        public int CartonNumOfLayer { get; set; }   
        
        public UncompletedPackage Clone()
        {
            return MemberwiseClone() as UncompletedPackage;
        } 
    }
}
