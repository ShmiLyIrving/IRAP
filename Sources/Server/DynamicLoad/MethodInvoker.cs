using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

namespace IRAP.DynamicLoad
{
    /// <summary>
    /// 方法调用器
    /// </summary>
    public class MethodInvoker : MarshalByRefObject, IDisposable
    {
        // 程序集名称
        private readonly string _DllName;
        // 程序集中的类类型全名
        private readonly string _TypeName;
        Type tp = null;
        // 方法信息缓存列表
        private readonly Dictionary<string, MethodInfo> _Methods =
            new Dictionary<string, MethodInfo>();
        // 程序集中的类类型实例
        private object _TypeInstance;

        public MethodInvoker(string dllName, string typeName)
        {
            _DllName = dllName;
            _TypeName = typeName;
        }

        /// <summary>
        /// 加载程序集中的所有方法
        /// </summary>
        public void LoadAllMethods()
        {
            Assembly assembly = Assembly.LoadFrom(_DllName);
            if (assembly == null)
                throw new Exception(string.Format("无法找到程序集[{0}]！", _DllName));
            tp = assembly.GetType(_TypeName);
            if (tp == null)
                throw new Exception(
                    string.Format(
                        "在程序集[{0}]中没有找到[{1}]类", 
                        _TypeName, 
                        _DllName));
            _TypeInstance = Activator.CreateInstance(tp);
            if (_TypeInstance == null)
                throw new Exception(
                    string.Format(
                        "无法创建[{0}]程序集中[{1}]类的实例",
                        _DllName,
                        _TypeName));

            MethodInfo[] typeMethod;

            if (_Methods.Count == 0)
            {
                typeMethod = tp.GetMethods(
                    BindingFlags.DeclaredOnly |
                    BindingFlags.Public |
                    BindingFlags.Instance);

                for (int i = 0; i < typeMethod.Length; i++)
                {
                    if (typeMethod[i].DeclaringType != typeof(object))
                    {
                        MethodInfo method;
                        if (!_Methods.TryGetValue(typeMethod[i].Name, out method))
                            _Methods.Add(typeMethod[i].Name, typeMethod[i]);
                    }
                }
            }
        }

        /// <summary>
        /// 调用程序集中的指定方法
        /// </summary>
        /// <param name="methodName">方法名称</param>
        /// <param name="methodParams">参数数组</param>
        public object InvokeMethod(
            string methodName,
            object[] methodParams,
            out int errCode,
            out string errText)
        {
            MethodInfo method;
            if (string.IsNullOrEmpty(methodName))
                throw new Exception("方法名称不能空白！");

            _Methods.TryGetValue(methodName, out method);

            if (method == null)
                throw new Exception(
                    string.Format(
                        "没有找到[{0}]方法！",
                        methodName));

            object result = tp.InvokeMember(
                methodName,
                BindingFlags.Default | BindingFlags.InvokeMethod,
                null,
                _TypeInstance,
                methodParams);

            errCode = int.Parse(methodParams[methodParams.Length - 2].ToString());
            errText = methodParams[methodParams.Length - 1].ToString();

            return result;
        }

        public object InvokeMethodEx(
            string methodName,
            object[] methodPararms,
            out int errCode,
            out string errText)
        {
            MethodInfo method;
            if (string.IsNullOrEmpty(methodName))
                throw new Exception("方法名称不能空白！");

            _Methods.TryGetValue(methodName, out method);

            if (method == null)
                throw new Exception(
                    string.Format(
                        "没有找到[{0}]方法！",
                        methodName));

            Hashtable dict = methodPararms[0] as Hashtable;
            // 得到指定方法的参数列表
            ParameterInfo[] paramsInfo = method.GetParameters();
            // 真正的参数类型
            object[] trueParams = new object[paramsInfo.Length];

            int i = 0;
            int errCodeIndex = -1;
            int errTextIndex = -1;
            foreach (ParameterInfo paramItem in paramsInfo)
            {
                if (paramItem.IsOut)
                {
                    if (paramItem.Name.ToUpper() == "ERRCODE")
                        errCodeIndex = i;
                    if (paramItem.Name.ToUpper() == "ERRTEXT")
                        errTextIndex = i;

                    i++;
                    continue;
                }

                Type tType = paramItem.ParameterType;
                bool isJson = false;
                if (tType.Equals(typeof(string)) || (!tType.IsInterface && !tType.IsClass))
                    isJson = false;
                else if (tType.IsClass)
                    isJson = true;

                foreach (DictionaryEntry item in dict)
                {
                    if (item.Key.ToString() == paramItem.Name)
                    {
                        try
                        {
                            if (!isJson)
                                trueParams[i] = Convert.ChangeType(item.Value, tType);
                            else
                            {
                                object targetObj = IRAPJsonSerializer.Deserializer(
                                    item.Value.ToString(),
                                    tType);
                                trueParams[i] = Convert.ChangeType(targetObj, tType);
                            }
                        }
                        catch (Exception error)
                        {
                            errCode = 9999;
                            errText = string.Format("方法[{0}]中参数[{1}]在赋值时转换类型失败：{2}",
                                methodName,
                                paramItem.Name,
                                error.Message);
                            return null;
                        }
                    }
                }

                if (trueParams[i]==null)
                {
                    errCode = 9999;
                    errText = string.Format("方法[{0}]中参数[{1}]没有赋值！不能为 NULL 哦:)",
                        methodName,
                        paramItem.Name);
                    return null;
                }

                i++;
            }

            object result = tp.InvokeMember(
                methodName,
                BindingFlags.Default | BindingFlags.InvokeMethod,
                null,
                _TypeInstance,
                trueParams);
            errCode = 0;
            errText = string.Format("调用方法[{0}]成功！", methodName);
            if (errCodeIndex >= 0)
                errCode = int.Parse(trueParams[errCodeIndex].ToString());
            if (errTextIndex >= 0)
                errText = trueParams[errTextIndex].ToString();

            return result;
        }

        public void Dispose()
        {
            _TypeInstance = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect(0);
        }
    }
}
