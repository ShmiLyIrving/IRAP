using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

using IRAP.Global;
using IRAP.Entity.MES;
using IRAP.Entities.MES;

namespace IRAP.WCF.Client.Method
{
    public class IRAPMESClient
    {
        private static IRAPMESClient _instance = null;
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private IRAPMESClient()
        {

        }

        public static IRAPMESClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPMESClient();
                return _instance;
            }
        }

        /// <summary>
        /// 获取SPC控制图信息：⒈ 支持彩虹图；⒉ 支持Xbar-R图
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="t47LeafID">SPC控制图类型代码：373564-彩虹图；373565-Xbar-R图</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t133LeafID">设备叶标识</param>
        /// <param name="t20LeafID">工艺参数叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetInfo_SPCChart(
            int communityID,
            string pwoNo,
            int t47LeafID,
            int t216LeafID,
            int t133LeafID,
            int t20LeafID,
            long sysLogID,
            ref EntitySPCChart data,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                data = new EntitySPCChart();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("pwoNo", pwoNo);
                hashParams.Add("t47LeafID", t47LeafID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t133LeafID", t133LeafID);
                hashParams.Add("t20LeafID", t20LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_SPCChart，输入参数：" +
                        "CommunityID={0}|PWONo={1}|T47LeafID={2}|" +
                        "T216LeafID={3}|T133LeafID={4}|T20LeafID={5}|" +
                        "SysLogID={6}",
                        communityID,
                        pwoNo,
                        t47LeafID,
                        t216LeafID,
                        t133LeafID,
                        t20LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.QC",
                        "ufn_GetInfo_SPCChart",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = (EntitySPCChart)rlt;
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
        /// 统计过程重置
        /// ⒈ 更新工艺调整时间点为当前时间点，从此时点以后的数据计入SPC图；
        /// ⒉ 写工艺调整日志。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="c1ID">产品工位关联标识</param>
        /// <param name="t47LeafID">SPC控制图标识号：373564-彩虹图；373565-XBarR图</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_WriteLog_SPCReset(
            int communityID,
            int c1ID,
            int t47LeafID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("c1ID", c1ID);
                hashParams.Add("t47LeafID", t47LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_WriteLog_SPCReset，输入参数：" +
                        "CommunityID={0}|C1ID={1}|T47LeafID={2}|" +
                        "SysLogID={3}",
                        communityID,
                        c1ID,
                        t47LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.QC",
                        "usp_WriteLog_SPCReset",
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
        /// 设置统计过程控制中 XBar-R 图的上下控制线
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="c1ID">产品工位关联标识</param>\
        /// <param name="t47LeafID">SPC控制图标识号：373564-彩虹图；373565-XBarR图</param>
        /// <param name="lcl">XBar 控制线下限</param>
        /// <param name="ucl">XBar 控制线上限</param>
        /// <param name="rlcl">R 控制线下限</param>
        /// <param name="rucl">R 控制线上限</param>
        /// <param name="rbar">R 的均值</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_WriteLog_SPCCtrlLineSet(
            int communityID,
            int c1ID,
            int t47LeafID,
            long lcl,
            long ucl,
            long rlcl,
            long rucl,
            long rbar,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("c1ID", c1ID);
                hashParams.Add("t47LeafID", t47LeafID);
                hashParams.Add("lcl", lcl);
                hashParams.Add("ucl", ucl);
                hashParams.Add("rlcl", rlcl);
                hashParams.Add("rucl", rucl);
                hashParams.Add("rbar", rbar);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_WriteLog_SPCCtrlLineSet，输入参数：" +
                        "CommunityID={0}|C1ID={1}|T47LeafID={2}|" +
                        "LCL={3}|UCL={4}|RLCL={5}|RUCL={6}|RBar={7}|" +
                        "SysLogID={8}",
                        communityID,
                        c1ID,
                        t47LeafID,
                        lcl,
                        ucl,
                        rlcl,
                        rucl,
                        rbar,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.QC",
                        "usp_WriteLog_SPCCtrlLineSet",
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

        public void ufn_GetInfo_WIPBarcode(
            int communityID,
            string barcode,
            int processLeaf,
            int workUnitLeaf,
            ref WIPBarCodeInfo data,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("barcode", barcode);
                hashParams.Add("processLeaf", processLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_WIPBarcode，输入参数：" +
                        "CommunityID={0}|Barcode={1}|ProcessLeaf={2}|" +
                        "WorkUnitLeaf={3}",
                        communityID,
                        barcode,
                        processLeaf,
                        workUnitLeaf),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.IRAPMES",
                        "ufn_GetInfo_WIPBarcode",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as WIPBarCodeInfo;
                    else
                        data = new WIPBarCodeInfo();
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
        /// 获取指定产线未结工单清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="resourceTreeID">菜单参数(134)</param>
        /// <param name="leafID">产线的叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_OpenPWOsOfALine(
            int communityID,
            int resourceTreeID,
            int leafID,
            long sysLogID,
            ref List<OpenPWO> datas,
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
                hashParams.Add("resourceTreeID", resourceTreeID);
                hashParams.Add("leafID", leafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_OpenPWOsOfALine 函数， " +
                        "参数：CommunityID={0}|ResourceTreeID={1}|" +
                        "LeafID={2}|SysLogID={3}",
                        communityID,
                        resourceTreeID,
                        leafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.WorkOrder",
                            "ufn_GetList_OpenPWOsOfALine",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<OpenPWO>;
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
        /// 获取指定产品未关闭的变更事项
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetFactList_OpenChanges(
            int communityID,
            int t102LeafID,
            long sysLogID,
            ref List<OpenChangeInfo> datas,
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
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetFactList_OpenChanges 函数， " +
                        "参数：CommunityID={0}|T102LeafID={1}|" +
                        "SysLogID={2}",
                        communityID,
                        t102LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.IRAPMES",
                            "ufn_GetFactList_OpenChanges",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<OpenChangeInfo>;
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
        /// 获取产品相关未关闭变更事项的类别汇总信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[OpenChangeSummary]</returns>
        public void ufn_GetSummary_OpenChanges(
            int communityID,
            int t102LeafID,
            long sysLogID,
            ref List<OpenChangeSummary> datas,
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
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetSummary_OpenChanges 函数， " +
                        "参数：CommunityID={0}|T102LeafID={1}|" +
                        "SysLogID={2}",
                        communityID,
                        t102LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.IRAPMES",
                            "ufn_GetSummary_OpenChanges",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<OpenChangeSummary>;
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

        public void usp_ManufactureRecord(
            int communityID,
            long transactNo,
            long factID,
            int processLeaf,
            int workUnitLeaf,
            string wipBarcode,
            string productSN,
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
                hashParams.Add("transactNo", transactNo);
                hashParams.Add("factID", factID);
                hashParams.Add("processLeaf", processLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("wipBarcode", wipBarcode);
                hashParams.Add("productSN", productSN);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_ManufactureRecord，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|FactID={2}|ProcessLeaf={3}|" +
                        "WorkUnitLeaf={4}|WIPBarcode={5}|ProductSN={6}|SysLogID={7}",
                        communityID, transactNo, factID, productSN, workUnitLeaf,
                        wipBarcode, productSN, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.IRAPMES",
                        "usp_ManufactureRecord",
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
        /// 解析WIPIDCode在当前工位上生产是否OK
        /// ⒈ 路由是否停滞在本工位；
        /// ⒉ 产品是否当前选中产品；
        /// ⒊ 是否合法的在制品标识或在制品容器标识。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="wipIDCode">在制品标识</param>
        /// <param name="productLeaf">当前选中产品叶标识</param>
        /// <param name="workUnitLeaf">当前选中工位叶标识</param>
        /// <param name="isEnhanced">是否增强</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetInfo_WIPIDCode(
            int communityID,
            string wipIDCode,
            int productLeaf,
            int workUnitLeaf,
            bool isEnhanced,
            long sysLogID,
            ref WIPIDCode data,
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
                data = new WIPIDCode();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("wipIDCode", wipIDCode);
                hashParams.Add("productLeaf", productLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("isEnhanced", isEnhanced);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_WIPIDCode 函数， " +
                        "参数：CommunityID={0}|WIPIDCode={1}|" +
                        "ProductLeaf={2}|WorkUnitLeaf={3}|" +
                        "IsEnhanced={4}|SysLogID={5}",
                        communityID,
                        wipIDCode,
                        productLeaf,
                        workUnitLeaf,
                        isEnhanced,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.WIP",
                            "ufn_GetInfo_WIPIDCode",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        data = rlt as WIPIDCode;
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
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void ufn_GetList_ProducingPWOFromWorkUnit(
            int communityID,
            int t102LeafID,
            int t107LeafID,
            long sysLogID,
            ref List<ProducingPWOFromWorkUnit> datas,
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
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_ProducingPWOFromWorkUnit 函数， " +
                        "参数：CommunityID={0}|T102LeafID={1}|" +
                        "T107LeafID={2}|SysLogID={3}",
                        communityID,
                        t102LeafID,
                        t107LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.WorkOrder",
                            "ufn_GetList_ProducingPWOFromWorkUnit",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ProducingPWOFromWorkUnit>;
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
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void ufn_GetList_ToDoPWOFromWorkUnit(
            int communityID,
            int t102LeafID,
            int t107LeafID,
            long sysLogID,
            ref List<ToDoPWOFromWorkUnit> datas,
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
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_ToDoPWOFromWorkUnit 函数， " +
                        "参数：CommunityID={0}|T102LeafID={1}|" +
                        "T107LeafID={2}|SysLogID={3}",
                        communityID,
                        t102LeafID,
                        t107LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.WorkOrder",
                            "ufn_GetList_ToDoPWOFromWorkUnit",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ToDoPWOFromWorkUnit>;
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
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="rsFactXML">检查结果 XML 
        /// [RSFact]
        ///     [RF17 Ordinal="" T118LeafID="" Metric01="" /]
        /// [/RSFact]
        /// </param>
        /// <param name="inspectedQty">检查总不良品数量</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_SaveFact_FailureInspecting(
            int communityID,
            long transactNo,
            long factID,
            int t102LeafID,
            int t107LeafID,
            string pwoNo,
            string rsFactXML,
            long inspectedQty,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("transactNo", transactNo);
                hashParams.Add("factID", factID);
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("pwoNo", pwoNo);
                hashParams.Add("rsFactXML", rsFactXML);
                hashParams.Add("inspectedQty", inspectedQty);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveFact_FailureInspecting，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                        "T102LeafID={3}|T107LeafID={4}|PWONo={5}|" +
                        "RSFactXML={6}|InspectedQty={7}|SysLogID={8}",
                        communityID,
                        transactNo,
                        factID,
                        t102LeafID,
                        t107LeafID,
                        pwoNo,
                        rsFactXML,
                        inspectedQty,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.ManualInspecting",
                        "usp_SaveFact_FailureInspecting",
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
        /// 在制品路由防错
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_PokaYoke_PalletRouting(
            int communityID,
            int t102LeafID,
            int t107LeafID,
            string pwoNo,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("pwoNo", pwoNo);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_PokaYoke_PalletRouting，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T107LeafID={2}|" +
                        "PWONo={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t107LeafID,
                        pwoNo,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.PokaYoke",
                        "usp_PokaYoke_PalletRouting",
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
        /// 工单同时生产可行性检验
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t131LeafID">选择环别验证</param>
        /// <param name="pokaYokeXML">
        /// 产品标识:
        /// [Param]
        ///     [RowSet]
        ///         [Ordinal][/Ordinal]
        ///         [T102LeafID][/T102LeafID]
        ///         [T216LeafID][/T216LeafID]
        ///     [/RowSet]
        /// [/Param]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_PokaYoke_ParamConsistency(
            int communityID,
            int t131LeafID,
            string pokaYokeXML,
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
                hashParams.Add("t131LeafID", t131LeafID);
                hashParams.Add("pokaYokeXML", pokaYokeXML);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_PokaYoke_ParamConsistency，输入参数：" +
                        "CommunityID={0}|T131LeafID={1}|PokaYokeXML={2}|" +
                        "SysLogID={3}",
                        communityID,
                        t131LeafID,
                        pokaYokeXML,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.PokaYoke",
                        "usp_PokaYoke_ParamConsistency",
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
        /// 获取测试数据采集行集事实(测试数据)
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="rsFactPK">行集事实表分区键</param>
        /// <param name="factID">事实编号</param>
        /// <param name="failOnly">是否仅包括失败的测试项</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void ufn_GetRSFact_TestData(
            int communityID,
            long rsFactPK,
            long factID,
            bool failOnly,
            long sysLogID,
            ref List<RSFactTestData> datas,
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
                hashParams.Add("rsFactPK", rsFactPK);
                hashParams.Add("factID", factID);
                hashParams.Add("failOnly", failOnly);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetRSFact_TestData 函数， " +
                        "参数：CommunityID={0}|RSFactPK={1}|" +
                        "FactID={2}|FailOnly={3}|SysLogID={4}",
                        communityID,
                        rsFactPK,
                        factID,
                        failOnly,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.QC",
                            "ufn_GetRSFact_TestData",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<RSFactTestData>;
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
        /// 辅助事实分区键
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="af482PK">辅助事实分区键</param>
        /// <param name="pwoNo">生产工单号</param>
        public void ufn_GetLotNumberFromPWO(
            int communityID,
            long af482PK,
            string pwoNo,
            ref string lotNumber,
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
                lotNumber = "";

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("af482PK", af482PK);
                hashParams.Add("pwoNo", pwoNo);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetLotNumberFromPWO 函数， " +
                        "参数：CommunityID={0}|AF482PK={1}|" +
                        "PWONo={2}",
                        communityID,
                        af482PK,
                        pwoNo),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.WorkOrder",
                            "ufn_GetLotNumberFromPWO",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        lotNumber = rlt as string;
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
        /// 保存人工外观检查事实记录，记录失效模式清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="productLeaf">产品叶标识（T102LeafID）</param>
        /// <param name="workUnitLeaf">工位叶标识（T107LeafID）</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="barCode">产品条码</param>
        /// <param name="scrapCode">失效模式代码清单</param>
        public void usp_SaveFact_Inspecting(
            int communityID,
            long transactNo,
            long factID,
            int productLeaf,
            int workUnitLeaf,
            long sysLogID,
            string barCode,
            string scrapCode,
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
                hashParams.Add("transactNo", transactNo);
                hashParams.Add("factID", factID);
                hashParams.Add("productLeaf", productLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("sysLogID", sysLogID);
                hashParams.Add("barCode", barCode);
                hashParams.Add("scrapCode", scrapCode);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveFact_Inspecting，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                        "ProductLeaf={3}|WorkUnitLeaf={4}|SysLogID={5}|" +
                        "BarCode={6}|ScrapCode={7}|",
                        communityID,
                        transactNo,
                        factID,
                        productLeaf,
                        workUnitLeaf,
                        sysLogID,
                        barCode,
                        scrapCode),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.IRAPMES",
                        "usp_SaveFact_Inspecting",
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
        /// 获取失效模式的质量问题柏拉图数据清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="pwoNo">生产工单号</param>
        public void ufn_GetPallet_FailureMode(
           int communityID,
           int productLeaf,
           int workUnitLeaf,
           string pwoNo,
           long sysLogID,
           ref List<FailureModeOfPallet> datas,
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
                hashParams.Add("productLeaf", productLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("pwoNo", pwoNo);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetPallet_FailureMode 函数， " +
                        "参数：CommunityID={0}|ProductLeaf={1}|" +
                        "WorkUnitLeaf={2}|PWONo={3}|SysLogID={4}",
                        communityID,
                        productLeaf,
                        workUnitLeaf,
                        pwoNo,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.IRAPMES",
                            "ufn_GetPallet_FailureMode",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<FailureModeOfPallet>;
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
        /// 获取用于人工检查的在制品以及子在制品信息
        /// </summary>
        public void mfn_GetInfo_WIPIDCode(
            int communityID,
            string wipIDCode,
            int productLeaf,
            int workUnitLeaf,
            bool isEnhanced,
            long sysLogID,
            ref Inspecting data,
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
                data = new Inspecting();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("wipIDCode", wipIDCode);
                hashParams.Add("productLeaf", productLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("isEnhanced", isEnhanced);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 mfn_GetInfo_WIPIDCode 函数， " +
                        "参数：CommunityID={0}|WIPIDCode={1}|" +
                        "ProductLeaf={2}|WorkUnitLeaf={3}|" +
                        "IsEnhanced={4}|SysLogID={5}",
                        communityID,
                        wipIDCode,
                        productLeaf,
                        workUnitLeaf,
                        isEnhanced,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.WIP",
                            "mfn_GetInfo_WIPIDCode",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        data = rlt as Inspecting;
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
        /// 批次生产开始
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t216LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="operatorCode">操作工代码</param>
        /// <param name="t131LeafID">产品类别叶标识</param>
        /// <param name="rsFactXML">
        /// 工单信息列表
        /// [RSFact]
        ///     [RF25
        ///         Ordinal=""
        ///         T102LeafID=""
        ///         T216LeafID=""
        ///         WIPCode=""
        ///         LotNumber=""
        ///         Texture=""
        ///         PWONo=""
        ///         BatchLot=""
        ///         Qty=""
        ///         Scale="" /]
        /// [/RSFact]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void usp_SaveFact_BatchProductionStart(
            int communityID,
            int t216LeafID,
            int t107LeafID,
            string operatorCode,
            int t131LeafID,
            string rsFactXML,
            long sysLogID,
            out string batchNo,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            batchNo = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("t131LeafID", t131LeafID);
                hashParams.Add("operatorCode", operatorCode);
                hashParams.Add("rsFactXML", rsFactXML);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 usp_SaveFact_BatchProductionStart，输入参数：" +
                        "CommunityID={0}|T216LeafID={1}|T107LeafID={2}|" +
                        "T131LeafID={3}|OperatorCode={4}|RSFactXML={5}|SysLogID={6}",
                        communityID, t216LeafID, t107LeafID, t131LeafID, operatorCode,
                        rsFactXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.WorkOrder",
                        "usp_SaveFact_BatchProductionStart",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    if (errCode == 0)
                    {
                        if (rlt is Hashtable)
                        {
                            Hashtable rltHash = (Hashtable)rlt;
                            try
                            {
                                HashtableTools.Instance.GetValue(
                                    rltHash,
                                    "BatchNumber",
                                    out batchNo);
                            }
                            catch (Exception error)
                            {
                                errCode = -1003;
                                errText = error.Message;
                                WriteLog.Instance.Write(errText, strProcedureName);
                                return;
                            }
                        }
                        else
                        {
                            errCode = -1002;
                            errText = "应用服务 usp_SaveFact_BatchProductionStart 返回的不是 Hashtable！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
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
        /// 批次生产结束
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t216LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">容器批次号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void usp_SaveFact_BatchProductionEnd(
            int communityID,
            int t216LeafID,
            int t107LeafID,
            string batchNumber,
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
                #region 将函数参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 usp_SaveFact_BatchProductionEnd，输入参数：" +
                        "CommunityID={0}|T216LeafID={1}|T107LeafID={2}|" +
                        "BatchNumber={3}|SysLogID={4}",
                        communityID, t216LeafID, t107LeafID, batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.WorkOrder",
                        "usp_SaveFact_BatchProductionEnd",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
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
        /// 获取指定工序设备的当前状态
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t133LeafID">设备叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetInfo_BatchProduct(
            int communityID,
            int t107LeafID,
            int t216LeafID,
            int t133LeafID,
            long sysLogID,
            ref BatchProductInfo data,
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
                data = new BatchProductInfo();

                #region 将函数调用参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t133LeafID", t133LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_BatchProduct，输入参数：" +
                        "CommunityID={0}|T107LeafID={1}|T216LeafID={2}|" +
                        "T133LeafID={3}|SysLogID={4}",
                        communityID, t107LeafID, t216LeafID,
                        t133LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.WorkOrder",
                            "ufn_GetInfo_BatchProduct",
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as BatchProductInfo;
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
        /// 获取指定设备的待检炉次号
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t133LeafID">设备叶标识</param>
        /// <param name="opType">
        /// 检索类型：IQ-检验参数数据；IC-检验确认
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void ufn_GetList_BatchByEquipment(
            int communityID,
            int t133LeafID,
            string opType,
            long sysLogID,
            ref List<BatchByEquipment> datas,
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
                hashParams.Add("t133LeafID", t133LeafID);
                hashParams.Add("opType", opType);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_BatchByEquipment 函数， " +
                        "参数：CommunityID={0}|T133LeafID={1}|OpType={2}|" +
                        "SysLogID={3}",
                        communityID,
                        t133LeafID,
                        opType,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.WorkOrder",
                            "ufn_GetList_BatchByEquipment",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<BatchByEquipment>;
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
        /// 根据容次号获取生产工单信息列表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="batchNumber">生产容次号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void ufn_GetList_BatchPWONo(
            int communityID,
            string batchNumber,
            long sysLogID,
            ref List<BatchPWOInfo> datas,
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
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_BatchPWONo 函数， " +
                        "参数：CommunityID={0}|BatchNumber={1}|SysLogID={2}",
                        communityID,
                        batchNumber,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.WorkOrder",
                            "ufn_GetList_BatchPWONo",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<BatchPWOInfo>;
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
        /// 保存批次管理系统中的生产过程参数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">容次号</param>
        /// <param name="rsFactXML">
        /// 生产过程参数 XML
        /// [RSFact]
        ///     [RF25_1
        ///         Ordinal=""
        ///         T20LeafID=""
        ///         ParameterName=""
        ///         LowLimit=""
        ///         Criterion=""
        ///         HighLimit=""
        ///         Scale=""
        ///         UnitOfMeasure=""
        ///         Metric01="" /]
        /// [/RSFact]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_SaveFact_BatchMethodConfirming(
            int communityID,
            int t216LeafID,
            int t107LeafID,
            string batchNumber,
            string rsFactXML,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("rsFactXML", rsFactXML);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveFact_BatchMethodConfirming，输入参数：" +
                        "CommunityID={0}|T216LeafID={1}|T107LeafID={2}|BatchNumber={3}|" +
                        "RSFactXML={4}|SysLogID={5}",
                        communityID, t216LeafID, t107LeafID, batchNumber, rsFactXML,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.IRAPMES",
                        "usp_SaveFact_BatchMethodConfirming",
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
        /// 编辑批次管理系统中的生产过程参数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">容次号</param>
        /// <param name="opType">
        /// 操作标识：
        /// D-删除；U-修改（目前仅支持删除）
        /// </param>
        /// <param name="factID">保存的生产过程参数事实号</param>
        /// <param name="rsFactXML">
        /// 生产过程参数 XML
        /// [RSFact]
        ///     [RF25_1
        ///         Ordinal=""
        ///         T20LeafID=""
        ///         ParameterName=""
        ///         LowLimit=""
        ///         Criterion=""
        ///         HighLimit=""
        ///         Scale=""
        ///         UnitOfMeasure=""
        ///         Metric01="" /]
        /// [/RSFact]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_SaveFact_BatchMethodCancel(
            int communityID,
            int t216LeafID,
            int t107LeafID,
            string batchNumber,
            string opType,
            long factID,
            string rsFactXML,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("opType", opType);
                hashParams.Add("factID", factID);
                hashParams.Add("rsFactXML", rsFactXML);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveFact_BatchMethodCancel，输入参数：" +
                        "CommunityID={0}|T216LeafID={1}|T107LeafID={2}|BatchNumber={3}|" +
                        "OpType={4}|FactID={5}|RSFactXML={6}|SysLogID={7}",
                        communityID, t216LeafID, t107LeafID, batchNumber, opType, factID,
                        rsFactXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.IRAPMES",
                        "usp_SaveFact_BatchMethodCancel",
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
        /// 保存批次管理中的检验
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="factID">关联事实号</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">容次号</param>
        /// <param name="lotNumber">生产批次号</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="qcStatus">
        /// 检验结果：
        /// 1-合格；2-不合格
        /// </param>
        /// <param name="rsFactXML">
        /// 检验结果：
        /// [RSFact]
        ///     [RF6_2
        ///         RowNum=""
        ///         Ordinal=""
        ///         T20LeafID=""
        ///         LowLimit=""
        ///         Criterion=""
        ///         HighLimit=""
        ///         UnitOfMeasure=""
        ///         Metric01="" />
        /// [/RSFact]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_SaveFact_BatchManualInspecting(
            int communityID,
            long factID,
            int t102LeafID,
            int t107LeafID,
            string batchNumber,
            string lotNumber,
            string pwoNo,
            int qcStatus,
            string rsFactXML,
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
                hashParams.Add("factID", factID);
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("lotNumber", lotNumber);
                hashParams.Add("pwoNo", pwoNo);
                hashParams.Add("qcStatus", qcStatus);
                hashParams.Add("rsFactXML", rsFactXML);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveFact_BatchManualInspecting，输入参数：" +
                        "CommunityID={0}|FactID={1}|T102LeafID={2}|T107LeafID={3}|" +
                        "BatchNumber={4}|LotNumber={5}|PWONo={6}|QCStatus={7}|" +
                        "RSFactXML={8}|SysLogID={9}",
                        communityID, factID, t102LeafID, t107LeafID, batchNumber, lotNumber,
                        pwoNo, qcStatus, rsFactXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.IRAPMES",
                        "usp_SaveFact_BatchManualInspecting",
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
        /// 确认批次管理中的检验值 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="factID">关联事实号</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">容次号</param>
        /// <param name="lotNumber">生产批次号</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_SaveFact_BatchInspectingConfirm(
            int communityID,
            long factID,
            int t102LeafID,
            int t107LeafID,
            string batchNumber,
            string lotNumber,
            string pwoNo,
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
                hashParams.Add("factID", factID);
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("lotNumber", lotNumber);
                hashParams.Add("pwoNo", pwoNo);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveFact_BatchInspectingConfirm，输入参数：" +
                        "CommunityID={0}|FactID={1}|T102LeafID={2}|T107LeafID={3}|" +
                        "BatchNumber={4}|LotNumber={5}|PWONo={6}|SysLogID={7}",
                        communityID, factID, t102LeafID, t107LeafID, batchNumber, lotNumber,
                        pwoNo, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.IRAPMES",
                        "usp_SaveFact_BatchInspectingConfirm",
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
        /// 获取可访问的返工工单清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_OpenReworkPWOs(
            int communityID,
            long sysLogID,
            ref List<OpenReworkPWO> datas,
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
                        "调用 ufn_GetList_OpenReworkPWOs 函数， " +
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
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.WorkOrder",
                            "ufn_GetList_OpenReworkPWOs",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<OpenReworkPWO>;
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
        /// 获取指定返工工单的返工路由表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="tf482PK">事实分区键</param>
        /// <param name="pwoIssuingFactID">返工工单签发事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetReworkRoutingTBL(
            int communityID,
            long tf482PK,
            long pwoIssuingFactID,
            long sysLogID,
            ref List<ReworkRouter> datas,
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
                hashParams.Add("tf482PK", tf482PK);
                hashParams.Add("pwoIssuingFactID", pwoIssuingFactID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetReworkRoutingTBL 函数， " +
                        "参数：CommunityID={0}|TF482PK={1}|" +
                        "PWOIssuingFactID={2}|SysLogID={3}",
                        communityID,
                        tf482PK,
                        pwoIssuingFactID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.WorkOrder",
                            "ufn_GetReworkRoutingTBL",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ReworkRouter>;
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
        /// 获取返工工单卸料表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="tf482PK">事实分区键</param>
        /// <param name="pwoIssuingFactID">返工工单签发事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetReworkPWOUnloadingSheet(
            int communityID,
            long tf482PK,
            long pwoIssuingFactID,
            long sysLogID,
            ref List<ReworkPWOUnloadingSheetItem> datas,
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
                hashParams.Add("tf482PK", tf482PK);
                hashParams.Add("pwoIssuingFactID", pwoIssuingFactID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetReworkPWOUnloadingSheet 函数， " +
                        "参数：CommunityID={0}|TF482PK={1}|" +
                        "PWOIssuingFactID={2}|SysLogID={3}",
                        communityID,
                        tf482PK,
                        pwoIssuingFactID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.WorkOrder",
                            "ufn_GetReworkPWOUnloadingSheet",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ReworkPWOUnloadingSheetItem>;
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
        /// 保存返工工单路由设置与卸料设置
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="tf482PK">事实分区键</param>
        /// <param name="pwoIssuingFactID">返工工单签发事实编号</param>
        /// <param name="reworkRoutingTBL">
        /// 返工路由表 XML
        /// [RSFact]
        /// 	[RF3 Ordinal="..." 
        /// 	     T107LeafID1="..." 
        /// 	     T107LeafID2="..." 
        /// 	     T116LeafID="..." /]
        /// 	...
        /// [/RSFact]
        /// </param>
        /// <param name="reworkUnloadingSheet">
        /// 返工卸料表 XML
        /// [RSFact]
        /// 	[RF4 Ordinal="..."
        /// 	     T107LeafID="..."
        /// 	     T108LeafID="..."
        /// 	     T110LeafID="..."
        /// 	     T101LeafID="..."
        /// 	     T102LeafID="..."
        /// 	     UnloadQty="..."
        /// 	     ScrapOnUnloading="..." /]
        /// 	...
        /// [/RSFact]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_SaveRSFacts_ReworkPWO(
            int communityID,
            long tf482PK,
            long pwoIssuingFactID,
            string reworkRoutingTBL,
            string reworkUnloadingSheet,
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
                hashParams.Add("tf482PK", tf482PK);
                hashParams.Add("pwoIssuingFactID", pwoIssuingFactID);
                hashParams.Add("reworkRoutingTBL", reworkRoutingTBL);
                hashParams.Add("reworkUnloadingSheet", reworkUnloadingSheet);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveRSFacts_ReworkPWO，输入参数：" +
                        "CommunityID={0}|TF482PK={1}|PWOIssuingFactID={2}|" +
                        "ReworkRoutingTBL={3}|ReworkUnloadingSheet={4}|SysLogID={5}",
                        communityID,
                        tf482PK,
                        pwoIssuingFactID,
                        reworkRoutingTBL,
                        reworkUnloadingSheet,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.WorkOrder",
                        "usp_SaveRSFacts_ReworkPWO",
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
        /// 保存理化检验中的信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="factID">关联事实号</param>
        /// <param name="optype">操作类型</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">容次号</param>
        /// <param name="lotNumber">生产批次号</param>
        /// 检验结果：
        /// 1-合格；2-不合格
        /// </param>
        /// <param name="rsFactXML">
        /// 检验结果：
        /// [RSFact]
        ///     [RF6_2
        ///         RowNum=""
        ///         Ordinal=""
        ///         T20LeafID=""
        ///         LowLimit=""
        ///         Criterion=""
        ///         HighLimit=""
        ///         UnitOfMeasure=""
        ///         Metric01="" />
        /// [/RSFact]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_SaveFact_SmeltBatchManualInspecting(
            int communityID,
            long factID,
            string opType,
            int t102LeafID,
            int t107LeafID,
            string batchNumber,
            string lotNumber,
            string rsFactXML,
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
                hashParams.Add("factID", factID);
                hashParams.Add("opType", opType);
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("lotNumber", lotNumber);
                hashParams.Add("rsFactXML", rsFactXML);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveFact_BatchManualInspecting，输入参数：" +
                        "CommunityID={0}|FactID={1}|OpType={2}|T102LeafID={3}|T107LeafID={4}|" +
                        "BatchNumber={5}|LotNumber={6}" +
                        "RSFactXML={7}|SysLogID={8}",
                        communityID, factID, opType, t102LeafID, t107LeafID, batchNumber, lotNumber,
                        rsFactXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.IRAPMES",
                        "usp_SaveFact_SmeltBatchManualInspecting",
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
        /// 保存理化检验中的信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="factID">关联事实号</param>
        /// <param name="optype">操作类型</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">容次号</param>
        /// <param name="lotNumber">生产批次号</param>
        /// 检验结果：
        /// 1-合格；2-不合格
        /// </param>
        /// <param name="rsFactXML">
        /// 检验结果：
        /// [RSFact]
        ///     [RF6_2
        ///         RowNum=""
        ///         Ordinal=""
        ///         T20LeafID=""
        ///         LowLimit=""
        ///         Criterion=""
        ///         HighLimit=""
        ///         UnitOfMeasure=""
        ///         Metric01="" />
        /// [/RSFact]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_SaveFact_SmeltBatchInspecting(
            int communityID,
            long factID,
            string opType,
            int t102LeafID,
            int t107LeafID,
            string batchNumber,
            string lotNumber,
            string pWONo,
            string rsFactXML,
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
                hashParams.Add("factID", factID);
                hashParams.Add("opType", opType);
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("lotNumber", lotNumber);
                hashParams.Add("pWONo", pWONo);
                hashParams.Add("rsFactXML", rsFactXML);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveFact_BatchManualInspecting，输入参数：" +
                        "CommunityID={0}|FactID={1}|OpType={2}|T102LeafID={3}|T107LeafID={4}|" +
                        "BatchNumber={5}|LotNumber={6}|PWONo={7}|RSFactXML={8}|SysLogID={9}",
                        communityID, factID, opType, t102LeafID, t107LeafID, batchNumber, lotNumber, pWONo, rsFactXML,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.IRAPMES",
                        "usp_SaveFact_SmeltBatchInspecting",
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
        public void usp_Upload_SmeltPWORelease(
            int communityID,
            long importID,
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
                    hashParams.Add("importID", importID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format("执行存储过程 " +
                            "usp_Upload_SmeltPWORelease，参数：" +
                            "CommunityID={0}|ImportID={1}|SysLogID={2}",
                            communityID, importID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.WorkOrder",
                        "usp_Upload_SmeltPWORelease",
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
    }
}
