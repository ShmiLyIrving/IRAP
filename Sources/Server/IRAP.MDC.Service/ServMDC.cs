using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using IRAP.Global;

namespace IRAP.MDC.Service
{
    public partial class ServMDC : ServiceBase
    {
        //private AsynchronousSocketListener _socketServer = null;
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public ServMDC()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.Write("");
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            WriteLog.Instance.Write(
                string.Format("[{0}] 服务启动", ServiceName), 
                strProcedureName);

            try
            {
                WriteLog.Instance.IsWriteLog = true;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message);
            }

            // 旧版本使用 Socket Server 进行通讯 
            //try
            //{
            //    if (_socketServer == null)
            //    {
            //        _socketServer = new AsynchronousSocketListener();
            //    }
            //}
            //catch (Exception error)
            //{
            //    WriteLog.Instance.Write(error.Message, "创建 Socket Server.");
            //}

            //try
            //{
            //    _socketServer.Start();
            //}
            //catch (Exception error)
            //{
            //    WriteLog.Instance.Write(error.Message, "开始 Socket Listen.");
            //}

            // 2018.1.10 使用 TcpListener 进行通讯
            try
            {
                TTCPServer.Instance.ThreadRun();
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, "TcpListener");
            }
        }

        protected override void OnStop()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            //_socketServer.Stop();
            //_socketServer = null;
            TTCPServer.Instance.Stop();
            WriteLog.Instance.Write(
                string.Format("[{0}] 停止服务", ServiceName),
                strProcedureName);
            WriteLog.Instance.WriteEndSplitter(strProcedureName);
        }
    }
}
