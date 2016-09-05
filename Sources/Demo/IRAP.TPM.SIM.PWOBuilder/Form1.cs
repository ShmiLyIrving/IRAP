using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace IRAP.TPM.SIM.PWOBuilder
{
    public partial class Form1 : Form
    {
        private IConnectionFactory factory = null;
        string content = 
            "<Content><Message T107Code=\"{0}\" "+
            "PWONo=\"34PEP1CD6360615001\" T20LeafID=\"353207\" "+
            "T216LeafID=\"2292530\" T133LeafID=\"2244450\" "+
            "SendDateTime=\"{1}\" /></Content>";

        public Form1()
        {
            InitializeComponent();
        }

        private void InitActiveMQ()
        {
            try
            {
                factory = new ConnectionFactory("tcp://192.168.1.2:61616/");

                edtContent.Enabled = true;
                btnSend.Enabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    string.Format("ActiveMQ 初始化失败：{0}", e.Message),
                    "系统提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                edtContent.Enabled = false;
                btnSend.Enabled = false;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            InitActiveMQ();

            edtContent.Text = "";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            using (IConnection connection = factory.CreateConnection())
            {
                using (ISession session = connection.CreateSession())
                {
                    IMessageProducer prod = session.CreateProducer(
                        new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("IRAPDCS_MEQ"));
                        //new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("IRAPTPM_InQueue"));
                    ITextMessage message = prod.CreateTextMessage();
                    message.Text = 
                        string.Format(
                            content, 
                            edtContent.Text,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    message.Properties.SetString("filter", edtContent.Text);
                    prod.Send(message, MsgDeliveryMode.Persistent, MsgPriority.Normal, TimeSpan.MinValue);
                    MessageBox.Show("发送成功!");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
