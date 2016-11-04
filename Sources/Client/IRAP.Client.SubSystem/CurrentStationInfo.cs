using System;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.SubSystem
{
    public class CurrentStationInfo
    {
        private static string className =
        MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static CurrentStationInfo _instance = null;
        private StationInfo station = new StationInfo();

        private CurrentStationInfo()
        {
        }

        public static CurrentStationInfo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CurrentStationInfo();
                return _instance;
            }
        }

        public StationInfo Station
        {
            get { return station; }
        }

        public void GetStation()
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
                station = new StationInfo();

                IRAPSystemClient.Instance.sfn_GetInfo_Station(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref station,
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