using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAPShared;
using IRAPORM;
using IRAP.Entity.FVS;

namespace IRAP.BL.FVS
{
    public class Kanbans : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public Kanbans()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        public IRAPJsonResult ufn_GetKanban_AndonEquipRepairCall(
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
                List<AndonEquipRepairEvent> datas = new List<AndonEquipRepairEvent>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 ufn_GetKanban_AndonEquipRepairCall，" +
                        "参数：SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM ufn_GetKanban_AndonEquipRepairCall(" +
                            "@SysLogID) ORDER BY Ordinal";

                        IList<AndonEquipRepairEvent> lstDatas = conn.CallTableFunc<AndonEquipRepairEvent>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonEquipRepairEvent>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 ufn_GetKanban_AndonEquipRepairCall 函数发生异常：{0}", error.Message);
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

        public IRAPJsonResult ufn_GetKanban_AndonMaterialCall(
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
                List<AndonMaterialEvent> datas = new List<AndonMaterialEvent>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 ufn_GetKanban_AndonMaterialCall，" +
                        "参数：SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM ufn_GetKanban_AndonMaterialCall(" +
                            "@SysLogID) ORDER BY Ordinal";

                        IList<AndonMaterialEvent> lstDatas = conn.CallTableFunc<AndonMaterialEvent>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonMaterialEvent>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 ufn_GetKanban_AndonMaterialCall 函数发生异常：{0}", error.Message);
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

        public IRAPJsonResult ufn_GetKanban_AndonSupportCall(
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
                List<AndonSupportCallEvent> datas = new List<AndonSupportCallEvent>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 ufn_GetKanban_AndonSupportCall，" +
                        "参数：SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM ufn_GetKanban_AndonSupportCall(" +
                            "@SysLogID) ORDER BY Ordinal";

                        IList<AndonSupportCallEvent> lstDatas = conn.CallTableFunc<AndonSupportCallEvent>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonSupportCallEvent>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 ufn_GetKanban_AndonSupportCall 函数发生异常：{0}", error.Message);
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

        public IRAPJsonResult ufn_GetKanban_AndonFailuresCall(
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
                List<AndonFailureCallEvent> datas = new List<AndonFailureCallEvent>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 ufn_GetKanban_AndonFailuresCall，" +
                        "参数：SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM ufn_GetKanban_AndonFailuresCall(" +
                            "@SysLogID) ORDER BY Ordinal";

                        IList<AndonFailureCallEvent> lstDatas = conn.CallTableFunc<AndonFailureCallEvent>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonFailureCallEvent>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 ufn_GetKanban_AndonFailuresCall 函数发生异常：{0}", error.Message);
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
        /// 生产异常监控看板：
        /// ⒈ 监控指定工厂结构范围(按产线目录树点击流)生产异常状况；
        /// ⒉ 可以产线或工作中心作为监控单元；
        /// ⒊ 支持六大类安灯事件类型。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t134ClickStream">工厂结构树点击流</param>
        /// <param name="resourceTreeID">资源树标识(134-产线；211-工作中心)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetKanban_ProductionSurveillance(
            int communityID,
            string t134ClickStream,
            int resourceTreeID,
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
                List<ProductionSurveillance> datas = new List<ProductionSurveillance>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T134ClickStream", DbType.String, t134ClickStream));
                paramList.Add(new IRAPProcParameter("@ResourceTreeID", DbType.Int32, resourceTreeID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetKanban_ProductionSurveillance，" +
                        "参数：CommunityID={0}|T134ClickStream={1}|ResourceTreeID={2}|" +
                        "SysLogID={3}",
                        communityID, t134ClickStream, resourceTreeID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetKanban_ProductionSurveillance(" +
                            "@CommunityID, @T134ClickStream, @ResourceTreeID, @SysLogID)" +
                            "ORDER BY UDFOrdinal";

                        IList<ProductionSurveillance> lstDatas =
                            conn.CallTableFunc<ProductionSurveillance>(strSQL, paramList);
                        datas = lstDatas.ToList<ProductionSurveillance>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetKanban_ProductionSurveillance 函数发生异常：{0}", error.Message);
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

        public IRAPJsonResult ufn_GetKanban_ProductLines(
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
                List<AndonPrdtLine> datas = new List<AndonPrdtLine>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetKanban_ProductLines，" +
                        "参数：SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetKanban_ProductLines(@SysLogID)" +
                            "ORDER BY UDFOrdinal";

                        IList<AndonPrdtLine> lstDatas = conn.CallTableFunc<AndonPrdtLine>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonPrdtLine>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetKanban_ProductLines 函数发生异常：{0}", error.Message);
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
        /// <param name="t103LeafID">生产任务种类叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetKanban_PWOSurveillance(
            int communityID,
            int t103LeafID,
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
                List<PWOSurveillance> datas = new List<PWOSurveillance>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T103LeafID", DbType.Int32, t103LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetKanban_PWOSurveillance，" +
                        "参数：CommunityID={0}|T103LeafID={1}|SysLogID={2}",
                        communityID, t103LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetKanban_PWOSurveillance(" +
                            "@CommunityID, @T103LeafID, @SysLogID)";

                        IList<PWOSurveillance> lstDatas =
                            conn.CallTableFunc<PWOSurveillance>(strSQL, paramList);
                        datas = lstDatas.ToList<PWOSurveillance>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetKanban_PWOSurveillance 函数发生异常：{0}", error.Message);
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