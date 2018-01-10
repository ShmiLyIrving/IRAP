using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRAP.Global;
using IRAP.Interface.OPC;
using OPCClient.Classes;
using DevExpress.XtraEditors;


namespace OPCClient
{
    public class IRAPOPCServer
    {
        public IRAPOPCServer() { }
        public string Address { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Address;
        }
    }

    public class IRAPOPCServers
    {
        private static IRAPOPCServers _instance = null;
        private List<IRAPOPCServer> items = new List<IRAPOPCServer>();

        public List<IRAPOPCServer> Items
        {
            get { return items; }
        }
        private IRAPOPCServers()
        {
            GetKepServList();
        }

        public static IRAPOPCServers Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPOPCServers();
                return _instance;
            }
        }
        //更新服务器列表信息
        public bool UpdateKepServ(string address,string name,int type)
        {
            TUpdateKepServContent content = new TUpdateKepServContent();

            content.Head.CommunityID = SysParams.Instance.Content.CommunityID.ToString();
            content.Head.SysLogID = SysParams.Instance.Content.SysLogID.ToString();
            content.Head.RoleLeaf = SysParams.Instance.Content.RoleLeaf.ToString();
            content.Head.UserCode = SysParams.Instance.Content.UserCode;
            content.Head.StationID = SysParams.Instance.Content.StationID;
            content.Head.UnixTime = TimeParser.LocalTimeToUnix(DateTime.Now).ToString();
            content.Request.CommunityID = SysParams.Instance.Content.CommunityID;

            content.Head.ExCode = "UpdateKepServ";
            content.Request.ExCode = "UpdateKepServ";
            content.Request.UpdateType = type;
            content.Request.KepServAddr = address;
            content.Request.KepServName = name;
            content.ResolveResponse(OPCWSClient.Instance.WSCall(content.GenerateRequestContent()));
            if(content.Response.ErrCode =="0")
            {
                GetKepServList();
                return true;              
            }
            else
            {
                XtraMessageBox.Show(content.Response.ErrCode + ":" + content.Response.ErrText);
                return false;
            }
        }
        //获取服务器列表
        public List<IRAPOPCServer> GetKepServList()
        {
            items.Clear();
            TGetKepServListContent content = new TGetKepServListContent();

            content.Head.CommunityID = SysParams.Instance.Content.CommunityID.ToString();
            content.Head.SysLogID = SysParams.Instance.Content.SysLogID.ToString();
            content.Head.RoleLeaf = SysParams.Instance.Content.RoleLeaf.ToString();
            content.Head.UserCode = SysParams.Instance.Content.UserCode;
            content.Head.StationID = SysParams.Instance.Content.StationID;
            content.Head.UnixTime = TimeParser.LocalTimeToUnix(DateTime.Now).ToString();
            content.Request.CommunityID = SysParams.Instance.Content.CommunityID;

            content.Head.ExCode= "GetKepServList";
            content.Request.ExCode = "GetKepServList";

            content.ResolveResponse(OPCWSClient.Instance.WSCall(content.GenerateRequestContent()));
            if(content.Response.ErrCode=="0")
            {
                foreach(TGetKepServListRspDetail item in content.Response.Items)
                {
                    IRAPOPCServer server = new IRAPOPCServer();
                    server.Name = item.KepServName;
                    server.Address = item.KepServAddr;
                    items.Add(server);
                }
                return items;
            }
            else
            {
                XtraMessageBox.Show(content.Response.ErrCode + ":" + content.Response.ErrText);
                return null;
            }
        }
    }
}
