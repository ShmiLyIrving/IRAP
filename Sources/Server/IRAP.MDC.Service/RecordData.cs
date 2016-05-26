using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

using IRAP.Global;
using IRAP.Entity.MDM;
using IRAP.WebService.Client.UES;

namespace IRAP.MDC.Service
{
    public class RecordData
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        /// <summary>
        /// 社区标识
        /// </summary>
        private int communityID = 60010;

        private string source = "";
        private string data = "";
        private RegInstrument instrument = null;
        private string activeMQ_BrokerUri = "";
        private string activeMQ_QueueName = "";

        /// <summary>
        /// 实际测量值
        /// </summary>
        private long metric01 = 0;

        private IConnectionFactory factory = null;

        public RecordData(string source, string data, List<RegInstrument> regInstruments)
        {
            this.source = 
                source.Substring(
                    0,
                    source.IndexOf(':'));
            this.data = data;

            foreach (RegInstrument regInstru in regInstruments)
            {
                if (regInstru.IPAddress == this.source)
                {
                    this.instrument = regInstru;
                }
            }

            string strProcedureName =
                string.Format(
                    "{0}.{1}:{2}",
                    className,
                    MethodBase.GetCurrentMethod().Name,
                    source);

            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            #region 获取系统配置参数
            if (config.AppSettings.Settings["CommunityID"] != null)
            {
                string temp = config.AppSettings.Settings["CommunityID"].Value.ToString();
                Int32.TryParse(temp, out communityID);
                if (communityID == 0)
                    communityID = 60010;
            }
            #endregion

            #region 获取 ActiveMQ 连接参数
            if (config.AppSettings.Settings["ActiveMQ_BrokerUri"] != null)
                activeMQ_BrokerUri =
                    config.AppSettings.Settings["ActiveMQ_BrokerUri"].Value.ToString();
            if (config.AppSettings.Settings["ActiveMQ_QueueName"] != null)
                activeMQ_QueueName =
                    config.AppSettings.Settings["ActiveMQ_QueueName"].Value.ToString();
            #endregion

            #region 初始化 ActiveMQ
            if (activeMQ_BrokerUri.Trim() != "" &&
                activeMQ_QueueName.Trim() != "")
            {
                try
                {
                    factory = new ConnectionFactory(activeMQ_BrokerUri);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(
                        string.Format(
                            "初始化 ActiveMQ 失败：{0}",
                            error.Message),
                        strProcedureName);
                }
            }
            else
            {
                WriteLog.Instance.Write("无法初始化 ActiveMQ", strProcedureName);
            }
            #endregion
        }

        public bool DataValid()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}:{2}",
                    className,
                    MethodBase.GetCurrentMethod().Name,
                    source);

            if (instrument == null)
            {
                // 量仪还未在系统注册，不接受任何测量数据
                WriteLog.Instance.Write(
                    string.Format(
                        "量仪[{0}]还未在系统中注册，暂时不接受任何测量数据",
                        source),
                    strProcedureName);
                return false;
            }
            else
            {
                if (data.Length == instrument.LengthOfDataMsg)
                {
                    double fltMetric01 = 0;
                    if (
                        !double.TryParse(
                            data.Substring(0, data.Length - 3),
                            out fltMetric01))
                    {
                        WriteLog.Instance.Write(
                            string.Format(
                                "测量数据[(0}]不符合格式要求，无法转换成数值",
                                data),
                            strProcedureName);
                        return false;
                    }
                    else
                    {
                        metric01 = Convert.ToInt64(fltMetric01 * Math.Pow(10, instrument.Scale));
                        return true;
                    }
                }
                else
                {
                    WriteLog.Instance.Write(
                        string.Format(
                            "接收到的测量数据[{0}]长度不符合定义[{1}]要求",
                            data,
                            instrument.LengthOfDataMsg),
                        strProcedureName);
                    return false;
                }
            }
        }

        public void Record()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}:{2}",
                    className,
                    MethodBase.GetCurrentMethod().Name,
                    source);

            if (SaveData(metric01))
                SendMessageToESB();
        }

        private bool SaveData(long metric01)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}:{2}",
                    className,
                    MethodBase.GetCurrentMethod().Name,
                    source);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                EntityWIPIDInfo wipInfo = new EntityWIPIDInfo();

                IRAPUESClient.Instance.WIP_WIPID(
                    communityID,
                    "Anonymous",
                    1,
                    instrument.InstrumentCode,
                    ref wipInfo,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode != 0)
                    return false;

                IRAPUESClient.Instance.DC_Measure(
                    communityID,
                    wipInfo.UserCode,
                    wipInfo.SysLogID,
                    wipInfo.ProductNo,
                    wipInfo.WIPCode,
                    wipInfo.PWONo,
                    wipInfo.ContainerNo,
                    wipInfo.WIPStationCode,
                    wipInfo.WIPQty,
                    instrument.T20LeafID,
                    metric01,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                return errCode == 0;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                return false;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void SendMessageToESB()
        {
            if (factory != null && 
                activeMQ_QueueName.Trim() != "")
            {
                using (IConnection connection = factory.CreateConnection())
                {
                    using (ISession session = connection.CreateSession())
                    {
                        IMessageProducer prod =
                            session.CreateProducer(
                                new ActiveMQQueue(activeMQ_QueueName));
                        ITextMessage message = prod.CreateTextMessage();
                        message.Text = source;
                        message.Properties.SetString("filter", source);
                        prod.Send(
                            message,
                            MsgDeliveryMode.Persistent,
                            MsgPriority.Normal,
                            TimeSpan.MinValue);
                    }
                }
            }
        }
    }
}