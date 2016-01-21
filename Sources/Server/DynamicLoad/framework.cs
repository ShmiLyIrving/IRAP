using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using IRAP.Interface.Global;
using IRAPShared;

namespace IRAP.DynamicLoad
{
    public class IRAPDevFramework
    {
        private static Dictionary<string, string> _assemblyList;
        private static AssemblyLoader _Loader = null;
        //private static List<Type> _typeList = new List<Type>();
        private static AssemblyLoader Loader
        {
            get
            {
                if (_Loader == null)
                {
                    _Loader = new AssemblyLoader();
                    //_Loader.LoadAssemblys(_assemblyList);
                }

                return _Loader;
            }
        }

        public static void LoadEntity()
        {
            string entityPath = AppDomain.CurrentDomain.BaseDirectory + "Entities";

            if (!Directory.Exists(entityPath))
            {
                Directory.CreateDirectory(entityPath);//创建新路径
            }

            //string[] fileList = Directory.GetFiles(entityPath, "*.dll");
            //foreach (string fileName in fileList)
            //{
            //    //Assembly myAssembly=Assembly.LoadFrom(fileName);
            //    string assemblyName = System.IO.Path.GetFileNameWithoutExtension(fileName);
            //    Assembly.Load(assemblyName);
            //    Console.WriteLine("加载:" + fileName);
            //}
        }

        public IRAPDevFramework()
        {
            if (_Loader == null)
            {
                // LoadEntity();
                _assemblyList = new Dictionary<string, string>();
                //ReadAssemblyXML();
            }
        }

        #region 调用程序集通用接口
        public object ExChange(string assemblyName, string className, string method,
            List<IRAPJsonTable> jsonTable, out string backType, out int errCode, out string errText)
        {

            try
            {
                if (!_assemblyList.ContainsKey(className))
                {
                    _assemblyList.Add(className, assemblyName);
                    Loader.LoadAssembly(assemblyName, className);
                }
                Hashtable dict = new Hashtable();
                //组装成为还有复杂类型的Hashtable
                foreach (IRAPJsonTable tableRow in jsonTable)
                {
                    object rowObj = IRAPJsonSerializer.Deserializer(tableRow.JsonContent, tableRow.FullName);
                    dict.Add(tableRow.Key, rowObj);
                }
                object[] obj = new object[] { dict, -1, string.Format("No Runing->{0}->{1}-{2}", assemblyName, className, method) };
                object result = Loader.InvokeMethod(assemblyName, className, method, obj, out errCode, out errText);
                if (result == null || result.GetType() == null)
                {
                    backType = "".GetType().FullName;
                    return IRAPJsonSerializer.Serializer("");
                }
                backType = result.GetType().FullName;

                return IRAPJsonSerializer.Serializer(result);
            }
            catch (Exception err)
            {
                _assemblyList.Remove(className);
                errCode = 999999;
                //errText = string.Format("调用程序集{0}->{1}异常：{2}", assemblyName, method, err.Message);
                errText = string.Format("调用程序集{0}->{1}异常：{2}", assemblyName, method, err.Message + "\n" + err.InnerException.Message);
                backType = "".GetType().FullName;
                return "";
            }
        }
        #endregion

        #region 调用程序集接口获取流
        public byte[] GetBinary(string assemblyName, string className, string method, Hashtable dict,
            out int errCode, out string errText)
        {
            try
            {
                if (!_assemblyList.ContainsKey(className))
                {
                    _assemblyList.Add(className, assemblyName);
                    Loader.LoadAssembly(assemblyName, className);
                }
                object[] obj = new object[] { dict, -1, 
            string.Format("No Runing->{0}->{1}-{2}" ,assemblyName, className,method ) };
                string backType = string.Empty;
                object result = Loader.InvokeMethod(assemblyName, className, method, obj, out errCode, out errText);
                backType = result.GetType().FullName;
                return (byte[])result;
            }
            catch (Exception err)
            {
                _assemblyList.Remove(className);
                errCode = 999999;
                errText = string.Format("调用程序集{0}->{1}异常：{2}", assemblyName, method, err.Message);
                return new byte[] { 0, 11, 33 };
            }
        }
        #endregion

        #region 调用程序集上传流
        public string UpLoadBinary(string assemblyName, string className, string method, byte[] upStream,
            out int errCode, out string errText)
        {
            try
            {
                if (!_assemblyList.ContainsKey(className))
                {
                    _assemblyList.Add(className, assemblyName);
                    Loader.LoadAssembly(assemblyName, className);
                }
                object[] obj = new object[] { upStream, -1, 
            string.Format("No Runing->{0}->{1}-{2}" ,assemblyName, className,method ) };
                string backType = string.Empty;
                object result = Loader.InvokeMethod(assemblyName, className, method, obj, out errCode, out errText);
                backType = result.GetType().FullName;
                return result.ToString();
            }
            catch (Exception err)
            {
                _assemblyList.Remove(className);
                errCode = 999999;
                errText = string.Format("调用程序集{0}->{1}异常：{2}", assemblyName, method, err.Message);
                return "";
            }

        }

