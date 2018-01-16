using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace IRAP.PLC.Collection
{
    /// <summary>
    /// 拧紧设备数据采集
    /// </summary>
    internal class DC_Tighten : CustomDataCollection
    {
        private string operationCode = "";
        public DC_Tighten(MemoEdit displayLog) : base(displayLog) { }
        protected override void GetDataAndSendToESB(DateTime beginDT, DateTime endDT)
        {
            WriteLogInThread(
                 string.Format(
                     "获取[拧紧设备]【{0}】-【{1}】的数据",
                     beginDT,
                     endDT));

            string sql =
                string.Format(
                    "SELECT * FROM ResultData " +
                    "WHERE CDATE(时间) BETWEEN #{0}# AND #{1}#",
                    beginDT,
                    endDT);

            if (SystemParams.Instance.T216Code != "")
                operationCode = SystemParams.Instance.T216Code;

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
                    root.AppendChild(CreateDataRow(xml, dr));
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
        private XmlNode CreateDataRow(XmlDocument xml, DataRow dr)
        {
            XmlNode node = xml.CreateElement("Row");
            try
            {
                node.Attributes.Append(
                    CreateAttr(
                        xml,
                        "CollectingTime",
                        StrDateTimeToUnitTime(dr["时间"].ToString().Trim())));
                node.Attributes.Append(CreateAttr(xml, "EquipmentCode", SystemParams.Instance.DeviceCode));
                node.Attributes.Append(CreateAttr(xml, "OperationCode", operationCode));
                node.Attributes.Append(CreateAttr(xml, "时间", dr["时间"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "测试编码", dr["测试编码"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "测试结果", dr["测试结果"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "左装配位移", dr["左装配位移"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "右装配位移", dr["右装配位移"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "传感器压装位移", dr["传感器压装位移"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "传感器压装压力", dr["传感器压装压力"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "传感器电压", dr["传感器电压"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "拧紧枪扭矩", dr["拧紧枪扭矩"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "测试员", dr["测试员"].ToString().Trim()));
            }
            catch(Exception e)
            {
                WriteLogInThread(e.Message.ToString() + "请检查数据库文件是否选择正确");
            }
            return node;
        }
    }
}
