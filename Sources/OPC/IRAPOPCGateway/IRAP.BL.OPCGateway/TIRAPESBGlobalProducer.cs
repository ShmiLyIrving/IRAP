using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;

namespace IRAP.BL.OPCGateway
{
    public class TIRAPESBGlobalProducer
    {
        private static TIRAPESBGlobalProducer _instance = null;

        public static TIRAPESBGlobalProducer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TIRAPESBGlobalProducer();
                return _instance;
            }
        }

        private IRAPESBProducer producer;
        private object lockObj = new object();

        private TIRAPESBGlobalProducer()
        {
            producer =
                new IRAPESBProducer(
                    TOPCGatewayGlobal.Instance.ESBParam.BrokeUri,
                    TOPCGatewayGlobal.Instance.ESBParam.QueueName,
                    TOPCGatewayGlobal.Instance.ESBParam.Filter,
                    TOPCGatewayGlobal.Instance.ESBParam.BrokeUri,
                    TOPCGatewayGlobal.Instance.ESBParam.ExCode);
        }

        public void SendToESB(string msgString)
        {
            lock (lockObj)
            {
                if (producer != null)
                {
                    producer.SendToESB(msgString);
                }
            }
        }
    }
}
