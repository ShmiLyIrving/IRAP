using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using IRAPORM;
using IRAPShared;

namespace BatchSystemMNGNT_Asimco
{
    public class TBLStockDetails
    {
        private static List<Entities.TTableStockDetail> GetDataRecord(
            string strSQL,
            IList<IDataParameter> paramList)
        {
            try
            {
                using (IRAPSQLConnection conn =
                    new IRAPSQLConnection(SysParams.Instance.DBConnectionString))
                {
                    IList<Entities.TTableStockDetail> lstDatas =
                        conn.CallTableFunc<Entities.TTableStockDetail>(strSQL, paramList);

                    return lstDatas.ToList();
                }
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] =
                    string.Format(
                        "在获取四班库存记录时发生错误：[{0}]",
                        error.Message);
                throw error;
            }
        }

        public static List<Entities.TTableStockDetail> Get(
            string itemNumber,
            string lotNumber)
        {
            string strSQL =
                "SELECT * FROM ERP.FSDBMR.dbo.StockDetail " +
                "WHERE STK_ROOM=@STK_ROOM AND ITEM=@ITEM AND {0} " +
                "ORDER BY LOT";
            IList<IDataParameter> paramList = new List<IDataParameter>();

            if (lotNumber.Length == 14)
                strSQL = string.Format(strSQL, "LOT=@LOT");
            else
                strSQL = string.Format(strSQL, "LOT LIKE @LOT");

            paramList.Add(new IRAPProcParameter("@STK_ROOM", DbType.String, "28"));
            paramList.Add(new IRAPProcParameter("@ITEM", DbType.String, itemNumber));
            paramList.Add(new IRAPProcParameter("@LOT", DbType.String, lotNumber));

            try
            {
                List<Entities.TTableStockDetail> rlt =
                        GetDataRecord(strSQL, paramList);
                return rlt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
