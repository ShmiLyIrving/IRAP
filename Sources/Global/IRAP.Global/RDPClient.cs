using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Management;

namespace IRAP.Global
{
    public class RDPClientIP
    {
        [DllImport("wtsapi32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool WTSEnumerateSessions(
            int hServer,
            int Reserved,
            int Version,
            ref long ppSessionInfo,
            ref int pCount);

        [DllImport("wtsapi32")]
        public static extern void WTSFreeMemory(IntPtr pMemory);

        [DllImport("wtsapi32")]
        public static extern bool WTSLogoffSession(
            int hServer,
            long SessionId,
            bool bWait);

        [DllImport("wtsapi32")]
        public static extern bool WTSQuerySessionInformation(
            IntPtr hServer,
            int sessionId,
            WTSInfoClass wtsInfoClass,
            out IntPtr ppBuffer,
            out uint pBytesReturned);

        [DllImport("wtsapi32.dll")]
        public static extern bool WTSQuerySessionInformation(
            IntPtr hServer,
            int sessionId,
            WTSInfoClass wtsInfoClass,
            out StringBuilder ppBuffer,
            out uint pBytesReturned);

        [DllImport("kernel32")]
        public static extern bool ProcessIdToSessionId(
            uint dwProcessId,
            ref uint pSessionId);

        [DllImport("kernel32")]
        public static extern uint GetCurrentProcessId();

        public enum WTSInfoClass
        {
            WTSInitialProgram,
            WTSApplicationName,
            WTSWorkingDirectory,
            WTSOEMId,
            WTSSessionId,
            WTSUserName,
            WTSWinStationName,
            WTSDomainName,
            WTSConnectState,
            WTSClientBuildNumber,
            WTSClientName,
            WTSClientDirectory,
            WTSClientProductId,
            WTSClientHardwareId,
            WTSClientAddress,
            WTSClientDisplay,
            WTSClientProtocolType,
        }

        /// <summary>
        /// The WTS_CONNECTSTATE_CLASS enumeration type contains INT values
        /// that indicate the connection state of a Terminal Services session.
        /// </summary>
        public enum WTS_CONNECTSTATE_CLASS
        {
            WTSActive,
            WTSConnected,
            WTSConnectQuery,
            WTSShadown,
            WTSDisconnected,
            WTSIdle,
            WTSListen,
            WTSReset,
            WTSDown,
            WTSInit,
        }

        /// <summary>
        /// The WTS_SESSION_INFO structure contains information about a client
        /// session on a terminal server. If the WTS_SESSION_INFO.SessionID == 0,
        /// it means that the SESSION is the local logon user's session.
        /// </summary>
        public struct WTS_SESSION_INFO
        {
            public int SessionID;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string WinStationName;
            public WTS_CONNECTSTATE_CLASS State;
        }

        /// <summary>
        /// The SessionEnumeration function retrieves a list of WTS_SESSION_INFO
        /// on a current terminal server.
        /// </summary>
        /// <returns>a list of WTS_SESSION_INFO o a current terminal server</returns>
        public static WTS_SESSION_INFO[] SessionEnumeration()
        {
            // Set handle of terminal server as the current terminal server
            int hServer = 0;
            bool retVal;
            long lpBuffer = 0;
            int count = 0;
            long p;
            WTS_SESSION_INFO session_Info = new WTS_SESSION_INFO();
            WTS_SESSION_INFO[] arrSessionInfo;

            retVal = WTSEnumerateSessions(hServer, 0, 1, ref lpBuffer, ref count);
            arrSessionInfo = new WTS_SESSION_INFO[0];
            if (retVal)
            {
                arrSessionInfo = new WTS_SESSION_INFO[count];
                p = lpBuffer;
                for (int i = 0; i < count; i++)
                {
                    arrSessionInfo[i] =
                        (WTS_SESSION_INFO)Marshal.PtrToStructure(
                            new IntPtr(p),
                            session_Info.GetType());
                    p += Marshal.SizeOf(session_Info.GetType());
                }
                WTSFreeMemory(new IntPtr(lpBuffer));
            }
            else
            {
                // Insert Error Reactive Here
            }

            return arrSessionInfo;
        }

        #region Structures
        /// <summary>
        /// Structure for Terminal Service Client IP Address
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WTS_CLIENT_ADDRESS
        {
            public int AddressFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] Address;
        }

        /// <summary>
        /// Structre for Terminal Service Session Client Display
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WTS_CLIENT_DISPLAY
        {
            public int HorizontalResolution;
            public int VerticalResolution;
            /// <summary>
            /// 1 - The display uses 4 bits per pixel for a maximum of 16 colors.
            /// 2 - The display uses 8 bits per pixel for a maximum of 256 colors.
            /// 4 - The display uses 16 bits per pixel for a maximum of 2^16 colors.
            /// 8 - The display uses 3-byte RGB values for a maximum of 2^24 colors.
            /// 16 - The display uses 15 bits per pixel for a maximum of 2^15 colors.
            /// </summary>
            public int ColorDepth;
        }
        #endregion
    }

