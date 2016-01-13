using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using DevExpress.XtraTreeList.Nodes;

namespace IRAP.UFMPS.Library
{
    /// <summary>
    /// 文件处理方式：以单线程方式将数据文件中的数据插入指定表中
    /// </summary>
    internal class TThreadInsertIntoTableSingle : TCustomDocumentProcess
    {
        private static SqlConnection dbConn = null;
        private static TThreadInsertIntoTableSingle _instance = null;
        /// <summary>
        /// 线程是否正在处理
        /// </summary>
        private bool isThreadRunning = false;
        /// <summary>
        /// 需要锁定的对象，用于增加待处理数据文件名列表
        /// </summary>
        private object lockedObject = new object();
        /// <summary>
        /// 是否需要结束当前线程的运行
        /// </summary>
        private volatile bool _shouldStopped = true;

        private TThreadInsertIntoTableSingle(
            string dataFileName,
            TTaskInfo taskInfo,
            UserControls.UCMonitorLog showLog = null,
            TreeListNode nodeParent = null)
            : base(dataFileName, taskInfo, showLog, nodeParent)
        {
        }

        ~TThreadInsertIntoTableSingle()
        {
        }

        public static TThreadInsertIntoTableSingle Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TThreadInsertIntoTableSingle("", null);
                return _instance;
            }
        }

        public TTaskInfo TaskInfo
        {
            get { return _task; }
            set
            {
                if (!isThreadRunning)
                {
                    if (_task == null || 
                        (_task.DbServer != value.DbServer ||
                         _task.DbName != value.DbName ||
                         _task.DbUserID != value.DbUserID ||
                         _task.DbUserPWD != value.DbUserPWD))
                    {
                        _task = value;

                        string connectionString = string.Format("Data Source={0};" +
                            "Initial Catalog={1};" +
                            "Persist Security Info=True;" +
                            "User ID={2};" +
                            "Password={3};",
                            _task.DbServer,
                            _task.DbName,
                            _task.DbUserID,
                            _task.DbUserPWD);

                        if (dbConn != null && dbConn.State == ConnectionState.Open)
                            dbConn.Close();
                        dbConn = new SqlConnection(connectionString);
                        dbConn.Open();
                    }
                }
            }
        }

        public UserControls.UCMonitorLog ShowLog
        {
            get { return showLog; }
            set
            {
                if (showLog == null)
                    showLog = value;
            }
        }

        public TreeListNode NodeParent
        {
            get { return nodeParentLog; }
        }

        /// <summary>
        /// 准备处理的数据文件名（包括路径）
        /// </summary>
        public new string DataFileName
        {
            set
            {
                lock (lockedObject)
                {
                    if (processingFiles.IndexOf(value) < 0)
                    {
                        processingFiles.Add(value);
                    }
                    else
                    {
                        InvokeWriteLog(string.Format("文件[0]已经处于待处理列表中。", value));
                    }
                }
            }
        }

        /// <summary>
        /// 线程是否在运行中？
        /// </summary>
        public bool Running
        {
            get
            {
                return !_shouldStopped;
            }
        }

        /// <summary>
        /// 单线程处理需要导入的数据文件
        /// </summary>
        public override void RunProcessing()
        {
            _shouldStopped = false;

            while (!_shouldStopped)
            {
                // 当线程下一循环开始状态设置为“需导入的表为空”时，检测表是否为空
                if (_task.ThreadStartMark == TThreadStartMark.TableIsEmpty)
                {
                    try
                    {
                        if (!TableIsEmpty())
                        {
                            Thread.Sleep(2000);
                            continue;
                        }
                    }
                    catch (Exception error)
                    {
                        InvokeWriteLog(string.Format("检测表是否为空时发生错误：{0}", error.Message));
                        Thread.Sleep(2000);
                        continue;
                    }
                }

                // 从待处理的文件列表取下一个需要处理的文件
                lock (lockedObject)
                {
                    if (processingFiles.Count > 0)
                    {
                        dataFileName = processingFiles[0];
                        processingFiles.Remove(dataFileName);
                    }
                    else
                    {
                        dataFileName = "";
                    }
                }

                if (dataFileName != "")
                {
                    try
                    {
                        if (DocumentProcessing())
                        {
                            AfterDocumentProcessing();
                        }
                    }
                    catch (Exception error)
                    {
                        InvokeWriteLog(error.Message);
                    }

                    InvokeWriteLog(string.Format("文件[{0}]处理完毕。", dataFileName));
                    nodeParentLog = null;
                }

                Thread.Sleep(100);
            }

            _thread = null;
        }

        protected override bool DocumentProcessing()
        {
            if (File.Exists(dataFileName))
            {
                InvokeWriteLog(string.Format("打开文件[{0}]", dataFileName));

                if (ReadTextDataFile(dataFileName))
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
                InvokeWriteLog(string.Format("文件[{0}]不存在，无法处理！", dataFileName));
                return false;
            }
        }

        /// <summary>
        /// 结束当前线程的运行
        /// </summary>
        public void RequestStop()
        {
            _shouldStopped = true;
        }

        /// <summary>
        /// 检测插入数据的数据库表是否为空
        /// </summary>
        private bool TableIsEmpty()
        {
            string strSQL = string.Format("SELECT * FROM {0}", _task.TbTableName);
            SqlCommand cmdSQL = new SqlCommand(strSQL, dbConn);

            SqlDataReader reader = cmdSQL.ExecuteReader();
            try
            {
                return !reader.HasRows;
            }
            finally
            {
                reader.Close();
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

            StreamReader objReader = new StreamReader(dataFileName, Encoding.GetEncoding("GB18030"), true);
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
                InvokeWriteLog(string.Format("文件[{0}]处理完毕。", dataFileName));

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
