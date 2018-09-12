using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml;

namespace MDEditor
{
    public partial class Form1 : Form
    {
        private string dbString = "";
        private List<XbarChartMeasureData> datas = new List<XbarChartMeasureData>();

        public Form1()
        {
            InitializeComponent();

            dbString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public List<XbarChartMeasureData> XMLToXBarChartDataList(string chartDataXML)
        {
            List<XbarChartMeasureData> datas = new List<XbarChartMeasureData>();

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(chartDataXML);
                XmlNodeList nodes = xmlDoc.SelectNodes("ChartData/Row");
                foreach (XmlNode node in nodes)
                {
                    XbarChartMeasureData data = new XbarChartMeasureData();
                    if (node.Attributes["Ordinal"] != null)
                        data.Ordinal = int.Parse(node.Attributes["Ordinal"].Value);

                    if (node.Attributes["FactID"] != null)
                        data.FactID = long.Parse(node.Attributes["FactID"].Value);

                    if (node.Attributes["PartitionPolicy"] != null)
                        data.PartitionPolicy = long.Parse(node.Attributes["PartitionPolicy"].Value);

                    if (node.Attributes["RSOrdinal"] != null)
                        data.RSOrdinal = int.Parse(node.Attributes["RSOrdinal"].Value);

                    if (node.Attributes["WFInstanceID"] != null)
                        data.WFInstanceID = node.Attributes["WFInstanceID"].Value;

                    if (node.Attributes["BusinessDate"] != null)
                        data.BusinessDate = node.Attributes["BusinessDate"].Value;

                    if (node.Attributes["Metric01"] != null)
                        data.Metric01 = long.Parse(node.Attributes["Metric01"].Value);

                    datas.Add(data);
                }
            }
            catch { datas = new List<XbarChartMeasureData>(); }
            finally
            {
                xmlDoc = null;
            }

            return datas;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            splitContainerControl1.Panel2.Text = "查询结果";

            if (edtT133Code.Text.Trim() == "")
            {
                MessageBox.Show("设备编号不能空白！");
                return;
            }

            string sqlCmd =
                string.Format(
                    "SELECT * FROM IRAPMES..ufn_GetInfo_SPCChartByEqu(60010, '{0}', 107)",
                    edtT133Code.Text.Trim());

            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(dbString);
                SqlCommand cmd = new SqlCommand(sqlCmd, conn)
                {
                    CommandType = CommandType.Text,
                };
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                conn.Close();
                conn = null;

                sda.Fill(ds);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["ErrCode"].ToString() == "999999")
                    {
                        MessageBox.Show(dt.Rows[0]["ErrText"].ToString());
                        return;
                    }
                    else
                    {
                        string chartDataXML = dt.Rows[0]["ChartTitle"].ToString();
                        if (chartDataXML.IndexOf("XBar-R") >= 0)
                        {
                            splitContainerControl1.Panel2.Text =
                                string.Format(
                                    "当前正在生产的产品：{0}",
                                    dt.Rows[0]["T102Code"].ToString());
                            datas = XMLToXBarChartDataList(dt.Rows[0]["ChartDataXML"].ToString());
                            gridControl1.DataSource = datas;
                            gridView1.BestFitColumns();
                        }
                        else
                        {
                            MessageBox.Show("当前设备的控制图是彩虹图，不能删除数据！");
                        }
                    }
                }
            }
        }

        private void ribeDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int idx = gridView1.GetFocusedDataSourceRowIndex();
            if (idx >= 0)
            {
                if (gridControl1.DataSource != null &&
                    (gridControl1.DataSource as List<XbarChartMeasureData>).Count > idx)
                {
                    XbarChartMeasureData data = (gridControl1.DataSource as List<XbarChartMeasureData>)[idx];

                    if (
                        MessageBox.Show(
                            string.Format(
                                "您确定要删除测量值：[{0}]？",
                                data.Metric01),
                            "请确认！",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        string sqlCmd =
                            string.Format(
                                "INSERT INTO IRAPMES..RSFact_InspectDataCollecting_H " +
                                "SELECT *, GETDATE() " +
                                "FROM IRAPMES..RSFact_InspectDataCollecting " +
                                "WHERE PartitioningKey={0} AND " +
                                "FactID={1} AND Ordinal={2};\n" +
                                "DELETE FROM IRAPMES..RSFact_InspectDataCollecting " +
                                "WHERE PartitioningKey={0} AND " +
                                "FactID={1} AND Ordinal={2};",
                                data.PartitionPolicy,
                                data.FactID,
                                data.RSOrdinal);

                        SqlConnection conn = new SqlConnection(dbString);
                        try
                        {
                            conn.Open();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                            return;
                        }

                        SqlTransaction transaction = conn.BeginTransaction();
                        try
                        {
                            SqlCommand cmd = new SqlCommand(sqlCmd, conn, transaction)
                            {
                                CommandType = CommandType.Text,
                            };

                            cmd.ExecuteNonQuery();

                            transaction.Commit();

                            conn.Close();
                            conn = null;

                            MessageBox.Show("测量数据已删除");

                            btnSearch.PerformClick();
                        }
                        catch (Exception error)
                        {
                            transaction.Rollback();

                            MessageBox.Show(error.Message);
                            return;
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
    }

    /// <summary>
    /// SPC XBar-R图测量数据
    /// </summary>
    public class XbarChartMeasureData
    {
        public int Ordinal { get; set; }
        public long FactID { get; set; }
        public long PartitionPolicy { get; set; }
        public int RSOrdinal { get; set; }
        public string WFInstanceID { get; set; }
        public string BusinessDate { get; set; }
        public long Metric01 { get; set; }

        public XbarChartMeasureData Clone()
        {
            XbarChartMeasureData rlt = MemberwiseClone() as XbarChartMeasureData;
            return rlt;
        }
    }
}
