using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class FactPackaging
    {
        /// <summary>
        /// 事实编号
        /// </summary>
        public long FactID { get; set; }              
        /// <summary>
        /// 产品主标识条码
        /// </summary>
        public string WIPCode { get; set; }         
        /// <summary>
        /// 产品副标识条码
        /// </summary>
        public string AltWIPCode { get; set; }         
        /// <summary>
        /// 产品序列号
        /// </summary>
        public string SerialNumber { get; set; }        
        /// <summary>
        /// 生产批号
        /// </summary>
        public string LotNumber { get; set; }       
        /// <summary>
        /// 容器编号
        /// </summary>
        public string ContainerNo { get; set; }     
        /// <summary>
        /// 包装规格序号
        /// </summary>
        public int PackagingSpecNo { get; set; }     
        /// <summary>
        /// 质量状态
        /// </summary>
        public long QCStatus { get; set; }          
        /// <summary>
        /// 产品数量
        /// </summary>
        public long QtyPacked { get; set; }        
        /// <summary>
        /// 铲板第几层
        /// </summary>
        public int LayerIdxOfPallet { get; set; }  
        /// <summary>
        /// 当前层第几箱
        /// </summary>
        public int CartonIdxOfLayer { get; set; }  
        /// <summary>
        /// 箱内第几层内包装(盒）
        /// </summary>
        public int LayerIdxOfCarton { get; set; }     
        /// <summary>
        /// 箱内第几排内包装(盒)
        /// </summary>
        public int RowIdxOfCarton { get; set; }    
        /// <summary>
        /// 箱内第几列内包装(盒)
        /// </summary>
        public int ColIdxOfCarton { get; set; }    
        /// <summary>
        /// 盒内第几层产品
        /// </summary>
        public int LayerIdxOfBox { get; set; }    
        /// <summary>
        /// 盒内第几排产品
        /// </summary>
        public int RowIdxOfBox { get; set; }   
        /// <summary>
        /// 盒内第几列产品
        /// </summary>
        public int ColIdxOfBox { get; set; }    
        /// <summary>
        /// 内包装序列号
        /// </summary>
        public string BoxSerialNumber { get; set; } 
        /// <summary>
        /// 箱包装序列号
        /// </summary>
        public string CartonSerialNumber { get; set; } 
        /// <summary>
        /// 包装层层序列号
        /// </summary>
        public string LayerSerialNumber { get; set; } 
        /// <summary>
        /// 铲板标签序列号
        /// </summary>
        public string PalletSerialNumber { get; set; } 
        /// <summary>
        /// 拆包Unix时间
        /// </summary>
        public int UnpackedUnixTime { get; set; }

        public FactPackaging Clone()
        {
            return MemberwiseClone() as FactPackaging;
        }
    }
}
