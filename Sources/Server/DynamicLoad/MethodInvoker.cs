using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace IRAP.DynamicLoad
{
    //方法调用器
    /// <summary>
    /// 方法调用器
    /// </summary>
    public class MethodInvoker : MarshalByRefObject,IDisposable
    {
        //程序集名称
        private readonly string _DllName;
        //程序集中的类类型全名
        private readonly string _TypeName;
        Type tp = null;
        //方法信息缓存列表
        private readonly Dictionary<string, MethodInfo> _Methods = 
            new Dictionary<string, MethodInfo>();
        //程序集中的类类型实例
        private object _TypeInstance;

        //构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="typeName"></param>
        public MethodInvoker(string dllName, string typeName)
        {
            this._DllName = dllName;
            this._TypeName = typeName;
        }

        //加载程序集中的所有方法
        /// <summary>
        /// 加载程序集中的所有方法
        /// </summary>
        public void LoadAllMethods()
        {
            Assembly assembly = Assembly.LoadFrom(_DllName);
            if (assembly == null)
                throw new Exception("Can't find " + _DllName);
             tp = assembly.GetType(_TypeName);
            if (tp == null)
                throw new Exception("Can't get type " + _TypeName + " from " + _DllName);
            _TypeInstance = Activator.CreateInstance(tp);
            if (_TypeInstance == null)
                throw new Exception("Can't construct type " + _TypeName + " from " + _DllName);

            MethodInfo[] typeMethod;

            if (_Methods.Count == 0)
            {
                typeMethod = tp.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

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

        //调用程序集中的指定方法
        /// <summary>
        /// 调用程序集中的指定方法
        /// </summary>
        /// <param name="methodName">方法名称</param>
        /// <param name="methodParams">参数数组</param>
        /// <returns></returns>
        public object InvokeMethod(string methodName, object[] methodParams, out int errCode,
            out string errText )
        {
            MethodInfo method;
            if (string.IsNullOrEmpty(methodName))
                throw new Exception("Method Name IsNullOrEmpty");

            _Methods.TryGetValue(methodName, out method);

            if (method == null)
                throw new Exception("Method can not be found");

            //object result = method.Invoke(_TypeInstance, methodParams);
             //  method.Invoke(_TypeInstance, BindingFlags.InvokeMethod, null, methodParams, null);

            object result = tp.InvokeMember(methodName,
                BindingFlags.Default | BindingFlags.InvokeMethod, null, _TypeInstance, methodParams);

           // backType = methodParams[methodParams.Length - 3].ToString();
            errCode = int.Parse(methodParams[methodParams.Length - 2].ToString());
            errText = methodParams[methodParams.Length - 1].ToString();
            //这里可以对result进行包装
            return result;
        }


        public object InvokeMethodEx(string methodName, object[] methodParams, out int errCode,
         out string errText)
        {
            MethodInfo method;
            if (string.IsNullOrEmpty(methodName))
                throw new Exception("Method Name IsNullOrEmpty");

            _Methods.TryGetValue(methodName, out method);

            if (method == null)
                throw new Exception("Method can not be found");
            Hashtable dict = methodParams[0] as Hashtable;
            //Dictionary<string, string> dict = methodParams[0] as Dictionary<string, string>;
            ParameterInfo[] paramsInfo = method.GetParameters();//得到指定方法的参数列表  
            //真正的参数类型
            object[] trueParams = new object[paramsInfo.Length];
            int i = 0;
            int errCodeIndex = -1;
            int errTextIndex = -1;
            foreach (ParameterInfo paramItem in paramsInfo)
            {
                if (paramItem.IsOut)
                {
                    if (paramItem.Name == "errCode")
                    {
                        errCodeIndex = i;
                    }
                    if (paramItem.Name == "errText")
                    {
                        errTextIndex = i;
                    }
                    i++;
                    continue;
                }
                Type tType = paramItem.ParameterType;
                bool isJson = false;
                if (tType.Equals(typeof(string)) || (!tType.IsInterface && !tType.IsClass))
                {
                    isJson = false;
                }
                else if (tType.IsClass)
                {
                    isJson = true;
                }
                foreach (DictionaryEntry item in dict)
                {
                    if (item.Key.ToString() == paramItem.Name)
                    {
                        try
                        {
                            if (!isJson)
                            {
                                trueParams[i] = Convert.ChangeType(item.Value, tType);
                            }
                            else
                            {
                                object targetObj = IRAPJsonSerializer.Deserializer(item.Value.ToString(),
                                   tType);
                                trueParams[i] = Convert.ChangeType(targetObj, tType);
                            }
                        }
                        catch (Exception err)
                        {
                            errCode = 9999;
                            errText ="方法："+methodName+"中参数：" + paramItem.Name + " 赋值时转换失败：" + err.Message;
                            return null;
                        }
                        // i++;
                    }
                }
                if (trueParams[i] == null )
                {
                    errCode = 9999;
                    errText = "方法：" + methodName + "中参数：" + paramItem.Name + "没有赋值！不能为NULL哦。";
                    return null;
                }
                i++;
            }

            object result = tp.InvokeMember(methodName,
              BindingFlags.Default | BindingFlags.InvokeMethod, null, _TypeInstance, trueParams);
            errCode = 0;
            errText = "调用" + methodName + "成功！";
            if (errCodeIndex > -1)
            {
                errCode = int.Parse(trueParams[errCodeIndex].ToString());
            }

            if (errTextIndex > -1)
            {
                errText = trueParams[errTextIndex].ToString();
            }
            //这里可以对result进行包装
            return result;
        }

        #region IDisposable 成员
        public void Dispose()
        {
            _TypeInstance = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect(0);
        }
        #endregion
    }
}
