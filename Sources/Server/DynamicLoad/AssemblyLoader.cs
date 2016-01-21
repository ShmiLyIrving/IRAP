using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.IO;

namespace IRAP.DynamicLoad
{
    public class AssemblyLoader : MarshalByRefObject,IDisposable
    {
        private readonly object _lockThis = new object();
        private Dictionary<string, Queue<InvokerInfo>> _caches =
            new Dictionary<string, Queue<InvokerInfo>>();

        //加载所有可用的程序集
        /// <summary>
        /// 加载所有可用的程序集
        /// </summary>
        /// <param name="dlls"></param>
        public void LoadAssemblys(Dictionary<string, string> dlls)
        {
            foreach (KeyValuePair<string, string> kvp in dlls)
            {
                Queue<InvokerInfo> result;
                _caches.TryGetValue(kvp.Value, out result);
                if (result==null)
                {
                    LoadAssembly(kvp.Value, kvp.Key);
                } 
            }
           // Assembly.Load("IRAP.Entity.IRAPAdmin");
        }
        //卸载程序集
        /// <summary>
        /// 卸载程序集
        /// </summary>
        /// <param name="dllName"></param>
        public void Unload(string typeName)
        {
            AppDomain domain = null;
            while (_caches[typeName].Count != 0)
            {
                InvokerInfo info = _caches[typeName].Dequeue();
                domain = info.Domain;
            }
            if (domain!=null)
            {
                AppDomain.Unload(domain);
            }  
        }
        //调用指定程序集中的指定方法
        /// <summary>
        /// 调用指定程序集中指定的方法
        /// </summary>
        /// <param name="dllName">程序集名称</param>
        /// <param name="methodName">方法名称</param>
        /// <param name="methodParams">参数数组</param>
        /// <returns></returns>
        public object InvokeMethod(string dllName, string className,string methodName, object[] methodParams,
             out int errCode, out string errText)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object result;
            InvokerInfo info;
            lock (_lockThis)
            {
                info = GetInvoker(dllName, className);
                info.Ref++;
            }
            try
            {
                result = info.Invoker.InvokeMethod(methodName, methodParams, out errCode, out errText);
                stopwatch.Stop();
                TimeSpan timespan = stopwatch.Elapsed;
                Console.WriteLine(DateTime.Now.ToString() 
                    + ":<" + info.Ref.ToString() 
                    + ">" + dllName + "->" 
                    + methodName+"->耗时(ms):"+timespan.TotalMilliseconds.ToString());
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                lock (_lockThis)
                {
                    info.Ref--;
                    TryToUnLoad(dllName,className, info);
                }
            }
            return result;
        }

