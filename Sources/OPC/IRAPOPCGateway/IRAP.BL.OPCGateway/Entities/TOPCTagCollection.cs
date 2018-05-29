using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.BL.OPCGateway.Entities
{
    /// <summary>
    /// OPC 标签集合类
    /// </summary>
    public class TOPCTagCollection
    {
        private List<TOPCTag> tags = new List<TOPCTag>();
        private Dictionary<string, TOPCTag> indexTags =
            new Dictionary<string, TOPCTag>();

        public TOPCTag this[int index]
        {
            get
            {
                if (index >= 0 && index < tags.Count)
                    return tags[index];
                else
                    return null;
            }
        }

        public int Count
        {
            get { return tags.Count; }
        }

        public Dictionary<string, TOPCTag> IndexTags
        {
            get { return indexTags; }
        }

        public void Add(TOPCTag item)
        {
            if (item != null)
            {
                tags.Add(item);
                indexTags.Add(item.TagName, item);
            }
        }

        public void Remove(TOPCTag item)
        {
            indexTags.Remove(item.TagName);
            tags.Remove(item);
        }

        public void Clear()
        {
            indexTags.Clear();
            tags.Clear();
        }
    }
}
