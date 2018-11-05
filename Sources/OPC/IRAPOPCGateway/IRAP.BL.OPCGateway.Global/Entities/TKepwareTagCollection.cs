using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.BL.OPCGateway.Global.Entities
{
    public class TKepwareTagCollection
    {
        private object lockObject = new object();

        private List<TKepwareTag> items =
            new List<TKepwareTag>();

        public TKepwareTag this[int index]
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

        public int Add(TKepwareTag item)
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

        public int Add(string itemTag)
        {
            lock (lockObject)
            {
                if (!string.IsNullOrEmpty(itemTag))
                {
                    if (!itemTag.Contains("._"))
                    {
                        items.Add(
                            new TKepwareTag()
                            {
                                TagName = itemTag,
                            });
                    }
                }
            }

            return items.Count;
        }

        public int Remove(TKepwareTag item)
        {
            lock (lockObject)
            {
                bool successed = false;
                do
                {
                    successed = items.Remove(item);
                } while (successed);
            }

            return items.Count;
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
