using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.UTS
{
    public class OperTypeInfo
    {
        /// <summary>
        /// 业务操作类型
        /// </summary>
        public int OpType { get; set; }

        /// <summary>
        /// 业务操作类型代码
        /// </summary>
        public string OpTypeCode { get; set; }
        /// <summary>
        /// 业务操作类型名称
        /// </summary>
        public string OpTypeName { get; set; }
        /// <summary>
        /// 业务操作类型序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 辅助交易表名
        /// </summary>
        public string AuxTranTBLName { get; set; }
        /// <summary>
        /// 联机事务处理临时事实表名
        /// </summary>
        public string OLTPTempFactTBLName { get; set; }
        /// <summary>
        /// 联机事务处理固化事实表名
        /// </summary>
        public string OLTPFixedFactTBLName { get; set; }
        /// <summary>
        /// 辅助事实表名
        /// </summary>
        public string AuxFactTBLName { get; set; }
        /// <summary>
        /// 补充统计规则
        /// </summary>
        public string ComplementaryRule { get; set; }
        /// <summary>
        /// 状态限制控制串
        /// </summary>
        public string StateExclCtrlStr { get; set; }
        /// <summary>
        /// 是否实体创建操作类型
        /// </summary>
        public bool EntityCreating { get; set; }
        /// <summary>
        /// 业务发生日期时间是否有效
        /// </summary>
        public bool BusinessDateIsValid { get; set; }
        /// <summary>
        /// 业务授权条件
        /// </summary>
        public string AuthorizingCondition { get; set; }

        public OperTypeInfo Clone()
        {
            return MemberwiseClone() as OperTypeInfo;
        }
    }
}
