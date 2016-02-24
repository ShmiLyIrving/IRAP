using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAPORM;
using IRAPShared;
using IRAP.Entity.MES;

namespace IRAP.BL.MES
{
    public class IRAPMESReport : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPMESReport()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 工单历史数据查询
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t132LeafID">业务操作标识</param>
        /// <param name="searchStartTime">查询开始时间</param>
        /// <param name="searchEndTime">查询结束时间</param>
        public IRAPJsonResult ufn_GetReport_MOExecution(
            int communityID, 
            int t132LeafID, 
            DateTime searchStartTime, 
            DateTime searchEndTime, 
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
                List<Report_MOExecution> datas = new List<Report_MOExecution>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T132LeafID", DbType.Int32, t132LeafID));
                paramList.Add(new IRAPProcParameter("@SearchStartTime", DbType.DateTime2, searchStartTime));
                paramList.Add(new IRAPProcParameter("@SearchEndTime", DbType.DateTime2, searchEndTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetReport_MOExecution，" +
                        "参数：CommunityID={0}|T132LeafID={1}|SearchStartTime={2}|" +
                        "SearchEndTime={3}|SysLogID={4}",
                        communityID, t132LeafID, searchStartTime, searchEndTime, 
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetReport_MOExecution(" +
                            "@CommunityID, @T132LeafID, @SearchStartTime, " +
                            "@SearchEndTime, @SysLogID)";

                        IList<Report_MOExecution> lstDatas = 
                            conn.CallTableFunc<Report_MOExecution>(strSQL, paramList);
                        datas = lstDatas.ToList<Report_MOExecution>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPMES..ufn_GetReport_MOExecution 函数发生异常：{0}",
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}