    public class RDPClientMAC
    {
        [DllImport("iphlpapi.dll")]
        private static extern int SendARP(
            Int32 DestIP,
            Int32 SrcIP,
            ref Int64 MacAddr,
            ref Int32 PhyAddrLen);

        [DllImport("ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        public static string GetRDPMacAddress()
        {
            RDPClientIP.WTS_SESSION_INFO[] pSessionInfo = RDPClientIP.SessionEnumeration();
            try
            {
                uint count = 0;
                uint count2 = 0;
                IntPtr buffer = IntPtr.Zero;
                uint id = RDPClientIP.GetCurrentProcessId();
                uint sessionID = 0;

                RDPClientIP.ProcessIdToSessionId(id, ref sessionID);

                IntPtr sb = IntPtr.Zero;
                StringBuilder outBuffer = new StringBuilder();
                string sIPAddress = string.Empty;
                RDPClientIP.WTS_CLIENT_ADDRESS oClientAddress = new RDPClientIP.WTS_CLIENT_ADDRESS();

                bool dwRet =
                    RDPClientIP.WTSQuerySessionInformation(
                        IntPtr.Zero,
                        (int)sessionID,
                        RDPClientIP.WTSInfoClass.WTSClientName,
                        out outBuffer,
                        out count2);
                if (dwRet == true && count2 > 3)
                {
                    bool bsuccess =
                        RDPClientIP.WTSQuerySessionInformation(
                            IntPtr.Zero,
                            (int)sessionID,
                            RDPClientIP.WTSInfoClass.WTSClientAddress,
                            out sb,
                            out count);
                    if (bsuccess)
                    {
                        oClientAddress =
                            (RDPClientIP.WTS_CLIENT_ADDRESS)Marshal.PtrToStructure(
                                sb,
                                oClientAddress.GetType());
                        sIPAddress =
                            string.Format(
                                "{0}.{1}.{2}.{3}",
                                oClientAddress.Address[2],
                                oClientAddress.Address[3],
                                oClientAddress.Address[4],
                                oClientAddress.Address[5]);
                        string mac = RDPClientMAC.GetMacBySendARP(sIPAddress);
                        return mac;
                    }
                    else
                    {
                        return "FFFFFFFFFFFF";
                    }
                }
                else
                {
                    string mac = GetLocalMac2();
                    return mac;
                }
            }
            catch (Exception err)
            {
                return "FFFFFFFFFFFF";
            }
        }

        /// <summary>
        /// SendARP 获取 MAC 地址
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <returns></returns>
        public static string GetMacBySendARP(string remoteIP)
        {
            StringBuilder macAddress = new StringBuilder();
            try
            {
                Int32 remote = inet_addr(remoteIP);
                Int64 macInfo = new long();
                Int32 length = 6;

                SendARP(remote, 0, ref macInfo, ref length);

                string temp = Convert.ToString(macInfo, 16).PadLeft(12, '0').ToUpper();

                int x = 12;
                for (int i = 0; i < 6; i++)
                {
                    if (i == 5)
                    {
                        macAddress.Append(temp.Substring(x - 2, 2));
                    }
                    else
                    {
                        macAddress.Append(temp.Substring(x - 2, 2) + "");
                    }
                    x -= 2;
                }

                return macAddress.ToString();
            }
            catch
            {
                return macAddress.ToString();
            }
        }

        public static string GetLocalMac()
        {
            // 通过硬件接口获取，即使不联网
            List<string> macs = new List<string>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                macs.Add(ni.GetPhysicalAddress().ToString());
            }

            StringBuilder res = new StringBuilder();
            foreach (string item in macs)
            {
                if (item.Trim() != string.Empty)
                {
                    res.Append(item + ";");
                }
            }

            return res.Remove(res.Length - 1, 1).ToString();
        }

        public static string GetLocalMac2()
        {
            List<string> macs = new List<string>();
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        mac = mo["MacAddress"].ToString();
                        string[] addresses = (string[])mo["IPAddress"];
                        macs.Add(mac);
                    }
                }

                moc = null;
                mc = null;
            }
            catch
            {
                return "FFFFFFFFFFFF";
            }

            StringBuilder res = new StringBuilder();
            foreach (string item in macs)
            {
                res.Append(item.Replace(":", "") + ";");
            }
            return res.Remove(res.Length - 1, 1).ToString();
        }
    }
}