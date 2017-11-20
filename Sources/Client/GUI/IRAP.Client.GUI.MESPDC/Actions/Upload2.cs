using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;
using System.Windows.Forms;

using FtpLib;
using DevExpress.XtraEditors;

using IRAP.Global;
using System.IO;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class Upload2Action : CustomAction, IUDFAction
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string uploadType = "";
        private string fileName = "";
        private string strData = "";
        private string address = "";
        private string strPort = "";
        private string userID = "";
        private string pwd = "";
        private string uploadfilePath = "";


        public Upload2Action(XmlNode actionParams, ExtendEventHandler extendAction, ref object tag)
            : base(actionParams, extendAction, ref tag)
        {
            try
            {
                uploadType = actionParams.Attributes["UploadType"].Value.ToString();
                fileName = actionParams.Attributes["FileName"].Value.ToString();
                strData = actionParams.Attributes["FileData"].Value.ToString();
                address = actionParams.Attributes["Address"].Value.ToString();
                strPort = actionParams.Attributes["Port"].Value.ToString();
                userID = actionParams.Attributes["UserID"].Value.ToString();
                pwd = actionParams.Attributes["PWD"].Value.ToString();
                uploadfilePath = actionParams.Attributes["UploadFilePath"].Value.ToString();
            }
            catch { }

        }
        public void DoAction()
        {
            string strProcedureName =
                string.Format(
                "{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (uploadType == "FTP")
                {
                    WriteLog.Instance.Write(string.Format("向FTP[{0}]上传文件[{1}],文件内容:[{2}]", address, fileName, strData), strProcedureName);
                    int port = 21;
                    int.TryParse(strPort, out port);
                    string FTPpath = string.Format(@"{0}{1}\", AppDomain.CurrentDomain.BaseDirectory,uploadfilePath);
                    string fullFileName = FTPpath + fileName;
                    string remotefile = string.Format(@"{0}\{1}",uploadfilePath,fileName);
                    using (FtpConnection ftp = new FtpConnection(address, port, userID, pwd))
                    {
                        try
                        {
                            ftp.Open();
                            ftp.Login();
                            if(!Directory.Exists(FTPpath))
                            { Directory.CreateDirectory(FTPpath); }
                            if (!System.IO.File.Exists(fullFileName))
                            {
                                System.IO.FileStream fs = System.IO.File.Create(fullFileName);
                                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, Encoding.Default);//ANSI编码格式
                                sw.Write(strData);
                                sw.Flush();
                                sw.Close();
                                fs.Close();
                            }
                            ftp.PutFile(fullFileName,remotefile);
                            WriteLog.Instance.Write("文件上传成功！", strProcedureName);
                            ftp.Close();
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(error.Message, strProcedureName);
                            XtraMessageBox.Show(
                                error.Message,
                                "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (System.IO.File.Exists(fullFileName))
                            {
                                System.IO.File.Delete(fullFileName);
                            }
                        }
                    }
                }
                else if (uploadType == "HTTP")
                {

                }
                else if (uploadType == "ShareFolder")
                {

                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
    public class Upload2Factory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(XmlNode actionParams, ExtendEventHandler extendAction, ref object tag)
        {
            return new Upload2Action(actionParams, extendAction, ref tag);
        }
    }
}
