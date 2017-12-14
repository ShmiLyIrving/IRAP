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
                    if (content.Request.ExCode == "UpdateDeviceTags")
                    {
                        TIRAPOPCDevice device = null;

                        switch (content.Request.UpdateType)
                        {
                            case 1:     // 新增设备
                                device =
                                    TIRAPOPCDevices.Instance.GetDeviceWithDeviceCode(
                                        content.Request.DeviceCode);
                                if (device != null)
                                {
                                    Exception error = new Exception();
                                    error.Data["ErrCode"] = "900102";
                                    error.Data["ErrText"] =
                                        string.Format(
                                            "设备号[{0}]已经存在，对应的设备名称[{1}]，不能新增",
                                            device.DeviceCode,
                                            device.DeviceName);
                                    throw error;
                                }

                                device = new TIRAPOPCDevice(content.Request);
                                TIRAPOPCDevices.Instance.Add(
                                    device,
                                    TOPCGatewayGlobal.Instance.ConfigurationFile);

                                content.Response.ErrCode = "0";
                                content.Response.ErrText = "设备信息及标签新增成功";

                                break;
                            case 2:     // 修改设备及标签信息
                                device =
                                    TIRAPOPCDevices.Instance.GetDeviceWithDeviceCode(
                                        content.Request.DeviceCode);
                                if (device == null)
                                {
                                    Exception error = new Exception();
                                    error.Data["ErrCode"] = "121026";
                                    error.Data["ErrText"] =
                                        string.Format(
                                            "无效的设备代码({0})",
                                            content.Request.DeviceCode);
                                    throw error;
                                }

                                device = new TIRAPOPCDevice(content.Request);
                                TIRAPOPCDevices.Instance.Modify(
                                    device,
                                    TOPCGatewayGlobal.Instance.ConfigurationFile);

                                content.Response.ErrCode = "0";
                                content.Response.ErrText = "设备信息及标签修改成功";

                                break;
                            case 3:     // 删除设备
                                string deviceCode = content.Request.DeviceCode;
                                TIRAPOPCDevices.Instance.Remove(
                                    deviceCode,
                                    TOPCGatewayGlobal.Instance.ConfigurationFile);

                                content.Response.ErrCode = "0";
                                content.Response.ErrText = "设备信息及标签删除成功";

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
