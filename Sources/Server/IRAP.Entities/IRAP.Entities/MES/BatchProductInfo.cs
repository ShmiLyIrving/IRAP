using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Entities.MES
{
    public class BatchProductInfo
    {
        public BatchProductInfo()
        {
            BatchStartDate = DateTime.Now;
        }

        /// <summary>
        /// 热定型容次号
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 操作工工号
        /// </summary>
        public string OperatorCode { get; set; }
        /// <summary>
        /// 操作工姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 生产开始时间
        /// </summary>
        public DateTime BatchStartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string BatchEndDate { get; set; }
        /// <summary>
        /// 班次代码
        /// </summary>
        public string T126Code { get; set; }
        /// <summary>
        /// 班次信息
        /// </summary>
        public string T126Name { get; set; }
        /// <summary>
        /// 环别叶标识
        /// </summary>
        public int T131LeafID { get; set; }
        /// <summary>
        /// 环别代码
        /// </summary>
        public string T131Code { get; set; }
        /// <summary>
        /// 环别名称
        /// </summary>
        public string T131Name { get; set; }
        /// <summary>
        /// 正在生产的工单信息
        /// [MethodItem]
        ///     [Row FactID="" PWONo="" T102LeafID="" T102Code="" 
        ///         T102Name="" WIPCode="" LotNumber="" SerialNumber="" 
        ///         AltWIPCode="" Texture="" BatchLot="" Qty=""/]
        /// [/MethodItem]
        /// </summary>
        public string BatchDataXML { get; set; }
        /// <summary>
        /// 待检验的检验标准信息列表  --暂时从前台调用其他接口获取
        /// </summary>
        public string MethodDataXML { get; set; }
        /// <summary>
        /// 是否正在生产
        /// </summary>
        public int InProduction { get; set; }

        public BatchProductInfo Clone()
        {
            return MemberwiseClone() as BatchProductInfo;
        }

        public List<EntityBatchPWO> GetPWOsFromXML()
        {
            List<EntityBatchPWO> rlt = new List<EntityBatchPWO>();

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(BatchDataXML);

                foreach (XmlNode node in doc.SelectNodes("MethodItem/Row"))
                {
                    EntityBatchPWO pwo = new EntityBatchPWO();
                    if (node.Attributes["FactID"] != null)
                        pwo.FactID = Tools.ConvertToInt64(node.Attributes["FactID"].Value);
                    if (node.Attributes["PWONo"] != null)
                        pwo.PWONo = node.Attributes["PWONo"].Value;
                    if (node.Attributes["T102LeafID"] != null)
                        pwo.T102LeafID = Tools.ConvertToInt32(node.Attributes["T102LeafID"].Value);
                    if (node.Attributes["T102Code"] != null)
                        pwo.T102Code = node.Attributes["T102Code"].Value;
                    if (node.Attributes["T102Name"] != null)
                        pwo.T102Name = node.Attributes["T102Name"].Value;
                    if (node.Attributes["WIPCode"] != null)
                        pwo.WIPCode = node.Attributes["WIPCode"].Value;
                    if (node.Attributes["LotNumber"] != null)
                        pwo.LotNumber = node.Attributes["LotNumber"].Value;
                    if (node.Attributes["SerialNumber"] != null)
                        pwo.SerialNumber = node.Attributes["SerialNumber"].Value;
                    if (node.Attributes["AltWIPCode"] != null)
                        pwo.AltWIPCode = node.Attributes["AltWIPCode"].Value;
                    if (node.Attributes["Texture"] != null)
                        pwo.Texture = node.Attributes["Texture"].Value;
                    if (node.Attributes["BatchLot"] != null)
                        pwo.BatchLot = node.Attributes["BatchLot"].Value;
                    if (node.Attributes["Qty"] != null)
                        pwo.Quantity = Tools.ConvertToInt64(node.Attributes["Qty"].Value);

                    rlt.Add(pwo);
                }
            }
            catch
            {
                rlt.Clear();
            }

            return rlt;
        }
    }
}
