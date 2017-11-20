using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

using IRAP.Global;
using IRAP.Entities.MES;

namespace IRAP.WCF.Client.Method
{
    public class IRAPMESPKGClient
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static IRAPMESPKGClient _instance = null;

        private IRAPMESPKGClient() { }

        public static IRAPMESPKGClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPMESPKGClient();
                return _instance;
            }
        }

        public void ufn_GetKanban_PackageTypes(
            int communityID,
            int productLeaf,
            int workUnitLeaf,
            long sysLogID,
            ref List<PackageType> datas,
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
                        "调用 ufn_GetKanban_PackageTypes，输入参数：" +
                        "CommunityID={0}|ProductLeaf={1}|WorkUnitLeaf={2}|"+
                        "SysLogID={3}",
                        communityID, productLeaf, workUnitLeaf, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.ProductPackage",
                        "ufn_GetKanban_PackageTypes",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<PackageType>;
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
        /// 获取未完成包装信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="packagingSpecNo">包装规格序号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetInfo_UncompletedPackage(
            int communityID,
            int productLeaf,
            int workUnitLeaf,
            int packagingSpecNo,
            long sysLogID,
            ref UncompletedPackage data,
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
                hashParams.Add("productLeaf", productLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("packagingSpecNo", packagingSpecNo);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_UncompletedPackage，输入参数：" +
                        "CommunityID={0}|ProductLeaf={1}|WorkUnitLeaf={2}|" +
                        "PackagingSpecNo={3}|SysLogID={4}",
                        communityID,
                        productLeaf,
                        workUnitLeaf,
                        packagingSpecNo,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.ProductPackage",
                        "ufn_GetInfo_UncompletedPackage",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as UncompletedPackage;
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
        /// 获取指定包装交易号的业务事实明细
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">包装交易号</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetFactList_Packaging(
            int communityID,
            long transactNo,
            int productLeaf,
            long sysLogID,
            ref List<FactPackaging> datas,
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
                hashParams.Add("transactNo", transactNo);
                hashParams.Add("productLeaf", productLeaf);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetFactList_Packaging，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|ProductLeaf={2}|" +
                        "SysLogID={3}",
                        communityID, transactNo, productLeaf, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.ProductPackage",
                        "ufn_GetFactList_Packaging",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<FactPackaging>;
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
        /// 保存产品包装事实并防错
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">包装工位叶标识</param>
        /// <param name="packagingSpecNo">包装规格序号(C64R7.Ordinal)</param>
        /// <param name="wipPattern">产品主标识代码</param>
        /// <param name="layerNumOfPallet">铲板第几层</param>
        /// <param name="cartonNumOfLayer">当前层第几箱</param>
        /// <param name="layerNumOfCarton">箱内第几层内包装(盒）</param>
        /// <param name="rowNumOfCarton">箱内第几排内包装(盒)</param>
        /// <param name="colNumOfCarton">箱内第几列内包装(盒)</param>
        /// <param name="layerNumOfBox">盒内第几层产品</param>
        /// <param name="rowNumOfBox">盒内第几排产品</param>
        /// <param name="colNumOfBox">盒内第几列产品</param>
        /// <param name="boxSerialNumber">内包装序列号</param>
        /// <param name="cartonSerialNumber">箱包装序列号</param>
        /// <param name="layerSerialNumber">包装层层序列号</param>
        /// <param name="palletSerialNumber">铲板标签序列号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errTex"></param>
        /// <returns></returns>
        public string usp_SaveFact_Packaging(
            int communityID,
            long transactNo,
            long factID,
            int productLeaf,
            int workUnitLeaf,
            int packagingSpecNo,
            string wipPattern,
            int layerNumOfPallet,
            int cartonNumOfLayer,
            int layerNumOfCarton,
            int rowNumOfCarton,
            int colNumOfCarton,
            int layerNumOfBox,
            int rowNumOfBox,
            int colNumOfBox,
            string boxSerialNumber,
            string cartonSerialNumber,
            string layerSerialNumber,
            string palletSerialNumber,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            // new NotImplementedException();
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
                hashParams.Add("transactNo", transactNo);
                hashParams.Add("factID", factID);
                hashParams.Add("productLeaf", productLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("packagingSpecNo", packagingSpecNo);
                hashParams.Add("wipPattern", wipPattern);
                hashParams.Add("layerNumOfPallet", layerNumOfPallet);
                hashParams.Add("cartonNumOfLayer", cartonNumOfLayer);
                hashParams.Add("layerNumOfCarton", layerNumOfCarton);
                hashParams.Add("rowNumOfCarton", rowNumOfCarton);
                hashParams.Add("colNumOfCarton", colNumOfCarton);
                hashParams.Add("layerNumOfBox", layerNumOfBox);
                hashParams.Add("rowNumOfBox", rowNumOfBox);
                hashParams.Add("colNumOfBox", colNumOfBox);
                hashParams.Add("boxSerialNumber", boxSerialNumber);
                hashParams.Add("cartonSerialNumber", cartonSerialNumber);
                hashParams.Add("layerSerialNumber", layerSerialNumber); 
                hashParams.Add("palletSerialNumber", palletSerialNumber);
                hashParams.Add("sysLogID", sysLogID);

                WriteLog.Instance.Write(
                    string.Format(
                                                "调用 IRAPMES..usp_SaveFact_Packaging，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                        "ProductLeaf={3}|WorkUnitLeaf={4}|PackagingSpecNo={5}|" +
                        "WIPPattern={6}|LayerNumOfPallet={7}|CartonNumOfLayer={8}|" +
                        "LayerNumOfCarton={9}|RowNumOfCarton={10}|ColNumOfCarton={11}|" +
                        "LayerNumOfBox={12}|RowNumOfBox={13}|ColNumOfBox={14}|" +
                        "BoxSerialNumber={15}|CartonSerialNumber={16}|LayerSerialNumber={17}|" +
                        "PalletSerialNumber={18}|SysLogID={19}",
                        communityID,
                        transactNo,
                        factID,
                        productLeaf,
                        workUnitLeaf,
                        packagingSpecNo,
                        wipPattern,
                        layerNumOfPallet,
                        cartonNumOfLayer,
                        layerNumOfCarton,
                        rowNumOfCarton,
                        colNumOfCarton,
                        layerNumOfBox,
                        rowNumOfBox,
                        colNumOfBox,
                        boxSerialNumber,
                        cartonSerialNumber,
                        layerSerialNumber,
                        palletSerialNumber,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.ProductPackage",
                        "usp_SaveFact_Packaging",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    return rlt as string;
                }
                #endregion
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
                return "";
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void ufn_GetLabelFMTStr(
            int communityID,
            int correlationID,
            int labelID,
            string serialNo,
            long sysLogID,
            ref List<LabelFMTStr> labelFMTStr,
            out int errCode,
            out string errText
            )
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                //labelFMTStr.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("correlationID", correlationID);
                hashParams.Add("labelID", labelID);
                hashParams.Add("serialNo", serialNo);
                hashParams.Add("pHStr1", "");
                hashParams.Add("pHStr2", "");
                hashParams.Add("pHStr3", "");
                hashParams.Add("pHStr4", "");
                hashParams.Add("pHStr5", "");
                hashParams.Add("pHStr6", "");
                hashParams.Add("pHStr7", "");
                hashParams.Add("pHStr8", "");
                hashParams.Add("pHStr9", "");
                hashParams.Add("pHStr10", "");
                hashParams.Add("pHStr11", "");
                hashParams.Add("pHStr12", "");
                hashParams.Add("pHStr13", "");
                hashParams.Add("pHStr14", "");
                hashParams.Add("pHStr15", "");
                hashParams.Add("sysLogID", sysLogID);

                //WriteLog.Instance.Write(
                //    string.Format(
                //        "调用 ufn_GetFactList_Packaging，输入参数：" +
                //        "CommunityID={0}|TransactNo={1}|ProductLeaf={2}|" +
                //        "SysLogID={3}",
                //        communityID, transactNo, productLeaf, sysLogID),
                //    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.ProductPackage",
                        "ufn_GetLabelFMTStr",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        labelFMTStr = rlt as List<LabelFMTStr>;
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
        /// 获取包装工位需要打印的标识串
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="correlationID">C64 关联号</param>
        /// <param name="ordinal">C64 包装行集序号</param>
        /// <param name="labelType">标签类型（3种）</param>
        /// <param name="nowTime">当前事件</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetNextPackageSN(
            int communityID,
            int correlationID,
            int ordinal,
            string labelType,
            DateTime nowTime,
            long sysLogID,
            ref string sequenceNo,
            out int errCode,
            out string errText)
        {
            sequenceNo = "";

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
                hashParams.Add("ordinal", ordinal);
                hashParams.Add("labelType", labelType);
                hashParams.Add("nowTime", nowTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 dbo.ufn_GetNextPackageSN，输入参数：" +
                        "CommunityID={0}|CorrelationID={1}|Ordinal={2}|" +
                        "LabelType={3}|NowTime={4}|SysLogID={5}",
                        communityID,
                        correlationID,
                        ordinal,
                        labelType,
                        nowTime,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.ProductPackage",
                        "ufn_GetNextPackageSN",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}，SequenceNo={2}",
                            errCode,
                            errText,
                            (string)rlt),
                        strProcedureName);

                    if (errCode == 0)
                        sequenceNo = (string)rlt;
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