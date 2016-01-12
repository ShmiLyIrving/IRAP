using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using IRAP.Global;
using IRAP.UFMPS.Library.UserControls;

namespace IRAP.UFMPS.Library
{
		public delegate void TaskInfoEventHandler(object sender, int taskSeqno);
		public delegate void MonitorEventHandler(object sender, string monitorMSG);
		public delegate void TasksEventHandler(object sender, int taskSeqno, int taskCount);

		public class TTask: TTaskInfo
		{
			public TTask(string regKeyItem, TObjectCreateType objCreateType): base (regKeyItem, objCreateType)
			{
			}
			private TCustomTaskThread _thread = null;

			public override void Save()
			{
				base.Save();

				if (TaskInfoEvent != null)
				{
					TaskInfoEvent(this, this.taskSeqno);
				}
			}

			private void DoActionErrorEvent(object sender, string monitorMSG)
			{
				OutputMonitorEvent(monitorMSG);
			}

			private void OnDirectoryGetNewFile()
			{
				throw new NotImplementedException();
			}

			private void OutputMonitorEvent(string message)
			{
				if (MonitorEvent != null)
				{
					MonitorEvent(this, message);
				}
			}

			private string WatchType_Normal(string fileName)
			{
				string rlt = "";

				if (this.NormalWatchFileExts != "")
				{
					if (Tools.FileNameMatched(Path.GetFileName(fileName), this.NormalWatchFileFilters))
					{
						rlt = fileName;
					}
					else
					{
						// 判断是否要保留不处理的文件
						if (this.NormalKeepUndealFile)
						{
							// 将不处理的文件移动到指定的目录中
							try
							{
								string strDestination = string.Format("{0}{1}",
									this.NormalKeepUndealFileFolder,
									Path.GetFileName(fileName));
								File.Move(fileName, strDestination);
								OutputMonitorEvent(string.Format("文件[{0}]移动到[{1}]",
									Path.GetFileName(fileName),
									this.NormalKeepUndealFileFolder));
							}
							catch (Exception error)
							{
								OutputMonitorEvent(string.Format("移动文件[{0}]失败：{1}", fileName, error.Message));
							}
						}
						else
						{
							// 删除不处理的文件
							try
							{
								File.Delete(fileName);
								OutputMonitorEvent(string.Format("删除文件[{0}]", fileName));
							}
							catch (Exception error)
							{
								OutputMonitorEvent(string.Format("删除文件[{0}]失败：{1}", fileName, error.Message));
							}
						}
					}
				}
				else
				{
					rlt = fileName;
				}

				return rlt;
			}

			public UCMonitorLog LogControl
			{
				get
				{
					return logControl;
				}
				set
				{
					if (logControl != value) {
						logControl = value;
					}
				}
			}
			private UCMonitorLog logControl = null;

			public int TaskSeqno
			{
				get
				{
					return taskSeqno;
				}
				set
				{
					taskSeqno = value;
					if (TaskInfoEvent != null)
						TaskInfoEvent(this, value);
				}
			}
			private int taskSeqno = 0;

			public TTaskStatus TaskStatus
			{
				get
				{
					return taskStatus;
				}
				set
				{
					taskStatus = value;

					switch(taskStatus)
					{
						case TTaskStatus.taskStopped:
							// 停止监控线程
                            //OutputMonitorEvent(string.Format("停止对文件夹[{0}]的监控", this.WatchDirectory));
                            if (_thread != null)
                            {
                                _thread.Stop();
                            }
							break;
						case TTaskStatus.taskRunning:
							// 开始监控线程
							//OutputMonitorEvent(string.Format("开始对文件夹[{0}]进行监控", this.WatchDirectory));
                            switch (this.WatchType)
                            {
                                case TWatchType.Normal:
                                    _thread = new TThreadWatchNormal(logControl, this);
                                    break;
                                case TWatchType.SignalFlag:
                                    _thread = new TThreadWatchFlagFile(logControl, this);
                                    break;
                                default:
                                    break;
                            }

                            if (_thread != null)
                            {
                                _thread.Start();
                            }
                            else
                            {
                                OutputMonitorEvent(
                                    string.Format(
                                        "当前程序暂不支持{0}监控方式",
                                        EnumHelper.GetDescription(this.WatchType)));
                                taskStatus = TTaskStatus.taskStopped;
                            }
							break;
						default:
							break;
					}

					if (TaskInfoEvent != null)
					{
						TaskInfoEvent(this, this.taskSeqno);
					}
				}
			}
			private TTaskStatus taskStatus = TTaskStatus.taskStopped;

			public string TaskStatusMessage
			{
				get
				{
					return EnumHelper.GetDescription(taskStatus);
				}
			}

			public event MonitorEventHandler MonitorEvent;

			public event TaskInfoEventHandler TaskInfoEvent;
		}
}
