using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using IRAP.Interface.Global;
using IRAP.Server.Global;

namespace IRAP.General.Server.Library
{
    public class ServiceIRAPGeneral : IServiceIRAPGlobal
    {
        private static string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private string connectionStr = "";
        private DBConfigParams dbParams = new DBConfigParams("IRAP");

        public ServiceIRAPGeneral()
        {
            connectionStr = dbParams.DBConnectionString;
        }

        public int ExChange(string assemblyName, string className, string methodName, List<IRAPJsonTable> jsonTable, ref string jsonContent, out string backTypeFullName, out string errText)
        {
            int errCode = -1;
            IRAPDev
        }

        public byte[] GetBinary(string assemblyName, string className, string methodName, Hashtable paramDict, out int errCode, out string errText)
        {
            throw new NotImplementedException();
        }

        public string UploadBinary(string assemblyName, string className, string methodName, byte[] binaryBytes, out int errCode, out string errText)
        {
            throw new NotImplementedException();
        }

        public int WCFRESTful(string assemblyName, string className, string methodName, List<IRAPJsonTable> jsonTable, ref string jsonContent, out string backTypeFullName, out string errText)
        {
            throw new NotImplementedException();
        }
    }
}
