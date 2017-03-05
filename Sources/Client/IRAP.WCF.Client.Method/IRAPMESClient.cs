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
                        "CommunityID={0}|T102LeafID={1}|T107LeafID={2}|"+
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
    }
}