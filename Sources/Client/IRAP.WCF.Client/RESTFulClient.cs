using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

using IRAPShared;

namespace IRAP.WCF.Client
{
    public class RESTFulClient
    {
        public static object PostWithDict(
            string dllName,
            string className,
            string methodName,
            Hashtable dict,
            out int errCode,
            out string errText)
        {
            if (!dict.ContainsKey("DllName"))
                dict.Add("DllName", dllName);
            if (!dict.ContainsKey("ClassName"))
                dict.Add("ClassName", className);
            if (!dict.ContainsKey("MethodName"))
                dict.Add("MethodName", methodName);

            Dictionary<string, object> trueDict = new Dictionary<string, object>();
            foreach (DictionaryEntry item in dict)
            {
                trueDict.Add(item.Key.ToString(), item.Value);
            }

            IRAPJsonResult res = HttpClientUtil.doPostWidthDict<IRAPJsonResult>("RESTful", trueDict);
            errCode = res.ErrCode;
            errText = res.ErrText;

            return IRAPJsonSerializer.Deserializer(res.Json, res.TypeName);
        }

        public static object PostWithClass(
            string dllName,
            string className,
            string methodName,
            object anonymousClass,
            out int errCode,
            out string errText)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (PropertyInfo pi in anonymousClass.GetType().GetProperties())
            {
                bool isClass = false;
                if (pi.PropertyType.Equals(typeof(string)) ||
                    pi.PropertyType.IsInterface &&
                    pi.PropertyType.IsClass)
                {
                    isClass = false;
                }
                else if (pi.PropertyType.IsClass)
                {
                    isClass = true;
                }
                
                if (isClass)
                {
                    object obj = pi.GetValue(anonymousClass, null);
                    string json = IRAPJsonSerializer.Serializer(obj);
                    dict.Add(pi.Name, json);
                }
                else
                {
                    dict.Add(pi.Name, pi.GetValue(anonymousClass, null));
                }
            }

            if (!dict.ContainsKey("DllName"))
                dict.Add("DllName", dllName);
            if (!dict.ContainsKey("ClassName"))
                dict.Add("ClassName", className);
            if (!dict.ContainsKey("MethodName"))
                dict.Add("MethodName", methodName);

            IRAPJsonResult res = HttpClientUtil.doPostWidthDict<IRAPJsonResult>("RESTful", dict);
            errCode = res.ErrCode;
            errText = res.ErrText;

            return IRAPJsonSerializer.Deserializer(res.Json, res.TypeName);
        }
    }
}
