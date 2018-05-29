using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.BL.OPCGateway.Entities
{
    /// <summary>
    /// OPC 标签对应检验项集合类
    /// </summary>
    public class TTagT20ObjectCollection
    {
        private List<TTagT20Object> items =
            new List<TTagT20Object>();

        public TTagT20Object this[int index]
        {
            get
            {
                if (index >= 0 && index < items.Count)
                    return items[index];
                else
                    return null;
            }
        }

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public void Add(TTagT20Object item)
        {
            if (item != null)
                items.Add(item);
        }

        public bool Remove(TTagT20Object item)
        {
            return items.Remove(item);
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
