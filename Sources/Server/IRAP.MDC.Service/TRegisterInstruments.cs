using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.MDC.Service
{
    internal class TRegisterInstruments
    {
        private static TRegisterInstruments _instance = null;

        public static TRegisterInstruments Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TRegisterInstruments();
                return _instance;
            }
        }

        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        /// <summary>
        /// 在册测量仪表清单
        /// </summary>
        private List<RegInstrument> instruments = new List<RegInstrument>();

        private TRegisterInstruments() { }

        /// <summary>
        /// 当前获取到的在册测量仪表数
        /// </summary>
        public int Count
        {
            get { return instruments.Count; }
        }

        private void GetRegisterInstruments()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);

            int errCode = 0;
            string errText = "";

            try
            {
                IRAPMDMClient.Instance.ufn_GetList_RegInstruments(
                    TSysParams.Instance.CommunityID,
                    ref instruments,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    className);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, className);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public RegInstrument GetItem(string ipAddress)
        {
            if (instruments.Count <= 0)
                GetRegisterInstruments();

            foreach (RegInstrument item in instruments)
            {
                if (item.IPAddress == ipAddress)
                    return item;
            }
            return null;
        }
    }
}
