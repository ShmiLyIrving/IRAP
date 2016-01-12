using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DevExpress.XtraTreeList.Nodes;
using System.IO;

using IRAP.Global;

namespace IRAP.UFMPS.Library
{
    internal class TThreadFtpFile : TCustomDocumentProcess
    {
        public TThreadFtpFile(
            string dataFileName, 
            TTaskInfo taskInfo, 
            UserControls.UCMonitorLog showLog = null,
            TreeListNode nodeParent = null) 
            : base(dataFileName, taskInfo, showLog, nodeParent)
        {
            ;
        }

        protected override bool DocumentProcessing()
        {
            if (File.Exists(dataFileName))
            {
                FTPClient ftp = new FTPClient(
                    _task.Ftp_Address,
                    _task.Ftp_Port,
                    _task.Ftp_UserID,
                    _task.Ftp_UserPWD);

                InvokeWriteLog(string.Format("连接 FTP 服务器：{0}", _task.Ftp_Address));
                try
                {
                    ftp.Connect();
                }
                catch (Exception error)
                {
                    InvokeWriteLog(string.Format("连接 FTP 服务器时发生错误：{0}", error.Message));
                    return false;
                }

                try
                {
                    long intRlt = 0;

                    InvokeWriteLog(string.Format("开始上传文件[{0}]", dataFileName));
                    string strDestinationFileName = Path.GetFileName(dataFileName);
                    ftp.OpenUpload(dataFileName, strDestinationFileName);
                    while ((intRlt = ftp.DoUpload()) > 0)
                    {
                        Thread.Sleep(10);
                    }
                    if (intRlt == -1)
                    {
                        InvokeWriteLog(string.Format("上传文件时发生错误：{0}", ftp.errormessage));
                        return false;
                    }
                    else
                    {
                        InvokeWriteLog("文件上传完毕");
                    }
                }
                finally
                {
                    InvokeWriteLog("断开服务器连接");
                    ftp.Disconnect();
                }
            }
            else
            {
                InvokeWriteLog(string.Format("文件[{0}]不存在，无法处理", dataFileName));
            }
            return true;
        }
    }
}
