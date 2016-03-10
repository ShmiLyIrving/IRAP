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
    public class WorkUnit : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public WorkUnit()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 根据工位呼叫安灯记录计算工位停产时间(秒)
        /// [功能假定同一工位异常事件不重叠]
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="periodBegin">期间开始时间</param>
        /// <param name="periodEnd">期间结束时间</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>long[异常停产时间(s)]</returns>
        public IRAPJsonResult ufn_GetUnscheduledPDTofAWorkUnit(
            int communityID, 
            int t107LeafID, 
            DateTime periodBegin, 
            DateTime periodEnd, 
            long sysLogID, 
            out int errCode, 
            out string errText)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                long rlt = 0;

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.String, t107LeafID));
                paramList.Add(new IRAPProcParameter("@PeriodBegin", DbType.DateTime2, periodBegin));
                paramList.Add(new IRAPProcParameter("@PeriodEnd", DbType.DateTime2, periodEnd));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES.dbo.ufn_GetUnscheduledPDTofAWorkUnit，" +
                        "参数：CommunityID={0}|T107LeafID={1}|PeridoBegin={2}|" +
                        "PeriodEnd={3}|SysLogID={4}",
                        communityID, t107LeafID, periodBegin, periodEnd, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        rlt = (long) conn.CallScalarFunc(
                            "IRAPMES.dbo.ufn_GetUnscheduledPDTofAWorkUnit", 
                            paramList);
                        if (rlt > -2147483648)
                        {
                            errCode = 0;
                            errText = 
                                string.Format(
                                    "调用成功！获得 UnscheduledPDTofAWorkUnit={0}", 
                                    rlt);
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                        else
                        {
                            errCode = 99999;
                            errText = "未得到 UnscheduledPDTofAWorkUnit 的值";
                        }
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = 
                        string.Format(
                            "调用 IRAPMES.dbo.ufn_GetUnscheduledPDTofAWorkUnit 函数发生异常：{0}", 
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }
    }
}