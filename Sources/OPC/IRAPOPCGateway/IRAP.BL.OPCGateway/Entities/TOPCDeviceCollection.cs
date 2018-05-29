using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.BL.OPCGateway.Entities
{
    /// <summary>
    /// OPC 设备集合类
    /// </summary>
    public class TOPCDeviceCollection
    {
        private List<TOPCDevice> items = new List<TOPCDevice>();
        private Dictionary<string, TOPCDevice> idxDevices = 
            new Dictionary<string, TOPCDevice>();

        public TOPCDevice this[int index]
        {
            get
            {
                if (index >= 0 && index < items.Count)
                    return items[index];
                else
                    return null;
            }
        }

        public int Count { get { return items.Count; } }

        public Dictionary<string, TOPCDevice> IndexDevices
        {
            get { return idxDevices; }
            set { idxDevices = value; }
        }

        public void Add(TOPCDevice item)
        {
            if (item != null)
            {
                items.Add(item);
                idxDevices.Add(
                    string.Format(
                        "{1}",
                        item.T133Code),
                    item);
            }
        }

        public void Remove(TOPCDevice item)
        {
            string key =
                string.Format(
                    "{1}",
                    item.T133Code);
            if (idxDevices.ContainsKey(key))
                idxDevices.Remove(key);

            items.Remove(item);
        }

        public void Clear()
        {
            idxDevices.Clear();
            items.Clear();
        }
    }
}

