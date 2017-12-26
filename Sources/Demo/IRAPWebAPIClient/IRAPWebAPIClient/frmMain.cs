using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace IRAPWebAPIClient
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string url = "";

            switch (cboModuleName.Text)
            {
                case "Exchange":
                    url = string.Format(
                        "{0}{1}/{2}/{3}/{4}",
                        edtAddress.Text,
                        cboModuleName.Text,
                        edtClientID.Text,
                        cboContextType.Text,
                        edtExCode.Text);
                    break;
                default:
                    MessageBox.Show(
                        string.Format("目前不支持模块 [{0}]", cboModuleName.Text),
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/stream;";
            request.KeepAlive = false;
            request.AllowAutoRedirect = true;
            request.CookieContainer = new CookieContainer();
            request.Timeout = 30000;        // 单位：毫秒

            try
            {
                Stream stream = request.GetRequestStream();

                byte[] requestContext = Encoding.UTF8.GetBytes(edtRequest.Text);
                stream.Write(requestContext, 0, requestContext.Length);
                stream.Flush();
                stream.Close();
                Application.DoEvents();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string resJson = "";
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    resJson = sr.ReadToEnd();
                }

                edtResponse.Text = resJson;
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    error.Message,
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            cboModuleName.SelectedIndex = 0;
            cboContextType.SelectedIndex = 0;
            edtClientID.Text = "MESDeveloper";
            edtExCode.Text = "IRAP_MES_GetOPCServerTagList";

            edtRequest.Text = "{\"CommunityID\":\"60002\",\"SysLogID\":\"1\"}";
        }
    }
}
