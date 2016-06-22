using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.MES;
using IRAPORM;
using IRAPShared;

namespace IRAP.BL.MES
{
    public class QC : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public QC()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取质量控制点序号
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <returns>质量控制点序号[int]</returns>
        public IRAPJsonResult ufn_GetQCCheckPointOrdinal(
            int communityID, 
            int t102LeafID, 
            int t107LeafID, 
            string pwoNo, 
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
                int rlt = 0;

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.String, t107LeafID));
                paramList.Add(new IRAPProcParameter("@PWONo", DbType.String, pwoNo));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES.dbo.ufn_GetQCCheckPointOrdinal，参数：" +
                        "CommunityID={0}|T102LeafID={1}|T107LeafID={2}|PWONo={3}",
                        communityID,
                        t102LeafID,
                        t107LeafID,
                        pwoNo),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        rlt = (int) conn.CallScalarFunc("IRAPMES.dbo.ufn_GetQCCheckPointOrdinal", paramList);
                        if (rlt > -2147483648)
                        {
                            errCode = 0;
                            errText = string.Format("调用成功！获得 QCCheckPointOrdinal={0}", rlt);
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                        else
                        {
                            errCode = 99999;
                            errText = "未得到 QCCheckPointOrdinal 的值";
                        }
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMES.dbo.ufn_GetQCCheckPointOrdinal 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }

        /// <summary>
        /// 获取SPC控制图信息：⒈ 支持彩虹图；⒉ 支持Xbar-R图
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="t47LeafID">SPC控制图类型代码：373564-彩虹图；373565-Xbar-R图</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t133LeafID">设备叶标识</param>
        /// <param name="t20LeafID">工艺参数叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetInfo_SPCChart(
            int communityID, 
            string pwoNo, 
            int t47LeafID, 
            int t216LeafID, 
            int t133LeafID, 
            int t20LeafID, 
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
                EntitySPCChart rlt = new EntitySPCChart();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("PWONo", DbType.String, pwoNo));
                paramList.Add(new IRAPProcParameter("T47LeafID", DbType.Int32, t47LeafID));
                paramList.Add(new IRAPProcParameter("T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T133LeafID", DbType.Int32, t133LeafID));
                paramList.Add(new IRAPProcParameter("@T20LeafID", DbType.String, t20LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES.dbo.ufn_GetInfo_SPCChart，参数：" +
                        "CommunityID={0}|PWONo={1}|T47LeafID={2}|T216LeafID={3}" +
                        "T133LeafID={4}|T20LeafID={5}|SysLogID={6}",
                        communityID,
                        pwoNo,
                        t47LeafID,
                        t216LeafID,
                        t133LeafID,
                        t20LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string sqlCmd = "SELECT * FROM IRAPMES..ufn_GetInfo_SPCChart(" +
                            "@CommunityID, @PWONo, @T47LeafID, @T216LeafID, @T133LeafID, " +
                            "@T20LeafID, @SysLogID)";
                        IList<EntitySPCChart> objs = 
                            conn.CallTableFunc<EntitySPCChart>(sqlCmd, paramList);
                        if (objs != null && objs.Count > 0)
                        {
                            rlt = objs[0].Clone();

                            errCode = 0;
                            errText = "调用成功！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                        else
                        {
                            errCode = 99999;
                            errText = "未得到 SPC 控制图信息";
                        }
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMES.dbo.ufn_GetInfo_SPCChart 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }
    }
}