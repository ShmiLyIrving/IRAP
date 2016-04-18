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
                            "RowSetID={3}|VoucherNo={4}|EffectiveTime={5}|"+
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
                        "CommunityID={0}|T102LeafID={1}|TreeID={2}|"+
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
                        "CommunityID={0}|T102LeafID={1}|T216LeafID={2}|"+
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
    }
}