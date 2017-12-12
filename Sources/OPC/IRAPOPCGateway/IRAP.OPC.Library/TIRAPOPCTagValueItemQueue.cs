using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.OPC.Entity;

namespace IRAP.OPC.Library
{
    public class TIRAPOPCTagValueItemQueue
    {
        private static TIRAPOPCTagValueItemQueue _instance = null;

        public static TIRAPOPCTagValueItemQueue Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TIRAPOPCTagValueItemQueue();
                return _instance;
            }
        }

        private Queue<TIRAPOPCTagValueItem> queue = new Queue<TIRAPOPCTagValueItem>();
        private object _lockObject = new object();

        private TIRAPOPCTagValueItemQueue() { }

        public void Add(TIRAPOPCTagValueItem item)
        {
            lock (_lockObject)
            {
                queue.Enqueue(item);
            }
        }

        public TIRAPOPCTagValueItem Get()
        {
            lock (_lockObject)
            {
                return queue.Dequeue();
            }
        }
    }
}
