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
    }
}
