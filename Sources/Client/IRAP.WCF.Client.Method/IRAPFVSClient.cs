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
            long nextEventFactID,
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
                    hashParams.Add("nextEventFactID", nextEventFactID);
                    hashParams.Add("opID", opID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("satisfactoryLevel", satisfactoryLevel);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_AndonEventClose，输入参数：" +
                            "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                            "EventFactID={3}|NextEventFactID={4}|OpID={5}|" +
                            "UserCode={6}|SatisfactoryLevel={7}|" +
                            "SysLogID={8}",
                            communityID, transactNo, factID, eventFactID,
                            nextEventFactID, opID, userCode, satisfactoryLevel,
                            sysLogID),
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
        /// 安灯事件撤销
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="eventFactID">安灯事件标识</param>
        /// <param name="opID">业务操作标识</param>
        /// <param name="userCode">撤销人用户代码</param>
        /// <param name="veriCode">撤销授权码(短信)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_AndonEventCancel_Visteon(
            int communityID,
            long eventFactID,
            int opID,
            string userCode,
            string veriCode,
            string cancelReason,
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
                    hashParams.Add("cancelReason", cancelReason);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_AndonEventCancel，输入参数：" +
                            "CommunityID={0}|EventFactID={1}|OpID={2}|" +
                            "UserCode={3}|VeriCode={4}|CancelReason={5}|" +
                            "SysLogID={6}",
                            communityID, eventFactID, opID, userCode,
                            veriCode, cancelReason, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_AndonEventCancel_Visteon",
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

        /// <summary>
        /// 获取产线的安灯事件列表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t134LeafID">产线叶标识</param>
        /// <param name="t179LeafID">安灯事件类型叶标识</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetFactList_AndonEvents(
            int communityID,
            int t134LeafID,
            int t179LeafID,
            string beginDate,
            string endDate,
            long sysLogID,
            ref List<AndonEventFact> datas,
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
                    hashParams.Add("t179LeafID", t179LeafID);
                    hashParams.Add("beginDate", beginDate);
                    hashParams.Add("endDate", endDate);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_GetFactList_AndonEvents，输入参数：" +
                            "CommunityID={0}|T134LeafID={1}|T179LeafID={2}|" +
                            "BeginDate={3}|EndDate={4}|SysLogID={5}",
                            communityID, t134LeafID, t179LeafID, beginDate,
                            endDate, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetFactList_AndonEvents",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonEventFact>;
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
        /// 获取产线未关闭的安灯事件列表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="resourceTreeID">资源类型(211-工作中心 134-产线)</param>
        /// <param name="resourceLeafID">资源叶标识</param>
        public void ufn_GetList_OpenAndonEventsByLine(
            int communityID,
            int resourceTreeID,
            int resourceLeafID,
            ref List<OpenAndonEvent> datas,
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
                    hashParams.Add("resourceTreeID", resourceTreeID);
                    hashParams.Add("resourceLeafID", resourceLeafID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_GetList_OpenAndonEventsByLine，输入参数：" +
                            "CommunityID={0}|ResourceTreeID={1}|ResourceLeafID={2}",
                            communityID, resourceTreeID, resourceLeafID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_OpenAndonEventsByLine",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<OpenAndonEvent>;
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
        /// 保存停线记录4820关联安灯事件
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="andonEventID">关联的安灯事件FactID</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_SaveFact_StopEventFromAndon(
            int communityID,
            long transactNo,
            long factID,
            long andonEventID,
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
                    hashParams.Add("andonEventID", andonEventID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_StopEventFromAndon，输入参数：" +
                            "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                            "AndonEventID={3}|SysLogID={4}",
                            communityID, transactNo, factID, andonEventID,
                            sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_SaveFact_StopEventFromAndon",
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
        /// 生产异常监控看板：
        /// ⒈ 监控指定工厂结构范围(按产线目录树点击流)生产异常状况；
        /// ⒉ 可以产线或工作中心作为监控单元；
        /// ⒊ 支持六大类安灯事件类型。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t134ClickStream">工厂结构树点击流</param>
        /// <param name="resourceTreeID">资源树标识(134-产线；211-工作中心)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetKanban_ProductionSurveillance(
            int communityID,
            string t134ClickStream,
            int resourceTreeID,
            long sysLogID,
            ref List<ProductionSurveillance> datas,
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
                    hashParams.Add("t134ClickStream", t134ClickStream);
                    hashParams.Add("resourceTreeID", resourceTreeID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_GetKanban_ProductionSurveillance，输入参数：" +
                            "CommunityID={0}|T134ClickStream={1}|ResourceTreeID={2}|" +
                            "SysLogID={3}",
                            communityID, t134ClickStream, resourceTreeID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Kanbans",
                            "ufn_GetKanban_ProductionSurveillance",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ProductionSurveillance>;
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
        /// 设备维修安灯呼叫事件看板
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t134ClickStream">产线目录树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetAndonEventKanban_BMR(
            int communityID,
            string t134ClickStream,
            long sysLogID,
            ref List<AndonEventKanbanBMR> events,
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
                events.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("t134ClickStream", t134ClickStream);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_GetAndonEventKanban_BMR，输入参数：" +
                            "CommunityID={0}|T134ClickStream={1}|SysLogID={2}|",
                            communityID, t134ClickStream, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.AndonEventKanban",
                            "ufn_GetAndonEventKanban_BMR",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        events = rlt as List<AndonEventKanbanBMR>;
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
        /// <param name="t134ClickStream">产线目录树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetAndonEventKanban_LSR(
            int communityID,
            string t134ClickStream,
            long sysLogID,
            ref List<AndonEventKanbanLSR> events,
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
                events.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("t134ClickStream", t134ClickStream);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_GetAndonEventKanban_LSR，输入参数：" +
                            "CommunityID={0}|T134ClickStream={1}|SysLogID={2}|",
                            communityID, t134ClickStream, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.AndonEventKanban",
                            "ufn_GetAndonEventKanban_LSR",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        events = rlt as List<AndonEventKanbanLSR>;
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
        /// <param name="t134ClickStream">产线目录树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetAndonEventKanban_MDR(
            int communityID,
            string t134ClickStream,
            long sysLogID,
            ref List<AndonEventKanbanMDR> events,
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
                events.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("t134ClickStream", t134ClickStream);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_GetAndonEventKanban_MDR，输入参数：" +
                            "CommunityID={0}|T134ClickStream={1}|SysLogID={2}|",
                            communityID, t134ClickStream, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.AndonEventKanban",
                            "ufn_GetAndonEventKanban_MDR",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        events = rlt as List<AndonEventKanbanMDR>;
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
        /// <param name="t134ClickStream">产线目录树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetAndonEventKanban_QCR(int communityID,
            string t134ClickStream,
            long sysLogID,
            ref List<AndonEventKanbanQCR> events,
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
                events.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("t134ClickStream", t134ClickStream);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_GetAndonEventKanban_QCR，输入参数：" +
                            "CommunityID={0}|T134ClickStream={1}|SysLogID={2}|",
                            communityID, t134ClickStream, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.AndonEventKanban",
                            "ufn_GetAndonEventKanban_QCR",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        events = rlt as List<AndonEventKanbanQCR>;
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
        /// <param name="t134ClickStream">产线目录树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetAndonEventKanban_SPR(
            int communityID,
            string t134ClickStream,
            long sysLogID,
            ref List<AndonEventKanbanSPR> events,
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
                events.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("t134ClickStream", t134ClickStream);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_GetAndonEventKanban_SPR，输入参数：" +
                            "CommunityID={0}|T134ClickStream={1}|SysLogID={2}|",
                            communityID, t134ClickStream, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.AndonEventKanban",
                            "ufn_GetAndonEventKanban_SPR",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        events = rlt as List<AndonEventKanbanSPR>;
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
        /// <param name="t134ClickStream">产线目录树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetAndonEventKanban_TRR(
            int communityID,
            string t134ClickStream,
            long sysLogID,
            ref List<AndonEventKanbanTRR> events,
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
                events.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("t134ClickStream", t134ClickStream);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_GetAndonEventKanban_TRR，输入参数：" +
                            "CommunityID={0}|T134ClickStream={1}|SysLogID={2}|",
                            communityID, t134ClickStream, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.AndonEventKanban",
                            "ufn_GetAndonEventKanban_TRR",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        events = rlt as List<AndonEventKanbanTRR>;
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
        /// 获取安灯撤销的原因
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_AndonCancelReason(
            int communityID,
            long sysLogID,
            ref List<AndonCancelReason> datas,
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
                            "执行函数 ufn_GetList_AndonCancelReason，输入参数：" +
                            "CommunityID={0}|SysLogID={1}",
                            communityID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_AndonCancelReason",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonCancelReason>;
                    }
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
        /// 保存停线记录
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号（新发起时新申请，复核时传递未关闭的停线事件）</param>
        /// <param name="resourceTreeID">工作中心传211，生产线传134</param>
        /// <param name="resourceLeafID">工作中心或产线叶标识</param>
        /// <param name="eventFactIDs">关联安灯事件点击流 （发起新事件时传空）</param>
        /// <param name="andonEventID">关联的安灯事件FactID</param>
        /// <param name="t144LeafID">停线记录根源原因</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_SaveFact_StopEvent(
            int communityID,
            long transactNo,
            long factID,
            int resourceTreeID,
            int resourceLeafID,
            string eventFactIDs,
            int t144LeafID,
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
                    hashParams.Add("resourceTreeID", resourceTreeID);
                    hashParams.Add("resourceLeafID", resourceLeafID);
                    hashParams.Add("eventFactIDs", eventFactIDs);
                    hashParams.Add("t144LeafID", t144LeafID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format("执行存储过程 " +
                            "usp_SaveFact_StopEvent，参数：" +
                            "CommunityID={0}|TransactNo={1}|FactID={2}|ResourceTreeID={3}|" +
                            "ResourceLeafID={4}|EventFactIDs={5}|T144LeafID={6}|SysLogID={7}",
                            communityID, transactNo, factID, resourceTreeID,
                            resourceLeafID, eventFactIDs, t144LeafID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.IRAPFVS",
                        "usp_SaveFact_StopEvent",
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
        /// 当前工单执行期间发起的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void ufn_GetList_PeriodAndonEvents(
            int communityID,
            long sysLogID,
            ref List<PeriodAndonEvent> datas,
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
                            "执行函数 ufn_GetList_PeriodAndonEvents，输入参数：" +
                            "CommunityID={0}|SysLogID={1}",
                            communityID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.IRAPFVS",
                            "ufn_GetList_PeriodAndonEvents",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<PeriodAndonEvent>;
                    }
                    #endregion

#if DEBUG
                    for (int i = 1; i <= 10; i++)
                        datas.Add(
                            new PeriodAndonEvent()
                            {
                                Ordinal = i,
                                EventFactID = 101 + i,
                                Description = string.Format("[{0}]{1}", i, "D13-01-SGM A3 Cluster代码为[1216900027]的SGM A3 CAT发生故障：故障"),
                                CallTime = "2016-12-12 12:50:18",
                                ClosedTime = "2016-12-14 09:29:43",
                            });
#endif
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
        /// 获取未关联的停线事件
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void ufn_GetList_PeriodStopEvents(
            int communityID,
            long sysLogID,
            ref List<PeriodStopEvent> datas,
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
                            "执行函数 ufn_GetList_PeriodStopEvents，输入参数：" +
                            "CommunityID={0}|SysLogID={1}",
                            communityID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.IRAPFVS",
                            "ufn_GetList_PeriodStopEvents",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<PeriodStopEvent>;
                    }
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
        /// 根据指定的生产任务种类标识获取生产工单列表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t103LeafID">生产任务种类标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetKanban_PWOSurveillance(
            int communityID,
            int t103LeafID,
            long sysLogID,
            ref List<PWOSurveillance> datas,
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
                    hashParams.Add("t103LeafID", t103LeafID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_GetKanban_PWOSurveillance，输入参数：" +
                            "CommunityID={0}|T103LeafID={1}|SysLogID={2}",
                            communityID, t103LeafID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Kanbans",
                            "ufn_GetKanban_PWOSurveillance",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<PWOSurveillance>;
                    }
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
        /// 获取制造订单跟踪看板
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t132ClickStream">产品族树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_Dashboard_MOTrack(
            int communityID,
            string t132ClickStream,
            long sysLogID,
            ref List<Dashboard_MOTrack> datas,
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
                    hashParams.Add("t132ClickStream", t132ClickStream);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_Dashboard_MOTrack，输入参数：" +
                            "CommunityID={0}|T132ClickStream={1}|SysLogID={2}",
                            communityID, t132ClickStream, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Dashboards",
                            "ufn_Dashboard_MOTrack",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<Dashboard_MOTrack>;
                    }
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
        /// 获取工单物料配送监控看板
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t132ClickStream">产品族树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_Dashboard_MODelivery(
            int communityID,
            string t132ClickStream,
            long sysLogID,
            ref List<Dashboard_MODelivery> datas,
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
                    hashParams.Add("t132ClickStream", t132ClickStream);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_Dashboard_MODelivery，输入参数：" +
                            "CommunityID={0}|T132ClickStream={1}|SysLogID={2}",
                            communityID, t132ClickStream, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Dashboards",
                            "ufn_Dashboard_MODelivery",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<Dashboard_MODelivery>;
                    }
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
        /// 获取工单物料配送监控看板
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t134ClickStream">产线点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_Dashboard_WorkUnitProductionProgress(
            int communityID,
            string t134ClickStream,
            long sysLogID,
            ref List<Dashboard_WorkUnitProductionProgress> datas,
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
                    hashParams.Add("t134ClickStream", t134ClickStream);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_Dashboard_WorkUnitProductionProgress，输入参数：" +
                            "CommunityID={0}|T134ClickStream={1}|SysLogID={2}",
                            communityID, t134ClickStream, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Dashboards",
                            "ufn_Dashboard_WorkUnitProductionProgress",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<Dashboard_WorkUnitProductionProgress>;
                    }
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
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t132ClickStream">产品族点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_Dashboard_WIPWaiting(
            int communityID,
            string t132ClickStream,
            long sysLogID,
            ref List<Dashboard_WIPWaiting> datas,
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
                    hashParams.Add("t132ClickStream", t132ClickStream);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_Dashboard_WIPWaiting，输入参数：" +
                            "CommunityID={0}|T132ClickStream={1}|SysLogID={2}",
                            communityID, t132ClickStream, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Dashboards",
                            "ufn_Dashboard_WIPWaiting",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<Dashboard_WIPWaiting>;
                    }
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
        /// 获取当前签到的员工
        /// </summary>
        /// <param name="communityID">社区标识</param>
        public void ufn_GetInfo_AtWork(
            int communityID,
            ref List<EmployeeAtWork> datas,
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
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行函数 ufn_GetInfo_AtWork，输入参数：" +
                            "CommunityID={0}",
                            communityID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.IRAPFVS",
                            "ufn_GetInfo_AtWork",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<EmployeeAtWork>;
                    }
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
    }
}