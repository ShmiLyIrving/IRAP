using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Reflection;

namespace IRAP.WCF.Client
{
    public class IRAPJsonSerializer
    {
        private static Type GetEntityType(string fullName)
        {
            AppDomain _domain = AppDomain.CurrentDomain;
            Assembly[] _loadAssembly;
            _loadAssembly = _domain.GetAssemblies();
            Type tt2 = null;
            foreach (Assembly item in _loadAssembly)
            {
                tt2 = item.GetType(fullName);
                if (tt2 != null)
                    break;
            }
            return tt2;
        }

        public static object Deserializer(string jsonString, Type targetType)
        {
            if (string.IsNullOrEmpty(jsonString))
                return null;

            // 获取指定名称的类型
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(targetType);
                object _result = serializer.ReadObject(ms);
                return _result;
            }
        }

        public static object Deserializer(string jsonString, string fullName)
        {
            if (string.IsNullOrEmpty(jsonString))
                return null;

            // 获取指定名称的类型
            Type tt2 = GetEntityType(fullName);
            using (MemoryStream ms=new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(tt2);
                object _result = serializer.ReadObject(ms);
                return _result;
            }
        }

        public static object Deserializer(string jsonString, string fullName, IList<Type> knownTypes)
        {
            if (string.IsNullOrEmpty(jsonString))
                return null;

            // 获取指定名称的类型
            Type tt2 = GetEntityType(fullName);
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
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
            DataContractJsonSerializer serializer =
                new DataContractJsonSerializer(t1.GetType(), knownTypes);
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, t1);
                szJson = Encoding.UTF8.GetString(ms.ToArray());
            }
            return szJson;
        }

        public static string Serializer<T>(T t1)
        {
            string szJson = "";
            DataContractJsonSerializer serializer =
                new DataContractJsonSerializer(t1.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, t1);
                szJson = Encoding.UTF8.GetString(ms.ToArray());
            }
            return szJson;
        }

        public static string Serializer<T>(T t1, string fullName)
        {
            Type t2 = GetEntityType(fullName);
            string szJson = "";
            DataContractJsonSerializer serializer =
                new DataContractJsonSerializer(t2);
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, t1);
                szJson = Encoding.UTF8.GetString(ms.ToArray());
            }
            return szJson;
        }
    }
}
