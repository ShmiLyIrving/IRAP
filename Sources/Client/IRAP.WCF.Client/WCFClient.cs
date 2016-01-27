using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.ServiceModel;

using IRAP.WCF.Client.IRAPWCFClient;

namespace IRAP.WCF.Client
{
    public class WCFClient : IDisposable
    {
        private static IList<Type> _knownTypes = new List<Type>();
        private string _wcfAddress = "";

        public WCFClient()
        {
            
        }

        public WCFClient(string wcfAddress) : this()
        {
            _wcfAddress = wcfAddress;
        }

        /// <summary>
        /// 根据程序集找类型
        /// </summary>
        public static Type FindType(string typeFullName)
        {
            Type tt2 = null;
            AppDomain _domain = AppDomain.CurrentDomain;
            Assembly[] _loadAssembly = _domain.GetAssemblies();

            foreach (Assembly item in _loadAssembly)
            {
                tt2 = item.GetType(typeFullName);
                if (tt2 != null)
                {
                    _knownTypes.Add(tt2);
                    break;
                }
            }

            return tt2;
        }

        /// <summary>
        /// WCF 通用接口，Json可实现覆盖实体
        /// </summary>
        public object WCFRESTFul(
            string assemblyName, 
            string className, 
            string methodName, 
            Hashtable paramDict, 
            out int errCode, 
            out string errText)
        {
            ServiceIRAPGlobalClient client = new ServiceIRAPGlobalClient();
            if (_wcfAddress != "")
                client.Endpoint.Address = new EndpointAddress(_wcfAddress);

            string backTypeName = "";
            string jsonContent = "";
            List<IRAPJsonTable> jsonTableList = new List<IRAPJsonTable>();

            #region 把 Hashtable 转换成 IRAPJsonTable 传输
            foreach (DictionaryEntry item in paramDict)
            {
                if (item.Value != null)
                {
                    IRAPJsonTable jsonTable = new IRAPJsonTable()
                    {
                        FullName = item.Value.GetType().FullName,
                        Key = item.Key.ToString(),
                    };
                    jsonTable.JsonContent =
                        IRAPJsonSerializer.Serializer(
                            item.Value,
                            jsonTable.FullName);

                    jsonTableList.Add(jsonTable);
                }
                else
                {
                    errCode = 99998;
                    errText = string.Format("字典属性：[{0}]值不能为空，请检查！",
                        item.Key.ToString());
                    return errText;
                }
            }
            #endregion

            try
            {
                errCode = client.WCFRESTful(
                    assemblyName,
                    className,
                    methodName,
                    jsonTableList,
                    ref jsonContent,
                    out backTypeName,
                    out errText);
            }
            finally
            {
                client.Close();
            }

            object d1 = IRAPJsonSerializer.Deserializer(jsonContent, backTypeName);
            return d1;
        }

        /// <summary>
        /// WCF 通用接口
        /// </summary>
        public object Exchange(string assemblyName, string className, string methodName, Hashtable paramDict, out int errCode, out string errText)
        {
            ServiceIRAPGlobalClient client = new ServiceIRAPGlobalClient();
            if (_wcfAddress != "")
                client.Endpoint.Address = new EndpointAddress(_wcfAddress);

            string backTypeName = "";
            string jsonContent = "";
            List<IRAPJsonTable> jsonTableList = new List<IRAPJsonTable>();

            #region 把 Hashtable 转换成 IRAPJsonTable 传输
            foreach (DictionaryEntry item in paramDict)
            {
                if (item.Value != null)
                {
                    IRAPJsonTable jsonTable = new IRAPJsonTable()
                    {
                        FullName = item.Value.GetType().FullName,
                        Key = item.Key.ToString(),
                    };
                    jsonTable.JsonContent =
                        IRAPJsonSerializer.Serializer(
                            item.Value,
                            jsonTable.FullName);

                    jsonTableList.Add(jsonTable);
                }
                else
                {
                    errCode = 99998;
                    errText = string.Format("字典属性：[{0}]值不能为空，请检查！",
                        item.Key.ToString());
                    return errText;
                }
            }
            #endregion

            try
            {
                errCode = client.ExChange(
                    assemblyName,
                    className,
                    methodName,
                    jsonTableList,
                    ref jsonContent,
                    out backTypeName,
                    out errText);
            }
            finally
            {
                client.Close();
            }

            object d1 = IRAPJsonSerializer.Deserializer(jsonContent, backTypeName);
            return d1;
        }

        /// <summary>
        /// 获取流数据
        /// </summary>
        public byte[] GetBinary(string assemblyName, string className, string methodName, Hashtable paramDict, out int errCode, out string errText)
        {
            ServiceIRAPGlobalClient client = new ServiceIRAPGlobalClient();
            byte[] result;

            try
            {
                result = client.GetBinary(
                    out errCode,
                    out errText,
                    assemblyName,
                    className,
                    methodName,
                    paramDict);
            }
            finally
            {
                client.Close();
            }

            return result;
        }

        /// <summary>
        /// 上传流的接口
        /// </summary>
        public string UploadBinary(
            string assemblyName, 
            string className, 
            string methodName, 
            byte[] binaryBytes, 
            out int errCode, 
            out string errText)
        {
            ServiceIRAPGlobalClient client = new ServiceIRAPGlobalClient();
            string result = "";

            try
            {
                result = client.UploadBinary(
                    out errCode, 
                    out errText, 
                    assemblyName, 
                    className, 
                    methodName, 
                    binaryBytes);
            }
            finally
            {
                client.Close();
            }

            return result;
        }

        public void Dispose()
        {
            
        }
    }
}
