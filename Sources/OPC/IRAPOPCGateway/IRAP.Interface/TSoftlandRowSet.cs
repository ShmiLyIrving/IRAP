using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface
{
    public class TSoftlandRowSet
    {
        public virtual XmlNode GenerateXMLNode(XmlNode node)
        {
            return IRAPXMLUtils.GenerateXMLAttribute(node, this); 
        }
    }
}