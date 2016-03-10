using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.MES;
using IRAPORM;
using IRAPShared;


namespace IRAP.BL.MES
{
    public class OperatorSkill : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public OperatorSkill()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 操作工技能放错
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="pokaYokeMode">
        /// 放错方式：
        /// 1-按工序员工技能放错；
        /// 2-按产品族+工序技能放错；
        /// 3-按产品+工序技能放错。
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_PokaYoke_OperatorSkill(
            int communityID, 
            int t102LeafID, 
            int t107LeafID, 
            int pokaYokeMode, 
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
                paramList.Add(new IRAPProcParameter("@PokaYokeMode", DbType.Int32, pokaYokeMode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(
                    new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 IRAPMES..usp_PokaYoke_OperatorSkill，参数：" +
                        "CommunityID={0}|T102LeafID={1}|T107LeafID={2}|PokaYokeMode={3}|" +
                        "SysLogID={4}",
                        communityID, t102LeafID, t107LeafID, pokaYokeMode, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPMES..usp_PokaYoke_OperatorSkill", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    Hashtable rtnParams = new Hashtable();
                    if (errCode == 0)
                    {
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                            {
                                if (param.DbType == DbType.Int32 && param.Value == DBNull.Value)
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                                else
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                            }
                        }
                    }

                    return Json(rtnParams);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPMES..usp_PokaYoke_OperatorSkill 时发生异常：{0}", error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 按工序维护员工技能
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="processID">工序 LeafID</param>
        /// <param name="userCode">员工工号</param>
        /// <param name="skillLevel">技能等级</param>
        /// <param name="updateMethod">
        /// 保存方式：
        /// 1-新增;
        /// 2-修改；
        /// 3-删除。
        /// </param>
        public IRAPJsonResult usp_SaveSkillOfProcess(
            int communityID, 
            int processID, 
            string userCode, 
            int skillLevel, 
            int updateMethod, 
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
                paramList.Add(new IRAPProcParameter("@ProcessID", DbType.Int32, processID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@SkillLevel", DbType.Int32, skillLevel));
                paramList.Add(new IRAPProcParameter("@UpdateMethod", DbType.Int64, updateMethod));
                paramList.Add(
                    new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(
                    new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 IRAPMES..usp_SaveSkillOfProcess，参数：" +
                        "CommunityID={0}|ProcessID={1}|UserCode={2}|SkillLevel={3}|"+
                        "UpdateMethod={4}",
                        communityID, processID, userCode, skillLevel, updateMethod),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPMES..usp_SaveSkillOfProcess", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    Hashtable rtnParams = new Hashtable();
                    if (errCode == 0)
                    {
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                            {
                                if (param.DbType == DbType.Int32 && param.Value == DBNull.Value)
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                                else
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                            }
                        }
                    }

                    return Json(rtnParams);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPMES..usp_SaveSkillOfProcess 时发生异常：{0}", error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}