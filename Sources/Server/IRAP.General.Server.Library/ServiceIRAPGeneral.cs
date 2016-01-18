using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using IRAP.Interface.Global;
using IRAP.Server.Global;
using IRAP.DynamicLoad;
using IRAPShared;

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

        public int ExChange(
            string assemblyName, 
            string className, 
            string methodName, 
            List<IRAPJsonTable> jsonTable, 
            ref string jsonContent, 
            out string backTypeFullName, 
            out string errText)
        {
            int errCode = -1;
            IRAPDevFramework irapfw = new IRAPDevFramework();
            jsonContent = (string)irapfw.Exchange(
                assemblyName,
                className,
                methodName,
                jsonTable,
                out backTypeFullName,
                out errCode,
                out errText);

            return errCode;
        }

        public byte[] GetBinary(
            string assemblyName, 
            string className, 
            string methodName, 
            Hashtable paramDict, 
            out int errCode, 
            out string errText)
        {
            byte[] binaryBytes;
            IRAPDevFramework irapfw = new IRAPDevFramework();
            binaryBytes = irapfw.GetBinary(
                assemblyName,
                className,
                methodName,
                paramDict,
                out errCode,
                out errText);

            return binaryBytes;
        }

        public string UploadBinary(
            string assemblyName, 
            string className, 
            string methodName, 
            byte[] binaryBytes, 
            out int errCode, 
            out string errText)
        {
            IRAPDevFramework irapfw = new IRAPDevFramework();
            string result = irapfw.UpLoadBinary(
                assemblyName,
                className,
                methodName,
                binaryBytes,
                out errCode,
                out errText);

            return result;
        }

        public int WCFRESTful(
            string assemblyName, 
            string className, 
            string methodName, 
            List<IRAPJsonTable> jsonTable, 
            ref string jsonContent, 
            out string backTypeFullName, 
            out string errText)
        {
            int errCode = -1;

            IRAPDevFramework irapfw = new IRAPDevFramework();
            IRAPJsonResult result = (IRAPJsonResult)irapfw.WCFRESTful(
                assemblyName,
                className,
                methodName,
                jsonTable,
                out errCode,
                out errText);

            if (result != null)
            {
                backTypeFullName = result.TypeName;
                jsonContent = result.Json;
            }
            else
            {
                backTypeFullName = DBNull.Value.GetType().ToString();
                jsonContent = "";
            }

            return errCode;
        }
    }
}
