using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

using DevExpress.XtraEditors;

using IRAP.Global;

namespace IRAP.PLC.Collection
{
    /// <summary>
    /// 纽堡脱氢炉工艺参数采集
    /// </summary>
    internal class DC_Baking_NB : CustomDataCollection
    {
        private string operationCode = "CN11010001030102W";
        private string paramCode = "";
        private string paramName = "温度";

        public DC_Baking_NB(MemoEdit displayLog) : base(displayLog) { }

        protected override void GetDataAndSendToESB(DateTime beginDT, DateTime endDT)
        {
            WriteLogInThread(
                string.Format(
                    "获取[烤箱]【{0}】-【{1}】的数据",
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
                            root.AppendChild(CreateDataRow(xml, drd));
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

        /// <summary>
        /// 根据槽工位号确定 Chamber 号，从而确定设备编号
        /// </summary>
        /// <param name="fbNo"></param>
        /// <returns></returns>
        private string GetEquipmentCode(string fbNo)
        {
            int f = Tools.ConvertToInt32(fbNo);
            switch (f)
            {
                case 1:
                case 2:
                    return SystemParams.Instance.DeviceCode + "-1";
                case 3:
                case 4:
                    return SystemParams.Instance.DeviceCode + "-2";
                default:
                    return SystemParams.Instance.DeviceCode;
            }
        }

        private XmlNode CreateDataRow(XmlDocument xml, DataRow dr)
        {
            XmlNode node = xml.CreateElement("Row");

            node.Attributes.Append(
                CreateAttr(
                    xml,
                    "CollectingTime",
                    StrDateTimeToUnitTime(dr["时间"].ToString().Trim())));

            node.Attributes.Append(CreateAttr(xml, "EquipmentCode", GetEquipmentCode(dr["槽工位号"].ToString().Trim())));
            node.Attributes.Append(CreateAttr(xml, "OperationCode", operationCode));
            node.Attributes.Append(CreateAttr(xml, "StepNo", ""));
            node.Attributes.Append(CreateAttr(xml, "ProductNo", dr["零件号码"].ToString().Trim()));
            node.Attributes.Append(CreateAttr(xml, "LotNumber", ""));
            node.Attributes.Append(CreateAttr(xml, "SerialNumber", ""));
            node.Attributes.Append(CreateAttr(xml, "Ordinal", ""));
            node.Attributes.Append(CreateAttr(xml, "ParamCode", paramCode));
            node.Attributes.Append(CreateAttr(xml, "ParamName", paramName));

            int low = 0;
            int high = 0;
            SplitterTempString(dr["设定温度波形"].ToString().Trim(), ref low, ref high);

            node.Attributes.Append(CreateAttr(xml, "LowLimit", low.ToString()));
            node.Attributes.Append(CreateAttr(xml, "Criterion", "GELE"));
            node.Attributes.Append(CreateAttr(xml, "HighLimit", high.ToString()));
            node.Attributes.Append(CreateAttr(xml, "Scale", "2"));
            node.Attributes.Append(CreateAttr(xml, "UnitOfMeasure", "℃"));
            node.Attributes.Append(CreateAttr(xml, "Conclusion", ""));

            int metric01 = 0;
            int metric02 = 0;
            SplitterTempString(dr["实际温度波形"].ToString().Trim(), ref metric01, ref metric02);

            node.Attributes.Append(CreateAttr(xml, "Metric01", metric01.ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric02", metric02.ToString()));
            node.Attributes.Append(CreateAttr(xml, "Metric03", "0"));
            node.Attributes.Append(CreateAttr(xml, "Metric04", "0"));
            node.Attributes.Append(CreateAttr(xml, "Metric05", "0"));

            return node;
        }

        private void SplitterTempString(string tempString, ref int temp1, ref int temp2)
        {
            string[] temps = tempString.Split(',');

            string[] t = temps[0].Split('/');
            temp1 = Convert.ToInt32(Tools.ConvertToDouble(t[0]) * 100);

            t = temps[1].Split('/');
            temp2 = Convert.ToInt32(Tools.ConvertToDouble(t[0]) * 100);
        }
    }
}
