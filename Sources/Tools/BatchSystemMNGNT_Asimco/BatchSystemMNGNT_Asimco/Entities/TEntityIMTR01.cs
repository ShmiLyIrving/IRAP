using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using IRAP.Global;

namespace BatchSystemMNGNT_Asimco.Entities
{
    public class TEntityIMTR01 : TEntityCustomLog
    {
        public TEntityIMTR01() { }

        public TEntityIMTR01(TEntityCustomLog source) : this()
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
                    if (node.Attributes["LotNumberFrom"] != null)
                        lotNumber = node.Attributes["LotNumberFrom"].Value;
                    if (node.Attributes["BinFrom"] != null)
                        binFrom = node.Attributes["BinFrom"].Value;
                    if (node.Attributes["BinTo"] != null)
                        binTo = node.Attributes["BinTo"].Value;
                    if (node.Attributes["InventoryQuantity"] != null)
                        quantity = node.Attributes["InventoryQuantity"].Value;

                    exchange.Add(IRAPXMLUtils.NodeToObject<TEntityXMLIMTR01>(node));
                }
            }
            catch { }
        }

        protected override bool ShowEditorDialogs()
        {
            using (Editors.frmEditorIMTR01 form =
                new Editors.frmEditorIMTR01(this))
            {
                return form.ShowDialog() == DialogResult.OK;
            }
        }
    }
}
