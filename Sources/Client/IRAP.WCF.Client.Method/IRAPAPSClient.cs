using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

using IRAP.Global;


namespace IRAP.WCF.Client.Method
{
    public class IRAPAPSClient
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static IRAPAPSClient _instance = null;

        private IRAPAPSClient()
        {

        }

        public static IRAPAPSClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPAPSClient();
                return _instance;
            }
        }

        public void usp_RequestForMODispatching(
            int communityID,
            long pwoIssuingFactID,
            string moNumber,
            int moLineNo,
            long orderQty,
            long atpQty,
            long sysLogID,
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
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("pwoIssuingFactID", pwoIssuingFactID);
                hashParams.Add("moNumber", moNumber);
                hashParams.Add("moLineNo", moLineNo);
                hashParams.Add("orderQty", orderQty);
                hashParams.Add("atpQty", atpQty);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_RequestForMODispatching，输入参数：" +
                        "CommunityID={0}|PWOIssuingFactID={1}|MONumber={2}|" +
                        "MOLineNo={3}|OrderQty={4}|ATPQty={5}|" +
                        "SysLogID={6}",
                        communityID,
                        pwoIssuingFactID,
                        moNumber,
                        moLineNo,
                        orderQty,
                        atpQty,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.APS.dll",
                        "IRAP.BL.APS.IRAPAPS",
                        "usp_RequestForMODispatching",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="pwoIssuingFactID">工单签发事实编号</param>
        /// <param name="moNumber">制造订单号</param>
        /// <param name="moLineNo">制造订单行号</param>
        /// <param name="orderQty">订单数量</param>
        /// <param name="atpQty">物料齐套数量</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_RequestForMOQtyModification(
            int communityID,
            long pwoIssuingFactID,
            string moNumber,
            int moLineNo,
            long orderQty,
            long atpQty,
            long sysLogID,
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
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("pwoIssuingFactID", pwoIssuingFactID);
                hashParams.Add("moNumber", moNumber);
                hashParams.Add("moLineNo", moLineNo);
                hashParams.Add("orderQty", orderQty);
                hashParams.Add("atpQty", atpQty);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_RequestForMOQtyModification，输入参数：" +
                        "CommunityID={0}|PWOIssuingFactID={1}|MONumber={2}|" +
                        "MOLineNo={3}|OrderQty={4}|ATPQty={5}|" +
                        "SysLogID={6}",
                        communityID,
                        pwoIssuingFactID,
                        moNumber,
                        moLineNo,
                        orderQty,
                        atpQty,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.APS.dll",
                        "IRAP.BL.APS.IRAPAPS",
                        "usp_RequestForMOQtyModification",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
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