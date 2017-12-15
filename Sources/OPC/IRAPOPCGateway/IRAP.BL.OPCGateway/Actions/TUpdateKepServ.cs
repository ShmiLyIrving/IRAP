using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using IRAP.Interface.OPC;
using IRAP.OPC.Entity;
using IRAP.OPC.Library;

namespace IRAP.BL.OPCGateway.Actions
{
    internal class TUpdateKepServ : Interfaces.IWebAPIAction
    {
        private TUpdateKepServContent content = new TUpdateKepServContent();

        public TUpdateKepServ(string xmlContent)
        {
            try
            {
                content.Resolve(xmlContent);
            }
            catch (Exception error)
            {
                foreach (DictionaryEntry de in error.Data)
                {
                    if (de.Key.ToString().ToUpper() == "ERRCODE")
                        content.Response.ErrCode = de.Value.ToString();
                    if (de.Key.ToString().ToUpper() == "ERRTEXT")
                        content.Response.ErrText = de.Value.ToString();
                }
            }
        }

        public string DoAction()
        {
            if (content.Request != null)
            {
                content.Response.ErrCode = "999999";
                content.Response.ErrText = "功能正在开发中......";

                try
                {
                    if (content.Request.ExCode == "UpdateKepServ")
                    {
                        TIRAPOPCServer server = null;

                        switch (content.Request.UpdateType)
                        {
                            case 1:     // 新增
                                server =
                                    TIRAPOPCServers.Instance.GetServerWithAddrAndName(
                                        content.Request.KepServAddr,
                                        content.Request.KepServName);
                                if (server != null)
                                {
                                    Exception error = new Exception();
                                    error.Data["ErrCode"] = "900102";
                                    error.Data["ErrText"] = 
                                        string.Format(
                                            "KepServer[{0}({1})]已在系统中注册",
                                            server.Address,
                                            server.Name);
                                    throw error;
                                }

                                server = new TIRAPOPCServer(content.Request);
                                TIRAPOPCServers.Instance.Add(
                                    server,
                                    TOPCGatewayGlobal.Instance.ConfigurationFile);

                                content.Response.ErrCode = "0";
                                content.Response.ErrText = "KepwareServer 新增成功";

                                break;
                            case 2:
                                content.Response.ErrCode = "999999";
                                content.Response.ErrText = "不支持 UpdateType=2 的功能";
                                break;
                            case 3:
                                TIRAPOPCServers.Instance.Remove(
                                    content.Request.KepServAddr,
                                    content.Request.KepServName,
                                    TOPCGatewayGlobal.Instance.ConfigurationFile);

                                content.Response.ErrCode = "0";
                                content.Response.ErrText = "KepwareServer 删除成功";

                                break;
                        }
                    }
                    else
                    {
                        content.Response.ErrCode = "900000";
                        content.Response.ErrText = "报文体中的交易代码和报文头中的交易代码不一致";
                    }
                }
                catch (Exception error)
                {
                    content.Response.ErrText = string.Format("系统抛出的错误：[{0}]", error.Message);
                    foreach (DictionaryEntry de in error.Data)
                    {
                        if (de.Key.ToString().ToUpper() == "ERRCODE")
                            content.Response.ErrCode = de.Value.ToString();
                        if (de.Key.ToString().ToUpper() == "ERRTEXT")
                            content.Response.ErrText = de.Value.ToString();
                    }
                }
            }

            return content.GenerateResponseContent();
        }
    }
}
