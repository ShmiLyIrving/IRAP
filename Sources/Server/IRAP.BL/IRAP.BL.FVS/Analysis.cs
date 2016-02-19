using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAPShared;
using IRAPORM;
using IRAP.Global;
using IRAP.Entity.FVS;

namespace IRAP.BL.FVS
{
    public class Analysis : IRAPBLLBase
    {
        private static string className = 
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public Analysis()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 返回指定产线指定班次质量问题分析Pareto图
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t134LeafID">产线叶标识</param>
        /// <param name="workDate">工作日(yyyy-mm-dd)</param>
        /// <param name="t126LeafID">班次叶标识</param>
        /// <param name="nowTime">当前时点</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetAnalysis_LineQualityProblem(
            int communityID, 
            int t134LeafID, 
            string workDate, 
            int t126LeafID, 
            DateTime nowTime, 
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
                List<LineQualityProblemInfo> datas = new List<LineQualityProblemInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T134LeafID", DbType.Int32, t134LeafID));
                paramList.Add(new IRAPProcParameter("@WorkDate", DbType.String, workDate));
                paramList.Add(new IRAPProcParameter("@T126LeafID", DbType.Int32, t126LeafID));
                paramList.Add(new IRAPProcParameter("@NowTime", DbType.DateTime2, nowTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetAnalysis_LineQualityProblem，" +
                        "参数：CommunityID={0}|T134LeafID={1}|WorkDate={2}|" +
                        "T126LeafID={3}|NowTime={4}|SysLogID={5}",
                        communityID, t134LeafID, workDate, t126LeafID, nowTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetAnalysis_LineQualityProblem(" +
                            "@CommunityID, @T134LeafID, @WorkDate, @T126LeafID, " +
                            "@NowTime, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<LineQualityProblemInfo> lstDatas =
                            conn.CallTableFunc<LineQualityProblemInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<LineQualityProblemInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetAnalysis_LineQualityProblem 函数发生异常：{0}", error.Message);
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