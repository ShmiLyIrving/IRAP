using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAPGeneralGateway.Entities
{
    public class TExCodeEntity
    {
        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// 交易代码
        /// </summary>
        public string ExCode { get; set; }
        /// <summary>
        /// 0-DEMO；1-直连数据库；2-调用接口
        /// </summary>
        public int InvokeType { get; set; }
        /// <summary>
        /// InvkeyType==0时，返回的响应报文样本内容
        /// </summary>
        public string ResponseText { get; set; }
        /// <summary>
        /// 程序集名
        /// </summary>
        public string LibraryName { get; set; }
        /// <summary>
        /// 类名（包含该类所在的 namespace）
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// 功能描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 存储过程名
        /// </summary>
        public string ProcName { get; set; }
        /// <summary>
        /// 存储过程执行后是否返回结果集
        /// </summary>
        public int HasRowSet { get; set; }
        /// <summary>
        /// 服务端是否需要统一验证令牌
        /// </summary>
        public int VerifyToken { get; set; }
    }
}
