using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace IRAP.MDC.Service
{
    public partial class ServMDC : ServiceBase
    {
        private AsynchronousSocketListener _socketServer = null;

        public ServMDC()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                WriteLog.Instance.IsWriteLog = true;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message);
            }

            try
            {
                if (_socketServer == null)
                {
                    _socketServer = new AsynchronousSocketListener();
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, "创建 Socket Server.");
            }

            try
            {
                _socketServer.Start();
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, "开始 Socket Listen.");
            }
        }

        protected override void OnStop()
        {
            _socketServer.Stop();
            _socketServer = null;
        }
    }
}
