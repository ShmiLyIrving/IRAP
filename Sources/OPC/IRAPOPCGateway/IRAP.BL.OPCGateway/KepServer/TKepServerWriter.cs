using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using OPCAutomation;

using IRAP.OPC.Entity;
using IRAP.OPC.Entity.IRAPServer;

namespace IRAP.BL.OPCGateway
{
    public class TKepServerWriter
    {
        /// <summary>
        /// KepServer
        /// </summary>
        private OPCServer kepServer = new OPCServer();
        private OPCGroups kepGroups = null;
        private OPCGroup kepGroup = null;
        private OPCItems kepItems = null;
        private OPCItem kepItem = null;
        private List<TIRAPOPCTagItem> tags = new List<TIRAPOPCTagItem>();

        private string ipKepServer = "";
        private string nameKepServer = "";
        /// <summary>
        ///  当前是否已经连接到 KepServer
        /// </summary>
        private bool kepServerConnected = false;

        private int transactionID = 1;

        public TKepServerWriter()
        {
            kepServer.ServerShutDown += new DIOPCServerEvent_ServerShutDownEventHandler(KepServer_ServerShutDown);
        }

        ~TKepServerWriter()
        {
#if DEBUG
            Debug.WriteLine(
                string.Format(
                    "关闭远程服务器[{0}][{1}]的连接",
                    nameKepServer,
                    ipKepServer));
#endif

            if (kepServer != null)
            {
                kepServer.Disconnect();
                kepServer = null;
            }
        }

        /// <summary>
        /// KepServer 的 IP 地址
        /// </summary>
        public string KepServerIP { get { return ipKepServer; } }

        /// <summary>
        /// KepServer 的服务器名称
        /// </summary>
        public string KepServerName { get { return nameKepServer; } }

        private void KepServer_ServerShutDown(string Reason)
        {
            kepServerConnected = false;
            Debug.WriteLine(
                string.Format(
                    "远程服务器[{0}][{1}]断开连接，可能已经关机了。",
                    nameKepServer,
                    ipKepServer));
        }

        private void KepGroup_AsyncWriteComplete(
            int transactionID,
            int numItems,
            ref Array clientHandles,
            ref Array errors)
        {
            string outputStr = "";
            for (int i = 1; i <= numItems; i++)
            {
                outputStr +=
                    string.Format(
                        "[{0}]Trans:[{1}] CH:[{2}] Errors:[{3}]",
                        DateTime.Now.ToString("HH:mm:ss.fff"),
                        transactionID,
                        clientHandles.GetValue(i).ToString(),
                        errors.GetValue(i).ToString());
            }
            Console.WriteLine(outputStr);
        }

        public bool Init(string ipKepServer, string nameKepServer)
        {
            if (kepServerConnected)
                kepServer.Disconnect();

            this.ipKepServer = ipKepServer;
            this.nameKepServer = nameKepServer;

            Debug.WriteLine(
                string.Format(
                    "连接远程服务器[{0}][{1}]......",
                    nameKepServer,
                    ipKepServer));

            try
            {
                kepServer.Connect(nameKepServer, ipKepServer);
                Debug.WriteLine("远程服务器连接成功");
            }
            catch (Exception error)
            {
                kepServerConnected = false;
                Debug.WriteLine(
                    string.Format(
                        "连接远程服务器[{0}]出现错误：[{1}]",
                        ipKepServer,
                        error.Message));
                return false;
            }

            // 连接了远程服务器后，枚举中该服务器中所有的节点
            OPCBrowser browser = kepServer.CreateBrowser();
            browser.ShowBranches();
            browser.ShowLeafs(true);
            foreach (object tag in browser)
            {
                string tagName = tag.ToString();
                if (!tagName.Contains("._"))
                    tags.Add(
                        new TIRAPOPCTagItem()
                        {
                            TagName = tagName,
                        });
            }

            // 建立数据变化的侦听
            kepGroups = kepServer.OPCGroups;
            //kepGroups.RemoveAll();
            kepGroup = kepGroups.Add("OPCWRITERGROUP");

            kepGroup.AsyncWriteComplete += new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(KepGroup_AsyncWriteComplete);

            kepItems = kepGroup.OPCItems;
            for (int i = 0; i < tags.Count; i++)
            {
                OPCItem item = kepItems.AddItem(tags[i].TagName, i + 100000);
                tags[i].ServerHandle = item.ServerHandle;

                TIRAPOPCTag tag =
                    TIRAPOPCDevices.Instance.FindOPCTagItem(
                        string.Format(
                            "{0}.{1}",
                            nameKepServer,
                            tags[i].TagName));
                if (tag != null)
                {
                    tag.ServerHandle = tags[i].ServerHandle;
                    tag.WriteTagValueMethod = WriteTagValue;

                    Debug.WriteLine(
                        string.Format(
                            "TagName:[{0}], ServerHandle:[{1}]",
                            tag.TagName,
                            tag.ServerHandle));
                }
            }

            return true;
        }

        public void WriteTagValue(string TagName, string TagValue)
        {
            foreach (TIRAPOPCTagItem tagItem in tags)
            {
                if (tagItem.TagName == TagName)
                {
                    OPCItem item = kepItems.GetOPCItem(tagItem.ServerHandle);
                    if (item != null)
                    {
                        item.Write(TagValue);
                    }
                    break;
                }
            }
        }

        public void WriteTagValue(
            int tagServerHandle,
            string tagValue,
            out int errCode,
            out string errText)
        {
            errCode = 0;
            errText = "写入完成";

            OPCItem item = kepItems.GetOPCItem(tagServerHandle);
            if (item != null)
                try
                {
                    //item.Write(tagValue);

                    int[] temp = new int[2] { 0, item.ServerHandle };
                    Array serverHandles = (Array)temp;
                    object[] valueTemp = new object[2] { "", tagValue };
                    Array values = (Array)valueTemp;
                    Array error;
                    int cancelID;
                    kepGroup.AsyncWrite(
                        1,
                        ref serverHandles,
                        ref values,
                        out error,
                        transactionID++,
                        out cancelID);
                }
                catch (Exception error)
                {
                    errCode = -1;
                    errText = string.Format("写入时发生错误：{0}", error.Message);
                }
            else
            {
                errCode = -2;
                errText = "没有找到需要写入的 Tag";
            }
        }
    }
}
