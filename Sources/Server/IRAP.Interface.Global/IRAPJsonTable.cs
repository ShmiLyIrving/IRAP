using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace IRAP.Interface.Global
{
    [DataContract()]
    [Serializable()]
    public class IRAPJsonTable
    {
        private string _key = "";
        private string _jsonContent = "";
        private string _fullName = "";

        public IRAPJsonTable(string key, string json, string fullName)
        {
            _key = key;
            _jsonContent = json;
            _fullName = fullName;
        }

        [DataMember()]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        [DataMember()]
        public string JsonContent
        {
            get { return _jsonContent; }
            set { _jsonContent = value; }
        }

        [DataMember()]
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
    }
}