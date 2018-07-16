using System;

namespace PlanMGMT.Model
{
    /// <summary>
    /// 字典类
    /// </summary>
    public class TypeList
    {
        /// <summary>
        /// 唯一编码
        /// </summary>
        public Int64 Id { get; set; }
        /// <summary>
        /// 父编码
        /// </summary>
        public Int64 FatherId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }
    }
}
