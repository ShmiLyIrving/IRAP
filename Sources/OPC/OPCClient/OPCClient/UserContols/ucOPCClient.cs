using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using DevExpress.XtraTreeList.Nodes;

using OPCAutomation;

namespace OPCClient.UserContols
{
    public partial class ucOPCClient : OPCClient.UserContols.ucCustomBase
    {
        /// <summary>
        ///  OPCServer 的 IP 地址
        /// </summary>
        private string remoteOPCServerIP = "";

        private OPCServer KepServer = null;
        private OPCGroups KepGroups = null;
        private OPCGroup KepGroup = null;
        private OPCItems KepItems = null;

        private delegate void KepGroup_DataChange(
            int transactionID,
            int numItems,
            ref Array clientHandles,
            ref Array itemValues,
            ref Array qualities,
            ref Array timeStamps);

        private OPCBrowser opcBrowser = null;

        public ucOPCClient()
        {
            InitializeComponent();
        }

        public ucOPCClient(string title) : base(title)
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
                //Thread threadConnectOPCServer = new Thread();
                //threadConnectOPCServer.IsBackground = true;
                //threadConnectOPCServer.Start();
            }
        }

        #region 以线程方式连接 OPCServer
        private void ConnectRemoteServerInThread()
        {
            KepServer = new OPCServer();
        }
        #endregion

        private string ConnRemoteServer(string remoteServerIP, string remoteServerName)
        {
            try
            {
                KepServer.Connect(remoteServerName, remoteServerIP);
                return "";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            treeList1.Nodes.Clear();

            KepServer = new OPCServer();
            List<string> servers = new List<string>();
            object serverList = KepServer.GetOPCServers("127.0.0.1");
            foreach (string serv in (Array)serverList)
            {
                treeList1.AppendNode(
                    new object[] { serv },
                    null);
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.HasChildren)
                    return;

                OPCBrowser browser = null;

                switch (e.Node.Level)
                {
                    case 0:
                        if (ConnRemoteServer("127.0.0.1", e.Node[0].ToString()) == "")
                        {
                            browser = KepServer.CreateBrowser();
                            browser.ShowBranches();
                            browser.ShowLeafs(true);
                            foreach (object b in browser)
                            {
                                string strTemp = b.ToString();
                                if (!(strTemp.Contains("_System._") 
                                    ||strTemp.Contains("_Statistics._")
                                    ||strTemp.Contains("_DataLogger._")))
                                {
                                    treeList1.AppendNode(
                                        new object[] { strTemp },
                                        e.Node);
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}
