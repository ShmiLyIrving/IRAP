using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Xml;

namespace AsimcoBatchMNGMT
{
    public partial class PICKForm : DevExpress.XtraEditors.XtraForm
    {
        string[] Xml;
        string[] Retried;
        string[][] Check;
        string Skuid;
        DataTable dt;
        DataTable dtMaterial;
        CurrencyManager cm;
        
        public PICKForm()
        {
            InitializeComponent();
        }
        public PICKForm(string[] xml,string skuid, string errinfo, string[] retried,DataTable dtmaterial,string[][] check)
        {
            InitializeComponent();
            Xml = xml;
            Retried = retried;
            Skuid = skuid;
            dtMaterial = dtmaterial;
            Check = check;
            dt = DBhelp.XML2Table(Xml[0]);
            cm = (CurrencyManager)this.BindingContext[dt];
            textEdit1.DataBindings.Add("Text", dt, "AgencyLeaf");
            textEdit2.DataBindings.Add("Text", dt, "SysLogID");
            textEdit3.DataBindings.Add("Text", dt, "StationID");
            textEdit4.DataBindings.Add("Text", dt, "RoleLeaf");
            textEdit5.DataBindings.Add("Text", dt, "CommunityID");
            textEdit6.DataBindings.Add("Text", dt, "UserCode");
            textEdit7.DataBindings.Add("Text", dt, "ExCode");
            textEdit8.DataBindings.Add("Text", dt, "UserID");
            textEdit9.DataBindings.Add("Text", dt, "PassWord");
            textEdit10.DataBindings.Add("Text", dt, "OrderType");
            textEdit11.DataBindings.Add("Text", dt, "IssueType");
            textEdit12.DataBindings.Add("Text", dt, "OrderNumber");
            textEdit13.DataBindings.Add("Text", dt, "LineNumber");
            textEdit14.DataBindings.Add("Text", dt, "ComponentLineType");
            textEdit15.DataBindings.Add("Text", dt, "PointOfUseID");
            textEdit16.DataBindings.Add("Text", dt, "OperationSequenceNumber");
            textEdit17.DataBindings.Add("Text", dt, "ItemNumber");
            textEdit18.DataBindings.Add("Text", dt, "Stockroom");
            textEdit19.DataBindings.Add("Text", dt, "Bin");
            textEdit20.DataBindings.Add("Text", dt, "LotNumber");
            textEdit21.DataBindings.Add("Text", dt, "IssuedQuantity");
            textEdit22.DataBindings.Add("Text", dt, "ResourceComponentPolicy");
            textEdit23.DataBindings.Add("Text", dt, "QuantityType");
            textEdit24.Text = skuid;
            cm.Position = 0; // 如 index = 0;
            if(dtmaterial != null)
            { 
                textEdit25.DataBindings.Add("Text", dtmaterial, "LotNumber");
                textEdit26.DataBindings.Add("Text", dtmaterial, "RecvBatchNo");
                textEdit27.DataBindings.Add("Text", dtmaterial, "MaterialTrackID");
                textEdit28.DataBindings.Add("Text", dtmaterial, "QtyInStore");
                check[0][1] = check[0][2] = dtmaterial.Rows[0]["RecvBatchNo"].ToString();
                check[1][1] = check[1][2] = dtmaterial.Rows[0]["QtyInStore"].ToString();
            }
            else
            {
                this.checkEdit2.Enabled = false;
                this.checkEdit3.Enabled = false;
            }
            if (errinfo.Trim() != "")
            {
                this.textBox1.WordWrap = true;
                this.textBox1.Text = errinfo;
            }
            if (Retried[0] == "True")
            {
                this.checkEdit1.Checked = true;
                this.simpleButton1.Enabled = false;
                this.btn_delete.Enabled = false;
            }
            else
            {
                this.checkEdit1.Checked = false;
            }
        }
       
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            cm.EndCurrentEdit();//结束当前编辑操作
            if (dt.Rows.Count > 0)
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(Xml[0]);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (xdoc.FirstChild.FirstChild.Attributes[i] != null)
                    {
                        xdoc.FirstChild.FirstChild.Attributes[i].InnerText = dt.Rows[0][i].ToString();
                    }
                }
                Xml[0] = xdoc.InnerXml;
                if(Check[1][0] == "True")
                {
                    Check[1][1] = this.textEdit28.Text;
                    if(Check[1][1] == Check[1][2])
                    {
                        Check[1][0] = "False";
                    }
                }
                if(Check[0][0] == "True")
                {
                    if (Check[0][1] == Check[0][2])
                    {
                        Check[0][0] = "False";
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataTable _dt;
            string sql = "";
            if (textEdit20.Text.Length == 14)
                sql = string.Format("select ITEM,ITEM_DESC,BIN,QTY_BY_LOC,LOT from ERP.FSDBMR.dbo.StockDetail where ITEM = '{0}' AND LOT LIKE '{1}%'", textEdit17.Text, textEdit20.Text.Substring(0, textEdit20.Text.Length - 3));
            else if (textEdit20.Text.Length == 11)
                sql = string.Format("select ITEM,ITEM_DESC,BIN,QTY_BY_LOC,LOT from ERP.FSDBMR.dbo.StockDetail where ITEM = '{0}' AND LOT LIKE '{1}%'", textEdit17.Text, textEdit20.Text);
            _dt = DBhelp.Query(sql).Tables["ds"];
            frmserchstock f = new frmserchstock(_dt);
            f.ShowDialog();
        }

        private void PICKForm_Load(object sender, EventArgs e)
        {
            if(Skuid != "")
            {
                string sql = string.Format("select QtyLoaded from IRAPMES..RSFact_PWOMaterialTrack where " +
"WFInstanceID in (SELECT WFInstanceID from IRAPMES..AuxFact_PWOIssuing where MONumber = '{0}' and MOLineNo = '{1}') and SKUID = '{2}'", textEdit12.Text, textEdit13.Text, Skuid);
                try
                {
                    textEdit32.Text = Check[2][1] = Check[2][2] = DBhelp.getSingle(sql).ToString();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    WriteLog.Instance.Write(err.Message, "查询Qtyloaded出错");
                }
            }
        }
        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEdit4.Checked == true)
            {
                textEdit32.Text = ((long)(decimal.Parse(textEdit21.Text) * 1000000)).ToString();
                Check[2][1] = textEdit32.Text;
                Check[2][0] = "True";
            }
            else
            {
                this.textEdit32.Text = Check[2][2];
                Check[2][0] = "False";
            }
        }
        private void textEdit21_EditValueChanged(object sender, EventArgs e)
        {
            if (this.checkEdit4.Checked == true)
            {
                textEdit32.Text = ((long)(decimal.Parse(textEdit21.Text) * 1000000)).ToString();
                Check[2][1] = textEdit32.Text;
            }
        }

        private void btn_serch_Click(object sender, EventArgs e)
        {
            DataTable _dt;
            string sql = string.Format("select ITEM_DESC,BIN,QTY_BY_LOC from ERP.FSDBMR.dbo.StockDetail where ITEM = '{0}' AND LOT = '{1}'", textEdit17.Text, textEdit20.Text);
            _dt = DBhelp.Query(sql).Tables["ds"];
            textEdit29.DataBindings.Add("Text", _dt, "ITEM_DESC");
            textEdit30.DataBindings.Add("Text", _dt, "QTY_BY_LOC");
            textEdit31.DataBindings.Add("Text", _dt, "BIN");
            if (_dt.Rows.Count <= 0)
            {
                textEdit29.Text = "无记录";
                textEdit30.Text = "无记录";
                textEdit31.Text = "无记录";
            }

            this.btn_serch.Enabled = false;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (Retried[0] == "False")
            {
                DialogResult result = MessageBox.Show("您要删除这条信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (result == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Abort;
                }
            }
            else
            {
                MessageBox.Show("该记录的Retried值为1，无法再删除!");
            }
        }

        private void textEdit20_EditValueChanged(object sender, EventArgs e)
        {
            if(this.checkEdit2.Checked == true)
            {
                textEdit26.Text = textEdit20.Text;
                Check[0][1] = textEdit20.Text;
            }
        }
        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == true)
            {
                textEdit26.Text = textEdit20.Text;
                Check[0][1] = textEdit20.Text;
                Check[0][0] = "True";
            }
            else
            {
                textEdit26.Text = Check[0][2];
                Check[0][0] = "False";
            }
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            if(this.checkEdit3.Checked == true)
            {
                Check[1][0] = "True";
                this.textEdit28.ReadOnly = false; 
            }
            else
            {
                Check[1][0] = "False";
                this.textEdit28.Text = Check[1][2];
                this.textEdit28.ReadOnly = true;
            }
        }

        private void PICKForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}