using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    /// <summary>
    /// 失效根源工序
    /// </summary>
    public class FailureSrcOperation
    {
        public int Ordinal { get; set; }
        public int OperationID { get; set; }
        public int OperationLeaf { get; set; }
        public string OperationCode { get; set; }
        public string OperationName { get; set; }
        public int PWOCategoryLeaf { get; set; }
        public string PWOCategoryName { get; set; }

        public FailureSrcOperation Clone()
        {
            return MemberwiseClone() as FailureSrcOperation;
        }
    }
}
