using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexDefrag
{
    public class ScanningTask
    {
        private static ScanningTask _instance = null;

        public static ScanningTask Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ScanningTask();
                return _instance;
            }
        }
        private int threadID = 0;
        public delegate void SetTextHandler(string text);
        public SetTextHandler SetBtnText = null;
        public SetTextHandler SetAccumTask = null;
        public SetTextHandler SetlbHead = null;
        public delegate void SetMsgHandler(string msg, string modeName, ToolTipIcon icon);
        public SetMsgHandler SetMsgState = null;
        public delegate void Action();
        public Action AfterScan = null;
        public Action AfterDefrag = null;
        public delegate void SetEnableHandler(bool enable);
        public SetEnableHandler SetPicAnimate = null;
        public delegate void SetBtnEnablHandler(int page, bool enable);
        public SetBtnEnablHandler SetBtnEnable = null;
   
        ~ScanningTask()
        {
            Debug.WriteLine(string.Format("释放线程 [Thread #{0}]", threadID));
        }
        
        public void GetTableStruct(CancellationToken cts)
        {
            try
            {
                SetMsgState("正在扫描数据库结构", "", ToolTipIcon.None);
                SetlbHead("正在扫描数据库:");
                TaskFactory fac = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(20));
                List<Task> childtasks = new List<Task>();
                foreach (DB db in Server.Instance.databases)
                {
                    if(cts.IsCancellationRequested)
                    {
                        return;
                    }
                    childtasks.Add(
                    fac.StartNew(() =>
                    {
                        db.InitDB(cts);
                    }));
                }
                fac.ContinueWhenAll(childtasks.ToArray(), compeletedtasks =>
                {
                    int nSuccessed =0;
                    int nFailed = 0;
                    foreach (var t in compeletedtasks)
                    {
                        if (t.Status == TaskStatus.RanToCompletion)
                            nSuccessed++;
                        if (t.Status == TaskStatus.Faulted)
                        {
                            nFailed++;
                        }
                    }                  
                    if (!cts.IsCancellationRequested)
                    {
                        SetMsgState($"扫描成功：{nSuccessed}个，未成功：{nFailed}个(双击查看日志)", "", ToolTipIcon.None);
                        Scan(cts);
                    }
                    else
                    {
                        SetMsgState("扫描已取消", "", ToolTipIcon.Info);
                        SetAccumTask("取消成功");
                        SetPicAnimate(false);
                        SetBtnEnable(1, true);
                    }
                });              
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void Scan(CancellationToken cts)
        {
            try
            {
                
                SetlbHead("正在扫描：");
                
                Stopwatch w = new Stopwatch();
                w.Start();
                TaskFactory fac = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(int.Parse(SysParams.Instance.MaxScanningThreadCount)));
                if (Server.Instance.databases != null)
                {
                    List<Task> childtasks = new List<Task>();
                    foreach (DB db in Server.Instance.databases)
                    {
                        if (db.tables != null)
                        {
                            foreach (DBTable table in db.tables)
                            {
                                if (cts.IsCancellationRequested)
                                {
                                    return;
                                }
                                table.needDefrag = false;
                                childtasks.Add(
                                fac.StartNew(() =>
                                {
                                    table.InitIndexState(cts);
                                }));
                            }
                        }
                    }
                    fac.ContinueWhenAll(childtasks.ToArray(), compeletedtasks =>
                    {
                        int nSuccessed = 0;
                        int nFailed = 0;
                        foreach (var t in compeletedtasks)
                        {
                            if (t.Status == TaskStatus.RanToCompletion)
                                nSuccessed++;
                            if (t.Status == TaskStatus.Faulted)
                            {
                                nFailed++;
                            }
                        }
                        if (!cts.IsCancellationRequested)
                        {
                            SetAccumTask("正在保存数据");
                            Task t = new Task(() =>
                            {
                                if (SysParams.Instance.ScanningLog)
                                {
                                    SetlbHead("任务：");
                                    foreach (DB db in Server.Instance.databases)
                                    {
                                        if (db.tables != null)
                                        {
                                            foreach (DBTable table in db.tables)
                                            {
                                                if (cts.IsCancellationRequested)
                                                {
                                                    break;
                                                }
                                                XmlFile.Instance.SavaDBInfo(db, table);
                                            }
                                        }
                                    }
                                }
                            });
                            t.Start();
                            w.Restart();
                            t.ContinueWith(c =>
                            {
                                w.Stop();
                                SetMsgState($"扫描完成", "", ToolTipIcon.Info);
                                SetAccumTask("扫描完成");
                                AfterScan();
                            }, TaskContinuationOptions.OnlyOnRanToCompletion);
                            t.ContinueWith(c =>
                            {
                                w.Stop();
                                SetMsgState($"保存数据失败(双击查看日志)","", ToolTipIcon.Error);

                            }, TaskContinuationOptions.NotOnRanToCompletion);
                        }
                        else
                        {
                            SetMsgState("扫描已取消", "", ToolTipIcon.Info);
                            SetAccumTask("取消成功");
                            SetPicAnimate(false);
                            SetBtnEnable(1, true);
                        }
                    });
                    //test.Start();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void Defrag(CancellationToken cts)
        {
            try
            {
                TaskFactory fac = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(int.Parse(SysParams.Instance.MaxDefragThreadCount)));
                List<Task> childtasks = new List<Task>();
                foreach (DB db in Server.Instance.databases)
                    foreach (DBTable table in db.tables)
                        foreach (IndexState index in table.indexstates)
                        {
                            childtasks.Add(fac.StartNew(() =>
                            {
                                index.Defrag(db.dataBaseID, table.Tableid, table.Tablename, cts);
                            }));
                        }
                fac.ContinueWhenAll(childtasks.ToArray(), compeletedtasks =>
                {
                    int nSuccessed = 0;
                    int nFailed = 0;
                    foreach (var t in compeletedtasks)
                    {
                        if (t.Status == TaskStatus.RanToCompletion)
                            nSuccessed++;
                        if (t.Status == TaskStatus.Faulted)
                        {
                            nFailed++;
                        }
                    }
                    if (!cts.IsCancellationRequested)
                    {
                        SetAccumTask("清理完成");
                        SetMsgState($"清理成功：{nSuccessed}个，未成功：{nFailed}个(双击查看日志)", "", ToolTipIcon.Info);
                        AfterDefrag();
                    }
                    else
                    {
                        SetMsgState("清理已取消", "", ToolTipIcon.Info);
                        SetAccumTask("取消成功");
                        SetPicAnimate(false);
                        SetBtnEnable(1, true);
                    }
                });
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
