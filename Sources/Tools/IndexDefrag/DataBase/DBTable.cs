using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace IndexDefrag
{
    public class DBTable
    {
        public DBTable(int DataBaseID,string DBName,DBhelp Dbhelp,int TableID, string TableName)
        {
            Databaseid = DataBaseID;
            dbname = DBName;
            dbhelp = Dbhelp;
            Tableid = TableID;
            Tablename = TableName;
            accumchecked = GetAccumChecked();
        }

        private static object objectlock =new object();
        private static object Loglock = new object();
        private int databaseid;
        private string dbname;        
        private int tableid;
        private string tablename;
        private bool NeedDefrag = false;//默认不需要清理
        private int accumchecked = 0;
        public List<IndexState> indexstates = new List<IndexState>();
        public DBhelp dbhelp;

        [IRAPXMLNodeAttrORMap(IsORMap =false)]
        public int Databaseid
        {
            get
            {
                return databaseid;
            }

            set
            {
                databaseid = value;
            }
        }

        public int Tableid
        {
            get
            {
                return tableid;
            }

            set
            {
                tableid = value;
            }
        }

        public string Tablename
        {
            get
            {
                return tablename;
            }

            set
            {
                tablename = value;
            }
        }

        public bool needDefrag
        {
            get
            {
                return NeedDefrag;
            }

            set
            {
                NeedDefrag = value;
            }
        }

        public int AccumChecked
        {
            get
            {
                return accumchecked;
            }

            set
            {
                accumchecked = value;
            }
        }
        [IRAPXMLNodeAttrORMap(IsORMap =false)]
        public string Dbname
        {
            get
            {
                return dbname;
            }

            set
            {
                dbname = value;
            }
        }
        public int GetAccumChecked()
        {
            return XmlFile.Instance.GetAccumChecked(SysParams.Instance.DBServer, databaseid, tableid);
        }
        public void InitIndexState(CancellationToken cts)
        {           
            if (cts.IsCancellationRequested)
            {
                return;
            }
            string strProcedureName = string.Format(
                    "{0}.{1}",
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name);
            NeedDefrag =false;
            if (Server.Instance.GetAccumChecked(this)< int.Parse(SysParams.Instance.MaxIgnoreSacningTimes))
            {
                
                try
                {
                    string sql = "SELECT index_id IndexID,partition_number PartitionID,avg_fragmentation_in_percent,fragment_count " +
                $"FROM sys.dm_db_index_physical_stats({Databaseid}, {Tableid}, null, null, null) " +
                "WHERE index_id!= 0 AND alloc_unit_type_desc = 'IN_ROW_DATA' " +
                $"AND avg_fragmentation_in_percent> {SysParams.Instance.MaxAFP} " +
                $"AND fragment_count>{SysParams.Instance.MaxFragmentCount} " +
                "ORDER BY avg_fragmentation_in_percent DESC";
                    DataTable dtindexstates = dbhelp.Query(sql).Tables["ds"];
                    ScanningTask.Instance.SetAccumTask(Tablename);
                    if (dtindexstates.Rows.Count > 0)
                    {
                        NeedDefrag = true;                        
                        indexstates = new List<IndexState>();
                        foreach (DataRow r in dtindexstates.Rows)
                        {
                            if (cts.IsCancellationRequested)
                            {
                                return;
                            }
                            if ((double)r["avg_fragmentation_in_percent"] > double.Parse(SysParams.Instance.MaxAFP))
                            {
                                indexstates.Add(new IndexState(dbhelp,(int)(r["IndexID"]), (int)(r["PartitionID"]), (double)(r["avg_fragmentation_in_percent"]), (long)(r["fragment_count"])));
                                Debug.WriteLine((r["IndexID"]).ToString());
                                lock (objectlock)
                                {
                                    accumchecked = 0;
                                    Server.Instance.SaveAccumChecked(this);
                                }
                            }
                        }
                    }
                    else
                    {
                        lock (objectlock)
                        {
                            accumchecked++;
                            Server.Instance.SaveAccumChecked(this);
                        }
                    }
                }
                catch (Exception e)
                {
                    lock (Loglock)
                    {
                        WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                        WriteLog.Instance.Write(
                               string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                                   e.Message,
                                   e.StackTrace),
                               strProcedureName);
                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }
                    throw e;
                }
            }
        }
        public override string ToString()
        {
            return Tablename;
        }
    }
}
