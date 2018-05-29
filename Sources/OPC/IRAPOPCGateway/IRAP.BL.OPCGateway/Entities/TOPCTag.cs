using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;

using IRAP.Global;
using IRAP.OPCGateway.Global;

namespace IRAP.BL.OPCGateway.Entities
{
    /// <summary>
    /// OPC 标签类
    /// </summary>
    public class TOPCTag
    {
        private TTagT20ObjectCollection items =
            new TTagT20ObjectCollection();
        private string tagValue = "";
        private string timeStamp =
            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public int TagLeafID { get; set; }

        public string TagName { get; set; }

        public int TagType { get; set; }

        /// <summary>
        /// 标签值
        /// </summary>
        public string TagValue
        {
            get { return tagValue; }
        }

        public string TagValueTime
        {
            get { return timeStamp; }
        }

        public TTagT20ObjectCollection TestItems
        {
            get { return items; }
        }

        public TOPCDevice Device { get; set; }

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
        public static TOPCTag CreateInstance(XmlNode node)
        {
            if (node.Name != "Tag")
                return null;

            TOPCTag rlt = new TOPCTag();
            rlt.TagLeafID = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "TagLeafID"));
            rlt.TagName = IRAPXMLUtils.GetXMLNodeAttributeValue(node, "TagName");
            rlt.TagType = Tools.ConvertToInt32(IRAPXMLUtils.GetXMLNodeAttributeValue(node, "TagType"));

            rlt.TestItems.Clear();
            foreach (XmlNode child in node.ChildNodes)
            {
                TTagT20Object item = TTagT20Object.CreateInstance(child);
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
}
