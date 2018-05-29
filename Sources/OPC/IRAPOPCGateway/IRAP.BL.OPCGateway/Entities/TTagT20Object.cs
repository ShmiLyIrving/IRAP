using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.BL.OPCGateway.Entities
{
    /// <summary>
    /// OPC 标签对应检验项类
    /// </summary>
    public class TTagT20Object
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

        public static TTagT20Object CreateInstance(XmlNode node)
        {
            if (node.Name != "Row")
                return null;

            TTagT20Object rlt = new TTagT20Object()
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
}
