using IRAP.Entity.UTS;
using IRAP.Global;
using IRAPORM;
using IRAPShared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IRAP.BL.UTS {
    public class GeneralImport : IRAPBLLBase {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public GeneralImport() {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取导入导出关联的树及其叶选择提示信息 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t19LeafID">导入导出叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns></returns>
        public IRAPJsonResult sfn_GetInfo_LinkedTreeOfImpExp(int communityID,int t19LeafID,long sysLogID,out int errCode,
            out string errText) {
            string strProcedureName =string.Format("{0}.{1}",className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                List<LinkedTreeTip> datas = new List<LinkedTreeTip>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T19LeafID", DbType.Int32, t19LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetInfo_LinkedTreeOfImpExp，" +
                        "参数：CommunityID={0}|T19LeafID={1}|SysLogID={2}",
                        communityID, t19LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_GetInfo_LinkedTreeOfImpExp(" +
                            "@CommunityID, @T19LeafID, @SysLogID)";

                        IList<LinkedTreeTip> lstDatas = conn.CallTableFunc<LinkedTreeTip>(strSQL, paramList);
                        datas = lstDatas.ToList<LinkedTreeTip>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_GetInfo_LinkedTreeOfImpExp 函数发生异常：{0}", error.Message);
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
