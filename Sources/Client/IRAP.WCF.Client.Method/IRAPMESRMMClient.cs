using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

using IRAP.Global;

namespace IRAP.WCF.Client.Method
{
    public class IRAPMESRMMClient
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static IRAPMESRMMClient _instance = null;

        private IRAPMESRMMClient()
        {
        }

        public static IRAPMESRMMClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPMESRMMClient();
                return _instance;
            }
        }

        /// <summary>
        /// 提供界面维护T20质量参数和工艺参数。
        /// 注意：前台界面需要在“增加”和“修改”时，
        ///      做 Code 和 Name 的重复性放错
        ///      （Code 为空时不需放错，Name 
        ///      不能空白）。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="deltaCMD">A-增；D-删；U-改</param>
        /// <param name="paramNode">
        /// 参数类型NodeID：
        /// 5094-制造质量参数；
        /// 5140-制造工艺参数。
        /// </param>
        /// <param name="paramLeaf">新增时：0；删除和修改时传参数的 LeafID</param>
        /// <param name="paramCode">参数的编码</param>
        /// <param name="paramName">参数的名称</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ssp_SaveADU_Parameters(
            int communityID,
            string deltaCMD,
            int paramNode,
            int paramLeaf,
            string paramCode,
            string paramName,
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
                    hashParams.Add("deltaCMD", deltaCMD);
                    hashParams.Add("paramNode", paramNode);
                    hashParams.Add("paramLeaf", paramLeaf);
                    hashParams.Add("paramCode", paramCode);
                    hashParams.Add("paramName", paramNode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format("执行存储过程 ssp_SaveADU_Parameters，参数：" +
                            "CommunityID={0}|DeltaCMD={1}|ParamCode={2}|ParamLeaf={3}|"+
                            "ParamCode={4}|ParamName={5}|SysLogID={6}",
                            communityID, deltaCMD, paramCode, paramLeaf,
                            paramCode, paramNode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MESRMM.dll",
                        "IRAP.BL.MESRMM.MesRMM",
                        "ssp_SaveADU_Parameters",
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