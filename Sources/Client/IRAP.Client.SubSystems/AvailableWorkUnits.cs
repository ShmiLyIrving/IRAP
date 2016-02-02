using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.SubSystems
{
    public class AvailableWorkUnits
    {
        private static string className = 
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static AvailableWorkUnits _instance = null;
        private int processLeaf = 0;
        private List<WorkUnitInfo> _workUnits = new List<WorkUnitInfo>();

        private AvailableWorkUnits()
        {
        }

        public static AvailableWorkUnits Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AvailableWorkUnits();
                return _instance;
            }
        }

        public int ProcessLeaf
        {
            get { return processLeaf; }
        }

        public List<WorkUnitInfo> WorkUnits
        {
            get { return _workUnits; }
        }

        public int GetWorkUnits(int communityID, long sysLogID, int processLeaf)
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
                _workUnits.Clear();

                IRAPSystemClient.Instance.ufn_GetKanban_WorkUnits(
                    communityID,
                    sysLogID,
                    processLeaf,
                    ref _workUnits,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                    return _workUnits.Count;
                else
                    throw new Exception(errText);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                throw new Exception(
                    string.Format(
                        "无法获取工位/功能，原因：{0}",
                        error.Message));
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public int IndexOf(WorkUnitInfo workUnit)
        {
            for (int i = 0; i < _workUnits.Count; i++)
            {
                if (WorkUnits[i].WorkUnitLeaf == workUnit.WorkUnitLeaf)
                    return i;
            }
            return -1;
        }
    }
}