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
        [OperationContract()]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Exchange/{clientID}/{msgFormat}/{exCode}")]
        Stream GeneralCall(Stream reqContent, string clientID, string msgFormat, string exCode);
    }
}
