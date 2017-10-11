using IRAPShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MESPDC.Areas.MESPDC.Models
{
    public class MethodParametersModel
    {
        /// <summary>
        /// 自增序列号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// 参数ID
        /// </summary>
        public int ParameterID { get; set; }
        /// <summary>
        /// 样品01
        /// </summary>
        public int Sample01 { get; set; }
        /// <summary>
        /// 样品02
        /// </summary>
        public int Sample02 { get; set; }
        /// <summary>
        /// 样品03
        /// </summary>
        public int Sample03 { get; set; }
        /// <summary>
        /// 样品03
        /// </summary>
        public int Sample04 { get; set; }
        /// <summary>
        /// 样品04
        /// </summary>
        public int Sample05 { get; set; }
        /// <summary>
        /// 样品05
        /// </summary>
        public int Sample06 { get; set; }
        /// <summary>
        /// 样品07
        /// </summary>
        public int Sample07 { get; set; }
        /// <summary>
        /// 样品08
        /// </summary>
        public int Sample08 { get; set; }
         [IRAPORMMap(false)]
        public int ErrCode { get; set; }
         [IRAPORMMap(false)]
         public string ErrText { get; set; }
    }

    public class MethodParametersModel_String
    {
        /// <summary>
        /// 自增序列号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// 参数ID
        /// </summary>
        public int ParameterID { get; set; }
        /// <summary>
        /// 样品01
        /// </summary>
        public string Sample01 { get; set; }
        /// <summary>
        /// 样品02
        /// </summary>
        public string Sample02 { get; set; }
        /// <summary>
        /// 样品03
        /// </summary>
        public string Sample03 { get; set; }
        /// <summary>
        /// 样品03
        /// </summary>
        public string Sample04 { get; set; }
        /// <summary>
        /// 样品04
        /// </summary>
        public string Sample05 { get; set; }
        /// <summary>
        /// 样品05
        /// </summary>
        public string Sample06 { get; set; }
        /// <summary>
        /// 样品07
        /// </summary>
        public string Sample07 { get; set; }
        /// <summary>
        /// 样品08
        /// </summary>
        public string Sample08 { get; set; }
        [IRAPORMMap(false)]
        public int ErrCode { get; set; }
        [IRAPORMMap(false)]
        public string ErrText { get; set; }
    }

    /// <summary>
    /// IRAPMES..ufn_GetList_MethodStandard
    /// </summary>
    public class MethodStandardModel
    {
        /// <summary>
        /// 参数LeafID
        /// </summary>
        public int T20LeafID { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string T20NodeName { get; set; }
        /// <summary>
        /// 低限制
        /// </summary>
        public int LowLimit { get; set; }
        /// <summary>
        /// 判断标准
        /// </summary>
        public string Criterion { get; set; }
        /// <summary>
        /// 高限制
        /// </summary>
        public int HighLimit { get; set; }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UnitOfMeasure { get; set; }
    }
}