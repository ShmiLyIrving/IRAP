using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;

using IRAP.OPC.Library;
using IRAP.OPC.Entity;
using IRAP.Interface;

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

            string rspContent = "<Softland><Head><ExCode>RequestError</ExCode>" +
                        "<ErrorMessage>{0}</ErrorMessage></Head></Softland>";

            #region 解析收到的请求字符串
            TSoftlandContent softlandContent = new TSoftlandContent();
            try
            {
                softlandContent.ResolveRequest(content);
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);

                rspContent = string.Format(rspContent, error.Message);
            }
            #endregion

            #region 根据请求交易代码，执行交易过程
            if (softlandContent.Head.ExCode != "")
            {
                object action = null;
                string typeName =
                    string.Format(
                        "IRAP.BL.OPCGateway.Actions.T{0}",
                        softlandContent.Head.ExCode);

                try
                {
                    Type type = Type.GetType(typeName);
                    if (type == null)
                    {
                        string errText =
                            string.Format(
                                "无法创建[{0}]交易对象，该交易正在开发中。",
                                typeName);
                        Debug.WriteLine(errText);
                        rspContent = string.Format(rspContent, errText);
                    }
                    else
                    {
                        action = Activator.CreateInstance(type, new object[] { content });
                    }
                }
                catch (Exception error)
                {
                    string errText =
                        string.Format(
                            "无法创建[{0}]交易对象，系统返回错误信息：[{1}]",
                            softlandContent.Head.ExCode,
                            error.Message);
                    Debug.WriteLine(errText);
                    rspContent = string.Format(rspContent, errText);
                }

                if (action != null)
                    try
                    {
                        rspContent = (action as Interfaces.IWebAPIAction).DoAction();
                    }
                    catch (Exception error)
                    {
                        string errText =
                            string.Format(
                                "在执行[{0}]对象的 DoAction 方法，系统返回错误信息：[{1}]",
                                typeName,
                                error.Message);
                        Debug.WriteLine(errText);
                        rspContent = string.Format(rspContent, errText);
                    }

            }
            #endregion

            WriteLog.Instance.Write(id, "发送的响应报文：");
            WriteLog.Instance.Write(id, rspContent);

            return GenerateReturnStream(rspContent);
        }
    }
}
