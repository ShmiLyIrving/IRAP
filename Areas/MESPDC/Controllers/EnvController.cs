using IRAPORM;
using IRAPShared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MESPDC.Areas.MESPDC.Controllers
{
    public class EnvController : Controller
    {
        public int CommunityID
        {
            get
            {
                if (Session != null && Session["CommunityID"] != null)
                {
                    return int.Parse(Session["CommunityID"].ToString());
                }
                else
                {
                    return 60023;
                }
            }
        }
        public long SysLogID
        {
            get
            {
                if (Session != null && Session["SysLogID"] != null)
                {
                    return long.Parse(Session["SysLogID"].ToString());
                }
                else
                {
                    return 749830;
                }
            }
        }
        public string UserCode
        {

            // Session["SystemName"] = systemName;
            //  Session["SystemID"] = systemID;
            //  Session["Area"] = oneSystem.Application;
            // Session["UserCode"] = model.UserCode;
            //  Session["AgencyLeaf"] = model.AgencyLeaf;
            //  Session["RoleLeaf"] = model.RoleLeaf;
            get
            {
                if (Session["UserCode"] != null)
                {
                    return Session["UserCode"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public int LanguageID
        {
            get
            {
                if (Session["LanguageID"] != null)
                {
                    return int.Parse(Session["LanguageID"].ToString());
                }
                else
                {
                    return 0;
                }
            }
        }

        protected long GetFactID(int count, out int errCode, out string errText)
        {
            try
            {
                IRAPSQLConnection conn = new IRAPSQLConnection();

                IList<IDataParameter> oraParam = new List<IDataParameter>();
                oraParam.Add(new IRAPProcParameter("CommunityID", DbType.Int32, CommunityID));
                oraParam.Add(new IRAPProcParameter("Count", DbType.Int32, count));

                string FactID =
                    conn.CallScalar("SELECT IRAP.dbo.sfn_GetSequenceNo(@CommunityID,'NextFactNo',@Count)", oraParam)
                        .ToString();
                conn.Close();

                errCode = 0;
                errText = "成功";

                return long.Parse(FactID);
            }
            catch (Exception e)
            {
                errCode = 9999;
                errText = e.Message;

                return -1;
            }
        }



        protected long GetUDFLogID(int count, out int errCode, out string errText)
        {
            try
            {
                IRAPSQLConnection conn = new IRAPSQLConnection();

                IList<IDataParameter> oraParam = new List<IDataParameter>();
                oraParam.Add(new IRAPProcParameter("CommunityID", DbType.Int32, CommunityID));
                oraParam.Add(new IRAPProcParameter("Count", DbType.Int32, count));

                string UDFLogID =
                    conn.CallScalar("SELECT IRAP.dbo.sfn_GetSequenceNo(@CommunityID,'NextUDFLogID',@Count)", oraParam)
                        .ToString();
                conn.Close();

                errCode = 0;
                errText = "成功";

                return long.Parse(UDFLogID);
            }
            catch (Exception e)
            {
                errCode = 9999;
                errText = e.Message;

                return -1;
            }
        }

        protected long GetTransactNo(string opNode, out int errCode, out string errText)
        {
            try
            {
                long CommunityID = this.CommunityID;
                long SysLogID = this.SysLogID;

                IRAPSQLConnection conn = new IRAPSQLConnection();
                IList<IDataParameter> checkFileNameParamSql = new List<IDataParameter>();
                checkFileNameParamSql.Add(new IRAPProcParameter("CommunityID", DbType.Int32, CommunityID));
                checkFileNameParamSql.Add(new IRAPProcParameter("SequenceCode", DbType.String, "NextTransactNo"));
                checkFileNameParamSql.Add(new IRAPProcParameter("Count", DbType.Int32, 1));
                checkFileNameParamSql.Add(new IRAPProcParameter("SysLogID", DbType.Int64, SysLogID));
                checkFileNameParamSql.Add(new IRAPProcParameter("OpNode", DbType.String, opNode));
                checkFileNameParamSql.Add(new IRAPProcParameter("VoucherNo", DbType.String, ""));
                checkFileNameParamSql.Add(new IRAPProcParameter("SequenceNo", DbType.Int64, ParameterDirection.Output, 8));
                checkFileNameParamSql.Add(new IRAPProcParameter("ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                checkFileNameParamSql.Add(new IRAPProcParameter("ErrText", DbType.String, ParameterDirection.Output, 400));
                IRAPError err = conn.CallProc("IRAP..ssp_GetSequenceNo", ref checkFileNameParamSql);
                conn.Close();

                if (err.ErrCode == 0)
                {
                    errCode = int.Parse(checkFileNameParamSql[7].Value.ToString());
                    errText = checkFileNameParamSql[8].Value.ToString();
                    return long.Parse(checkFileNameParamSql[6].Value.ToString());
                }
                else
                {
                    errCode = err.ErrCode;
                    errText = err.ErrText;
                    return -1;
                }

            }
            catch (Exception e)
            {
                errCode = 9999;
                errText = e.Message;

                return -1;
            }
        }
        #region 导出Excel

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public DataTable GetExcelExport_List(Hashtable dict, out int errCode, out string errText)
        {
            string querySql = string.Empty;
            try
            {
                if (!dict.ContainsKey("QuerySql"))
                {
                    errCode = 9999;
                    errText = "必须传入QuerySql参数";
                    new DataTable("TB1");
                }
                querySql = dict["QuerySql"].ToString();

                IRAPSQLConnection conn = new IRAPSQLConnection();
                DataTable list1 = conn.QuerySQL(querySql);
                errCode = 0;
                errText = "返回成功！";
                conn.Close();
                return list1;
            }
            catch (Exception err)
            {
                errText = querySql + err.Message;
                errCode = 9999;
                return new DataTable("table1");

            }

        }
        #endregion
	}
}