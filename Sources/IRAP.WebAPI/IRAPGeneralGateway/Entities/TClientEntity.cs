using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAPGeneralGateway.Entities
{
    public class TClientEntity
    {
        public string ClientID { get; set; }
        public string ApplicationName { get; set; }
        public string Encrypt_Key { get; set; }
        public string AuthLibrary { get; set; }
        public int SecurityLevel { get; set; }
    }
}
