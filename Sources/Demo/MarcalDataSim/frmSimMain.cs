﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Configuration;

using DevExpress.XtraEditors;

namespace MarcalDataSim
{
    public partial class frmSimMain : DevExpress.XtraEditors.XtraForm
    {
        private IPEndPoint ipep = null;

        public frmSimMain()
        {
            InitializeComponent();

            //IPHostEntry hostInfo = Dns.GetHostEntry(@"irap.vicp.net");
            IPHostEntry hostInfo = Dns.GetHostEntry(@"localhost");

            foreach (IPAddress ip in hostInfo.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipep = new IPEndPoint(ip, 30000);
                }
            }

            if (ConfigurationManager.AppSettings["DCSAddress"] != null)
                ipep = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["DCSAddress"]), 30000);
            else
                ipep = new IPEndPoint(IPAddress.Parse("192.168.1.2"), 30000);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (ipep == null)
            {
                WriteLog("初始化 Socket 服务地址失败");
            }

            try
            {
                string outBufferStr;
                byte[] outBuffer = new byte[1024];
                byte[] inBuffer = new byte[1024];

                int idxUnitOfMeasure = rgpUnifOfMeasure.SelectedIndex;
                outBufferStr =
                    edtSimData.Text.Trim() +
                    rgpUnifOfMeasure.Properties.Items[idxUnitOfMeasure].Value.ToString();
                WriteLog(outBufferStr);
                outBuffer = Encoding.ASCII.GetBytes(outBufferStr);

                using (Socket client =
                    new Socket(
                        ipep.AddressFamily,
                        SocketType.Stream,
                        ProtocolType.Tcp))
                {
                    client.Connect(ipep);
                    client.Send(outBuffer, outBuffer.Length, SocketFlags.None);
                    client.Receive(inBuffer, SocketFlags.None);
                    WriteLog(Encoding.ASCII.GetString(inBuffer).Trim());
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
            }
            catch
            {
                WriteLog("服务未开启！");
            }

            edtSimData.Focus();
        }

        private void WriteLog(string message)
        {
            //if (mmeLogs.Text.Trim() != "")
            //    mmeLogs.Text += "\r\n";

            if (message.Trim() != "")
            {
                message = 
                    string.Format(
                        "{0}: {1}",
                        DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                        message).Trim('\0');

                mmeLogs.Text = 
                    string.Format(
                        "{0}\r\n{1}",
                        message,
                        mmeLogs.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void edtSimData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSend.PerformClick();
            }
        }

        private void frmSimMain_Activated(object sender, EventArgs e)
        {
            edtSimData.Focus();
        }
    }
}