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
    public class PokaYoke : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public PokaYoke()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 在制品路由防错
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_PokaYoke_PalletRouting(
            int communityID,
            int t102LeafID,
            int t107LeafID,
            string pwoNo,
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
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@PWONo", DbType.String, pwoNo));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_PokaYoke_PalletRouting，参数：" +
                        "CommunityID={0}|T102LeafID={1}|T107LeafID={2}|" +
                        "PWONo={3}|SysLogID={4}",
                        communityID, t102LeafID, t107LeafID, pwoNo, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_PokaYoke_PalletRouting", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    return Json(error);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText =
                    string.Format(
                        "调用 IRAPMES..usp_PokaYoke_PalletRouting 函数发生异常：{0}",
                        error.Message);
                return Json(
                    new IRAPError()
                    {
                        ErrCode = errCode,
                        ErrText = errText,
                    });
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
