using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace IRAP.Global
{
    /// <summary>
    /// WM_COPYDATA 消息中用到的结构体函数
    /// </summary>
    public struct COPYDATASTRUCT
    {
        public IntPtr dwData;
        public int cbData;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData;
    }

    public class MessageAPI
    {
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(int hWnd, int Msg, IntPtr wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        public const int WM_USER = 0x0400;                      // 用户自定义消息
        public const int WM_POSTMESSAGE = WM_USER + 1000;       // 发送消息
        public const int defaultlParam = 0;
        public const int WM_COPYDATA = 0x004A;
        public Int64 m_Handle;                                  // 发送消息的句柄

        /// <summary>
        /// 完整附加消息发送
        /// </summary>
        /// <param name="handle">目标句柄</param>
        /// <param name="wParam">附加消息</param>
        /// <param name="lParam">字符串消息</param>
        public static void SendMess(int handle, int wParam, string lParam)
        {
            byte[] chrs = Encoding.Default.GetBytes(lParam);
            int size = chrs.Length;
            COPYDATASTRUCT cds;

            cds.dwData = (IntPtr)100;
            cds.cbData = size + 1;
            cds.lpData = lParam;
            if (handle > 0)
                SendMessage(handle, WM_COPYDATA, wParam, ref cds);
        }

        /// <summary>
        /// 重载函数，只传递字符串
        /// </summary>
        /// <param name="handle">目标句柄</param>
        /// <param name="lParam">字符串</param>
        public static void SendMess(int handle, string lParam)
        {
            byte[] chrs = Encoding.Default.GetBytes(lParam);
            int size = chrs.Length;
            COPYDATASTRUCT cds;

            cds.dwData = (IntPtr)100;
            cds.cbData = size + 1;
            cds.lpData = lParam;
            if (handle > 0)
                SendMessage(handle, WM_COPYDATA, 0, ref cds);
        }

        /// <summary>
        /// PostMessage 方法发送消息
        /// </summary>
        /// <param name="handle">目标句柄</param>
        /// <param name="wParam">发送的消息</param>
        public static void PostMess(int handle, string wParam)
        {
            IntPtr p = Marshal.StringToHGlobalAnsi(wParam);
            if (handle > 0)
                PostMessage(handle, WM_POSTMESSAGE, p, 0);
        }
    }
}
