using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using IRAP.OPC.Entity;
using IRAP.Interface.OPC;
using IRAP.OPC.Library;

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
            if (content.Request != null)
            {
                content.Response.ErrCode = "999999";
                content.Response.ErrText = "功能正在开发中......";

                try
                {
                    if (content.Request.ExCode == "GetDeviceTags")
                    {
                        TIRAPOPCLocDevice device =
                            TIRAPLocOPCDevices.Instance.GetDeviceWithDeviceCode(
                                content.Request.DeviceCode);
                        if (device == null)
                        {
                            content.Response.ErrCode = "121026";
                            content.Response.ErrText = string.Format("无效的设备代码({0})", content.Request.DeviceCode);
                        }
                        else
                        {
                            content.Response.DeviceCode = device.DeviceCode;
                            content.Response.DeviceName = device.DeviceName;
                            content.Response.KepServAddr = device.KepServerAddr;
                            content.Response.KepServName = device.KepServerName;
                            content.Response.KepServChannel = device.KepServerChannel;
                            content.Response.KepServDevice = device.KepServerDevice;

                            for (int i = 0; i < device.Tags.Count; i++)
                            {
                                content.Response.Details.Add(
                                    new TGetDeviceTagsRspDetail()
                                    {
                                        Ordinal = i + 1,
                                        TagName = device.Tags[i].TagName,
                                        DataType = device.Tags[i].DataType,
                                        Description = device.Tags[i].Description,
                                    });
                            }

                            content.Response.ErrCode = "0";
                            content.Response.ErrText = "设备标签清单获取完成";
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
