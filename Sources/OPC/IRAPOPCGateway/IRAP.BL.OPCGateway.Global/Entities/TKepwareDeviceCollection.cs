using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.BL.OPCGateway.Global.Entities
{
    public class TKepwareDeviceCollection
    {
        private static object lockObject = new object();

        private List<TKepwareDevice> items = new List<TKepwareDevice>();
        private Dictionary<string, TKepwareDevice> idxItems =
            new Dictionary<string, TKepwareDevice>();

        public TKepwareDevice this[int index]
        {
            get
            {
                if (index >= 0 && index < items.Count)
                {
                    return items[index];
                }
                else
                {
                    return null;
                }
            }
        }

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public int Add(TKepwareDevice item)
        {
            lock (lockObject)
            {
                if (item != null)
                {
                    items.Add(item);
                }
            }

            return items.Count;
        }

        public int Add(string kepServAddr, string kepServName, string itemTag)
        {
            lock (lockObject)
            {
                if (!string.IsNullOrEmpty(itemTag))
                {
                    if (!itemTag.Contains("._"))
                    {
                        string[] splitTagName = itemTag.Split('.');
                        if (splitTagName.Length > 2)
                        {
                            TKepwareDevice device = null;
                            string tagIdxKey = $"{splitTagName[0]}.{splitTagName[1]}";
                            idxItems.TryGetValue(tagIdxKey, out device);
                            if (device == null)
                            {
                                device =
                                    new TKepwareDevice()
                                    {
                                        KepServAddr = kepServAddr,
                                        KepServName = kepServName,
                                        KepServChannel = splitTagName[0],
                                        KepServDevice = splitTagName[1],
                                    };

                                device.Tags.Add(itemTag);

                                items.Add(device);
                                idxItems.Add(tagIdxKey, device);
                            }
                            else
                            {
                                device.Tags.Add(itemTag);
                            }
                        }
                    }
                }
            }

            return items.Count;
        }

        public int Remove(TKepwareDevice item)
        {
            lock (lockObject)
            {
                bool successed = false;
                do
                {
                    successed = items.Remove(item);
                    successed = 
                        idxItems.Remove(
                            $"{item.KepServChannel}.{item.KepServDevice}");
                } while (successed);
            }

            return items.Count;
        }

        public void Clear()
        {
            items.Clear();
            idxItems.Clear();
        }

        public TKepwareDevice Get(string channel, string name)
        {
            string strKeyValue = $"{channel}.{name}";
            TKepwareDevice rlt = null;
            idxItems.TryGetValue(strKeyValue, out rlt);
            return rlt;
        }
    }
}
