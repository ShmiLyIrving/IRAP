using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using IRAP.Global;
using IRAPShared;

namespace IRAP.BL.FVS
{
    public class IRAPFVS : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static IRAPFVS _instance = null;

        public IRAPFVS()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        public static IRAPFVS Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPFVS();
                return _instance;
            }
        }

        public IRAPJsonResult ufn_GetT134ClickStream(
            int communityID, 
            long sysLogID, 
            out int errCode, 
            out string errText)
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ufn_GetT132ClickStream(
            int communityID, 
            long sysLogID, 
            out int errCode, 
            out string errText)
        {
            throw new System.NotImplementedException();
        }
    }
}
