using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.MESRMM;
using IRAPORM;
using IRAPShared;

namespace IRAP.BL.MESRMM
{
    public class MesRMM : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public MesRMM()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取技能熟练程度列表
        /// </summary>
        /// <returns></returns>
        public IRAPJsonResult mfn_GetList_SkillLevels(
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
                List<SkillLevel> datas =
                    new List<SkillLevel>();

                datas.Add(
                    new SkillLevel()
                    {
                        Level = 1,
                        SkillLevelString = "Excellent(优秀)",
                    });
                datas.Add(
                    new SkillLevel()
                    {
                        Level = 2,
                        SkillLevelString = "Veteran(老练)",
                    });
                datas.Add(
                    new SkillLevel()
                    {
                        Level = 3,
                        SkillLevelString = "Fair(良好)",
                    });
                datas.Add(
                    new SkillLevel()
                    {
                        Level = 4,
                        SkillLevelString = "Qualified(合格)",
                    });

                errCode = 0;
                errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                WriteLog.Instance.Write(errText, strProcedureName);

                return Json(datas);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据社区获取可以设置技能矩阵的员工名单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <returns>List[UserOfSkillMatrix]</returns>
        public IRAPJsonResult sfn_GetList_UsersOfSkillMatrix(
            int communityID, 
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
                List<UserOfSkillMatrix> datas =
                    new List<UserOfSkillMatrix>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetList_UsersOfSkillMatrix，" +
                        "参数：CommunityID={0}",
                        communityID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_GetList_UsersOfSkillMatrix(" +
                            "@CommunityID) ORDER BY Ordinal";

                        IList<UserOfSkillMatrix> lstDatas =
                            conn.CallTableFunc<UserOfSkillMatrix>(strSQL, paramList);
                        datas = lstDatas.ToList<UserOfSkillMatrix>();
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
                            "调用 IRAP..sfn_GetList_UsersOfSkillMatrix 函数发生异常：{0}",
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

        /// <summary>
        /// 提供界面维护T20质量参数和工艺参数。
        /// 注意：前台界面需要在“增加”和“修改”时，
        ///      做 Code 和 Name 的重复性放错
        ///      （Code 为空时不需放错，Name 
        ///      不能空白）。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="deltaCMD">A-增；D-删；U-改</param>
        /// <param name="paramNode">
        /// 参数类型NodeID：
        /// 5094-制造质量参数；
        /// 5140-制造工艺参数。
        /// </param>
        /// <param name="paramLeaf">新增时：0；删除和修改时传参数的 LeafID</param>
        /// <param name="paramCode">参数的编码</param>
        /// <param name="paramName">参数的名称</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ssp_SaveADU_Parameters(
            int communityID, 
            string deltaCMD, 
            int paramNode, 
            int paramLeaf, 
            string paramCode, 
            string paramName, 
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
                paramList.Add(new IRAPProcParameter("@DeltaCMD", DbType.Int32, deltaCMD));
                paramList.Add(new IRAPProcParameter("@ParamName", DbType.String, paramNode));
                paramList.Add(new IRAPProcParameter("@ParamCLeaf", DbType.Int32, paramLeaf));
                paramList.Add(new IRAPProcParameter("@ParamCode", DbType.String, paramCode));
                paramList.Add(new IRAPProcParameter("@ParamName", DbType.String, paramName));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(
                    new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAP..ssp_SaveADU_Parameters，参数：" +
                        "CommunityID={0}|DeltaCMD={1}|ParamNode={2}|ParamLeaf={3}|" +
                        "ParamCode={4}|ParamName={5}|SysLogID={6}",
                        communityID, deltaCMD, paramNode, paramLeaf, paramCode,
                        paramName, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_SaveADU_Parameters", ref paramList);
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
                errText = 
                    string.Format(
                        "调用 IRAP..ssp_SaveADU_Parameters 时发生异常：{0}", 
                        error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取产品私有返工路由表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="shotTime">版本时间（空串表示最新版本）</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[PrivateRouterForAProduct]</returns>
        public IRAPJsonResult ufn_GetInfo_PrivateRouteTableOfAProduct(
            int communityID, 
            int t102LeafID, 
            string shotTime, 
            long sysLogID, 
            out int errCode, 
            out string errText)
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ufn_GetList_UserByProcess()
        {
            throw new System.NotImplementedException();
        }
    }
}
