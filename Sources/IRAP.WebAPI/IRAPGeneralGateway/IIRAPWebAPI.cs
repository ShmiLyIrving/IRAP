using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;

namespace IRAPGeneralGateway
{
    [ServiceContract()]
    public interface IIRAPWebAPI
    {
        // 这里要特别注意 UriTemplate 地址要与调用地址完全一致，Exchange/，如果调用地址是 Exchange 则不能传递流
        // 正常的数据交换
        [OperationContract()]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Exchange/{clientID}/{msgFormat}/{exCode}")]
        Stream GeneralCall(Stream reqContent, string clientID, string msgFormat, string exCode);

        // 渠道认证与业务无关
        [OperationContract()]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "ChannelValidate/{clientID}/{msgFormat}")]
        Stream ChannelValidate(Stream reqContent, string clientID, string msgFormat);

        // 登录认证
        [OperationContract()]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "OpenAuth/{clientID}/{msgFormat}")]
        Stream OpenAuth(Stream reqContent, string clientID, string msgFormat);

        // 安全认证，IIS 转发时调用，记录访问者信息
        [OperationContract()]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Safe/{clientID}/{msgFormat}")]
        Stream SafeRecord(Stream reqContent, string clientID, string msgFormat);

        // 上传文件流，请求 HTTP 头包含文件类型：Content-Type=MIME类型，Stream 是文件流，Parameters 是约定的参数
        [OperationContract()]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "UpFile/{clientID}/{exCode}/{parameters}")]
        Stream Upload(Stream fileStream, string clientID, string exCode, string parameters);

        // 下载文件流，响应 HTTP 头包含文件类型：Content-Type=MIME类型，
        // 响应头：Headers.Add("Content-Disposition", "attachment; filename=xxx.xxx")浏览器弹出下载框
        [OperationContract()]
        [WebInvoke(
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "DownFile/{clientID}/{exCode}/{parameters}")]
        Stream Download(string clientID, string exCode, string parameters);
    }
}
