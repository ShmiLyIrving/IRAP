using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.MDM;
using IRAP.Entity.MDM.Tables;

namespace IRAP.WCF.Client.Method
{
    public class IRAPMDMClient
    {
        private static IRAPMDMClient _instance = null;
        private static string className =
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
                        "CommunityID={0}|T102LeafID={1}|ShotTime={2}|" +
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

        /// <summary>
        /// 获取工序清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[ProcessOperation]</returns>
        public void ufn_GetList_ProcessOperations(
            int communityID,
            long sysLogID,
            ref List<ProcessOperation> datas,
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
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_ProcessOperations，输入参数：" +
                        "CommunityID={0}|SysLogID={1}",
                        communityID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "ufn_GetList_ProcessOperations",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<ProcessOperation>;
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
        /// 获取工艺维护菜单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t116LeafID">工序类型标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_MethodMMenu(
            int communityID,
            int t116LeafID,
            long sysLogID,
            ref List<MethodMMenu> datas,
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
                hashParams.Add("t116LeafID", t116LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_MethodMMenu，输入参数：" +
                        "CommunityID={0}|T116LeafID={1}|SysLogID={2}",
                        communityID,
                        t116LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "ufn_GetList_MethodMMenu",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<MethodMMenu>;
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
        /// 保存行集属性
        /// </summary>
        /// <remarks>
        /// ⒈ 进行生效时间合法性防错；
        /// ⒉ 自动敏感与上一版本之间的数据变化，更新版本历史；
        /// ⒊ 不进行版本控制时，也能保存上一版本到版本历史表。
        /// </remarks>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="leafID">叶标识</param>
        /// <param name="rowSetID">行集序号</param>
        /// <param name="voucherNo">变更凭证号</param>
        /// <param name="effectiveTime">生效时间点(yyyy-mm-dd hh:mm)，空串表示立刻生效</param>
        /// <param name="deleUnapplied">是否删除未应用版本</param>
        /// <param name="rsAttrXML">
        /// 行集属性
        /// 	[RSAttr]
        /// 		[Row RealOrdinal="1" .../]
        /// 		...
        /// 	[/RSAttr]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ssp_SaveRSAttrChange(
            int communityID,
            int treeID,
            int leafID,
            int rowSetID,
            string voucherNo,
            string effectiveTime,
            bool deleUnapplied,
            string rsAttrXML,
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
                    hashParams.Add("treeID", treeID);
                    hashParams.Add("leafID", leafID);
                    hashParams.Add("rowSetID", rowSetID);
                    hashParams.Add("voucherNo", voucherNo);
                    hashParams.Add("effectiveTime", effectiveTime);
                    hashParams.Add("deleUnapplied", deleUnapplied);
                    hashParams.Add("rsAttrXML", rsAttrXML);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ssp_SaveRSAttrChange，输入参数：" +
                            "CommunityID={0}|TreeID={1}|LeafID={2}|" +
                            "RowSetID={3}|VoucherNo={4}|EffectiveTime={5}|" +
                            "DeleUnapplied={6}|RSAttrXML={7}|SysLogID={8}",
                            communityID, treeID, leafID, rowSetID, voucherNo,
                            effectiveTime, deleUnapplied, rsAttrXML, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "ssp_SaveRSAttrChange",
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
        /// 根据102和（216或107）获取C64ID
        /// </summary>
        public void ufn_GetMethodID(
            int communityID,
            int t102LeafID,
            int treeID,
            int leafID,
            long unixTime,
            ref int c64ID,
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
                hashParams.Add("treeID", treeID);
                hashParams.Add("leafID", leafID);
                hashParams.Add("unixTime", unixTime);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetMethodID，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|TreeID={2}|" +
                        "LeafID={3}|UnixTime={4}",
                        communityID,
                        t102LeafID,
                        treeID,
                        leafID,
                        unixTime),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "ufn_GetMethodID",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}，C64ID={2}",
                            errCode,
                            errText,
                            (int)rlt),
                        strProcedureName);

