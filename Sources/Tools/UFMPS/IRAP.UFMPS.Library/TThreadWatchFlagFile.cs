using System;
using System.IO;

using IRAP.Global;
using IRAP.UFMPS.Library.UserControls;

namespace IRAP.UFMPS.Library
{
	class TThreadWatchFlagFile: TCustomTaskThread
	{
		public TThreadWatchFlagFile(UCMonitorLog objShowLogs, TTaskInfo taskInfo): base(objShowLogs, taskInfo)
		{
		}

        /// <summary>
        /// 判断传入的文件是否是信号旗文件，如果是则返回相应的数据文件名；如果不是则返回空
        /// </summary>
        /// <param name="fileName">监控到的文件名</param>
        /// <returns>数据文件名</returns>
        protected override bool CheckFileValid(string fileName, ref string dataFileName)
        {
            bool rlt = false;
            dataFileName = "";

            if (_taskInfo.FlagFileDataFileExt.Trim() != "")
            {
                if (Tools.FileNameMatched(Path.GetFileName(fileName), _taskInfo.FlagFileNames))
                {
                    InvokeWriteLog(string.Format("找到信号旗文件：[{0}]", fileName));

                    // fileName 是信号旗文件
                    switch (_taskInfo.FlagFileGetDataFileType)
                    {
                        case 0:  // 数据文件名类同信号旗文件名
                            string strFileExt = Path.GetExtension(fileName);
                            dataFileName = fileName.Replace(strFileExt,
                                "." + _taskInfo.FlagFileDataFileExt);
                            rlt = true;

                            InvokeWriteLog(string.Format("获得数据文件名：[{0}]", dataFileName));
                            break;
                        case 1:  // 数据文件名从信号旗文件中获取
                            StreamReader objReader = new StreamReader(fileName);
                            try
                            {
                                while (dataFileName != null)
                                {
                                    dataFileName = objReader.ReadLine();
                                    if (dataFileName != null && dataFileName.Trim() != "")
                                    {
                                        InvokeWriteLog(string.Format("从信号旗文件中获得数据文件名：[{0}]", dataFileName));
                                        rlt = true;
                                        break;
                                    }
                                }
                            }
                            finally
                            {
                                objReader.Close();
                            }
                            break;
                        default:
                            rlt = false;
                            dataFileName = "";
                            InvokeWriteLog("未获得数据文件名");
                            break;
                    }

                    if (rlt)
                    {
                        dataFileName = Path.GetFileName(dataFileName);
                        dataFileName = string.Format(
                            "{0}{1}",
                            _taskInfo.FlagFileDataFileFolder.Trim() != "" ?
                                _taskInfo.FlagFileDataFileFolder.Trim() :
                                _taskInfo.WatchFolder.Trim(),
                            Path.GetFileName(dataFileName));
                        InvokeWriteLog(string.Format("获取带路径的数据文件名：[{0}]", dataFileName));

                        if (_taskInfo.BackupFileFlag && _taskInfo.BackupFileFolder.Trim() != "")
                        {
                            int i = 0;
                            string destFileName = "";
                            do
                            {
                                if (i == 0)
                                {
                                    destFileName = Path.GetFileName(fileName);
                                }
                                else
                                {
                                    destFileName = string.Format("{0}({1}){2}",
                                        Path.GetFileNameWithoutExtension(fileName),
                                        i,
                                        Path.GetExtension(fileName));
                                }

                                try
                                {
                                    //InvokeWriteLog(string.Format("数据文件[{0}]备份到[{1}{2}]", fileName, _taskInfo.BackupFileFolder, destFileName));
                                    File.Move(fileName,
                                        string.Format("{0}{1}",
                                            _taskInfo.BackupFileFolder,
                                            destFileName));
                                    //InvokeWriteLog("备份成功！");
                                    break;
                                }
                                catch (Exception error)
                                {
                                    //InvokeWriteLog(string.Format("备份失败：{0}", error.Message));
                                    i++;
                                }
                            } while (true);
                        }
                        else
                        {
                            File.Delete(fileName);
                        }
                    }
                }
            }
            else
            {
                InvokeWriteLog("还没有设置信号旗文件名！");
                return false;
            }

            return rlt;
        }
	}
}
