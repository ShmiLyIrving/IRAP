using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAPGeneralGateway.Entities
{
    public class TEntityInputParam
    {
        /// <summary>
        /// 存储过程名
        /// </summary>
        public string ProcName { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string ParamName { get; set; }
        /// <summary>
        /// 参数类型
        /// </summary>
        public string ParamType { get; set; }
        /// <summary>
        /// 是否允许 NULL 值
        /// </summary>
        public bool CanNull { get; set; }
        /// <summary>
        /// 是否为输出参数
        /// </summary>
        public int IsOutput { get; set; }
        public int Length { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }
    }
}