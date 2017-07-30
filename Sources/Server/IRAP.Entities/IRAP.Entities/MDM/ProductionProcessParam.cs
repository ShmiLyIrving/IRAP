using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;

using IRAP.Global;

namespace IRAP.Entities.MDM
{
    /// <summary>
    /// 生产过程参数
    /// </summary>
    public class ProductionProcessParam
    {
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
        public string DataXML { get; set; }

        public List<PPParamValue> ResolveDataXML()
        {
            string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        MethodBase.GetCurrentMethod().DeclaringType.FullName,
                        MethodBase.GetCurrentMethod().Name);

            List<PPParamValue> rlt = new List<PPParamValue>();

            XmlDocument xdoc = new XmlDocument();
            try
            {
                xdoc.LoadXml(DataXML);
            }
            catch (XmlException err)
            {
                WriteLog.Instance.Write(err.Message, strProcedureName);
                return new List<PPParamValue>();
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

                rlt.Add(
                    new PPParamValue()
                    {
                        FactID = factID,
                        Metric01 = metric01,
                    });
            }
            return rlt;
        }

        public ProductionProcessParam Clone()
        {
            ProductionProcessParam rlt = MemberwiseClone() as ProductionProcessParam;

            return rlt;
        }
    }

    public class PPParamValue
    {
        public long FactID { get; set; }
        public string Metric01 { get; set; }
    }
}
