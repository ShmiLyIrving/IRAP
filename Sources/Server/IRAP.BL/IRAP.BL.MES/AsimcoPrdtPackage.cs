using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections;

using IRAP.Global;
using IRAPShared;
using IRAPORM;
using IRAP.Entities;
using IRAP.Entities.Asimco;

namespace IRAP.BL.MES
{
    public class AsimcoPrdtPackage : IRAPBLLBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public AsimcoPrdtPackage()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取待打印的销售订单信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="soNumber">销售订单号（筛选条件，默认空白）</param>
        /// <param name="productNo">产品号（筛选条件，默认空白）</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_WaitPackageSO(
            int communityID,
            string soNumber,
            string productNo,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<WaitPackageSO> datas =
                    new List<WaitPackageSO>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SONumber", DbType.String, soNumber));
                paramList.Add(new IRAPProcParameter("@ProductNo", DbType.String, productNo));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_WaitPackageSO(" +
                            "@CommunityID, @SONumber, @ProductNo, @SysLogID) " +
                            "ORDER BY Ordinal";

                        string msg = $"{strSQL} 参数：";
                        for (int i = 0; i < paramList.Count; i++)
                        {
                            msg +=
                                $"{paramList[i].ParameterName}=" +
                                $"{paramList[i].Value.ToString()}|";
                        }
                        WriteLog.Instance.Write(msg, strProcedureName);

                        IList<WaitPackageSO> lstDatas =
                            conn.CallTableFunc<WaitPackageSO>(strSQL, paramList);
                        datas = lstDatas.ToList();

                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPMES..ufn_GetList_WaitPackageSO 函数发生异常：{0}",
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
        /// 获取待分单的包装生产线
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_PackageLine(
            int communityID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<WaitPackageSO> datas =
                    new List<WaitPackageSO>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_PackageLine(" +
                            "@CommunityID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        string msg = $"{strSQL} 参数：";
                        for (int i = 0; i < paramList.Count; i++)
                        {
                            msg +=
                                $"{paramList[i].ParameterName}=" +
                                $"{paramList[i].Value.ToString()}|";
                        }
                        WriteLog.Instance.Write(msg, strProcedureName);

                        IList<WaitPackageSO> lstDatas =
                            conn.CallTableFunc<WaitPackageSO>(strSQL, paramList);
                        datas = lstDatas.ToList();

                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPMES..ufn_GetList_PackageLine 函数发生异常：{0}",
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
        /// 获取指定打印交易号的外箱清单列表
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="transactNo">打印交易号</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_Carton(
            int communityID,
            long transactNo,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<Carton> datas =
                    new List<Carton>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_Carton(" +
                            "@CommunityID, @TransactNo, @SysLogID) " +
                            "ORDER BY Ordinal";

                        string msg = $"{strSQL} 参数：";
                        for (int i = 0; i < paramList.Count; i++)
                        {
                            msg +=
                                $"{paramList[i].ParameterName}=" +
                                $"{paramList[i].Value.ToString()}|";
                        }
                        WriteLog.Instance.Write(msg, strProcedureName);

                        IList<Carton> lstDatas =
                            conn.CallTableFunc<Carton>(strSQL, paramList);
                        datas = lstDatas.ToList();

                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPMES..ufn_GetList_Carton 函数发生异常：{0}",
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
        /// 获取指定外箱标签的内箱清单列表
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="cartonNumber">外箱序号</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_BoxOfCarton(
            int communityID,
            string cartonNumber,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<BoxOfCarton> datas =
                    new List<BoxOfCarton>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@CartonNumber", DbType.String, cartonNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_BoxOfCarton(" +
                            "@CommunityID, @CartonNumber, @SysLogID) " +
                            "ORDER BY Ordinal";

                        string msg = $"{strSQL} 参数：";
                        for (int i = 0; i < paramList.Count; i++)
                        {
                            msg +=
                                $"{paramList[i].ParameterName}=" +
                                $"{paramList[i].Value.ToString()}|";
                        }
                        WriteLog.Instance.Write(msg, strProcedureName);

                        IList<BoxOfCarton> lstDatas =
                            conn.CallTableFunc<BoxOfCarton>(strSQL, paramList);
                        datas = lstDatas.ToList();

                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPMES..ufn_GetList_BoxOfCarton 函数发生异常：{0}",
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
        /// 获取待确认标签清单列表
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_WaitConfirmPrint(
            int communityID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<WaitConfirmPrint> datas =
                    new List<WaitConfirmPrint>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_WaitConfirmPrint(" +
                            "@CommunityID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        string msg = $"{strSQL} 参数：";
                        for (int i = 0; i < paramList.Count; i++)
                        {
                            msg +=
                                $"{paramList[i].ParameterName}=" +
                                $"{paramList[i].Value.ToString()}|";
                        }
                        WriteLog.Instance.Write(msg, strProcedureName);

                        IList<WaitConfirmPrint> lstDatas =
                            conn.CallTableFunc<WaitConfirmPrint>(strSQL, paramList);
                        datas = lstDatas.ToList();

                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPMES..ufn_GetList_WaitConfirmPrint 函数发生异常：{0}",
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
        /// 根据订单和产线，预打印标签供后面成套检验
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="moNumber">销售订单号</param>
        /// <param name="moLineNo">销售订单行号</param>
        /// <param name="numberOfBox">内箱产品数量</param>
        /// <param name="cartonNumber">外箱数</param>
        /// <param name="boxNumber">内箱数</param>
        /// <param name="t105LeafID">客户叶标识</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns>TransactNo(打印交易号)</returns>
        public IRAPJsonResult usp_SaveFact_PackagePrint(
            int communityID,
            string moNumber,
            int moLineNo,
            long numberOfBox,
            long cartonNumber,
            long boxNumber,
            int t105LeafID,
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
                paramList.Add(new IRAPProcParameter("@MONumber", DbType.String, moNumber));
                paramList.Add(new IRAPProcParameter("@MOLineNo", DbType.Int32, moLineNo));
                paramList.Add(new IRAPProcParameter("@NumberOfBox", DbType.Int64, numberOfBox));
                paramList.Add(new IRAPProcParameter("@CartonNumber", DbType.Int64, cartonNumber));
                paramList.Add(new IRAPProcParameter("@BoxNumber", DbType.Int64, boxNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.String, ParameterDirection.InputOutput, 50));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    "执行存储过程 IRAPMES..usp_SaveFact_PackagePrint，" +
                    $"参数：CommunityID={communityID}|MONumber={moNumber}|" +
                    $"MOLineNo={moLineNo}|NumberOfBox={numberOfBox}|" +
                    $"CartonNumber={cartonNumber}|BoxNumber={boxNumber}|" +
                    $"SysLogID={sysLogID}",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_SaveFact_PackagePrint", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;

                    Hashtable rtnParams = new Hashtable();
                    if (errCode == 0)
                    {
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput ||
                                param.Direction == ParameterDirection.Output)
                            {
                                if (param.DbType == DbType.Int32 && param.Value == DBNull.Value)
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                                else
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                            }
                        }

                        string text = "";
                        foreach (string key in rtnParams.Keys)
                        {
                            text += $"{key}={rtnParams[key]}|";
                        }
                        WriteLog.Instance.Write($"返回参数：{text}", strProcedureName);
                    }
                    else
                    {
                        WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
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
                        "调用 IRAPMES..usp_SaveFact_PackagePrint 过程发生异常：{0}",
                        error.Message);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 单个打印
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="boxNumber">单箱条码</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult usp_RePrintBoxNumber(
            int communityID,
            string boxNumber,
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
                paramList.Add(new IRAPProcParameter("@BoxNumber", DbType.Int64, boxNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                string msg = "执行存储过程 IRAPMES..usp_RePrintBoxNumber，参数：";
                for (int i = 0; i < paramList.Count; i++)
                {
                    msg +=
                        $"{paramList[i].ParameterName}=" +
                        $"{paramList[i].Value.ToString()}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    DataSet ds =
                        conn.CallProcEx("IRAPMES..usp_RePrintBoxNumber", ref paramList);

                    List<RePrintBoxNumber> datas = new List<RePrintBoxNumber>();
                    if (ds.Tables.Count > 0)
                    {
                        datas = Helper.ToList<RePrintBoxNumber>(ds.Tables[0]);
                    }

                    Hashtable rtnParams = new Hashtable();
                    foreach (IRAPProcParameter param in paramList)
                    {
                        if (param.Direction == ParameterDirection.InputOutput ||
                            param.Direction == ParameterDirection.Output)
                        {
                            if (param.DbType == DbType.Int32 && param.Value == DBNull.Value)
                                rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                            else
                                rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                        }
                    }
                    errCode = (int)rtnParams["ErrCode"];
                    errText = rtnParams["ErrText"].ToString();

                    return Json(datas);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText =
                    string.Format(
                        "调用 IRAPMES..usp_RePrintBoxNumber 过程发生异常：{0}",
                        error.Message);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                return Json(new List<RePrintBoxNumber>());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 保存外箱标签重打
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="moNumber">订单号</param>
        /// <param name="moLineNo">订单行号</param>
        /// <param name="cartonNumber">外箱号（默认空白）</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult usp_RePrintCartonNumber(
            int communityID,
            string moNumber,
            int moLineNo,
            string cartonNumber,
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
                paramList.Add(new IRAPProcParameter("@MONumber", DbType.String, moNumber));
                paramList.Add(new IRAPProcParameter("@MOLineNo", DbType.Int32, moLineNo));
                paramList.Add(new IRAPProcParameter("@CartonNumber", DbType.String, cartonNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                string msg = "执行存储过程 IRAPMES..usp_RePrintCartonNumber，参数：";
                for (int i = 0; i < paramList.Count; i++)
                {
                    msg +=
                        $"{paramList[i].ParameterName}=" +
                        $"{paramList[i].Value.ToString()}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    DataSet ds =
                        conn.CallProcEx("IRAPMES..usp_RePrintCartonNumber", ref paramList);

                    List<RePrintCartonNumber> datas = new List<RePrintCartonNumber>();
                    if (ds.Tables.Count > 0)
                    {
                        datas = Helper.ToList<RePrintCartonNumber>(ds.Tables[0]);
                    }

                    Hashtable rtnParams = new Hashtable();
                    foreach (IRAPProcParameter param in paramList)
                    {
                        if (param.Direction == ParameterDirection.InputOutput ||
                            param.Direction == ParameterDirection.Output)
                        {
                            if (param.DbType == DbType.Int32 && param.Value == DBNull.Value)
                                rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                            else
                                rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                        }
                    }
                    errCode = (int)rtnParams["ErrCode"];
                    errText = rtnParams["ErrText"].ToString();

                    return Json(datas);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText =
                    string.Format(
                        "调用 IRAPMES..usp_RePrintCartonNumber 过程发生异常：{0}",
                        error.Message);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                return Json(new List<RePrintCartonNumber>());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 发起重打申请
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="parmXML">发起重打申请</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult usp_RequestReprint(
            int communityID,
            string parmXML,
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
                paramList.Add(new IRAPProcParameter("@ParmXML", DbType.Xml, parmXML));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                string msg = "执行存储过程 IRAPMES..usp_RequestReprint，参数：";
                for (int i = 0; i < paramList.Count; i++)
                {
                    msg +=
                        $"{paramList[i].ParameterName}=" +
                        $"{paramList[i].Value.ToString()}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_RequestReprint", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;

                    Hashtable rtnParams = new Hashtable();
                    if (errCode == 0)
                    {
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput ||
                                param.Direction == ParameterDirection.Output)
                            {
                                if (param.DbType == DbType.Int32 && param.Value == DBNull.Value)
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                                else
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                            }
                        }

                        string text = "";
                        foreach (string key in rtnParams.Keys)
                        {
                            text += $"{key}={rtnParams[key]}|";
                        }
                        WriteLog.Instance.Write($"返回参数：{text}", strProcedureName);
                    }
                    else
                    {
                        WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
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
                        "调用 IRAPMES..usp_RequestReprint 过程发生异常：{0}",
                        error.Message);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 保存打印确认完成信息
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="parmXML"></param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult usp_SaveFact_PrintConfirm(
            int communityID,
            string parmXML,
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
                paramList.Add(new IRAPProcParameter("@ParmXML", DbType.Xml, parmXML));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                string msg = "执行存储过程 IRAPMES..usp_SaveFact_PrintConfirm，参数：";
                for (int i = 0; i < paramList.Count; i++)
                {
                    msg +=
                        $"{paramList[i].ParameterName}=" +
                        $"{paramList[i].Value.ToString()}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_SaveFact_PrintConfirm", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;

                    Hashtable rtnParams = new Hashtable();
                    if (errCode == 0)
                    {
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput ||
                                param.Direction == ParameterDirection.Output)
                            {
                                if (param.DbType == DbType.Int32 && param.Value == DBNull.Value)
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                                else
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                            }
                        }

                        string text = "";
                        foreach (string key in rtnParams.Keys)
                        {
                            text += $"{key}={rtnParams[key]}|";
                        }
                        WriteLog.Instance.Write($"返回参数：{text}", strProcedureName);
                    }
                    else
                    {
                        WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
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
                        "调用 IRAPMES..usp_SaveFact_PrintConfirm 过程发生异常：{0}",
                        error.Message);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 输入外包装数更新内包装数量
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="moNumber">订单号</param>
        /// <param name="moLineNo">订单行号</param>
        /// <param name="cartonNumber">外箱数量</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult usp_PokaYoke_Pakcage(
            int communityID,
            string moNumber,
            int moLineNo,
            int cartonNumber,
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
                paramList.Add(new IRAPProcParameter("@MONumber", DbType.String, moNumber));
                paramList.Add(new IRAPProcParameter("@MOLineNo", DbType.Int32, moLineNo));
                paramList.Add(new IRAPProcParameter("@CartonNumber", DbType.Int32, cartonNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                string msg = "执行存储过程 IRAPMES..usp_PokaYoke_Pakcage，参数：";
                for (int i = 0; i < paramList.Count; i++)
                {
                    msg +=
                        $"{paramList[i].ParameterName}=" +
                        $"{paramList[i].Value.ToString()}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_PokaYoke_Pakcage", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;

                    Hashtable rtnParams = new Hashtable();
                    if (errCode == 0)
                    {
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput ||
                                param.Direction == ParameterDirection.Output)
                            {
                                if (param.DbType == DbType.Int32 && param.Value == DBNull.Value)
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                                else
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                            }
                        }

                        string text = "";
                        foreach (string key in rtnParams.Keys)
                        {
                            text += $"{key}={rtnParams[key]}|";
                        }
                        WriteLog.Instance.Write($"返回参数：{text}", strProcedureName);
                    }
                    else
                    {
                        WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
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
                        "调用 IRAPMES..usp_PokaYoke_Pakcage 过程发生异常：{0}",
                        error.Message);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
