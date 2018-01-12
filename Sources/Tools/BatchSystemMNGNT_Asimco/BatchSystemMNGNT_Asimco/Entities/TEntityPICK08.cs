using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace BatchSystemMNGNT_Asimco.Entities
{
    public class TEntityPICK08 : TEntityCustomLog
    {
        public TEntityPICK08() { }

        public TEntityPICK08(TEntityCustomLog source) : this()
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
                    if (node.Attributes["IssuedQuantity"] != null)
                        quantity = node.Attributes["IssuedQuantity"].Value;
                    if (node.Attributes["OrderNumber"] != null)
                        orderNo = node.Attributes["OrderNumber"].Value;
                    if (node.Attributes["LineNumber"] != null)
                        orderLineNo = node.Attributes["LineNumber"].Value;
                }

                exchange.Add(IRAPXMLUtils.NodeToObject<TEntityXMLPICK08>(node));
            }
            catch { }
        }
    }
}
