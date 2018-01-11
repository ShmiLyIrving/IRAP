using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

using IRAP.Global;
using IRAP.Entities.DPA;

namespace IRAP.WCF.Client.Method
{
    public class IRAPDPAClient
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static IRAPDPAClient _instance = null;

        public static IRAPDPAClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPDPAClient();
                return _instance;
            }
        }

        private IRAPDPAClient() { }

        /// <summary>
        /// 向数据库表 IRAPDPA..dpa_Imp_SmeltProductionPlan 表中插入多条记录
        /// </summary>
        /// <param name="datas">记录集合</param>
        public void msp_InsertIntoSmeltProductionPlanTable(
            List<dpa_Imp_SmeltProductionPlan> datas,
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
                    hashParams.Add("datas", datas);
                    WriteLog.Instance.Write(
                        "执行应用服务方法 msp_InsertIntoSmeltProductionPlanTable ",
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.DPA.dll",
                        "IRAP.BL.DPA.IRAPDPA",
                        "msp_InsertIntoSmeltProductionPlanTable",
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
        /// 校验 dpa_Imp_SmeltProductionPlan 中的生产计划是否正确
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="importID">导入批次标识</param>
        /// <param name="sysLogID">系统登录 标识</param>
        public void usp_PokaYoke_SmeltPWORelease(
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
                            "usp_PokaYoke_SmeltPWORelease，参数：" +
                            "CommunityID={0}|ImportID={1}|SysLogID={2}",
                            communityID, importID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.DPA.dll",
                        "IRAP.BL.DPA.IRAPDPA",
                        "usp_PokaYoke_SmeltPWORelease",
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
        /// 获取指定 ImportLogID 的导入记录
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="importLogID">导入标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="datas">List&lt;pda_Imp_SmeltProductionPlan&gt;</param>
        public void mfn_GetList_SmeltProductionPlan(
            int communityID,
            long importLogID,
            long sysLogID,
            ref List<dpa_Imp_SmeltProductionPlan> datas,
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
                hashParams.Add("importLogID", importLogID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 mfn_GetList_SmeltProductionPlan 函数， " +
                        "参数：CommunityID={0}|ImportLogID={1}|SysLogID={2}",
                        communityID,
                        importLogID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.DPA.dll",
                            "IRAP.BL.DPA.IRAPDPA",
                            "mfn_GetList_SmeltProductionPlan",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<dpa_Imp_SmeltProductionPlan>;
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