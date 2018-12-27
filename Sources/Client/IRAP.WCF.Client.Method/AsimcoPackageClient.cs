using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

using IRAP.Global;
using IRAPShared;
using IRAP.Entities.Asimco;

namespace IRAP.WCF.Client.Method
{
    public class AsimcoPackageClient
    {
        private static AsimcoPackageClient _instance = null;

        public static AsimcoPackageClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AsimcoPackageClient();
                return _instance;
            }
        }

        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private AsimcoPackageClient() { }

        /// <summary>
        /// 获取待打印的销售订单信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="soNumber">销售订单号（筛选条件，默认空白）</param>
        /// <param name="productNo">产品号（筛选条件，默认空白）</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void ufn_GetList_WaitPackageSO(
            int communityID,
            string soNumber,
            string productNo,
            long sysLogID,
            ref List<WaitPackageSO> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (datas == null)
                    datas = new List<WaitPackageSO>();
                else
                    datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("soNumber", soNumber);
                hashParams.Add("productNo", productNo);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.AsimcoPrdtPackage",
                            MethodBase.GetCurrentMethod().Name,
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<WaitPackageSO>;
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
        /// 获取待分单的包装生产线
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void ufn_GetList_PackageLine(
            int communityID,
            long sysLogID,
            ref List<PackageLine> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (datas == null)
                    datas = new List<PackageLine>();
                else
                    datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key].ToString()}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.AsimcoPrdtPackage",
                            MethodBase.GetCurrentMethod().Name,
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<PackageLine>;
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
        /// 获取产品供给客户清单
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="moNumber">制造订单号</param>
        /// <param name="moLineNo">制造订单行号</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void ufn_GetList_PackageClient(
            int communityID,
            string moNumber,
            int moLineNo,
            long sysLogID,
            ref List<PackageClient> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (datas == null)
                    datas = new List<PackageClient>();
                else
                    datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("moNumber", moNumber);
                hashParams.Add("moLineNo", moLineNo);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.AsimcoPrdtPackage",
                            MethodBase.GetCurrentMethod().Name,
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<PackageClient>;
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
        /// 获取指定打印交易号的外箱清单列表
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="transactNo">打印交易号</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void ufn_GetList_Carton(
            int communityID,
            long transactNo,
            long sysLogID,
            ref List<Carton> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (datas == null)
                    datas = new List<Carton>();
                else
                    datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("transactNo", transactNo);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.AsimcoPrdtPackage",
                            MethodBase.GetCurrentMethod().Name,
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<Carton>;
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
        /// 获取指定外箱标签的内箱清单列表
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="cartonNumber">外箱序号</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void ufn_GetList_BoxOfCarton(
            int communityID,
            string cartonNumber,
            long sysLogID,
            ref List<BoxOfCarton> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (datas == null)
                    datas = new List<BoxOfCarton>();
                else
                    datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("cartonNumber", cartonNumber);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.AsimcoPrdtPackage",
                            MethodBase.GetCurrentMethod().Name,
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<BoxOfCarton>;
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
        /// 获取待确认标签清单列表
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void ufn_GetList_WaitConfirmPrint(
            int communityID,
            long sysLogID,
            ref List<WaitConfirmPrint> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (datas == null)
                    datas = new List<WaitConfirmPrint>();
                else
                    datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.AsimcoPrdtPackage",
                            MethodBase.GetCurrentMethod().Name,
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<WaitConfirmPrint>;
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
        /// 获取待重打的外箱清单列表
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void ufn_GetList_WaitRePrintCarton(
            int communityID,
            long sysLogID,
            ref List<WaitRePrintCarton> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (datas == null)
                    datas = new List<WaitRePrintCarton>();
                else
                    datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.AsimcoPrdtPackage",
                            MethodBase.GetCurrentMethod().Name,
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<WaitRePrintCarton>;
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
        /// 根据订单和产线，预打印标签供后面成套检验
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="moNumber">销售订单号</param>
        /// <param name="moLineNo">销售订单行号</param>
        /// <param name="numberOfBox">内箱产品数量</param>
        /// <param name="cartonNumber">外箱数</param>
        /// <param name="t105LeafID">客户叶标识</param>
        /// <param name="t134LeafID">产线叶标识</param>
        /// <param name="boxNumber">内箱数</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns>TransactNo(打印交易号)</returns>
        public void usp_SaveFact_PackagePrint(
            int communityID,
            string moNumber,
            int moLineNo,
            long numberOfBox,
            long cartonNumber,
            int t105LeafID,
            int t134LeafID,
            long boxNumber,
            long sysLogID,
            ref long transactNo,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            transactNo = 0;

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("moNumber", moNumber);
                hashParams.Add("moLineNo", moLineNo);
                hashParams.Add("numberOfBox", numberOfBox);
                hashParams.Add("cartonNumber", cartonNumber);
                hashParams.Add("boxNumber", boxNumber);
                hashParams.Add("t105LeafID", t105LeafID);
                hashParams.Add("t134LeafID", t134LeafID);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.AsimcoPrdtPackage",
                        MethodBase.GetCurrentMethod().Name,
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
                                    "TransactNo",
                                    out transactNo);
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
                            errText = 
                                $"应用服务 {MethodBase.GetCurrentMethod().Name} 返回的不是 Hashtable！";
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
        /// 单个打印
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="boxNumber">单箱条码</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_RePrintBoxNumber(
            int communityID,
            string boxNumber,
            long sysLogID,
            ref List<RePrintBoxNumber> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (datas == null)
                    datas = new List<RePrintBoxNumber>();
                else
                    datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("boxNumber", boxNumber);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.AsimcoPrdtPackage",
                            MethodBase.GetCurrentMethod().Name,
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<RePrintBoxNumber>;
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
        /// 保存外箱标签重打
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="moNumber">订单号</param>
        /// <param name="moLineNo">订单行号</param>
        /// <param name="cartonNumber">外箱号（默认空白）</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_RePrintCartonNumber(
            int communityID,
            string moNumber,
            int moLineNo,
            string cartonNumber,
            long sysLogID,
            ref List<RePrintCartonNumber> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (datas == null)
                    datas = new List<RePrintCartonNumber>();
                else
                    datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("moNumber", moNumber);
                hashParams.Add("moLineNo", moLineNo);
                hashParams.Add("cartonNumber", cartonNumber);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.AsimcoPrdtPackage",
                            MethodBase.GetCurrentMethod().Name,
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<RePrintCartonNumber>;
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
        /// 发起重打申请
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="parmXML">发起重打申请</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_RequestReprint(
            int communityID,
            string parmXML,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("parmXML", parmXML);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.AsimcoPrdtPackage",
                        MethodBase.GetCurrentMethod().Name,
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        $"({errCode}){errText}",
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
        /// 保存打印确认完成信息
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="parmXML"></param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_SaveFact_PrintConfirm(
            int communityID,
            string parmXML,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("parmXML", parmXML);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.AsimcoPrdtPackage",
                        MethodBase.GetCurrentMethod().Name,
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        $"({errCode}){errText}",
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
        /// 输入外包装数更新内包装数量
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="moNumber">订单号</param>
        /// <param name="moLineNo">订单行号</param>
        /// <param name="t105LeafID">客户叶标识</param>
        /// <param name="cartonNumber">外箱数量</param>
        /// <param name="sysLogID"></param>
        /// <param name="boxNumber">内箱数量（返回参数）</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_PokaYoke_Package(
            int communityID,
            string moNumber,
            int moLineNo,
            int t105LeafID,
            int cartonNumber,
            long sysLogID,
            out int boxNumber,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            boxNumber = 0;

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("moNumber", moNumber);
                hashParams.Add("moLineNo", moLineNo);
                hashParams.Add("t105LeafID", t105LeafID);
                hashParams.Add("cartonNumber", cartonNumber);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.AsimcoPrdtPackage",
                        MethodBase.GetCurrentMethod().Name,
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        $"({errCode}){errText}",
                        strProcedureName);

                    if (errCode == 0)
                    {
                        if (rlt is Hashtable)
                        {
                            Hashtable rltHash = (Hashtable)rlt;

                            #region 取返回值
                            try
                            {
                                HashtableTools.Instance.GetValue(rltHash, "BoxNumber", out boxNumber);
                                WriteLog.Instance.Write(
                                    $"输出参数：BoxNumber={boxNumber}",
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
                            errText = $"应用服务 {MethodBase.GetCurrentMethod().Name} 返回的不是 Hashtable！";
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
        /// 保存标签重打确认完成信息
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="factID">标签事实号</param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void usp_SaveFact_PrintStatus(
            int communityID,
            long factID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("factID", factID);
                hashParams.Add("sysLogID", sysLogID);

                string msg = $"调用 {MethodBase.GetCurrentMethod().Name} ，参数：";
                foreach (string key in hashParams.Keys)
                {
                    msg += $"{key}={hashParams[key]}|";
                }
                WriteLog.Instance.Write(msg, strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.AsimcoPrdtPackage",
                        MethodBase.GetCurrentMethod().Name,
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        $"({errCode}){errText}",
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
    }
}
