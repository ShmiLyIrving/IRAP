using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList.Nodes;
using System.IO;

namespace IRAP.UFMPS.Library
{
    class TThreadMoveTo : TCustomDocumentProcess
    {
        public TThreadMoveTo(
            string dataFileName,
            TTaskInfo taskInfo,
            UserControls.UCMonitorLog showLog = null, 
            TreeListNode nodeParent = null)
            : base(dataFileName, taskInfo, showLog, nodeParent)
        {
            
        }
    
        protected override bool DocumentProcessing()
        {
            if (File.Exists(DataFileName))
            {
                if (_task.Copy_DestFolder.Trim() != "")
                {
                    string strDestinationFileName = string.Format("{0}{1}",
                        _task.Copy_DestFolder,
                        Path.GetFileName(DataFileName));

                    try
                    {
                        File.Copy(DataFileName, strDestinationFileName, true);
                        return true;
                    }
                    catch (Exception error)
                    {
                        InvokeWriteLog(string.Format("将文件[{0}]复制到文件夹[{1}]时发生错误：{2}",
                            DataFileName,
                            _task.Copy_DestFolder,
                            error.Message));
                        return false;
                    }
                }
                else
                {
                    InvokeWriteLog("“处理模式”中的“目的文件夹”没有设置！");
                    return false;
                }
            }
            else
            {
                InvokeWriteLog(string.Format("文件[{0}]不存在，无法处理！", DataFileName));
                return false;
            }
        }
    }
}
