using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using IRAP.Global;

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
    }
}