        #endregion

        #region 根据配置文件加载实体类
        public static void ReadAssemblyXML()
        {
            XmlDocument _xmlDoc = new XmlDocument();

            string _assetXMLPath = AppDomain.CurrentDomain.BaseDirectory + @"IRAPEntitySet.xml";

            _xmlDoc.Load(_assetXMLPath);
            XmlElement xmlContent = _xmlDoc.DocumentElement;
            XmlNode rowNode = xmlContent.SelectSingleNode("/Assembly");

            foreach (XmlNode node in rowNode.ChildNodes)
            {
                string assemblyName = node.Attributes["AssemblyName"].Value;
                if (assemblyName != string.Empty)
                {
                    Assembly.Load(assemblyName);
                }
            }
        }

        #endregion

        #region "新接口可动态覆盖实体"
        public object ExChangeJson(string assemblyName, string className, string method,
          List<IRAPJsonTable> jsonTable, out string backType, out int errCode, out string errText)
        {

            try
            {
                if (!_assemblyList.ContainsKey(className))
                {
                    _assemblyList.Add(className, assemblyName);
                    Loader.LoadAssembly(assemblyName, className);
                }
                Dictionary<string, string[]> dict = new Dictionary<string, string[]>();
                //组装成为还有复杂类型的Hashtable
                foreach (IRAPJsonTable tableRow in jsonTable)
                {
                    dict.Add(tableRow.Key, new string[] { tableRow.JsonContent, tableRow.FullName });
                    //object rowObj = IRAPJsonSerializer.Deserializer(tableRow.JsonContent, tableRow.FullName);
                    //dict.Add(tableRow.Key, rowObj);
                }
                object[] obj = new object[] { dict, -1, string.Format("No Runing->{0}->{1}-{2}", assemblyName, className, method) };
                string[] result = (string[])Loader.InvokeMethod(assemblyName, className, method, obj, out errCode, out errText);

                backType = result[1];

                return result[0];
            }
            catch (Exception err)
            {
                _assemblyList.Remove(className);
                errCode = 999999;
               // errText = string.Format("调用程序集{0}->{1}异常：{2}", assemblyName, method, err.Message);
                errText = string.Format("调用程序集{0}->{1}异常：{2}", assemblyName, method, err.Message + "\n" + err.InnerException.Message);
                backType = "".GetType().FullName;
                return "";
            }
        }
        #endregion

        #region "新接口WCF RESTFul风格接口"
        public object WCFRESTful(string assemblyName, string className, string method,
          List<IRAPJsonTable> jsonTable,out int errCode, out string errText)
        {
            try
            {
                if (!_assemblyList.ContainsKey(className))
                {
                    _assemblyList.Add(className, assemblyName);
                    Loader.LoadAssembly(assemblyName, className);
                }
                Hashtable dict = new Hashtable();
                //组装成为还有复杂类型的Hashtable
                foreach (IRAPJsonTable tableRow in jsonTable)
                {

                    Type type = Type.GetType(tableRow.FullName);
                    if (type == null)
                    {
                        dict.Add(tableRow.Key, tableRow.JsonContent);
                        continue;
                    }

                    object srcObj = IRAPJsonSerializer.Deserializer(tableRow.JsonContent, tableRow.FullName);
                    dict.Add(tableRow.Key, srcObj.ToString());
                }
                object[] obj = new object[] { dict };
                object result = Loader.InvokeMethodEx(assemblyName, className, method, obj, out errCode, out errText);

                IRAPJsonResult res = result as IRAPJsonResult;
                //backType = res.TypeName;
                return res;
            }
            catch (Exception err)
            {
                _assemblyList.Remove(className);
                errCode = 999999;
                errText = string.Format("调用程序集{0}->{1}异常：{2}", assemblyName, method, err.Message+"\n"+err.InnerException.Message);
                //backType = "".GetType().FullName;
                return new IRAPJsonResult("", "".GetType().FullName);
            }
        }
        #endregion

        #region "新接口RESTFul风格接口"
        public object RESTful(string assemblyName, string className, string method,
           Hashtable jsonTable,out int errCode, out string errText)
        {
            try
            {
                if (!_assemblyList.ContainsKey(className))
                {
                    _assemblyList.Add(className, assemblyName);
                    Loader.LoadAssembly(assemblyName, className);
                }
                object[] obj = new object[] { jsonTable };
                object result = Loader.InvokeMethodEx(assemblyName, className, method, obj, out errCode, out errText);
                IRAPJsonResult res = result as IRAPJsonResult;
                //backType = res.TypeName;
                return res;
            }
            catch (Exception err)
            {
                _assemblyList.Remove(className);
                errCode = 999999;
                //errText = string.Format("调用程序集{0}->{1}异常：{2}", assemblyName, method, err.Message);
                errText = string.Format("调用程序集{0}->{1}异常：{2}", assemblyName, method, err.Message + "\n" + err.InnerException.Message);
                //backType = "".GetType().FullName;
                return new IRAPJsonResult("", "".GetType().FullName);
            }
        }
        #endregion
    }
}
