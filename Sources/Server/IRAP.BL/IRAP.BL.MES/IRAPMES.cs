using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAPORM;
using IRAPShared;
using IRAP.Entity.MES;

namespace IRAP.BL.MES
{
    public class IRAPMES : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPMES()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        public IRAPJsonResult ufn_GetInfo_WIPBarcode(
            string barcode, 
            int processLeaf, 
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
                WIPBarCodeInfo data = new WIPBarCodeInfo();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@Barcode", DbType.String, barcode));
                paramList.Add(new IRAPProcParameter("@ProcessLeaf", DbType.Int32, processLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetInfo_WIPBarcode，" +
                        "参数：Barcode={0}|ProcessLeaf={1}|WorkUnitLeaf={2}",
                        barcode, processLeaf, workUnitLeaf),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * FROM IRAPMES..ufn_GetInfo_WIPBarcode(" +
                            "@Barcode, @ProcessLeaf, @WorkUnitLeaf)";

                        IList<WIPBarCodeInfo> lstDatas = conn.CallTableFunc<WIPBarCodeInfo>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        }
                        else
                        {
                            errCode = 99001;
                            errText = string.Format("没有[{0}]的在制品信息", barcode);
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMES..ufn_GetInfo_WIPBarcode 函数发生异常：{0}", error.Message);
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

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="productLeaf">产品叶标识(T102LeafID)</param>
        /// <param name="workUnitLeaf">工位叶标识(T107LeafID)</param>
        public IRAPJsonResult ufn_GetKanban_RepairModes(
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
                List<RepairMode> datas = new List<RepairMode>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetKanban_RepairModes，" +
                        "参数：CommunityID={0}|SysLogID={1}|ProductLeaf={2}|WorkUnitLeaf={3}",
                        communityID, sysLogID, productLeaf, workUnitLeaf),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetKanban_RepairModes(" +
                            "@CommunityID, @SysLogID, @ProductLeaf, @WorkUnitLeaf)" +
                            "ORDER BY Ordinal";

                        IList<RepairMode> lstDatas = 
                            conn.CallTableFunc<RepairMode>(strSQL, paramList);
                        datas = lstDatas.ToList<RepairMode>();
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
                            "调用 IRAPMES..ufn_GetKanban_RepairModes 函数发生异常：{0}", 
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

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="productLeaf">产品叶标识(T102LeafID)</param>
        /// <param name="workUnitLeaf">工位叶标识(T107LeafID)</param>
        public IRAPJsonResult ufn_GetKanban_Symbols_Inspecting(
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
                List<SymbolInspecting> datas = new List<SymbolInspecting>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetKanban_Symbols_Inspecting，" +
                        "参数：CommunityID={0}|SysLogID={1}|ProductLeaf={2}|WorkUnitLeaf={3}",
                        communityID, sysLogID, productLeaf, workUnitLeaf),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetKanban_Symbols_Inspecting(" +
                            "@CommunityID, @SysLogID, @ProductLeaf, @WorkUnitLeaf)" +
                            "ORDER BY Ordinal";

                        IList<SymbolInspecting> lstDatas = 
                            conn.CallTableFunc<SymbolInspecting>(strSQL, paramList);
                        datas = lstDatas.ToList<SymbolInspecting>();
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
                            "调用 IRAPMES..ufn_GetKanban_Symbols_Inspecting 函数发生异常：{0}", 
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