using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

using IRAP.Global;

namespace IRAP.WebService.Client.UES
{
    internal class WebServiceIRAPUES : WS_IRAPUES.IRAPUESBase
    {
        public WebServiceIRAPUES()
        {
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["WebServiceURL"] != null)
                Url = config.AppSettings.Settings["WebServiceURL"].Value.ToString();
            if (Url.Trim() == "")
                Url = "http://192.168.57.221:8015/IRAPUESWebService.asmx"; 
        }
    }

    public class IRAPUESClient
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static IRAPUESClient _instance = null;

        private IRAPUESClient() {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        public static IRAPUESClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPUESClient();
                return _instance;
            }
        }

        /// <summary>
        /// 查看指定设备当前正在生产的在制品标识信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码（不签权时传入 Anonymous）</param>
        /// <param name="sysLogID">系统登录标识（不签权时传入 1）</param>
        /// <param name="equipmentCode">设备编号</param>
        public void WIP_WIPID(
            int communityID,
            string userCode,
            long sysLogID,
            string equipmentCode,
            ref EntityWIPIDInfo wipInfo,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                using (WebServiceIRAPUES client = new WebServiceIRAPUES())
                {
                    try
                    {
                        string paramInput =
                            string.Format(
                                "<Parameters><Param ExCode=\"WIP_WIPID\" " +
                                "CommunityID=\"{0}\" UserCode=\"{1}\" " +
                                "SysLogID=\"{2}\" EquipmentCode=\"{3}\"/>" +
                                "</Parameters>",
                                communityID,
                                userCode,
                                sysLogID,
                                equipmentCode);
                        WriteLog.Instance.Write(
                            string.Format(
                                "调用 WebService，输入参数：[{0}]",
                                paramInput),
                            strProcedureName);
                        string rlt = client.IRAPUES(paramInput);



                    }
                    catch (Exception error)
                    {
                        errCode = -1001;
                        errText = error.Message;
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
