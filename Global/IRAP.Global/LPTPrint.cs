using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace IRAP.Global
{
    /// <summary>
    /// 并口打印
    /// </summary>
    public class LPTPrint: IDisposable
    {
        private int iHandle;
        private string lpt;

        public string LPT
        {
            get { return lpt; }
        }
    
        [StructLayout(LayoutKind.Sequential)]
        private struct OVERLAPPED
        {
            int Internal;
            int InternalHigh;
            int Offset;
            int OffsetHigh;
            int hEvent;
        }

        [DllImport("kernel32.dll")]
        private static extern int CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, int lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);

        [DllImport("kernel32.dll")]
        private static extern bool WriteFile(int hFile, byte[] lpBuffer, int nNumberOfBytesToWriter, out int lpNumberOfBytesWriten, out OVERLAPPED lpOverLapped);

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(int hObject);

        /// <summary>
        /// 根据并口号，打开并口
        /// </summary>
        /// <param name="lptPort">并口号</param>
        public bool LPTOpen(string lptPort)
        {
            lpt = lptPort;

            iHandle = CreateFile(lptPort, 0x40000000, 0, 0, 3, 0, 0);
            if (iHandle != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 将函数参数作为内容，发送给并口
        /// </summary>
        public bool LPTWrite(string lptPort, string myString)
        {
            if (!LPTOpen(lptPort))
                return false;

            if (iHandle != 1)
            {
                int i;
                OVERLAPPED x;
                byte[] myByte = Encoding.Default.GetBytes(myString);

                if (WriteFile(iHandle, myByte, myByte.Length, out i, out x))
                {
                    LPTClose();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception(string.Format("端口[{0}]未打开！", lptPort));
            }
        }

        /// <summary>
        /// 关闭打印端口
        /// </summary>
        /// <returns></returns>
        public bool LPTClose()
        {
            return CloseHandle(iHandle);
        }

        public void Dispose()
        {
            CloseHandle(iHandle);
        }
    }
}
