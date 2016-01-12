using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Win32;

namespace IRAP.UFMPS.Library
{
		public class TTaskManager: System.Object
		{
			public TTaskManager(string regKeyItem)
			{
				taskParentItem = regKeyItem;

				RegistryKey reg = null;
				try
				{
					reg = Registry.CurrentUser.OpenSubKey(taskParentItem);
				}
				catch
				{
				}

				if (reg != null)
				{
					string[] taskKeys = reg.GetSubKeyNames();
					int intTaskSeqno = 0;

					foreach (string strTaskID in taskKeys)
					{
						try
						{
							TTask task = new TTask(
								string.Format(@"{0}\{1}",
									taskParentItem,
									strTaskID),
								TObjectCreateType.octLoad);
								task.TaskSeqno = ++intTaskSeqno;

							tasks.Add(task);
						}
						catch (Exception error)
						{
							MessageBox.Show(string.Format("装载监控任务[ID:{0}]时发生错误：{1}",
									strTaskID,
									error.Message),
								"系统信息",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
						}
					}
				}
			}

			private TTaskManager()
			{
			}
			private static string taskParentItem = "";

			public void Delete(string taskID)
			{
				foreach (TTask task in tasks)
				{
					if (task.TaskID == taskID)
					{
						tasks.Remove(task);
						task.Delete();
						break;
					}
				}
			}

			private void RefreshTaskSeqno()
			{
				int i = 1;
				foreach (TTask task in tasks)
				{
					task.TaskSeqno = i++;
				}
			}

			public List<TTask> Tasks
			{
				get
				{
					return tasks;
				}
				set
				{
					if (tasks != value) {
						tasks = value;
					}
				}
			}
			private List<TTask> tasks = new List<TTask>();
		}
}
