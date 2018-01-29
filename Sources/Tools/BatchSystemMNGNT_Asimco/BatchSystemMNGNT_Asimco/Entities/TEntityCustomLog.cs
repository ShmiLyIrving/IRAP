using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAPShared;
using IRAPORM;

namespace BatchSystemMNGNT_Asimco.Entities
{
    [IRAPDB(TableName = "IRAP..stb_Log_WebServiceShuttling")]
    public class TEntityCustomLog
    {
        protected string exchangeXML = "";
        protected string properties = "";
        protected string skuID = "";
        protected string itemNumber = "";
        protected string lotNumber = "";
        protected string binFrom = "";
        protected string binTo = "";
        protected string quantity = "";
        protected string orderNo = "";
        protected string orderLineNo = "";
        protected List<object> exchange = new List<object>();

        [IRAPKey(IsKey = true)]
        public long LogID { get; set; }
        [IRAPKey(IsKey = true)]
        public int PartitioningKey { get; set; }
        [IRAPKey(IsKey = true)]
        public DateTime TimeWritten { get; set; }
        public string ExCode { get; set; }
        public string CorrelationID { get; set; }
        public int WSDLParameterID { get; set; }
        public int RetryCycle { get; set; }
        public string ExChangeXML
        {
            get { return exchangeXML; }
            set
            {
                exchangeXML = value;
                ResolveExchangeXML(value);
            }
        }
        public string Properties
        {
            get { return properties; }
            set
            {
                properties = value;
                ResolvePropertiesXML(value);
            }
        }
        public int ErrCode { get; set; }
        public string ErrText { get; set; }
        public long LinkedLogID { get; set; }
        public bool Retried { get; set; }
        public DateTime NextRetryTime { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public string SKUID { get { return skuID; } }
        [IRAPORMMap(ORMMap = false)]
        public string ItemNumber { get { return itemNumber; } }
        [IRAPORMMap(ORMMap = false)]
        public string LotNumber { get { return lotNumber; } }
        [IRAPORMMap(ORMMap = false)]
        public string BinFrom { get { return binFrom; } }
        [IRAPORMMap(ORMMap = false)]
        public string BinTo { get { return binTo; } }
        [IRAPORMMap(ORMMap = false)]
        public string Quantity { get { return quantity; } }
        [IRAPORMMap(ORMMap = false)]
        public string OrderNo { get { return orderNo; } }
        [IRAPORMMap(ORMMap = false)]
        public string OrderLineNo { get { return orderLineNo; } }
        [IRAPORMMap(ORMMap = false)]
        public bool Checked { get; set; }
        [IRAPORMMap(ORMMap = false)]
        public List<object> ExChange
        {
            get { return exchange; }
        }

        protected virtual void ResolveExchangeXML(string stringXML) { }

        protected virtual void ResolvePropertiesXML(string stringXML)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(stringXML);
                XmlNode skuNode = xml.SelectSingleNode("Properties/SKUID");
                if (skuNode != null)
                    skuID = skuNode.InnerText;
            }
            catch { }
        }

        protected void CopyFrom(TEntityCustomLog data)
        {
            LogID = data.LogID;
            PartitioningKey = data.PartitioningKey;
            TimeWritten = data.TimeWritten;
            ExCode = data.ExCode;
            CorrelationID = data.CorrelationID;
            WSDLParameterID = data.WSDLParameterID;
            RetryCycle = data.RetryCycle;
            ExChangeXML = data.ExChangeXML;
            Properties = data.Properties;
            ErrCode = data.ErrCode;
            ErrText = data.ErrText;
            LinkedLogID = data.LinkedLogID;
            Retried = data.Retried;
            NextRetryTime = data.NextRetryTime;
        }

