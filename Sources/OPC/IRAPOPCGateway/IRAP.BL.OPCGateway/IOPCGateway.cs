using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;

namespace IRAP.BL.OPCGateway
{
    [ServiceContract()]
    [XmlSerializerFormat()]
    public interface IOPCGateway
    {
        [OperationContract()]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "Method/")]
        Stream GeneralCall(Stream reqContent);
    }
}
