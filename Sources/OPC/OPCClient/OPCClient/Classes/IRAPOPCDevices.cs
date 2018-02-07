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

        private List<TIRAPOPCLocDevice> items = new List<TIRAPOPCLocDevice>();
        private IRAPOPCDevices() { }
        public List<TIRAPOPCLocDevice> Devices
        {
            get { return items; }
        }
        //获取设备列表
        public List<TIRAPOPCLocDevice> GetDevices()
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
                        TIRAPOPCLocDevice device = new TIRAPOPCLocDevice(d);
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
        public TIRAPOPCLocDevice GetDeviceWithDeviceCode(string code)
        {
            foreach (TIRAPOPCLocDevice device in items)
            {
                if (device.DeviceCode == code)
                    return device;
            }
            return null;
        }
    }
}