        public object InvokeMethodEx(string dllName, string className, string methodName, object[] methodParams,
          out int errCode, out string errText)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            object result;
            InvokerInfo info;
            lock (_lockThis)
            {
                info = GetInvoker(dllName, className);
                info.Ref++;
            }
            try
            {
                result = info.Invoker.InvokeMethodEx(methodName, methodParams, out errCode, out errText);
                stopwatch.Stop();
                TimeSpan timespan = stopwatch.Elapsed;
                Console.WriteLine(DateTime.Now.ToString()
                    + "(RESTful):<" + info.Ref.ToString()
                    + ">" + dllName + "->"
                    + methodName + "->耗时(ms):" + timespan.TotalMilliseconds.ToString());
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                lock (_lockThis)
                {
                    info.Ref--;
                    TryToUnLoad(dllName, className, info);
                }
            }
            return result;
        }
        //加载指定的程序集
        /// <summary>
        /// 加载指定的程序集
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="typeName"></param>
        public void LoadAssembly(string dllName, string typeName)
        {
            //Get object from cache
            Queue<InvokerInfo> result;
            _caches.TryGetValue(typeName, out result);

            if (result == null || result.Count == 0)
            {
                Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory + @"ServiceDlls\" + dllName);
                //Get TimeStamp of file
                FileInfo info =
                    new FileInfo(
                        AppDomain.CurrentDomain.BaseDirectory + @"ServiceDlls\" + dllName);

                if (!info.Exists)
                    throw new Exception(AppDomain.CurrentDomain.BaseDirectory
                        + @"ServiceDlls\" + dllName + " not exist");

                CacheMethodInvoker(dllName, typeName, info.LastWriteTime);
            }
        }
        //缓存指定的方法调用信息
        /// <summary>
        /// 缓存指定的方法调用信息
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="typeName"></param>
        /// <param name="lastWriteTime"></param>
        /// <returns></returns>
        private InvokerInfo CacheMethodInvoker(string dllName, string typeName, DateTime lastWriteTime)
        {
            MethodInvoker invoker;

            var invokerInfo = new InvokerInfo();

            var setup = new AppDomainSetup
            {
                ShadowCopyFiles = "true",
                ShadowCopyDirectories = AppDomain.CurrentDomain.BaseDirectory + @"ServiceDlls\",
                ConfigurationFile = "IRAP.DynamicLoad.exe.config",
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory
            };

            AppDomain domain = AppDomain.CreateDomain(dllName, null, setup);

            domain.DoCallBack(delegate { LifetimeServices.LeaseTime = TimeSpan.Zero; });

            invokerInfo.Domain = domain;
            invokerInfo.LastWriteTime = lastWriteTime;
            invokerInfo.TypeName = typeName;

            BindingFlags bindings =
                BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.Public;
            object[] para = new object[] { setup.ShadowCopyDirectories + @"\" + dllName, typeName };
            try
            {
                invoker = (MethodInvoker)domain.CreateInstanceFromAndUnwrap(
                                             Assembly.GetExecutingAssembly().CodeBase.Substring(8),
                                             typeof(MethodInvoker).FullName,
                                             true, bindings, null, para, 
                                             System.Globalization.CultureInfo.CurrentCulture,
                                             null);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Can't create object which type is " + typeof(MethodInvoker).FullName + " from assembly " +
                    Assembly.GetExecutingAssembly().CodeBase + ",Error Message: " + ex.Message);
            }

            if (invoker == null)
                throw new Exception(
                    "Can't find type " + typeof(MethodInvoker).FullName + " from " +
                    Assembly.GetExecutingAssembly().CodeBase);

            try
            {
                invoker.LoadAllMethods();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't initialize object which type is " + typeof(MethodInvoker).FullName +
                                    " from " +
                                    Assembly.GetExecutingAssembly().CodeBase + ",Error Message: " + ex.Message);
            }

            invokerInfo.Invoker = invoker;
            invokerInfo.Ref = 0;

            if (_caches.Keys.Contains(typeName))
            {
                //如果此类缓存中已经存在方法了，说明是过期的，需要重新加载！
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
        //尝试卸载程序集
        /// <summary>
        /// 尝试卸载程序集
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="currentInfo"></param>
        private void TryToUnLoad(string dllName,string typeName, InvokerInfo currentInfo)
        {
            InvokerInfo info = _caches[typeName].Peek();

            if (info == currentInfo)
                return;

            if (info.Ref == 0)
            {
                Unload(typeName);
            }
        }
        //获取指定程序集的调用信息
        /// <summary>
        /// 获取指定程序集的调用信息
        /// </summary>
        /// <param name="dllName"></param>
        /// <returns></returns>
        private InvokerInfo GetInvoker(string dllName,string typeName)
        {
            //Get object from cache
            Queue<InvokerInfo> result;
            InvokerInfo trueClass = null;
            _caches.TryGetValue(typeName, out result);

            foreach (InvokerInfo item in result)
            {
                if (item.TypeName==typeName )
                {
                    trueClass = item;
                    break;
                }
            }

            if (trueClass == null)
            {
                throw new Exception(dllName + " not loaded "+typeName);
            }

            //Get TimeStamp of file
            FileInfo info =
                new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"ServiceDlls\" + dllName);

            if (!info.Exists)
            {
                return trueClass;
            }

            if (info.LastWriteTime > trueClass.LastWriteTime)
            {
                return CacheMethodInvoker(dllName, typeName, info.LastWriteTime);
            }

            //return result.ToArray()[result.Count - 1];
            return trueClass;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            _caches.Clear();

            foreach (var o in _caches.Keys)
            {
                Unload(o);
            }
        }

        #endregion
    }
}
