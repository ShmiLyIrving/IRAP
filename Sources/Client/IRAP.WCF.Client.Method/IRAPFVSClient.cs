using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.FVS;
using IRAP.Entities.FVS;

namespace IRAP.WCF.Client.Method
{
    public class IRAPFVSClient
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static IRAPFVSClient _instance = null;

        private IRAPFVSClient()
        {
        }

        public static IRAPFVSClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPFVSClient();
                return _instance;
            }
        }

        public void ufn_GetT132ClickStream(
            int communityID,
            long sysLogID,
            ref string t132ClickStream,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                t132ClickStream = "";

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetT132ClickStream，输入参数：" +
                        "CommunityID={0}|SysLogID={1}",
                        communityID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.IRAPFVS",
                        "ufn_GetT132ClickStream",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        t132ClickStream = rlt as string;
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

        public void ufn_GetT134ClickStream(
            int communityID,
            long sysLogID,
            ref string t134ClickStream,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                t134ClickStream = "";

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetT134ClickStream，输入参数：" +
                        "CommunityID={0}|SysLogID={1}",
                        communityID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.IRAPFVS",
                        "ufn_GetT134ClickStream",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        t134ClickStream = rlt as string;
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
        /// 获取当前站点绑定产线的安灯告警灯状态
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_AndonLightStatus(
            int communityID,
            long sysLogID,
            ref List<AndonLightStatus> datas,
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
                datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_AndonLightStatus 函数， " +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_AndonLightStatus",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonLightStatus>;
                    }
                }
                #endregion
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 从产线触发安灯呼叫：
        /// ⒈ 呼叫产线设备的故障维修；
        /// ⒉ 呼叫产线的原辅材料及半成品配送；
        /// ⒊ 呼叫产线在制品的质量问题解决；
        /// ⒋ 呼叫产线设备的工装更换；
        /// ⒌ 呼叫产线安全问题解决；
        /// ⒍ 呼叫产线其他干系人现场支持
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="t179LeafID">安灯事件类型叶标识</param>
        /// <param name="t134LeafID">呼叫产线叶标识</param>
        /// <param name="t133LeafID">呼叫设备叶标识</param>
        /// <param name="objectTreeID">呼叫对象树标识</param>
        /// <param name="objectLeafID">呼叫对象叶标识</param>
        /// <param name="objectCode">呼叫对象代码</param>
        /// <param name="productionDown">是否已停产(0-未停产；1-已停产)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_SaveFact_AndonEventCallFromProductionLine(
            int communityID,
            long transactNo,
            long factID,
            int t179LeafID,
            int t134LeafID,
            int t133LeafID,
            int objectTreeID,
            int objectLeafID,
            string objectCode,
            bool productionDown,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("transactNo", transactNo);
                    hashParams.Add("factID", factID);
                    hashParams.Add("t179LeafID", t179LeafID);
                    hashParams.Add("t134LeafID", t134LeafID);
                    hashParams.Add("t133LeafID", t133LeafID);
                    hashParams.Add("objectTreeID", objectTreeID);
                    hashParams.Add("objectLeafID", objectLeafID);
                    hashParams.Add("objectCode", objectCode);
                    hashParams.Add("productionDown", productionDown);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_AndonEventCallFromProductionLine，输入参数：" +
                            "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                            "T179LeafID={3}|T134LeafID={4}|T133LeafID={5}|" +
                            "ObjectTreeID={6}|ObjectLeafID={7}|ObjectCode={8}|" +
                            "ProductionDown={9}|SysLogID={10}",
                            communityID, transactNo, factID, t179LeafID, t134LeafID,
                            t133LeafID, objectTreeID, objectLeafID, objectCode,
                            productionDown, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_SaveFact_AndonEventCallFromProductionLine",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件现场响应
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="eventFactID">安灯事件标识</param>
        /// <param name="opID">业务操作标识</param>
        /// <param name="userCode">关闭人用户代码</param>
        /// <param name="sysLogID">关闭站点系统登录标识</param>
        public void usp_SaveFact_AndonEventOnSiteRespond(
            int communityID,
            long transactNo,
            long factID,
            long eventFactID,
            int opID,
            string userCode,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("transactNo", transactNo);
                    hashParams.Add("factID", factID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("opID", opID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_AndonEventOnSiteRespond，输入参数：" +
                            "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                            "EventFactID={3}|OpID={4}|UserCode={5}|SysLogID={6}",
                            communityID, transactNo, factID, eventFactID, opID,
                            userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_SaveFact_AndonEventOnSiteRespond",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件关闭
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="eventFactID">安灯事件标识</param>
        /// <param name="opID">业务操作标识</param>
        /// <param name="userCode">关闭人用户代码</param>
        /// <param name="satisfactoryLevel">
        /// 满意度评价：
        /// 1-非常满意；
        /// 2-满意；
        /// 3-一般；
        /// 4-不满意
        /// </param>
        /// <param name="sysLogID">关闭站点系统登录标识</param>
        public void usp_SaveFact_AndonEventClose(
            int communityID,
            long transactNo,
            long factID,
            long eventFactID,
            int opID,
            string userCode,
            int satisfactoryLevel,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("transactNo", transactNo);
                    hashParams.Add("factID", factID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("opID", opID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("satisfactoryLevel", satisfactoryLevel);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_AndonEventClose，输入参数：" +
                            "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                            "EventFactID={3}|OpID={4}|UserCode={5}|" +
                            "SatisfactoryLevel={6}|SysLogID={7}",
                            communityID, transactNo, factID, eventFactID, opID,
                            userCode, satisfactoryLevel, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_SaveFact_AndonEventClose",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取待响应的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="sysLogID">响应站点系统登录标识</param>
        public void ufn_GetList_AndonEventsToRespond(
            int communityID,
            string userCode,
            long sysLogID,
            ref List<AndonRspEventInfo> datas,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_AndonEventsToRespond，输入参数：" +
                            "CommunityID={0}|UserCode={1}|SysLogID={2}",
                            communityID, userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_AndonEventsToRespond",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonRspEventInfo>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取待关闭的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_AndonEventsToClose(
            int communityID,
            long sysLogID,
            ref List<AndonEventToClose> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_AndonEventsToClose，输入参数：" +
                            "CommunityID={0}|SysLogID={1}",
                            communityID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_AndonEventsToClose",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonEventToClose>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取可撤销的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="sysLogID">响应站点系统登录标识</param>
        public void ufn_GetList_AndonEventsToCancel(
            int communityID,
            string userCode,
            long sysLogID,
            ref List<AndonEventInfo> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_AndonEventsToCancel，输入参数：" +
                            "CommunityID={0}|UserCode={1}|SysLogID={2}",
                            communityID, userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_AndonEventsToCancel",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonEventInfo>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件撤销授权请求
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="eventID">申请授权事件标识(事实编号/交易号)</param>
        /// <param name="userCode">申请授权人用户代码</param>
        /// <param name="userName">申请授权人姓名</param>
        /// <param name="menuItemID">当前菜单项标识</param>
        /// <param name="t2LeafID">授权人角色叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_AuthorizationRequest(
            int communityID,
            long eventID,
            string userCode,
            string userName,
            int menuItemID,
            int t2LeafID,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventID", eventID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("userName", userName);
                    hashParams.Add("menuItemID", menuItemID);
                    hashParams.Add("t2LeafID", t2LeafID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_AuthorizationRequest，输入参数：" +
                            "CommunityID={0}|EventID={1}|UserCode={2}|" +
                            "UserName={3}|MenuItemID={4}|T2LeafID={5}|" +
                            "SysLogID={6}",
                            communityID, eventID, userCode, userName, menuItemID,
                            t2LeafID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_AuthorizationRequest",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件撤销
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="eventFactID">安灯事件标识</param>
        /// <param name="opID">业务操作标识</param>
        /// <param name="userCode">撤销人用户代码</param>
        /// <param name="veriCode">撤销授权码(短信)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_AndonEventCancel(
            int communityID,
            long eventFactID,
            int opID,
            string userCode,
            string veriCode,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("opID", opID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("veriCode", veriCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_AndonEventCancel，输入参数：" +
                            "CommunityID={0}|EventFactID={1}|OpID={2}|" +
                            "UserCode={3}|VeriCode={4}|SysLogID={5}",
                            communityID, eventFactID, opID, userCode,
                            veriCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_AndonEventCancel",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取本人已响应未关闭的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="sysLogID">响应站点系统登录标识</param>
        public void ufn_GetList_AndonEventsToForward(
            int communityID,
            string userCode,
            long sysLogID,
            ref List<AndonEventInfo> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_AndonEventsToForward，输入参数：" +
                            "CommunityID={0}|UserCode={1}|SysLogID={2}",
                            communityID, userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_AndonEventsToForward",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonEventInfo>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void ufn_GetList_ResponsibleRespondersToInform(
            int communityID,
            long eventFactID,
            int opID,
            long sysLogID,
            ref List<ResponsibleResponderInfo> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("opID", opID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_ResponsibleRespondersToInform，输入参数：" +
                            "CommunityID={0}|EventFactID={1}|OpID={2}|SysLogID={3}",
                            communityID, eventFactID, opID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_ResponsibleRespondersToInform",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ResponsibleResponderInfo>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件追加呼叫（呼叫本部门人员）
        /// </summary>
        public void usp_AndonEventForwarding(
            int communityID,
            long eventFactID,
            int opID,
            int ordinal,
            string userCode,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("opID", opID);
                    hashParams.Add("ordinal", ordinal);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_AndonEventForwarding，输入参数：" +
                            "CommunityID={0}|EventFactID={1}|OpID={2}|" +
                            "Ordinal={3}|UserCode={4}|SysLogID={5}",
                            communityID, eventFactID, opID, ordinal,
                            userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_AndonEventForwarding",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件追加呼叫（跨部门呼叫人员）
        /// </summary>
        public void usp_AndonEventForwardingEx(
            int communityID,
            long eventFactID,
            int opID,
            int ordinal,
            string userCode,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("opID", opID);
                    hashParams.Add("ordinal", ordinal);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_AndonEventForwardingEx，输入参数：" +
                            "CommunityID={0}|EventFactID={1}|OpID={2}|" +
                            "Ordinal={3}|UserCode={4}|SysLogID={5}",
                            communityID, eventFactID, opID, ordinal,
                            userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_AndonEventForwardingEx",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void ufn_EWI_GetInfo_ShowPaper(
            int communityID,
            int processLeaf,
            int workUnitLeaf,
            long sysLogID,
            ref EWIShowPaperInfo data,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                data = new EWIShowPaperInfo();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("processLeaf", processLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_EWI_GetInfo_ShowPaper，输入参数：" +
                        "CommunityID={0}|ProcessLeaf={1}|WorkUnitLeaf={2}|SysLogID={3}",
                        communityID,
                        processLeaf,
                        workUnitLeaf,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.EWI",
                        "ufn_EWI_GetInfo_ShowPaper",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as EWIShowPaperInfo;
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

        public void ufn_EWI_GetInfo_PSShowPaper(
            int communityID,
            int processLeaf,
            int workUnitLeaf,
            long sysLogID,
            ref EWIPSShowPaperInfo data,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                data = new EWIPSShowPaperInfo();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("processLeaf", processLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_EWI_GetInfo_PSShowPaper，输入参数：" +
                        "CommunityID={0}|ProcessLeaf={1}|WorkUnitLeaf={2}|SysLogID={3}",
                        communityID,
                        processLeaf,
                        workUnitLeaf,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.EWI",
                        "ufn_EWI_GetInfo_PSShowPaper",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as EWIPSShowPaperInfo;
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
        /// 获取生产异常问题根源类型列表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t134LeafID">产线叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_AnomalyCauseTypes(
            int communityID,
            int t134LeafID,
            long sysLogID,
            ref List<AnomalyCauseType> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("t134LeafID", t134LeafID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_AnomalyCauseTypes，输入参数：" +
                            "CommunityID={0}|T134LeafID={1}|SysLogID={2}",
                            communityID, t134LeafID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.IRAPFVS",
                            "ufn_GetList_AnomalyCauseTypes",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AnomalyCauseType>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetDashboard_FTT(
            int communityID,
            long sysLogID,
            ref List<Dashboard_KPI> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetDashboard_FTT，输入参数：" +
                            "CommunityID={0}|SysLogID={1}",
                            communityID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Dashboards",
                            "ufn_GetDashboard_FTT",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<Dashboard_KPI>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetDashboard_BTS(
            int communityID,
            long sysLogID,
            ref List<Dashboard_KPI> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetDashboard_BTS，输入参数：" +
                            "CommunityID={0}|SysLogID={1}",
                            communityID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Dashboards",
                            "ufn_GetDashboard_BTS",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<Dashboard_KPI>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetDashboard_OEE(
            int communityID,
            long sysLogID,
            ref List<Dashboard_KPI> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetDashboard_OEE，输入参数：" +
                            "CommunityID={0}|SysLogID={1}",
                            communityID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Dashboards",
                            "ufn_GetDashboard_OEE",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<Dashboard_KPI>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取当前工单执行的瞬时达成率
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="resourceTreeID">产线或工作中心（134/211）</param>
        /// <param name="resourceLeafID">产线或工作中心叶标识</param>
        /// <param name="nowTime">当前时间(传入空串表示当前时间)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetInfo_LineKPI_BTS(
            int communityID,
            int resourceTreeID,
            int resourceLeafID,
            string nowTime,
            long sysLogID,
            ref LineKPI_BTS data,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                data = new LineKPI_BTS();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("resourceTreeID", resourceTreeID);
                hashParams.Add("resourceLeafID", resourceLeafID);
                hashParams.Add("nowTime", nowTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_LineKPI_BTS，输入参数：" +
                        "CommunityID={0}|ResourceTreeID={1}|" +
                        "ResourceLeafID={2}|NowTime={3}|SysLogID={4}",
                        communityID,
                        resourceTreeID,
                        resourceLeafID,
                        nowTime,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.WorkOrder",
                        "ufn_GetInfo_LineKPI_BTS",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as LineKPI_BTS;
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

        /// <param name="communityID">社区标识</param>
        /// <param name="pwoNo">工单编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetTrend_FTTofAPWO(
            int communityID,
            string pwoNo,
            long sysLogID,
            ref List<TrendFTTofAPWO> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("pwoNo", pwoNo);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetTrend_FTTofAPWO，输入参数：" +
                            "CommunityID={0}|PWONo={1}|SysLogID={2}",
                            communityID, pwoNo, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.WorkOrder",
                            "ufn_GetTrend_FTTofAPWO",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<TrendFTTofAPWO>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetStructure_FFTofAPWO(
            int communityID,
            string pwoNo,
            long sysLogID,
            ref List<Structure_FFTofAPWO> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("pwoNo", pwoNo);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetStructure_FFTofAPWO，输入参数：" +
                            "CommunityID={0}|PWONo={1}|SysLogID={2}",
                            communityID, pwoNo, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.WorkOrder",
                            "ufn_GetStructure_FFTofAPWO",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<Structure_FFTofAPWO>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据安灯事件事实编号，获取相关干系人列表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="eventFactID">安灯事件事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_EventStakeholders(
            int communityID,
            long eventFactID,
            long sysLogID,
            ref List<EventStakeholder> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_EventStakeholders，输入参数：" +
                            "CommunityID={0}|EventFactID={1}|SysLogID={2}",
                            communityID, eventFactID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_EventStakeholders",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<EventStakeholder>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取已响应的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="sysLogID">响应站点系统登录标识</param>
        public void ufn_GetList_AndonEventsResponded(
            int communityID,
            string userCode,
            long sysLogID,
            ref List<AndonRspedEventInfo> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_AndonEventsResponded，输入参数：" +
                            "CommunityID={0}|UserCode={1}|SysLogID={2}",
                            communityID, userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_AndonEventsResponded",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonRspedEventInfo>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 保存安灯事件会诊呼叫事实
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="eventFactID">安灯事件标识</param>
        /// <param name="newEventType">新确定的安灯事件标识</param>
        /// <param name="objectTreeID">对象树标识</param>
        /// <param name="objectCode">新确定的设备代码，或者人员代码</param>
        /// <param name="attrLeafID">失效模式叶标识</param>
        /// <param name="t144LeafID">原因叶标识</param>
        /// <param name="remark">备注信息</param>
        /// <param name="userCode">会诊呼叫人员用户代码</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_SaveFact_AndonEventConsultation(
            int communityID,
            long eventFactID,
            int newEventType,
            int objectTreeID,
            string objectCode,
            int attrLeafID,
            int t144LeafID,
            string remark,
            string userCode,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("newEventType", newEventType);
                    hashParams.Add("objectTreeID", objectTreeID);
                    hashParams.Add("objectCode", objectCode);
                    hashParams.Add("attrLeafID", attrLeafID);
                    hashParams.Add("t144LeafID", t144LeafID);
                    hashParams.Add("remark", remark);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_AndonEventConsultation，输入参数：" +
                            "CommunityID={0}|EventFactID={1}|NewEventType={2}|" +
                            "ObjectTreeID={3}|ObjectCode={4}|AttrLeafID={5}|" +
                            "T144LeafID={6}|Remark={7}|UserCode={8}|SysLogID={9}",
                            communityID, eventFactID, newEventType, objectTreeID,
                            objectCode, attrLeafID, t144LeafID, remark, userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_SaveFact_AndonEventConsultation",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取当前产线正在会诊的安灯事件及干系人清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_EventsToConsultation(
            int communityID,
            long sysLogID,
            ref List<EventToConsultation> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_EventsToConsultation，输入参数：" +
                            "CommunityID={0}|SysLogID={1}",
                            communityID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_EventsToConsultation",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<EventToConsultation>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 更新安灯事件的 T144LeafID 和备注
        /// </summary>
        public void usp_SaveFact_AndonEventNote(
            int communityID,
            long eventFactID,
            int t144LeafID,
            string remark,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("t144LeafID", t144LeafID);
                    hashParams.Add("remark", remark);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_AndonEventClose_Visteon，输入参数：" +
                            "CommunityID={0}|EventFactID={1}|" +
                            "T144LeafID={2}|Remark={3}|SysLogID={4}",
                            communityID, eventFactID, t144LeafID, remark, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_SaveFact_AndonEventNote",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取指定事实编号安灯事件的原因叶标识
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="eventFactID">安灯事件事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetT144LeafID(
            int communityID,
            long eventFactID,
            long sysLogID,
            ref int t144LeafID,
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
                t144LeafID = 0;

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetT144LeafID，输入参数：" +
                            "CommunityID={0}|EventFactID={1}|SysLogID={2}",
                            communityID, eventFactID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetT144LeafID",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        t144LeafID = (int)rlt;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}