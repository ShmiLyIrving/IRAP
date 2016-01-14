using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using IRAP.Global;

namespace IRAP.UFMPS.Library
{
    class TThreadWatchNormal : TCustomTaskThread
    {
        public TThreadWatchNormal(
            UserControls.UCMonitorLog objShowLog,
            TTaskInfo taskInfo)
            : base(objShowLog, taskInfo)
        {
            
        }

        /// <summary>
        /// 判断传入的文件名是否为需要监控的文件
        /// </summary>
        protected override bool CheckFileValid(string fileName, ref string dataFileName)
        {
            // 如果文件已经在处理中，则返回 false
            if (TCustomDocumentProcess.GetProcessingFiles().IndexOf(fileName) >= 0)
            {
                return false;
            }

            // 检查文件是否被独占打开，如果不能则返回 false 并返回
            FileStream objFileStream = null;
            try
            {
                objFileStream = new FileStream(
                    fileName,
                    FileMode.Open,
                    FileAccess.Write,
                    FileShare.None);
            }
            catch 
            {
                InvokeWriteLog(string.Format("文件[{0}]不能独占打开!", fileName));
                return false;
            }
            finally
            {
                if (objFileStream != null)
                    objFileStream.Close();
            }

            if (_taskInfo.NormalWatchFileExts.Trim() != "")
            {
                if (Tools.FileNameMatched(Path.GetFileName(fileName), _taskInfo.NormalWatchFileFilters))
                {
                    dataFileName = fileName;
                    return true;
                }
                else
                {
                    if (_taskInfo.NormalKeepUndealFile)
                    {
                        if (_taskInfo.NormalKeepUndealFileFolder.Trim() != "")
                        {
                            // 保留不需处理的文件
                            string strDestinationFileName = string.Format("{0}{1}",
                                Path.GetFileName(fileName),
                                _taskInfo.NormalKeepUndealFileFolder);
                            try
                            {
                                File.Move(fileName, strDestinationFileName);
                            }
                            catch (Exception error)
                            {
                                InvokeWriteLog(string.Format("文件[{0}]移动到文件夹[{1}]失败：{2}",
                                            fileName,
                                            _taskInfo.NormalKeepUndealFileFolder,
                                            error.Message));
                            }
                        }
                        else
                        {
                            InvokeWriteLog("没有设置“保留到文件夹”属性，只能删除当前文件。");
                            try
                            {
                                File.Delete(fileName);
                            }
                            catch (Exception error)
                            {
                                InvokeWriteLog(string.Format("文件[{0}]删除失败：{1}",
                                        fileName,
                                        error.Message));
                            }
                        }
                    }
                    else
                    {
                        // 删除非待处理文件
                        try
                        {
                            File.Delete(fileName);
                        }
                        catch (Exception error)
                        {
                            InvokeWriteLog(string.Format("文件[{0}]删除失败：{1}",
                                    fileName,
                                    error.Message));
                        }
                    }

                    return false;
                }
            }
            else
            {
                // 没有设置指定的监控文件名格式，默认为全部文件
                dataFileName = fileName;
                return true;
            }
        }
    }
}
