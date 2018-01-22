using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using IRAPShared;

namespace BatchSystemMNGNT_Asimco.Entities
{
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

        public long LogID { get; set; }
        public int PartitioningKey { get; set; }
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

        protected virtual void AfterExecute() { }

        /// <summary>
        /// 处理当前的日志
        /// </summary>
        public void Do()
        {
            if (ShowEditorDialogs())
            {
                XtraMessageBox.Show(
                    (ExChange[0] as IXMLNodeObject).GetXMLString(),
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
