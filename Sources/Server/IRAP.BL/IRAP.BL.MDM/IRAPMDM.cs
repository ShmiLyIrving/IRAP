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
using IRAP.Entity.IRAP;

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
                        "参数：CommunityID={0}|T102LeafID={1}|T216LeafID={2}"+
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
                        "参数：CommunityID={0}|T102LeafID={1}|ShotTime={2}|"+
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
                        "VoucherNo={4}|EffectiveTime={5}|DeleUnapplied={6}|"+
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
                        data = (int) conn.CallScalarFunc("IRAPMDM.dbo.ufn_GetMethodID", paramList);
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
                            "@CommunityID, @134LeafID, @T216LeafID, @T132LeafID, " +
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
    }
}
