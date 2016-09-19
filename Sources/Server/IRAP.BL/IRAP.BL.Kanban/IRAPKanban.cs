using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections;

using IRAPShared;
using IRAP.Global;
using IRAP.Entity.Kanban;
using IRAPORM;

namespace IRAP.BL.Kanban
{
    public class IRAPKanban : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPKanban()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="t3LeafID">功能叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult sfn_GetList_JumpToFunctions(
            int communityID,
            int t3LeafID,
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
                List<JumpToFunction> datas = new List<JumpToFunction>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T3LeafID", DbType.Int32, t3LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetList_JumpToFunctions，" +
                        "参数：CommunityID={0}|T3LeafID={1}|SysLogID={2}",
                        communityID, t3LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_GetList_JumpToFunctions(" +
                            "@CommunityID, @T3LeafID, @SysLogID)";

                        IList<JumpToFunction> lstDatas = conn.CallTableFunc<JumpToFunction>(strSQL, paramList);
                        datas = lstDatas.ToList<JumpToFunction>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_GetList_JumpToFunctions 函数发生异常：{0}", error.Message);
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
        /// 获取可访问叶集(带名称)
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="scenarioIndex">应用情境序号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult sfn_AccessibleLeafSetEx(
            int communityID,
            int treeID,
            int scenarioIndex,
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
                List<LeafSetEx> datas = new List<LeafSetEx>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TreeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@ScenarioIndex", DbType.Int32, scenarioIndex));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_AccessibleLeafSetEx，" +
                        "参数：CommunityID={0}|TreeID={1}|ScenarioIndex={2}|SysLogID={3}",
                        communityID, treeID, scenarioIndex, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_AccessibleLeafSetEx(" +
                            "@CommunityID, @TreeID, @ScenarioIndex, @SysLogID)";

                        IList<LeafSetEx> lstDatas = conn.CallTableFunc<LeafSetEx>(strSQL, paramList);
                        datas = lstDatas.ToList<LeafSetEx>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_AccessibleLeafSetEx 函数发生异常：{0}", error.Message);
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
        /// 获取点击流选中叶集
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="clickStream">点击流</param>
        public IRAPJsonResult sfn_SelectedLeafSet(
            int communityID,
            int treeID,
            string clickStream,
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
                List<SelectedLeaf> datas = new List<SelectedLeaf>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TreeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@ClickStream", DbType.String, clickStream));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_SelectedLeafSet，" +
                        "参数：CommunityID={0}|TreeID={1}|ClickStream={2}",
                        communityID, treeID, clickStream),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_SelectedLeafSet(" +
                            "@CommunityID, @TreeID, @ClickStream)" +
                            "ORDER BY Ordinal";

                        IList<SelectedLeaf> lstDatas = conn.CallTableFunc<SelectedLeaf>(strSQL, paramList);
                        datas = lstDatas.ToList<SelectedLeaf>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_SelectedLeafSet 函数发生异常：{0}", error.Message);
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
        /// 未找到对应的数据库函数
        /// </summary>
        public IRAPJsonResult sfn_TreeEntities()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 未找到对应的数据库函数
        /// </summary>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetKanban_Equipment()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 未找到对应的数据库函数
        /// </summary>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetKanban_FailureModes()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 未找到对应的数据库函数
        /// </summary>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetKanban_InspectFailures()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 未找到对应的数据库函数
        /// </summary>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetKanban_Routing_PrevWorkUnits()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 未找到对应的数据库函数
        /// </summary>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetKanban_SlotStorage()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 未找到对应的数据库函数
        /// </summary>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetKanban_Station_Ports(
            int communityID,
            long sysLogID,
            int processLeafID,
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
                List<StationPortInfo> datas = new List<StationPortInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ProcessLeafID", DbType.Int32, processLeafID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..ufn_GetKanban_Station_Ports，" +
                        "参数：CommunityID={0}|SysLogID={1}|ProcessLeafID={2}",
                        communityID,
                        sysLogID,
                        processLeafID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                                "SELECT * " +
                                "FROM IRAP..ufn_GetKanban_Station_Ports(" +
                                "@CommunityID, @SysLogID) ORDER BY Ordinal";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<StationPortInfo> lstDatas =
                            conn.CallTableFunc<StationPortInfo>(strSQL, paramList);
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAP..ufn_GetKanban_Station_Ports 函数发生异常：{0}",
                        error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
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
        /// 未找到对应的数据库函数
        /// </summary>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetKanban_TestFailures()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 未找到对应的数据库函数
        /// </summary>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_ProductMoveBack()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 未找到对应的数据库函数
        /// </summary>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetTranList_UncheckedMoveBack()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult sfn_GetList_MessagesToSend(
            int communityID,
            int scenarioIndex,
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
                List<MessageToSend> datas = new List<MessageToSend>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ScenarioIndex", DbType.Int32, scenarioIndex));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetList_MessagesToSend，" +
                        "参数：CommunityID={0}|ScenarioIndex={1}",
                        communityID, scenarioIndex),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_GetList_MessagesToSend(" +
                            "@CommunityID, @ScenarioIndex)" +
                            "ORDER BY Ordinal";

                        IList<MessageToSend> lstDatas =
                            conn.CallTableFunc<MessageToSend>(strSQL, paramList);
                        datas = lstDatas.ToList<MessageToSend>();
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
                            "调用 IRAP..sfn_GetList_MessagesToSend 函数发生异常：{0}",
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

        public IRAPJsonResult sfn_TreeViewCtrlParameters(
            int communityID,
            string tvCtrlParameters,
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
                List<TVCtrlParam> datas = new List<TVCtrlParam>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TVCtrlParameters", DbType.String, tvCtrlParameters));
                paramList.Add(new IRAPProcParameter("@LanguageID", DbType.Int32, languageID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_TreeViewCtrlParameters，" +
                        "参数：CommunityID={0}|TVCtrlParameters={1}|LanguageID={2}",
                        communityID, tvCtrlParameters, languageID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_TreeViewCtrlParameters(" +
                            "@CommunityID, @TVCtrlParameters, @LanguageID)" +
                            "ORDER BY Ordinal";

                        IList<TVCtrlParam> lstDatas =
                            conn.CallTableFunc<TVCtrlParam>(strSQL, paramList);
                        datas = lstDatas.ToList<TVCtrlParam>();
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
                            "调用 IRAP..sfn_TreeViewCtrlParameters 函数发生异常：{0}",
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

        /// <returns>
        /// [
        /// 	TreeViewCacheID
        /// ]
        /// </returns>
        public IRAPJsonResult ssp_GetTreeViewCache(
            int communityID,
            int irapTreeID,
            int treeViewType,
            int entryNode,
            int ditvCtrlVar,
            string dstvCtrlBlk,
            string filterClickStream,
            string selectClickStream,
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
                paramList.Add(new IRAPProcParameter("@IRAPTreeID", DbType.Int32, irapTreeID));
                paramList.Add(new IRAPProcParameter("@TreeViewType", DbType.Int32, treeViewType));
                paramList.Add(new IRAPProcParameter("@EntryNode", DbType.Int32, entryNode));
                paramList.Add(new IRAPProcParameter("@DITVCtrlVar", DbType.Int32, ditvCtrlVar));
                paramList.Add(new IRAPProcParameter("@DSTVCtrlBlk", DbType.String, dstvCtrlBlk));
                paramList.Add(new IRAPProcParameter("@FilterClickStream", DbType.String, filterClickStream));
                paramList.Add(new IRAPProcParameter("@SelectClickStream", DbType.String, selectClickStream));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@TreeViewCacheID", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 IRAP..ssp_GetTreeViewCache，参数：" +
                        "CommunityID={0}|IRAPTreeID={1}|TreeViewType={2}|EntryNode={3}|" +
                        "DITVCtrlVar={4}|DSTVCtrlBlk={5}|FilterClickStream={6}|" +
                        "SelectClickStream={7}|SysLogID={8}",
                        communityID, irapTreeID, treeViewType, entryNode, ditvCtrlVar,
                        dstvCtrlBlk, filterClickStream, selectClickStream, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_GetTreeViewCache", ref paramList);
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
                            if (param.Direction == ParameterDirection.InputOutput ||
                                param.Direction == ParameterDirection.Output)
                            {
                                if (param.DbType == DbType.Int32 &&
                                    param.Value == DBNull.Value)
                                {
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                                }
                                else
                                {
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                                }
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
                        "调用 IRAP..ssp_GetTreeViewCache 时发生异常：{0}",
                        error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <param name="orderByMode">
        /// 排序规则：
        /// 1. NodeName; 
        /// 2. NodeCode, NodeName; 
        /// 3. UDFOrdinal
        /// </param>
        public IRAPJsonResult sfn_IRAPTreeView(
            int communityID,
            int irapTreeID,
            int treeViewType,
            int entryNode,
            int ditvCtrlVar,
            string dstvCtrlBlk,
            string filterClickStream,
            string selectClickStream,
            long sysLogID,
            int orderByMode,
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
                List<IRAPTreeViewNode> datas = new List<IRAPTreeViewNode>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@IRAPTreeID", DbType.Int32, irapTreeID));
                paramList.Add(new IRAPProcParameter("@TreeViewType", DbType.Int32, treeViewType));
                paramList.Add(new IRAPProcParameter("@EntryNode", DbType.Int32, entryNode));
                paramList.Add(new IRAPProcParameter("@DITVCtrlVar", DbType.Int32, ditvCtrlVar));
                paramList.Add(new IRAPProcParameter("@DSTVCtrlBlk", DbType.String, dstvCtrlBlk));
                paramList.Add(new IRAPProcParameter("@FilterClickStream", DbType.String, filterClickStream));
                paramList.Add(new IRAPProcParameter("@SelectClickStream", DbType.String, selectClickStream));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_IRAPTreeView，参数：" +
                        "CommunityID={0}|IRAPTreeID={1}|TreeViewType={2}|EntryNode={3}|" +
                        "DITVCtrlVar={4}|DSTVCtrlBlk={5}|FilterClickStream={6}|" +
                        "SelectClickStream={7}|SysLogID={8}|OrderByMode={9}",
                        communityID, irapTreeID, treeViewType, entryNode, ditvCtrlVar,
                        dstvCtrlBlk, filterClickStream, selectClickStream, sysLogID,
                        orderByMode),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_IRAPTreeView(" +
                            "@CommunityID, @IRAPTreeID, @TreeViewType, @EntryNode, " +
                            "@DITVCtrlVar, @DSTVCtrlBlk, @FilterClickStream, " +
                            "@SelectClickStream, @SysLogID)" +
                            "ORDER BY NodeDepth, Parent";
                        switch (orderByMode)
                        {
                            case 1:
                                strSQL += ", NodeName";
                                break;
                            case 2:
                                strSQL += ", NodeCode, NodeName";
                                break;
                            case 3:
                                strSQL += ", UDFOrdinal";
                                break;
                            default:
                                break;
                        }

                        IList<IRAPTreeViewNode> lstDatas =
                            conn.CallTableFunc<IRAPTreeViewNode>(strSQL, paramList);
                        datas = lstDatas.ToList<IRAPTreeViewNode>();
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
                            "调用 IRAP..sfn_IRAPTreeView 函数发生异常：{0}",
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
        /// 获取子树结点集(包含自己)
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="nodeID">结点标识</param>
        public IRAPJsonResult sfn_SubtreeNodes(
            int communityID,
            int treeID,
            int nodeID,
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
                List<SubTreeNode> datas = new List<SubTreeNode>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TreeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@NodeID", DbType.Int32, nodeID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_SubtreeNodes，参数：" +
                        "CommunityID={0}|TreeID={1}|NodeID={2}",
                        communityID, treeID, nodeID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_SubtreeNodes(" +
                            "@CommunityID, @TreeID, @NodeID)" +
                            "ORDER BY NodeDepth, UDFOrdinal";

                        IList<SubTreeNode> lstDatas =
                            conn.CallTableFunc<SubTreeNode>(strSQL, paramList);
                        datas = lstDatas.ToList<SubTreeNode>();
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
                            "调用 IRAP..sfn_SubtreeNodes 函数发生异常：{0}",
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
        /// 获取子树叶集
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="nodeID">结点标识</param>
        public IRAPJsonResult sfn_SubtreeLeaves(
            int communityID,
            int treeID,
            int nodeID,
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
                List<SubTreeLeaf> datas = new List<SubTreeLeaf>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TreeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@NodeID", DbType.Int32, nodeID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_SubtreeLeaves，参数：" +
                        "CommunityID={0}|TreeID={1}|NodeID={2}",
                        communityID, treeID, nodeID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_SubtreeLeaves(" +
                            "@CommunityID, @TreeID, @NodeID)" +
                            "ORDER BY NodeDepth, UDFOrdinal";

                        IList<SubTreeLeaf> lstDatas =
                            conn.CallTableFunc<SubTreeLeaf>(strSQL, paramList);
                        datas = lstDatas.ToList<SubTreeLeaf>();
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
                            "调用 IRAP..sfn_SubtreeLeaves 函数发生异常：{0}",
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
        /// 获取过滤后的子树叶集
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="nodeID">结点标识</param>
        /// <param name="filterString">过滤字符串</param>
        public IRAPJsonResult mfn_SubtreeLeaves(
            int communityID,
            int treeID,
            int nodeID,
            string filterString,
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
                List<SubTreeLeaf> datas = new List<SubTreeLeaf>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TreeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@NodeID", DbType.Int32, nodeID));
                paramList.Add(new IRAPProcParameter("@FilterString", DbType.String, filterString));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_SubtreeLeaves，参数：" +
                        "CommunityID={0}|TreeID={1}|NodeID={2}|FilterString={3}",
                        communityID, treeID, nodeID, filterString),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = 
                            string.Format("SELECT * " +
                                "FROM IRAP..sfn_SubtreeLeaves(" +
                                "@CommunityID, @TreeID, @NodeID) " +
                                "WHERE NodeCode LIKE '%{0}%' OR NodeName LIKE '%{0}%' " +
                                "ORDER BY NodeDepth, UDFOrdinal",
                                filterString);
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<SubTreeLeaf> lstDatas =
                            conn.CallTableFunc<SubTreeLeaf>(strSQL, paramList);
                        datas = lstDatas.ToList<SubTreeLeaf>();
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
                            "调用 IRAP..sfn_SubtreeLeaves 函数发生异常：{0}",
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
        /// 拉出比较类型列表
        /// </summary>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult sfn_GetList_ScopeCriterionType(
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
                List<ScopeCriterionType> datas = new List<ScopeCriterionType>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetList_ScopeCriterionType，参数：SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_GetList_ScopeCriterionType(@SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<ScopeCriterionType> lstDatas =
                            conn.CallTableFunc<ScopeCriterionType>(strSQL, paramList);
                        datas = lstDatas.ToList<ScopeCriterionType>();
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
                            "调用 IRAP..sfn_GetList_ScopeCriterionType 函数发生异常：{0}",
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
        /// 获取可访问子树叶集
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="nodeID">结点标识</param>
        /// <param name="scenarioIndex">应用情境序号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult sfn_AccessibleSubtreeLeaves(
            int communityID,
            int treeID,
            int nodeID,
            int scenarioIndex,
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
                List<SubTreeLeaf> datas = new List<SubTreeLeaf>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TreeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@NodeID", DbType.Int32, nodeID));
                paramList.Add(new IRAPProcParameter("@ScenarioIndex", DbType.Int32, scenarioIndex));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_AccessibleSubtreeLeaves，参数：" +
                        "CommunityID={0}|TreeID={1}|NodeID={2}|ScenarioIndex={3}|" +
                        "SysLogID={4}",
                        communityID, treeID, nodeID, scenarioIndex, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_AccessibleSubtreeLeaves(" +
                            "@CommunityID, @TreeID, @NodeID, @ScenarioIndex, @SysLogID)" +
                            "ORDER BY NodeDepth, UDFOrdinal";

                        IList<SubTreeLeaf> lstDatas =
                            conn.CallTableFunc<SubTreeLeaf>(strSQL, paramList);
                        datas = lstDatas.ToList<SubTreeLeaf>();
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
                            "调用 IRAP..sfn_AccessibleSubtreeLeaves 函数发生异常：{0}",
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
        /// 获取有效期间类型清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="languageID">语言标识</param>
        public IRAPJsonResult sfn_GetList_ValidPeriodTypes(
            int communityID,
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
                List<PeriodType> datas = new List<PeriodType>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@LanguageID", DbType.Int32, languageID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetList_ValidPeriodTypes，参数：" +
                        "CommunityID={0}|LanguageID={1}",
                        communityID, languageID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_GetList_ValidPeriodTypes(" +
                            "@CommunityID, @LanguageID)";

                        IList<PeriodType> lstDatas =
                            conn.CallTableFunc<PeriodType>(strSQL, paramList);
                        datas = lstDatas.ToList<PeriodType>();
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
                            "调用 IRAP..sfn_GetList_ValidPeriodTypes 函数发生异常：{0}",
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
        /// 获取期间起止时间
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="periodTypeCode">期间类型代码</param>
        /// <param name="datetimeSpec">指定的日期时间点</param>
        /// <param name="periodOffset">期间偏移量</param>
        public IRAPJsonResult sfn_Period(
            int communityID,
            string periodTypeCode,
            DateTime datetimeSpec,
            int periodOffset,
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
                List<Period> datas = new List<Period>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@PeriodTypeCode", DbType.String, periodTypeCode));
                paramList.Add(new IRAPProcParameter("@DateTimeSpec", DbType.DateTime2, datetimeSpec));
                paramList.Add(new IRAPProcParameter("@PeriodOffset", DbType.Int32, periodOffset));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_Period，参数：" +
                        "CommunityID={0}|PeriodTypeCode={1}|DateTimeSpec={2}" +
                        "PeriodOffset={3}",
                        communityID, periodTypeCode, datetimeSpec, periodOffset),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_Period(" +
                            "@CommunityID, @PeriodTypeCode, @DateTimeSpec, @PeriodOffset)";

                        IList<Period> lstDatas =
                            conn.CallTableFunc<Period>(strSQL, paramList);
                        datas = lstDatas.ToList<Period>();
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
                            "调用 IRAP..sfn_Period 函数发生异常：{0}",
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
        /// 获取IRAP类实例的值：
        /// ⒈ 获取参数值，包括全局参数、社区参数、树个性参数；
        /// ⒉ 获取属性值，获取八大属性的值；
        /// ⒊ 获取事实；
        /// ⒋ 获取最新交易号。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="instanceID">实例标识</param>
        /// <param name="irapClassCode">IRAP 类码</param>
        /// <returns>[long]</returns>
        public IRAPJsonResult sfn_GetIRAPValue(
            int communityID,
            long instanceID,
            string irapClassCode,
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
                long data = 0;

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@InstanceID", DbType.Int64, instanceID));
                paramList.Add(new IRAPProcParameter("@IRAPClassCode", DbType.String, irapClassCode));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP.dbo.sfn_GetIRAPValue，参数：CommunityID={0}|" +
                        "InstanceID={1}|IRAPClassCode={2}",
                        communityID, instanceID, irapClassCode),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        data = (long) conn.CallScalarFunc("IRAP.dbo.sfn_GetIRAPValue", paramList);
                        errCode = 0;
                        errText = string.Format("调用成功！返回值：[{0}]", data);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP.dbo.sfn_GetIRAPValue 函数发生异常：{0}", error.Message);
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
        /// 获取指定主机和指定刷新类型是否需要刷新数据
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="refreshingType">刷新雷系字符串</param>
        /// <param name="hostName">主机名</param>
        public IRAPJsonResult mfn_GetInfo_StationNeedRefreshed(
            int communityID,
            string refreshingType,
            string hostName,
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
                bool data = false;

                #region 创建数据库调用参数组，并赋值
                long partitioningKey = communityID * 10000;
                WriteLog.Instance.Write(
                    string.Format(
                        "查找表 Stb228，参数：PartitioningKey={0}|" +
                        "RefreshingType={1}|HostName={2}",
                        partitioningKey, refreshingType, hostName),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        object tmpResult = null;
                        tmpResult = conn.Get<Stb228>(
                            new Stb228
                            {
                                PartitioningKey = partitioningKey,
                                RefreshingType = refreshingType,
                                HostName = hostName,
                            });

                        if (tmpResult == null)
                        {
                            errCode = 0;
                            errText =
                                string.Format(
                                    "[HostName({0})][RefreshingType({1})]不需要刷新",
                                    hostName, refreshingType);
                            data = false;
                        }
                        else
                        {
                            errCode = 0;
                            errText =
                                string.Format(
                                    "[HostName({0})][RefreshingType({1})]需要刷新",
                                    hostName, refreshingType);
                            data = true;

                            conn.Delete<Stb228>(
                                string.Format(
                                    "PartitioningKey={0} AND RefreshingType='{1}' AND HostName='{2}'",
                                    partitioningKey, refreshingType, hostName));
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 mfn_GetInfo_StationNeedRefreshed 函数发生异常：{0}", error.Message);
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
        /// 获取指定社区的所有用户清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <returns>List[CommunityUserInfo]</returns>
        public IRAPJsonResult sfn_GetList_UsersOfACommunity(
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
                List<CommunityUserInfo> datas = new List<CommunityUserInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetList_UsersOfACommunity，参数：" +
                        "CommunityID={0}",
                        communityID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_GetList_UsersOfACommunity(" +
                            "@CommunityID)";

                        IList<CommunityUserInfo> lstDatas =
                            conn.CallTableFunc<CommunityUserInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<CommunityUserInfo>();
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
                            "调用 IRAP..sfn_GetList_UsersOfACommunity 函数发生异常：{0}",
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
