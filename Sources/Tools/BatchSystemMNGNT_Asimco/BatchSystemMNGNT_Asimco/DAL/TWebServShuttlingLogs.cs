using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using IRAPORM;
using BatchSystemMNGNT_Asimco.Entities;

namespace BatchSystemMNGNT_Asimco
{
    public class TWebServShuttlingLogs
    {
        private static TWebServShuttlingLogs _instance = null;

        public static TWebServShuttlingLogs Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TWebServShuttlingLogs();
                return _instance;
            }
        }

        private List<TEntityCustomLog> logs = new List<TEntityCustomLog>();

        private TWebServShuttlingLogs() { }

        public List<TEntityCustomLog> Logs
        {
            get { return logs; }
        }

        private void ArrangeLogs(
            List<TEntityCustomLog> datas, 
            ref List<TEntityCustomLog> desDatas)
        {
            desDatas.Clear();

            foreach (TEntityCustomLog data in datas)
            {
                switch (data.ExCode)
                {
                    case "PICK08":
                        desDatas.Add(new TEntityPICK08(data));
                        break;
                    case "MORV00":
                        desDatas.Add(new TEntityMORV00(data));
                        break;
                    case "PORV01":
                        desDatas.Add(new TEntityPORV01(data));
                        break;
                    case "IMTR01":
                        desDatas.Add(new TEntityIMTR01(data));
                        break;
                    case "INVA01":
                        desDatas.Add(new TEntityINVA01(data));
                        break;
                    default:
                        desDatas.Add(data);
                        break;
                }
            }
        }

        public int GetLogs()
        {
            IList<IDataParameter> paramList = new List<IDataParameter>();

            try
            {
                using (IRAPSQLConnection conn = 
                    new IRAPSQLConnection(
                        SysParams.Instance.DBConnectionString))
                {
                    string strSQL =
                        "SELECT * FROM IRAP..stb_Log_WebServiceShuttling "+
                        "WHERE ErrCode!=0 AND Retried=0 ORDER BY LinkedLogID";
                    IList<TEntityCustomLog> lstDatas =
                        conn.CallTableFunc<TEntityCustomLog>(strSQL, paramList);

                    ArrangeLogs(lstDatas.ToList(), ref logs);
                }
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"]= 
                    string.Format(
                        "获取 IRAP..stb_Log_WebServiceShuttling 表的记录时发生异常：{0}",
                        error.Message);
                throw error;
            }

            return logs.Count;
        }

        public int GetLogs(
            string linkedLogID,
            string itemNumber,
            string lotNumber,
            string orderNo,
            string orderLineNo,
            bool failureOnly)
        {
            IList<IDataParameter> paramList = new List<IDataParameter>();

            try
            {
                string strSQL =
                    "SELECT * FROM IRAP..stb_Log_WebServiceShuttling " +
                    "{0}{1} ORDER BY LinkedLogID, LogID";
                string strCondition = "";

                if (linkedLogID.Trim() != "")
                    strCondition = string.Format("LinkedLogID={0}", linkedLogID);

                if (itemNumber.Trim() != "")
                {
                    if (strCondition != "")
                        strCondition += " AND ";
                    strCondition +=
                        string.Format(
                            "(ExChangeXML.value('(/Parameters/Param/@ItemNumber)[1]','varchar(20)') LIKE '%{0}%')",
                            itemNumber);
                }

                if (lotNumber.Trim() != "")
                {
                    if (strCondition != "")
                        strCondition += " AND ";
                    strCondition +=
                        string.Format(
                            "((ExChangeXML.value('(/Parameters/Param/@LotNumber)[1]','varchar(50)') LIKE '%{0}%') OR " +
                            " (ExChangeXML.value('(/Parameters/Param/@LotNumberDefault)[1]','varchar(50)') LIKE '%{0}%') OR " +
                            " (ExChangeXML.value('(/Parameters/Param/@LotNumberFrom)[1]','varchar(50)') LIKE '%{0}%'))",
                            lotNumber);
                }

                if (orderNo.Trim() != "")
                {
                    if (strCondition != "")
                        strCondition += " AND ";
                    strCondition +=
                        string.Format(
                            "(ExChangeXML.value('(/Parameters/Param/@PONumber)[1]','varchar(50)') LIKE '%{0}%' OR " +
                            " ExChangeXML.value('(/Parameters/Param/@OrderNumber)[1]','varchar(50)') LIKE '%{0}%' OR " +
                            " ExChangeXML.value('(/Parameters/Param/@MONumber)[1]','varchar(50)') LIKE '%{0}%')",
                            orderNo);
                }

                if (orderLineNo.Trim() != "")
                {
                    if (strCondition != "")
                        strCondition += " AND ";
                    strCondition +=
                        string.Format(
                            "(ExChangeXML.value('(/Parameters/Param/@POLineNumber)[1]','varchar(50)') LIKE '%{0}%' OR " +
                            " ExChangeXML.value('(/Parameters/Param/@OrderLineNumber)[1]','varchar(50)') LIKE '%{0}%' OR " +
                            " ExChangeXML.value('(/Parameters/Param/@MOLineNumber)[1]','varchar(50)') LIKE '%{0}%')",
                            orderLineNo);
                }

                if (failureOnly)
                {
                    if (strCondition != "")
                        strCondition += " AND ";
                    strCondition += "(ErrCode!=0 AND Retried=0)";
                }

                if (strCondition != "")
                    strSQL = string.Format(strSQL, "WHERE ", strCondition);
                else
                    strSQL = string.Format(strSQL, "", "");

                using (IRAPSQLConnection conn=
                    new IRAPSQLConnection(SysParams.Instance.DBConnectionString))
                {
                    strSQL = string.Format(strSQL, strCondition);
                    IList<TEntityCustomLog> lstDatas =
                        conn.CallTableFunc<TEntityCustomLog>(strSQL, paramList);

                    List<TEntityCustomLog> tempDatas = new List<TEntityCustomLog>();
                    ArrangeLogs(lstDatas.ToList(), ref tempDatas);

                    logs = tempDatas;
                    return tempDatas.Count;
                }
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] =
                    string.Format(
                        "获取 IRAP..stb_Log_WebServiceShuttling 表的记录时发生异常：{0}",
                        error.Message);
                throw error;
            }
        }
    }
}
