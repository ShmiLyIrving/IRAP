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
        
        /// <summary>
        /// 队列中消息的数量
        /// </summary>
        public int QueueItemCount
        {
            get { return queue.Count; }
        }
        
        /// <summary>
        /// 在队列中增加一个消息
        /// </summary>
        /// <param name="item"></param>
        public void Add(TIRAPOPCTagValueItem item)
        {
            lock (_lockObject)
            {
                queue.Enqueue(item);
            }
        }

        /// <summary>
        /// 从队列中取出一个消息
        /// </summary>
        /// <returns></returns>
        public TIRAPOPCTagValueItem Get()
        {
            lock (_lockObject)
            {
                if (queue.Count > 0)
                    return queue.Dequeue();
                else
                    return null;
            }
        }
    }
}
