using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

using IRAP.Global;
using IRAP.Entities.MES;

namespace IRAP.WCF.Client.Method
{
    public class IRAPMESMIClient
    {
        private static IRAPMESMIClient _instance = null;
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private IRAPMESMIClient()
        {

        }

        public static IRAPMESMIClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPMESMIClient();
                return _instance;
            }
        }

        /// <summary>
        /// 人工检查记录保存
        /// </summary>
        /// <param name="userCode">系统登录用户号</param>
        /// <param name="agencyLeaf">登录用户的机构叶标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="t107EntityID">工位实体标识</param>
        /// <param name="t132LeafID">产品族叶标识</param>
        /// <param name="containerNo">容器号</param>
        /// <param name="functionName">功能名称</param>
        /// <param name="wipInspecting">人工检查实体对象</param>
        /// <param name="confirmTime">检查确认时间</param>
        public void msp_SaveFact_ManualInspecting(
            int communityID,
            string userCode,
            int agencyLeaf,
            int productLeaf,
            int workUnitLeaf,
            int t107EntityID,
            int t132LeafID,
            string containerNo,
            string functionName,
            Inspecting wipInspecting,
            DateTime confirmTime,
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
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("agencyLeaf", agencyLeaf);
                    hashParams.Add("productLeaf", productLeaf);
                    hashParams.Add("workUnitLeaf", workUnitLeaf);
                    hashParams.Add("t107EntityID", t107EntityID);
                    hashParams.Add("t132LeafID", t132LeafID);
                    hashParams.Add("containerNo", containerNo);
                    hashParams.Add("functionName", functionName);
                    hashParams.Add("wipInspecting", wipInspecting);
                    hashParams.Add("confirmTime", confirmTime);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 msp_SaveFact_ManualInspecting，输入参数：" +
                            "CommunityID={0}|UserCode={1}|AgencyLeaf={2}|"+
                            "ProductLeaf={3}|WorkUnitLeaf={4}|T107EntityID={5}|"+
                            "T132LeafID={6}|ContainerNo={7}|FunctionName={8}|" +
                            "WIPInspecting.Count={9}|ConfirmTime={10}|SysLogID={11}",
                            communityID, userCode, agencyLeaf, productLeaf, workUnitLeaf,
                            t107EntityID, t132LeafID, containerNo, functionName,
                            wipInspecting.SubWIPIDCodes.Count,
                            confirmTime,
                            sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.ManualInspecting",
                        "msp_SaveFact_ManualInspecting",
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