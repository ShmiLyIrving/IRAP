using IRAP.Entities.IRAP;
using IRAP.Entities.MES;
using IRAP.Global;
using IRAPORM;
using IRAPShared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IRAP.BL.MES {
    public class SmeltingProduction :IRAPBLLBase {

        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public SmeltingProduction() {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        #region Debug
        /// <summary>
        /// 获取测试用的登录标识
        /// </summary>
        /// <returns></returns>
        private int GetSysLogID() {
            try {
                using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                    string strSQL = "SELECT  TOP 1 SysLogID,*FROM IRAP..stb009 WHERE PartitioningKey=600300000  AND UserCode='0000001'"
                    + "  ORDER BY LoginTime DESC";

                    return (int)conn.CallScalar(strSQL);
                }
            } catch (Exception) {
                return 0;
            }
        }
    
        #endregion

        /// <summary>
        /// 获取信息站点上下文(工位或工作流结点功能信息)
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_WIPStationsOfAHost(int communityID,long sysLogID, out int errCode,
            out string errText) {
            //todo:删除此句
                sysLogID = GetSysLogID();
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                List<ProductionParam> datas = new List<ProductionParam>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_WIPStationsOfAHost，" +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_WIPStationsOfAHost(" +
                            "@CommunityID, @SysLogID)";

                        IList<ProductionParam> lstDatas = conn.CallTableFunc<ProductionParam>(strSQL, paramList);
                        datas = lstDatas.ToList<ProductionParam>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMDM..ufn_GetList_WIPStationsOfAHost 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
