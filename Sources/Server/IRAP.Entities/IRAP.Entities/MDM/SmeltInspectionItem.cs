using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;
using IRAPShared;
using System.Reflection;

namespace IRAP.Entities.MDM
{
    public class SmeltInspectionItem
    {
        private string dataXML = "";
        private List<SmeltInspectionItemValue> values =
            new List<SmeltInspectionItemValue>();

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 检验项目叶标识
        /// </summary>
        public int T20LeafID { get; set; }
        /// <summary>
        /// 检验项目代码
        /// </summary>
        public string T20Code { get; set; }
        /// <summary>
        /// 检验项目名称
        /// </summary>
        public string T20Name { get; set; }
        /// <summary>
        /// 默认放大数量级
        /// </summary>
        public int Scale { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }
        /// <summary>
        /// 历史记录
        /// [RF25][Row FactID="" Metric01=""/][/RF25]
        /// </summary>
        public string DataXML
        {
            get { return dataXML; }
            set
            {
                dataXML = value;

                //values.Clear();
                //XmlDocument xml = new XmlDocument();
                //try
                //{
                //    xml.LoadXml(value);
                //    XmlNode root = xml.SelectSingleNode("RF25");
                //    foreach (XmlNode node in root.ChildNodes)
                //    {
                //        if (node.Name == "Row")
                //        {
                //            SmeltInspectionItemValue itemValue =
                //                new SmeltInspectionItemValue();

                //            if (node.Attributes["FactID"] != null)
                //                itemValue.FactID = Tools.ConvertToInt64(node.Attributes["FactID"].Value);
                //            if (node.Attributes["Metric01"] != null)
                //                itemValue.Metric01 = Tools.ConvertToInt32(node.Attributes["Metric01"].Value);
                //            itemValue.Scale = Scale;
                //            itemValue.UnitOfMeasure = UnitOfMeasure;

                //            values.Add(itemValue);
                //        }
                //    }
                //}
                //catch(Exception e)
                //{
                //    e.Message.ToString();
                //}
            }
        }

        [IRAPORMMap(ORMMap = false)]
        public List<SmeltInspectionItemValue> ItemValues
        {
            get { return values; }
        }

        public void ResolveDataXML()
        {
            string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        MethodBase.GetCurrentMethod().DeclaringType.FullName,
                        MethodBase.GetCurrentMethod().Name);

            values.Clear();

            XmlDocument xdoc = new XmlDocument();
            try
            {
                xdoc.LoadXml(DataXML);
            }
            catch (XmlException err)
            {
                WriteLog.Instance.Write(err.Message, strProcedureName);
                return;
            }

            XmlNode root = xdoc.SelectSingleNode("RF25");
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == "Row")
                {
                    SmeltInspectionItemValue itemValue =
                        new SmeltInspectionItemValue();

                    if (node.Attributes["FactID"] != null)
                        itemValue.FactID = Tools.ConvertToInt64(node.Attributes["FactID"].Value);
                    if (node.Attributes["Metric01"] != null)
                        itemValue.Metric01 = Tools.ConvertToInt32(node.Attributes["Metric01"].Value);
                    itemValue.Scale = Scale;
                    itemValue.UnitOfMeasure = UnitOfMeasure;

                    values.Add(itemValue);
                }
            }
        }
    }

    public class SmeltInspectionItemValue
    {
        private Quantity quantity = new Quantity();

        public long FactID { get; set; }
        public long Metric01
        {
            get { return quantity.IntValue; }
            set { quantity.IntValue = value; }
        }
        public int Scale
        {
            get { return quantity.Scale; }
            set { quantity.Scale = value; }
        }
        public string UnitOfMeasure
        {
            get { return quantity.UnitOfMeasure; }
            set { quantity.UnitOfMeasure = value; }
        }
        public Quantity MetricValue
        {
            get { return quantity; }
        }
    }
}
