using System.ComponentModel;

namespace IRAPGeneralGateway
{
    /// <summary>
    /// 客户端安全等级
    /// </summary>
    public enum TSecurityLevel
    {
        /// <summary>
        /// 明文
        /// </summary>
        [Description("明文")]
        None = 1,
        /// <summary>
        /// 压缩
        /// </summary>
        [Description("压缩")]
        Compressed,
        /// <summary>
        /// DES 加密和 GZIP 压缩（Base64）
        /// </summary>
        [Description("DES 加密和 GZIP 压缩（Base64）")]
        DES,
        /// <summary>
        /// AES 加密（Base64）
        /// </summary>
        [Description("AES 加密（Base64）")]
        AES,
    }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum TDBServerType
    {
        /// <summary>
        /// Microsoft SQL Server
        /// </summary>
        [Description("Microsoft SQL Server")]
        SQLServer = 1
    }

    /// <summary>
    /// 调用模式
    /// </summary>
    public enum TInvokeType
    {
        /// <summary>
        /// 样本模式
        /// </summary>
        [Description("样本模式")]
        Demo = 0,
        /// <summary>
        /// 数据库存储过程模式
        /// </summary>
        [Description("数据库存储过程模式")]
        StoreProcedure,
        /// <summary>
        /// 类库接口模式
        /// </summary>
        [Description("类库接口模式")]
        Interface,
    }

    /// <summary>
    /// 服务调用结果
    /// </summary>
    public enum TServiceCallResult
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 0,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Failure,
        /// <summary>
        /// 拒绝
        /// </summary>
        [Description("拒绝")]
        Reject,
        /// <summary>
        /// 出错
        /// </summary>
        [Description("出错")]
        Except,
    }
}