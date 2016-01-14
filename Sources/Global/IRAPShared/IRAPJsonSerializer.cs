using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;

namespace IRAPShared.Json
{
    class JsonSerializer
    {
        public static List<T> ConvertList<T>(string json )
        {
            //反序列化
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<T>));
                List<T> _listResult = (List<T>)serializer.ReadObject(ms);
                return _listResult;
            }
        }

        public static T ConvertObject<T>(string json)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                T _result =(T)serializer.ReadObject(ms);
                return _result;
            }
        }

        public static string ConvertJson<T>(T t1)
        {
            string szJson = string.Empty;
            DataContractJsonSerializer json = new DataContractJsonSerializer(t1.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, t1);
                szJson = Encoding.UTF8.GetString(stream.ToArray());    
            }
            return szJson;
        }

       public static T ConvertObject<T>(string json, IList<Type> konwnTypes)
        {
            if (string.IsNullOrEmpty(json)) return default(T);
        
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(T),  konwnTypes);
                T _result =(T)serializer.ReadObject(ms);
                return _result;
            }
        }
    }

   public class IRAPJsonSerializer
    {
       public static object Deserializer(string JsonString, Type targetType)
       {
           if (string.IsNullOrEmpty(JsonString)) return null;
           //获取指定名称的类型
           using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonString)))
           {
               DataContractJsonSerializer serializer =
                   new DataContractJsonSerializer(targetType);
               object _result = serializer.ReadObject(ms);
               return _result;
           }
       }
        public static object Deserializer(string JsonString,string FullName)
        {
            if (string.IsNullOrEmpty(JsonString)) return null;
            //获取指定名称的类型
            System.Type tt2 = GetEntityType(FullName);

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonString)))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer( tt2);
                object _result = serializer.ReadObject(ms);
                return _result;
            }
        }
        public static object Deserializer(string JsonString, string FullName, IList<Type> konwnTypes)
        {
            if (string.IsNullOrEmpty(JsonString)) return null;
            //获取指定名称的类型
            System.Type tt2 = GetEntityType(FullName);
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonString)))
            {
                DataContractJsonSerializer serializer =new DataContractJsonSerializer(tt2, konwnTypes);
                object _result = serializer.ReadObject(ms);
                return _result;
            }
        }
      
        public static string Serializer<T>(T t1,IList<Type> konwnTypes )
        {
            string szJson = string.Empty;
            DataContractJsonSerializer json = new DataContractJsonSerializer(t1.GetType(), konwnTypes);
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, t1);
                szJson = Encoding.UTF8.GetString(stream.ToArray());
            }
            return szJson;
        }

        public static string Serializer<T>(T t1)
        {
            string szJson = string.Empty;
            DataContractJsonSerializer json = new DataContractJsonSerializer(t1.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, t1);
                szJson = Encoding.UTF8.GetString(stream.ToArray());
            }
            return szJson;
        }


        private static Type GetEntityType(string FullName)
        {
            System.AppDomain _Domain = System.AppDomain.CurrentDomain;
            Assembly[] _LoadAssembly;
            _LoadAssembly = _Domain.GetAssemblies();
            System.Type tt2 = null;
            foreach (Assembly item in _LoadAssembly)
            {
                tt2 = item.GetType(FullName);
                if (tt2 != null)
                {
                    break;
                }
            }
            return tt2;
        }
    
    }
}
