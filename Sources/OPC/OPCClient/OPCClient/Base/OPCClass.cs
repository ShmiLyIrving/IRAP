using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OPCAutomation;

namespace OPCClient
{
    public class OPCClass
    {
        private OPCServer server;
        private OPCGroups groups;
        private OPCGroup group;
        private OPCItems items;

        public delegate void KepGroup_DataChange(
            int transactionID,
            int numItems,
            ref Array clientHandles,
            ref Array itemValues,
            ref Array qualities,
            ref Array timeStamps);

        private string ConnectRemoteServer(
            string remoteServerIP,
            string remoteServerName)
        {
            try
            {
                server.Connect(remoteServerName, remoteServerIP);
                return "";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        public List<string> GetOPCServers(string serverIP)
        {
            server = new OPCServer();
            List<string> rlt = new List<string>();
            object servers = server.GetOPCServers(serverIP);
            foreach (string turn in (Array)servers)
                rlt.Add(turn);
            return rlt;
        }

        public List<string> ConnRemoteAndGetRecurBrowse(
            string remoteServerIP,
            string remoteServerName)
        {
            List<string> rlt = new List<string>();

            string connRlt = ConnectRemoteServer(remoteServerIP, remoteServerName);
            if (connRlt != "")
                return rlt;

            OPCBrowser broswer = server.CreateBrowser();
            // 展开分支
            broswer.ShowBranches();
            // 展开叶子
            broswer.ShowLeafs(true);
            foreach (object turn in broswer)
            {
                string strTurn = turn.ToString();
                if (!(strTurn.Contains("._Statistics._")
                    || strTurn.Contains("_System._")
                    || strTurn.Contains("_DataLogger._")))
                    rlt.Add(strTurn);
            }

            return rlt;
        }

        public void GetData(
            List<string> recurBrowse,
            KepGroup_DataChange dataChange)
        {
            groups = server.OPCGroups;
            groups.RemoveAll();

            group = groups.Add("OPCDOTNETGROUP");
            group.UpdateRate = 250;                 // 订阅时间 250 毫秒
            group.IsActive = true;
            group.IsSubscribed = true;
            group.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(dataChange);

            items = group.OPCItems;
            int[] tmp = new int[2];
            tmp[0] = 0;
            for (int i = 0; i < recurBrowse.Count; i++)
                items.AddItem(recurBrowse[i], (i + 1));
        }

        public void CloseConnOPCServer()
        {
            if (server != null)
                server.Disconnect();
        }
    }
}
