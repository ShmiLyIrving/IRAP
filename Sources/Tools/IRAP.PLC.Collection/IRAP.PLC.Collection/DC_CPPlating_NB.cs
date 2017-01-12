using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;

using DevExpress.XtraEditors;

namespace IRAP.PLC.Collection
{
    internal class DC_CPPlating_NB : CustomDataCollection
    {
        private string operationCode = "CN11010001030102W";

        public DC_CPPlating_NB(MemoEdit mmoLog):base(mmoLog) { }

        protected override void GetDataAndSendToESB(DateTime beginDT, DateTime endDT)
        {
            WriteLogInThread(
                string.Format(
                    "获取电镀[{0}]【{1}】-【{2}】的数据",
                    SystemParams.Instance.DeviceCode,
                    beginDT,
                    endDT));

            string sql =
                string.Format(
                    "SELECT * FROM 入线表 " +
                    "WHERE CDATE(出线时间) BETWEEN #{0}# AND #{1}#",
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
                    if (dr["零件号码"].ToString().Trim() == "12345678")
                        continue;

                    root.RemoveAll();

                    sql =
                        string.Format(
                            "SELECT * FROM 线状态历史 " +
                            "WHERE (CDATE(时间) BETWEEN #{0}# AND #{1}#) " +
                            "AND 零件号码='{2}' AND 飞巴号='{3}'",
                            dr["入线时间"].ToString(),
                            dr["出线时间"].ToString(),
                            dr["零件号码"].ToString(),
                            dr["飞巴号"].ToString());
                    DataTable dtDetail = GetData(sql);

                    if (dtDetail.Rows.Count > 0)
                    {
                        foreach (DataRow drd in dtDetail.Rows)
                        {
                            string remark =
                                string.Format(
                                    "运行工步={0}|槽位名称={1}|设定时间={2}|入槽时间={3}",
                                    drd["运行工步"].ToString().Trim(),
                                    drd["槽位名称"].ToString().Trim(),
                                    drd["设定时间"].ToString().Trim(),
                                    drd["入槽时间"].ToString().Trim());

                            if (drd["设定温度波形"].ToString().Trim() != "")
                                root.AppendChild(
                                    CreateDataRow(
                                        xml, 
                                        drd,
                                        "",
                                        "温度",
                                        string.Format(
                                            "{0}|设定温度波形={1}|实际温度波形={2}",
                                            remark,
                                            drd["设定温度波形"].ToString().Trim(),
                                            drd["实际温度波形"].ToString().Trim())));
                            if (drd["设定电流波形"].ToString().Trim() != "")
                                root.AppendChild(
                                    CreateDataRow(
                                        xml,
                                        drd,
                                        "",
                                        "电流",
                                        string.Format(
                                            "{0}|设定电流波形{1}|实际电流波形={2}|实际电压波形={3}",
                                            remark,
                                            drd["设定电流波形"].ToString().Trim(),
                                            drd["实际电流波形"].ToString().Trim(),
                                            drd["实际电压波形"].ToString().Trim())));
                        }
                    }

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

        private XmlNode CreateDataRow(
            XmlDocument xml, 
            DataRow dr, 
            string paramCode,
            string paramName,
            string remark)
        {
            XmlNode node = xml.CreateElement("Row");

            node.Attributes.Append(
                CreateAttr(
                    xml,
                    "CollectingTime",
                    StrDateTimeToUnitTime(dr["时间"].ToString().Trim())));

            node.Attributes.Append(CreateAttr(xml, "EquipmentCode", SystemParams.Instance.DeviceCode));
            node.Attributes.Append(CreateAttr(xml, "OperationCode", operationCode));
            node.Attributes.Append(CreateAttr(xml, "StepNo", ""));
            node.Attributes.Append(CreateAttr(xml, "ProductNo", dr["零件号码"].ToString().Trim()));
            node.Attributes.Append(CreateAttr(xml, "LotNumber", ""));
            node.Attributes.Append(CreateAttr(xml, "SerialNumber", ""));
            node.Attributes.Append(CreateAttr(xml, "Ordinal", ""));
            node.Attributes.Append(CreateAttr(xml, "ParamCode", paramCode));
            node.Attributes.Append(CreateAttr(xml, "ParamName", paramName));
            node.Attributes.Append(CreateAttr(xml, "LowLimit", "0"));
            node.Attributes.Append(CreateAttr(xml, "Criterion", "GELE"));
            node.Attributes.Append(CreateAttr(xml, "HighLimit", "0"));
            node.Attributes.Append(CreateAttr(xml, "Scale", "0"));
            node.Attributes.Append(CreateAttr(xml, "UnitOfMeasure", ""));
            node.Attributes.Append(CreateAttr(xml, "Conclusion", ""));
            node.Attributes.Append(CreateAttr(xml, "Metric01", "0"));
            node.Attributes.Append(CreateAttr(xml, "Metric02", "0"));
            node.Attributes.Append(CreateAttr(xml, "Metric03", "0"));
            node.Attributes.Append(CreateAttr(xml, "Metric04", "0"));
            node.Attributes.Append(CreateAttr(xml, "Metric05", "0"));
            node.Attributes.Append(CreateAttr(xml, "Remark", remark));

            return node;
        }
    }
}
