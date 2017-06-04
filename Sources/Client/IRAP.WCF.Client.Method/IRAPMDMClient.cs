using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.MDM;
using IRAP.Entity.MDM.Tables;
using IRAP.Entities.MDM;

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
        /// 根据系统登录标识获取产线信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识param>
        public void ufn_GetInfo_ProductionLine(
            int communityID,
            long sysLogID,
            ref ProductionLineInfo data,
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
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_ProductionLine，输入参数：" +
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
                        "ufn_GetInfo_ProductionLine",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as ProductionLineInfo;
                    else
                        data = null;
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
        /// 获取指定产线指定产品相关的Logo图片信息
        /// </summary>
        /// <param name="communityID">社区标识 </param>
        /// <param name="t134LeafID">产线叶标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        public void ufn_GetInfo_LogoImages(
            int communityID,
            int t134LeafID,
            int t102LeafID,
            ref FVS_LogoImages data,
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
                hashParams.Add("t134LeafID", t134LeafID);
                hashParams.Add("t102LeafID", t102LeafID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_LogoImages，输入参数：" +
                        "CommunityID={0}|T134LeafID={1}|T102LeafID={2}",
                        communityID,
                        t134LeafID,
                        t102LeafID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "ufn_GetInfo_LogoImages",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as FVS_LogoImages;
                    else
                        data = null;
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
        /// 获取产品质量问题一点课资料
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="shotTime">时间(空串表示最新版本)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_OnePointLessons(
            int communityID,
            int t102LeafID,
            string shotTime,
            long sysLogID,
            ref List<OnePointLesson> datas,
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
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_OnePointLessons 函数， " +
                        "参数：CommunityID={0}|T102LeafID={1}|" +
                        "ShotTime={2}|SysLogID={3}",
                        communityID,
                        t102LeafID,
                        shotTime,
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
                            "ufn_GetList_OnePointLessons",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<OnePointLesson>;
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
        /// 获取质量问题一点课受训者名录
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="issueNo">问题编号</param>
        /// <param name="shotTime">时间（空串标识最新版本）</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_OPLTrainees(
            int communityID,
            int t102LeafID,
            int issueNo,
            string shotTime,
            long sysLogID,
            ref List<OPLTrainee> datas,
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
                hashParams.Add("issueNo", issueNo);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_OPLTrainees 函数， " +
                        "参数：CommunityID={0}|T102LeafID={1}|" +
                        "IssueNo={2}|ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        issueNo,
                        shotTime,
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
                            "ufn_GetList_OPLTrainees",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<OPLTrainee>;
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
        /// 获取操作工技能矩阵
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t134LeafID">产线叶标识</param>
        /// <param name="shotTime">日期时间，空串表示最新</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetSkillMatrix_Operators(
            int communityID,
            int t102LeafID,
            int t134LeafID,
            string shotTime,
            long sysLogID,
            ref List<OperatorSkillMatrix> datas,
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
                hashParams.Add("t134LeafID", t134LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetSkillMatrix_Operators 函数， " +
                        "参数：CommunityID={0}|T102LeafID={1}|" +
                        "T134LeafID={2}|ShotTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t134LeafID,
                        shotTime,
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
                            "ufn_GetSkillMatrix_Operators",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<OperatorSkillMatrix>;
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
        /// 获取上下文敏感的产线其他支持人员清单。
        /// </summary>
        /// <remarks>从产线安灯事件采集固定客户端调用时，工位及设备叶标识传入0</remarks>
        /// <param name="communityID">社区标识</param>
        /// <param name="t179LeafID">安灯事件类型叶标识</param>
        /// <param name="t107LeafID">触发呼叫工位叶标识</param>
        /// <param name="t133LeafID">触发呼叫设备叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_AndonCallPersons(
            int communityID,
            int t179LeafID,
            int t107LeafID,
            int t133LeafID,
            long sysLogID,
            ref List<AndonCallPerson> datas,
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
                        "调用 ufn_GetList_AndonCallPersons 函数， " +
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
                            "ufn_GetList_AndonCallPersons",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonCallPerson>;
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
                hashParams.Add("hostName", hostName);
                hashParams.Add("t134LeafID", t134LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SwitchToProductionLine，输入参数：" +
                        "CommunityID={0}|HostName={1}|T134LeafID={2}|" +
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

        /// <summary>
        /// 从系统登录标识获取公司名称
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void sfn_GetCompanyName(
            int communityID,
            long sysLogID,
            ref string companyName,
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
                companyName = "";

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_GetCompanyName 函数， " +
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
                            "sfn_GetCompanyName",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        companyName = rlt as string;
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
        /// 获取公司Logo图像的Base64编码
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void sfn_GetImage_CompanyLogo(
            int communityID,
            long sysLogID,
            ref string logoBase64,
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
                logoBase64 = "";

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_GetImage_CompanyLogo 函数， " +
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
                            "sfn_GetImage_CompanyLogo",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        logoBase64 = rlt as string;
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

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_KPIsToMonitor(
            int communityID,
            long sysLogID,
            ref List<KPIToMonitor> datas,
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
                        "调用 ufn_GetList_KPIsToMonitor 函数， " +
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
                            "ufn_GetList_KPIsToMonitor",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<KPIToMonitor>;
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

        /// <param name="communityID">社区标识</param>
        /// <param name="t102Code">部件编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_CustomerProduct(
            int communityID,
            string t102Code,
            long sysLogID,
            ref List<CustomerOfAProduction> datas,
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
                hashParams.Add("t102Code", t102Code);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_CustomerProduct 函数， " +
                        "参数：CommunityID={0}|T102Code={1}|SysLogID={2}",
                        communityID,
                        t102Code,
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
                            "ufn_GetList_CustomerProduct",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<CustomerOfAProduction>;
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

        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID"></param>
        /// <param name="t105LeafID">客户叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_AvaiableSite(
            int communityID,
            int t102LeafID,
            int t105LeafID,
            long sysLogID,
            ref List<AvailableSite> datas,
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
                hashParams.Add("t105LeafID", t105LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_AvaiableSite 函数， " +
                        "参数：CommunityID={0}|T102LeafID={1}|" +
                        "T105LeafID={2}|SysLogID={3}",
                        communityID,
                        t102LeafID,
                        t105LeafID,
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
                            "ufn_GetList_AvaiableSite",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AvailableSite>;
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
        /// 获取当前站点的可用目标存储地点清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_DstDeliveryStoreSites(
            int communityID,
            long sysLogID,
            ref List<DstDeliveryStoreSite> datas,
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
                        "调用 ufn_GetList_DstDeliveryStoreSites 函数， " +
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
                            "ufn_GetList_DstDeliveryStoreSites",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<DstDeliveryStoreSite>;
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

        /// <param name="communityID">社区标识</param>
        /// <param name="t117LeafID">标签叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetInfo_TemplateFMTStr(
            int communityID,
            int t117LeafID,
            long sysLogID,
            ref TemplateContent data,
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
                hashParams.Add("t117LeafID", t117LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_TemplateFMTStr，输入参数：" +
                        "CommunityID={0}|T117LeafID={1}|SysLogID={2}",
                        communityID,
                        t117LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "ufn_GetInfo_TemplateFMTStr",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as TemplateContent;
                    else
                        data = null;
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
        /// <param name="treeID">树标识</param>
        /// <param name="opType">操作类型：A-新增；U-修改；D-删除</param>
        /// <param name="srcLeafID">117树叶标识（修改时传入被修改叶标识；新增传入参考模板叶标识）</param>
        /// <param name="code">节点代码</param>
        /// <param name="alternateCode">节点替代代码</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="attrChangeXML">标签模板内容</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="newLeafID">新标签模板标识</param>
        public void usp_SaveFact_IRAP117Node(
            int communityID,
            int treeID,
            string opType,
            int srcLeafID,
            string code,
            string alternateCode,
            string nodeName,
            string attrChangeXML,
            long sysLogID,
            ref int newLeafID,
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
                hashParams.Add("treeID", treeID);
                hashParams.Add("opType", opType);
                hashParams.Add("srcLeafID", srcLeafID);
                hashParams.Add("code", code);
                hashParams.Add("alternateCode", alternateCode);
                hashParams.Add("nodeName", nodeName);
                hashParams.Add("attrChangeXML", attrChangeXML);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveFact_IRAP117Node，参数：" +
                        "CommunityID={0}|TreeID={1}|OpType={2}|SrcLeafID={3}|" +
                        "Code={4}|AlternateCode={5}|NodeName={6}|AttrChangeXML={7}|" +
                        "SysLogID={8}",
                        communityID, treeID, opType, srcLeafID, code, alternateCode,
                        nodeName, attrChangeXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "usp_SaveFact_IRAP117Node",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    if (errCode == 0)
                    {
                        if (rlt is Hashtable)
                        {
                            Hashtable rltHash = (Hashtable)rlt; 
                            #region 取返回值
                            try
                            {
                                HashtableTools.Instance.GetValue(rltHash, "NewLeafID", out newLeafID);
                                WriteLog.Instance.Write(
                                    string.Format(
                                        "输出参数：NewLeafID={0}",
                                        newLeafID),
                                    strProcedureName);
                            }
                            catch (Exception error)
                            {
                                errCode = -1003;
                                errText = error.Message;
                                WriteLog.Instance.Write(errText, strProcedureName);
                                return;
                            }
                            #endregion
                        }
                        else
                        {
                            errCode = -1002;
                            errText = "应用服务 usp_SaveFact_IRAP117Node 返回的不是 Hashtable！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                    }
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
        /// <param name="correlationID">关联号</param>
        /// <param name="t117LeafID">标签模板叶标识</param>
        public void usp_SaveFact_C75(
            int communityID,
            long correlationID,
            int t117LeafID,
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
                hashParams.Add("correlationID", correlationID);
                hashParams.Add("t117LeafID", t117LeafID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveFact_C75，参数：" +
                        "CommunityID={0}|CorrelationID={1}|T117LeafID={2}",
                        communityID, correlationID, t117LeafID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "usp_SaveFact_C75",
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
        public void ufn_GetInfo_SKUID(
            int communityID,
            string skuID,
            long sysLogID,
            ref BWI_SKUIDInfo data,
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
                hashParams.Add("skuID", skuID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_SKUID，输入参数：" +
                        "CommunityID={0}|SKUID={1}|SysLogID={2}",
                        communityID,
                        skuID,
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
                            "ufn_GetInfo_SKUID",
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as BWI_SKUIDInfo;
                    else
                        data = null;
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
        /// 获取指定产品指定工位可选产品失效模式清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_FailureModes(
            int communityID,
            int productLeaf,
            int workUnitLeaf,
            long sysLogID,
            ref List<FailureMode> datas,
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
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_FailureModes 函数， " +
                        "参数：CommunityID={0}|ProductLeaf={1}|" +
                        "WorkUnitLeaf={2}|SysLogID={3}",
                        communityID,
                        productLeaf,
                        workUnitLeaf,
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
                            "ufn_GetList_FailureModes",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<FailureMode>;
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
        /// 根据工位获取失效模式
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_WorkUnitFailureModes(
            int communityID,
            int t107LeafID,
            long sysLogID,
            ref List<FailureModeByWorkUnit> datas,
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
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_WorkUnitFailureModes 函数， " +
                        "参数：CommunityID={0}|T107LeafID={1}|SysLogID={2}",
                        communityID,
                        t107LeafID,
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
                            "ufn_GetList_WorkUnitFailureModes",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<FailureModeByWorkUnit>;
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
        /// 获取信息站点上下文(工位或工作流结点功能信息)
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_WIPStationsOfAHost(
            int communityID,
            long sysLogID,
            ref List<WIPStation> datas,
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
                        "调用 ufn_GetList_WIPStationsOfAHost 函数， " +
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
                            "ufn_GetList_WIPStationsOfAHost",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<WIPStation>;
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
        /// 获取经由指定工位产品清单或经由指定工作流结点的流程清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="isWorkFlowNode">是否工作流结点</param>
        public void ufn_GetList_ProductsViaStation(
            int communityID,
            int t107LeafID,
            bool isWorkFlowNode,
            long sysLogID,
            ref List<ProductViaStation> datas,
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
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("isWorkFlowNode", isWorkFlowNode);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_ProductsViaStation 函数， " +
                        "参数：CommunityID={0}|T107LeafID={1}|"+
                        "IsWorkFlowNode={2}|SysLogID={3}",
                        communityID,
                        t107LeafID,
                        isWorkFlowNode,
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
                            "ufn_GetList_ProductsViaStation",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ProductViaStation>;
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
        /// 获取检查工序获取的部件位置清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">
        /// 工序叶标识（在维修中固定传0；在人工检查中传WIPStation中的T216LeafID）
        /// </param>
        public void ufn_GetList_Symbols_Inspecting(
            int communityID,
            long sysLogID,
            int t102LeafID,
            int t216LeafID,
            ref List<SymbolInspecting> datas,
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
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("t216LeafID", t216LeafID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_Symbols_Inspecting 函数， " +
                        "参数：CommunityID={0}|SysLogID={1}|" +
                        "T102LeafID={2}|T216LeafID={3}",
                        communityID,
                        sysLogID,
                        t102LeafID,
                        t216LeafID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MDM.dll",
                            "IRAP.BL.MDM.IRAPMDM",
                            "ufn_GetList_Symbols_Inspecting",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<SymbolInspecting>;
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
        /// 获取指定产品指定工序发现缺陷的根源工序
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">
        /// 工序叶标识（在维修中固定传0；在人工检查中传WIPStation中的T216LeafID）
        /// </param>
        public void ufn_GetList_DefectRootCauses(
            int communityID,
            long sysLogID,
            int t102LeafID,
            int t216LeafID,
            ref List<DefectRootCause> datas,
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
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("t216LeafID", t216LeafID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_DefectRootCauses 函数， " +
                        "参数：CommunityID={0}|SysLogID={1}|" +
                        "T102LeafID={2}|T216LeafID={3}",
                        communityID,
                        sysLogID,
                        t102LeafID,
                        t216LeafID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MDM.dll",
                            "IRAP.BL.MDM.IRAPMDM",
                            "ufn_GetList_DefectRootCauses",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<DefectRootCause>;
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
        /// 获取指定产品指定工序的质量标准
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="shotTime">时间点（空串-当前）</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_QualityStandard(
            int communityID,
            int t102LeafID,
            int t216LeafID,
            string shotTime,
            long sysLogID,
            ref List<QualityStandard> datas,
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
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("shotTime", shotTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_QualityStandard，输入参数：" +
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
                        "ufn_GetList_QualityStandard",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<QualityStandard>;
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
        /// 功能描述： 请填写本数据库对象功能的简要描述
        /// ⒈   获取指定生产线或工作中心的可用班次清单供选择
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识（134-产线  211-工作中心）</param>
        /// <param name="leafID">产线或工作中心叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_ShiftsOfAMFGRSC(
            int communityID,
            int treeID,
            int leafID,
            long sysLogID,
            ref List<Shift> datas,
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
                hashParams.Add("treeID", treeID);
                hashParams.Add("leafID", leafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_ShiftsOfAMFGRSC，输入参数：" +
                        "CommunityID={0}|TreeID={1}|LeafID={2}|" +
                        "SysLogID={3}",
                        communityID,
                        treeID,
                        leafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "ufn_GetList_ShiftsOfAMFGRSC",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<Shift>;
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
        /// 获取当前产品当前工序前面所有制造工序清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="refUnixTime">参考的Unix时间</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_PrevMFGOperations(
            int communityID,
            int t102LeafID,
            int t107LeafID,
            int refUnixTime,
            long sysLogID,
            ref List<MFGOperation> datas,
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
                hashParams.Add("refUnixTime", refUnixTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_PrevMFGOperations，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T107LeafID={2}|" +
                        "RefUnixTime={3}|SysLogID={4}",
                        communityID,
                        t102LeafID,
                        t107LeafID,
                        refUnixTime,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MDM.dll",
                        "IRAP.BL.MDM.IRAPMDM",
                        "ufn_GetList_PrevMFGOperations",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<MFGOperation>;
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