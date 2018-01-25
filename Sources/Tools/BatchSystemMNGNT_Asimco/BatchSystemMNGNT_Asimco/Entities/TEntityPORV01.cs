using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data;

using IRAP.Global;
using IRAPShared;
using IRAPORM;

namespace BatchSystemMNGNT_Asimco.Entities
{
    public class TEntityPORV01 : TEntityCustomLog
    {
        public TEntityPORV01() { }

        public TEntityPORV01(TEntityCustomLog source) : this()
        {
            CopyFrom(source);
        }

        protected override void ResolveExchangeXML(string stringXML)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(stringXML);
                XmlNode node = xml.SelectSingleNode("Parameters/Param");
                if (node != null)
                {
                    if (node.Attributes["ItemNumber"] != null)
                        itemNumber = node.Attributes["ItemNumber"].Value;
                    if (node.Attributes["PONumber"] != null)
                        orderNo = node.Attributes["PONumber"].Value;
                    if (node.Attributes["POLineNumber"] != null)
                        orderLineNo = node.Attributes["POLineNumber"].Value;
                    if (node.Attributes["LotNumberDefault"] != null)
                        lotNumber = node.Attributes["LotNumberDefault"].Value;
                    if (node.Attributes["Bin1"] != null)
                        binTo = node.Attributes["Bin1"].Value;
                    if (node.Attributes["ReceiptQuantityMove1"] != null)
                        quantity = node.Attributes["ReceiptQuantityMove1"].Value;
                }

                exchange.Add(IRAPXMLUtils.NodeToObject<TEntityXMLPORV01>(node));
            }
            catch { }
        }

        protected override bool ShowEditorDialogs()
        {
            using (Editors.frmEditorPORV01 form =
                new Editors.frmEditorPORV01(this))
            {
                return form.ShowDialog() == DialogResult.OK;
            }
        }

        protected override void AfterExecute(TEntityCustomLog log)
        {
            if (log.ErrCode == 0 && log.Retried)
            {
                string[] splitString = log.ErrText.Split(',');
                string recvBatchNo = splitString[49];

                string strSQL =
                    "UPDATE IRAPRIMCS..utb_MaterialStore " +
                    "SET RecvBatchNo=@RecvBatchNo " +
                    "WHERE SKUID=@SKUID";
                IList<IDataParameter> paramList =
                    new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@RecvBatchNo", DbType.String, recvBatchNo));
                paramList.Add(new IRAPProcParameter("@SKUID", DbType.String, skuID));

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
                    MSGHelp.Instance.ShowErrorMessage(
                        string.Format(
                            "将SKUID[{0}]的RecvBatchNo更新为[{1}]的操作未成功，原因：[{2}]",
                            skuID,
                            recvBatchNo,
                            error.Message));
                }
            }
            else
            {
                MSGHelp.Instance.ShowErrorMessage(
                    string.Format(
                        "执行未成功，不能进行后续处理，结果：[{0}]",
                        log.ErrText));
            }
        }
    }
}
