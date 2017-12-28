using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IRAPGeneralGateway.Entities
{
    public class TEntityResComm
    {
        [XmlAttribute()]
        public string ExCode { get; set; }
        [XmlAttribute()]
        public int ErrCode { get; set; }
        [XmlAttribute()]
        public string ErrText { get; set; }
    }
}
