using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

using IRAP.Global;
using IRAP.Entities.MES;
using IRAPShared;
using IRAPORM;

namespace IRAP.BL.MES
{
    public class ProductPackage : IRAPBLLBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public ProductPackage()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        public IRAPJsonResult ufn_GetKanban_PackageTypes(
            int communityID,
            long sysLogID,
            int productLeaf,
            int workUnitLeaf,
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
                List<PackageType> datas = new List<PackageType>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetKanban_PackageTypes，" +
                        "参数：CommunityID={0}|SysLogID={1}|ProductLeaf={2}|" +
                        "WorkUnitLeaf={3}",
                        communityID, sysLogID, productLeaf, workUnitLeaf),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetKanban_PackageTypes(" +
                            "@CommunityID, @SysLogID, @ProductLeaf, @WorkUnitLeaf) " +
                            "ORDER BY Ordinal";

                        IList<PackageType> lstDatas =
                            conn.CallTableFunc<PackageType>(strSQL, paramList);
                        datas = lstDatas.ToList();
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
                            "调用 IRAPMES..ufn_GetKanban_PackageTypes 函数发生异常：{0}",
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
        /// 获取未完成包装信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="packagingSpecNo">包装规格序号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetInfo_UncompletedPackage(
            int communityID,
            int productLeaf,
            int workUnitLeaf,
            int packagingSpecNo,
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
                UncompletedPackage data = new UncompletedPackage();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@PackagingSpecNo", DbType.Int32, packagingSpecNo));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetInfo_UncompletedPackage，参数：CommunityID={0}|" +
                        "ProductLeaf={1}|WorkUnitLeaf={2}|PackagingSpecNo={4}|" +
                        "SysLogID={5}",
                        communityID, productLeaf, workUnitLeaf, packagingSpecNo,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetInfo_UncompletedPackage(" +
                            "@CommunityID, @ProductLeaf, @WorkUnitLeaf, "+
                            "@PackagingSpecNo, @SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<UncompletedPackage> lstDatas =
                            conn.CallTableFunc<UncompletedPackage>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = "调用成功！";
                        }
                        else
                        {
                            errCode = 99001;
                            errText = string.Format("在包装规格序号[{0}]在系统中不存在", packagingSpecNo);
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPMES..ufn_GetInfo_UncompletedPackage 函数发生异常：{0}",
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(data);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取指定包装交易号的业务事实明细
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">包装交易号</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetFactList_Packaging(
            int communityID,
            long transactNo,
            int productLeaf,
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
                List<FactPackaging> datas = new List<FactPackaging>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetFactList_Packaging，" +
                        "参数：CommunityID={0}|TransactNo={1}|ProductLeaf={2}|" +
                        "SysLogID={3}",
                        communityID, transactNo, productLeaf, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetFactList_Packaging(" +
                            "@CommunityID, @TransactNo, @ProductLeaf, @SysLogID)";

                        IList<FactPackaging> lstDatas =
                            conn.CallTableFunc<FactPackaging>(strSQL, paramList);
                        datas = lstDatas.ToList();
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
                            "调用 IRAPMES..ufn_GetFactList_Packaging 函数发生异常：{0}",
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
        /// 获取包装工位需要打印的标识串
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="correlationID">C64 关联号</param>
        /// <param name="ordinal">C64 包装行集序号</param>
        /// <param name="labelType">标签类型（3种）</param>
        /// <param name="nowTime">当前事件</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetNextPackageSN(
            int communityID,
            int correlationID,
            int ordinal,
            string labelType,
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
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@CorrelationID", DbType.Int32, correlationID));
                paramList.Add(new IRAPProcParameter("@Ordinal", DbType.Int32, ordinal));
                paramList.Add(new IRAPProcParameter("@LabelType", DbType.String, labelType));
                paramList.Add(new IRAPProcParameter("@NowTime", DbType.DateTime, nowTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES.dbo.ufn_GetNextPackageSN，参数："+
                        "CommunityID={0}|CorrelationID={1}|Ordinal={2}|"+
                        "LabelType={3}|NowTime={4}|SysLogID={5}",
                        communityID,
                        correlationID,
                        ordinal,
                        labelType,
                        nowTime,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string rlt = 
                            (string)conn.CallScalarFunc(
                                "IRAPMES.dbo.ufn_GetNextPackageSN", 
                                paramList);
                        errCode = 0;
                        errText = "调用成功！";
                        WriteLog.Instance.Write(errText, strProcedureName);
                        return Json(rlt);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = 
                        string.Format(
                            "调用 IRAPMES.dbo.ufn_GetNextPackageSN 函数发生异常：{0}", 
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    return Json("");
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
