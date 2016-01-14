using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRAPShared.Json;
using System.Collections;

namespace IRAPShared
{
    public class IRAPBLLBase
    {
        public IRAPBLLBase()
        {

        }
        public string[] JsonArray(object obj)
        {
             // IRAPJsonSerializer.Serializer(obj), obj.GetType().FullName);
           return new string [] { IRAPJsonSerializer.Serializer(obj),obj.GetType().FullName };
        }
        public IRAPJsonResult Json(object obj)
        {
            IRAPJsonResult res = new IRAPJsonResult(IRAPJsonSerializer.Serializer(obj), obj.GetType().FullName);

            return res;
        }
         
        public Hashtable Resolve(Dictionary<string, string[]> paramList)
        {
            Hashtable dict = new Hashtable();
            //组装成为还有复杂类型的Hashtable
            foreach (KeyValuePair<string, string[]> tableRow in paramList)
            {
                object rowObj = IRAPJsonSerializer.Deserializer(tableRow.Value[0], tableRow.Value[1]);
                dict.Add(tableRow.Key, rowObj);
            }
            return dict;
        }
        public static object GetObj(IRAPJsonResult param)
        {
            object obj = IRAPJsonSerializer.Deserializer(param.Json, param.TypeName);

            return obj;
        }
    }

    [Serializable]
    public class IRAPJsonResult
    {
        private string _json = string.Empty;
        private string _typeName = string.Empty;
        private bool _zip = false;
        public IRAPJsonResult()
        {

        }
        public IRAPJsonResult(string json, string typeName)
        {
            _json = json;
            _typeName = typeName;
        }
        public string Json
        {
            get { return _json; }
            set { _json = value; }
        }
        public string TypeName
        {
            get { return _typeName; }

            set { _typeName = value; }
        }

        public bool IsZip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        public int ErrCode { get; set; }
        public string ErrText { get; set; }
        public override string ToString()
        {
            return _json;
        }
 
    }
}
