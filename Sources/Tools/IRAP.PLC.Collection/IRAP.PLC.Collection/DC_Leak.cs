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
    /// 测漏设备数据采集
    /// </summary>
    internal class DC_Leak : CustomDataCollection
    {
        private string operationCode = "";
        public DC_Leak(MemoEdit displayLog) : base(displayLog) { }

        protected override void GetDataAndSendToESB(DateTime beginDT, DateTime endDT)
        {
            WriteLogInThread(
                string.Format(
                    "获取[测漏设备]【{0}】-【{1}】的数据",
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
            //XmlNode node = xml.CreateXmlDeclaration("1.0", "utf-8", "");
            //xml.AppendChild(node);

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
                node.Attributes.Append(CreateAttr(xml, "ID", dr["ID"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "时间", dr["时间"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "打标编码Num", dr["打标编码Num"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "状态", dr["状态"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "气密测试压力", dr["气密测试压力KPa"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "气密泄露量Sccm", dr["气密泄露量Sccm"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "流量测试值L_min", dr["流量测试值L_min"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "流量测试压损KPa", dr["流量测试压损KPa"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "工件号Num", dr["工件号Num"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "批次", dr["批次"].ToString().Trim()));
                node.Attributes.Append(CreateAttr(xml, "转盘号Num", dr["转盘号Num"].ToString().Trim()));
            }
            catch(Exception e)
            {
                WriteLogInThread(e.Message.ToString() + "请检查数据库文件是否选择正确");
            }
            return node;
        }
    }
}
