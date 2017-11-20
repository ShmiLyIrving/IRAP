using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.Threading;

using IRAP.Global;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class CmdToLPTAction : CustomAction, IUDFAction
    {
        private string className =
          MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private string strLPTPort = "LPT1";
        private string strData = "";
        string LPTpath = string.Format(@"{0}{1}\", AppDomain.CurrentDomain.BaseDirectory, "LPT");
        string LPTfile = string.Format(@"{0}{1}\{2}", AppDomain.CurrentDomain.BaseDirectory, "LPT", "tiaoma.txt");
        public CmdToLPTAction(XmlNode actionParams, ExtendEventHandler extendAction, ref object tag)
            : base(actionParams, extendAction, ref tag)
        {
            try
            {
                strLPTPort = actionParams.Attributes["PrintTo"].Value.ToString();
            }
            catch { }
            strData = actionParams.Attributes["Data"].Value.ToString();
        }
        private bool RunCmd(string command)
        {
            //实例一个Process类，启动一个独立进程  
            Process p = new Process();
            //Process类有一个StartInfo属性，這個是ProcessStartInfo类，包括了一些属性和方法，下面我們用到了他的几个属性：  
            p.StartInfo.FileName = "cmd.exe";//设定程序名  
            p.StartInfo.Arguments = "/k " + command;//设定程式执行参数  
            p.StartInfo.UseShellExecute = false;//关闭Shell的使用  
            p.StartInfo.RedirectStandardInput = true;//重定向标准输入  
            p.StartInfo.RedirectStandardOutput = true;//重定向标准输出  
            p.StartInfo.RedirectStandardError = true;//重定向错误输出  
            p.StartInfo.CreateNoWindow = true;//设置不显示窗口  
            //p.StandardInput.WriteLine(command);//也可以用这种方式输入要执行的命令  
            //p.StandardInput.WriteLine("exit");//不过要记得加上Exit要不然下一行程式执行的時候会当机  
            try
            {

                if (p.Start())//开始进程
                {
                    Thread.Sleep(1000);
                    //p.StandardInput.WriteLine(string.Format("copy {0} {1}", LPTfile, strLPTPort));
                    //p.StandardInput.WriteLine("exit");  
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (p != null)
                    p.Close();
            }
            return false;
        }
        public void DoAction()
        {
            string strProcedureName =
                string.Format(
                "{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            FileStream fs = null;
            try
            {
                WriteLog.Instance.Write(
                    string.Format("向端口[{0}]发送打印内容[{1}]", strLPTPort, strData),
                    strProcedureName);
                strData = strData.Replace(" ", "\r\n");


                if (!Directory.Exists(LPTpath))
                { Directory.CreateDirectory(LPTpath); }
                if (!File.Exists(LPTfile))
                {
                    fs = new FileStream(LPTfile, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);//ANSI编码格式
                    sw.Write(strData);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    try
                    {
                        RunCmd("COPY " + LPTfile + string.Format(" {0}", strLPTPort));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        WriteLog.Instance.Write(ex.Message, strProcedureName);
                    }                
                }
                else
                {
                    MessageBox.Show("目录下已有条码文件");
                }
                //System.Diagnostics.Process p = new System.Diagnostics.Process();
                //p.StartInfo.FileName = "cmd.exe";//要执行的程序名称 
                //p.StartInfo.UseShellExecute = false;
                //p.StartInfo.RedirectStandardInput = true;//可能接受来自调用程序的输入信息 
                //p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息 
                //p.StartInfo.CreateNoWindow = true;//不显示程序窗口 
                //p.Start();//启动程序 
                ////向CMD窗口发送输入信息： 
                //p.StandardInput.WriteLine(string.Format("copy {0} {1}", filePath, printPort));
                //p.StandardInput.WriteLine("exit");




                //using (LPTPrint print = new LPTPrint())
                //{
                //    try
                //    {
                //        print.LPTWrite(strLPTPort, strData);
                //    }
                //    catch (Exception error)
                //    {
                //        WriteLog.Instance.Write(error.Message, strProcedureName);
                //        XtraMessageBox.Show(
                //            error.Message,
                //            "系统信息",
                //            MessageBoxButtons.OK,
                //            MessageBoxIcon.Error);
                //        return;
                //    }
                //}
            }
            catch (Exception e)
            {
                WriteLog.Instance.Write(e.Message, strProcedureName);
                XtraMessageBox.Show(
                    e.Message,
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (System.IO.File.Exists(LPTfile))
                {
                    System.IO.File.Delete(LPTfile);
                }
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }

    public class CmdToLPTFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction, ref object tag)
        {
            return new CmdToLPTAction(actionParams, extendAction, ref tag);
        }
    }
}
