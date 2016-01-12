using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using System.Threading;

namespace IRAP.UFMPS.Library
{
    abstract class TCustomDocumentProcess
    {
        private UserControls.UCMonitorLog showLog = null;
        private TreeListNode nodeParentLog = null;
        private Thread _thread;
        private static List<string> processingFiles = new List<string>();

        protected string dataFileName;
        protected TTaskInfo _task = null;

        private TCustomDocumentProcess()
        {
            throw new System.NotImplementedException();
        }

        public TCustomDocumentProcess(
            string dataFileName, 
            TTaskInfo taskInfo, 
            UserControls.UCMonitorLog showLog, 
            TreeListNode parentNode)
        {
            this.showLog = showLog;
            this._task = taskInfo;
            this.dataFileName = dataFileName;
            this.nodeParentLog = parentNode;
        }

        ~TCustomDocumentProcess()
        {
        }

        public static List<string> GetProcessingFiles()
        {
            return processingFiles;
        }

        public string DataFileName
        {
            get { return dataFileName; }
        }

        protected abstract bool DocumentProcessing();

        private void AfterDocumentProcessing()
        {
            // 文件处理完成后
            if (_task.BackupFileFlag && _task.BackupFileFolder.Trim() != "")
            {
                if (!Directory.Exists(_task.BackupFileFolder))
                {
                    Directory.CreateDirectory(_task.BackupFileFolder);
                }

                try
                {
                    InvokeWriteLog(string.Format("将处理后的文件[{0}]移动到[{1}]文件夹。",
                        dataFileName,
                        _task.BackupFileFolder));
                    int i = 0;
                    string destinationFileName = string.Format("{0}{1}",
                        _task.BackupFileFolder,
                        Path.GetFileName(dataFileName));
                    do
                    {
                        try
                        {
                            File.Move(dataFileName, destinationFileName);
                            break;
                        }
                        catch
                        {
                            destinationFileName = string.Format("{0}{1}({2}){3}",
                                _task.BackupFileFolder,
                                Path.GetFileNameWithoutExtension(dataFileName),
                                ++i,
                                Path.GetExtension(dataFileName));
                        }
                    } while (true);
                }
                catch (Exception error)
                {
                    InvokeWriteLog(string.Format("移动文件[{0}]时发生错误：{1}", dataFileName, error.Message));
                    File.Delete(dataFileName);
                }
            }
            else
            {
                InvokeWriteLog(string.Format("删除文件[{0}]", dataFileName));
                File.Delete(dataFileName);
            }
        }

        /// <summary>
        /// 线程运行入口
        /// </summary>
        public void RunProcessing()
        {
            if (processingFiles.IndexOf(dataFileName) < 0)
            {
                try
                {
                    try
                    {
                        processingFiles.Add(dataFileName);
                        if (DocumentProcessing())
                        {
                            AfterDocumentProcessing();
                        }
                    }
                    catch (Exception error)
                    {
                        InvokeWriteLog(error.Message);
                    }
                }
                finally
                {
                    processingFiles.Remove(dataFileName);
                    InvokeWriteLog(string.Format("文件[{0}]处理完毕。", dataFileName));
                }
            }
        }

        protected void InvokeWriteLog(string message)
        {
            showLog.Invoke(new InvokeAddLogs(WriteLog), new object[] { null, message });
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        private void WriteLog(object sender, string message)
        {
            if (nodeParentLog == null)
            {
                nodeParentLog = showLog.WriteLog(string.Format("处理数据文件[{0}]", dataFileName));
            }
            if (message.Trim() != "")
            {
                showLog.WriteLog(message, nodeParentLog);
            }
        }

        public void Start()
        {
            if (_thread == null)
            {
                _thread = new Thread(new ThreadStart(this.RunProcessing));
                _thread.IsBackground = false;
                _thread.Start();
            }
            else
            {
                InvokeWriteLog("文件已经在处理中......");
            }
        }
    }
}