                    if (errCode == 0)
                        c64ID = (int)rlt;
                    else
                        c64ID = 0;
                }
                #endregion
            }
            catch (Exception error)
            {
                c64ID = 0;
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
        /// 获取指定产品指定工序的工艺参数标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点（空串-当面）</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_MethodStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
            long sysLogID,
            ref List<MethodStandard> datas,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_MethodStandard，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t216LeafID,
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
                        "ufn_GetList_MethodStandard",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<MethodStandard>;
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
        /// 获取指定产品和工序的工装标准清单
        /// </summary>
        public void ufn_GetList_ToolingStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
            long sysLogID,
            ref List<ToolingStandard> datas,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_ToolingStandard，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t216LeafID,
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
                        "ufn_GetList_ToolingStandard",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<ToolingStandard>;
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
        /// 获取指定产品指定工序的生产程序清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_ProductionPrograms(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
            long sysLogID,
            ref List<ProductionPrograms> datas,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_ProductionPrograms，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t216LeafID,
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
                        "ufn_GetList_ProductionPrograms",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<ProductionPrograms>;
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
        /// 获取工序作业标准清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_SOP(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
            long sysLogID,
            ref List<OPStandard> datas,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_SOP，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t216LeafID,
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
                        "ufn_GetList_SOP",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<OPStandard>;
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
        /// 获取工序生产环境参数标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_EnvParamStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
            long sysLogID,
            ref List<EnvParamStandard> datas,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_EnvParamStandard，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t216LeafID,
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
                        "ufn_GetList_EnvParamStandard",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<EnvParamStandard>;
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
        /// 获取指定产品指定工序人工检查标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_InspectionStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
            long sysLogID,
            ref List<InspectionStandard> datas,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_InspectionStandard，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t216LeafID,
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
                        "ufn_GetList_InspectionStandard",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<InspectionStandard>;
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
        /// 获取指定产品指定工序物料装料标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_LoadingStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
            long sysLogID,
            ref List<LoadingStandard> datas,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_LoadingStandard，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t216LeafID,
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
                        "ufn_GetList_LoadingStandard",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<LoadingStandard>;
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
        /// 获取失效模式清单的核心函数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t134LeafID">产线叶标识(0=不限)</param>
        /// <param name="t216LeafID">工序叶标识(0=不限)</param>
        /// <param name="t132LeafID">产品族叶标识(0=不限)</param>
        /// <param name="t102LeafID">产品叶标识(0=不限)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_FailureModes_Core(
            int communityID,
            int t134LeafID,
            int t216LeafID,
            int t132LeafID,
            int t102LeafID,
            long sysLogID,
            ref List<FailureModeCore> datas,
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
                hashParams.Add("t134LeafID", t134LeafID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t132LeafID", t132LeafID);
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_FailureModes_Core，输入参数：" +
                        "T134LeafID={1}|T216LeafID={2}|T132LeafID={1}|" +
                        "T102LeafID={2}|SysLogID={4}",
                        communityID,
                        t134LeafID,
                        t216LeafID,
                        t132LeafID,
                        t102LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "ufn_GetList_FailureModes_Core",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<FailureModeCore>;
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
        /// 获取工序生产环境参数标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_EnergyStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
            long sysLogID,
            ref List<EnergyStandard> datas,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_EnergyStandard，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t216LeafID,
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
                        "ufn_GetList_EnergyStandard",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<EnergyStandard>;
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
        /// 获取工序生产防错规则
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_PokaYokeRules(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
            long sysLogID,
            ref List<PokaYokeRule> datas,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_PokaYokeRules，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t216LeafID,
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
                        "ufn_GetList_PokaYokeRules",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<PokaYokeRule>;
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
        /// 获取工序生产准备标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_PreparingStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
            long sysLogID,
            ref List<PreparingStandard> datas,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_PreparingStandard，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t216LeafID,
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
                        "ufn_GetList_PreparingStandard",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<PreparingStandard>;
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
        /// 获取指定产品指定工序的操作工技能矩阵
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点(空串=当前)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetSkillMatrix_ByMethod(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
            long sysLogID,
            ref List<SkillMatrixByMethod> datas,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetSkillMatrix_ByMethod，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}|" +
                        "ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t216LeafID,
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
                        "ufn_GetSkillMatrix_ByMethod",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<SkillMatrixByMethod>;
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
        /// 获取功能的表单控件信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="menuItemID">菜单项标识</param>
        /// <param name="progLanguageID">编程语言标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void sfn_FunctionFormCtrls(
            int communityID,
            int menuItemID,
            int progLanguageID,
            long sysLogID,
            ref List<FormCtrlInfo> datas,
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
                hashParams.Add("menuItemID", menuItemID);
                hashParams.Add("progLanguageID", progLanguageID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_FunctionFormCtrls，输入参数：" +
                        "CommunityID={0}|MenuItemID={1}|ProgLanguageID={2}|SysLogID={3}",
                        communityID,
                        menuItemID,
                        progLanguageID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "sfn_FunctionFormCtrls",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<FormCtrlInfo>;
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
        /// 获取工位生产状态(工艺呈现专用)
        /// ⒈ 正在生产时呈现工单号、产品、容器号以及完工时目标库位；
        /// ⒉ 未在生产时呈现应该执行的工单号、容器号以及滞在库位，并可呈现工艺信息；
        /// ⒊ 正在生产时，点击进入可以呈现各种工艺信息。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_WIPStationProductionStatus(
            int communityID,
            long sysLogID,
            int filterT107LeafID,
            ref List<WIPStationProductionStatus> datas,
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
                hashParams.Add("filterT107LeafID", filterT107LeafID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_WIPStationProductionStatus 函数， " +
                        "参数：CommunityID={0}|SysLogID={1}|filterT107LeafID={2}",
                        communityID,
                        sysLogID,
                        filterT107LeafID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MDM.dll",
                            "IRAP.BL.MDM.IRAPMDM",
                            "ufn_GetList_WIPStationProductionStatus",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<WIPStationProductionStatus>;
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
        /// 获取工序叶标识
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="unixTime">时点Unix时间</param>
        public void ufn_GetT216LeafID(
            int communityID,
            int t102LeafID,
            int t107LeafID,
            int unixTime,
            ref int t216LeafID,
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
                t216LeafID = 0;

                try
                {
                    using (WCFClient client = new WCFClient())
                    {
                        try
                        {
                            #region 将函数调用参数加入 HashTable 中
                            Hashtable hashParams = new Hashtable();
                            hashParams.Add("communityID", communityID);
                            hashParams.Add("t102LeafID", t102LeafID);
                            hashParams.Add("t107LeafID", t107LeafID);
                            hashParams.Add("unixTime", unixTime);
                            WriteLog.Instance.Write(
                                string.Format(
                                    "调用 ufn_GetT216LeafID 函数，" +
                                    "输入参数：CommunityID={0}|T102LeafID={1}|" +
                                    "T107LeafID={2}|UnixTime={3}",
                                    communityID,
                                    t102LeafID,
                                    t107LeafID,
                                    unixTime),
                                strProcedureName);
                            #endregion

                            object d1 = client.WCFRESTFul("IRAP.BL.MDM.dll",
                                "IRAP.BL.MDM.IRAPMDM",
                                "ufn_GetT216LeafID",
                                hashParams,
                                out errCode,
                                out errText);
                            WriteLog.Instance.Write(
                                string.Format("({0}){1}", errCode, errText),
                                strProcedureName);

                            if (errCode == 0)
                            {
                                t216LeafID = (int)d1;
                            }
                        }
                        catch (Exception error)
                        {
                            errCode = -1001;
                            errText = error.Message;
                            WriteLog.Instance.Write(errText, strProcedureName);
                            return;
                        }
                    }
                }
                catch (Exception error)
                {
                    errCode = -1001;
                    errText = error.Message;
                    WriteLog.Instance.Write(errText, strProcedureName);
                    return;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void ufn_GetList_AvailableMethodStandards(
           int communityID,
           int methodID,
           int languageID,
           ref List<StandardType> datas,
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
                hashParams.Add("methodID", methodID);
                hashParams.Add("languageID", languageID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_AvailableMethodStandards 函数， " +
                        "参数：CommunityID={0}|MethodID={1}|LanguageID={2}",
                        communityID,
                        methodID,
                        languageID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MDM.dll",
                            "IRAP.BL.MDM.IRAPMDM",
                            "ufn_GetList_AvailableMethodStandards",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<StandardType>;
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
        /// 获取产品一般属性
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetProductSketch(
            int communityID,
            int t102LeafID,
            long sysLogID,
            ref GenAttr_Product data,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                data = new GenAttr_Product();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetProductSketch，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|SysLogID={2}",
                        communityID,
                        t102LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "ufn_GetProductSketch",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as GenAttr_Product;
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
        /// 获取工序一般属性
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t216LeafID">产品叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetProcessOperationGenAttr(
            int communityID,
            int t216LeafID,
            long sysLogID,
            ref GenAttr_ProcessOperation data,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                data = new GenAttr_ProcessOperation();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetProcessOperationGenAttr，输入参数：" +
                        "CommunityID={0}|T216LeafID={1}|SysLogID={2}",
                        communityID,
                        t216LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "ufn_GetProcessOperationGenAttr",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as GenAttr_ProcessOperation;
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
        /// 获取注册测量仪表清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        public void ufn_GetList_RegInstruments(
            int communityID,
            ref List<RegInstrument> datas,
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
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_RegInstruments 函数， " +
                        "参数：CommunityID={0}",
                        communityID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MDM.dll",
                            "IRAP.BL.MDM.IRAPMDM",
                            "ufn_GetList_RegInstruments",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<RegInstrument>;
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
        /// 获取工位SPC监控情况
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_WIPStationSPCMonitor(
            int communityID,
            long sysLogID,
            string filterString,
            ref List<WIPStationSPCMonitor> datas,
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
                hashParams.Add("filterString", filterString);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_WIPStationSPCMonitor 函数， " +
                        "参数：CommunityID={0}|SysLogID={1}|FilterString={2}",
                        communityID,
                        sysLogID,
                        filterString),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MDM.dll",
                            "IRAP.BL.MDM.IRAPMDM",
                            "ufn_GetList_WIPStationSPCMonitor",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<WIPStationSPCMonitor>;
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
        /// 获取安灯事件类型清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_AndonEventTypes(
            int communityID,
            long sysLogID,
            ref List<AndonEventType> datas,
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
                        "调用 ufn_GetList_AndonEventTypes 函数， " +
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
                            "IRAP.BL.MDM.dll",
                            "IRAP.BL.MDM.IRAPMDM",
                            "ufn_GetList_AndonEventTypes",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonEventType>;
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
        /// 获取安灯事件类型清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_StationBoundProductionLines(
            int communityID,
            long sysLogID,
            ref List<ProductionLineForStationBound> datas,
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
                        "调用 ufn_GetList_StationBoundProductionLines 函数， " +
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
                            "IRAP.BL.MDM.dll",
                            "IRAP.BL.MDM.IRAPMDM",
                            "ufn_GetList_StationBoundProductionLines",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ProductionLineForStationBound>;
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
        /// 获取上下文敏感的安灯呼叫对象清单：
        /// ⒈ 获取设备失效模式清单；
        /// ⒉ 获取产线物料清单；
        /// ⒊ 获取工位失效模式清单；
        /// ⒋ 获取设备工装型号清单；
        /// ⒌ 获取安全问题清单；
        /// ⒍ 获取产线其他支持人员清单。
        /// </summary>
        /// <remarks>从产线安灯事件采集固定客户端调用时，工位及设备叶标识传入0</remarks>
        /// <param name="communityID">社区标识</param>
        /// <param name="t179LeafID">安灯事件类型叶标识</param>
        /// <param name="t107LeafID">触发呼叫工位叶标识</param>
        /// <param name="t133LeafID">触发呼叫设备叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_AndonCallObjects(
            int communityID,
            int t179LeafID,
            int t107LeafID,
            int t133LeafID,
            long sysLogID,
            ref List<AndonCallObject> datas,
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
                hashParams.Add("t179LeafID", t179LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("t133LeafID", t133LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_AndonCallObjects 函数， " +
                        "参数：CommunityID={0}|T179LeafID={1}|T107LeafID={2}|" +
                        "T133LeafID={3}|SysLogID={4}",
                        communityID,
                        t179LeafID,
                        t107LeafID,
                        t133LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MDM.dll",
                            "IRAP.BL.MDM.IRAPMDM",
                            "ufn_GetList_AndonCallObjects",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonCallObject>;
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
        /// 将信息站点组切换到指定生产线
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="hostName">待切换站点主机名</param>
        /// <param name="t134LeafID">产线叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_SwitchToProductionLine(
        int communityID,
        string hostName,
        int t134LeafID,
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
                hashParams.Add("hostName", hostName);
                hashParams.Add("t134LeafID", t134LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SwitchToProductionLine，输入参数：" +
                        "CommunityID={0}|HostName={1}|T134LeafID={2}|"+
                        "SysLogID={3}",
                        communityID,
                        hostName,
                        t134LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "usp_SwitchToProductionLine",
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