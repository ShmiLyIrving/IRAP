using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using IRAP.OPC.Entity;
using IRAP.Interface.OPC;
using IRAP.OPC.Library;
using IRAP.BL.OPCGateway.Global;
using IRAP.BL.OPCGateway.Global.Entities;

namespace IRAP.BL.OPCGateway.Actions
{
    internal class TGetDeviceTags : Interfaces.IWebAPIAction
    {
        private TGetDeviceTagsContent content = new TGetDeviceTagsContent();

        public TGetDeviceTags(string xmlContent)
        {
            try
            {
                content.ResolveRequest(xmlContent);
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
            if (!string.IsNullOrEmpty(content.Response.ErrCode) &&
                content.Response.ErrCode != "0")
            {
                return content.GenerateResponseContent();
            }

            if (content.Request != null)
            {
                content.Response.ErrCode = "999999";
                content.Response.ErrText = "功能正在开发中......";

                try
                {
                    if (content.Request.ExCode == "GetDeviceTags")
                    {
                        TKepwareServer server =
                            TKepwareServers.Instance.Servers.ByAddress(
                                content.Request.KepServAddr);
                        if (server != null)
                        {
                            TKepwareDevice device =
                                server.Devices.Get(
                                    content.Request.KepServChannel,
                                    content.Request.KepServDevice);
                            if (device != null)
                            {
                                content.Response.KepServAddr = server.Address;
                                content.Response.KepServName = server.Name;
                                content.Response.KepServChannel = device.KepServChannel;
                                content.Response.KepServDevice = device.KepServDevice;

                                for (int i = 0; i < device.Tags.Count; i++)
                                {
                                    content.Response.Details.Add(
                                        new TGetDeviceTagsRspDetail()
                                        {
                                            Ordinal = i + 1,
                                            TagName = device.Tags[i].TagName,
                                        });
                                }

                                content.Response.ErrCode = "0";
                                content.Response.ErrText = "设备标签清单获取完成";
                            }
                            else
                            {
                                content.Response.ErrCode = "903321";
                                content.Response.ErrText =
                                    $"DeviceName[{content.Request.KepServChannel}." +
                                    $"{content.Request.KepServDevice}]不存在";
                            }
                        }
                        else
                        {
                            content.Response.ErrCode = "900103";
                            content.Response.ErrText =
                                $"KepServer[{content.Request.KepServName}" +
                                $"({content.Request.KepServAddr})]连接失败";
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
