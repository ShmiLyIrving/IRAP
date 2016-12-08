using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Drawing.Printing;
using System.Data;

using FastReport;
using FastReport.Data;

using IRAP.Global;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class PrintWithFastReportAction : 
        CustomAction, IUDFAction
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private Report report = new Report();
        private List<TemplateData> datas = new List<TemplateData>();
        private string dataSource = "";
        private string sqlCmd = "";

        public PrintWithFastReportAction(
            XmlNode actionParams,
            ExtendEventHandler extendAction) :
            base(actionParams, extendAction)
        {
            if (actionParams.Attributes["DataSource"] == null)
            {
                dataSource = "CUSTOM";
            }
            else
            {
                dataSource = actionParams.Attributes["DataSource"].Value.ToUpper();
            }

            XmlNode child = null;
            switch (dataSource)
            {
                case "CUSTOM":
                    child = actionParams.FirstChild;
                    while (child != null)
                    {
                        if (child.NodeType == XmlNodeType.CDATA)
                        {
                            report.LoadFromString(child.Value);
                        }
                        else if (child.Name.ToUpper() == "ROW")
                        {
                            datas.Add(
                                new TemplateData()
                                {
                                    Cnt = GetAttributeIntValue(child, "Cnt", 1),
                                    SendAddress = GetAttributeStringValue(child, "SendAddress"),
                                    CustomerCode = GetAttributeStringValue(child, "CustomerCode"),
                                    CustomerName = GetAttributeStringValue(child, "CustomerName"),
                                    ReceiveAddress = GetAttributeStringValue(child, "ReceiveAddress"),
                                    CustomerPartNumber = GetAttributeStringValue(child, "CustomerPartNumber"),
                                    SupplierPartNumber = GetAttributeStringValue(child, "SupplierPartNumber"),
                                    PartName = GetAttributeStringValue(child, "PartName"),
                                    Quantity = GetAttributeStringValue(child, "Quantity"),
                                    ContainerNo = GetAttributeStringValue(child, "ContainerNo"),
                                    ProductDate = GetAttributeStringValue(child, "ProductDate"),
                                    CustomerSN = GetAttributeStringValue(child, "CustomerSN"),
                                    SupplierCode = GetAttributeStringValue(child, "SupplierCode"),
                                });
                        }

                        child = child.NextSibling;
                    }
                    break;
                case "SQLCOMMAND":
                    child = actionParams.FirstChild;
                    while (child != null)
                    {
                        if (child.NodeType == XmlNodeType.CDATA)
                        {
                            report.LoadFromString(child.Value);
                        }
                        else if (child.Name.ToUpper() == "SQLCOMMAND")
                        {
                            if (child.Attributes["command"] != null)
                            {
                                sqlCmd = child.Attributes["command"].Value;
                            }
                        }

                        child = child.NextSibling;
                    }
                    break;
            }          

            report.PrintSettings.ShowDialog = false;
        }

        private string GetAttributeStringValue(XmlNode node, string attrName)
        {
            if (node == null)
                return "";
            if (node.Attributes[attrName] == null)
                return "";
            else
                return node.Attributes[attrName].Value;
        }

        private int GetAttributeIntValue(XmlNode node, string attrName, int defaultValue)
        {
            if (node == null)
                return defaultValue;
            if (node.Attributes[attrName] == null)
                return defaultValue;
            else
                try { return Convert.ToInt32(node.Attributes[attrName].Value); }
                catch { return defaultValue; }
        }

        private void SetReportParamValue(
            Report report, 
            string paramName,
            string paramValue)
        {
            if (report.Parameters.FindByName(paramName) != null)
                report.Parameters.FindByName(paramName).Value = paramValue;
        }

        public void DoAction()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                PrinterSettings prntSettings = null;

                WriteLog.Instance.Write("开始打印标签......", strProcedureName);
                switch (dataSource)
                {
                    case "CUSTOM":
                        #region 定制格式数据源打印
                        for (int i = 0; i < datas.Count; i++)
                        {
                            SetReportParamValue(report, "SendAddress", datas[i].SendAddress);
                            SetReportParamValue(report, "CustomerCode", datas[i].CustomerCode);
                            SetReportParamValue(report, "CustomerName", datas[i].CustomerName);
                            SetReportParamValue(report, "ReceiveAddress", datas[i].ReceiveAddress);
                            SetReportParamValue(report, "CustomerPartNumber", datas[i].CustomerPartNumber);
                            SetReportParamValue(report, "SupplierPartNumber", datas[i].SupplierPartNumber);
                            SetReportParamValue(report, "PartName", datas[i].PartName);
                            SetReportParamValue(report, "Quantity", datas[i].Quantity);
                            SetReportParamValue(report, "ContainerNo", datas[i].ContainerNo);
                            SetReportParamValue(report, "ProductDate", datas[i].ProductDate);
                            SetReportParamValue(report, "CustomerSN", datas[i].CustomerSN);
                            SetReportParamValue(report, "SupplierCode", datas[i].SupplierCode);

                            if (report.Prepare())
                            {
                                if (prntSettings == null)
                                {
                                    prntSettings = new PrinterSettings();
                                    //report.ShowPrintDialog(out prntSettings);
                                }

                                for (int j = 1; j <= datas[i].Cnt; j++)
                                {
                                    WriteLog.Instance.Write(
                                        string.Format("正在打印第{0}个标签的第{1}份拷贝。", i, j),
                                        strProcedureName);
                                    report.PrintPrepared(prntSettings);
                                }
                            }
                        }
                        #endregion
                        break;
                    case "SQLCOMMAND":
                        #region 表数据源打印
                        if (sqlCmd == "")
                        {
                            IRAPMessageBox.Instance.ShowErrorMessage(
                                "没有设置行动数据源，无法执行！",
                                "系统提示");
                            return;
                        }

                        int errCode = 0;
                        string errText = "";
                        DataTable dt = new DataTable();
                        IRAPUTSClient.Instance.GetDataTableWithSQL(
                            sqlCmd,
                            ref dt,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            string.Format("[{0}]{1}", errCode, errText),
                            strProcedureName);

                        DataSet ds = new DataSet();
                        dt.TableName = "DataSource";
                        ds.Tables.Add(dt);
                        report.RegisterData(ds);
                        if (report.Prepare())
                        {
                            //if (prntSettings == null)
                            //{
                            //    prntSettings = new PrinterSettings();
                            //    report.ShowPrintDialog(out prntSettings);
                            //}

                            //report.PrintPrepared(prntSettings);
                            report.PrintPrepared();
                        }
                        #endregion
                        break;
                }
                WriteLog.Instance.Write("标签打印结束。", strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }

    public class PrintWithFastReportFactory : 
        CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(
            XmlNode actionParams, 
            ExtendEventHandler extendAction)
        {
            return new PrintWithFastReportAction(
                actionParams, 
                extendAction);
        }
    }

    internal class TemplateData
    {
        /// <summary>
        /// 打印的份数
        /// </summary>
        public int Cnt { get; set; }
        /// <summary>
        /// 发货地址
        /// </summary>
        public string SendAddress { get; set; }
        /// <summary>
        /// 客户代码
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string ReceiveAddress { get; set; }
        /// <summary>
        /// 客户零件号
        /// </summary>
        public string CustomerPartNumber { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string SupplierCode { get; set; }
        /// <summary>
        /// 供应商零件号
        /// </summary>
        public string SupplierPartNumber { get; set; }
        /// <summary>
        /// 零件名称
        /// </summary>
        public string PartName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string Quantity { get; set; }
        /// <summary>
        /// 托盘号
        /// </summary>
        public string ContainerNo { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public string ProductDate { get; set; }
        /// <summary>
        /// 客户序列号
        /// </summary>
        public string CustomerSN { get; set; }

        public TemplateData Clone()
        {
            return MemberwiseClone() as TemplateData;
        }
    }
}