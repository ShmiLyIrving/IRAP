using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.Threading;

using IRAP.Global;
using IRAP.OPC.Entity;
using IRAP.OPC.Library;
using IRAP.Interface.DCS;

namespace IRAP.BL.OPCGateway
{
    /// <summary>
    /// KepServer 采集到的 Tag 值列表出队处理
    /// </summary>
    internal class TIRAPOPCTagValueQueueOut
    {
        private static TIRAPOPCTagValueQueueOut _instance = null;

        public static TIRAPOPCTagValueQueueOut Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TIRAPOPCTagValueQueueOut();
                return _instance;
            }
        }

        /// <summary>
        /// 消息队列处理最大线程数
        /// </summary>
        private int threadCount = 0;

        private List<TOPCTagValueSettleThread> threads = new List<TOPCTagValueSettleThread>();

        private TIRAPOPCTagValueQueueOut()
        {
            threadCount = LoadFromDataFile(TOPCGatewayGlobal.Instance.ConfigurationFile);

            for (int i = 0; i < threadCount; i++)
            {
                threads.Add(
                    new TOPCTagValueSettleThread(i + 1));
            }
        }

        /// <summary>
        /// 从本地持久化配置文件中获取关于 OPC 消息队列出队处理的配置信息
        /// </summary>
        /// <param name="cfgFileName">本地持久化配置文件名</param>
        /// <returns>消息队列出队处理线程数</returns>
        private int LoadFromDataFile(string cfgFileName)
        {
            int rlt = 10;

            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(cfgFileName);
            }
            catch (Exception error)
            {
                Debug.WriteLine(string.Format("加载[{0}]文件时出错：[{1}]", cfgFileName, error.Message));
                return rlt;
            }

            XmlNode node = xml.SelectSingleNode("root/Queue");
            if (node != null)
            {
                if (node.Attributes["MaxThreadCount"] != null)
                {
                    int.TryParse(node.Attributes["MaxThreadCount"].Value, out rlt);
                }
            }

            return rlt;
        }

        public void Start()
        {
            foreach (TOPCTagValueSettleThread thread in threads)
            {
                thread.Start();
            }
        }

        public void Stop()
        {
            for (int i = threads.Count - 1; i >= 0; i--)
            {
                threads[i].Stop();
            }
        }
    }

    /// <summary>
    /// OPC Tag 值处理线程
    /// </summary>
    internal class TOPCTagValueSettleThread
    {
        private int threadID = 0;

        private bool needStopped = false;

        private Thread thread = null;

        private IRAPESBProducer esbProducer =
            new IRAPESBProducer(
                TOPCGatewayGlobal.Instance.ESBParam.BrokeUri,
                TOPCGatewayGlobal.Instance.ESBParam.QueueName,
                TOPCGatewayGlobal.Instance.ESBParam.Filter,
                TOPCGatewayGlobal.Instance.ESBParam.BrokeUri,
                TOPCGatewayGlobal.Instance.ESBParam.ExCode);
        
        public TOPCTagValueSettleThread(int threadID)
        {
            this.threadID = threadID;
            Debug.WriteLine(string.Format("创建 OPC Tag 值处理线程 [Thread #{0}]", threadID));
        }

        ~TOPCTagValueSettleThread()
        {
            esbProducer = null;
            Debug.WriteLine(string.Format("释放线程 [Thread #{0}]", threadID));
        }

        /// <summary>
        /// 线程开始运行
        /// </summary>
        public void Start()
        {
            if (thread != null)
            {
                if (thread.ThreadState != System.Threading.ThreadState.Unstarted &&
                    thread.ThreadState != System.Threading.ThreadState.Stopped)
                {
                    return;
                }
            }

            thread = new Thread(new ThreadStart(Settle));
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 终止线程的运行
        /// </summary>
        public void Stop()
        {
            needStopped = true;
        }

        private void Settle()
        {
            Debug.WriteLine(
                string.Format(
                    "[线程 #{0}]开始处理 OPC 出队消息",
                    threadID));

            TIRAPOPCTagValueItem value = TIRAPOPCTagValueItemQueue.Instance.Get();
            while (!needStopped || value != null)
            {
                if (value != null)
                {
                    Debug.WriteLine(
                        string.Format(
                            "[线程 #{0}]处理 OPC 出队消息：TagName:[{1}],Value:[{2}]",
                            threadID,
                            value.TagName,
                            value.Value));

                    try
                    {
                        TDC_TestReqBodyTD testData =
                            new TDC_TestReqBodyTD()
                            {
                                T128LeafID = 0,
                                MetricName = "测试项名称",
                                Remark = value.TagName,
                            };

                        long metric = 0;
                        try
                        {
                            Convert.ToInt64(value.Value);
                        }
                        catch { metric = value.Value.ToUpper() == "TRUE" ? 1 : 0; }
                        testData.Metric01 = metric;

                        TDC_TestReqBody request = new TDC_TestReqBody();
                        request.EndTime = value.TimeStamp;

                        request.TestDatas.Add(testData);
                        request.PossibleFailureModes.Add(
                            new TDC_TestReqBodyPFM());
                        request.Recipes.Add(
                            new TDC_TestReqBodyRecipe());
                        TDC_TestContent content =
                            new TDC_TestContent(
                                request,
                                null,
                                null,
                                null);

                        esbProducer.SendToESB(content.GenerateRequestContent());
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

                Thread.Sleep(10);

                value = TIRAPOPCTagValueItemQueue.Instance.Get();
            }

            Debug.WriteLine("[线程 #[{0}]已停止。", threadID);
        }
    }
}
