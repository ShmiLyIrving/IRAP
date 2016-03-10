using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.MES;
using IRAPORM;
using IRAPShared;

namespace IRAP.BL.MES
{
    public class ManualInspecting : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public ManualInspecting()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 计算 QCStatus 的值
        /// </summary>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="pwoNo">工单号</param>
        /// <param name="qcStatus">质量控制状态</param>
        private long CalculateQCStatus(
            int t102LeafID,
            int t107LeafID,
            string pwoNo,
            long qcStatus)
        {
            throw new System.NotImplementedException();
        }
    }
}