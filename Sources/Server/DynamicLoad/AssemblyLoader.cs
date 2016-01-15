using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.Remoting.Lifetime;
using System.Reflection;
using System.Globalization;

namespace IRAP.DynamicLoad
{
    public class AssemblyLoader : MarshalByRefObject, IDisposable
    {
        private readonly object _lockThis = new object();
        private Dictionary<string, Queue<InvokerInfo>> _caches =
            new Dictionary<string, Queue<InvokerInfo>>();

        /// <summary>
        /// 加载所有可用的程序集
        /// </summary>
        /// <param name="dlls"></param>
        public void LoadAssemblys(Dictionary<string, string> dlls)
        {
            foreach(KeyValuePair<string, string> kvp in dlls)
            {
                Queue<InvokerInfo> result;
                _caches.TryGetValue(kvp.Value, out result);
                if (result == null)
                    LoadAssembly(kvp.Value, kvp.Key);
            }
        }

        /// <summary>
        /// 卸载程序集
        /// </summary>
        /// <param name="typeName"></param>
        public void Unload(string typeName)
        {
            AppDomain domain = null;
            while (_caches[typeName].Count !=0)
            {
                InvokerInfo info = _caches[typeName].Dequeue();
                domain = info.Domain;
            }

            if (domain != null)
                AppDomain.Unload(domain);
        }

        /// <summary>
        /// 调用指定程序集中的指定方法
        /// </summary>
        /// <param name="dllName">程序集名称</param>
        /// <param name="className">类名称</param>
        /// <param name="methodName">方法名称</param>
        /// <param name="methodParams">参数数组</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public object InvokeMethod(
            string dllName,
            string className,
            string methodName,
            object[] methodParams,
            out int errCode,
            out string errText)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            object result;
            InvokerInfo info;
            lock(_lockThis)
            {
                info = GetInvoker(dllName, className);
                info.Ref++;
            }

            try
            {
                result = info.Invoker.InvokeMethod(
                    methodName,
                    methodParams,
                    out errCode,
                    out errText);
                stopwatch.Stop();

                TimeSpan timespan = stopwatch.Elapsed;
                Console.WriteLine(
                    string.Format("{0}:<{1}>{2}->{3}->耗时(ms):{4}",
                        DateTime.Now.ToString(),
                        info.Ref.ToString(),
                        dllName,
                        methodName,
                        timespan.TotalMilliseconds.ToString()));
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                lock (_lockThis)
                {
                    info.Ref--;
                    TryToUnload(dllName, className, info);
                }
            }

