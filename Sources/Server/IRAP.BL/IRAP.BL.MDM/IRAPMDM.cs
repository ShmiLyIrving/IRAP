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
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ssp_NewIRAPTreeNode()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ssp_AlterNodeName()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ssp_AlterCode()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ssp_DeleIRAPTreeNode()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ssp_ClassifyAttributeFor132()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取排产优先级分类属性下拉列表
        /// </summary>
        public IRAPJsonResult mfn_GetList_T213ClassifyAttribute(out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult mfn_GetTreeList_ProductSeries(long sysLogID, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult mfn_GetTreeList_Products(long sysLogID, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ssp_ClassifyAttributeFor102()
        {
            throw new System.NotImplementedException();
        }

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

        public IRAPJsonResult ufn_GetList_ProcessSegmentsOfAProduct()
        {
            throw new System.NotImplementedException();
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

        public IRAPJsonResult ufn_GetProductName()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ufn_GetList_OptionCode()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ufn_GetList_ProductionLinesOfProduct()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ufn_GetList_DstDeliveryStoreSites()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ufn_GetList_MethodStandard()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ufn_GetList_QualityStandard()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ufn_GetList_AndonEventTypes()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ufn_GetList_StationBoundProductionLines()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult usp_SwitchToProductionLine()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ufn_GetList_AndonCallObjects()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ufn_GetList_ProcessOperations()
        {
            throw new System.NotImplementedException();
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
                int data = 0;

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@TreeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@LeafID", DbType.Int32, leafID));
                paramList.Add(new IRAPProcParameter("@UnixTime", DbType.Int32, unixTime));
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
    }
}
