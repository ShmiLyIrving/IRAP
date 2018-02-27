using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

using IRAP.OPC.Entity;
using IRAP.OPC.Entity.IRAPServer;
using IRAP.Global;
using IRAP.OPCGateway.Global;

namespace IRAP.BL.OPCGateway
{
    public class TOPCTagValueThread
    {
        private static int count;
        private static long AllThreadID;
        private long threadID;
        private Guid guid = Guid.NewGuid();
        private TIRAPOPCTagValueItem item = null;

        private IRAPESBProducer esbProducer =
            new IRAPESBProducer(
                TOPCGatewayGlobal.Instance.ESBParam.BrokeUri,
                TOPCGatewayGlobal.Instance.ESBParam.QueueName,
                TOPCGatewayGlobal.Instance.ESBParam.Filter,
                TOPCGatewayGlobal.Instance.ESBParam.BrokeUri,
                TOPCGatewayGlobal.Instance.ESBParam.ExCode);

        public TOPCTagValueThread(TIRAPOPCTagValueItem item)
        {
            count++;
            AllThreadID++;
            threadID = AllThreadID;

            this.item = item;
            Debug.WriteLine(string.Format("创建线程对象，当前线程号[#{0}]，一共有 [{1}] 个线程对象", threadID, count));
        }

        ~TOPCTagValueThread()
        {
            count--;
            esbProducer = null;
            Debug.WriteLine(string.Format("释放线程 [#{0}] 的对象，还剩余 [{1}] 个线程对象", threadID, count));
        }

        private void Settle()
        {
            try
            {
                string fullTagName =
                    string.Format(
                        "{0}.{1}",
                        item.KepServerName,
                        item.TagName);
                Debug.WriteLine(string.Format("TagName:[{0}]", fullTagName));

                TIRAPOPCTag tag =
                    TIRAPOPCDevices.Instance.FindOPCTagItem(fullTagName);

                if (tag != null)
                {
                    Console.WriteLine(
                        string.Format(
                            "[线程 #{0}]处理 OPC 消息：TagName:[{1}],Value:[{2}]",
                            threadID,
                            item.TagName,
                            item.Value));
                    //WriteLog.Instance.Write(
                    //    guid,
                    //    string.Format(
                    //        "[线程 #{0}]处理 OPC 消息：TagName:[{1}],Value:[{2}]",
                    //        threadID,
                    //        item.TagName,
                    //        item.Value));
                    tag.SetTagValue(item.Value, item.TimeStamp);
                }
                else
                {
                    Debug.WriteLine(
                        string.Format(
                            "KepTag:未注册[{0}]",
                            fullTagName));
                }
            }
            catch (Exception error)
            {
                string errCode = "";
                string errText = "";

                if (error.Data["ErrCode"] != null)
                    errCode = error.Data["ErrCode"].ToString();
                if (error.Data["ErrText"] != null)
                    errText = error.Data["ErrText"].ToString();
                else
                    errText = error.Message;

                Debug.WriteLine(
                    string.Format(
                        "[线程 #{0}]处理消息时出错：[({1}){2}]",
                        threadID,
                        errCode,
                        errText));
            }
        }

        public void Start()
        {
            Thread thread = new Thread(new ThreadStart(Settle));
            thread.IsBackground = true;
            thread.Start();
            thread.Join();
            GC.Collect();
        }
    }
}
