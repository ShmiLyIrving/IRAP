using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml;

using IRAP.Global;
using IRAP.WebAPI.Enums;
using IRAP.WebAPI.Entities.MES;
using IRAP.WebAPI.Exchange.MES;
using IRAP.Interface.DCS;
using IRAP.OPCGateway.Global;

namespace IRAP.OPC.Entity.IRAPServer
{
    public class TIRAPOPCDevices
    {
        private static TIRAPOPCDevices _instance = null;

        public static TIRAPOPCDevices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TIRAPOPCDevices();
                return _instance;
            }
        }

        private object lockObject = new object();

        private string webAPIUrl = "http://127.0.0.1:55552/";
        private TContentType contentType = TContentType.JSON;
        private string clientID = "MESDeveloper";

        private TIRAPOPCDeviceCollection devices = new TIRAPOPCDeviceCollection();

        private TIRAPOPCDevices() { }

        /// <summary>
        /// OPC 设备集合
        /// </summary>
        public TIRAPOPCDeviceCollection Devices
        {
            get { return devices; }
        }

        /// <summary>
        /// 设置 WebAPI 调用参数
        /// </summary>
        /// <param name="url">WebAPI 地址</param>
        /// <param name="contentType">报文类型：JSON, XML</param>
        /// <param name="clientID">客户端标识</param>
        public void SetWebAPIParams(string url, string contentType, string clientID)
        {
            webAPIUrl = url;
            try { this.contentType = (TContentType)Enum.Parse(typeof(TContentType), contentType); }
            catch { this.contentType = TContentType.JSON; }
            this.clientID = clientID;
        }

        /// <summary>
        /// 获取数据库中注册的 OPC 设备及标签
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void GetDevices(int communityID, long sysLogID)
        {
            TGetOPCServerTagList exchange = new TGetOPCServerTagList(webAPIUrl, contentType, clientID);
            exchange.Request =
                new TREQOPCServerTagList()
                {
                    CommunityID = communityID,
                    SysLogID = sysLogID,
                };

            if (!exchange.Do())
            {
                Debug.WriteLine(
                    string.Format(
                        "({0}){1}",
                        exchange.Error.ErrCode,
                        exchange.Error.ErrText),
                    "");
            }
            else
            {
                devices.Clear();
                foreach (TRESPOPCServerTagList item in exchange.Response.Rows)
                {
                    TIRAPOPCDevice device =
                        TIRAPOPCDevice.CreateInstance(item);
                    if (device != null)
                        devices.Add(device);
                }
                devices.IndexTags =
                    devices.IndexTags.OrderBy(
                        p => p.Key).ToDictionary(
                            p => p.Key, o => o.Value);
            }
        }

        /// <summary>
        /// 根据传入的 TagName 查找系统中已注册的 Tag 对象。
        /// 如果找到，则返回 TIRAPOPCTag 对象；如果未找到，则返回 null
        /// </summary>
        /// <param name="tagName">TagName</param>
        /// <returns></returns>
        public TIRAPOPCTag FindOPCTagItem(string tagName)
        {
            TIRAPOPCTag rlt = null;
            if (!devices.IndexTags.TryGetValue(tagName, out rlt))
                rlt = null;

            return rlt;
        }
    }

    /// <summary>
    /// OPC 设备类
    /// </summary>
    public class TIRAPOPCDevice : TRESPOPCServerTagList
    {
        private TIRAPOPCTagCollection items = new TIRAPOPCTagCollection();
        private Dictionary<string, TIRAPOPCTag> indexTags = 
            new Dictionary<string, TIRAPOPCTag>();

        public TIRAPOPCTagCollection Tags { get { return items; } }
        public Dictionary<string, TIRAPOPCTag> TagIndex { get { return indexTags; } }


        /// <summary>
        /// 根据 TRESPOPCServerTagList 对象创建 TIRAPOPCDevice 实例
        /// </summary>
        /// <param name="item">TRESPOPCServerTagList 对象</param>
        /// <returns></returns>
        public static TIRAPOPCDevice CreateInstance(TRESPOPCServerTagList item)
        {
            if (item == null)
                return null;

            TIRAPOPCDevice rlt =
                TGeneric.Mapper<TIRAPOPCDevice, TRESPOPCServerTagList>(item);
            if (rlt.TagList != "")
            {
                XmlDocument xml = new XmlDocument();
                try { xml.LoadXml(rlt.TagList); }
                catch { return rlt; }

                XmlNode root = xml.SelectSingleNode("Parameters");
                if (root != null)
                {
                    foreach (XmlNode child in root.ChildNodes)
                    {
                        TIRAPOPCTag tag =
                            TIRAPOPCTag.CreateInstance(child);
                        if (tag != null)
                        {
                            tag.Device = rlt;
                            rlt.Tags.Add(tag);
                            rlt.TagIndex.Add(
                                string.Format(
                                    "{0}.{1}", 
                                    rlt.ServerName, 
                                    tag.TagName), 
                                tag);
                        }
                    }
                }
            }

            return rlt;
        }

        /// <summary>
        /// 发送单个 Tag 的值到 ESB 中
        /// </summary>
        /// <param name="tag"></param>
        public void SendSimgleTag(TIRAPOPCTag tag)
        {
            TDC_TestReqBody request = new TDC_TestReqBody();
            request.EndTime = tag.TagValueTime;
            request.WIPStationCode = tag.Device.T133Code;
            request.PossibleFailureModes.Add(new TDC_TestReqBodyPFM());
            request.Recipes.Add(new TDC_TestReqBodyRecipe());

            switch (tag.TestItems.Count)
            {
                case 1:
                    request.TestDatas.Add(
                        new TDC_TestReqBodyTD()
                        {
                            T128LeafID = tag.TestItems[0].T20LeafID,
                            MetricName = tag.TestItems[0].ParameterName,
                            Remark = tag.TagName,
                            Metric01 = tag.TagValue,
                        });
                    break;
                default:
                    for (int i = 0; i < tag.TestItems.Count; i++)
                    {
                        request.TestDatas.Add(
                            new TDC_TestReqBodyTD()
                            {
                                T128LeafID = tag.TestItems[i].T20LeafID,
                                MetricName = tag.TestItems[i].ParameterName,
                                Remark = tag.TagName,
                                Metric01 = tag.TagValue.Substring(
                                    tag.TestItems[i].StartPosition,
                                    tag.TestItems[i].EndPosition - tag.TestItems[i].StartPosition + 1),
                            });
                    }
                    break;
            }
            TDC_TestContent content =
                new TDC_TestContent(
                    request,
                    null,
                    null,
                    null);

            TIRAPESBGlobalProducer.Instance.SendToESB(content.GenerateRequestContent());
        }

        /// <summary>
        /// 发送当前设备中所有 TagType=1 的 Tag 值到 ESB 中
        /// </summary>
        public void SendBatchTags(TIRAPOPCTag tag)
        {
            TDC_TestReqBody request = new TDC_TestReqBody();
            request.EndTime = tag.TagValueTime;
            request.WIPStationCode = tag.Device.T133Code;
            request.PossibleFailureModes.Add(new TDC_TestReqBodyPFM());
            request.Recipes.Add(new TDC_TestReqBodyRecipe());

            for (int i = 0; i < items.Count; i++)
            {
                TIRAPOPCTag batchTag = items[i];
                if (batchTag.TagType == 1)
                {
                    switch (batchTag.TestItems.Count)
                    {
                        case 1:
                            request.TestDatas.Add(
                                new TDC_TestReqBodyTD()
                                {
                                    T128LeafID = batchTag.TestItems[0].T20LeafID,
                                    MetricName = batchTag.TestItems[0].ParameterName,
                                    Remark = batchTag.TagName,
                                    Metric01 = batchTag.TagValue,
                                });
                            break;
                        default:
                            for (int j = 0; j < batchTag.TestItems.Count; j++)
                            {
                                request.TestDatas.Add(
                                    new TDC_TestReqBodyTD()
                                    {
                                        T128LeafID = batchTag.TestItems[j].T20LeafID,
                                        MetricName = batchTag.TestItems[j].ParameterName,
                                        Remark = batchTag.TagName,
                                        Metric01 = batchTag.TagValue.Substring(
                                            batchTag.TestItems[j].StartPosition,
                                            batchTag.TestItems[j].EndPosition - batchTag.TestItems[j].StartPosition + 1),
                                    });
                            }
                            break;
                    }
                }
            }
            TDC_TestContent content =
                new TDC_TestContent(
                    request,
                    null,
                    null,
                    null);

            TIRAPESBGlobalProducer.Instance.SendToESB(content.GenerateRequestContent());
        }
    }

    /// <summary>
    /// OPC 设备集合类
    /// </summary>
    public class TIRAPOPCDeviceCollection
    {
        private List<TIRAPOPCDevice> items = new List<TIRAPOPCDevice>();
        private Dictionary<string, TIRAPOPCTag> indexTags =
            new Dictionary<string, TIRAPOPCTag>();

        public TIRAPOPCDevice this[int index]
        {
            get
            {
                if (index >= 0 && index < items.Count)
                    return items[index];
                else
                    return null;
            }
        }

        public int Count { get { return items.Count; } }

        public Dictionary<string, TIRAPOPCTag> IndexTags
        {
            get { return indexTags; }
            set { indexTags = value; }
        }

        public void Add(TIRAPOPCDevice item)
        {
            if (item != null)
            {
                items.Add(item);
                
                foreach (KeyValuePair<string, TIRAPOPCTag> idxItem in item.TagIndex)
                {
                    indexTags.Add(idxItem.Key, idxItem.Value);
                }
            }
        }

        public void Remove(TIRAPOPCDevice item)
        {
            bool successed = false;
            do
            {
                successed = items.Remove(item);
            } while (successed);
        }

        public void Clear()
        {
            items.Clear();
        }
    }

    /// <summary>
    /// OPC 标签类
    /// </summary>
    public class TIRAPOPCTag
    {
        private TIRAPTagT20ObjectCollection items = new TIRAPTagT20ObjectCollection();
        private string tagValue = "";
        private string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public int TagLeafID { get; set; }
        public string TagName { get; set; }
        public int TagType { get; set; }
        /// <summary>
        /// 标签值
        /// </summary>
        public string TagValue { get { return tagValue; } }
        public string TagValueTime { get { return timeStamp; } }
        public TIRAPTagT20ObjectCollection TestItems { get { return items; } }
        public TIRAPOPCDevice Device { get; set; }
        /// <summary>
        /// KepwareServer 标签值回写句柄
        /// </summary>
        public int ServerHandle { get; set; }
        /// <summary>
        /// 回写 Tag 值委托
        /// </summary>
        public WriteTagValueHandle WriteTagValueMethod { get; set; }

        /// <summary>
        /// 根据 XMLNode 创建 TIRAPOPCTag 实例
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static TIRAPOPCTag CreateInstance(XmlNode node)
        {
            if (node.Name != "Tag")
                return null;

            TIRAPOPCTag rlt = new TIRAPOPCTag();
            rlt.TagLeafID = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "TagLeafID"));
            rlt.TagName = IRAPXMLUtils.GetXMLNodeAttributeValue(node, "TagName");
            rlt.TagType = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "TagType"));

            rlt.TestItems.Clear();
            foreach (XmlNode child in node.ChildNodes)
            {
                TIRAPTagT20Object item = TIRAPTagT20Object.CreateInstance(child);
                if (item != null)
                    rlt.TestItems.Add(item);
            }

            return rlt;
        }

        public void SetTagValue(string value, string timeStamp)
        {
            tagValue = value;
            this.timeStamp = timeStamp;

            if (Device != null)
            {
                switch (TagType)
                {
                    case 0:             // 更改实例中的值，同时发送 ESB 消息
                        Device.SendSimgleTag(this);
                        break;
                    case 2:             // 发送 ESB 消息
                        if (Tools.ConvertToBoolean(tagValue))
                        {
                            DateTime start1 = DateTime.Now;
                            Device.SendBatchTags(this);
                            TimeSpan sendTimeSpan = DateTime.Now - start1;

                            if (WriteTagValueMethod != null)
                            {
                                int errCode = 0;
                                string errText = "";
                                DateTime start2 = DateTime.Now;
                                WriteTagValueMethod(ServerHandle, "0", out errCode, out errText);
                                Console.WriteLine(
                                    string.Format(
                                        "[{0}]ErrCode={1}|ErrText={2}|发送消息花费时间={3}秒|回写花费时间={4}秒",
                                        DateTime.Now.ToString("HH:mm:ss.fff"),
                                        errCode,
                                        errText,
                                        sendTimeSpan.TotalSeconds,
                                        (DateTime.Now - start2).TotalSeconds));
                                Debug.WriteLineIf(errCode != 0, errText);
                            }
                        }
                        break;
                }
            }
        }

        public void WriteTagValueBack(
            string value, 
            out int errCode, 
            out string errText)
        {
            if (WriteTagValueMethod != null)
            {
                DateTime start = DateTime.Now;
                WriteTagValueMethod(ServerHandle, value, out errCode, out errText);
                Console.WriteLine(
                    string.Format(
                        "[{0}]ErrCode={1}|ErrText={2}|回写花费时间={3}秒",
                        DateTime.Now.ToString("HH:mm:ss.fff"),
                        errCode,
                        errText,
                        (DateTime.Now - start).TotalSeconds));
            }
            else
            {
                errCode = -1;
                errText = "没有设置回写事件句柄，无法回写";
            }
        }
    }

    /// <summary>
    /// OPC 标签集合类
    /// </summary>
    public class TIRAPOPCTagCollection
    {
        private List<TIRAPOPCTag> items = new List<TIRAPOPCTag>();

        public TIRAPOPCTag this[int index]
        {
            get
            {
                if (index >= 0 && index < items.Count)
                    return items[index];
                else
                    return null;
            }
        }

        public int Count { get { return items.Count; } }

        public void Add(TIRAPOPCTag item)
        {
            if (item != null)
                items.Add(item);
        }

        public void Remove(TIRAPOPCTag item)
        {
            bool successed = false;
            do
            {
                successed = items.Remove(item);
            } while (successed);
        }

        public void Clear()
        {
            items.Clear();
        }
    }

    /// <summary>
    /// OPC 标签对应检验项类
    /// </summary>
    public class TIRAPTagT20Object
    {
        public int Ordinal { get; set; }
        public int T20LeafID { get; set; }
        public string ParameterName { get; set; }
        public long LowLimit { get; set; }
        public string Criterion { get; set; }
        public long HighLimit { get; set; }
        public int Scale { get; set; }
        public string UnitOfMeasure { get; set; }
        public int RecordingMode { get; set; }
        public int SamplingCycle { get; set; }
        public int RTDBDSLinkID { get; set; }
        public string RTDBTagName { get; set; }
        public int Reference { get; set; }
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }

        public static TIRAPTagT20Object CreateInstance(XmlNode node)
        {
            if (node.Name != "Row")
            {
                return null;
            }

            TIRAPTagT20Object rlt = new TIRAPTagT20Object()
            {
                Ordinal = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "Ordinal"), 0),
                T20LeafID = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "T20LeafID"), 0),
                ParameterName = IRAPXMLUtils.GetXMLNodeAttributeValue(node, "ParameterName"),
                LowLimit = Tools.ConvertToInt64(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "LowLimit"), 0),
                Criterion = IRAPXMLUtils.GetXMLNodeAttributeValue(node, "Criterion"),
                HighLimit = Tools.ConvertToInt64(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "HighLimit"), 0),
                Scale = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "Scale"), 0),
                UnitOfMeasure = IRAPXMLUtils.GetXMLNodeAttributeValue(node, "UnitOfMeasure"),
                RecordingMode = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "RecordingMode"), 0),
                SamplingCycle = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "SamplingCycle"), 0),
                RTDBDSLinkID = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "RTDBDSLinkID"), 0),
                RTDBTagName = IRAPXMLUtils.GetXMLNodeAttributeValue(node, "RTDBTagName"),
                Reference = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "Reference"), 0),
                StartPosition = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "StartPosition"), 0),
                EndPosition = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "EndPosition"), 0),
            };

            return rlt;
        }
    }

    /// <summary>
    /// OPC 标签对应检验项集合类
    /// </summary>
    public class TIRAPTagT20ObjectCollection
    {
        private List<TIRAPTagT20Object> items = new List<TIRAPTagT20Object>();

        public TIRAPTagT20Object this[int index]
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
            get { return items.Count; }
        }

        public void Add(TIRAPTagT20Object item)
        {
            if (item != null)
                items.Add(item);
        }

        public void Remove(TIRAPTagT20Object item)
        {
            bool successed = true;
            do
            {
                successed = items.Remove(item);
            } while (successed);
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
