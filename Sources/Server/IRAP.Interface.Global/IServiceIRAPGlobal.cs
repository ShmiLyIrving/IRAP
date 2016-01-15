using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ServiceModel;

namespace IRAP.Interface.Global
{
    [ServiceContract()]
    public interface IServiceIRAPGlobal
    {
        [OperationContract()]
        int ExChange(string assemblyName, string className, string methodName, List<IRAPJsonTable> jsonTable, ref string jsonContent, out string backTypeFullName, out string errText);
        [OperationContract()]
        byte[] GetBinary(string assemblyName, string className, string methodName, Hashtable paramDict, out int errCode, out string errText);
        [OperationContract()]
        string UploadBinary(string assemblyName, string className, string methodName, byte[] binaryBytes, out int errCode, out string errText);
        [OperationContract()]
        int WCFRESTful(string assemblyName, string className, string methodName, List<IRAPJsonTable> jsonTable, ref string jsonContent, out string backTypeFullName, out string errText);
    }
}