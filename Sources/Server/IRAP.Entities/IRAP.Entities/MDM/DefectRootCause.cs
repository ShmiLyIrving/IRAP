using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    /// <summary>
    /// 缺陷根源工序
    /// </summary>
    public class DefectRootCause
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工序实体标识
        /// </summary>
        public int OperationID { get; set; }
        /// <summary>
        /// 工序叶标识
        /// </summary>
        public int OperationLeaf { get; set; }
        /// <summary>
        /// 工序代码
        /// </summary>
        public string OperationCode { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string OperationName { get; set; }
        /// <summary>
        /// 生产任务种类叶标识
        /// </summary>
        public int PWOCategoryLeaf { get; set; }
        /// <summary>
        /// 生产任务种类名称
        /// </summary>
        public string PWOCategoryName { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]{1}", OperationCode, OperationName);
        }

        public DefectRootCause Clone()
        {
            DefectRootCause rlt = MemberwiseClone() as DefectRootCause;

            return rlt;
        }
    }
}
