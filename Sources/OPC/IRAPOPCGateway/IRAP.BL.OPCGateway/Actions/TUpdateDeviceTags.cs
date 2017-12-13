using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using IRAP.Interface.OPC;
using IRAP.BL.OPCGateway.Interfaces;
using IRAP.OPC.Entity;
using IRAP.OPC.Library;

namespace IRAP.BL.OPCGateway.Actions
{
    internal class TUpdateDeviceTags : IWebAPIAction
    {
        private TUpdateDeviceTagsContent content = new TUpdateDeviceTagsContent();

        public TUpdateDeviceTags(string xmlContent)
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
                        content.ResponseBody.ErrCode = de.Value.ToString();
                    if (de.Key.ToString().ToUpper() == "ERRTEXT")
                        content.ResponseBody.ErrText = de.Value.ToString();
                }
            }
        }

        public string DoAction()
        {
            if (content.RequestBody != null)
            {
                content.ResponseBody.ErrCode = "999999";
                content.ResponseBody.ErrText = "功能正在开发中......";

                try
                {
                    switch (content.RequestBody.UpdateType)
                    {
                        case 1:     // 新增设备
                            TIRAPOPCDevice device =
                                TIRAPOPCDevices.Instance.GetDeviceWithDeviceCode(
                                    content.RequestBody.DeviceCode);
                            if (device != null)
                            {
                                content.ResponseBody.ErrCode = "900102";
                                content.ResponseBody.ErrText =
                                    string.Format(
                                        "设备号[{0}]已经存在，对应的设备名称[{1}]，不能新增",
                                        device.DeviceCode,
                                        device.DeviceName);
                                break;
                            }
                            else
                            {
                                device = new TIRAPOPCDevice(content.RequestBody);
                                TIRAPOPCDevices.Instance.Add(
                                    device, 
                                    TOPCGatewayGlobal.Instance.ConfigurationFile);

                                content.ResponseBody.ErrCode = "0";
                                content.ResponseBody.ErrText = "设备信息及标签新增成功";
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                }
                catch (Exception error)
                {
                    content.ResponseBody.ErrText = string.Format("系统抛出的错误：[{0}]", error.Message);
                    foreach (DictionaryEntry de in error.Data)
                    {
                        if (de.Key.ToString().ToUpper() == "ERRCODE")
                            content.ResponseBody.ErrCode = de.Value.ToString();
                        if (de.Key.ToString().ToUpper() == "ERRTEXT")
                            content.ResponseBody.ErrText = de.Value.ToString();
                    }
                }
            }

            return content.GenerateResponseContent();
        }
    }
}
