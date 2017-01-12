using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

using DevExpress.XtraEditors;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace IRAP.PLC.Collection
{
    /// <summary>
    /// 耐美特脱氢炉工艺参数采集
    /// </summary>
    internal class DC_Baking_NMT : CustomDataCollection
    {
        private string operationCode = "CN11010001030202W";
        private string paramCode = "";
        private string paramName = "温度";

        public DC_Baking_NMT(MemoEdit displayLog) : base(displayLog)
        {
        }

        private XmlNode CreateDataRow1(
            XmlDocument xml, 
            string productNo, 
            DataRow dr)
        {
            XmlNode node = xml.CreateElement("Row");

            node.Attributes.Append(
                CreateAttr(
                    xml,
                    "CollectingTime",
                    StrDateTimeToUnitTime(dr["MCGS_Time"].ToString().Trim())));
            node.Attributes.Append(CreateAttr(xml, "EquipmentCode", "BF-0825-1"));
            node.Attributes.Append(CreateAttr(xml, "OperationCode", operationCode));
            node.Attributes.Append(CreateAttr(xml, "StepNo", ""));
            node.Attributes.Append(CreateAttr(xml, "ProductNo", productNo.Trim()));
            node.Attributes.Append(CreateAttr(xml, "LotNumber", ""));
            node.Attributes.Append(CreateAttr(xml, "SerialNumber", ""));
            node.Attributes.Append(CreateAttr(xml, "Ordinal", ""));
            node.Attributes.Append(CreateAttr(xml, "ParamCode", paramCode));
            node.Attributes.Append(CreateAttr(xml, "ParamName", paramName));
            node.Attributes.Append(CreateAttr(xml, "LowLimit", "0"));
            node.Attributes.Append(CreateAttr(xml, "Criterion", "GELE"));
            node.Attributes.Append(CreateAttr(xml, "HighLimit", "0"));
            node.Attributes.Append(CreateAttr(xml, "Scale", "0"));
            node.Attributes.Append(CreateAttr(xml, "UnitOfMeasure", "℃"));
            node.Attributes.Append(CreateAttr(xml, "Conclusion", ""));
            node.Attributes.Append(CreateAttr(xml, "Metric01", dr["一台PV"].ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric02", dr["二台PV"].ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric03", dr["三台PV"].ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric04", dr["四台PV"].ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric05", dr["五台PV"].ToString()));

            return node;
        }

        private XmlNode CreateDataRow2(
            XmlDocument xml, 
            string productNo, 
            DataRow dr)
        {
            XmlNode node = xml.CreateElement("Row");

            node.Attributes.Append(
                CreateAttr(
                    xml,
                    "CollectingTime",
                    StrDateTimeToUnitTime(dr["MCGS_Time"].ToString())));
            node.Attributes.Append(CreateAttr(xml, "EquipmentCode", "BF-0825-2"));
            node.Attributes.Append(CreateAttr(xml, "OperationCode", operationCode));
            node.Attributes.Append(CreateAttr(xml, "StepNo", ""));
            node.Attributes.Append(CreateAttr(xml, "ProductNo", productNo.Trim()));
            node.Attributes.Append(CreateAttr(xml, "LotNumber", ""));
            node.Attributes.Append(CreateAttr(xml, "SerialNumber", ""));
            node.Attributes.Append(CreateAttr(xml, "Ordinal", ""));
            node.Attributes.Append(CreateAttr(xml, "ParamCode", paramCode));
            node.Attributes.Append(CreateAttr(xml, "ParamName", paramName));
            node.Attributes.Append(CreateAttr(xml, "LowLimit", "0"));
            node.Attributes.Append(CreateAttr(xml, "Criterion", "GELE"));
            node.Attributes.Append(CreateAttr(xml, "HighLimit", "0"));
            node.Attributes.Append(CreateAttr(xml, "Scale", "0"));
            node.Attributes.Append(CreateAttr(xml, "UnitOfMeasure", "℃"));
            node.Attributes.Append(CreateAttr(xml, "Conclusion", ""));
            node.Attributes.Append(CreateAttr(xml, "Metric01", dr["六台PV"].ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric02", dr["七台PV"].ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric03", dr["八台PV"].ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric04", dr["九台PV"].ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric05", dr["十台PV"].ToString()));

            return node;
        }

        private XmlNode CreateDataRow3(
            XmlDocument xml, 
            string productNo, 
            DataRow dr)
        {
            XmlNode node = xml.CreateElement("Row");

            node.Attributes.Append(
                CreateAttr(
                    xml,
                    "CollectingTime",
                    StrDateTimeToUnitTime(dr["MCGS_Time"].ToString().Trim())));
            node.Attributes.Append(CreateAttr(xml, "EquipmentCode", "BF-0825-3"));
            node.Attributes.Append(CreateAttr(xml, "OperationCode", operationCode));
            node.Attributes.Append(CreateAttr(xml, "StepNo", ""));
            node.Attributes.Append(CreateAttr(xml, "ProductNo", productNo.Trim()));
            node.Attributes.Append(CreateAttr(xml, "LotNumber", ""));
            node.Attributes.Append(CreateAttr(xml, "SerialNumber", ""));
            node.Attributes.Append(CreateAttr(xml, "Ordinal", ""));
            node.Attributes.Append(CreateAttr(xml, "ParamCode", paramCode));
            node.Attributes.Append(CreateAttr(xml, "ParamName", paramName));
            node.Attributes.Append(CreateAttr(xml, "LowLimit", "0"));
            node.Attributes.Append(CreateAttr(xml, "Criterion", "GELE"));
            node.Attributes.Append(CreateAttr(xml, "HighLimit", "0"));
            node.Attributes.Append(CreateAttr(xml, "Scale", "0"));
            node.Attributes.Append(CreateAttr(xml, "UnitOfMeasure", "℃"));
            node.Attributes.Append(CreateAttr(xml, "Conclusion", ""));
            node.Attributes.Append(CreateAttr(xml, "Metric01", dr["十一台PV"].ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric02", dr["十二台PV"].ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric03", dr["十三台PV"].ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric04", dr["十四台PV"].ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric05", dr["十五台PV"].ToString()));

            return node;
        }

        protected override void GetDataAndSendToESB(DateTime beginDT, DateTime endDT)
        {
            #region 烤箱1
            {
                WriteLogInThread(
                    string.Format(
                        "获取[烤箱1]【{0}】-【{1}】的数据",
                        beginDT,
                        endDT));

                string sql =
                    string.Format(
                        "SELECT * FROM 烤箱1存盘数据_MCGS " +
                        "WHERE MCGS_Time >= #{0}# AND MCGS_Time <= #{1}#",
                        beginDT,
                        endDT);

                DataTable dt = GetData(sql);

                XmlDocument xml = new XmlDocument();
                XmlNode node = xml.CreateXmlDeclaration("1.0", "utf-8", "");
                xml.AppendChild(node);

                if (dt != null &&
                    dt.Rows.Count > 0)
                {
                    WriteLogInThread(
                        string.Format(
                            "共处理 {0} 条记录;",
                            dt.Rows.Count));

                    XmlNode root = xml.SelectSingleNode("ROOT");
                    if (root == null)
                    {
                        root = xml.CreateElement("ROOT");
                        xml.AppendChild(root);
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        root.RemoveAll();

                        #region 生成当前记录的 XML 串
                        string xmlString =
                            string.Format(
                                "<Row MCGS_Time=\"{0}\" MCGS_TimeMS=\"{1}\" 一台PV=\"{2}\" />",
                                dr["MCGS_Time"].ToString(),
                                dr["MCGS_TimeMS"].ToString(),
                                dr["一台PV"].ToString());
                        #endregion

                        if (dr["Oven1_Product1"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow1(xml, dr["Oven1_Product1"].ToString(), dr));
                        if (dr["Oven1_Product2"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow1(xml, dr["Oven1_Product2"].ToString(), dr));
                        if (dr["Oven1_Product3"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow1(xml, dr["Oven1_Product3"].ToString(), dr));
                        if (dr["Oven1_Product4"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow1(xml, dr["Oven1_Product4"].ToString(), dr));
                        if (dr["Oven1_Product5"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow1(xml, dr["Oven1_Product5"].ToString(), dr));

                        if (root.HasChildNodes)
                            SendToESB(xml);
                    }
                    WriteLogInThread("处理完毕......");
                }
                else
                {
                    WriteLogInThread("无需处理......");
                }
            }
            #endregion

            #region 烤箱2
            {
                WriteLogInThread(
                    string.Format(
                        "获取[烤箱2]【{0}】-【{1}】的数据",
                        beginDT,
                        endDT));

                string sql =
                    string.Format(
                        "SELECT * FROM 烤箱2存盘数据_MCGS " +
                        "WHERE MCGS_Time >= #{0}# AND MCGS_Time <= #{1}#",
                        beginDT,
                        endDT);

                DataTable dt = GetData(sql);

                XmlDocument xml = new XmlDocument();
                XmlNode node = xml.CreateXmlDeclaration("1.0", "utf-8", "");
                xml.AppendChild(node);

                if (dt != null &&
                    dt.Rows.Count > 0)
                {
                    WriteLogInThread(
                      string.Format(
                          "共处理 {0} 条记录;",
                          dt.Rows.Count));

                    XmlNode root = xml.SelectSingleNode("ROOT");
                    if (root == null)
                    {
                        root = xml.CreateElement("ROOT");
                        xml.AppendChild(root);
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        root.RemoveAll();

                        if (dr["Oven2_Product1"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow2(xml, dr["Oven2_Product1"].ToString(), dr));
                        if (dr["Oven2_Product2"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow2(xml, dr["Oven2_Product2"].ToString(), dr));
                        if (dr["Oven2_Product3"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow2(xml, dr["Oven2_Product3"].ToString(), dr));
                        if (dr["Oven2_Product4"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow2(xml, dr["Oven2_Product4"].ToString(), dr));
                        if (dr["Oven2_Product5"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow2(xml, dr["Oven2_Product5"].ToString(), dr));

                        if (root.HasChildNodes)
                            SendToESB(xml);
                    }
                    WriteLogInThread("处理完毕......");
                }
                else
                {
                    WriteLogInThread("无需处理......");
                }
            }
            #endregion

            #region 烤箱3
            {
                WriteLogInThread(
                    string.Format(
                        "获取[烤箱3]【{0}】-【{1}】的数据",
                        beginDT,
                        endDT));

                string sql =
                    string.Format(
                        "SELECT * FROM 烤箱3存盘数据_MCGS " +
                        "WHERE MCGS_Time >= #{0}# AND MCGS_Time <= #{1}#",
                        beginDT,
                        endDT);

                DataTable dt = GetData(sql);

                XmlDocument xml = new XmlDocument();
                XmlNode node = xml.CreateXmlDeclaration("1.0", "utf-8", "");
                xml.AppendChild(node);

                if (dt != null &&
                    dt.Rows.Count > 0)
                {
                    WriteLogInThread(
                      string.Format(
                          "共处理 {0} 条记录;",
                          dt.Rows.Count));

                    XmlNode root = xml.SelectSingleNode("ROOT");
                    if (root == null)
                    {
                        root = xml.CreateElement("ROOT");
                        xml.AppendChild(root);
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        root.RemoveAll();

                        if (dr["Oven3_Product1"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow3(xml, dr["Oven3_Product1"].ToString(), dr));
                        if (dr["Oven3_Product2"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow3(xml, dr["Oven3_Product2"].ToString(), dr));
                        if (dr["Oven3_Product3"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow3(xml, dr["Oven3_Product3"].ToString(), dr));
                        if (dr["Oven3_Product4"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow3(xml, dr["Oven3_Product4"].ToString(), dr));
                        if (dr["Oven3_Product5"].ToString().Trim() != "")
                            root.AppendChild(CreateDataRow3(xml, dr["Oven3_Product5"].ToString(), dr));

                        if (root.HasChildNodes)
                            SendToESB(xml);
                    }
                    WriteLogInThread("处理完毕......");
                }
                else
                {
                    WriteLogInThread("无需处理......");
                }
            }
            #endregion
        }
    }
}