            return result;
        }

        public object InvokeMethodEx(
            string dllName,
            string className,
            string methodName,
            object[] methodParams,
            out int errCode,
            out string errText)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            object result;
            InvokerInfo info;
            lock(_lockThis)
            {
                info = GetInvoker(dllName, className);
                info.Ref++;
            }

            try
            {
                result = info.Invoker.InvokeMethodEx(
                    methodName,
                    methodParams,
                    out errCode,
                    out errText);
                stopwatch.Stop();

                TimeSpan timespan = stopwatch.Elapsed;
                Console.WriteLine(
                    string.Format("{0}(RESTful):<{1}>{2}->{3}->耗时(ms):{4}",
                        DateTime.Now.ToString(),
                        info.Ref.ToString(),
                        dllName,
                        methodName,
                        timespan.TotalMilliseconds.ToString()));
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                lock (_lockThis)
                {
                    info.Ref--;
                    TryToUnload(dllName, className, info);
                }
            }

            return result;
        }

        /// <summary>
        /// 加载指定的程序集
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="typeName"></param>
        public void LoadAssembly(string dllName, string typeName)
        {
            Queue<InvokerInfo> result;
            _caches.TryGetValue(typeName, out result);

            if (result==null||result.Count==0)
            {
                string dllFileName = string.Format(@"{0}\ServiceDlls\{1}",
                    AppDomain.CurrentDomain.BaseDirectory,
                    dllName);
                Console.WriteLine(dllFileName);

                FileInfo info = new FileInfo(dllFileName);
                if (!info.Exists)
                    throw new Exception(string.Format("没有找到程序集文件[{0}]", dllFileName));

                CacheMethodInvoker(dllName, typeName, info.LastWriteTime);
            }
        }

        /// <summary>
        /// 缓存指定的方法调用信息
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="typeName"></param>
        /// <param name="lastWriteTime"></param>
        private InvokerInfo CacheMethodInvoker(
            string dllName, 
            string typeName, 
            DateTime lastWriteTime)
        {
            MethodInvoker invoker = null;

            var invokerInfo = new InvokerInfo();
            var setup = new AppDomainSetup
            {
                ShadowCopyFiles = "true",
                ShadowCopyDirectories = string.Format(@"{0}ServiceDlls\",
                  AppDomain.CurrentDomain.BaseDirectory),
                ConfigurationFile = "IRAP.DynamicLoad.exe.config",
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
            };

            AppDomain domain = AppDomain.CreateDomain(dllName, null, setup);
            domain.DoCallBack(delegate { LifetimeServices.LeaseTime = TimeSpan.Zero; });

            invokerInfo.Domain = domain;
            invokerInfo.LastWriteTime = lastWriteTime;
            invokerInfo.TypeName = typeName;

            BindingFlags bindings =
                BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.Public;
            object[] para = new object[]
            {
                string.Format(@"{0}\{1}", setup.ShadowCopyDirectories, dllName),
                typeName,
            };

            try
            {
                invoker = (MethodInvoker)domain.CreateInstanceAndUnwrap(
                    Assembly.GetExecutingAssembly().CodeBase.Substring(8),
                    typeof(MethodInvoker).FullName,
                    true,
                    bindings,
                    null,
                    para,
                    CultureInfo.CurrentCulture,
                    null);
            }
            catch (Exception error)
            {
                throw new Exception(
                    string.Format(
                        "无法从程序集[{0}]中创建[{1}]类型的对象，原因：{2}",
                        Assembly.GetExecutingAssembly().CodeBase,
                        typeof(MethodInvoker).FullName,
                        error.Message));
            }

            if (invoker==null)
            {
                throw new Exception(
                    string.Format(
                        "在程序集[{0}]中没有找到[{1}]类型！",
                        Assembly.GetExecutingAssembly().CodeBase,
                        typeof(MethodInvoker).FullName));
            }

            try
            {
                invoker.LoadAllMethods();
            }
            catch (Exception error)
            {
                throw new Exception(
                    string.Format(
                        "无法初始化程序集[{0}]中[{1}]类型的实例，原因：{2}",
                        Assembly.GetExecutingAssembly().CodeBase,
                        typeof(MethodInvoker).FullName,
                        error.Message));
            }

            invokerInfo.Invoker = invoker;
            invokerInfo.Ref = 0;

            if (_caches.Keys.Contains(typeName))
            {
                // 如果此类缓存中已经存在方法了，说明是过期的，需要重新加载（？？？为毛？）
                foreach (InvokerInfo y in _caches[typeName])
                {
                    if (y.TypeName == typeName)
                    {
                        _caches[typeName].Clear();
                        break;
                    }
                }
                _caches[typeName].Enqueue(invokerInfo);
            }
            else
            {
                Queue<InvokerInfo> queue = new Queue<InvokerInfo>();
                queue.Enqueue(invokerInfo);
                _caches[typeName] = queue;
            }

            return invokerInfo;
        }

        /// <summary>
        /// 尝试卸载程序集
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="typeName"></param>
        /// <param name="currentInfo"></param>
        private void TryToUnload(
            string dllName,
            string typeName,
            InvokerInfo currentInfo)
        {
            InvokerInfo info = _caches[typeName].Peek();

            if (info == currentInfo)
                return;

            if (info.Ref == 0)
                Unload(typeName);
        }

        /// <summary>
        /// 获取指定程序集的调用信息
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        private InvokerInfo GetInvoker(string dllName, string typeName)
        {
            Queue<InvokerInfo> result;
            InvokerInfo trueClass = null;
            _caches.TryGetValue(typeName, out result);

            foreach (InvokerInfo item in result)
            {
                if (item.TypeName == typeName)
                {
                    trueClass = item;
                    break;
                }
            }

            if (trueClass == null)
                throw new Exception(
                    string.Format(
                        "无法加载程序集[{0}]中的[{1}]类型",
                        dllName,
                        typeName));

            string dllFileName = string.Format(@"{0}ServiceDlls\",
                AppDomain.CurrentDomain.BaseDirectory, dllName);
            FileInfo info = new FileInfo(dllFileName);

            if (!info.Exists)
                return trueClass;

            if (info.LastWriteTime > trueClass.LastWriteTime)
                return CacheMethodInvoker(dllName, typeName, info.LastWriteTime);

            return trueClass;
        }

        public void Dispose()
        {
            _caches.Clear();

            foreach (var o in _caches.Keys)
                Unload(o);
        }
    }
}
