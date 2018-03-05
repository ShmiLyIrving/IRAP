using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace IndexDefrag
{
    public class DB
    {
        public DB(int databaseid,string dbname)
        {
            DataBaseID = databaseid;
            DBName = dbname;
        }
        private int DataBaseID;
        private string DBName;
        private DBhelp dbhelp = null;
        private static object SyncLock = new object();
        public List<DBTable> tables= new List<DBTable>();

        public int dataBaseID
        {
            get
            {
                return DataBaseID;
            }

            set
            {
                DataBaseID = value;
            }
        }

        public string dBName
        {
            get
            {
                return DBName;
            }

            set
            {
                DBName = value;
            }
        }

        public override string ToString()
        {
            return DBName;
        }
        public void InitDB(CancellationToken cts)
        {
            try
            {
                lock (SyncLock)
                {
                    if(cts.IsCancellationRequested)
                    {
                        return;
                    }
                    Debug.WriteLine($"Get DB {DBName}");
                    ScanningTask.Instance.SetAccumTask(DBName);
                    string sql = $"SELECT object_id TableID,name TableName FROM {DBName}.sys.tables";
                    dbhelp = new DBhelp(DBName);
                    DataTable dttables = dbhelp.Query(sql).Tables["ds"];
                    if (dttables.Rows.Count > 0)
                    {
                        tables = new List<DBTable>();
                        foreach (DataRow r in dttables.Rows)
                        {
                            if (cts.IsCancellationRequested)
                            {
                                return;
                            }

                            tables.Add(new DBTable(DataBaseID, DBName, dbhelp, (int)(r[0]), r[1].ToString()));
                        }
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;
            DB db = (DB)obj;
            return  dataBaseID!=0||DBName!=null?dataBaseID ==db.dataBaseID ||DBName ==db.DBName:(db.DataBaseID == 0)||(db.DBName == null);
        }
    }
}
