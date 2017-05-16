using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Net.Sockets;

using DevExpress.XtraEditors;

namespace MaterialLabelPrint_Asimco
{
    public partial class frmMainLabelPrint : Form
    {
        private List<LabelData> labels = new List<LabelData>();

        public frmMainLabelPrint()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 生成数据库连接字符串
        /// </summary>
        /// <returns></returns>
        private string GetDBConnectionString()
        {
            string rlt =
                string.Format(
                    "Server={0};initial catalog=IRAP;UID={1};Password={2};" +
                    "Min Pool Size=2;Max Pool Size=60;",
                    "192.168.1.2",
                    "sa",
                    "CyprMes571");
            return rlt;
        }

        private List<LabelData> GetLabelFMTStrings(string filter)
        {
            List<LabelData> rlts = new List<LabelData>();

            string dbConnectionStr = GetDBConnectionString();

                SqlConnection conn = new SqlConnection(dbConnectionStr);
            try
            {
                conn.Open();
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return rlts;
            }

            string cmdStr =
                "SELECT '<Root><Action Ordinal=\"\" Action=\"PDASocketPrint\" " +
                "PrintToAddress=\"\" PrintToPort=\"\" Data = \"'" +
                "+ REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(" +
                "REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE" +
                "(TemplateFMTStr, '%1!', S.SKUID), '%2!', L101.Code), '%3!', S.LotNumber)" +
                ", '%4!', Convert(varchar(10), S.MFGDate, 120)), '%5!'" +
                ", SubString(IRAPMDM.dbo.ufn_GetStr_QuantityWithUM(S.QtyInStore, 6, 'KG'), " +
                "1, Len(IRAPMDM.dbo.ufn_GetStr_QuantityWithUM(S.QtyInStore, 6, 'KG')) - 5))" +
                ", '%6!', ''), '%7!', Stuff(L106.AlternateCode, 1, 2, '')), '%8!', L104.Code)" +
                ", '%9!', ''), '%10!', Convert(varchar(10), DateAdd(day, 1, S.ShelfLifeEndDate), " +
                "120)), '%11!', 'KG')" +
                ", '%12!', ''), '%13!', 'YES'), '%14!', ''), '%15!', S.RecvBatchNo)" +
                "+ '\" /></Root>' FROM IRAPMDM..GenAttr_Label G117" +
                ", IRAPRIMCS..utb_MaterialStore S, IRAPMDM..stb058 L106, IRAPMDM..stb058 L101" +
                ", IRAPMDM..stb058 L104 " +
                "WHERE G117.PartitioningKey = 600100117 AND G117.EntityID = 1031099 " +
                "AND S.PartitioningKey = 600100000 AND S.Leaf02 = 5333465 " + //AND S.ASNTransactNo = 0 " +
                "AND L106.PartitioningKey = 600100106 AND L106.LeafID = S.Leaf03 " +
                "AND L101.PartitioningKey = 600100101 AND L101.LeafID = S.Leaf01 " +
                "AND L104.PartitioningKey = 600100104 AND L104.LeafID = S.Leaf05 ";
            SqlCommand sqlCmd = new SqlCommand(cmdStr, conn)
            {
                CommandType = CommandType.Text,
                CommandTimeout = 60 * 1000 * 5,
            };
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            DataSet dsLabels = new DataSet();
            sda.Fill(dsLabels);

            if (dsLabels.Tables.Count > 0)
            {
                DataTable dt = dsLabels.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString().ToUpper().IndexOf("<ROOT>") >= 0)
                    {
                        LabelData data = ExplainXMLToLabelData(dr[0].ToString());
                        if (data != null)
                        {
                            if (filter == "")
                            {
                                rlts.Add(data);
                            }
                            else
                            if (data.StoreSiteNo.IndexOf(filter) == 0)
                            {
                                rlts.Add(data);
                            }
                        }
                    } 
                }
            }

