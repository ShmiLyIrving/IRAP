using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management;
using System.Net.NetworkInformation;
using System.IO;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Media;

namespace IRAP.Global
{
    public class Tools
    {
        private static string className = "IRAP.Global.Tools";
        public static string GetCpuID()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                string strCpuID = null;
                foreach (ManagementObject mo in moc)
                {
                    strCpuID = mo.Properties["ProcessorId"].Value.ToString();
                    break;
                }
                return strCpuID;
            }
            catch
            {
                return "";
            }
        }

        //BIOS
        public static List<string> GetBiosInfo()
        {
            List<string> list = new List<string>();
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_BIOS");

                foreach (ManagementObject mo in searcher.Get())
                {
                    list.Add(mo["Manufacturer"].ToString());
                    // mo["SerialNumber"]
                }
                return list;
            }
            catch (Exception err)
            {
                WriteLocalMsg("获取 BIOS 信息失败：" + err.Message);
                return list;
            }
        }

        public static List<string> GetMacByWMI()
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

                        foreach (string ipaddress in addresses)
                        {
                            // MessageBox.Show(string.Format("IP Address: {0}", ipaddress));
                        }
                        macs.Add(mac);
                    }
                }
                moc = null;
                mc = null;
            }
            catch (Exception err)
            {
                WriteLocalMsg("取 MAC 地址失败：" + err.Message);
                //MessageBox.Show("取mac地址失败：" + err.Message);
            }
            return macs;
        }


        //返回描述本地计算机上的网络接口的对象(网络接口也称为网络适配器)。
        public static NetworkInterface[] NetCardInfo()
        {
            return NetworkInterface.GetAllNetworkInterfaces();
        }

        /// <summary>
        /// 通过NetworkInterface读取网卡Mac
        /// </summary>
        /// <returns></returns>
        public static List<string> GetMacByNetworkInterface()
        {
            List<string> macs = new List<string>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                macs.Add(ni.GetPhysicalAddress().ToString());
            }
            return macs;
        }

        //所有的网卡无论有没有启用的
        public static List<string> GetIpAddress()
        {
            List<string> ipAddress = new List<string>();
            string myHostName = Dns.GetHostName();
            IPHostEntry ips = Dns.GetHostEntry(myHostName);
            foreach (IPAddress ip in ips.AddressList)
            {
                string ipString = ip.ToString();
                ipAddress.Add(ipString);
            }
            return ipAddress;
        }

        public static List<string> GetIpAddressByWMI()
        {
            List<string> ipAddress = new List<string>();
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        string[] addresses = (string[])mo["IPAddress"];

                        foreach (string ipaddress in addresses)
                        {
                            ipAddress.Add(ipaddress);
                            break;
                        }
                    }
                }
                moc = null;
                mc = null;
            }
            catch (Exception err)
            {
                WriteLocalMsg("取 IP 地址失败：" + err.Message);
            }

            return ipAddress;
        }

        public static void WriteLocalMsg(string ErrText)
        {

            string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"Log\";

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            FilePath += DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            StreamWriter sw = null;
            try
            {
                if (!File.Exists(FilePath))
                {
                    sw = File.CreateText(FilePath);
                }
                else
                {
                    sw = File.AppendText(FilePath);
                }

                if (ErrText.Trim() == "")
                    sw.WriteLine(ErrText);
                else
                    sw.WriteLine(DateTime.Now.ToString() + ":" + ErrText);
            }
            catch
            { ;}
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }

        }

        public static SqlParameter CreateParam(SqlCommand sqlCommand,
                                               SqlDbType sqlDbType,
                                               int size,
                                               ParameterDirection parameterDirection,
                                               string parameterName,
                                               object value)
        {
            SqlParameter newParam = sqlCommand.CreateParameter();
            newParam.SqlDbType = sqlDbType;
            newParam.Size = size;
            newParam.Direction = parameterDirection;
            newParam.ParameterName = parameterName;
            newParam.Value = value;

            return newParam;
        }

        public static DataSet ExecuteReturnDataSet(string strConnection, 
                                                   CommandType commandType, 
                                                   string cmdStr)
        {
            string strProcedureName = className + ".ExecuteReturnDataSet";
            WriteLog.Instance.Write(cmdStr, strProcedureName);

            DataSet returnDS = new DataSet();
            SqlConnection dbConnection = new SqlConnection(strConnection);

            try
            {
                SqlCommand cmd = new SqlCommand(cmdStr, dbConnection)
                {
                    CommandTimeout = 120,
                    CommandType = commandType
                };
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                dbConnection.Close();
                dbConnection = null;

                sda.Fill(returnDS);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                throw error;
                //returnDS = null;
            }

            return returnDS;
        }

        private static string GetWildcardRegexString(string wildcardStr)
        {
            Regex replace = new Regex("[.$^{\\[(|)*+?\\\\]");
            return "^" + replace.Replace(
                wildcardStr,
                delegate(Match m)
                {
                    switch (m.Value)
                    {
                        case "?":
                            return ".?";
                        case "*":
                            return ".*";
                        default:
                            return "\\" + m.Value;
                    }
                }) + "$";
        }

        public static bool FileNameMatched(string fileName, List<string> fileExts)
        {
            Regex match = null;
            string sortFileName = Path.GetFileName(fileName);

            foreach (string fileExt in fileExts)
            {
                match = new Regex(GetWildcardRegexString(fileExt), RegexOptions.IgnoreCase);
                if (match.IsMatch(fileName))
                {
                    return true;
                }
            }
            return false;
        }

        public static int ConvertToInt32(string value, int valueDefault = 0)
        {
            try { return Convert.ToInt32(value); }
            catch { return valueDefault; }
        }

        public static long ConvertToInt64(string value, long valueDefault = 0)
        {
            try { return Convert.ToInt64(value); }
            catch { return valueDefault; }
        }

        public static bool ConvertToBoolean(string value, bool valueDefault = false)
        {
            try { return Convert.ToBoolean(value); }
            catch { return valueDefault; }
        }

        public static double ConvertToDouble(string value, double valueDefault = 0)
        {
            try { return Convert.ToDouble(value); }
            catch { return valueDefault; }
        }

        public static DateTime ConvertToDateTime(string value)
        {
            try { return Convert.ToDateTime(value); }
            catch { return Convert.ToDateTime("1900-1-1 00:00:00"); }
        }

        /// <summary>
        /// 启动外部程序，不等待其运行结束
        /// </summary>
        /// <param name="appFileName">外部程序文件名（包括路径）</param>
        /// <returns>0-外部程序正常启动</returns>
        public int RunProcess(string appFileName)
        {
            try
            {
                System.Diagnostics.Process.Start(appFileName);
                return 0;
            }
            catch (ArgumentException error)
            {
                throw new Exception(error.Message);
            }
        }

        /// <summary>
        /// 启动外部程序，等待指定时间后退出
        /// </summary>
        /// <param name="appFileName">外部程序文件名（包括路径）</param>
        /// <param name="milliSeconds">等待时长（毫秒）（0-无限期等待）</param>
        /// <returns>
        /// 0-外部程序正常退出
        /// 1-外部程序被强制终止
        /// 2-外部程序没有正常运行
        /// </returns>
        public int RunProcessForWait(string appFileName, int milliSeconds = 0)
        {
            try
            {
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(appFileName);
                if (proc != null)
                {
                    if (milliSeconds == 0)
                    {
                        proc.WaitForExit();
                        return 0;
                    }
                    else
                    {
                        proc.WaitForExit(milliSeconds);
                        if (proc.HasExited)
                            return 0;
                        else
                        {
                            proc.Kill();
                            return 1;
                        }
                    }
                }
                return 2;
            }
            catch (ArgumentException error)
            {
                throw new Exception(error.Message);
            }
        }

        public static byte[] ImageToBytes(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);
            ms.Position = 0;
            byte[] bytes = ms.ToArray();
            ms.Close();
            return bytes;
        }

        public static Image BytesToImage(byte[] datas)
        {
            try
            {
                MemoryStream ms = new MemoryStream(datas);
                Image img = Image.FromStream(ms, true);         // 在这里出错
                ms.Close();
                return img;
            }
            catch
            {
                return null;
            }
        }

        public static void Play(Stream streamWav)
        {
            if (streamWav != null)
            {
                try
                {
                    System.Media.SoundPlayer sp = new SoundPlayer(streamWav);
                    sp.Play();
                }
                catch { }
            }
        }
    }
}
