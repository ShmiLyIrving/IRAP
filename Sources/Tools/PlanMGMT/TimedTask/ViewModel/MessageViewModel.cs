using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PlanMGMT.ViewModel
{
    public class MessageViewModel : ViewModelBase
    {
        public MessageViewModel()
        {
            if (!IsInDesignMode)
            {
                Load();
            }
            this.SendCommand = new ViewModelCommand((Object parameter) => {Send(); });
            System.Timers.Timer timer = new System.Timers.Timer();
            //timer.Interval = 1000;//1秒执行一次
            //timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Message);
            //timer.Start();
        }
        /// <summary> 加载  </summary>
        public ICommand SendCommand { get; set; }

        /// <summary>
        /// 任务列表
        /// </summary>
        private List<CommonMessage> _messageList;
        public List<CommonMessage> MessageList
        {
            get { return EsbHelper.Instance.WaitingMessages; }
            set
            {
                    _messageList = value;
                    base.RaisePropertyChanged("MessageList");
            }
        }
        private string _taskMsg;
        /// <summary> 任务信息 </summary>
        public string TaskMsg
        {
            get { return _taskMsg; }
            set
            {
                if (this._taskMsg == value) return;
                this._taskMsg = value;
                base.RaisePropertyChanged("TaskCount");
            }
        }
        private void Load()
        {
            //this.IsShowTitleList = true;
            this.MessageList = EsbHelper.Instance.WaitingMessages;
            
            if (this.MessageList == null)
                return;

            if (this.MessageList.Count > 0)
            {
                this.TaskMsg = "共有 " + this.MessageList.Count + " 条记录，您可在右侧面板添加或修改提醒铃声...";
            }
           
        }
        private void Timer_Message(object sender, System.Timers.ElapsedEventArgs e)
        {
            Load();
        }
        private void Send()
        {
            EsbHelper.Instance.SendMessage(MessageType.Commom, "local", "Hello World");
        }
    }
}
