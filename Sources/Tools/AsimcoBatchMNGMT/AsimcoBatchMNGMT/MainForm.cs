using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Threading;
using System.Data.SqlClient;
using System.Collections;
using System.Xml;
using System.Data.Linq;
using System.Diagnostics;

using DevExpress.XtraSplashScreen;

namespace AsimcoBatchMNGMT
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static DataTable stockdt;     //4班库存表
        public static DataTable materialdt;  //材料库存表
        public static DataTable maindt;      //主表
        public static DataView maindv;       //主视图
        public static DataTable checkdt;     //确认表
        public static DataTable checkdv;     //确认视图   
        public static string strRowFilter;   //过滤字符串
        public static string mainsql;
        WaitForm1 wf = new WaitForm1();

        public MainForm()
        {
            InitializeComponent();
        }

        //数据库配置后,从数据库加载数据
        private void bbi_config_ItemClick(object sender, ItemClickEventArgs e)
        {

            ValidateForm.Instance.ShowDialog();
            if (ValidateForm.Instance.DialogResult == DialogResult.OK)
            {
                RefreshData();

                bbi_refresh.Enabled = true;
                //可用一级筛选控件
                cboOperType.Enabled = true;
                cboOperType.Properties.Appearance.BackColor = Color.Gray;
                cboOperType.Properties.Appearance.ForeColor = Color.White;
                checkEdit1.Enabled = true;
                checkEdit1.Properties.Appearance.ForeColor = Color.White;
                checkEdit1.Properties.Appearance.BackColor = Color.Gray;
                bbi_log.Enabled = true;
                labelControl1.Visible = true;
                labelControl2.Visible = true;
                labelControl3.Visible = true;
                labelControl4.Visible = true;
                labelControl5.Visible = true;
                labelControl6.Visible = true;
                labelControl7.Visible = true;
                textEdit2.Visible = true;
                textEdit3.Visible = true;
                textEdit4.Visible = true;
                textEdit5.Visible = true;
                textEdit1.Visible = true;
                textEdit6.Visible = true;
                textEdit7.Visible = true;
            }
        }

        //卡片显示
        private void ShowCard()
        {
            if (gridView1.DataRowCount > 0)
            {
                string xml = gridView1.GetDataRow(gridView1.FocusedRowHandle)["ExChangeXML"].ToString();
                gridControl2.DataSource = DBhelp.XML2Table(xml);
                gridControl2.MainView.PopulateColumns();
                //隐藏cardView1无用属性
                for (int i = 0; i < 9; i++)
                {
                    cardView1.Columns[i].Visible = false;
                }
                if (gridView1.GetDataRow(gridView1.FocusedRowHandle)["Properties"].ToString() != "")
                {
                    string xml2 = gridView1.GetDataRow(gridView1.FocusedRowHandle)["Properties"].ToString();
                    DataTable tempstoredt = DBhelp.XML2Table(xml2);
                    tempstoredt.Columns.Add("LotNumber");
                    tempstoredt.Columns.Add("RecvBatchNo");
                    tempstoredt.Columns.Add("MaterialTrackID");
                    tempstoredt.Columns.Add("QtyInStore");
                    string selectsql3 = null;
                    if (tempstoredt.Columns.Contains("SKUID"))
                    {
                        selectsql3 = string.Format("SKUID = '{0}'", tempstoredt.Rows[0]["SKUID"].ToString());
                    }
                    DataTable tempdt = materialdt.Clone();
                    if (selectsql3 != null)
                    {
                        DataRow[] drArr = materialdt.Select(selectsql3);
                        if (drArr.Length > 0)
                        {
                            tempdt.ImportRow(drArr[0]);
                        }
                    }
                    if (tempdt.Rows.Count > 0)
                    {
                        tempstoredt.Rows[0]["LotNumber"] = tempdt.Rows[0]["LotNumber"];
                        tempstoredt.Rows[0]["RecvBatchNo"] = tempdt.Rows[0]["RecvBatchNo"];
                        tempstoredt.Rows[0]["MaterialTrackID"] = tempdt.Rows[0]["MaterialTrackID"];
                        tempstoredt.Rows[0]["QtyInStore"] = tempdt.Rows[0]["QtyInStore"];
                    }
                    else
                    {
                        tempstoredt.Rows[0]["LotNumber"] = "无记录";
                        tempstoredt.Rows[0]["RecvBatchNo"] = "无记录";
                        tempstoredt.Rows[0]["MaterialTrackID"] = "无记录";
                        tempstoredt.Rows[0]["QtyInStore"] = "无记录";
                    }

                    gridControl3.DataSource = tempstoredt;
                    gridControl3.MainView.PopulateColumns();

                    //隐藏cardView2无用属性
                    if (tempstoredt != null)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            cardView2.Columns[i].Visible = false;
                        }
                    }
                }

                //错误信息显示
                textBox1.Multiline = true;//多行显示
                textBox1.WordWrap = true; //文字断行显示
                textBox1.Width = 15;//这里设置显示10个文字的宽度像素
                if (gridView1.GetDataRow(gridView1.FocusedRowHandle)["ErrCode"].ToString() != "0"&&gridView1.GetDataRow(gridView1.FocusedRowHandle)["ErrCode"]!= null)
                {
                    this.panelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(244)))), ((int)(((byte)(191)))));
                    this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(244)))), ((int)(((byte)(191)))));
                    this.textBox1.Text = gridView1.GetDataRow(gridView1.FocusedRowHandle)["ErrCode"].ToString() + ":" + gridView1.GetDataRow(gridView1.FocusedRowHandle)["ErrText"].ToString();
                }
                else
                {
                    this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
                    this.textBox1.BackColor = System.Drawing.Color.White;
                    this.textBox1.Text = "";
                }
            }
            else
            {
                this.gridControl2.DataSource = null;
                this.gridControl3.DataSource = null;
                this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
                this.textBox1.BackColor = System.Drawing.Color.White;
                this.textBox1.Text = "";
            }
            cardView1.OptionsBehavior.Editable = false;
            cardView1.Appearance.FieldValue.BackColor = Color.Transparent;
            cardView1.Appearance.FieldValue.ForeColor = Color.Black;
        }

        //操作类型变更事件
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {       
            filter();
        }

        //未成功检查框变更事件
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            filter();
        }

        //gridView1焦点变更
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ShowCard();
        }

        //自定义cardview标题
        private void cardView1_CustomDrawCardCaption(object sender, DevExpress.XtraGrid.Views.Card.CardCaptionCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.CardView view = sender as DevExpress.XtraGrid.Views.Card.CardView;
            (e.CardInfo as DevExpress.XtraGrid.Views.Card.ViewInfo.CardInfo).CaptionInfo.CardCaption = "ExChangeXML";
        }

        private void cardView2_CustomDrawCardCaption(object sender, DevExpress.XtraGrid.Views.Card.CardCaptionCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.CardView view = sender as DevExpress.XtraGrid.Views.Card.CardView;
            (e.CardInfo as DevExpress.XtraGrid.Views.Card.ViewInfo.CardInfo).CaptionInfo.CardCaption = "MaterialStore";
        }

        //查询
        private void filter()
        {
            maindv.Sort = "LinkedLogID asc,LogID asc";
            gridControl1.DataSource = maindv;
            if (maindv != null)
            {
                if (checkEdit1.Checked)
                {
                    if (cboOperType.Text != "所有" && cboOperType.Text != "操作类型")
                        strRowFilter = "ExCode ='" + cboOperType.Text + "'and ErrCode <> 0 and Retried = 0";
                    else
                        strRowFilter = "ErrCode <> 0 and Retried = 0";
                }
                else
                {
                    if (cboOperType.Text != "所有" && cboOperType.Text != "操作类型")
                        strRowFilter = "ExCode ='" + cboOperType.Text + "'";
                    else
                        strRowFilter = "";
                }
                string _strRowFilter = "";
                if (textEdit2.Text.Trim() != "")
                    _strRowFilter += "ItemNumber like '%" + textEdit2.Text.Trim() + "%' and ";
                if (textEdit3.Text.Trim() != "")
                    _strRowFilter += "LotNumber like '%" + textEdit3.Text.Trim() + "%' and ";
                if (textEdit4.Text.Trim() != "")
                    _strRowFilter += "(BinFrom like '%" + textEdit4.Text.Trim() + "%' or BinTo like '%" + textEdit4.Text.Trim() + "%') and ";
                if (textEdit5.Text.Trim() != "")
                    _strRowFilter += labelControl4.Text + " like '%" + textEdit5.Text.Trim() + "%' and ";
                if (textEdit1.Text.Trim() != "")
                    _strRowFilter += labelControl5.Text + " = " + textEdit1.Text.Trim() + " and ";
                if (textEdit6.Text.Trim() != "")
                    _strRowFilter += "OrderNumber like '%" + textEdit6.Text.Trim() + "%' and ";
                if (textEdit7.Text.Trim() != "")
                    _strRowFilter += "OLineNo like '%" + textEdit7.Text.Trim() + "%' and ";

                if (_strRowFilter != "")
                {
                    _strRowFilter = _strRowFilter.Substring(0, _strRowFilter.Length - 5);   //删除多余字符
                    if (strRowFilter != "")
                    {
                        strRowFilter = string.Format("{0} and {1}", strRowFilter, _strRowFilter);
                    }
                    else
                        strRowFilter = _strRowFilter;
                    try
                    {
                        maindv.RowFilter = strRowFilter;
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    ShowCard();
                }
                else
                {
                    maindv.RowFilter = strRowFilter;
                    ShowCard();
                }
                if (gridView1.RowCount!=0)
                {
                    if (gridView1.IsGroupRow(-1) == true)
                    {
                        if (gridView1.GetDataRow(0)["SKUID"].ToString() == "" || gridView1.GetDataRow(0) == null)
                        {
                            gridView1.SetRowExpanded(-1, false);
                        }
                    }
                    gridView1.FocusedRowHandle = -1;
                }       
            }
            else
            {
                gridView1.FocusedRowHandle = -1;
                ShowCard();
            }
        }

        //判断窗口最大化
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.cardView1.CardWidth = 550;
                this.cardView2.CardWidth = 550;
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                this.cardView1.CardWidth = 353;
                this.cardView2.CardWidth = 353;
            }
        }

        private void bbi_log_ItemClick(object sender, ItemClickEventArgs e)
        {
            string logPath = string.Format(@"{0}Log\IRAP_{1}.log",
                                    AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd"));
            if (!System.IO.Directory.Exists(logPath))
            {
                try
                {
                    System.Diagnostics.Process.Start(logPath); //打开此文件。
                }
                catch
                {
                    MessageBox.Show("今天还没有日志生成！");
                }
            }
        }

        //获取并显示数据
        private void LoadTask()
        {
            Task task1 = Task.Factory.StartNew(() =>
            {
                string sql3 = "Select * from IRAPRIMCS..utb_MaterialStore";
                if (materialdt != null)
                {
                    materialdt.Clear();
                }
                try
                {
                    materialdt = DBhelp.Query(sql3).Tables["ds"];
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    WriteLog.Instance.Write(e.Message, "加载材料库存数据失败");
                }
            });
            splashScreenManager1.SetWaitFormDescription("获取数据中...");
            if (maindt != null)
            {
                maindt.Clear();
            }
            try
            {
                maindt = DBhelp.Query(mainsql).Tables["ds"];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                WriteLog.Instance.Write(e.Message, "加载主数据失败!");
            }
            splashScreenManager1.SetWaitFormDescription("显示数据中...");
            maindt.PrimaryKey = new DataColumn[] { maindt.Columns["LogID"] };
            maindt.Columns.Add("ItemNumber").SetOrdinal(4);
            maindt.Columns.Add("LotNumber").SetOrdinal(5);
            maindt.Columns.Add("BinFrom").SetOrdinal(6);
            maindt.Columns.Add("BinTo").SetOrdinal(7);
            maindt.Columns.Add("OrderNumber").SetOrdinal(8);
            maindt.Columns.Add("OLineNo");
            maindt.Columns.Add("Quantity").SetOrdinal(8);
            maindt.Columns.Add("SKUID").SetOrdinal(9);

            //更改ExCode并为列赋值
            for (int i = 0; i < maindt.Rows.Count; i++)
            {
                SetDTRow((long)maindt.Rows[i]["LogID"], 1);
            }
            gridControl1.UseEmbeddedNavigator = true;
            gridControl1.EmbeddedNavigator.Enabled = false;
            maindv = maindt.DefaultView;
            maindv.Sort = "LinkedLogID asc,LogID asc";
            gridControl1.DataSource = maindv;
            gridControl1.MainView.PopulateColumns();
            //隐藏gridView1无用属性
            gridView1.Columns["ErrCode"].Visible = false;
            gridView1.Columns["Retried"].Visible = false;
            gridView1.Columns["LinkedLogID"].Visible = false;
            gridView1.Columns["ExChangeXML"].Visible = false;
            gridView1.Columns["ErrText"].Visible = false;
            gridView1.Columns["Properties"].Visible = false;
            gridView1.Columns["SKUID"].GroupIndex = 0;
            gridView1.BestFitColumns();
            Task.WaitAll(task1);
        }

        //刷新数据
        private void RefreshData()
        {
           
            this.splashScreenManager1.ShowWaitForm();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            LoadTask();     
            if (gridView1.RowCount != 0)
            {
                filter();
            }
            stopwatch.Stop();
            WriteLog.Instance.Write(maindt.Rows.Count.ToString() + "条,"+string.Format("{0}ms",stopwatch.ElapsedMilliseconds.ToString()), "数据获取成功");
            splashScreenManager1.CloseWaitForm();
        }

        //获取解析的XML数据
        private void SetDTRow(long LogID,int mode)
        {
            DataRow dr = maindt.Rows.Find(LogID);
            DataTable tempdt = DBhelp.XML2Table(dr["ExChangeXML"].ToString());
            if (dr["Properties"].ToString() != "")
            {
                DataTable tempdt2 = DBhelp.XML2Table(dr["Properties"].ToString());
                if (tempdt2.Columns.Contains("SKUID"))
                {
                    dr["SKUID"] = tempdt2.Rows[0]["SKUID"];
                }
            }
            if (dr["ExCode"].ToString() == "PICK08"|| dr["ExCode"].ToString() == "提料")
            {
                dr["ExCode"] = "PICK08";
                dr["ItemNumber"] = tempdt.Rows[0]["ItemNumber"];
                dr["LotNumber"] = tempdt.Rows[0]["LotNumber"];
                dr["BinFrom"] = tempdt.Rows[0]["Bin"];
                dr["Quantity"] = tempdt.Rows[0]["IssuedQuantity"];
                dr["OrderNumber"] = tempdt.Rows[0]["OrderNumber"];
                dr["OLineNO"] = tempdt.Rows[0]["LineNumber"];
                if(mode ==2)
                {
                    gridView1.SetFocusedRowCellValue("ItemNumber", tempdt.Rows[0]["ItemNumber"]);
                    gridView1.SetFocusedRowCellValue("LotNumber", tempdt.Rows[0]["LotNumber"]);
                    gridView1.SetFocusedRowCellValue("BinFrom", tempdt.Rows[0]["Bin"]);
                    gridView1.SetFocusedRowCellValue("Quantity", tempdt.Rows[0]["IssuedQuantity"]);
                }
            }
            else if (dr["ExCode"].ToString() == "IMTR01" || dr["ExCode"].ToString() == "移库")
            {
                dr["ExCode"] = "IMTR01";
                dr["ItemNumber"] = tempdt.Rows[0]["ItemNumber"];
                dr["LotNumber"] = tempdt.Rows[0]["LotNumberFrom"];
                dr["BinFrom"] = tempdt.Rows[0]["BinFrom"];
                dr["BinTo"] = tempdt.Rows[0]["BinTo"];
                dr["Quantity"] = tempdt.Rows[0]["InventoryQuantity"];
                if(mode ==2)
                {
                    gridView1.SetFocusedRowCellValue("ItemNumber", tempdt.Rows[0]["ItemNumber"]);
                    gridView1.SetFocusedRowCellValue("LotNumber", tempdt.Rows[0]["LotNumberFrom"]);
                    gridView1.SetFocusedRowCellValue("BinFrom", tempdt.Rows[0]["BinFrom"]);
                    gridView1.SetFocusedRowCellValue("BinTo", tempdt.Rows[0]["BinTo"]);
                    gridView1.SetFocusedRowCellValue("Quantity", tempdt.Rows[0]["InventoryQuantity"]);
                }
            }
            else if (dr["ExCode"].ToString() == "PORV01" || dr["ExCode"].ToString() == "入库")
            {
                dr["ExCode"] = "PORV01";
                dr["ItemNumber"] = tempdt.Rows[0]["ItemNumber"];
                dr["LotNumber"] = tempdt.Rows[0]["LotNumberDefault"];
                dr["BinTo"] = tempdt.Rows[0]["Bin1"];
                dr["Quantity"] = tempdt.Rows[0]["ReceiptQuantityMove1"];
                dr["OrderNumber"] = tempdt.Rows[0]["PONumber"];
                dr["OLineNO"] = tempdt.Rows[0]["POLineNumber"];
                if (mode == 2)
                {
                    gridView1.SetFocusedRowCellValue("ItemNumber", tempdt.Rows[0]["ItemNumber"]);
                    gridView1.SetFocusedRowCellValue("LotNumber", tempdt.Rows[0]["LotNumberDefault"]);
                    gridView1.SetFocusedRowCellValue("BinTo", tempdt.Rows[0]["Bin1"]);
                    gridView1.SetFocusedRowCellValue("Quantity", tempdt.Rows[0]["ReceiptQuantityMove1"]);
                }
            }
            else if (dr["ExCode"].ToString() == "MORV00")
            {
                dr["ExCode"] = "MORV00";
                dr["ItemNumber"] = tempdt.Rows[0]["ItemNumber"];
                dr["LotNumber"] = tempdt.Rows[0]["LotNumber"];
                dr["BinFrom"] = tempdt.Rows[0]["Bin1"];
                dr["Quantity"] = tempdt.Rows[0]["ReceiptQuantity"];
                dr["OrderNumber"] = tempdt.Rows[0]["MONumber"];
                dr["OLineNO"] = tempdt.Rows[0]["MOLineNumber"];
            }
            else if (dr["ExCode"].ToString() == "INVA01")
            {
                dr["ExCode"] = "INVA01";
                dr["ItemNumber"] = tempdt.Rows[0]["ItemNumber"];
                dr["LotNumber"] = tempdt.Rows[0]["LotNumber"];
                dr["BinTo"] = tempdt.Rows[0]["Bin"];
                dr["Quantity"] = tempdt.Rows[0]["AdjustQuantity"];
            }
            tempdt.Clear();
        }
        
        private void bbi_refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshData();
        }

        //取数据库中最新的LogID
        private object GetLastLogID(long LinkedLogID)
        {
            string sql = string.Format("select LogID from IRAP..stb_Log_WebServiceShuttling where LinkedLogID ={0} and Retried = 0",LinkedLogID);
            object rlt = null;
            try
            {
                rlt =DBhelp.getSingle(sql);
            }
            catch(SqlException e)
            {
                MessageBox.Show("获取最新logID失败:" + e.Message);
                WriteLog.Instance.Write(e.Message, "获取最新logID失败");
            }
            return rlt;       
        }

        //显示编辑窗口
        public void ShowEditForm()
        {
            string[][] check = new string[3][];
            check[0] = new string[] { "False", "False", "False" };   //是否提交
            check[1] = new string[] { "", "", "" };                 //返回 RecvBatchNo,QtyInStore,QtyLoaded的值
            check[2] = new string[] { "", "", "" };                 //默认值
            string selectsql3 = null;
            long LogID = long.Parse(gridView1.GetDataRow(gridView1.FocusedRowHandle)["LogID"].ToString());
            long LinkedLogID = long.Parse(gridView1.GetDataRow(gridView1.FocusedRowHandle)["LinkedLogID"].ToString());
            string skuid = "";
            string[] retried = { gridView1.GetDataRow(gridView1.FocusedRowHandle)["Retried"].ToString(), gridView1.GetDataRow(gridView1.FocusedRowHandle)["Retried"].ToString() };
            string[] xml = { gridView1.GetDataRow(gridView1.FocusedRowHandle)["ExChangeXML"].ToString(), gridView1.GetDataRow(gridView1.FocusedRowHandle)["ExChangeXML"].ToString() };
            DataTable tempdt = DBhelp.XML2Table(xml[0]);
            if (xml[0] != "")
            {
                XmlDocument xdoc = new XmlDocument();
                if (gridView1.GetDataRow(gridView1.FocusedRowHandle)["Properties"].ToString().Trim() != "")
                {
                    xdoc.LoadXml(gridView1.GetDataRow(gridView1.FocusedRowHandle)["Properties"].ToString());
                    if (xdoc.FirstChild.SelectSingleNode("SKUID") != null)
                    {
                        skuid = xdoc.FirstChild.SelectSingleNode("SKUID").InnerText;
                        selectsql3 = string.Format("SKUID = '{0}'", skuid);
                    }
                }
                DialogResult dia = new DialogResult();
                DataTable dtNew3 = materialdt.Clone();
                string errinfo = gridView1.GetDataRow(gridView1.FocusedRowHandle)["ErrCode"].ToString() + ":" + gridView1.GetDataRow(gridView1.FocusedRowHandle)["ErrText"].ToString();
                if (selectsql3 != null)
                {
                    DataRow[] drArr3 = materialdt.Select(selectsql3);
                    if (drArr3.Length > 0)
                    {
                        dtNew3.ImportRow(drArr3[0]);
                    }
                    if (dtNew3.Rows.Count <= 0)
                    {
                        dtNew3 = null;
                    }
                }
                if (gridView1.GetDataRow(gridView1.FocusedRowHandle)["ExCode"].ToString() == "IMTR01")
                {
                    IMTRForm im = null;
                    im = new IMTRForm(xml, skuid, errinfo, retried, dtNew3, check);
                    dia = im.ShowDialog();
                }
                else if (gridView1.GetDataRow(gridView1.FocusedRowHandle)["ExCode"].ToString() == "PORV01")
                {
                    PORVForm po = null;
                    po = new PORVForm(xml, skuid, errinfo, retried, dtNew3, check);
                    dia = po.ShowDialog();
                }
                else if (gridView1.GetDataRow(gridView1.FocusedRowHandle)["ExCode"].ToString() == "PICK08")
                {
                    PICKForm pi = null;
                    pi = new PICKForm(xml, skuid, errinfo, retried, dtNew3, check);
                    dia = pi.ShowDialog();
                }
                if (dia == DialogResult.OK)
                {
                    string sql = "update IRAP..stb_Log_WebServiceShuttling set ExChangeXML = @ExChangeXML where LogID = @LogID and PartitioningKey ='600100000'";
                    SqlParameter[] paras = new SqlParameter[2];
                    if (GetLastLogID(LinkedLogID) != null)
                    {
                        long LastLogID = (long)GetLastLogID(LinkedLogID);
                        WriteLog.Instance.WriteBeginSplitter("开始编辑记录LogID =" + LastLogID.ToString() + string.Format(";Retried = {0}", retried[0]));
                        paras[0] = new SqlParameter("@ExChangeXML", xml[0]);
                        paras[1] = new SqlParameter("@LogID", LastLogID);
                        int i = 2;
                        try
                        {
                            i = DBhelp.ExecuteSQL(sql, paras);
                        }
                        catch (SqlException err)
                        {
                            WriteLog.Instance.Write(err.Message, "更改ExChangeXml失败");
                            WriteLog.Instance.Write(xml[1], "更改前的ExChangeXml");
                            WriteLog.Instance.Write(xml[0], "更改后的ExChangeXml");
                            MessageBox.Show(err.Message);
                        }
                        if (i == 0)
                        {
                            WriteLog.Instance.Write("未找到记录：", "更改ExChangeXml失败");
                            WriteLog.Instance.Write(xml[1], "更改前的ExChangeXml");
                            WriteLog.Instance.Write(xml[0], "更改后的ExChangeXml");
                            MessageBox.Show("保存失败");
                        }
                        else if (i == 1)
                        {
                            WriteLog.Instance.Write("成功", "更改ExChangeXml成功");
                            WriteLog.Instance.Write(xml[1], "更改前的ExChangeXml");
                            WriteLog.Instance.Write(xml[0], "更改后的ExChangeXml");
                            string name = "IRAP..ssp_BackgroundJob_WSRetry";
                            SqlParameter[] paras3 = new SqlParameter[5];
                            paras3[0] = new SqlParameter("@SysLogID", 1);
                            paras3[1] = new SqlParameter("@CommunityID", 60010);
                            paras3[2] = new SqlParameter("@WSSLogID", LastLogID);
                            paras3[3] = new SqlParameter("@ErrCode", SqlDbType.Int, 4);
                            paras3[3].Direction = ParameterDirection.Output;
                            paras3[4] = new SqlParameter("@ErrText", SqlDbType.NVarChar, 400);
                            paras3[4].Direction = ParameterDirection.Output;
                            int j = 2;
                            try
                            {
                                j = DBhelp.ExecuteProc(name, paras3);
                            }
                            catch (SqlException err)
                            {
                                MessageBox.Show(err.Message);
                                WriteLog.Instance.Write(err.Message, "WSRrtry执行失败");
                            }
                            if (j == -1)
                            {
                                WriteLog.Instance.Write(string.Format("ErrCode = {0},{1}", paras3[3].Value.ToString(), paras3[4].Value.ToString()), "WSRetry执行成功");
                                MessageBox.Show(string.Format("ErrCode = {0},{1}", paras3[3].Value.ToString(), paras3[4].Value.ToString()));
                                if (check[0][0] == "True")
                                {
                                    int flag = 2;
                                    string sql2 = "update IRAPRIMCS..utb_MaterialStore set RecvBatchNo = @RecvBatchNo where SKUID =@SKUID";
                                    SqlParameter[] paras2 = new SqlParameter[2];
                                    paras2[0] = new SqlParameter("@RecvBatchNo", check[0][1]);
                                    paras2[1] = new SqlParameter("@SKUID", skuid);
                                    try
                                    {
                                        flag = DBhelp.ExecuteSQL(sql2, paras2);
                                        if (flag == 0)
                                        {
                                            WriteLog.Instance.Write(string.Format("更改RecvbatcNo = {0}为RecvBatchNo = {1}", check[0][2], check[0][1]), "更改RecvBatchNo失败，未找到记录");
                                        }
                                        else if (flag == 1)
                                        {
                                            WriteLog.Instance.Write(string.Format("更改RecvbatcNo = {0}为RecvBatchNo = {1}", check[0][2], check[0][1]), "更改RecvBatchNo成功");
                                        }
                                    }
                                    catch (SqlException err)
                                    {
                                        MessageBox.Show(err.Message);
                                        WriteLog.Instance.Write(string.Format("更改RecvbatcNo = {0}更改RecvbatcNo = {1}", check[0][2], check[0][1]), "更改更改RecvbatcNo失败" + err.Message);
                                    }
                                }
                                if (check[1][0] == "True")
                                {
                                    int flag = 2;
                                    string sql2 = "update IRAPRIMCS..utb_MaterialStore set QtyInStore = @QtyInStore where SKUID =@SKUID";
                                    SqlParameter[] paras2 = new SqlParameter[2];
                                    paras2[0] = new SqlParameter("@QtyInStore", check[1][1]);
                                    paras2[1] = new SqlParameter("@SKUID", skuid);
                                    try
                                    {
                                        flag = DBhelp.ExecuteSQL(sql2, paras2);
                                        if (flag == 0)
                                        {
                                            WriteLog.Instance.Write(string.Format("更改QtyInStore = {0}为QtyInStore = {1}", check[1][2], check[1][1]), "更改QtyInStore失败，未找到记录");
                                        }
                                        else if (flag == 1)
                                        {
                                            WriteLog.Instance.Write(string.Format("更改QtyInStore = {0}为QtyInStore = {1}", check[1][2], check[1][1]), "更改QtyInStore成功");
                                        }
                                    }
                                    catch (SqlException err)
                                    {
                                        MessageBox.Show(err.Message);
                                        WriteLog.Instance.Write(string.Format("更改QtyInStore = {0}更改QtyInStore = {1}", check[1][2], check[1][1]), "更改更改QtyInStore失败" + err.Message);
                                    }
                                }
                                if (check[2][1] != check[2][2] && check[2][0] == "True")
                                {
                                    int flag = 2;
                                    string sql2 = "update IRAPMES..RSFact_PWOMaterialTrack set QtyLoaded = @QtyLoaded where WFInstanceID in (SELECT WFInstanceID from IRAPMES..AuxFact_PWOIssuing where MONumber =@MONumber and MOLineNo =@MOLineNo) and SKUID =@SKUID";
                                    SqlParameter[] paras2 = new SqlParameter[4];
                                    paras2[0] = new SqlParameter("@QtyLoaded", check[2][1]);
                                    paras2[1] = new SqlParameter("@MONumber", tempdt.Rows[0]["OrderNumber"].ToString());
                                    paras2[2] = new SqlParameter("@MOLineNo", tempdt.Rows[0]["LineNumber"].ToString());
                                    paras2[3] = new SqlParameter("@SKUID", skuid);
                                    try
                                    {
                                        flag = DBhelp.ExecuteSQL(sql2, paras2);
                                        if (flag == 0)
                                        {
                                            WriteLog.Instance.Write(string.Format("更改QtyLoaded = {0}为QtyLoaded = {1}", check[2][2], check[2][1]), "更改QtyLoaded失败,未找到记录");
                                        }
                                        else if (flag == 1)
                                        {
                                            WriteLog.Instance.Write(string.Format("更改QtyLoaded = {0}为QtyLoaded = {1}", check[2][2], check[2][1]), "更改QtyLoaded成功");
                                        }
                                    }
                                    catch (Exception err)
                                    {
                                        MessageBox.Show(err.Message);
                                        WriteLog.Instance.Write(string.Format("更改QtyLoaded = {0}为QtyLoaded = {1}", check[2][2], check[2][1]), "更改QtyLoaded失败" + err.Message);
                                    }
                                }
                                WriteLog.Instance.WriteEndSplitter("结束编辑记录");
                                RefreshData();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("该LinkedLogID下无Retried=0的记录，请刷新数据");
                    }
                }
                else if (dia == DialogResult.Abort)
                {
                    string sql = "update IRAP..stb_Log_WebServiceShuttling set Retried = @Retried where LogID = @LogID";
                    SqlParameter[] paras = new SqlParameter[2];
                    if (GetLastLogID(LinkedLogID) != null)
                    {
                        long LastLogID = (long)(LogID);
                        paras[0] = new SqlParameter("@Retried", 1);
                        paras[1] = new SqlParameter("@LogID", LastLogID);
                        try
                        {
                            if (DBhelp.ExecuteSQL(sql, paras) == 1)
                            {
                                MessageBox.Show("删除成功");
                                WriteLog.Instance.WriteBeginSplitter("开始删除记录LogID =" + LastLogID.ToString() + string.Format(";Retried = {0}", retried[0]));
                                WriteLog.Instance.Write(xml[1], "删除记录成功");
                                WriteLog.Instance.WriteEndSplitter("结束删除记录");
                                RefreshData();
                            }
                        }
                        catch (SqlException err)
                        {
                            MessageBox.Show("删除失败:" + err.Message);
                            WriteLog.Instance.WriteBeginSplitter("开始删除记录LogID =" + LastLogID.ToString() + string.Format(";Retried = {0}", retried[0]));
                            WriteLog.Instance.Write(err.Message, "删除记录失败");
                            WriteLog.Instance.Write(xml[1], "删除记录失败");
                            WriteLog.Instance.WriteEndSplitter("结束删除记录");
                        }
                    }
                    else
                    {
                        MessageBox.Show("该LinkedLogID下无Retried=0的记录，请刷新数据");
                    }
                }
            }
        }
        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内 
                if (hInfo.InRow)
                {
                    if (!gridView1.IsGroupRow(gridView1.FocusedRowHandle))      //不是分组行
                    {
                        ShowEditForm();
                    }
                }
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit1.Text.Length > 6 || textEdit1.Text.Length == 0)
            {
                filter();
            }         
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (gridView1.RowCount != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int rowHandle = gridView1.FocusedRowHandle;

                    if (gridView1.IsGroupRow(rowHandle) == true)
                    {
                        gridView1.SetRowExpanded(rowHandle, !gridView1.GetRowExpanded(rowHandle));
                    }
                    else
                    {
                        ShowEditForm();
                    }
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports rts = new Reports();
            rts.ShowDialog();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            //RefreshData();
        }
    }
}