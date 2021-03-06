using System;
using System.Threading;
using System.IO;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Windows.Forms;

using IRAP.Global;
using IRAP.UFMPS.Library.UserControls;

namespace IRAP.UFMPS.Library
{
	abstract class TCustomTaskThread: System.Object
	{
		public TCustomTaskThread(UCMonitorLog objShowLogs, TTaskInfo taskInfo)
		{
			showLog = objShowLogs;
            _taskInfo = taskInfo.Clone();
		}

		private TCustomTaskThread()
		{
		}

		private delegate void InvokeAddLogs(string message);
		private delegate void InvokeClearLogs();
        private Thread threadWatch = null;

        protected UCMonitorLog showLog = null;
        protected TTaskInfo _taskInfo = null;

		public void Start()
		{
			if (!threadStarted)
			{
				threadWatch = new Thread(new ThreadStart(Watch));
                
                //showLog.BeginInvoke(new InvokeClearLogs(ClearLogs), new object[] { });
                InvokeWriteLog("开始监控文件夹");

                threadWatch.IsBackground = true;
                threadWatch.Start();
			}
			else
			{
                InvokeWriteLog("文件夹已经处于监控中！");
			}
		}

        public void Stop()
        {
            threadWatch.Abort();
            threadWatch.Join();

            InvokeWriteLog("终止文件夹监控");
        }

		private void ClearLogs()
		{
			showLog.tlLog.Nodes.Clear();
		}

        protected abstract bool CheckFileValid(string fileName, ref string dataFileName);

		private void Watch()
		{
			InvokeAddLogs messageWrite = new InvokeAddLogs(WriteLog);
			InvokeClearLogs messageClear = new InvokeClearLogs(ClearLogs);

            string[] files = new string[0];
            int intCycleNum = 0;
            while (true)
			{
                if (intCycleNum % 10 == 0)
                {
                    intCycleNum = 0;
                    try
                    {
                        files = Directory.GetFiles(_taskInfo.WatchFolder);
                    }
                    catch (Exception error)
                    {
                        InvokeWriteLog(string.Format("获取文件列表时发生错误：{0}", error.Message));
                    }

                    foreach (string strFileName in files)
                    {
                        string strDataFileName = "";
                        if (CheckFileValid(strFileName, ref strDataFileName))
                        {
                            //InvokeWriteLog(string.Format("发现需要处理的文件：{0}。", 
                            //            strDataFileName,
                            //            Thread.CurrentThread.ManagedThreadId));

                            if (_taskInfo.FileDealType == TDocumentProcessType.InsertIntoTableWithSingle)
                            {
                                // 如果文件处理方式为“导入制定数据表 - 单线程处理”
                                TThreadInsertIntoTableSingle.Instance.TaskInfo = _taskInfo;
                                TThreadInsertIntoTableSingle.Instance.ShowLog = showLog;
                                TThreadInsertIntoTableSingle.Instance.DataFileName = strDataFileName;

                                if (!TThreadInsertIntoTableSingle.Instance.Running)
                                    TThreadInsertIntoTableSingle.Instance.Start();
                            }
                            else
                            {
                                // 根据文件处理方式，创建相应的处理线程
                                switch (_taskInfo.FileDealType)
                                {
                                    case TDocumentProcessType.FTP:
                                        _processingThread = new TThreadFtpFile(strDataFileName, _taskInfo, showLog);
                                        break;
                                    case TDocumentProcessType.MoveTo:
                                        _processingThread = new TThreadMoveTo(strDataFileName, _taskInfo, showLog);
                                        break;
                                    case TDocumentProcessType.CallStoreProcedure:
                                        _processingThread = null;
                                        break;
                                    case TDocumentProcessType.InsertIntoTableThread:
                                        _processingThread = new TThreadInsertIntoTableThread(strDataFileName, _taskInfo, showLog);
                                        break;
                                    default:
                                        _processingThread = null;
                                        break;
                                }

                                if (_processingThread != null)
                                {
                                    _processingThread.Start();
                                }
                                else
                                {
                                    InvokeWriteLog(string.Format("当前程序暂不支持{0}处理方式。",
                                                EnumHelper.GetDescription(_taskInfo.FileDealType)));
                                }
                            }
                        }
                    }
                }
                intCycleNum++;

				Thread.Sleep(100);
			}
		}

		private void WriteLog(string message)
		{
			if (message.Trim() != "")
			{
				showLog.WriteLog(message);
			}
		}

		public bool ThreadStarted
		{
			get
			{
				return threadStarted;
			}
		}
		private bool threadStarted = false;
        private TCustomDocumentProcess _processingThread = null;

        protected void InvokeWriteLog(string message)
        {
            showLog.Invoke(new InvokeAddLogs(WriteLog), new object[] { message });
        }
	}
}
