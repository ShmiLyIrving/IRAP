using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Globalization;

using IRAP.Global;
using IRAP.Entity.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.SubSystems
{
    public class AvailableProcesses
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static AvailableProcesses _instance = null;
        private List<ProcessInfo> _processes = new List<ProcessInfo>();
        private ucOptions barOptions;

        private AvailableProcesses()
        {
            
        }

        public static AvailableProcesses Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AvailableProcesses();
                return _instance;
            }
        }

        public List<ProcessInfo> Processes
        {
            get { return _processes; }
        }

        public ucOptions Options
        {
            get { return barOptions; }
            set { barOptions = value; }
        }

        public int GetProcesses(int communityID, long sysLogID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                _processes.Clear();

                IRAPSystemClient.Instance.ufn_GetKanban_Processes(
                    communityID,
                    sysLogID,
                    ref _processes,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                    return _processes.Count;
                else
                    throw new Exception(errText);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                    throw new Exception(
                        string.Format(
                            "Unable to get products/processes, reason: {0}",
                            error.Message));
                else
                    throw new Exception(
                        string.Format(
                            "无法获取产品/流程，原因：{0}",
                            error.Message));
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }           
        }

        public int IndexOf(ProcessInfo process)
        {
            for (int i = 0; i < _processes.Count; i++)
            {
                if (_processes[i].T102LeafID == process.T102LeafID &&
                    _processes[i].T120LeafID == process.T120LeafID)
                    return i;
            }
            return -1;
        }
    }
}