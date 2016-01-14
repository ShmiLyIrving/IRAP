using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace IRAP.Global
{
    /// <summary>
    /// 执行外部命令的类
    /// </summary>
    public class Command : IDisposable
    {
        private Process proc = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Command()
        {
            proc = new Process();
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        public void Dispose()
        {
            if (proc != null)
            {
                proc.Dispose();
                proc = null;
            }
        }

        /// <summary>
        /// 执行外部命令
        /// </summary>
        /// <param name="cmd">要执行的外部命令</param>
        public void RunCmd(string cmd)
        {
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            proc.StandardInput.WriteLine(cmd);
            proc.Close();
        }

        /// <summary>
        /// 打开程序并执行命令
        /// </summary>
        /// <param name="programName">程序全路径文件名</param>
        /// <param name="cmd">要执行的命令</param>
        public void RunProgram(string programName, string cmd)
        {
            Process proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = programName;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            if (cmd.Length != 0)
            {
                proc.StandardInput.WriteLine(cmd);
            }
            proc.Close();
        }

        /// <summary>
        /// 打开程序
        /// </summary>
        /// <param name="programName">程序全路径文件名</param>
        public void RunProgram(string programName)
        {
            RunProgram(programName, "");
        }
    }
}
