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

        private object objectlock =new object();
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
            NeedDefrag =false;
            if (Server.Instance.GetAccumChecked(this)< int.Parse(SysParams.Instance.MaxIgnoreSacningTimes))
            {
                ScanningTask.Instance.SetAccumTask(Tablename);
                try
                {
                    string sql = "SELECT index_id IndexID,partition_number PartitionID,avg_fragmentation_in_percent,fragment_count " +
                $"FROM sys.dm_db_index_physical_stats({Databaseid}, {Tableid}, null, null, null) " +
                "WHERE index_id!= 0 AND alloc_unit_type_desc = 'IN_ROW_DATA' " +
                $"AND avg_fragmentation_in_percent> {SysParams.Instance.MaxAFP} " +
                $"AND fragment_count>{SysParams.Instance.MaxFragmentCount} " +
                "ORDER BY avg_fragmentation_in_percent DESC";
                    DataTable dtindexstates = dbhelp.Query(sql).Tables["ds"];
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
