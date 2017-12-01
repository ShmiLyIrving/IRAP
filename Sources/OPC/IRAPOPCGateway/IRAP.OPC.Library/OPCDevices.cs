using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.OPC.Entity;

namespace IRAP.OPC.Library
{
    public class OPCDevices
    {
        private static OPCDevices _instance = null;

        public static OPCDevices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new OPCDevices();
                return _instance;
            }
        }

        private List<OPCDevice> opcDevices = new List<OPCDevice>();

        private OPCDevices() { }

        public List<OPCDevice> Devices
        {
            get { return opcDevices; }
        }

        public int Count
        {
            get { return opcDevices.Count; }
        }

        public int Add(OPCDevice device)
        {
            opcDevices.Add(device);
            return opcDevices.Count - 1;
        }
    }
}
