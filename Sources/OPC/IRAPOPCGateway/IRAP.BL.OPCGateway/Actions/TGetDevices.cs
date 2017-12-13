using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

using IRAP.Interface.OPC;
using IRAP.BL.OPCGateway.Interfaces;
using IRAP.OPC.Entity;
using IRAP.OPC.Library;

namespace IRAP.BL.OPCGateway.Actions
{
    internal class TGetDevices : IWebAPIAction
    {
        private TGetDevicesContent content = new TGetDevicesContent();

        public TGetDevices(string xmlContent)
        {
            content.Resolve(xmlContent);
        }

        public string DoAction()
        {
            content.ResponseBody.ErrCode = "999999";
            content.ResponseBody.ErrText = "功能正在开发中......";

            try
            {
                int ordinal = 1;
                foreach (TIRAPOPCDevice device in TIRAPOPCDevices.Instance.Devices)
                {
                    content.ResponseBody.AddDeviceDetail(
                        new TGetDevicesRspDetail()
                        {
                            Ordinal = ordinal++,
                            DeviceCode = device.DeviceCode,
                            DeviceName = device.DeviceName,
                            KepServAddr = device.KepServerAddr,
                            KepServName = device.KepServerName,
                            KepServChannel = device.KepServerChannel,
                            KepServDevice = device.KepServerDevice,
                        });
                }

                content.ResponseBody.ErrCode = "0";
                content.ResponseBody.ErrText = "设备列表获取完成";
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

            return content.GenerateResponseContent();
        }
    }
}
