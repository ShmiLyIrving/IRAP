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
    public class TroubleShooting : IRAPBLLBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public TroubleShooting()
        {
            WriteLog.Instance.WriteLogFileName = 
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取送修在制品修复转出工序清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="srcT107LeafID">来源工位叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetList_QCOperationsForNG(
            int communityID, 
            int t102LeafID, 
            int srcT107LeafID, 
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
                List<QCOperationForNG> datas = new List<QCOperationForNG>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@SrcT107LeafID", DbType.Int32, srcT107LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetList_QCOperationsForNG，" +
                        "参数：CommunityID={0}|T102LeafID={1}|SrcT107LeafID={2}|" +
                        "SysLogID={3}",
                        communityID, t102LeafID, srcT107LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_QCOperationsForNG(" +
                            "@CommunityID, @T132LeafID, @SearchStartTime, " +
                            "@SearchEndTime, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<QCOperationForNG> lstDatas =
                            conn.CallTableFunc<QCOperationForNG>(strSQL, paramList);
                        datas = lstDatas.ToList<QCOperationForNG>();
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
                            "调用 IRAPMES..ufn_GetList_QCOperationsForNG 函数发生异常：{0}",
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