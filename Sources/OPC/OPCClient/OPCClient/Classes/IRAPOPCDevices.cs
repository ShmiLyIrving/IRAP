using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRAP.OPC.Entity;
using IRAP.Interface.OPC;
using DevExpress.XtraEditors;

namespace OPCClient.Classes
{
    public class IRAPOPCDevices
    {
        private static IRAPOPCDevices _instance = null;

        public static IRAPOPCDevices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPOPCDevices();
                return _instance;
            }
        }

        private List<TIRAPOPCDevice> items = new List<TIRAPOPCDevice>();
        private IRAPOPCDevices() { }
        public List<TIRAPOPCDevice> Devices
        {
            get { return items; }
        }
        //获取设备列表
        public List<TIRAPOPCDevice> GetDevices()
        {
            items.Clear();
            TGetDevicesContent content = new TGetDevicesContent();
            content.Head.ExCode = "GetDevices";
            content.Request.ExCode = "GetDevices";
            content.ResolveResponse(OPCWSClient.Instance.WSCall(content.GenerateRequestContent()));
            if (content.Response.ErrCode == "0")
            {
                if (content.Response.Details.Count > 0)
                {
                    items.Clear();
                    foreach (var d in content.Response.Details)
                    {
                        TIRAPOPCDevice device = new TIRAPOPCDevice(d);
                        items.Add(device);
                    }
                };
            }
            else
            {
                XtraMessageBox.Show(content.Response.ErrCode + ":" + content.Response.ErrText);
            }
            return items;
        }
        public int Count
        {
            get { return items.Count; }
        }
        public TIRAPOPCDevice GetDeviceWithDeviceCode(string code)
        {
            foreach (TIRAPOPCDevice device in items)
            {
                if (device.DeviceCode == code)
                    return device;
            }
            return null;
        }
    }
}
