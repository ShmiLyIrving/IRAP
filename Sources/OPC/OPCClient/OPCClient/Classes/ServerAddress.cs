using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCClient
{
    public class ServerAddress
    {
        public string Address { get; set; }
    }

    public class ServerAddresses
    {
        private static ServerAddresses _instance = null;
        private List<ServerAddress> items = new List<ServerAddress>();

        private ServerAddresses()
        {
            Load();
        }

        public static ServerAddresses Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServerAddresses();
                return _instance;
            }
        }

        public List<ServerAddress> Items
        {
            get
            {
                return items;
            }
        }

        public void Save()
        {
            IniFile.WriteString(
                "Servers",
                "Count",
                items.Count.ToString(),
                SysGlobalVariable.Instance.SysParamsFileName);
            for (int i = 0; i < items.Count; i++)
                IniFile.WriteString(
                    "Servers",
                    string.Format("Address{0}", i + 1),
                    items[i].Address,
                    SysGlobalVariable.Instance.SysParamsFileName);
        }

        public void Load()
        {
            items.Clear();

            int count = 0;
            int.TryParse(
                IniFile.ReadString(
                    "Servers", 
                    "Count", 
                    "0", 
                    SysGlobalVariable.Instance.SysParamsFileName), 
                out count);

            for (int i=0;i< count; i++)
            {
                string temp =
                    IniFile.ReadString(
                        "Servers",
                        string.Format("Address{0}", i + 1),
                        "",
                        SysGlobalVariable.Instance.SysParamsFileName);
                if (temp.Trim() != "")
                    items.Add(new ServerAddress() { Address = temp.Trim() });
            }
        }
    }
}
