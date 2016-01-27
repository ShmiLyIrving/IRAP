using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

namespace IRAP.WCF.Client
{
    public class JsonSerializer
    {
        public static List<T> ConvertList<T>(string json)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = 
                    new DataContractJsonSerializer(typeof(List<T>));
                List<T> _listResult = (List<T>)serializer.ReadObject(ms);
                return _listResult;
            }
        }

        public static T ConvertObject<T>(string json)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = 
                    new DataContractJsonSerializer(typeof(T));
                T _result = (T)serializer.ReadObject(ms);
                return _result;
            }
        }

        public static string ConvertJson<T>(T t1)
        {
            string szJson = "";
            DataContractJsonSerializer json = 
                new DataContractJsonSerializer(t1.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                json.WriteObject(ms, t1);
                szJson = Encoding.UTF8.GetString(ms.ToArray());
                return szJson;
            }
        }

        public static T ConvertObject<T>(string json, IList<Type> knownTypes)
        {
            if (string.IsNullOrEmpty(json))
                return default(T);

            using (MemoryStream ms=new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(T), knownTypes);
                T _result = (T)serializer.ReadObject(ms);
                return _result;
            }
        }
    }
}
