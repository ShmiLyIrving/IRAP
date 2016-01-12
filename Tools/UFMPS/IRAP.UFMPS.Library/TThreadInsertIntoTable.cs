using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using DevExpress.XtraTreeList.Nodes;
using System.Data;
using System.Data.SqlClient;

namespace IRAP.UFMPS.Library
{
    internal class TThreadInsertIntoTable : TCustomDocumentProcess
    {
        private SqlConnection dbConn = null;

        public TThreadInsertIntoTable(
            string dataFileName, 
            TTaskInfo taskInfo, 
            UserControls.UCMonitorLog showLog = null,
            TreeListNode nodeParent = null) : base(dataFileName, taskInfo, showLog, nodeParent) 
        {
            string connectionString = string.Format("Data Source={0};" +
                "Initial Catalog={1};" +
                "Persist Security Info=True;" +
                "User ID={2};" +
                "Password={3};",
                _task.DbServer,
                _task.DbName,
                _task.DbUserID,
                _task.DbUserPWD);

            dbConn = new SqlConnection(connectionString);
            dbConn.Open();
        }

        ~TThreadInsertIntoTable()
        {
        }

        protected override bool DocumentProcessing()
        {
            if (File.Exists(DataFileName))
            {
                InvokeWriteLog(string.Format("打开文件[{0}]", DataFileName));

                if (ReadTextDataFile(DataFileName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                InvokeWriteLog(string.Format("文件[{0}]不存在，无法处理！", DataFileName));
                return false;
            }
        }

        private bool ReadTextDataFile(string strFileName)
        {
            SqlDataAdapter da = new SqlDataAdapter(
                string.Format("SELECT * FROM {0}", _task.TbTableName),
                dbConn);
            SqlCommand cmdSQL = new SqlCommand();
            SqlTransaction transaction = null;

            transaction = dbConn.BeginTransaction("IMPORTDATA");
            cmdSQL.Connection = dbConn;
            cmdSQL.Transaction = transaction;

            StreamReader objReader = new StreamReader(DataFileName, Encoding.GetEncoding("GB18030"), true);
            try
            {
                int intLineNo = 0;
                string strData = "";
                string[] fields = new string[0];
                string strSQL = "";
                int intStartArrayNo = 0;
                bool boolTransactionSuccessfull = true;

                while (strData != null)
                {
                    try
                    {
                        intLineNo++;
#if DEBUG
                        InvokeWriteLog(string.Format("读取第 {0} 行......", intLineNo));
#endif
                        strData = objReader.ReadLine();
#if DEBUG
                        InvokeWriteLog(string.Format("内容：{0}", strData));
#endif

                        if (intLineNo < _task.TbDataFirstRow)
                        {
#if DEBUG
                            InvokeWriteLog("该行不是数据行，放弃。");
#endif
                            continue;
                        }

                        if (strData != null && strData.Trim() != "")
                        {
#if DEBUG
                            InvokeWriteLog(string.Format(
                                    "该行是数据行，根据分割字符({0})进行数据域分割",
                                    _task.TbTxtFileSplitter));
#endif
                            fields = strData.Split(
                                new string[] { _task.TbTxtFileSplitter },
                                StringSplitOptions.RemoveEmptyEntries);

#if DEBUG
                            InvokeWriteLog(string.Format("将分割后的数据插入表[{0}]中......", _task.TbTableName));
#endif

                            if (_task.TbIncludeTxtFileName)
                            {
                                strSQL = string.Format("'{0}'", Path.GetFileName(dataFileName));
                                intStartArrayNo = 0;
                            }
                            else
                            {
                                strSQL = string.Format("'{0}'", fields[0]);
                                intStartArrayNo = 1;
                            }
                            for (int i = intStartArrayNo; i < _task.TbNumOfTxtFields; i++)
                            {
                                strSQL = string.Format("{0}, '{1}'", strSQL, fields[i]);
                            }
                            strSQL = string.Format("INSERT INTO {0} VALUES({1})", _task.TbTableName, strSQL);
#if DEBUG
                            InvokeWriteLog(string.Format("执行：{0}", strSQL));
#endif

                            cmdSQL.CommandText = strSQL;
                            cmdSQL.ExecuteNonQuery();
                        }
                        else
                        {
#if DEBUG
                            InvokeWriteLog("该行是结束行，或者是空行，不处理");
#endif
                        }
                    }
                    catch (Exception error)
                    {
                        InvokeWriteLog(string.Format("第{0}行数据导入时发生错误：{1}", intLineNo, error.Message));
                        boolTransactionSuccessfull = false;
                    }
                }
                InvokeWriteLog(string.Format("文件[{0}]处理完毕。", DataFileName));

                if (boolTransactionSuccessfull)
                {
                    transaction.Commit();
                    InvokeWriteLog(string.Format("数据导入完成"));
                }
                else
                {
                    transaction.Rollback();
                    InvokeWriteLog(string.Format("数据导入失败！"));
                }

                return true;
            }
            finally
            {
                objReader.Close();
            }
        }

    }
}
