using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;

using IRAP.OPC.Library;
using IRAP.OPC.Entity;

namespace IRAP.BL.OPCGateway
{
    public class OPCGatewayService : IOPCGateway
    {
        private Guid id = Guid.NewGuid();

        public OPCGatewayService()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        ~OPCGatewayService()
        {
        }

        private Stream  GenerateReturnStream(string rtnMessage)
        {
            byte[] strBytes = Encoding.UTF8.GetBytes(rtnMessage);
            return new MemoryStream(strBytes);
        }

        public Stream GeneralCall(Stream reqContent)
        {
            StreamReader sr = new StreamReader(reqContent);
            string content = sr.ReadToEnd();
            sr.Close();

            WriteLog.Instance.Write(id, "收到的请求报文：");
            WriteLog.Instance.Write(id, content);

            string rspContent = "<root><Warning>系统正在建设中......</Warning></root>";

            #region 解析收到的请求字符串
            if (content.Contains("_Add_"))
            {
                TIRAPOPCDevices.Instance.Add(
                    new TIRAPOPCDevice()
                    {
                        DeviceCode = content,
                    });
            }
            if (content.Contains("_GetLast_"))
            {
                if (TIRAPOPCDevices.Instance.Count == 0)
                    rspContent = "<root><Warning>没有设备信息</Warning></root>";
                else
                    rspContent =
                        string.Format(
                            "<root><Device DeviceCode={0}/></root>",
                            TIRAPOPCDevices.Instance.Devices[TIRAPOPCDevices.Instance.Count - 1].DeviceCode);
            }
            #endregion

            #region 根据请求交易代码，执行交易过程
            #endregion

            WriteLog.Instance.Write(id, "发送的响应报文：");
            WriteLog.Instance.Write(id, rspContent);

            return GenerateReturnStream(rspContent);
        }
    }
}
