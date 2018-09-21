using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAPGeneralGateway.Entities
{
    public class TEntityDBConnection
    {
        public string DBType { get; set; }
        public string ConnectionString { get; set; }
        public bool Encrypt { get; set; }
    }
}
