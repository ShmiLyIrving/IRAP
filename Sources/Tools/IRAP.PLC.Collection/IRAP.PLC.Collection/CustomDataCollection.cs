using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Xml;
using System.Threading;

using DevExpress.XtraEditors;

namespace IRAP.PLC.Collection
{
    internal abstract class CustomDataCollection : CustomSendToESBThread
    {
        private OleDbConnection connection = null;

        public CustomDataCollection(MemoEdit mmoLog) : base(mmoLog) { }

        private OleDbConnection OpenDB(string fileName)
        {
            OleDbConnection connection =
                new OleDbConnection(
                    string.Format(
                        "Provider=Microsoft.Jet.OLEDB.4.0;" +
                        "Data Source={0};Persist Security Info=false",
                        fileName));

            return connection;
        }

        protected DataTable GetData(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            OleDbDataAdapter da = new OleDbDataAdapter()
            {
                SelectCommand = cmd,
            };
            DataSet ds = new DataSet();
            da.Fill(ds, "Data");

            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        protected string StrDateTimeToUnitTime(string dt)
        {
            string rlt = "0";

            DateTime b = DateTime.Parse("1970-1-1 00:00:00.000");

            DateTime d = DateTime.Now;
            try { d = DateTime.Parse(dt); }
            catch { return rlt; }

            TimeZoneInfo local = TimeZoneInfo.Local;
            double utcOffset = local.GetUtcOffset(DateTime.Now).TotalSeconds;

            double unitTime = (d - b).TotalSeconds - utcOffset;
            return unitTime.ToString();
        }

        protected XmlAttribute CreateAttr(XmlDocument xml, string key, string value)
        {
            XmlAttribute rlt = xml.CreateAttribute(key);
            rlt.Value = value;
            return rlt;
        }

        protected override void Do()
        {
            try
            {
                connection = OpenDB(SystemParams.Instance.DataFileName);
                try
                {
                    connection.Open();
                }
                catch (Exception error)
                {
                    WriteLogInThread(error.Message);
                    isThreadStarted = false;
                    return;
                }

                DateTime lastCheckPoint = SystemParams.Instance.BeginDT;
                int deltaTimeSpan = SystemParams.Instance.DeltaTimeSpan;
                while (true)
                {
                    if (!isThreadStarted)
                        return;

                    DateTime endDT = SystemParams.Instance.BeginDT.AddMinutes(deltaTimeSpan);

                    // 如果查询区间段时间晚于当前时间，则什么都不做
                    if (endDT < DateTime.Now)
                    {
                        GetDataAndSendToESB(SystemParams.Instance.BeginDT, endDT);

                        SaveCheckPointInThread(endDT);
                    }

                    Thread.Sleep(2000);
                }

            }
            finally
            {
                if (connection != null)
                    connection.Close();
                WriteLogInThread("线程结束运行......");
            }
        }

        protected abstract void GetDataAndSendToESB(DateTime beginDT, DateTime endDT);
    }
}
