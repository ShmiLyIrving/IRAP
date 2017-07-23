using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entities.MDM
{
    /// <summary>
    /// 生产过程参数
    /// </summary>
    public class ProductionProcessParam
    {
        private string dataXML = "";
        private List<PPParamValue> values = new List<PPParamValue>();

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
        /// 历史数据记录
        /// [RF25]
        ///     [Row FactID="" Metric01="" /]
        /// [/RF25]
        /// </summary>
        public string DataXML
        {
            get { return dataXML; }
            set
            {
                dataXML = value;

                string strProcedureName =
                        string.Format(
                            "{0}.{1}",
                            MethodBase.GetCurrentMethod().DeclaringType.FullName,
                            MethodBase.GetCurrentMethod().Name);

                values.Clear();

                XmlDocument xdoc = new XmlDocument();
                try
                {
                    xdoc.LoadXml(value);
                }
                catch (XmlException err)
                {
                    WriteLog.Instance.Write(err.Message, strProcedureName);
                    return;
                }

                long factID = 0;
                string metric01 = "";
                foreach (XmlNode node in xdoc.SelectNodes("RF25/Row"))
                {
                    if (node.Attributes["FactID"] != null)
                        factID = Tools.ConvertToInt64(node.Attributes["FactID"].Value, 0);
                    else
                        factID = 0;
                    if (node.Attributes["Metric01"] != null)
                        metric01 = node.Attributes["Metric01"].Value;
                    else
                        metric01 = "";

                    values.Add(
                        new PPParamValue()
                        {
                            FactID = factID,
                            Metric01 = metric01,
                        });
                }
            }
        }

        [IRAPORMMap(ORMMap = false)]
        public List<PPParamValue> Values
        {
            get { return values; }
        }

        public ProductionProcessParam Clone()
        {
            return MemberwiseClone() as ProductionProcessParam;
        }
    }

    public class PPParamValue
    {
        public long FactID { get; set; }
        public string Metric01 { get; set; }
    }
}
