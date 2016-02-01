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
    public class AvailableSubSystems
    {
        private static AvailableSubSystems _instance = null;
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private List<SystemInfo> subSystems = new List<SystemInfo>();

        private AvailableSubSystems()
        {
            
        }

        public static AvailableSubSystems Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AvailableSubSystems();
                return _instance;
            }
        }

        public List<SystemInfo> SubSystems
        {
            get { return subSystems; }
        }

        public int AvailableCount
        {
            get
            {
                int rlt = 0;
                foreach (SystemInfo system in subSystems)
                    if (system.Accessible)
                        rlt++;
                return rlt;
            }
        }

        public void GetSubSystems(int communityID, long sysLogID, int progLanguageID)
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
                subSystems.Clear();

                IRAPSystemClient.Instance.sfn_AvailableSystems(
                    communityID,
                    sysLogID,
                    progLanguageID,
                    ref subSystems,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                    throw new Exception(errText);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                throw error;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}