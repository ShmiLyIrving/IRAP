using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using OPCAutomation;

namespace OPCClient.UserContols
{
    public partial class ucOPCServer : OPCClient.UserContols.ucCustomBase
    {
        /// <summary>
        ///  OPCServer 的 IP 地址
        /// </summary>
        private string remoteOPCServerIP = "";

        public ucOPCServer()
        {
            InitializeComponent();
        }

        public ucOPCServer(string title) : base(title)
        {
            InitializeComponent();
        }

        public string OPCServerIP
        {
            get { return remoteOPCServerIP; }
            set
            {
                remoteOPCServerIP = value;

                // 连接 OPCSever
                Thread threadConnectOPCServer = new Thread(ConnectRemoteServerInThread);
                threadConnectOPCServer.IsBackground = true;
                threadConnectOPCServer.Start();
            }
        }

        private void ConnectRemoteServerInThread()
        {

        }
    }
}
