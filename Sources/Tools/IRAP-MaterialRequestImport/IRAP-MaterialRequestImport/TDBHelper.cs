using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Reflection;

using IRAP.Global;
using IRAPORM;
using IRAPShared;

namespace IRAP_MaterialRequestImport
{
    public class TDBHelper
    {
        private static TDBHelper _instance = null;

        public static TDBHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TDBHelper();
                return _instance;
            }
        }

        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private TDBHelper() { }

        /// <summary>
        /// 获取用户名及密码的验证结果
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="plainPWD"></param>
        /// <param name="veriCode"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns>false:验证不通过;true:验证通过</returns>
        public bool sfn_UserPWDVerify(
            string userCode,
            string plainPWD,
            string veriCode,
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
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@PlainPWD", DbType.String, plainPWD));
                paramList.Add(new IRAPProcParameter("@VeriCode", DbType.String, veriCode));
                WriteLog.Instance.Write(
                    $"调用函数 IRAP.dbo.sfn_UserPWDVerify，参数：UserCode={userCode}|" +
                    $"PlainPWD={plainPWD}|VeriCode={veriCode}",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn =
                        new IRAPSQLConnection(
                            TParams.Instance.DBConnectionStr))
                    {
                        bool rlt = (bool)conn.CallScalarFunc("IRAP.dbo.sfn_UserPWDVerify", paramList);
                        errCode = 0;
                        errText = $"调用成功！获得函数结果 ({rlt})";
                        WriteLog.Instance.Write(errText, strProcedureName);
                        return rlt;
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP.dbo.sfn_UserPWDVerify 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    return false;
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public List<TAgencyInfo> sfn_UserAgencies(
            string userCode,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<TAgencyInfo> datas = new List<TAgencyInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                WriteLog.Instance.Write(
                    "调用函数 IRAP..sfn_UserAgencies，" +
                    $"参数：UserCode={userCode}",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn =
                        new IRAPSQLConnection(
                            TParams.Instance.DBConnectionStr))
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_UserAgencies(@UserCode)";

                        IList<TAgencyInfo> lstDatas = 
                            conn.CallTableFunc<TAgencyInfo>(strSQL, paramList);
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_UserAgencies 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return datas;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取机构中用户角色清单用于登录时角色选择
        /// </summary>
        /// <param name="userCode">用户代码</param>
        public List<TRoleInfo> sfn_UserRoles(
            string userCode,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<TRoleInfo> datas = new List<TRoleInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                WriteLog.Instance.Write(
                    "调用函数 IRAP..sfn_UserRolesInAgency，" +
                    $"参数：UserCode={userCode}",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn =
                        new IRAPSQLConnection(
                            TParams.Instance.DBConnectionStr))
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_UserRoles(" +
                            "@UserCode)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<TRoleInfo> lstDatas = 
                            conn.CallTableFunc<TRoleInfo>(strSQL, paramList);
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_UserRolesInAgency 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return datas;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void ssp_RunAFunction(
            long sysLogID,
            int menuItemID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn =
                        new IRAPSQLConnection(
                            TParams.Instance.DBConnectionStr))
                    {
                        string strSQL = 
                            "INSERT INTO IRAP..stb153 " +
                            $"SELECT {sysLogID},"+
                            $"'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}',"+
                            $"{menuItemID};\n" +
                            "UPDATE IRAP..stb009 " +
                            $"SET DBName='IRAPSCES' "+
                            $"WHERE SysLogID={sysLogID}";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        conn.CallScalar(strSQL);

                        errCode = 0;
                        errText = "调用成功！";
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("向 IRAP..stb153 中插入记录时发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
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
        public long ssp_GetSysLogID(
            string userCode,
            string stationID,
            out string smsVeriCode,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@StationID", DbType.String, stationID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, ParameterDirection.Output, 8));
                paramList.Add(new IRAPProcParameter("@SMSVeriCode", DbType.String, ParameterDirection.Output, 10));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    "执行存储过程 IRAP..ssp_GetSysLogID，" +
                    $"参数：UserCode={userCode}|StationID={stationID}",
                    strProcedureName);
                #endregion

                long sysLogID = 0;
                smsVeriCode = "";

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = 
                        new IRAPSQLConnection(
                            TParams.Instance.DBConnectionStr))
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_GetSysLogID", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        foreach ( IDataParameter param in paramList)
                        {
                            if (param.ParameterName == "@SysLogID")
                            {
                                if (param.Value != DBNull.Value)
                                {
                                    sysLogID = (long)param.Value;
                                }
                            }
                            else if (param.ParameterName == "@SMSVeriCode")
                            {
                                if (param.Value != DBNull.Value)
                                {
                                    smsVeriCode = param.Value.ToString();
                                }
                            }
                        }
                        WriteLog.Instance.Write(
                            $"SysLogID=({sysLogID})|SMSVeriCode=({smsVeriCode})",
                            strProcedureName);

                        return sysLogID;
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 ssp_GetSysLogID 函数发生异常：{0}", error.Message);
                    return sysLogID;
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 登录 IRAP 平台
        /// 1、校验用户名、用户密码、验证码集信息站点的合法性
        /// 2、校验通过时写系统登录日志，取得用户及站点的有关信息
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="plainPWD">登录密码</param>
        /// <param name="veriCode">验证码</param>
        /// <param name="stationID">站点标识</param>
        /// <param name="ipAddress">IP 地址</param>
        /// <param name="agencyLeaf">登录机构叶标识</param>
        /// <param name="roleLeaf">登录角色叶标识</param>
        /// <param name="sysLogID">系统登录标识（可预先获取）</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns>
        /// [
        ///     UserName string: 用户姓名
        ///     NickName string: 用户昵称
        ///     SysLogID long: 系统登录标识
        ///     LanguageID int: 语言标识
        ///     OPHoneNo string: 办公电话
        ///     HPhoneNo string: 住宅电话
        ///     MPhoneNo string: 移动电话
        ///     AgencyID int: 机构标识
        ///     AgencyName string: 机构名称
        ///     HostName string: 主机名
        /// ]
        /// </returns>
        public void ssp_Login(
            string dbName,
            string userCode,
            string plainPWD,
            string veriCode,
            string stationID,
            string ipAddress,
            int agencyLeaf,
            int roleLeaf,
            ref string userName,
            ref string nickName,
            ref long sysLogID,
            ref int languageID,
            ref string oPhoneNo,
            ref string hPhoneNo,
            ref string mPhoneNo,
            ref int agencyID,
            ref string agencyName,
            ref string hostName, 
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@DBName", DbType.String, dbName));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@PlainPWD", DbType.String, plainPWD));
                paramList.Add(new IRAPProcParameter("@VeriCode", DbType.String, veriCode));
                paramList.Add(new IRAPProcParameter("@StationID", DbType.String, stationID));
                paramList.Add(new IRAPProcParameter("@IPAddress", DbType.String, ipAddress));
                paramList.Add(new IRAPProcParameter("@AgencyLeaf", DbType.Int32, agencyLeaf));
                paramList.Add(new IRAPProcParameter("@RoleLeaf", DbType.Int32, roleLeaf));
                paramList.Add(new IRAPProcParameter("@UserName", DbType.String, ParameterDirection.Output, 40));
                paramList.Add(new IRAPProcParameter("@NickName", DbType.String, ParameterDirection.Output, 40));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, ParameterDirection.InputOutput, 8)
                {
                    Value = sysLogID,
                });
                paramList.Add(new IRAPProcParameter("@LanguageID", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@OPhoneNo", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(new IRAPProcParameter("@HPhoneNo", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(new IRAPProcParameter("@MPhoneNo", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(new IRAPProcParameter("@AgencyID", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@AgencyName", DbType.String, ParameterDirection.Output, 100));
                paramList.Add(new IRAPProcParameter("@HostName", DbType.String, ParameterDirection.Output, 30));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    "执行存储过程 IRAP..ssp_Login，参数：" +
                    $"DBName={dbName}|UserCode={userCode}|PlainPWD={plainPWD}|"+
                    $"VeriCode={veriCode}|StationID={stationID}|IPAddress={ipAddress}|"+
                    $"AgencyLeaf={agencyLeaf}|RoleLeaf={roleLeaf}|SysLogID={sysLogID}",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = 
                    new IRAPSQLConnection(
                        TParams.Instance.DBConnectionStr))
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_Login", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    foreach (IDataParameter param in paramList)
                    {
                        switch (param.ParameterName)
                        {
                            case "@UserName":
                                if (param.Value != DBNull.Value)
                                {
                                    userName = (string)param.Value;
                                }
                                break;
                            case "@NickName":
                                if (param.Value != DBNull.Value)
                                {
                                    nickName = (string)param.Value;
                                }
                                break;
                            case "@SysLogID":
                                if (param.Value != DBNull.Value)
                                {
                                    sysLogID = (long)param.Value;
                                }
                                break;
                            case "@LanguageID":
                                if (param.Value != DBNull.Value)
                                {
                                    languageID = (int)param.Value;
                                }
                                break;
                            case "@OPhoneNo":
                                if (param.Value != DBNull.Value)
                                {
                                    oPhoneNo = (string)param.Value;
                                }
                                break;
                            case "@HPhoneNo":
                                if (param.Value != DBNull.Value)
                                {
                                    hPhoneNo = (string)param.Value;
                                }
                                break;
                            case "@MPhoneNo":
                                if (param.Value != DBNull.Value)
                                {
                                    mPhoneNo = (string)param.Value;
                                }
                                break;
                            case "@AgencyID":
                                if (param.Value != DBNull.Value)
                                {
                                    agencyID = (int)param.Value;
                                }
                                break;
                            case "@AgencyName":
                                if (param.Value != DBNull.Value)
                                {
                                    agencyName = (string)param.Value;
                                }
                                break;
                            case "@HostName":
                                if (param.Value != DBNull.Value)
                                {
                                    hostName = (string)param.Value;
                                }
                                break;
                        }
                    }
                    WriteLog.Instance.Write(
                        $"UserName=({userName})|NickName=({nickName})|" +
                        $"SysLogID=({sysLogID})|LanguageID=({languageID})|" +
                        $"OPhoneNo=({oPhoneNo})|HPhoneNo=({hPhoneNo})|" +
                        $"MPhoneNo=({mPhoneNo})|AgencyID=({agencyID})|" +
                        $"AgencyName=({agencyName})|HostName=({hostName})",
                        strProcedureName);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAP..ssp_Login 时发生异常：{0}", error.Message);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 退出 IRAP 平台
        /// </summary>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="userDiary">工作日志</param>
        public void ssp_Logout(
            long sysLogID,
            string userDiary,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@UserDiary", DbType.String, userDiary));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(
                    "执行存储过程 IRAP..ssp_Logout，参数：" +
                    $"SysLogID={sysLogID}|UserDiary={1}",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = 
                    new IRAPSQLConnection(
                        TParams.Instance.DBConnectionStr))
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_Logout", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAP..ssp_Logout 时发生异常：{0}", error.Message);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void DeleteOldTableData(
            string tableName,
            int communityID,
            long importID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                long partitioningKey = communityID * 10000;

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@PartitioningKey", DbType.Int64, partitioningKey));
                paramList.Add(new IRAPProcParameter("@ImportLogID", DbType.Int64, importID));
                WriteLog.Instance.Write(
                    $"执行 DELETE FROM IRAPDPA..{tableName} WHERE PartitioningKey={partitioningKey} "+
                    $"AND ImportID={importID}。",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn =
                    new IRAPSQLConnection(
                        TParams.Instance.DBConnectionStr))
                {
                    string strSQL =
                        $"DELETE FROM IRAPDPA..{tableName} WHERE PartitioningKey={partitioningKey} " +
                        $"AND ImportID={importID}";

                    var count = conn.CallScalar(strSQL, paramList);
                    IRAPError error = new IRAPError(0, "数据删除成功");

                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = $"删除(IRAPDPA..{tableName})时发生异常：{error.Message}";
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 向数据库表 IRAPDPA..dpa_Log_MaterialReq 表中插入多条记录
        /// </summary>
        /// <param name="datas">记录集合</param>
        public void msp_InsertIntoMaterialReq(
            List<Tdpa_Log_MaterialReq> datas,
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
                using (IRAPSQLConnection conn = 
                    new IRAPSQLConnection(
                        TParams.Instance.DBConnectionStr))
                {
                    try
                    {
                        int count = 0;
                        foreach (Tdpa_Log_MaterialReq data in datas)
                        {
                            string strSQL =
                                "INSERT INTO IRAPDPA..dpa_Log_MaterialReq " +
                                $"SELECT {data.PartitioningKey},{data.ImportID}," +
                                $"'{data.ImportDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}'," +
                                $"{data.Ordinal},'{data.MaterialCode}',{data.ReqQty}," +
                                $"'{data.SrcLoc}','{data.DstLoc}','{data.RoutingCode}'," +
                                $"0,0,0,0,0,'{data.Remark}',{data.ErrCode}," +
                                $"'{data.ErrText}'";

                            conn.CallScalar(strSQL);
                            count++;
                        }
                        //int count = conn.BatchInsert(datas);

                        errCode = 0;
                        errText =
                            string.Format(
                                "在 IRAPDPA..dpa_Log_MaterialReq 表中插入 [{0}] 条记录",
                                count);
                    }
                    catch (Exception error)
                    {
                        errCode = 99000;
                        errText =
                            string.Format(
                                "在向 IRAPDPA..dpa_Log_MaterialReq 表中插入记录时发生异常：{0}",
                                error.Message);
                        WriteLog.Instance.Write(errText, strProcedureName);
                        WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    }
                }
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText =
                    string.Format(
                        "在向 IRAPDPA..dpa_Log_MaterialReq 表中插入记录时发生异常：{0}",
                        error.Message);
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void usp_PokaYoke_MaterialReq(
            int communityID,
            long importID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ImportID", DbType.Int64, importID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(
                    "执行存储过程 IRAPDPA..usp_PokaYoke_MaterialReq，参数：" +
                    $"CommunityID={communityID}|ImportID={importID}|SysLogID={sysLogID}",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn =
                    new IRAPSQLConnection(
                        TParams.Instance.DBConnectionStr))
                {
                    IRAPError error = conn.CallProc("IRAPDPA..usp_PokaYoke_MaterialReq", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPDPA..usp_PokaYoke_MaterialReq 时发生异常：{0}", error.Message);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void usp_ImportMaterialReq(
            int communityID,
            long importID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ImportID", DbType.Int64, importID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(
                    "执行存储过程 IRAPDPA..usp_ImportMaterialReq，参数：" +
                    $"CommunityID={communityID}|ImportID={importID}|SysLogID={sysLogID}",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn =
                    new IRAPSQLConnection(
                        TParams.Instance.DBConnectionStr))
                {
                    IRAPError error = conn.CallProc("IRAPDPA..usp_ImportMaterialReq", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPDPA..usp_ImportMaterialReq 时发生异常：{0}", error.Message);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public List<Tdpa_Log_MaterialReq> mfn_GetList_MaterialReq(
            int communityID,
            long importID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<Tdpa_Log_MaterialReq> datas = new List<Tdpa_Log_MaterialReq>();

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn =
                        new IRAPSQLConnection(
                            TParams.Instance.DBConnectionStr))
                    {
                        long partitioningKey = communityID * 10000;
                        string strSQL =
                            "SELECT * " +
                            "FROM IRAPDPA..dpa_Log_MaterialReq " +
                            $"WHERE PartitioningKey={partitioningKey} AND " +
                            $"ImportID={importID}";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<Tdpa_Log_MaterialReq> lstDatas =
                            conn.List<Tdpa_Log_MaterialReq>(
                                $"PartitioningKey={partitioningKey} AND " +
                                $"ImportID={importID}",
                                "IRAPDPA..dpa_Log_MaterialReq");
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("执行 SQL 时发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return datas;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
