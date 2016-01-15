using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Reflection;

namespace IRAP.DynamicLoad
{
    public class IRAPJsonSerializer
    {
        public static object Deserializer(string JsonString, Type targetType)
        {
            if (string.IsNullOrEmpty(JsonString))
                return null;

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonString)))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(targetType);
                object _result = serializer.ReadObject(ms);
                return _result;
            }
        }

        public static object Deserializer(string JsonString, string FullName)
        {
            if (string.IsNullOrEmpty(JsonString))
                return null;

            Type tt2 = GetEntityType(FullName);
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonString)))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(tt2);
                object _result = serializer.ReadObject(ms);
                return _result;
            }
        }

        public static object Deserializer(
            string JsonString, 
            string FullName, 
            IList<Type> knownTypes)
        {
            if (string.IsNullOrEmpty(JsonString))
                return null;

            Type tt2 = GetEntityType(FullName);
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonString)))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(tt2, knownTypes);
                object _result = serializer.ReadObject(ms);
                return _result;
            }
        }

        public static string Serializer<T>(T t1, IList<Type> knownTypes)
        {
            string szJson = "";

            DataContractJsonSerializer json =
                new DataContractJsonSerializer(t1.GetType(), knownTypes);
            using (MemoryStream ms = new MemoryStream())
            {
                json.WriteObject(ms, t1);
                szJson = Encoding.UTF8.GetString(ms.ToArray());
            }

            return szJson;
        }

        public static string Serializer<T>(T t1)
        {
            string szJson = "";

            DataContractJsonSerializer json =
                new DataContractJsonSerializer(t1.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                json.WriteObject(ms, t1);
                szJson = Encoding.UTF8.GetString(ms.ToArray());
            }

            return szJson;
        }

        private static Type GetEntityType(string FullName)
        {
            AppDomain _domain = AppDomain.CurrentDomain;
            Assembly[] _loadAssembly;

            _loadAssembly = _domain.GetAssemblies();
            Type tt2 = null;
            foreach (Assembly item in _loadAssembly)
            {
                tt2 = item.GetType(FullName);
                if (tt2 != null)
                    break;
            }
            return tt2;
        }
    }
}
