using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.BL.OPCGateway.Global.Entities
{
    public class TKepwareServerCollection
    {
        private List<TKepwareServer> items =
            new List<TKepwareServer>();
        private Dictionary<string, TKepwareServer> idxByAddress =
            new Dictionary<string, TKepwareServer>();

        public TKepwareServer this[int index]
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
            get { return items.Count; }
        }

        public TKepwareServer ByAddress(string addr)
        {
            TKepwareServer rlt = null;
            idxByAddress.TryGetValue(addr, out rlt);
            return rlt;
        }

        public int Add(TKepwareServer item)
        {
            if (item != null)
            {
                TKepwareServer oldServ = ByAddress(item.Address);
                if (oldServ != null)
                {
                    Remove(oldServ);
                }

                items.Add(item);
                idxByAddress.Add(item.Address, item);
            }

            return items.Count;
        }

        public int Remove(TKepwareServer item)
        {
            bool successed = false;
            do
            {
                successed = items.Remove(item);
                successed = idxByAddress.Remove(item.Address);
            } while (successed);

            return items.Count;
        }
        
        public void Clear()
        {
            items.Clear();
            idxByAddress.Clear();
        }
    }
}
