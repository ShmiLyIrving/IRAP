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
using System.ServiceModel;

using IRAP.Global;
using IRAP.General.Server.Library;

namespace IRAP.Server.Service
{
    public partial class WinServIRAPServer : ServiceBase
    {
        private static string className = 
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static ServiceHost _host = null;

        public WinServIRAPServer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteLog.Instance.WriteLogFileName = className;
            WriteLog.Instance.WriteBeginSplitter(className);
            WriteLog.Instance.Write("服务开始运行", className);

            try
            {
                if (_host == null)
                {
                    _host = new ServiceHost(typeof(ServiceIRAPGeneral));
                }
                _host.Open();
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, className);
                throw error;
            }
        }

        protected override void OnStop()
        {
            _host.Close();

            WriteLog.Instance.Write("服务终止运行", className);
            WriteLog.Instance.WriteEndSplitter(className);
            WriteLog.Instance.Write("");
        }
    }
}
