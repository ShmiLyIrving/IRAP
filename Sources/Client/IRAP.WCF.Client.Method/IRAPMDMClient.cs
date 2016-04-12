using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.MDM;

namespace IRAP.WCF.Client.Method
{
    public class IRAPMDMClient
    {
        private static IRAPMDMClient _instance = null;
        private static string className=
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private IRAPMDMClient()
        {
            
        }

        public static IRAPMDMClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPMDMClient();
                return _instance;
            }
        }

        /// <summary>
        /// 获取产品指定时点工艺流程
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="shotTime">
        /// 关注的时间点(yyyy-mm-dd hh:mm)，
        /// 注：当前版本传空串
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetInfo_ProductProcess(
            int communityID, 
            int t102LeafID, 
            string shotTime, 
            long sysLogID, 
            ref List<ProductProcess> datas, 
            out int errCode, 
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_ProductProcess，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|ShotTime={2}|"+
                        "SysLogID={3}",
                        communityID,
                        t102LeafID,
                        shotTime,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "ufn_GetInfo_ProductProcess",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<ProductProcess>;
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = -1001;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}