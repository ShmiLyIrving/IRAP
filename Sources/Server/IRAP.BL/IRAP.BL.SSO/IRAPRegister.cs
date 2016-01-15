using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAPShared;
using IRAPORM;

namespace IRAP.BL.SSO
{
    public class IRAPRegister : IRAPBLLBase
    {
        private static string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPRegister()
        {
            WriteLog.Instance.WriteLogFileName = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 功能站点注册
        /// </summary>
        /// <param name="stationID">站点编号</param>
        /// <param name="communityID">社区标识</param>
        /// <param name="funcGroupID">功能组标识</param>
        /// <param name="templateSTN">模板站点号</param>
        public IRAPJsonResult ssp_RegistStation(string stationID, int communityID, int funcGroupID, string templateSTN, out int errCode, out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@StationID", DbType.String, stationID));
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@FuncGroupID", DbType.Int32, funcGroupID));
                paramList.Add(new IRAPProcParameter("@TemplateSTN", DbType.String, templateSTN));
                WriteLog.Instance.Write(string.Format("执行存储过程 IRAP..ssp_RegistStation，参数：StationID={0}|" +
                        "CommunityID={1}|FuncGroupID={2}|TemplateSTN={3}",
                        stationID, communityID, funcGroupID, templateSTN),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_RegistStation", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    return Json(error);
                }
                #endregion
            }
            catch (Exception err)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAP..ssp_RegistStation 函数发生异常：{0}", err.Message);
                return Json(new IRAPError()
                {
                    ErrCode = errCode,
                    ErrText = errText
                });
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
