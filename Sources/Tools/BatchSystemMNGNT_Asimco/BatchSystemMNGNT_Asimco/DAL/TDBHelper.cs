using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using IRAPORM;
using IRAPShared;
using BatchSystemMNGNT_Asimco.Entities;

namespace BatchSystemMNGNT_Asimco.DAL
{
    public class TDBHelper
    {
        public static List<TTableMaterialStore> GetMaterialStore(string skuID)
        {
            try
            {
                using (IRAPSQLConnection conn =
                    new IRAPSQLConnection(SysParams.Instance.DBConnectionString))
                {
                    IList<IDataParameter> paramList = new List<IDataParameter>();
                    paramList.Add(new IRAPProcParameter("@SKUID", DbType.String, skuID));

                    IList<TTableMaterialStore> lstDatas =
                        conn.CallTableFunc<TTableMaterialStore>(
                            "SELECT * FROM IRAPRIMCS..utb_MaterialStore " +
                            "WHERE SKUID=@SKUID",
                            paramList);

                    return lstDatas.ToList();
                }
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] =
                    string.Format(
                        "获取 SKUID[{0}] 物料的记录时发生异常：{1}",
                        skuID,
                        error.Message);
                throw error;
            }
        }

        public static List<TTableRSFactPWOMaterialTrack> GetMaterialTrack(
            string skuID,
            string moNumber,
            int moLineNo)
        {
            try
            {
                using (IRAPSQLConnection conn =
                    new IRAPSQLConnection(SysParams.Instance.DBConnectionString))
                {
                    IList<IDataParameter> paramList = new List<IDataParameter>();
                    paramList.Add(new IRAPProcParameter("@MONumber", DbType.String, moNumber));
                    paramList.Add(new IRAPProcParameter("@MOLineNo", DbType.Int32, moLineNo));
                    paramList.Add(new IRAPProcParameter("@SKUID", DbType.String, skuID));

                    IList<TTableRSFactPWOMaterialTrack> lstDatas =
                        conn.CallTableFunc<TTableRSFactPWOMaterialTrack>(
                            "SELECT A.* FROM IRAPMES..RSFact_PWOMaterialTrack A " +
                            "INNER JOIN IRAPMES..AuxFact_PWOIssuing B " +
                            "ON A.WFInstanceID=B.WFInstanceID AND B.MONumber=@MONumber AND " +
                            "B.MOLineNo=@MOLineNo AND A.SKUID=@SKUID",
                            paramList);

                    return lstDatas.ToList();
                }
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] =
                    string.Format(
                        "获取订单号[{0}]行号[{1}]的提料记录时发生异常：{2}",
                        moNumber,
                        moLineNo,
                        error.Message);
                throw error;
            }
        }

        public static void UpdateMaterialTrack(
            TTableRSFactPWOMaterialTrack row)
        {
            try
            {
                using (IRAPSQLConnection conn =
                    new IRAPSQLConnection(SysParams.Instance.DBConnectionString))
                {
                    conn.UpdateTable("IRAPMES..RSFact_PWOMaterialTrack", row);
                }
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] =
                    string.Format(
                        "更新工单号[{0}]，SKUID[{1}的提料数据时发生异常：{2}",
                        row.WFInstanceID,
                        row.SKUID,
                        error.Message);
                throw error;
            }
        }

        public static TEntityCustomLog GetLastUnsuccessedLogWithLinkedLogID(
            long linkedLogID)
        {
            try
            {
                using (IRAPSQLConnection conn =
                    new IRAPSQLConnection(SysParams.Instance.DBConnectionString))
                {
                    IList<IDataParameter> paramList = new List<IDataParameter>();
                    paramList.Add(new IRAPProcParameter("@LinkedLogID", DbType.Int64, linkedLogID));

                    IList<TEntityCustomLog> lstDatas =
                        conn.CallTableFunc<TEntityCustomLog>(
                            "SELECT * FROM IRAP..stb_Log_WebServiceShuttling " +
                            "WHERE LinkedLogID=@LinkedLogID AND ErrCode!=0 AND Retried=0",
                            paramList);

                    if (lstDatas.Count > 0)
                        return lstDatas[0];
                    else
                        return null;
                }
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] =
                    string.Format(
                        "获取 WebService 日志时发生异常：{0}",
                        error.Message);
                throw error;
            }
        }

        public static void UpdateMaterialStore(TTableMaterialStore row)
        {
            try
            {
                using (IRAPSQLConnection conn =
                    new IRAPSQLConnection(SysParams.Instance.DBConnectionString))
                {
                    conn.UpdateTable("IRAPRIMCS..utb_MaterialStore", row);
                }
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] =
                    string.Format(
                        "更新 SKUID[{0} 物料的库存数据时发生异常：{1}",
                        row.SKUID,
                        error.Message);
                throw error;
            }
        }
    }
}
