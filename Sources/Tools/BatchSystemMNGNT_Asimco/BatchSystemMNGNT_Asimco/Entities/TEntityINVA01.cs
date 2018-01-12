using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace BatchSystemMNGNT_Asimco.Entities
{
    public class TEntityINVA01 : TEntityCustomLog
    {
        public TEntityINVA01() { }

        public TEntityINVA01(TEntityCustomLog source) : this()
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
                    if (node.Attributes["LotNumber"] != null)
                        lotNumber = node.Attributes["LotNumber"].Value;
                    if (node.Attributes["Bin"] != null)
                        binFrom = node.Attributes["Bin"].Value;
                    if (node.Attributes["ActionCode"] != null)
                        quantity = node.Attributes["ActionCode"].Value;
                    if (node.Attributes["AdjustQuantity"] != null)
                        quantity += node.Attributes["AdjustQuantity"].Value;
                }

                exchange.Add(IRAPXMLUtils.NodeToObject<TEntityXMLINVA01>(node));
            }
            catch { }
        }
    }
}
