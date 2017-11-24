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
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace AsimcoBatchMNGMT
{
    public partial class ValidateForm : DevExpress.XtraEditors.XtraForm
    {
        private static ValidateForm instance;
        public static string attributeFileName = string.Format("{0}IRAP.ini",
                                                  AppDomain.CurrentDomain.BaseDirectory);
        public static ValidateForm Instance
        {
            get
            {
                if (instance == null)
                    instance = new ValidateForm();
                instance.Disposed += new EventHandler(instance_Disposed);
                return instance;
            }
        }
        /// <summary>  
        /// 如果释放资源，也要释放此类中的对象（在此类中）  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        static void instance_Disposed(object sender, EventArgs e)
        {
            instance = null;

        }
        public static string connStr = null;
        /// <summary>
        /// 无边框窗体拖动
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;    
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        private  ValidateForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connStr = "server="+edtLink.Text+";database=" + edtDB.Text + ";uid=" + edtUserCode.Text + ";pwd=" + edtUserPWD.Text;
            MainForm.mainsql = "select Retried,LinkedLogID,LogID,ExCode,ErrCode,ErrText,ExChangeXML,Properties from IRAP..stb_Log_WebServiceShuttling ";
            try
            {
                using (SqlConnection sc = new SqlConnection(connStr))
                {
                    sc.Open();
                    sc.Close();
                }
                DBhelp.ConnStr = connStr;
                WriteLog.Instance.Write(edtLink.Text, "数据库验证成功");
                this.DialogResult = DialogResult.OK;
                
            }
            catch(Exception err)
            {
                MessageBox.Show("登录失败！"+err.Message);
                WriteLog.Instance.Write(connStr + err.Message, "数据库验证失败");
                this.Dispose();
            }

            if(comboBoxEdit1.Text == "仅未成功")
            {
                MainForm.mainsql += "where ErrCode != 0 and Retried =0";
            }
            else if(comboBoxEdit1.Text == "最近两天")
            { 
                string beginday = DateTime.Now.AddDays(-1).Date.ToString("yyyy-MM-dd");
                MainForm.mainsql += string.Format("where NextRetryTime>='{0}'", beginday);
            }
        }

        private void ValidateForm_Load(object sender, EventArgs e)
        {
            this.edtDB.Text = IniFile.ReadString("Server", "Database", "IRAPRIMCS",attributeFileName);
            this.edtLink.Text = IniFile.ReadString("Server", "Host", "192.168.1.2", attributeFileName);
            this.edtUserCode.Text = IniFile.ReadString("Server", "Uid", "sa", attributeFileName);
            this.edtUserPWD.Text = IniFile.ReadString("Server", "Pwd", "CyprMes571", attributeFileName);
            this.comboBoxEdit1.Text = IniFile.ReadString("Server", "Filter", "仅未成功", attributeFileName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IniFile.WriteString("Server", "Database", edtDB.Text, attributeFileName);
            IniFile.WriteString("Server", "Host", edtLink.Text, attributeFileName);
            IniFile.WriteString("Server", "Uid", edtUserCode.Text, attributeFileName);
            IniFile.WriteString("Server", "Pwd", edtUserPWD.Text, attributeFileName);
            IniFile.WriteString("Server", "Filter", comboBoxEdit1.Text, attributeFileName);
            btnLogin.PerformClick();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}