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
                        "ProductLeaf={1}|WorkUnitLeaf={2}|PackagingSpecNo={3}|" +
                        "SysLogID={4}",
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
                            "@CommunityID, @ProductLeaf, @WorkUnitLeaf, " +
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
                        "调用函数 IRAPMES.dbo.ufn_GetNextPackageSN，参数：" +
                        "CommunityID={0}|CorrelationID={1}|Ordinal={2}|" +
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
        public IRAPJsonResult usp_SaveFact_Packaging(
            int communityID,
            long transactNo,
            long factID,
            int productLeaf,
            int workUnitLeaf,
            int packagingSpecNo,
            string wipPattern,
            int layerNumOfPallet,
            int cartonNumOfLayer,
            int layerNumOfCarton,
            int rowNumOfCarton,
            int colNumOfCarton,
            int layerNumOfBox,
            int rowNumOfBox,
            int colNumOfBox,
            string boxSerialNumber,
            string cartonSerialNumber,
            string layerSerialNumber,
            string palletSerialNumber,
            long sysLogID,
            out int errCode,
            out string errText
            )
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
                paramList.Clear();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@PackagingSpecNo", DbType.Byte, packagingSpecNo));
                paramList.Add(new IRAPProcParameter("@WIPPattern", DbType.String, wipPattern));
                paramList.Add(new IRAPProcParameter("@LayerNumOfPallet", DbType.Byte, layerNumOfPallet));
                paramList.Add(new IRAPProcParameter("@CartonNumOfLayer", DbType.Byte, cartonNumOfLayer));
                paramList.Add(new IRAPProcParameter("@LayerNumOfCarton", DbType.Byte, layerNumOfCarton));
                paramList.Add(new IRAPProcParameter("@RowNumOfCarton", DbType.Byte, rowNumOfCarton));
                paramList.Add(new IRAPProcParameter("@ColNumOfCarton", DbType.Byte, colNumOfCarton));
                paramList.Add(new IRAPProcParameter("@LayerNumOfBox", DbType.Byte, layerNumOfBox));
                paramList.Add(new IRAPProcParameter("@RowNumOfBox", DbType.Byte, rowNumOfBox));
                paramList.Add(new IRAPProcParameter("@ColNumOfBox", DbType.Byte, colNumOfBox));
                paramList.Add(new IRAPProcParameter("@BoxSerialNumber", DbType.String, boxSerialNumber));
                paramList.Add(new IRAPProcParameter("@CartonSerialNumber", DbType.String, cartonSerialNumber));
                paramList.Add(new IRAPProcParameter("@LayerSerialNumber", DbType.String, layerSerialNumber));
                paramList.Add(new IRAPProcParameter("@PalletSerialNumber", DbType.String, palletSerialNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@OutputStr", DbType.Xml,ParameterDirection.Output,2000));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                       "调用 IRAPMES..usp_SaveFact_Packaging，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                        "ProductLeaf={3}|WorkUnitLeaf={4}|PackagingSpecNo={5}|" +
                        "WIPPattern={6}|LayerNumOfPallet={7}|CartonNumOfLayer={8}|" +
                        "LayerNumOfCarton={9}|RowNumOfCarton={10}|ColNumOfCarton={11}|" +
                        "LayerNumOfBox={12}|RowNumOfBox={13}|ColNumOfBox={14}|" +
                        "BoxSerialNumber={15}|CartonSerialNumber={16}|LayerSerialNumber={17}|" +
                        "PalletSerialNumber={18}|SysLogID={19}",
                        communityID,
                        transactNo,
                        factID,
                        productLeaf,
                        workUnitLeaf,
                        packagingSpecNo,
                        wipPattern,
                        layerNumOfPallet,
                        cartonNumOfLayer,
                        layerNumOfCarton,
                        rowNumOfCarton,
                        colNumOfCarton,
                        layerNumOfBox,
                        rowNumOfBox,
                        colNumOfBox,
                        boxSerialNumber,
                        cartonSerialNumber,
                        layerSerialNumber,
                        palletSerialNumber,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error =
                        conn.CallProc("IRAPMES..usp_SaveFact_Packaging", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;
                        string  outputStr = paramList[20].Value.ToString();
                        return Json(outputStr);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPMES..usp_SaveFact_Packaging 过程发生异常：{0}",
                            error.Message);
                    return Json(
                        new IRAPError()
                        {
                            ErrCode = errCode,
                            ErrText = errText,
                        });
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public IRAPJsonResult ufn_GetLabelFMTStr(
           int communityID,
           int correlationID,
           int labelID,
           string serialNo,
           string pHStr1,
           string pHStr2,
           string pHStr3,
           string pHStr4,
           string pHStr5,
           string pHStr6,
           string pHStr7,
           string pHStr8,
           string pHStr9,
           string pHStr10,
           string pHStr11,
           string pHStr12,
           string pHStr13,
           string pHStr14,
           string pHStr15,
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
                List<LabelFMTStr> datas = new List<LabelFMTStr>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Clear();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@CorrelationID", DbType.Int32, correlationID));
                paramList.Add(new IRAPProcParameter("@LabelID", DbType.Int32, labelID));
                paramList.Add(new IRAPProcParameter("@SerialNo", DbType.String, serialNo));
                paramList.Add(new IRAPProcParameter("@PHStr1", DbType.String, pHStr1));
                paramList.Add(new IRAPProcParameter("@PHStr2", DbType.String, pHStr2));
                paramList.Add(new IRAPProcParameter("@PHStr3", DbType.String, pHStr3));
                paramList.Add(new IRAPProcParameter("@PHStr4", DbType.String, pHStr4));
                paramList.Add(new IRAPProcParameter("@PHStr5", DbType.String, pHStr5));
                paramList.Add(new IRAPProcParameter("@PHStr6", DbType.String, pHStr6));
                paramList.Add(new IRAPProcParameter("@PHStr7", DbType.String, pHStr7));
                paramList.Add(new IRAPProcParameter("@PHStr8", DbType.String, pHStr8));
                paramList.Add(new IRAPProcParameter("@PHStr9", DbType.String, pHStr9));
                paramList.Add(new IRAPProcParameter("@PHStr10", DbType.String, pHStr10));
                paramList.Add(new IRAPProcParameter("@PHStr11", DbType.String, pHStr11));
                paramList.Add(new IRAPProcParameter("@PHStr12", DbType.String, pHStr12));
                paramList.Add(new IRAPProcParameter("@PHStr13", DbType.String, pHStr13));
                paramList.Add(new IRAPProcParameter("@PHStr14", DbType.String, pHStr14));
                paramList.Add(new IRAPProcParameter("@PHStr15", DbType.String, pHStr15));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));

                //WriteLog.Instance.Write(
                //    string.Format(
                //        "调用函数 IRAPMES..ufn_GetFactList_Packaging，" +
                //        "参数：CommunityID={0}|TransactNo={1}|ProductLeaf={2}|" +
                //        "SysLogID={3}",
                //        communityID, transactNo, productLeaf, sysLogID),
                //    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetLabelFMTStr(" +
                            "@CommunityID, @CorrelationID, @LabelID, @SerialNo,@PHStr1,@PHStr2,@PHStr3,@PHStr4,@PHStr5,@PHStr6,@PHStr7,@PHStr8,@PHStr9,@PHStr10,@PHStr11,@PHStr12,@PHStr13,@PHStr14,@PHStr15,@SysLogID)";

                        IList<LabelFMTStr> lstDatas =
                            conn.CallTableFunc<LabelFMTStr>(strSQL, paramList);
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
    }
}
