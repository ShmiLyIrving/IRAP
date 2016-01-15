using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.DynamicLoad
{
    public class InvokerInfo
    {
        /// <summary>
        /// 待调用的服务类型
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 服务所在应用程序域
        /// </summary>
        public AppDomain Domain { get; set; }
        /// <summary>
        /// 服务调用器
        /// </summary>
        public MethodInvoker Invoker { get; set; }
        /// <summary>
        /// DLL 文件最后修改时间
        /// </summary>
        public DateTime LastWriteTime { get; set; }
        /// <summary>
        /// 引用数
        /// </summary>
        public int Ref { get; set; }
    }
}
