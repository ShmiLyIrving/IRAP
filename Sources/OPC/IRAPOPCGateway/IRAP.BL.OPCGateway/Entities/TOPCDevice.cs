using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;
using IRAP.Interface.DCS;
using IRAP.OPCGateway.Global;
using IRAP.WebAPI.Entities.MES;

namespace IRAP.BL.OPCGateway.Entities
{
    /// <summary>
    /// OPC 设备类
    /// </summary>
    public class TOPCDevice : TRESPOPCServerTagList
    {
        private TOPCTagCollection tags = new TOPCTagCollection();
        private Dictionary<string, TOPCTag> indexTags =
            new Dictionary<string, TOPCTag>();

        public TOPCTagCollection Tags
        {
            get { return tags; }
        }

        public Dictionary<string, TOPCTag> IndexTags
        {
            get { return IndexTags; }
        }

        /// <summary>
        /// 根据 TRESPOPCServerTagList 对象创建 TIRAPOPCDevice 实例
        /// </summary>
        /// <param name="item">TRESPOPCServerTagList 对象</param>
        /// <returns></returns>
        public static TOPCDevice CreateInstance(TRESPOPCServerTagList item)
        {
            if (item == null)
                return null;

            TOPCDevice rlt =
                TGeneric.Mapper<TOPCDevice, TRESPOPCServerTagList>(item);
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
                        TOPCTag tag =
                            TOPCTag.CreateInstance(child);
                        if (tag != null)
                        {
                            tag.Device = rlt;
                            rlt.Tags.Add(tag);
                            rlt.IndexTags.Add(
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
        public void SendSimgleTag(TOPCTag tag)
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
        public void SendBatchTags(TOPCTag tag)
        {
            TDC_TestReqBody request = new TDC_TestReqBody();
            request.EndTime = tag.TagValueTime;
            request.WIPStationCode = tag.Device.T133Code;
            request.PossibleFailureModes.Add(new TDC_TestReqBodyPFM());
            request.Recipes.Add(new TDC_TestReqBodyRecipe());

            for (int i = 0; i < tags.Count; i++)
            {
                TOPCTag batchTag = tags[i];
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
}
