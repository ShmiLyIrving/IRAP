using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using System.Data;

using IRAP.Global;
using IRAP.Server.Global;
using IRAP.Entities.UTS;
using IRAPShared;
using IRAPORM;
using IRAPDAL;

namespace IRAP.BL.UTS
{
    public class IRAPUTS : IRAPBLLBase
    {
        private static string className = 
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPUTS()
        {
            WriteLog.Instance.WriteLogFileName = 
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 申请序列号
        /// ⒈ 申请预定义序列的一个或多个序列号；
        /// ⒉ 如果序列是交易号的，自动写交易日志。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sequenceCode">序列代码</param>
        /// <param name="count">申请序列值个数</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="opNode">业务操作节点列表</param>
        /// <param name="voucherNo">业务凭证号</param>
        /// <returns>申请到的第一个序列值[long]</returns>
        public IRAPJsonResult ssp_GetSequenceNo(
            int communityID, 
            string sequenceCode, 
            int count, 
            long sysLogID, 
            string opNode, 
            string voucherNo, 
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
                Hashtable rlt = new Hashtable();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SequenceCode", DbType.String, sequenceCode));
                paramList.Add(new IRAPProcParameter("@Count", DbType.Int32, count));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@OpNode", DbType.String, opNode));
                paramList.Add(new IRAPProcParameter("@VoucherNo", DbType.String, voucherNo));
                paramList.Add(new IRAPProcParameter("@SequenceNo", DbType.Int64, ParameterDirection.Output, 8));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAP..ssp_GetSequenceNo，输入参数：" +
                        "CommunityID={0}|SequenceCode={1}|Count={2}|SysLogID={3}"+
                        "OpNode={4}|VoucherNo={5}",
                        communityID, sequenceCode, count, sysLogID, opNode, voucherNo),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_GetSequenceNo", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        rlt = DBUtils.DBParamsToHashtable(paramList);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..ssp_GetSequenceNo 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 保存万能表单采集的数据
        /// </summary>
        public IRAPJsonResult ssp_OLTP_UDFForm(
            int communityID, 
            long transactNo, 
            long factID, 
            int ctrlParameter1, 
            int ctrlParameter2, 
            int ctrlParameter3, 
            long sysLogID, 
            string strParameter1, 
            string strParameter2, 
            string strParameter3, 
            string strParameter4, 
            string strParameter5, 
            string strParameter6, 
            string strParameter7, 
            string strParameter8, 
            string errMessage,
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
                Hashtable rlt = new Hashtable();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@CtrlParameter1", DbType.Int32, ctrlParameter1));
                paramList.Add(new IRAPProcParameter("@CtrlParameter2", DbType.Int32, ctrlParameter2));
                paramList.Add(new IRAPProcParameter("@CtrlParameter3", DbType.Int32, ctrlParameter3));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@OutputStr", DbType.String, ParameterDirection.Output, 2147483647));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText", 
                        DbType.String, 
                        ParameterDirection.Output, 
                        400)
                    {
                        Value = errMessage,
                    });
                paramList.Add(new IRAPProcParameter("@StrParameter1", DbType.String, strParameter1));
                paramList.Add(new IRAPProcParameter("@StrParameter2", DbType.String, strParameter2));
                paramList.Add(new IRAPProcParameter("@StrParameter3", DbType.String, strParameter3));
                paramList.Add(new IRAPProcParameter("@StrParameter4", DbType.String, strParameter4));
                paramList.Add(new IRAPProcParameter("@StrParameter5", DbType.String, strParameter5));
                paramList.Add(new IRAPProcParameter("@StrParameter6", DbType.String, strParameter6));
                paramList.Add(new IRAPProcParameter("@StrParameter7", DbType.String, strParameter7));
                paramList.Add(new IRAPProcParameter("@StrParameter8", DbType.String, strParameter8));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAP..ssp_OLTP_UDFForm，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|FactID={2}|CtrlParameter1={3}|" +
                        "CtrlParameter2={4}|CtrlParameter3={5}|SysLogID={6}|StrParameter1={7}|" +
                        "StrParameter2={8}|StrParameter3={9}|StrParameter4={10}|StrParameter5={11}|" +
                        "StrParameter6={12}|StrParameter7={13}|StrParameter8={14}|ErrText={15}",
                        communityID, transactNo, factID, ctrlParameter1, ctrlParameter2,
                        ctrlParameter3, sysLogID, strParameter1, strParameter2, strParameter3,
                        strParameter4, strParameter5, strParameter6, strParameter7, strParameter8,
                        errMessage),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_OLTP_UDFForm", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        rlt = DBUtils.DBParamsToHashtable(paramList);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..ssp_OLTP_UDFForm 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 万能表单统一防错入口
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="ctrlParameter1">个性功能号</param>
        /// <param name="ctrlParameter2">选项一标识</param>
        /// <param name="ctrlParameter3">选项二标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="strParameter1">字串参数1</param>
        /// <param name="strParameter2">字串参数2</param>
        /// <param name="strParameter3">字串参数3</param>
        /// <param name="strParameter4">字串参数4</param>
        /// <param name="strParameter5">字串参数5</param>
        /// <param name="strParameter6">字串参数6</param>
        /// <param name="strParameter7">字串参数7</param>
        /// <param name="strParameter8">字串参数8</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns>OutputStr</returns>
        public IRAPJsonResult ssp_PokaYoke_UDFForm(
            int communityID,
            int ctrlParameter1,
            int ctrlParameter2,
            int ctrlParameter3,
            long sysLogID,
            string strParameter1,
            string strParameter2,
            string strParameter3,
            string strParameter4,
            string strParameter5,
            string strParameter6,
            string strParameter7,
            string strParameter8,
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
                Hashtable rlt = new Hashtable();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@CtrlParameter1", DbType.Int32, ctrlParameter1));
                paramList.Add(
                    new IRAPProcParameter(
                        "@CtrlParameter2",
                        DbType.Int32,
                        ParameterDirection.InputOutput,
                        4)
                    {
                        Value = ctrlParameter2,
                    });
                paramList.Add(
                    new IRAPProcParameter(
                        "@CtrlParameter3",
                        DbType.Int32,
                        ParameterDirection.InputOutput,
                        4)
                    {
                        Value = ctrlParameter3,
                    });
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@OutputStr", DbType.String, ParameterDirection.Output, 2147483647));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                paramList.Add(
                    new IRAPProcParameter(
                        "@StrParameter1",
                        DbType.String,
                        ParameterDirection.InputOutput,
                        50)
                    {
                        Value = strParameter1,
                    });
                paramList.Add(
                    new IRAPProcParameter(
                        "@StrParameter2",
                        DbType.String,
                        ParameterDirection.InputOutput,
                        50)
                    {
                        Value = strParameter2,
                    });
                paramList.Add(
                    new IRAPProcParameter(
                        "@StrParameter3",
                        DbType.String,
                        ParameterDirection.InputOutput,
                        50)
                    {
                        Value = strParameter3,
                    });
                paramList.Add(
                    new IRAPProcParameter(
                        "@StrParameter4",
                        DbType.String,
                        ParameterDirection.InputOutput,
                        50)
                    {
                        Value = strParameter4,
                    });
                paramList.Add(
                    new IRAPProcParameter(
                        "@StrParameter5",
                        DbType.String,
                        ParameterDirection.InputOutput,
                        50)
                    {
                        Value = strParameter5,
                    });
                paramList.Add(
                    new IRAPProcParameter(
                        "@StrParameter6",
                        DbType.String,
                        ParameterDirection.InputOutput,
                        50)
                    {
                        Value = strParameter6,
                    });
                paramList.Add(
                    new IRAPProcParameter(
                        "@StrParameter7",
                        DbType.String,
                        ParameterDirection.InputOutput,
                        50)
                    {
                        Value = strParameter7,
                    });
                paramList.Add(
                    new IRAPProcParameter(
                        "@StrParameter8",
                        DbType.String,
                        ParameterDirection.InputOutput,
                        50)
                    {
                        Value = strParameter8,
                    });
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAP..ssp_PokaYoke_UDFForm，输入参数：" +
                        "CommunityID={0}|CtrlParameter1={1}|CtrlParameter2={2}|" +
                        "CtrlParameter3={3}|SysLogID={4}|StrParameter1={5}|" +
                        "StrParameter2={6}|StrParameter3={7}|StrParameter4={8}|" +
                        "StrParameter5={9}|StrParameter6={10}|StrParameter7={11}|" +
                        "StrParameter8={12}",
                        communityID, ctrlParameter1, ctrlParameter2,
                        ctrlParameter3, sysLogID, strParameter1, strParameter2,
                        strParameter3, strParameter4, strParameter5, strParameter6, 
                        strParameter7, strParameter8),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_PokaYoke_UDFForm", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        rlt = DBUtils.DBParamsToHashtable(paramList);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = 
                        string.Format(
                            "调用 IRAP..ssp_PokaYoke_UDFForm 函数发生异常：{0}", 
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取业务操作类型清单
        /// </summary>
        public IRAPJsonResult sfn_OperTypes(
            int opID,
            int languageID,
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
                List<OperTypeInfo> datas = new List<OperTypeInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@OpID", DbType.Int32, opID));
                paramList.Add(new IRAPProcParameter("@LanguageID", DbType.Int32, languageID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_OperTypes，" +
                        "参数：OpID={0}|LanguageID={1}",
                        opID, languageID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_OperTypes(" +
                            "@OpID, @LanguageID) " +
                            "ORDER BY Ordinal";

                        IList<OperTypeInfo> lstDatas =
                            conn.CallTableFunc<OperTypeInfo>(strSQL, paramList);
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
                            "调用 IRAP..sfn_OperTypes 函数发生异常：{0}",
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

        public IRAPJsonResult msp_GetSequenceNo(
            int communityID,
            string sequenceCode,
            int count,
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
                WriteLog.Instance.Write(
                    string.Format(
                        "申请序列号，SequenceCode={0}|Count={1}",
                        sequenceCode,
                        count),
                    strProcedureName);
                long sequenceNo = 0;

                if (sequenceCode.ToUpper() == "TRANSACTNO")
                {
                    errCode = 999999;
                    errText = "当前功能不支持申请交易号！";
                }
                else
                {
                    try
                    {
                        sequenceNo =
                            IRAPDAL.UTS.Instance.msp_GetSequenceNo(
                                sequenceCode,
                                count);
                        errCode = 0;
                        errText =
                            string.Format(
                                "申请序列号成功：[{0}]",
                                sequenceNo);
                    }
                    catch (Exception error)
                    {
                        errCode = 999999;
                        errText =
                            string.Format(
                                "申请序列号失败：[{0}]",
                                error.Message);
                    }
                }

                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                return Json(sequenceNo);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 通用交易复核
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">待复核交易号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult ssp_CheckTransaction(
            int communityID,
            long transactNo,
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
                Hashtable rlt = new Hashtable();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAP..ssp_CheckTransaction，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|SysLogID={2}",
                        communityID, transactNo, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_CheckTransaction", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        rlt = DBUtils.DBParamsToHashtable(paramList);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..ssp_CheckTransaction 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 保存产品包装事实并防错
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">包装工位叶标识</param>
        /// <param name="packagingSpecNo">包装规格序号(C64R7.Ordinal)</param>
        /// <param name="wipPattern">产品主标识代码</param>
        /// <param name="layerNumOfPallet">铲板第几层</param>
        /// <param name="cartonNumOfLayer">当前层第几箱</param>
        /// <param name="layerNumOfCarton">箱内第几层内包装(盒）</param>
        /// <param name="rowNumOfCarton">箱内第几排内包装(盒)</param>
        /// <param name="colNumOfCarton">箱内第几列内包装(盒)</param>
        /// <param name="layerNumOfBox">盒内第几层产品</param>
        /// <param name="rowNumOfBox">盒内第几排产品</param>
        /// <param name="colNumOfBox">盒内第几列产品</param>
        /// <param name="boxSerialNumber">内包装序列号</param>
        /// <param name="cartonSerialNumber">箱包装序列号</param>
        /// <param name="layerSerialNumber">包装层层序列号</param>
        /// <param name="palletSerialNumber">铲板标签序列号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errTex"></param>
        /// <returns></returns>
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
                Hashtable rlt = new Hashtable();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@PackagingSpecNo", DbType.Int32, packagingSpecNo));
                paramList.Add(new IRAPProcParameter("@WIPPattern", DbType.String, wipPattern));
                paramList.Add(new IRAPProcParameter("@LayerNumOfPallet", DbType.Int32, layerNumOfPallet));
                paramList.Add(new IRAPProcParameter("@CartonNumOfLayer", DbType.Int32, cartonNumOfLayer));
                paramList.Add(new IRAPProcParameter("@LayerNumOfCarton", DbType.Int32, layerNumOfCarton));
                paramList.Add(new IRAPProcParameter("@RowNumOfCarton", DbType.Int32, rowNumOfCarton));
                paramList.Add(new IRAPProcParameter("@ColNumOfCarton", DbType.Int32, colNumOfCarton));
                paramList.Add(new IRAPProcParameter("@LayerNumOfBox", DbType.Int32, layerNumOfBox));
                paramList.Add(new IRAPProcParameter("@RowNumOfBox", DbType.Int32, rowNumOfBox));
                paramList.Add(new IRAPProcParameter("@ColNumOfBox", DbType.Int32, colNumOfBox));
                paramList.Add(new IRAPProcParameter("@BoxSerialNumber", DbType.String, boxSerialNumber));
                paramList.Add(new IRAPProcParameter("@CartonSerialNumber", DbType.String, cartonSerialNumber));
                paramList.Add(new IRAPProcParameter("@LayerSerialNumber", DbType.String, layerSerialNumber));
                paramList.Add(new IRAPProcParameter("@PalletSerialNumber", DbType.String, palletSerialNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAPMES..usp_SaveFact_Packaging，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                        "ProductLeaf={3}|WorkUnitLeaf={4}|PackagingSpecNo={5}|"+
                        "WIPPattern={6}|LayerNumOfPallet={7}|CartonNumOfLayer={8}|"+
                        "LayerNumOfCarton={9}|RowNumOfCarton={10}|ColNumOfCarton={11}|"+
                        "LayerNumOfBox={12}|RowNumOfBox={13}|ColNumOfBox={14}|"+
                        "BoxSerialNumber={15}|CartonSerialNumber={16}|LayerSerialNumber={17}|"+
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
                            conn.CallProc(
                                "IRAPMES..usp_SaveFact_Packaging", 
                                ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        rlt = DBUtils.DBParamsToHashtable(paramList);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = 
                        string.Format(
                            "调用 IRAPMES..usp_SaveFact_Packaging 函数发生异常：{0}", 
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