            return rlts;
        }

        private List<LabelData> GetLabelFMTStringsWithS000001()
        {
            List<LabelData> rlts = new List<LabelData>();

            string dbConnectionStr = GetDBConnectionString();

            SqlConnection conn = new SqlConnection(dbConnectionStr);
            try
            {
                conn.Open();
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return rlts;
            }

            string cmdStr =
                "SELECT '<Root><Action Ordinal=\"\" Action=\"PDASocketPrint\" " +
                "PrintToAddress=\"\" PrintToPort=\"\" Data = \"'" +
                "+ REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(" +
                "REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE" +
                "(TemplateFMTStr, '%1!', S.SKUID), '%2!', L101.Code), '%3!', S.LotNumber)" +
                ", '%4!', Convert(varchar(10), S.MFGDate, 120)), '%5!'" +
                ", SubString(IRAPMDM.dbo.ufn_GetStr_QuantityWithUM(S.QtyInStore, 6, 'KG'), " +
                "1, Len(IRAPMDM.dbo.ufn_GetStr_QuantityWithUM(S.QtyInStore, 6, 'KG')) - 5))" +
                ", '%6!', ''), '%7!', Stuff(L106.AlternateCode, 1, 2, '')), '%8!', L104.Code)" +
                ", '%9!', ''), '%10!', Convert(varchar(10), DateAdd(day, 1, S.ShelfLifeEndDate), " +
                "120)), '%11!', 'KG')" +
                ", '%12!', ''), '%13!', 'YES'), '%14!', ''), '%15!', S.RecvBatchNo)" +
                "+ '\" /></Root>' FROM IRAPMDM..GenAttr_Label G117" +
                ", IRAPRIMCS..utb_MaterialStore S, IRAPMDM..stb058 L106, IRAPMDM..stb058 L101" +
                ", IRAPMDM..stb058 L104 " +
                "WHERE G117.PartitioningKey = 600100117 AND G117.EntityID = 1031099 " +
                "AND S.PartitioningKey = 600100000 AND S.Leaf03 = 5357752 " +
                "AND L106.PartitioningKey = 600100106 AND L106.LeafID = S.Leaf03 " +
                "AND L101.PartitioningKey = 600100101 AND L101.LeafID = S.Leaf01 " +
                "AND L104.PartitioningKey = 600100104 AND L104.LeafID = S.Leaf05 ";
            SqlCommand sqlCmd = new SqlCommand(cmdStr, conn)
            {
                CommandType = CommandType.Text,
                CommandTimeout = 60 * 1000 * 5,
            };
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            DataSet dsLabels = new DataSet();
            sda.Fill(dsLabels);

            if (dsLabels.Tables.Count > 0)
            {
                DataTable dt = dsLabels.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString().ToUpper().IndexOf("<ROOT>") >= 0)
                    {
                        LabelData data = ExplainXMLToLabelData(dr[0].ToString());
                        if (data != null)
                        {
                            rlts.Add(data);
                        }
                    }
                }
            }

            return rlts;
        }

        private LabelData ExplainXMLToLabelData(string xmlString)
        {
            LabelData rlt = null;

            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(xmlString);

                foreach (XmlNode node in xml.SelectNodes("Root/Action"))
                {
                    if (node.Attributes["Action"].Value == "PDASocketPrint")
                    {
                        rlt = new LabelData();

                        rlt.LabelFMTString = node.Attributes["Data"].Value;
                        string[] strings = rlt.LabelFMTString.Split('\n');

                        rlt.SKUID = strings[10].Substring(20, 18);
                        rlt.Quantity = strings[14].Substring(31, 10);

                        int length = strings[11].Length;
                        int pos = strings[11].IndexOf(":") + 1;
                        rlt.MaterialCode =
                            strings[11].Substring(
                                pos,
                                length - pos);

                        length = strings[20].Length;
                        pos = strings[20].IndexOf(":") + 1;
                        rlt.InLotNumber =
                            strings[20].Substring(
                                pos,
                                length - pos);

                        length = strings[16].Length;
                        pos = strings[16].IndexOf(":") + 1;
                        rlt.StoreSiteNo =
                            strings[16].Substring(
                                pos,
                                length - pos);

                        break;
                    }
                }
            }
            catch (Exception error)
            {
                return null;
            }

            return rlt;
        }

        private void SetDataChoiceStatus(bool isSelected)
        {
            grdvLabels.BeginDataUpdate();
            foreach (LabelData label in labels)
                label.Choice = isSelected;
            grdvLabels.EndDataUpdate();
        }

        private void btnGetLabelFMTStrings_Click(object sender, EventArgs e)
        {
            labels = GetLabelFMTStrings(edtStoreSiteNoFillter.Text.Trim());

            grdLabels.DataSource = labels;
            grdvLabels.BestFitColumns();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetDataChoiceStatus(true);
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            SetDataChoiceStatus(false);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SocketPrint.Instance.PrinterAddress = edtIPAddress.Text.Trim();
            SocketPrint.Instance.PrinterPort = Convert.ToInt32(edtPort.Value);

            foreach (LabelData label in labels)
            {
                if (label.Choice)
                {
                    if (SocketPrint.Instance.PrinterReady())
                        SocketPrint.Instance.Print(label.LabelFMTString);
                    else
                    {
                        XtraMessageBox.Show(
                            string.Format(
                                "打印机[{0}.{1}]离线，无法打印!",
                                SocketPrint.Instance.PrinterAddress,
                                SocketPrint.Instance.PrinterPort),
                            Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }
                }
            }
        }

        private void btnS000001Label_Click(object sender, EventArgs e)
        {
            labels = GetLabelFMTStringsWithS000001();

            grdLabels.DataSource = labels;
            grdvLabels.BestFitColumns();
        }
    }

    internal class LabelData
    {
        public bool Choice { get; set; }
        public string SKUID { get; set; }
        public string StoreSiteNo { get; set; }
        public string MaterialCode { get; set; }
        public string InLotNumber { get; set; }
        public string Quantity { get; set; }
        public string LabelFMTString { get; set; }
    }

    internal class SocketPrint
    {
        private static SocketPrint _instance = null;
        private const string className = "IRAP.PDA.Global.SocketPrint";

        public SocketPrint()
        {
        }

        public static SocketPrint Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SocketPrint();
                return _instance;
            }
        }

        /// <summary>
        /// 打印机IP地址
        /// </summary>
        public string PrinterAddress { get; set; }

        /// <summary>
        /// 打印机端口号
        /// </summary>
        public int PrinterPort { get; set; }

        public bool PrinterReady()
        {
            string strProcedureName = className + ".PrinterReady";

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(PrinterAddress), PrinterPort);
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    socket.Connect(endPoint);
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public bool Print(string data)
        {
            string strProcedureName = className + ".Print";

            //byte[] bData = Encoding.Default.GetBytes(data);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(PrinterAddress), PrinterPort);
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    socket.Connect(endPoint);

                    string[] arrayData = data.Split('\n');
                    for (int i = 0; i < arrayData.Length; i++)
                    {
                        byte[] bData = Encoding.Default.GetBytes(arrayData[i] + "\r\n");
                        socket.Send(bData);
                    }
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }
    }
}
