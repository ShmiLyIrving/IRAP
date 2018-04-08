using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace IndexDefrag
{
    public class Server
    {
        private static object synclock = new object();
        private static Server _instance = null;
        private string dbserver;
        private static readonly object syncRoot = new object();
        public DataTable dtAccumChecked = new DataTable();
        public string DBServer
        { get { return dbserver; } }
        
        public List<DB> databases = new List<DB>();
        private Server(string DBAddress)
        {
            if (dtAccumChecked != null)
            {
                dtAccumChecked.Clear();
            }
            dtAccumChecked.Columns.Add("Databaseid");
            dtAccumChecked.Columns.Add("Tableid");
            dtAccumChecked.Columns.Add("AccumChecked");
            dbserver = DBAddress;
        }
        [IRAPXMLNodeAttrORMap(IsORMap =false)]
        public static Server Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = new Server(SysParams.Instance.DBServer);
                }
                return _instance;
            }
        }
        public void InitServer()
        {
            databases.Clear();
            try
            {
                XmlFile.Instance.ReadAccumChecked(dtAccumChecked);
                DBhelp test = new DBhelp("master");
                string sql = "SELECT dbid DatabaseID,name DBName FROM sysdatabases where name not in ('master','tempdb','model','msdb')";
                DataTable dtdbs = test.Query(sql).Tables["ds"];
                foreach (DataRow r in dtdbs.Rows)
                {
                    databases.Add(new DB((short)(r[0]), r[1].ToString()));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int GetAccumChecked(DBTable table)
        {
            lock (synclock)
            {
                DataRow[] drs;
                try
                {
                    drs = dtAccumChecked.Select($"dataBaseID = '{table.Databaseid}' and Tableid = '{table.Tableid}' ");
                }
                catch(Exception e)
                {
                    throw e;
                }
                if (drs.Length == 1)
                {
                    return int.Parse(drs[0]["AccumChecked"].ToString());
                }
                else if (drs.Length == 0)
                {
                    return 0;
                }
                else
                {
                    throw new Exception($"DatabaseId为{table.Databaseid},tableID 为{table.Tableid}的记录不唯一");
                }
            }
        }
        public void SaveAccumChecked(DBTable table)
        {
            lock (synclock)
            {
                DataRow[] drs;
                try
                {
                    drs = dtAccumChecked.Select($"dataBaseID = '{table.Databaseid}' and Tableid = '{table.Tableid}' ");
                }
                catch(Exception e)
                {
                    throw e;
                }
                if (drs.Length == 1)
                {
                    drs[0]["AccumChecked"] = table.AccumChecked;
                    dtAccumChecked.AcceptChanges();
                }
                else if (drs.Length == 0)
                {
                    DataRow n = dtAccumChecked.NewRow();
                    n["Databaseid"] = table.Databaseid;
                    n["Tableid"] = table.Tableid;
                    n["AccumChecked"] = table.AccumChecked;
                    dtAccumChecked.Rows.Add(n);
                }
                else if (drs.Length>0)
                {
                    throw new Exception($"DatabaseId为{table.Databaseid},tableID 为{table.Tableid}的记录不唯一");
                }
            }
        }
        public override string ToString()
        {
            return DBServer;
        }
    }
}
                                