using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Management;

using IRAP.Global;

namespace IRAP.Client.User
{
    public abstract class StationUser : BaseUser
    {
        protected string ipAddress="";
        protected string macAddress="";

        public StationUser()
        {
            macAddress = "";

            // 获取当前的 IP 地址
            HostToIP(ref ipAddress);

            // 如果配置文件中设置了 MAC 地址，并且指明使用 MAC 地址，则读取该配置的 MAC 地址
            string strCFGFileName = string.Format(@"{0}\IRAP.ini",
                AppDomain.CurrentDomain.BaseDirectory);
            bool usingVirtualAddr = IniFile.ReadBool(
                "Virtual Station",
                "Virtual Station Used",
                false,
                strCFGFileName);
            if (usingVirtualAddr)
            {
                macAddress = IniFile.ReadString(
                    "Virtual Station",
                    "Virtual Station",
                    "",
                    strCFGFileName);
            }

            if (macAddress.Trim() == "")
            {
                string macAddresses = RDPClientMAC.GetRDPMacAddress();
                string[] arrMacAddress = macAddresses.Split(';');
                if (arrMacAddress.Length > 0)
                    macAddress = arrMacAddress[0];
                else
                    macAddress = "FFFFFFFFFFFF";
            }
        }

        public string IPAddress
        {
            get { return IPAddress; }
        }

        public string MacAddress
        {
            get { return macAddress; }
        }

        private bool HostToIP1(ref string ipAddress)
        {
            IPAddress[] arrayIPAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for (int i=0;i<arrayIPAddress.Length;i++)
            {
                // 从 IP 地址列表中筛选出 IPv4 类型的地址
                // AddressFamily.InterNetwork 表示此地址为 IPv4
                // AddressFamily.InterNetworkV6 表示此地址为 IPv6
                if (arrayIPAddress[i].AddressFamily==AddressFamily.InterNetwork)
                {
                    ipAddress = arrayIPAddress[i].ToString();
                    return true;
                }
            }

            ipAddress = "127.0.0.1";
            return true;
        }

        private bool HostToIP(ref string ipAddress)
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection nics = mc.GetInstances();
            foreach (ManagementObject nic in nics)
            {
                if (Convert.ToBoolean(nic["ipEnabled"]))
                {
                    ipAddress = (nic["ipAddress"] as string[])[0];
                    return true;
                }
            }

            ipAddress = "127.0.0.1";
            return true;
        }

        private bool HostToIP2(ref string ipAddress)
        {
            try
            {
                // 获得网络接口，网卡、拨号器、适配器都会有一个网络接口
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface network in networkInterfaces)
                {
                    // 获得当前网络接口属性
                    IPInterfaceProperties properties = network.GetIPProperties();
                    // 每个网络接口可能会有多个 IP 地址
                    foreach (IPAddressInformation address in properties.UnicastAddresses)
                    {
                        // 如果此 IP 不是 IPv4，则进行下一次循环
                        if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                            continue;
                        // 忽略 127.0.0.1
                        if (System.Net.IPAddress.IsLoopback(address.Address))
                            continue;

                        ipAddress = address.Address.ToString();
                        return true;
                    }
                }

                ipAddress = "127.0.0.1";
                return true;
            }
            catch
            {
                ipAddress = "127.0.0.1";
                return true;
            }
        }

        protected virtual void GetMacAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                try
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        macAddress = mo["MacAddress"].ToString();
                        macAddress = macAddress.Replace(":", "");
                        break;
                    }
                }
                catch 
                {
                    mo.Dispose();
                }
            }
        }
    }
}