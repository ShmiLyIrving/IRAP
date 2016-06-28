using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Xml;

using IRAP.Global;

namespace IRAP.WebService.Client.UES
{
    internal class WebServiceIRAPUES : WS_IRAPUES.IRAPUESBase
    {
        public WebServiceIRAPUES()
        {
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["WebServiceURL"] != null)
                Url = config.AppSettings.Settings["WebServiceURL"].Value.ToString();
            if (Url.Trim() == "")
                Url = "http://192.168.57.221:8015/IRAPUESWebService.asmx"; 
        }
    }

    public class IRAPUESClient : IRAP.WebService.Client.CustomWSClient
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static IRAPUESClient _instance = null;

        private IRAPUESClient()
        {
        }

        public static IRAPUESClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPUESClient();
                return _instance;
            }
        }

        /// <summary>
        /// 查看指定设备当前正在生产的在制品标识信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码（不签权时传入 Anonymous）</param>
        /// <param name="sysLogID">系统登录标识（不签权时传入 1）</param>
        /// <param name="equipmentCode">设备编号</param>
        public void WIP_WIPID(
            int communityID,
            string userCode,
            long sysLogID,
            string equipmentCode,
            ref EntityWIPIDInfo wipInfo,
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
                using (WebServiceIRAPUES client = new WebServiceIRAPUES())
                {
                    try
                    {
                        wipInfo = new EntityWIPIDInfo();

                        #region 生成调用参数，并调用 WebService，得到输出参数
                        string paramInput =
                            string.Format(
                                "<Parameters><Param ExCode=\"WIP_WIPID\" " +
                                "CommunityID=\"{0}\" UserCode=\"{1}\" " +
                                "SysLogID=\"{2}\" EquipmentCode=\"{3}\"/>" +
                                "</Parameters>",
                                communityID,
                                userCode,
                                sysLogID,
                                equipmentCode);
                        WriteLog.Instance.Write(
                            string.Format(
                                "调用 WebService，输入参数：[{0}]",
                                paramInput),
                            strProcedureName);

                        paramInput = EncodingParam(paramInput);
                        WriteLog.Instance.Write(
                            string.Format("压缩并编码后的字符串：[{0}]", paramInput),
                            strProcedureName);
                        string rlt = client.IRAPUES(paramInput);
                        WriteLog.Instance.Write(
                            string.Format("收到的响应字符串：[{0}]", rlt),
                            strProcedureName);
                        rlt = DecodingParam(rlt);
                        WriteLog.Instance.Write(
                            string.Format(
                                "得到输出参数：[{0}]",
                                rlt),
                            strProcedureName);
                        #endregion

                        #region 解析得到的输出参数
                        errCode = -1009;
                        errText = "输出参数空白！";
                        if (rlt.Trim() != "")
                        {
                            XmlDocument xml = new XmlDocument();

                            try
                            {
                                xml.LoadXml(rlt);
                            }
                            catch (Exception error)
                            {
                                errCode = -1001;
                                errText = error.Message;
                                WriteLog.Instance.Write(error.Message, strProcedureName);
                                return;
                            }

                            foreach (XmlNode node in xml.SelectNodes("Result/Param"))
                            {
                                if (node.Attributes["ErrCode"] != null)
                                {
                                    if (!int.TryParse(node.Attributes["ErrCode"].Value, out errCode))
                                        errCode = -1009;
                                }
                                else
                                    errCode = -1009;

                                if (node.Attributes["ErrText"] != null)
                                    errText = node.Attributes["ErrText"].Value;
                                else
                                    errText = "输出参数中没有定义 ErrText";

                                if (errCode == 0)
                                {
                                    if (node.Attributes["UserCode"] != null)
                                        wipInfo.UserCode = node.Attributes["UserCode"].Value;
                                    if (node.Attributes["SysLogID"] != null)
                                        wipInfo.SysLogID = Tools.ConvertToInt64(node.Attributes["SysLogID"].Value);
                                    if (node.Attributes["ProductNo"] != null)
                                        wipInfo.ProductNo = node.Attributes["ProductNo"].Value;
                                    if (node.Attributes["WIPCode"] != null)
                                        wipInfo.WIPCode = node.Attributes["WIPCode"].Value;
                                    if (node.Attributes["AltWIPCode"] != null)
                                        wipInfo.AltWIPCode = node.Attributes["AltWIPCode"].Value;
                                    if (node.Attributes["SerialNumber"] != null)
                                        wipInfo.SerialNumber = node.Attributes["SerialNumber"].Value;
                                    if (node.Attributes["LotNumber"] != null)
                                        wipInfo.LotNumber = node.Attributes["LotNumber"].Value;
                                    if (node.Attributes["PWONo"] != null)
                                        wipInfo.PWONo = node.Attributes["PWONo"].Value;
                                    if (node.Attributes["ContainerNo"] != null)
                                        wipInfo.ContainerNo = node.Attributes["ContainerNo"].Value;
                                    if (node.Attributes["NumSubWIPs"] != null)
                                        wipInfo.NumSubWIPs = Tools.ConvertToInt32(node.Attributes["NumSubWIPs"].Value);
                                    if (node.Attributes["WIPQty"] != null)
                                        wipInfo.WIPQty = Tools.ConvertToInt64(node.Attributes["WIPQty"].Value);
                                    if (node.Attributes["Scale"] != null)
                                        wipInfo.Scale = Tools.ConvertToInt32(node.Attributes["Scale"].Value);
                                    if (node.Attributes["UnitOfMeasure"] != null)
                                        wipInfo.UnitOfMeasure = node.Attributes["UnitOfMeasure"].Value;
                                    if (node.Attributes["WIPStationCode"] != null)
                                        wipInfo.WIPStationCode = node.Attributes["WIPStationCode"].Value;
                                    if (node.Attributes["OperationCode"] != null)
                                        wipInfo.OperationCode = node.Attributes["OperationCode"].Value;
                                    if (node.Attributes["MoveInTime"] != null)
                                        wipInfo.MoveInTime = node.Attributes["MoveInTime"].Value;
                                    if (node.Attributes["QueueInTime"] != null)
                                        wipInfo.QueueInTime = node.Attributes["QueueInTime"].Value;
                                    if (node.Attributes["T133LeafID"] != null)
                                        wipInfo.T133LeafID = Tools.ConvertToInt32(node.Attributes["T133LeafID"].Value);
                                    if (node.Attributes["T216LeafID"] != null)
                                        wipInfo.T216LeafID = Tools.ConvertToInt32(node.Attributes["T216LeafID"].Value);
                                    if (node.Attributes["T20LeafID"] != null)
                                        wipInfo.T20LeafID = Tools.ConvertToInt32(node.Attributes["T20LeafID"].Value);
                                    if (node.Attributes["T47LeafID"] != null)
                                        wipInfo.T47LeafID = Tools.ConvertToInt32(node.Attributes["T47LeafID"].Value);
                                    if (node.Attributes["LCL"] != null)
                                        wipInfo.LCL = Tools.ConvertToInt64(node.Attributes["LCL"].Value);
                                    if (node.Attributes["UCL"] != null)
                                        wipInfo.UCL = Tools.ConvertToInt64(node.Attributes["UCL"].Value);
                                }

                                break;
                            }
                        }
                        #endregion
                    }
                    catch (Exception error)
                    {
                        errCode = -1001;
                        errText = error.Message;
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 测量仪表通过本接口上传在制品指定特性测量数据
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">操作工用户代码</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="productNo">产品编号</param>
        /// <param name="wipCode">在制品主标识代码</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="containerNo">在制品容器编号</param>
        /// <param name="wipStationCode">工位代码</param>
        /// <param name="wipQty">在制品数量</param>
        /// <param name="t20LeafID">测量参数叶标识</param>
        /// <param name="metric01">实测值</param>
        public void DC_Measure(
            int communityID,
            string userCode,
            long sysLogID,
            string productNo,
            string wipCode,
            string pwoNo,
            string containerNo,
            string wipStationCode,
            long wipQty,
            int t20LeafID,
            long metric01,
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
                using (WebServiceIRAPUES client = new WebServiceIRAPUES())
                {
                    try
                    {
                        #region 生成调用参数，并调用 WebService，得到输出参数
                        string paramInput =
                            string.Format(
                                "<Parameters><Param ExCode=\"DC_Measure\" " +
                                "CommunityID=\"{0}\" UserCode=\"{1}\" " +
                                "SysLogID=\"{2}\" ProductNo=\"{3}\" " +
                                "WIPCode=\"{4}\" PWONo=\"{5}\" "+
                                "ContainerNo=\"{6}\" WIPStationCode=\"{7}\" "+
                                "WIPQty=\"{8}\" T20LeafID=\"{9}\" "+
                                "Metric01=\"{10}\"/>" +
                                "</Parameters>",
                                communityID,
                                userCode,
                                sysLogID,
                                productNo,
                                wipCode,
                                pwoNo,
                                containerNo,
                                wipStationCode,
                                wipQty,
                                t20LeafID,
                                metric01);
                        WriteLog.Instance.Write(
                            string.Format("调用 WebService，输入参数：[{0}]", paramInput),
                            strProcedureName);

                        paramInput = EncodingParam(paramInput);
                        WriteLog.Instance.Write(
                            string.Format("压缩并编码后的字符串：[{0}]", paramInput),
                            strProcedureName);
                        string rlt = client.IRAPUES(paramInput);
                        WriteLog.Instance.Write(
                            string.Format("收到的响应字符串：[{0}]", rlt),
                            strProcedureName);
                        rlt = DecodingParam(rlt);
                        WriteLog.Instance.Write(
                            string.Format("得到输出参数：[{0}]", rlt),
                            strProcedureName);
                        #endregion

                        #region 解析得到的输出参数
                        errCode = -1009;
                        errText = "输出参数空白！";
                        if (rlt.Trim() == "")
                        {
                            XmlDocument xml = new XmlDocument();

                            try
                            {
                                xml.LoadXml(rlt);
                            }
                            catch (Exception error)
                            {
                                errCode = -1001;
                                errText = error.Message;
                                WriteLog.Instance.Write(error.Message, strProcedureName);
                                return;
                            }

                            foreach (XmlNode node in xml.SelectNodes("Result/Param"))
                            {
                                if (node.Attributes["ErrCode"] != null)
                                {
                                    if (!int.TryParse(node.Attributes["ErrCode"].Value, out errCode))
                                        errCode = -1009;
                                }
                                else
                                    errCode = -1009;

                                if (node.Attributes["ErrText"] != null)
                                    errText = node.Attributes["ErrText"].Value;
                                else
                                    errText = "输出参数中没有定义 ErrText";

                                return;
                            }
                        }
                        #endregion

                    }
                    catch (Exception error)
                    {
                        errCode = -1001;
                        errText = error.Message;
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
