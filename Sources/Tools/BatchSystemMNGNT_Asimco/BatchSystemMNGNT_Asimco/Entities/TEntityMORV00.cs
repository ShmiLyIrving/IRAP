using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace BatchSystemMNGNT_Asimco.Entities
{
    public class TEntityMORV00 : TEntityCustomLog
    {
        public TEntityMORV00() { }

        public TEntityMORV00(TEntityCustomLog source) : this()
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
                    if (node.Attributes["Bin1"] != null)
                        binTo = node.Attributes["Bin1"].Value;
                    if (node.Attributes["ReceiptQuantity"] != null)
                        quantity = node.Attributes["ReceiptQuantity"].Value;
                    if (node.Attributes["MONumber"] != null)
                        orderNo = node.Attributes["MONumber"].Value;
                    if (node.Attributes["MOLineNumber"] != null)
                        orderLineNo = node.Attributes["MOLineNumber"].Value;
                }

                exchange.Add(IRAPXMLUtils.NodeToObject<TEntityXMLMORV00>(node));
            }
            catch { }
        }
    }
}