        protected virtual bool ShowEditorDialogs()
        {
            XtraMessageBox.Show(
                string.Format("还未实现[{0}]的编辑器", ExCode),
                "提示信息",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return false;
        }

        protected virtual void AfterExecute(TEntityCustomLog log) { }

        /// <summary>
        /// 处理当前的日志
        /// </summary>
        public void Do()
        {
            if (ShowEditorDialogs())
            {
                string newXMLString =
                    (ExChange[0] as IXMLNodeObject).GetXMLString();

                TEntityCustomLog logWait4Exec = null;
                if (ErrCode != 0 && !Retried)
                {
                    // 当前日志的最新待重试记录
                    try
                    {
                        TWaitting.Instance.ShowWaitForm("获取最新待重试记录");
                        logWait4Exec =
                            DAL.TDBHelper.GetLastUnsuccessedLogWithLinkedLogID(LinkedLogID);
                    }
                    catch (Exception error)
                    {
                        TWaitting.Instance.CloseWaitForm();
                        MSGHelp.Instance.ShowErrorMessage(error);
                        return;
                    }
                }
                else
                    logWait4Exec = this;

                if (logWait4Exec == null)
                {
                    Exception error = new Exception();
                    error.Data["ErrCode"] = 999999;
                    error.Data["ErrText"] = "当前待处理的日志已经被批量作业处理成功";

                    TWaitting.Instance.CloseWaitForm();
                    MSGHelp.Instance.ShowErrorMessage(error);
                }
                else
                {
                    using (IRAPSQLConnection conn =
                        new IRAPSQLConnection(SysParams.Instance.DBConnectionString))
                    {
                        try
                        {
                            TWaitting.Instance.ShowWaitForm("更新日志记录");
                            logWait4Exec.ExChangeXML =
                                (ExChange[0] as IXMLNodeObject).GetXMLString();

                            IList<IDataParameter> paramList = new List<IDataParameter>();
                            paramList.Add(new IRAPProcParameter("@ExChangeXML", DbType.Xml, newXMLString));
                            paramList.Add(new IRAPProcParameter("@LogID", DbType.Int64, LogID));

                            conn.Update(
                                "UPDATE IRAP..stb_Log_WebServiceShuttling "+
                                "SET ExChangeXML=@ExChangeXML "+
                                "WHERE LogID=@LogID", 
                                paramList);
                        }
                        catch (Exception error)
                        {
                            error.Data["ErrCode"] = 999999;
                            error.Data["ErrText"] =
                                string.Format(
                                    "更新日志记录时发生异常：[{0}]",
                                    error.Message);
                            TWaitting.Instance.CloseWaitForm();
                            MSGHelp.Instance.ShowErrorMessage(error);

                            return;
                        }

                        int errCode = 0;
                        string errText = "";

                        try
                        {
                            TWaitting.Instance.ShowWaitForm("调用 WebService");
                            IList<IDataParameter> paramList = new List<IDataParameter>();
                            paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, 60010));
                            paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, 1));
                            paramList.Add(new IRAPProcParameter("@WSSLogID", DbType.Int64, logWait4Exec.LogID));
                            paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                            paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));

                            IRAPError error =
                                conn.CallProc("IRAP..ssp_BackgroundJob_WSRetry", ref paramList);
                            errCode = error.ErrCode;
                            errText = error.ErrText;

                            if (errCode != 0)
                            {
                                MSGHelp.Instance.ShowErrorMessage(errText);
                                return;
                            }
                        }
                        catch (Exception error)
                        {
                            error.Data["ErrCode"] = 999999;
                            error.Data["ErrText"] =
                                string.Format(
                                    "执行 IRAP..ssp_BackgroundJob_WSRetry 时发生异常：[{0}]",
                                    error.Message);
                            TWaitting.Instance.CloseWaitForm();
                            MSGHelp.Instance.ShowErrorMessage(error);

                            return;
                        }

                        try
                        {
                            TWaitting.Instance.ShowWaitForm("获取执行结果");

                            IList<TEntityCustomLog> datas =
                                conn.CallTableFunc<TEntityCustomLog>(
                                    string.Format(
                                        "SELECT TOP 1 * FROM IRAP..stb_Log_WebServiceShuttling " +
                                        "WHERE LinkedLogID={0} ORDER BY LogID DESC",
                                        logWait4Exec.LinkedLogID),
                                    new List<IDataParameter>());
                            if (datas.Count > 0)
                                logWait4Exec = datas[0];
                            else
                                logWait4Exec = null;

                            if (logWait4Exec != null)
                            {
                                if (logWait4Exec.ErrCode == 0)
                                {
                                    //MSGHelp.Instance.ShowNormalMessage("手工处理成功，稍后进行后续处理");
                                    AfterExecute(logWait4Exec);
                                }
                                else
                                    MSGHelp.Instance.ShowErrorMessage(
                                        logWait4Exec.ErrCode,
                                        logWait4Exec.ErrText);
                            }
                            else
                            {
                                MSGHelp.Instance.ShowErrorMessage("未获取到执行的结果");
                            }
                        }
                        catch (Exception error)
                        {
                            MSGHelp.Instance.ShowErrorMessage(error);
                        }
                    }
                }
            }
        }

        public void Delete()
        {
            string strSQL =
                "UPDATE IRAP..stb_Log_WebServiceShuttling " +
                "SET Retried=1 WHERE LogID=@LogID";
            IList<IDataParameter> paramList =
                new List<IDataParameter>();
            paramList.Add(new IRAPProcParameter("@LogID", DbType.Int32, LogID));

            try
            {
                using (IRAPSQLConnection conn =
                    new IRAPSQLConnection(SysParams.Instance.DBConnectionString))
                {
                    conn.Update(strSQL, paramList);
                }
            }
            catch (Exception error)
            {
                MSGHelp.Instance.ShowErrorMessage(error);
            }
        }
    }
}
