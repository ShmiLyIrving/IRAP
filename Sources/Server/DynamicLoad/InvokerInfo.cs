using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.DynamicLoad
{
    public class InvokerInfo
    {
        //待调用的服务类型
        /// <summary>
        /// 待调用的服务类型
        /// </summary>
        public string TypeName { get; set; }

        //服务所在应用程序域
        /// <summary>
        /// 服务所在应用程序域
        /// </summary>
        public AppDomain Domain { get; set; }

        //服务调用器
        /// <summary>
        /// 服务调用器
        /// </summary>
        public MethodInvoker Invoker { get; set; }

        //dll文件最后修改时间
        /// <summary>
        /// dll文件最后修改时间
        /// </summary>
        public DateTime LastWriteTime { get; set; }

        //引用数
        /// <summary>
        /// 引用数
        /// </summary>
        public int Ref { get; set; }
    }
}
