using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;

namespace IndexDefrag
{
    public class IndexState
    {
        public IndexState(DBhelp Dbhelp, int IndexID,int PartionID, double Avg_fragmentation_in_percent, long Fragment_count)
        {
            dbhelp = Dbhelp;
            this.IndexID = IndexID;
            this.partionID = PartionID;
            this.Avg_fragmentation_in_percent = Avg_fragmentation_in_percent;
            this.Fragment_count = Fragment_count;
        }
        private static object LockArea = new object();
        private static object Loglock = new object();
        private int indexID;
        private int partionID;
        private double avg_fragmentation_in_percent;
        private long fragment_count;
        public DBhelp dbhelp;

        public int IndexID
        {
            get
            {
                return indexID;
            }

            set
            {
                indexID = value;
            }
        }

        public double Avg_fragmentation_in_percent
        {
            get
            {
                return avg_fragmentation_in_percent;
            }

            set
            {
                avg_fragmentation_in_percent = value;
            }
        }

        public long Fragment_count
        {
            get
            {
                return fragment_count;
            }

            set
            {
                fragment_count = value;
            }
        }

        public int PartionID
        {
            get
            {
                return partionID;
            }

            set
            {
                partionID = value;
            }
        }

        public void Defrag(int databaseid,int tableid,string tablename,CancellationToken cts)
        {
            if (cts.IsCancellationRequested)
            {
                return;
            }
            string strProcedureName = string.Format(
                "{0}.{1}",
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name);
            //Debug.WriteLine("Defraging Table:" + tablename);     
            try
            {
                string sql = $"DBCC INDEXDEFRAG ({databaseid},{tableid},{indexID},{partionID})";// WITH NO_INFOMSGS
                string r =dbhelp.GetSingle(sql).ToString();
                ScanningTask.Instance.SetAccumTask(tablename + "/" + indexID);
                ScanningTask.Instance.SetMsgState("Pages Scanned:"+r,"Table:"+tablename+",Index:"+indexID,System.Windows.Forms.ToolTipIcon.None);
            }
            catch(Exception e)
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
        

        public IndexState Clone()
        {
            return MemberwiseClone() as IndexState;
        }
    }
}
