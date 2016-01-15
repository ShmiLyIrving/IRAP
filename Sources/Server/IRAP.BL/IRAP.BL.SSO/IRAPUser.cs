using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAPShared;
using IRAPORM;
using IRAP.Entity.SSO;

namespace IRAP.BL.SSO
{
    public class IRAPUser : IRAPBLLBase
    {
        private static string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPUser()
        {
            WriteLog.Instance.WriteLogFileName = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        public IRAPJsonResult sfn_PostLoginCMDs(
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<CMDString> datas = new List<CMDString>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(string.Format("调用函数 IRAP..sfn_PostLoginCMDs，参数：SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * FROM IRAP..sfn_PostLoginCMDs(@SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<CMDString> lstDatas = conn.CallTableFunc<CMDString>(strSQL, paramList);
                        datas = lstDatas.ToList<CMDString>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_PostLoginCMDs 函数发生异常：{0}", error.Message);
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

        public IRAPJsonResult sfn_PostLogoutCMDs(
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<CMDString> datas = new List<CMDString>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(string.Format("调用函数 IRAP..sfn_PostLogoutCMDs，参数：SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * FROM IRAP..sfn_PostLogoutCMDs(@SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<CMDString> lstDatas = conn.CallTableFunc<CMDString>(strSQL, paramList);
                        datas = lstDatas.ToList<CMDString>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_PostLogoutCMDs 函数发生异常：{0}", error.Message);
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


        /// <summary>
        /// 获取用户名及密码验证的结果（0-验证不通过；1-验证通过，则返回社区标识号0;>1-验证通过，返回社区标识号）
        /// </summary>
        /// <param name="userCode">用户代码</param>
        /// <param name="plainPWD">用户密码明码</param>
        /// <param name="veriCode">验证码，不需时传空串</param>
        /// <param name="stationID">验证站点或社区标识</param>
        public IRAPJsonResult sfn_UserPWDVerify(
            string userCode,
            string plainPWD,
            string veriCode,
            string stationID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@PlainPWD", DbType.String, plainPWD));
                paramList.Add(new IRAPProcParameter("@VeriCode", DbType.String, veriCode));
                paramList.Add(new IRAPProcParameter("@StationID", DbType.String, stationID));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        int rlt = (int)conn.CallScalarFunc("IRAP.dbo.sfn_UserPWDVerify", paramList);
                        errCode = 0;
                        errText = "调用成功！";
                        return Json(rlt);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP.dbo.sfn_UserPWDVerify 函数发生异常：{0}", error.Message);
                    return Json(0);
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 申请系统登录标识 , 必要时也获取短信验证码
        /// </summary>
        /// <remarks>
        /// UserCode        string          用户代码
        /// StationID       string          站点标识/社区标识
        /// 输出
        /// SysLogID        long            系统登录标识
        /// SMSVeriCode     string          短信验证码
        /// </remarks>
        /// <param name="userCode">用户代码</param>
        /// <param name="stationID">站点标识/社区标识</param>
        public IRAPJsonResult ssp_GetSysLogID(
            string userCode,
            string stationID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@StationID", DbType.String, stationID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, ParameterDirection.Output, 8));
                paramList.Add(new IRAPProcParameter("@VeriCode", DbType.String, ParameterDirection.Output, 10));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_GetSysLogID", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        Hashtable rlt = new Hashtable();
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                            {
                                rlt.Add(param.ParameterName, param.Value);
                            }
                        }
                        return Json(rlt);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 ssp_GetSysLogID 函数发生异常：{0}", error.Message);
                    return Json(new Hashtable());
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 退出 IRAP 平台
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="userDiary">工作日志</param>
        public IRAPJsonResult ssp_Logout(
            int communityID,
            long sysLogID,
            string userDiary,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CummunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@UserDiary", DbType.String, userDiary));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(new IRAPProcParameter("@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(string.Format("执行存储过程 IRAP..ssp_Logout，参数：" +
                        "CommunityID={0}|UserDiary={1}|SysLogID={2}",
                        communityID, userDiary, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_Logout", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;

                    return Json("");
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAP..ssp_Logout 时发生异常：{0}", error.Message);
                return Json("");
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}