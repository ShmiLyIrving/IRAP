using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using System.IO;
using DevExpress.XtraTreeList.Nodes;

using IRAP.Global;
using IRAP.UFMPS.Library;

namespace IRAP_UFMPS
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        const string RegTaskKey = @"SOFTWARE\Softland Information Tech. Co. Ltd.\Universal File Monitoring & Processing Service\Tasks";

        private static TTaskManager tasks = new TTaskManager(RegTaskKey);
        private DevExpress.XtraTab.XtraTabPage taskLogPanel = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.notifyIcon.Text = this.Text;

            string skinName = IniFile.ReadString(
                "Skin",
                "SkinName",
                "Glass Oceans",
                string.Format(@"{0}\IRAP.ini",
                    AppDomain.CurrentDomain.SetupInformation.ApplicationBase));
            defaultLookAndFeel.LookAndFeel.SkinName = skinName;

            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                tcboSkinNames.Items.Add(skin.SkinName);
            }
        }

        private void tcboSkinNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.defaultLookAndFeel.LookAndFeel.SkinName = tcboSkinNames.Text;
            IniFile.WriteString(
                "Skin",
                "SkinName",
                defaultLookAndFeel.LookAndFeel.SkinName,
                string.Format(@"{0}\IRAP.ini",
                    AppDomain.CurrentDomain.SetupInformation.ApplicationBase));
            contextMenu.Close();
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            tcboSkinNames.SelectedIndex = tcboSkinNames.Items.IndexOf(this.defaultLookAndFeel.LookAndFeel.SkinName);

            if (tlTasks.FocusedNode != null)
            {
                if (((TTask)tlTasks.FocusedNode.Tag).TaskStatus == TTaskStatus.taskStopped)
                {
                    tmnuEditTask.Enabled = true;
                    tmnuDeleteTask.Enabled = true;

                    tmnuStartTask.Enabled = true;
                    tmnuStopTask.Enabled = false;
                }
                else
                {
                    tmnuEditTask.Enabled = false;
                    tmnuDeleteTask.Enabled = false;

                    tmnuStartTask.Enabled = false;
                    tmnuStopTask.Enabled = true;
                }
            }
            else
            {
                tmnuEditTask.Enabled = false;
                tmnuDeleteTask.Enabled = false;

                tmnuStartTask.Enabled = false;
                tmnuStopTask.Enabled = false;
            }

            bool boolStartAll = false;
            bool boolStopAll = false;
            foreach (TreeListNode node in tlTasks.Nodes)
            {
                boolStartAll = boolStartAll || ((TTask)node.Tag).TaskStatus == TTaskStatus.taskStopped;
                boolStopAll = boolStopAll || ((TTask)node.Tag).TaskStatus == TTaskStatus.taskRunning;
            }
            tmnuStartAllTasks.Enabled = boolStartAll;
            tmnuStopAllTasks.Enabled = boolStopAll;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            spccBody.Panel1.Height = spccBody.Height / 2;
            
            foreach (TTask task in tasks.Tasks)
            {
                tlTasks.AppendNode(
                    new object[] 
                    {
                        task.TaskStatusMessage,
                        task.TaskName,
                        EnumHelper.GetDescription(task.WatchType),
                        task.WatchFolder,
                        EnumHelper.GetDescription(task.FileDealType)
                    },
                    null,
                    task);
                CreateTaskLogPanel(task);
            }

            tmnuStartAllTasks.PerformClick();
        }

        private void tmnuNewTask_Click(object sender, EventArgs e)
        {
            using (frmTaskEditor frmNewTask = new frmTaskEditor())
            {
                TTask newTask = new TTask(RegTaskKey, TObjectCreateType.octNew);

                frmNewTask.Task = newTask;
                frmNewTask.Text = "新增监控任务";

                if (frmNewTask.ShowDialog() == DialogResult.OK)
                {
                    newTask.Save();
                    tasks.Tasks.Add(newTask);
                    tlTasks.AppendNode(
                        new object[]
                        {
                            newTask.TaskStatusMessage,
                            newTask.TaskName,
                            EnumHelper.GetDescription(newTask.WatchType),
                            newTask.WatchFolder,
                            EnumHelper.GetDescription(newTask.FileDealType)
                        },
                        null,
                        newTask);
                    CreateTaskLogPanel(newTask);
                }
            }
        }

        private void tmnuEditTask_Click(object sender, EventArgs e)
        {
            if (tlTasks.FocusedNode != null && tlTasks.FocusedNode.Tag != null)
            {
                using (frmTaskEditor frmEditTask = new frmTaskEditor())
                {
                    TTask editTask = (TTask)tlTasks.FocusedNode.Tag;

                    frmEditTask.Task = editTask;
                    frmEditTask.Text = "修改监控任务";

                    if (frmEditTask.ShowDialog() == DialogResult.OK)
                    {
                        editTask.Save();

                        tlTasks.FocusedNode[tclmnTaskName.AbsoluteIndex] = editTask.TaskName;
                        tlTasks.FocusedNode[tclmnWatchType.AbsoluteIndex] = EnumHelper.GetDescription(editTask.WatchType);
                        tlTasks.FocusedNode[tclmnMonitorFolder.AbsoluteIndex] = editTask.WatchFolder;
                        tlTasks.FocusedNode[tclmnDocProcessType.AbsoluteIndex] = EnumHelper.GetDescription(editTask.FileDealType);

                        tcTaskLogs.SelectedTabPage.Text = GetTaskLogPanelText(editTask);
                    }
                }
            }
        }

        private void tlTasks_DoubleClick(object sender, EventArgs e)
        {
            if (tmnuEditTask.Enabled)
            {
                tmnuEditTask.PerformClick();
            }
        }

        private void tmnuDeleteTask_Click(object sender, EventArgs e)
        {
            if (tlTasks.FocusedNode != null && tlTasks.FocusedNode.Tag != null)
            {
                TreeListNode deleteNode = tlTasks.FocusedNode;
                TTask task = (TTask)deleteNode.Tag;

                if (MessageBox.Show(
                    string.Format("请确认是否要删除当前选定的[{0}]监控任务？",
                        task.TaskName),
                    "系统信息",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tasks.Delete(task.TaskID);
                    tcTaskLogs.TabPages.Remove(tcTaskLogs.SelectedTabPage);
                    tlTasks.Nodes.Remove(deleteNode);
                }
            }
        }

        private void tmnuStartTask_Click(object sender, EventArgs e)
        {
            if (tlTasks.FocusedNode != null && tlTasks.FocusedNode.Tag != null)
            {
                TTask task = (TTask)tlTasks.FocusedNode.Tag;

                task.TaskStatus = TTaskStatus.taskRunning;
                tlTasks.FocusedNode[tclmnStatus.AbsoluteIndex] = EnumHelper.GetDescription(task.TaskStatus);
            }
        }

        private void tmnuStopTask_Click(object sender, EventArgs e)
        {
            if (tlTasks.FocusedNode != null && tlTasks.FocusedNode.Tag != null)
            {
                TTask task = (TTask)tlTasks.FocusedNode.Tag;

                task.TaskStatus = TTaskStatus.taskStopped;
                tlTasks.FocusedNode[tclmnStatus.AbsoluteIndex] = EnumHelper.GetDescription(task.TaskStatus);
            }
        }

        private void tmnuStartAllTasks_Click(object sender, EventArgs e)
        {
            foreach (TreeListNode node in tlTasks.Nodes)
            {
                if (node.Tag != null)
                {
                    TTask task = (TTask)node.Tag;
                    if (task.TaskStatus == TTaskStatus.taskStopped)
                    {
                        task.TaskStatus = TTaskStatus.taskRunning;
                        node[tclmnStatus.AbsoluteIndex] = EnumHelper.GetDescription(task.TaskStatus);
                    }
                }
            }
        }

        private void tmnuStopAllTasks_Click(object sender, EventArgs e)
        {
            foreach (TreeListNode node in tlTasks.Nodes)
            {
                if (node.Tag != null)
                {
                    TTask task = (TTask)node.Tag;
                    if (task.TaskStatus == TTaskStatus.taskRunning)
                    {
                        task.TaskStatus = TTaskStatus.taskStopped;
                        node[tclmnStatus.AbsoluteIndex] = EnumHelper.GetDescription(task.TaskStatus);
                    }
                }
            }
        }

        private string GetTaskLogPanelName(TTask task)
        {
            return string.Format("tp{0}", task.TaskID);
        }

        private string GetTaskLogPanelText(TTask task)
        {
            return string.Format("{0}的日志", task.TaskName);
        }

        /// <summary>
        /// 根据监控任务，生成一个该任务的监控日志面板
        /// </summary>
        /// <param name="task">监控任务对象</param>
        private void CreateTaskLogPanel(TTask task)
        {
            taskLogPanel = new DevExpress.XtraTab.XtraTabPage();
            taskLogPanel.Parent = tcTaskLogs;
            taskLogPanel.Name = GetTaskLogPanelName(task);
            taskLogPanel.Text = GetTaskLogPanelText(task);

            IRAP.UFMPS.Library.UserControls.UCMonitorLog ucLog = new IRAP.UFMPS.Library.UserControls.UCMonitorLog();
            ucLog.Parent = taskLogPanel;
            ucLog.Dock = DockStyle.Fill;
            ucLog.Task = task;

            taskLogPanel.Tag = ucLog;

            tcTaskLogs.TabPages.Add(taskLogPanel);

            task.LogControl = ucLog;
            task.MonitorEvent += ucLog.OnTaskLogEvent;
        }

        private void tlTasks_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                TTask task = (TTask)e.Node.Tag;
                foreach (DevExpress.XtraTab.XtraTabPage tPage in tcTaskLogs.TabPages)
                {
                    if (tPage.Name == GetTaskLogPanelName(task))
                    {
                        tcTaskLogs.SelectedTabPage = tPage;
                        break;
                    }
                }
            }
        }

        private void tcTaskLogs_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            foreach (TreeListNode node in tlTasks.Nodes)
            {
                if (node.Tag != null && e.Page != null && e.Page.Tag != null)
                {
                    if ((TTask)node.Tag == ((IRAP.UFMPS.Library.UserControls.UCMonitorLog)e.Page.Tag).Task)
                    {
                        tlTasks.FocusedNode = node;
                    }
                }
                else
                {
                    tlTasks.FocusedNode = null;
                }
            }
        }

        private FormWindowState windowStateBeforeHide = FormWindowState.Maximized;
        protected override void OnClosing(CancelEventArgs e)
        {
            windowStateBeforeHide = this.WindowState;
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon.Visible = true;
                this.ShowInTaskbar = false;
            }
            else
            {
                windowStateBeforeHide = this.WindowState;
            }
        }

        private void tmnQuit_Click(object sender, EventArgs e)
        {
            this.notifyIcon.Visible = false;
            Application.Exit();
        }

        private void notifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.cm_NotifyIcon.Show(MousePosition.X, MousePosition.Y);
            }
            else if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = windowStateBeforeHide;
                this.notifyIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
        }
    }
}