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
    internal class TGetKepServList : Interfaces.IWebAPIAction
    {
        private TGetKepServListContent content = new TGetKepServListContent();

        public TGetKepServList(string xmlContent)
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
                    if (content.Request.ExCode == "GetKepServList")
                    {
                        int ordinal = 1;
                        foreach (TIRAPOPCServer server in TIRAPOPCServers.Instance.Servers)
                        {
                            content.Response.Items.Add(
                                new TGetKepServListRspDetail()
                                {
                                    Ordinal = ordinal++,
                                    KepServAddr = server.Address,
                                    KepServName = server.Name,
                                });
                        }

                        content.Response.ErrCode = "0";
                        content.Response.ErrText = "设备列表获取完成";
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
