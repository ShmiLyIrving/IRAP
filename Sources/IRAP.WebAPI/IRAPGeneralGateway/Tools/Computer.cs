using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace IRAPGeneralGateway
{
    public class Computer
    {
        /// <summary>
        /// CPU 序列号
        /// </summary>
        public string CPUID { get; set; }
        /// <summary>
        /// MAC 地址
        /// </summary>
        public string MacAddress { get; set; }
        /// <summary>
        /// 硬盘 ID
        /// </summary>
        public string DiskID { get; set; }
        /// <summary>
        /// IP 地址
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string LoginUserName { get; set; }
        /// <summary>
        /// 计算机名
        /// </summary>
        public string ComputerName { get; set; }
        /// <summary>
        /// 系统类型
        /// </summary>
        public string SystemType { get; set; }
        /// <summary>
        /// 内存量 单位：M
        /// </summary>
        public string TotalPhysicalMemory { get; set; }

        public Computer()
        {
            CPUID = GetCPUID();
            MacAddress = GetMacAddress();
            DiskID = GetDiskID();
            IpAddress = GetIPAddress();
            LoginUserName = GetUserName();
            SystemType = GetSystemType();
            TotalPhysicalMemory = GetTotalPhysicalMemory();
            ComputerName = GetComputerName();
        }

        private string GetCPUID()
        {
            try
            {
                string cpuInfo = "";
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc = null;
                mc = null;
                return cpuInfo;
            }
            catch
            {
                return "Unknown";
            }
        }

        private string GetMacAddress()
        {
            try
            {
                StringBuilder mac = new StringBuilder();
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        mac.Append(mo["MacAddress"].ToString() + ";");
                    }
                }
                moc = null;
                mc = null;

                return mac.ToString();
            }
            catch
            {
                return "Unknown";
            }
        }

        private string GetDiskID()
        {
            try
            {
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                string strHardDiskID = null;
                foreach (ManagementObject mo in searcher.Get())
                {
                    strHardDiskID = mo["SerialNumber"].ToString().Trim();
                    break;
                }
                return strHardDiskID;
            }
            catch
            {
                return "Unknown";
            }
        }

        private string GetIPAddress()
        {
            try
            {
                //string st = "";
                StringBuilder sb = new StringBuilder();
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {

                        Array ar;
                        ar = (Array)(mo.Properties["IpAddress"].Value);
                        sb.Append(ar.GetValue(0).ToString() + ";");
                    }
                }
                moc = null;
                mc = null;

                return sb.ToString();
            }
            catch
            {
                return "Unknown";
            }
        }

        string GetUserName()
        {
            try
            {
                string st = "";
                st = Environment.UserName;
                return st;
            }
            catch
            {
                return "Unknown";
            }
        }

        string GetComputerName()
        {
            try
            {
                return Environment.MachineName;
            }
            catch
            {
                return "Unknown";
            }
        }

        string GetSystemType()
        {
            try
            {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    st = mo["SystemType"].ToString();
                }
                moc = null;
                mc = null;

                return st;
            }
            catch
            {
                return "Unknown";
            }
        }

        string GetTotalPhysicalMemory()
        {
            try
            {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    st = mo["TotalPhysicalMemory"].ToString();
                }
                moc = null;
                mc = null;

                return st;
            }
            catch
            {
                return "Unknown";
            }
        }
    }
}
