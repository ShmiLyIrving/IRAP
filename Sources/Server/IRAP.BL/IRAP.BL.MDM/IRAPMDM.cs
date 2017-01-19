using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Reflection;

using IRAP.Global;
using IRAPORM;
using IRAPShared;
using IRAP.Server.Global;
using IRAP.Entity.MDM;
using IRAP.Entity.MDM.Tables;
using IRAP.Entity.IRAP;
using IRAP.Entities.MDM;

namespace IRAP.BL.MDM
{
    public class IRAPMDM : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPMDM()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 根据父节点获取系统的机构叶节点列表
        /// </summary>
        /// <param name="parentID">父节点标识</param>
        public IRAPJsonResult mfn_GetList_Agencies(
            int parentID,
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
                List<Stb053> datas = new List<Stb053>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@ParentID", DbType.Int32, parentID));
                WriteLog.Instance.Write(
                    string.Format(
                        "从 IRAP..stb053 表中获取 TreeID=1，Father={0} 的记录",
                        parentID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..stb053 WHERE TreeID=1 AND Father=@ParetnID";

                        IList<Stb053> lstDatas = conn.CallTableFunc<Stb053>(strSQL, paramList);
                        datas = lstDatas.ToList<Stb053>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("从 IRAP..stb053 获取记录发生异常：{0}", error.Message);
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
        /// 获取系统的机构组列表
        /// </summary>
        public IRAPJsonResult mfn_GetList_AgencyGroups(out int errCode, out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<Stb052> datas = new List<Stb052>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                WriteLog.Instance.Write(
                    "从 IRAP..stb053 表中获取 TreeID=1 的记录",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..stb052 WHERE TreeID=1" +
                            "ORDER BY Father, NodeDepth, UDFOrdinal";

                        IList<Stb052> lstDatas = conn.CallTableFunc<Stb052>(strSQL, paramList);
                        datas = lstDatas.ToList<Stb052>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("从 IRAP..stb052 获取记录发生异常：{0}", error.Message);
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
        /// 获取一般树视图
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="includeLeaves">包含树叶子</param>
        /// <param name="entryNode">入口节点</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult sfn_TreeView(
            int communityID,
            int treeID,
            bool includeLeaves,
            int entryNode,
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
                List<TreeViewNode> datas = new List<TreeViewNode>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TreeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@IncludeLeaves", DbType.Boolean, includeLeaves));
                paramList.Add(new IRAPProcParameter("@EntryNode", DbType.Int32, entryNode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_TreeView，" +
                        "参数：CommunityID={0}|TreeID={1}|SysLogID={2}|" +
                        "IncludeLeaves={3}|EntryNode={4}",
                        communityID, treeID, sysLogID, includeLeaves, entryNode),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_TreeView(" +
                            "@CommunityID, @TreeID, @SysLogID, @IncludeLeaves, @EntryNode) " +
                            "ORDER BY NodeDepth, Parent, UDFOrdinal, NodeID";

                        IList<TreeViewNode> lstDatas = conn.CallTableFunc<TreeViewNode>(strSQL, paramList);
                        datas = lstDatas.ToList<TreeViewNode>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_TreeView 函数发生异常：{0}", error.Message);
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
        /// 树视图新增一个结点
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="irapTreeID">IRAP 树视图标识</param>
        /// <param name="treeViewType">
        /// IRAP 树视图类型：
        /// 1-森林视图；
        /// 2-普通树视图；
        /// 3~16略。
        /// </param>
        /// <param name="nodeID">结点标识</param>
        /// <param name="nodeType">
        /// 结点类型：
        /// 1-森林；
        /// 2-树；
        /// 3-普通结点；
        /// 4-叶子；
        /// 5-属性。
        /// </param>
        /// <param name="nodePK">结点分区键</param>
        /// <param name="newNodeType">新增结点类型</param>
        /// <param name="newNodePK">新增结点分区键</param>
        /// <param name="createMode">
        /// 创建方式：
        /// 1-新增作为本结点末子结点；
        /// 2-插入作为本结点末兄结点；
        /// </param>
        /// <param name="nodeCode">结点代码</param>
        /// <param name="alternateCode">替代结点代码</param>
        /// <param name="nodeName">结点名称</param>
        /// <param name="udfOrdinal">兄弟遍历序</param>
        /// <param name="iconID">个性图标标识</param>
        /// <param name="ctrlValue">属性控制值</param>
        /// <param name="treeViewCacheID">树视图缓冲区标识</param>
        /// <param name="xmlString">个性处理XML串</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>
        /// Hashtable
        /// 	NewNodeID       int     新结点标识
        /// 	Accessibility   int     新结点可访问性（0-不可选择；1-可单选；2-可复选）
        /// 	SelectStatus    int     新结点选中状态（0-未选中；1-已选中）
        /// 	SearchCode1     string  新结点第一检索码
        /// 	SearchCode2     string  新结点第二检索码
        /// </returns>
        public IRAPJsonResult ssp_NewIRAPTreeNode(
            int communityID,
            int irapTreeID,
            int treeViewType,
            int nodeID,
            int nodeType,
            long nodePK,
            int newNodeType,
            long newNodePK,
            int createMode,
            string nodeCode,
            string alternateCode,
            string nodeName,
            double udfOrdinal,
            int iconID,
            int ctrlValue,
            int treeViewCacheID,
            string xmlString,
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
                paramList.Add(new IRAPProcParameter("@NodeID", DbType.Int32, nodeID));
                paramList.Add(new IRAPProcParameter("@NodeType", DbType.Int32, nodeType));
                paramList.Add(new IRAPProcParameter("@NodePK", DbType.Int64, nodePK));
                paramList.Add(new IRAPProcParameter("@NewNodeType", DbType.Int32, newNodeType));
                paramList.Add(new IRAPProcParameter("@NewNodePK", DbType.Int64, newNodePK));
                paramList.Add(new IRAPProcParameter("@CreateMode", DbType.Int32, createMode));
                paramList.Add(new IRAPProcParameter("@NodeCode", DbType.String, nodeCode));
                paramList.Add(new IRAPProcParameter("@AlternateCode", DbType.String, alternateCode));
                paramList.Add(new IRAPProcParameter("@NodeName", DbType.String, nodeName));
                paramList.Add(new IRAPProcParameter("@UDFOrdinal", DbType.Double, udfOrdinal));
                paramList.Add(new IRAPProcParameter("@IconID", DbType.Int32, iconID));
                paramList.Add(new IRAPProcParameter("@CtrlValue", DbType.Int32, ctrlValue));
                paramList.Add(new IRAPProcParameter("@TreeViewCacheID", DbType.Int32, treeViewCacheID));
                paramList.Add(new IRAPProcParameter("@XMLString", DbType.String, xmlString));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter("@NewNodeID", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(
                    new IRAPProcParameter("@Accessibility", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(
                    new IRAPProcParameter("@SelectStatus", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(
                    new IRAPProcParameter("@SearchCode1", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(
                    new IRAPProcParameter("@SearchCode2", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(
                    new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(
                    new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 IRAP..ssp_NewIRAPTreeNode，参数：" +
                        "CommunityID={0}|IRAPTreeID={1}|TreeViewType={2}|" +
                        "NodeID={3}|NodeType={4}|NodePK={5}|NewNodeType={6}|" +
                        "NewNodePK={7}|CreatMode={8}|NodeCode={9}|AlternateCode={10}|" +
                        "NodeName={11}|UDFOrdinal={12}|IconID={13}|CtrlValue={14}|" +
                        "TreeViewCacheID={15}|XMLString={16}|SysLogID={17}",
                        communityID, irapTreeID, treeViewType, nodeID, nodeType,
                        nodePK, newNodeType, newNodePK, createMode, nodeCode,
                        alternateCode, nodeName, udfOrdinal, iconID, ctrlValue,
                        treeViewCacheID, xmlString, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_NewIRAPTreeNode", ref paramList);
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
                errText = string.Format("调用 IRAP..ssp_NewIRAPTreeNode 时发生异常：{0}", error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 未找到对应的数据库存储过程
        /// </summary>
        public IRAPJsonResult ssp_AlterNodeName()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 未找到对应的数据库存储过程
        /// </summary>
        public IRAPJsonResult ssp_AlterCode()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 数据库存储过程没有定义注释
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="irapTreeID">IRAP 树视图标识</param>
        /// <param name="treeViewType">
        /// IRAP 树视图类型：
        /// 1-森林视图；
        /// 2-普通树视图；
        /// 3~16略。
        /// </param>
        /// <param name="nodeID">结点标识</param>
        /// <param name="nodeType">
        /// 结点类型：
        /// 1-森林；
        /// 2-树；
        /// 3-普通结点；
        /// 4-叶子；
        /// 5-属性。
        /// </param>
        /// <param name="treeViewCacheID">树视图缓冲区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ssp_DeleIRAPTreeNode(
            int communityID,
            int irapTreeID,
            int treeViewType,
            int nodeID,
            int nodeType,
            int treeViewCacheID,
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
                paramList.Add(new IRAPProcParameter("@NodeID", DbType.Int32, nodeID));
                paramList.Add(new IRAPProcParameter("@NodeType", DbType.Int32, nodeType));
                paramList.Add(new IRAPProcParameter("@TreeViewCacheID", DbType.Int32, treeViewCacheID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(
                    new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 IRAP..ssp_DeleIRAPTreeNode，参数：" +
                        "CommunityID={0}|IRAPTreeID={1}|TreeViewType={2}|" +
                        "NodeID={3}|NodeType={4}TreeViewCacheID={5}|SysLogID={6}",
                        communityID, irapTreeID, treeViewType, nodeID, nodeType,
                        treeViewCacheID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_DeleIRAPTreeNode", ref paramList);
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
                errText = string.Format("调用 IRAP..ssp_DeleIRAPTreeNode 时发生异常：{0}", error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 未找到对应的数据库存储过程
        /// </summary>
        public IRAPJsonResult ssp_ClassifyAttributeFor132()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取排产优先级分类属性下拉列表
        /// </summary>
        /// <returns>List[IRAP.Entity.MDM.Stb058]</returns>
        public IRAPJsonResult mfn_GetList_T213ClassifyAttribute(out int errCode, out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<Stb058> datas = new List<Stb058>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..stb058 " +
                            "WHERE TreeID=213 AND Father=33084";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<Stb058> lstDatas = conn.CallTableFunc<Stb058>(strSQL, paramList);
                        datas = lstDatas.ToList<Stb058>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("从 IRAPMDM..stb058 获取记录发生异常：{0}", error.Message);
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
        /// 获取产品族（产品系列）的树
        /// </summary>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[ProductSeries]</returns>
        public IRAPJsonResult mfn_GetTreeList_ProductSeries(long sysLogID, out int errCode, out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<ProductSeriesTreeNode> datas = new List<ProductSeriesTreeNode>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                            string.Format(
                                "SELECT T.*, " +
                                "       T213.LeafID AS T213LeafID, " +
                                "       T213.NodeName AS T213NodeName " +
                                "  FROM IRAP..sfn_TreeView(132, {0}, 1, 10032) T " +
                                "       LEFT OUTER JOIN IRAPMDM..stb063 S132 " +
                                "            ON S132.TreeID = 132 AND " +
                                "               S132.TransactNoLE = 9223372036854775807 AND " +
                                "               S132.LeafID = -T.NodeID" +
                                "       LEFT OUTER JOIN IRAPMDM..stb058 T213 " +
                                "            ON T213.TreeID = 213 AND" +
                                "               T213.LeafID = S132.Leaf01" +
                                " ORDER BY NodePath, Parent, UDFOrdinal, NodeID",
                                sysLogID);
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<ProductSeriesTreeNode> lstDatas = conn.CallTableFunc<ProductSeriesTreeNode>(strSQL, paramList);
                        datas = lstDatas.ToList<ProductSeriesTreeNode>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("获取产品族（产品系列）的树记录发生异常：{0}", error.Message);
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
        /// 获取产品树
        /// </summary>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[ProductTreeNode]</returns>
        public IRAPJsonResult mfn_GetTreeList_Products(long sysLogID, out int errCode, out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<ProductSeriesTreeNode> datas = new List<ProductSeriesTreeNode>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                            string.Format(
                                "SELECT T.*, " +
                                "       T213.LeafID AS T213LeafID, " +
                                "       T213.NodeName AS T213NodeName " +
                                "  FROM IRAP..sfn_TreeView(132, {0}, 1, 10032) T " +
                                "       LEFT OUTER JOIN IRAPMDM..stb063 S132 " +
                                "            ON S132.TreeID = 132 AND " +
                                "               S132.TransactNoLE = 9223372036854775807 AND " +
                                "               S132.LeafID = -T.NodeID" +
                                "       LEFT OUTER JOIN IRAPMDM..stb058 T213 " +
                                "            ON T213.TreeID = 213 AND" +
                                "               T213.LeafID = S132.Leaf01" +
                                " ORDER BY NodePath, Parent, UDFOrdinal, NodeID",
                                sysLogID);
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<ProductSeriesTreeNode> lstDatas = conn.CallTableFunc<ProductSeriesTreeNode>(strSQL, paramList);
                        datas = lstDatas.ToList<ProductSeriesTreeNode>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("获取产品的树记录发生异常：{0}", error.Message);
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
        /// 未找到对应的数据库存储过程
        /// </summary>
        public IRAPJsonResult ssp_ClassifyAttributeFor102()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 未找到对应的数据库存储过程
        /// </summary>
        public IRAPJsonResult ssp_InstantaneousAttributeFor102()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult mfn_GetList_T132ClassifyAttribute(out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult mfn_GetTreeList_ProductLine(long sysLogID, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult mfn_GetList_ProductLineCapacities(int t134LeafID, long sysLogID, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取 058 表中指定树标识和代码的叶子信息
        /// </summary>
        public IRAPJsonResult mfn_GetInfo_Entity058WithCode(int treeID, string code, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定产品的工段清单
        /// </summary>
        /// <param name="productCode">产品编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[ProcessSegment]</returns>
        public IRAPJsonResult ufn_GetList_ProcessSegmentsOfAProduct(
            string productCode,
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
                List<ProcessSegment> datas =
                    new List<ProcessSegment>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@ProductCode", DbType.String, productCode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_ProcessSegmentsOfAProduct，" +
                        "参数：ProductCode={0}|SysLogID={1}",
                        productCode, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_ProcessSegmentsOfAProduct(" +
                            "@ProductCode, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<ProcessSegment> lstDatas =
                            conn.CallTableFunc<ProcessSegment>(strSQL, paramList);
                        datas = lstDatas.ToList<ProcessSegment>();
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
                            "调用 IRAPMDM..ufn_GetList_ProcessSegmentsOfAProduct 函数发生异常：{0}",
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
        /// 获取指定树标识的列表
        /// </summary>
        public IRAPJsonResult mfn_GetList_EntititesIn058(int treeID, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult mfn_GetList_ProductOptions(out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定产品编号的产品信息
        /// </summary>
        /// <param name="productCode">产品编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[IRAP.Entity.IRP.Product]</returns>
        public IRAPJsonResult ufn_GetProductName(
            string productCode,
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
                List<Product> datas =
                    new List<Product>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@ProductCode", DbType.String, productCode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..ufn_GetProductName，" +
                        "参数：ProductCode={0}|SysLogID={1}",
                        productCode, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..ufn_GetProductName(@ProductCode, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<Product> lstDatas =
                            conn.CallTableFunc<Product>(strSQL, paramList);
                        datas = lstDatas.ToList<Product>();
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
                            "调用 IRAP..ufn_GetProductName 函数发生异常：{0}",
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

        /// <param name="sysLogID">社区标识</param>
        /// <returns>List[IRAP.Entity.IRAP.T215Info]</returns>
        public IRAPJsonResult ufn_GetList_OptionCode(
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
                List<T215Info> datas =
                    new List<T215Info>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..ufn_GetList_OptionCode，" +
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
                            "FROM IRAP..ufn_GetList_OptionCode(@SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<T215Info> lstDatas =
                            conn.CallTableFunc<T215Info>(strSQL, paramList);
                        datas = lstDatas.ToList<T215Info>();
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
                            "调用 IRAP..ufn_GetList_OptionCode 函数发生异常：{0}",
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
        /// 获取可以生产指定产品的产线或工作中心组
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="productNo">产品编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[ProductionLineOfProduct]</returns>
        public IRAPJsonResult ufn_GetList_ProductionLinesOfProduct(
            int communityID,
            string productNo,
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
                List<ProductionLineOfProduct> datas =
                    new List<ProductionLineOfProduct>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ProductNo", DbType.String, productNo));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_ProductionLinesOfProduct，" +
                        "参数：CommunityID={0}|ProductNo={1}|SysLogID={2}",
                        communityID, productNo, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_ProductionLinesOfProduct(" +
                            "@CommunityID, @ProductNo, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<ProductionLineOfProduct> lstDatas =
                            conn.CallTableFunc<ProductionLineOfProduct>(strSQL, paramList);
                        datas = lstDatas.ToList<ProductionLineOfProduct>();
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
                            "调用 IRAPMDM..ufn_GetList_ProductionLinesOfProduct 函数发生异常：{0}",
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
        /// 获取当前站点的可用目标存储地点清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetList_DstDeliveryStoreSites(
            int communityID,
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
                List<DstDeliveryStoreSite> datas =
                    new List<DstDeliveryStoreSite>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_DstDeliveryStoreSites，" +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_DstDeliveryStoreSites(" +
                            "@CommunityID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<DstDeliveryStoreSite> lstDatas =
                            conn.CallTableFunc<DstDeliveryStoreSite>(strSQL, paramList);
                        datas = lstDatas.ToList<DstDeliveryStoreSite>();
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
                            "调用 IRAPMDM..ufn_GetList_DstDeliveryStoreSites 函数发生异常：{0}",
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
        /// 获取指定产品指定工序的工艺参数标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点（空串-当面）</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[MethodStandard]</returns>
        public IRAPJsonResult ufn_GetList_MethodStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
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
                List<MethodStandard> datas =
                    new List<MethodStandard>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_MethodStandard，" +
                        "参数：CommunityID={0}|T102LeafID={1}|T216LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID, t102LeafID, t216LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_MethodStandard(" +
                            "@CommunityID, @T102LeafID, @T216LeafID, " +
                            "@ShotTime, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<MethodStandard> lstDatas =
                            conn.CallTableFunc<MethodStandard>(strSQL, paramList);
                        datas = lstDatas.ToList<MethodStandard>();
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
                            "调用 IRAPMDM..ufn_GetList_MethodStandard 函数发生异常：{0}",
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
        /// 获取指定产品指定工序的质量标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点（空串-当前）</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[QualityStandard]</returns>
        public IRAPJsonResult ufn_GetList_QualityStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
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
                List<QualityStandard> datas =
                    new List<QualityStandard>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_QualityStandard，" +
                        "参数：CommunityID={0}|T102LeafID={1}|T216LeafID={2}" +
                        "ShotTime={3}||SysLogID={4}",
                        communityID, t102LeafID, t216LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_QualityStandard(" +
                            "@CommunityID, @T102LeafID, @T216LeafID, " +
                            "@ShotTime, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<QualityStandard> lstDatas =
                            conn.CallTableFunc<QualityStandard>(strSQL, paramList);
                        datas = lstDatas.ToList<QualityStandard>();
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
                            "调用 IRAPMDM..ufn_GetList_QualityStandard 函数发生异常：{0}",
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
        /// 获取安灯事件类型清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[AndonEventType]</returns>
        public IRAPJsonResult ufn_GetList_AndonEventTypes(
            int communityID,
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
                List<AndonEventType> datas =
                    new List<AndonEventType>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_AndonEventTypes，" +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_AndonEventTypes(" +
                            "@CommunityID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<AndonEventType> lstDatas =
                            conn.CallTableFunc<AndonEventType>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonEventType>();
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
                            "调用 IRAPMDM..ufn_GetList_AndonEventTypes 函数发生异常：{0}",
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
        /// 获取站点绑定的生产线清单
        /// </summary>
        /// <remarks>
        /// ⑴ 社区标识一定要有效且非0
        /// ⑵ 系统登录标识一定要有效
        /// ⑶ 登录站点是安灯事件采集站点
        /// </remarks>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[ProductionLineForStationBound]</returns>
        public IRAPJsonResult ufn_GetList_StationBoundProductionLines(
            int communityID,
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
                List<ProductionLineForStationBound> datas =
                    new List<ProductionLineForStationBound>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_StationBoundProductionLines，" +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_StationBoundProductionLines(" +
                            "@CommunityID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<ProductionLineForStationBound> lstDatas =
                            conn.CallTableFunc<ProductionLineForStationBound>(strSQL, paramList);
                        datas = lstDatas.ToList<ProductionLineForStationBound>();
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
                            "调用 IRAPMDM..ufn_GetList_StationBoundProductionLines 函数发生异常：{0}",
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
        /// 将信息站点组切换到指定生产线
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="hostName">待切换站点主机名</param>
        /// <param name="t134LeafID">产线叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_SwitchToProductionLine(
            int communityID,
            string hostName,
            int t134LeafID,
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
                paramList.Add(new IRAPProcParameter("@HostName", DbType.String, hostName));
                paramList.Add(new IRAPProcParameter("@T134LeafID", DbType.Int32, t134LeafID));
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
                    string.Format("执行存储过程 IRAPMDM..usp_SwitchToProductionLine，参数：" +
                        "CommunityID={0}|HostName={1}|T134LeafID={2}|SysLogID={3}",
                        communityID, hostName, t134LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPMDM..usp_SwitchToProductionLine", ref paramList);
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
                errText = string.Format("调用 IRAPMDM..usp_SwitchToProductionLine 时发生异常：{0}", error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取上下文敏感的安灯呼叫对象清单：
        /// ⒈ 获取设备失效模式清单；
        /// ⒉ 获取产线物料清单；
        /// ⒊ 获取工位失效模式清单；
        /// ⒋ 获取设备工装型号清单；
        /// ⒌ 获取安全问题清单；
        /// ⒍ 获取产线其他支持人员清单。
        /// </summary>
        /// <remarks>从产线安灯事件采集固定客户端调用时，工位及设备叶标识传入0</remarks>
        /// <param name="communityID">社区标识</param>
        /// <param name="t179LeafID">安灯事件类型叶标识</param>
        /// <param name="t107LeafID">触发呼叫工位叶标识</param>
        /// <param name="t133LeafID">触发呼叫设备叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[AndonCallObject]</returns>
        public IRAPJsonResult ufn_GetList_AndonCallObjects(
            int communityID,
            int t179LeafID,
            int t107LeafID,
            int t133LeafID,
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
                List<AndonCallObject> datas = new List<AndonCallObject>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T179LeafID", DbType.Int32, t179LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@T133LeafID", DbType.Int32, t133LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_AndonCallObjects，" +
                        "参数：CommunityID={0}|T179LeafID={1}|T107LeafID={2}" +
                        "T133LeafID={3}|SysLogID={4}",
                        communityID, t179LeafID, t107LeafID, t133LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_AndonCallObjects(" +
                            "@CommunityID, @T179LeafID, @T107LeafID, " +
                            "@T133LeafID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<AndonCallObject> lstDatas =
                            conn.CallTableFunc<AndonCallObject>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonCallObject>();
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
                            "调用 IRAPMDM..ufn_GetList_AndonCallObjects 函数发生异常：{0}",
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
        /// 获取工序清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[ProcessOperation]</returns>
        public IRAPJsonResult ufn_GetList_ProcessOperations(
            int communityID,
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
                List<ProcessOperation> datas = new List<ProcessOperation>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_ProcessOperations，" +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_ProcessOperations(" +
                            "@CommunityID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<ProcessOperation> lstDatas =
                            conn.CallTableFunc<ProcessOperation>(strSQL, paramList);
                        datas = lstDatas.ToList<ProcessOperation>();
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
                            "调用 IRAPMDM..ufn_GetList_ProcessOperations 函数发生异常：{0}",
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
        /// 获取产品指定时点工艺流程
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="shotTime">关注的时间点(yyyy-mm-dd hh:mm)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetInfo_ProductProcess(
            int communityID,
            int t102LeafID,
            string shotTime,
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
                List<ProductProcess> datas = new List<ProductProcess>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetInfo_ProductProcess，" +
                        "参数：CommunityID={0}|T102LeafID={1}|ShotTime={2}|" +
                        "SysLogID={3}",
                        communityID, t102LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetInfo_ProductProcess(" +
                            "@CommunityID, @T102LeafID, @ShotTime, @SysLogID)";

                        IList<ProductProcess> lstDatas = conn.CallTableFunc<ProductProcess>(strSQL, paramList);
                        datas = lstDatas.ToList<ProductProcess>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMDM..ufn_GetInfo_ProductProcess 函数发生异常：{0}", error.Message);
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
        /// 根据系统登录标识获取产线信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识param>
        /// <returns>ProductionLineInfo</returns>
        public IRAPJsonResult ufn_GetInfo_ProductionLine(
            int communityID,
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
                ProductionLineInfo data = new ProductionLineInfo();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetInfo_ProductionLine，" +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetInfo_ProductionLine(" +
                            "@CommunityID, @SysLogID)";

                        IList<ProductionLineInfo> lstDatas = conn.CallTableFunc<ProductionLineInfo>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = "调用成功！";
                        }
                        else
                        {
                            errCode = -99001;
                            errText = "没有当前站点的产线信息";
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMDM..ufn_GetInfo_ProductionLine 函数发生异常：{0}", error.Message);
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
        /// 获取指定产线指定产品相关的Logo图片信息
        /// </summary>
        /// <param name="communityID">社区标识 </param>
        /// <param name="t134LeafID">产线叶标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <returns>FVS_LogoImages</returns>
        public IRAPJsonResult ufn_GetInfo_LogoImages(
            int communityID,
            int t134LeafID,
            int t102LeafID,
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
                FVS_LogoImages data = new FVS_LogoImages();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T134LeafID", DbType.Int32, t134LeafID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetInfo_LogoImages，" +
                        "参数：CommunityID={0}|T134LeafID={1}|T102LeafID={2}",
                        communityID, t134LeafID, t102LeafID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetInfo_LogoImages(" +
                            "@CommunityID, @T134LeafID, @T102LeafID)";

                        IList<FVS_LogoImages> lstDatas = conn.CallTableFunc<FVS_LogoImages>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = "调用成功！";
                        }
                        else
                        {
                            errCode = -99001;
                            errText = "没有配置图片";
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMDM..ufn_GetInfo_LogoImages 函数发生异常：{0}", error.Message);
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
        /// 保存行集属性
        /// </summary>
        /// <remarks>
        /// ⒈ 进行生效时间合法性防错；
        /// ⒉ 自动敏感与上一版本之间的数据变化，更新版本历史；
        /// ⒊ 不进行版本控制时，也能保存上一版本到版本历史表。
        /// </remarks>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="leafID">叶标识</param>
        /// <param name="rowSetID">行集序号</param>
        /// <param name="voucherNo">变更凭证号</param>
        /// <param name="effectiveTime">生效时间点(yyyy-mm-dd hh:mm)，空串表示立刻生效</param>
        /// <param name="deleUnapplied">是否删除未应用版本</param>
        /// <param name="rsAttrXML">
        /// 行集属性
        /// 	[RSAttr]
        /// 		[Row RealOrdinal="1" .../]
        /// 		...
        /// 	[/RSAttr]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ssp_SaveRSAttrChange(
            int communityID,
            int treeID,
            int leafID,
            int rowSetID,
            string voucherNo,
            string effectiveTime,
            bool deleUnapplied,
            string rsAttrXML,
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
                paramList.Add(new IRAPProcParameter("@TreeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@LeafID", DbType.String, leafID));
                paramList.Add(new IRAPProcParameter("@RowSetID", DbType.Int32, rowSetID));
                paramList.Add(new IRAPProcParameter("@VoucherNo", DbType.String, voucherNo));
                paramList.Add(new IRAPProcParameter("@EffectiveTime", DbType.String, effectiveTime));
                paramList.Add(new IRAPProcParameter("@DeleUnapplied", DbType.Boolean, deleUnapplied));
                paramList.Add(new IRAPProcParameter("@RSAttrXML", DbType.String, rsAttrXML));
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
                    string.Format("执行存储过程 IRAPMDM..ssp_SaveRSAttrChange，参数：" +
                        "CommunityID={0}|TreeID={1}|LeafID={2}|RowSetID={3}|" +
                        "VoucherNo={4}|EffectiveTime={5}|DeleUnapplied={6}|" +
                        "RSAttrXML={7}|SysLogID={8}",
                        communityID, treeID, leafID, rowSetID, voucherNo, effectiveTime,
                        deleUnapplied, rsAttrXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPMDM..ssp_SaveRSAttrChange", ref paramList);
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
                        rtnParams = DBUtils.DBParamsToHashtable(paramList);
                    }

                    return Json(rtnParams);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPMDM..ssp_SaveRSAttrChange 时发生异常：{0}", error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 保存工序属性的变更内容
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t216Leaf">工序叶标识</param>
        /// <param name="t216Code">工序编码</param>
        /// <param name="t216Name">工序名称</param>
        /// <param name="t116Leaf">工序类型叶标识</param>
        /// <param name="t124Leaf">工段叶标识</param>
        /// <param name="t123Leaf">生产在制品部位叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>
        /// Hashtable
        /// 	T216Leaf		int
        /// </returns>
        public IRAPJsonResult usp_SaveAttr_ProcessOperation(
            int communityID,
            int t216Leaf,
            string t216Code,
            string t216Name,
            int t116Leaf,
            int t124Leaf,
            int t123Leaf,
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
                paramList.Add(
                    new IRAPProcParameter(
                        "@T216Leaf",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4)
                    {
                        Value = t216Leaf,
                    });
                paramList.Add(new IRAPProcParameter("@T216Code", DbType.String, t216Code));
                paramList.Add(new IRAPProcParameter("@T216Name", DbType.String, t216Name));
                paramList.Add(new IRAPProcParameter("@T116Leaf", DbType.Int32, t116Leaf));
                paramList.Add(new IRAPProcParameter("@T124Leaf", DbType.Int32, t124Leaf));
                paramList.Add(new IRAPProcParameter("@T123Leaf", DbType.Int32, t123Leaf));
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
                    string.Format("执行存储过程 IRAPMDM..usp_SaveAttr_ProcessOperation，参数：" +
                        "CommunityID={0}|T216Leaf={1}|T216Code={2}|T216Name={3}" +
                        "T116Leaf={4}|T124Leaf={5}|T123Leaf={6}|SysLogID={7}",
                        communityID, t216Leaf, t216Code, t216Name, t116Leaf,
                        t124Leaf, t123Leaf, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPMDM..usp_SaveAttr_ProcessOperation", ref paramList);
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
                errText = string.Format("调用 IRAPMDM..usp_SaveAttr_ProcessOperation 时发生异常：{0}", error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据102和（216或107）获取C64ID
        /// </summary>
        /// <returns>[int]</returns>
        public IRAPJsonResult ufn_GetMethodID(
            int communityID,
            int t102LeafID,
            int treeID,
            int leafID,
            long unixTime,
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
                int data = 0;

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@TreeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@LeafID", DbType.Int32, leafID));
                paramList.Add(new IRAPProcParameter("@UnixTime", DbType.Int64, unixTime));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM.dbo.ufn_GetMethodID，参数：CommunityID={0}|" +
                        "T102LeafID={1}|TreeID={2}|LeafID={3}|UnixTime={4}",
                        communityID, t102LeafID, treeID, leafID, unixTime),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        data = (int)conn.CallScalarFunc("IRAPMDM.dbo.ufn_GetMethodID", paramList);
                        errCode = 0;
                        errText = string.Format("调用成功！返回值：[{0}]", data);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMDM.dbo.ufn_GetMethodID 函数发生异常：{0}", error.Message);
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
        /// 未找到对应的数据库函数
        /// </summary>
        public IRAPJsonResult ufn_GetList_ProductGroup()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取工艺维护菜单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t116LeafID">工序类型标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[MethodMMenu]</returns>
        public IRAPJsonResult ufn_GetList_MethodMMenu(
            int communityID,
            int t116LeafID,
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
                List<MethodMMenu> datas = new List<MethodMMenu>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T116LeafID", DbType.Int32, t116LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_MethodMMenu，参数：CommunityID={0}|" +
                        "T116LeafID={1}|SysLogID={2}",
                        communityID, t116LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_MethodMMenu(" +
                            "@CommunityID, @T116LeafID, @SysLogID) ORDER BY Ordinal";

                        IList<MethodMMenu> lstDatas = conn.CallTableFunc<MethodMMenu>(strSQL, paramList);
                        datas = lstDatas.ToList<MethodMMenu>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMDM..ufn_GetList_MethodMMenu 函数发生异常：{0}", error.Message);
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
        /// 获取指定产品和工序的工装标准清单
        /// </summary>
        public IRAPJsonResult ufn_GetList_ToolingStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
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
                List<ToolingStandard> datas = new List<ToolingStandard>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_ToolingStandard，参数：CommunityID={0}|" +
                        "T102LeafID={1}|T216LeafID={2}|ShotTime={3}|SysLogID={4}",
                        communityID, t102LeafID, t216LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_ToolingStandard(" +
                            "@CommunityID, @T102LeafID, @T216LeafID, @ShotTime, " +
                            "@SysLogID)";

                        IList<ToolingStandard> lstDatas = conn.CallTableFunc<ToolingStandard>(strSQL, paramList);
                        datas = lstDatas.ToList<ToolingStandard>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMDM..ufn_GetList_ToolingStandard 函数发生异常：{0}", error.Message);
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
        /// 获取指定产品指定工序的生产程序清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[ProductionPrograms]</returns>
        public IRAPJsonResult ufn_GetList_ProductionPrograms(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
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
                List<ProductionPrograms> datas = new List<ProductionPrograms>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_ProductionPrograms，参数：CommunityID={0}|" +
                        "T102LeafID={1}|T216LeafID={2}|ShotTime={3}|SysLogID={4}",
                        communityID, t102LeafID, t216LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_ProductionPrograms(" +
                            "@CommunityID, @T102LeafID, @T216LeafID, @ShotTime, " +
                            "@SysLogID)";

                        IList<ProductionPrograms> lstDatas =
                            conn.CallTableFunc<ProductionPrograms>(strSQL, paramList);
                        datas = lstDatas.ToList<ProductionPrograms>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetList_ProductionPrograms 函数发生异常：{0}",
                        error.Message);
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
        /// 获取工序作业标准清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[OPStandard]</returns>
        public IRAPJsonResult ufn_GetList_SOP(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
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
                List<OPStandard> datas = new List<OPStandard>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_SOP，参数：CommunityID={0}|" +
                        "T102LeafID={1}|T216LeafID={2}|ShotTime={3}|SysLogID={4}",
                        communityID, t102LeafID, t216LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_SOP(" +
                            "@CommunityID, @T102LeafID, @T216LeafID, @ShotTime, " +
                            "@SysLogID)";

                        IList<OPStandard> lstDatas =
                            conn.CallTableFunc<OPStandard>(strSQL, paramList);
                        datas = lstDatas.ToList<OPStandard>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetList_SOP 函数发生异常：{0}",
                        error.Message);
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
        /// 获取工序生产环境参数标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[EnvParamStandard]</returns>
        public IRAPJsonResult ufn_GetList_EnvParamStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
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
                List<EnvParamStandard> datas = new List<EnvParamStandard>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_EnvParamStandard，参数：CommunityID={0}|" +
                        "T102LeafID={1}|T216LeafID={2}|ShotTime={3}|SysLogID={4}",
                        communityID, t102LeafID, t216LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_EnvParamStandard(" +
                            "@CommunityID, @T102LeafID, @T216LeafID, @ShotTime, " +
                            "@SysLogID)";

                        IList<EnvParamStandard> lstDatas =
                            conn.CallTableFunc<EnvParamStandard>(strSQL, paramList);
                        datas = lstDatas.ToList<EnvParamStandard>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetList_EnvParamStandard 函数发生异常：{0}",
                        error.Message);
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
        /// 获取指定产品指定工序人工检查标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[InspectionStandard]</returns>
        public IRAPJsonResult ufn_GetList_InspectionStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
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
                List<InspectionStandard> datas = new List<InspectionStandard>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_InspectionStandard，参数：CommunityID={0}|" +
                        "T102LeafID={1}|T216LeafID={2}|ShotTime={3}|SysLogID={4}",
                        communityID, t102LeafID, t216LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_InspectionStandard(" +
                            "@CommunityID, @T102LeafID, @T216LeafID, @ShotTime, " +
                            "@SysLogID)";

                        IList<InspectionStandard> lstDatas =
                            conn.CallTableFunc<InspectionStandard>(strSQL, paramList);
                        datas = lstDatas.ToList<InspectionStandard>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetList_InspectionStandard 函数发生异常：{0}",
                        error.Message);
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
        /// 获取指定产品指定工序物料装料标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[LoadingStandard]</returns>
        public IRAPJsonResult ufn_GetList_LoadingStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
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
                List<LoadingStandard> datas = new List<LoadingStandard>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_InspectionStandard，参数：CommunityID={0}|" +
                        "T102LeafID={1}|T216LeafID={2}|ShotTime={3}|SysLogID={4}",
                        communityID, t102LeafID, t216LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_LoadingStandard(" +
                            "@CommunityID, @T102LeafID, @T216LeafID, @ShotTime, " +
                            "@SysLogID)";

                        IList<LoadingStandard> lstDatas =
                            conn.CallTableFunc<LoadingStandard>(strSQL, paramList);
                        datas = lstDatas.ToList<LoadingStandard>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetList_LoadingStandard 函数发生异常：{0}",
                        error.Message);
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
        /// 获取失效模式清单的核心函数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t134LeafID">产线叶标识(0=不限)</param>
        /// <param name="t216LeafID">工序叶标识(0=不限)</param>
        /// <param name="t132LeafID">产品族叶标识(0=不限)</param>
        /// <param name="t102LeafID">产品叶标识(0=不限)</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[FailureModeCore]</returns>
        public IRAPJsonResult ufn_GetList_FailureModes_Core(
            int communityID,
            int t134LeafID,
            int t216LeafID,
            int t132LeafID,
            int t102LeafID,
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
                List<FailureModeCore> datas = new List<FailureModeCore>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T134LeafID", DbType.Int32, t134LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T132LeafID", DbType.Int32, t132LeafID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_FailureModes_Core，参数：CommunityID={0}|" +
                        "T134LeafID={1}|T216LeafID={2}|T132LeafID={1}|T102LeafID={2}|SysLogID={3}",
                        communityID,
                        t134LeafID,
                        t216LeafID,
                        t132LeafID,
                        t102LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_FailureModes_Core(" +
                            "@CommunityID, @T134LeafID, @T216LeafID, @T132LeafID, " +
                            "@T102LeafID, @SysLogID)";

                        IList<FailureModeCore> lstDatas =
                            conn.CallTableFunc<FailureModeCore>(strSQL, paramList);
                        datas = lstDatas.ToList<FailureModeCore>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetList_FailureModes_Core 函数发生异常：{0}",
                        error.Message);
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
        /// 获取工序生产能源质量标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[EnergyStandard]</returns>
        public IRAPJsonResult ufn_GetList_EnergyStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
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
                List<EnergyStandard> datas = new List<EnergyStandard>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_EnergyStandard，参数：CommunityID={0}|" +
                        "T102LeafID={1}|T216LeafID={2}|ShotTime={3}|SysLogID={4}",
                        communityID, t102LeafID, t216LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_EnergyStandard(" +
                            "@CommunityID, @T102LeafID, @T216LeafID, @ShotTime, " +
                            "@SysLogID)";

                        IList<EnergyStandard> lstDatas =
                            conn.CallTableFunc<EnergyStandard>(strSQL, paramList);
                        datas = lstDatas.ToList<EnergyStandard>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetList_EnergyStandard 函数发生异常：{0}",
                        error.Message);
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
        /// 获取工序生产防错规则
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[PokaYokeRule]</returns>
        public IRAPJsonResult ufn_GetList_PokaYokeRules(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
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
                List<PokaYokeRule> datas = new List<PokaYokeRule>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_PokaYokeRules，参数：CommunityID={0}|" +
                        "T102LeafID={1}|T216LeafID={2}|ShotTime={3}|SysLogID={4}",
                        communityID, t102LeafID, t216LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_PokaYokeRules(" +
                            "@CommunityID, @T102LeafID, @T216LeafID, @ShotTime, " +
                            "@SysLogID)";

                        IList<PokaYokeRule> lstDatas =
                            conn.CallTableFunc<PokaYokeRule>(strSQL, paramList);
                        datas = lstDatas.ToList<PokaYokeRule>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetList_PokaYokeRules 函数发生异常：{0}",
                        error.Message);
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
        /// 获取工序生产准备标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[PreparingStandard]</returns>
        public IRAPJsonResult ufn_GetList_PreparingStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
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
                List<PreparingStandard> datas = new List<PreparingStandard>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_PreparingStandard，参数：CommunityID={0}|" +
                        "T102LeafID={1}|T216LeafID={2}|ShotTime={3}|SysLogID={4}",
                        communityID, t102LeafID, t216LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_PreparingStandard(" +
                            "@CommunityID, @T102LeafID, @T216LeafID, @ShotTime, " +
                            "@SysLogID)";

                        IList<PreparingStandard> lstDatas =
                            conn.CallTableFunc<PreparingStandard>(strSQL, paramList);
                        datas = lstDatas.ToList<PreparingStandard>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetList_PreparingStandard 函数发生异常：{0}",
                        error.Message);
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
        /// 获取指定产品指定工序的操作工技能矩阵
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[SkillMatrixByMethod]</returns>
        public IRAPJsonResult ufn_GetSkillMatrix_ByMethod(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
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
                List<SkillMatrixByMethod> datas = new List<SkillMatrixByMethod>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetSkillMatrix_ByMethod，参数：CommunityID={0}|" +
                        "T102LeafID={1}|T216LeafID={2}|ShotTime={3}|SysLogID={4}",
                        communityID, t102LeafID, t216LeafID, shotTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetSkillMatrix_ByMethod(" +
                            "@CommunityID, @T102LeafID, @T216LeafID, @ShotTime, " +
                            "@SysLogID)";

                        IList<SkillMatrixByMethod> lstDatas =
                            conn.CallTableFunc<SkillMatrixByMethod>(strSQL, paramList);
                        datas = lstDatas.ToList<SkillMatrixByMethod>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetSkillMatrix_ByMethod 函数发生异常：{0}",
                        error.Message);
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
        /// 获取功能的表单控件信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="menuItemID">菜单项标识</param>
        /// <param name="progLanguageID">编程语言标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[FormCtrlInfo]</returns>
        public IRAPJsonResult sfn_FunctionFormCtrls(
            int communityID,
            int menuItemID,
            int progLanguageID,
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
                List<FormCtrlInfo> datas = new List<FormCtrlInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@MenuItemID", DbType.Int32, menuItemID));
                paramList.Add(new IRAPProcParameter("@ProgLanguageID", DbType.Int32, progLanguageID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_FunctionFormCtrls，参数：CommunityID={0}|" +
                        "MenuItemID={1}|ProgLanguageID={2}|SysLogID={3}",
                        communityID, menuItemID, progLanguageID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_FunctionFormCtrls(" +
                            "@CommunityID, @MenuItemID, @ProgLanguageID, " +
                            "@SysLogID) ORDER BY Ordinal";

                        IList<FormCtrlInfo> lstDatas =
                            conn.CallTableFunc<FormCtrlInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<FormCtrlInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAP..sfn_FunctionFormCtrls 函数发生异常：{0}",
                        error.Message);
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
        /// 获取工位生产状态(工艺呈现专用)
        /// ⒈ 正在生产时呈现工单号、产品、容器号以及完工时目标库位；
        /// ⒉ 未在生产时呈现应该执行的工单号、容器号以及滞在库位，并可呈现工艺信息；
        /// ⒊ 正在生产时，点击进入可以呈现各种工艺信息。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="filterT107LeafID">工位叶标识过滤：0-不过滤</param>
        /// <returns>List[WIPStationProductionStatus]</returns>
        public IRAPJsonResult ufn_GetList_WIPStationProductionStatus(
            int communityID,
            long sysLogID,
            int filterT107LeafID,
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
                List<WIPStationProductionStatus> datas =
                    new List<WIPStationProductionStatus>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_WIPStationProductionStatus，" +
                        "参数：CommunityID={0}|SysLogID={1}|FilterT107LeafID={2}",
                        communityID, sysLogID, filterT107LeafID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_WIPStationProductionStatus(" +
                            "@CommunityID, @SysLogID)";
                        if (filterT107LeafID != 0)
                            strSQL += string.Format(" WHERE T107LeafID={0}", filterT107LeafID);

                        IList<WIPStationProductionStatus> lstDatas =
                            conn.CallTableFunc<WIPStationProductionStatus>(strSQL, paramList);
                        datas = lstDatas.ToList<WIPStationProductionStatus>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetList_WIPStationProductionStatus 函数发生异常：{0}",
                        error.Message);
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
        /// 获取工位叶标识
        /// </summary>
        public IRAPJsonResult ufn_GetT216LeafID(
            int communityID,
            int t102LeafID,
            int t107LeafID,
            int unixTime,
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
                paramList.Add(new IRAPProcParameter("@UnixTime", DbType.String, unixTime));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM.dbo.ufn_GetT216LeafID，参数：CommunityID={0}|" +
                        "T102LeafID={1}|T107LeafID={2}|UnixTime={3}",
                        communityID,
                        t102LeafID,
                        t107LeafID,
                        unixTime),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        int rlt =
                            (int)conn.CallScalarFunc(
                                "IRAPMDM.dbo.ufn_GetT216LeafID",
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
                            "调用 IRAP.dbo.ufn_GetT216LeafID 函数发生异常：{0}",
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    return Json(0);
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="methodID">工艺标识</param>
        /// <param name="languageID">语言标识</param>
        public IRAPJsonResult ufn_GetList_AvailableMethodStandards(
            int communityID,
            int methodID,
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
                List<StandardType> datas = new List<StandardType>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@MethodID", DbType.Int32, methodID));
                paramList.Add(new IRAPProcParameter("@LanguageID", DbType.Int32, languageID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_AvailableMethodStandards，" +
                        "参数：CommunityID={0}|MethodID={1}|LanguageID={2}",
                        communityID, methodID, languageID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_AvailableMethodStandards(" +
                            "@CommunityID, @MethodID, @LanguageID)";

                        IList<StandardType> lstDatas =
                            conn.CallTableFunc<StandardType>(strSQL, paramList);
                        datas = lstDatas.ToList<StandardType>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetList_AvailableMethodStandards 函数发生异常：{0}",
                        error.Message);
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
        /// 获取产品一般属性
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>[GenAttr_Product]</returns>
        public IRAPJsonResult ufn_GetProductSketch(
            int communityID,
            int t102LeafID,
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
                GenAttr_Product rlt = new GenAttr_Product();

                WriteLog.Instance.Write(
                    string.Format(
                        "获得产品的一般属性，调用参数：CommunityID={0}|T102LeafID={1}|SysLogID={1}",
                        communityID,
                        t102LeafID,
                        sysLogID),
                    strProcedureName);

                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        long partitioningKey = communityID * 10000 + 102;

                        // 从获取 T102LeafID 对应的 EntityID
                        object tmpResult = null;
                        Stb058 stb058Entity = null;

                        tmpResult = conn.Get<Stb058>(new Stb058 { PartitioningKey = partitioningKey, LeafID = t102LeafID });
                        if (tmpResult == null)
                        {
                            errCode = 98001;
                            errText = string.Format("没有 LeafID = {0} 的产品信息", t102LeafID);
                            WriteLog.Instance.Write(errText, strProcedureName);
                            return Json(rlt);
                        }
                        else
                        {
                            stb058Entity = tmpResult as Stb058;
                        }

                        tmpResult = conn.Get<GenAttr_Product>(new GenAttr_Product()
                        {
                            PartitioningKey = partitioningKey,
                            EntityID = stb058Entity.EntityID
                        });
                        if (tmpResult == null)
                        {
                            errCode = 98001;
                            errText = string.Format("没有 LeafID = {0} 的产品一般属性", t102LeafID);
                            WriteLog.Instance.Write(errText, strProcedureName);
                            return Json(rlt);
                        }
                        else
                        {
                            rlt = ((GenAttr_Product)tmpResult);
                        }

                        errCode = 0;
                        errText = string.Format("获得 LeafID = {0} 的产品一般属性", t102LeafID);
                        return Json(rlt);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 ufn_GetProductSketch 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    return Json(rlt);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }

        /// <summary>
        /// 获取工序的一般属性
        /// </summary>
        /// <remarks>
        /// Sketch： 产品工序简图
        /// </remarks>
        /// <returns>[GenAttr_ProcessOperation]</returns>
        public IRAPJsonResult ufn_GetProcessOperationGenAttr(
            int communityID,
            int t216LeafID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                GenAttr_ProcessOperation rlt = new GenAttr_ProcessOperation();

                WriteLog.Instance.Write(
                    string.Format(
                        "获得工序的一般属性，调用参数：CommunityID={0}|T216LeafID={1}|SysLogID={2}",
                        communityID,
                        t216LeafID,
                        sysLogID),
                    strProcedureName);

                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        long partitioningKey = communityID * 10000 + 216;

                        // 从获取 T216LeafID 对应的 EntityID
                        object tmpResult = null;
                        Stb058 stb058Entity = null;

                        WriteLog.Instance.Write(
                            string.Format("获取 LeafID={0} 的工序信息", t216LeafID),
                            strProcedureName);
                        tmpResult = conn.Get<Stb058>(new Stb058
                        {
                            PartitioningKey = partitioningKey,
                            LeafID = t216LeafID
                        });
                        if (tmpResult == null)
                        {
                            errCode = 98001;
                            errText = string.Format("没有 LeafID = {0} 的工序信息", t216LeafID);
                            WriteLog.Instance.Write(errText, strProcedureName);
                            return Json(rlt);
                        }
                        else
                        {
                            stb058Entity = tmpResult as Stb058;
                        }

                        WriteLog.Instance.Write(
                            string.Format("获取 EntityID={0} 的工序一般信息", stb058Entity.EntityID),
                            strProcedureName);
                        tmpResult = conn.Get<GenAttr_ProcessOperation>(new GenAttr_ProcessOperation()
                        {
                            PartitioningKey = partitioningKey,
                            EntityID = stb058Entity.EntityID
                        });
                        if (tmpResult == null)
                        {
                            errCode = 98001;
                            errText = string.Format("没有 LeafID = {0} 的工序一般属性", t216LeafID);
                            WriteLog.Instance.Write(errText, strProcedureName);
                            return Json(rlt);
                        }
                        else
                        {
                            rlt = ((GenAttr_ProcessOperation)tmpResult);
                        }

                        errCode = 0;
                        errText = string.Format("获得 LeafID = {0} 的工序一般属性", t216LeafID);
                        return Json(rlt);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 ufn_GetProcessOperationGenAttr 函数发生异常：{0}\n{1}",
                            error.Message,
                            error.StackTrace);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    return Json(rlt);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }

        /// <summary>
        /// 获取注册测量仪表清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <returns>List[RegInstrument]</returns>
        public IRAPJsonResult ufn_GetList_RegInstruments(
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
                List<RegInstrument> datas = new List<RegInstrument>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_RegInstruments，" +
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
                            "FROM IRAPMDM..ufn_GetList_RegInstruments(" +
                            "@CommunityID) ORDER BY Ordinal";

                        IList<RegInstrument> lstDatas =
                            conn.CallTableFunc<RegInstrument>(strSQL, paramList);
                        datas = lstDatas.ToList<RegInstrument>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPMDM..ufn_GetList_RegInstruments 函数发生异常：{0}",
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
        /// 获取工位SPC监控情况
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="filterString">根据工位代码进行过滤</param>
        /// <returns>List[WIPStationSPCMonitor]</returns>
        public IRAPJsonResult ufn_GetList_WIPStationSPCMonitor(
            int communityID,
            long sysLogID,
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
                List<WIPStationSPCMonitor> datas = new List<WIPStationSPCMonitor>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_WIPStationSPCMonitor，" +
                        "参数：CommunityID={0}|SysLogID={1}|FilterString={2}",
                        communityID,
                        sysLogID,
                        filterString),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string filter = "";
                        if (filterString != "")
                            filter = string.Format("WHERE T107Code='{0}' ", filterString);

                        string strSQL = 
                            string.Format(
                                "SELECT * " +
                                "FROM IRAPMDM..ufn_GetList_WIPStationSPCMonitor(" +
                                "@CommunityID, @SysLogID) {0}ORDER BY Ordinal",
                                filter);
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<WIPStationSPCMonitor> lstDatas =
                            conn.CallTableFunc<WIPStationSPCMonitor>(strSQL, paramList);
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
                        "调用 IRAPMDM..ufn_GetList_WIPStationSPCMonitor 函数发生异常：{0}",
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
        /// 获取产品质量问题一点课资料
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="shotTime">时间(空串表示最新版本)</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[OnePointLesson]</returns>
        public IRAPJsonResult ufn_GetList_OnePointLessons(
            int communityID,
            int t102LeafID,
            string shotTime,
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
                List<OnePointLesson> datas = new List<OnePointLesson>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_OnePointLessons，" +
                        "参数：CommunityID={0}|T102LeafID={1}|ShotTime={2}|"+
                        "SysLogID={3}",
                        communityID,
                        t102LeafID,
                        shotTime,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                                "SELECT * " +
                                "FROM IRAPMDM..ufn_GetList_OnePointLessons(" +
                                "@CommunityID, @T102LeafID, @ShotTime, @SysLogID) "+
                                "ORDER BY Ordinal";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<OnePointLesson> lstDatas =
                            conn.CallTableFunc<OnePointLesson>(strSQL, paramList);
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
                        "调用 IRAPMDM..ufn_GetList_OnePointLessons 函数发生异常：{0}",
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
        /// 获取质量问题一点课受训者名录
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="issueNo">问题编号</param>
        /// <param name="shotTime">时间（空串标识最新版本）</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[OPLTrainee]</returns>
        public IRAPJsonResult ufn_GetList_OPLTrainees(
            int communityID,
            int t102LeafID,
            int issueNo,
            string shotTime,
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
                List<OPLTrainee> datas = new List<OPLTrainee>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@IssueNo", DbType.Int32, issueNo));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_OPLTrainees，" +
                        "参数：CommunityID={0}|T102LeafID={1}|IssueNo={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        issueNo,
                        shotTime,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                                "SELECT * " +
                                "FROM IRAPMDM..ufn_GetList_OPLTrainees(" +
                                "@CommunityID, @T102LeafID, @IssueNo, "+
                                "@ShotTime, @SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<OPLTrainee> lstDatas =
                            conn.CallTableFunc<OPLTrainee>(strSQL, paramList);
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
                        "调用 IRAPMDM..ufn_GetList_OPLTrainees 函数发生异常：{0}",
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
        /// 获取操作工技能矩阵
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t134LeafID">产线叶标识</param>
        /// <param name="shotTime">日期时间，空串表示最新</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[OperatorSkillMatrix]</returns>
        public IRAPJsonResult ufn_GetSkillMatrix_Operators(
            int communityID,
            int t102LeafID,
            int t134LeafID,
            string shotTime,
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
                List<OperatorSkillMatrix> datas = new List<OperatorSkillMatrix>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T134LeafID", DbType.Int32, t134LeafID));
                paramList.Add(new IRAPProcParameter("@ShotTime", DbType.String, shotTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetSkillMatrix_Operators，" +
                        "参数：CommunityID={0}|T102LeafID={1}|T134LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t134LeafID,
                        shotTime,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                                "SELECT * " +
                                "FROM IRAPMDM..ufn_GetSkillMatrix_Operators(" +
                                "@CommunityID, @T102LeafID, @T134LeafID, " +
                                "@ShotTime, @SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<OperatorSkillMatrix> lstDatas =
                            conn.CallTableFunc<OperatorSkillMatrix>(strSQL, paramList);
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
                        "调用 IRAPMDM..ufn_GetSkillMatrix_Operators 函数发生异常：{0}",
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
        /// 从系统登录标识获取公司名称
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>string</returns>
        public IRAPJsonResult sfn_GetCompanyName(
            int communityID, 
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
                string rlt = "";

                try
                {
                    #region 创建数据库调用参数组，并赋值
                    IList<IDataParameter> paramList = new List<IDataParameter>();
                    paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                    paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                    WriteLog.Instance.Write(string.Format("执行函数 IRAPMDM..sfn_GetCompanyName，参数：" +
                            "CommunityID={0}|SysLogID={1}",
                            communityID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行数据库函数或存储过程
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        rlt = (string)conn.CallScalarFunc("IRAPMDM.dbo.sfn_GetCompanyName", paramList);

                        errCode = 0;
                        errText = string.Format("调用成功，获得值： [{0}]", rlt);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                    #endregion
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMDM.dbo.sfn_GetCompanyName 时发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取公司Logo图像的Base64编码
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult sfn_GetImage_CompanyLogo(
            int communityID, 
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
                string rlt = "";

                try
                {
                    #region 创建数据库调用参数组，并赋值
                    IList<IDataParameter> paramList = new List<IDataParameter>();
                    paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                    paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                    WriteLog.Instance.Write(string.Format("执行函数 IRAPMDM..sfn_GetImage_CompanyLogo，参数：" +
                            "CommunityID={0}|SysLogID={1}",
                            communityID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行数据库函数或存储过程
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        rlt = (string)conn.CallScalarFunc("IRAPMDM.dbo.sfn_GetImage_CompanyLogo", paramList);

                        errCode = 0;
                        errText = "调用成功。";
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                    #endregion
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMDM.dbo.sfn_GetImage_CompanyLogo 时发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetList_KPIsToMonitor(
            int communityID, 
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
                List<KPIToMonitor> datas = new List<KPIToMonitor>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_KPIsToMonitor，" +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                                "SELECT * " +
                                "FROM IRAPMDM..ufn_GetList_KPIsToMonitor(" +
                                "@CommunityID, @SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<KPIToMonitor> lstDatas =
                            conn.CallTableFunc<KPIToMonitor>(strSQL, paramList);
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
                        "调用 IRAPMDM..ufn_GetList_KPIsToMonitor 函数发生异常：{0}",
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
        /// 获取产品供给客户清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[CustomerOfAProduction]</returns>
        public IRAPJsonResult ufn_GetList_CustomerProduct(
            int communityID, 
            string t102Code, 
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
                List<CustomerOfAProduction> datas = new List<CustomerOfAProduction>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102Code", DbType.String, t102Code));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_CustomerProduct，" +
                        "参数：CommunityID={0}|T102Code={1}|SysLogID={2}",
                        communityID,
                        t102Code,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                                "SELECT * " +
                                "FROM IRAPMDM..ufn_GetList_CustomerProduct(" +
                                "@CommunityID, @T102Code, @SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<CustomerOfAProduction> lstDatas =
                            conn.CallTableFunc<CustomerOfAProduction>(strSQL, paramList);
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
                        "调用 IRAPMDM..ufn_GetList_CustomerProduct 函数发生异常：{0}",
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

        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID"></param>
        /// <param name="t105LeafID">客户叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[AvailableSite]</returns>
        public IRAPJsonResult ufn_GetList_AvaiableSite(
            int communityID,
            int t102LeafID,
            int t105LeafID,
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
                List<AvailableSite> datas = new List<AvailableSite>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T105LeafID", DbType.Int32, t105LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_AvaiableSite，" +
                        "参数：CommunityID={0}|T102LeafID={1}|T105LeafID={2}|"+
                        "SysLogID={3}",
                        communityID,
                        t102LeafID,
                        t105LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                                "SELECT * " +
                                "FROM IRAPMDM..ufn_GetList_AvaiableSite(" +
                                "@CommunityID, @T102LeafID, @T105LeafID, @SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<AvailableSite> lstDatas =
                            conn.CallTableFunc<AvailableSite>(strSQL, paramList);
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
                        "调用 IRAPMDM..ufn_GetList_AvaiableSite 函数发生异常：{0}",
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

        /// <param name="communityID">社区标识</param>
        /// <param name="t117LeafID">标签叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetInfo_TemplateFMTStr(
            int communityID, 
            int t117LeafID, 
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
                TemplateContent data = new TemplateContent();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T117LeafID", DbType.Int32, t117LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetInfo_TemplateFMTStr，" +
                        "参数：CommunityID={0}|T117LeafID={1}|SysLogID={2}",
                        communityID, t117LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetInfo_TemplateFMTStr(" +
                            "@CommunityID, @T117LeafID, @SysLogID)";

                        IList<TemplateContent> lstDatas = 
                            conn.CallTableFunc<TemplateContent>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = "调用成功！";
                        }
                        else
                        {
                            errCode = -99001;
                            errText = string.Format("没有标识号为[{0}]的模板信息。", t117LeafID);
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMDM..ufn_GetInfo_TemplateFMTStr 函数发生异常：{0}", error.Message);
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
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="opType">操作类型：A-新增；U-修改；D-删除</param>
        /// <param name="srcLeafID">117树叶标识（修改时传入被修改叶标识；新增传入参考模板叶标识）</param>
        /// <param name="code">节点代码</param>
        /// <param name="alternateCode">节点替代代码</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="attrChangeXML">标签模板内容</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="newLeafID">新标签模板标识</param>
        public IRAPJsonResult usp_SaveFact_IRAP117Node(
            int communityID, 
            int treeID, 
            string opType, 
            int srcLeafID, 
            string code, 
            string alternateCode, 
            string nodeName, 
            string attrChangeXML, 
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
                paramList.Add(new IRAPProcParameter("@TreeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@OpType", DbType.String, opType));
                paramList.Add(new IRAPProcParameter("@SrcLeafID", DbType.Int32, srcLeafID));
                paramList.Add(new IRAPProcParameter("@Code", DbType.String, code));
                paramList.Add(new IRAPProcParameter("@AlternateCode", DbType.String, alternateCode));
                paramList.Add(new IRAPProcParameter("@NodeName", DbType.String, nodeName));
                paramList.Add(new IRAPProcParameter("@AttrChangeXML", DbType.String, attrChangeXML));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@NewLeafID", DbType.Int32, ParameterDirection.Output, 4));
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
                    string.Format("执行存储过程 IRAPMDM..usp_SaveFact_IRAP117Node，参数：" +
                        "CommunityID={0}|TreeID={1}|OpType={2}|SrcLeafID={3}|" +
                        "Code={4}|AlternateCode={5}|NodeName={6}|AttrChangeXML={7}|"+
                        "SysLogID={8}",
                        communityID, treeID, opType, srcLeafID, code, alternateCode,
                        nodeName, attrChangeXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPMDM..usp_SaveFact_IRAP117Node", ref paramList);
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
                        "调用 IRAPMDM..usp_SaveFact_IRAP117Node 时发生异常：{0}", 
                        error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="correlationID">关联号</param>
        /// <param name="t117LeafID">标签模板叶标识</param>
        public IRAPJsonResult usp_SaveFact_C75(
            int communityID,
            long correlationID,
            int t117LeafID,
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
                paramList.Add(new IRAPProcParameter("@CorrelationID", DbType.Int64, correlationID));
                paramList.Add(new IRAPProcParameter("@T117LeafID", DbType.Int32, t117LeafID));
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
                    string.Format("执行存储过程 IRAPMDM..usp_SaveFact_C75，参数：" +
                        "CommunityID={0}|CorrelationID={1}|T117LeafID={2}",
                        communityID, correlationID, t117LeafID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPMDM..usp_SaveFact_C75", ref paramList);
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
                        "调用 IRAPMDM..usp_SaveFact_C75 时发生异常：{0}",
                        error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取产线其他支持人员清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t179LeafID">安灯事件类型叶标识</param>
        /// <param name="t107LeafID">触发呼叫工位叶标识</param>
        /// <param name="t133LeafID">触发呼叫设备叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetList_AndonCallPersons(
            int communityID,
            int t179LeafID,
            int t107LeafID,
            int t133LeafID,
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
                List<AndonCallPerson> datas = new List<AndonCallPerson>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T179LeafID", DbType.Int32, t179LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@T133LeafID", DbType.Int32, t133LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_AndonCallPersons，" +
                        "参数：CommunityID={0}|T179LeafID={1}|T107LeafID={2}" +
                        "T133LeafID={3}|SysLogID={4}",
                        communityID, t179LeafID, t107LeafID, t133LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_AndonCallPersons(" +
                            "@CommunityID, @T179LeafID, @T107LeafID, " +
                            "@T133LeafID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<AndonCallPerson> lstDatas =
                            conn.CallTableFunc<AndonCallPerson>(strSQL, paramList);
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
                            "调用 IRAPMDM..ufn_GetList_AndonCallPersons 函数发生异常：{0}",
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
        /// 获取指定产品指定工位可选产品失效模式清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        public IRAPJsonResult ufn_GetList_FailureModes(
            int communityID,
            int productLeaf,
            int workUnitLeaf,
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
                List<FailureMode> datas = new List<FailureMode>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_FailureModes，" +
                        "参数：CommunityID={0}|ProductLeaf={1}|WorkUnitLeaf={2}|" +
                        "SysLogID={4}",
                        communityID, productLeaf, workUnitLeaf, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_FailureModes(" +
                            "@CommunityID, @ProductLeaf, @WorkUnitLeaf, " +
                            "@SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<FailureMode> lstDatas =
                            conn.CallTableFunc<FailureMode>(strSQL, paramList);
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
                            "调用 IRAPMDM..ufn_GetList_FailureModes 函数发生异常：{0}",
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
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="skuID"></param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetInfo_SKUID(
            int communityID,
            string skuID,
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
                BWI_SKUIDInfo data = new BWI_SKUIDInfo();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SKUID", DbType.String, skuID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetInfo_SKUID，" +
                        "参数：CommunityID={0}|SKUID={1}|SysLogID={2}",
                        communityID, skuID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetInfo_SKUID(" +
                            "@CommunityID, @SKUID, @SysLogID)";

                        IList<BWI_SKUIDInfo> lstDatas = 
                            conn.CallTableFunc<BWI_SKUIDInfo>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = "调用成功！";
                        }
                        else
                        {
                            errCode = -99001;
                            errText = "没有当前站点的产线信息";
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = 
                        string.Format(
                            "调用 IRAPMDM..ufn_GetInfo_SKUID 函数发生异常：{0}", 
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
        /// 根据工位获取失效模式
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_WorkUnitFailureModes(
            int communityID,
            int t107LeafID,
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
                List<FailureModeByWorkUnit> datas = new List<FailureModeByWorkUnit>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_WorkUnitFailureModes，" +
                        "参数：CommunityID={0}|T107LeafID={1}|SysLogID={2}",
                        communityID, t107LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_WorkUnitFailureModes(" +
                            "@CommunityID, @T107LeafID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<FailureModeByWorkUnit> lstDatas =
                            conn.CallTableFunc<FailureModeByWorkUnit>(strSQL, paramList);
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
                            "调用 IRAPMDM..ufn_GetList_WorkUnitFailureModes 函数发生异常：{0}",
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
