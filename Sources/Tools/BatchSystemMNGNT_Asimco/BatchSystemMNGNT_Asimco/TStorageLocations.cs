using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using IRAPORM;
using BatchSystemMNGNT_Asimco.Entities;

namespace BatchSystemMNGNT_Asimco
{
    public class TStorageLocations
    {
        private static TStorageLocations _instance = null;

        public static TStorageLocations Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TStorageLocations();
                return _instance;
            }
        }

        private List<TTableMDM058> locations =
            new List<TTableMDM058>();

        private TStorageLocations()
        {
            GetLocations();
        }

        private void GetLocations()
        {
            TWaitting.Instance.ShowWaitForm("正在获取库位列表");

            IList<IDataParameter> paramList = new List<IDataParameter>();

            try
            {
                using (IRAPSQLConnection conn =
                    new IRAPSQLConnection(
                        SysParams.Instance.DBConnectionString))
                {
                    string strSQL =
                        "SELECT * FROM IRAPMDM..stb058 " +
                        "WHERE PartitioningKey=600100106 " +
                        "ORDER BY LeafID";
                    IList<TTableMDM058> lstDatas =
                        conn.CallTableFunc<TTableMDM058>(strSQL, paramList);

                    locations = lstDatas.ToList();
                }
            }
            catch (Exception error)
            {
                locations.Clear();

                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] = error.Message;
                throw error;
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
            }
        }

        public TTableMDM058 GetStorageLocationWithLeafID(int t106LeafID)
        {
            foreach (TTableMDM058 item in locations)
            {
                if (item.LeafID == t106LeafID)
                    return item;
            }
            return new TTableMDM058();
        }
    }
}
