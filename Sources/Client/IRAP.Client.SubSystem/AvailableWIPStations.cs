using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

using IRAP.Global;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.SubSystem
{
    public class AvailableWIPStations
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static AvailableWIPStations _instance = null;
        private List<WIPStation> _stations = new List<WIPStation>();
        private ucOptions barOptions;

        private AvailableWIPStations()
        {

        }

        public static AvailableWIPStations Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AvailableWIPStations();
                return _instance;
            }
        }

        public List<WIPStation> Stations
        {
            get { return _stations; }
        }

        public ucOptions Options
        {
            get { return barOptions; }
            set { barOptions = value; }
        }

        public int GetWIPStations(int communityID, long sysLogID)
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
                _stations.Clear();

                IRAPMDMClient.Instance.ufn_GetList_WIPStationsOfAHost(
                    communityID,
                    sysLogID,
                    ref _stations,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                    return _stations.Count;
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
                            "Unable to get WIP Stations, reason: {0}",
                            error.Message));
                else
                    throw new Exception(
                        string.Format(
                            "无法获取当前站点的工位信息，原因：{0}",
                            error.Message));
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public int IndexOf(WIPStation station)
        {
            for (int i = 0; i < _stations.Count; i++)
            {
                if (_stations[i].T107LeafID == station.T107LeafID)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 根据 T107LeafID 从当面的工位列表中获取工位
        /// </summary>
        /// <param name="leafID"></param>
        /// <returns></returns>
        public WIPStation GetStationWithT107LeafID(int leafID)
        {
            WIPStation rlt = null;
            foreach (WIPStation station in _stations)
            {
                if (station.T107LeafID == leafID)
                {
                    rlt = station;
                    break;
                }
            }
            return rlt;
        }
    }
}
