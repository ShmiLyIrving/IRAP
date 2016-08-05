using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.SubSystems
{
    public class CurrentOptions
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static CurrentOptions _instance = null;
        private int indexOfWorkUnit = -1;
        private ProcessInfo process = new ProcessInfo();
        private WorkUnitInfo workUnit = new WorkUnitInfo();
        private List<WorkUnitInfo> workUnits = new List<WorkUnitInfo>();

        private CurrentOptions()
        {
        }

        public static CurrentOptions Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CurrentOptions();
                return _instance;
            }
        }

        /// <summary>
        ///  获取/设置当前选择的工位/工序在工位/工序列表中的索引号
        /// </summary>
        public int IndexOfWorkUnit
        {
            get { return indexOfWorkUnit; }
            set
            {
                if (value > workUnits.Count)
                {
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        throw new Exception("Index is out of range.");
                    else
                        throw new Exception("索引超出工位/工序列表的范围");
                }

                if (indexOfWorkUnit != value)
                {
                    if (indexOfWorkUnit < 0)
                    {
                        indexOfWorkUnit = -1;
                        workUnit = null;
                    }
                    else
                    {
                        workUnit = WorkUnits[value];
                        indexOfWorkUnit = value;
                    }
                }
            }
        }

        /// <summary>
        /// 获取/设置当前的产品/流程
        /// </summary>
        public ProcessInfo Process
        {
            get { return process; }
            set
            {
                if (value != null)
                {
                    if (process == null ||
                        process.T120LeafID != value.T120LeafID ||
                        process.T102LeafID != value.T102LeafID)
                    {
                        process = value.Clone();
                        try
                        {
                            GetWorkUnitsWithCurrentProcess();
                        }
                        catch
                        {
                            indexOfWorkUnit = -1;
                            workUnit = null;
                            return;
                        }

                        if (WorkUnits.Count > 0)
                        {
                            indexOfWorkUnit = 0;
                            workUnit = workUnits[0];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取/设置当前选择的工位/工序
        /// </summary>
        public WorkUnitInfo WorkUnit
        {
            get { return workUnit; }
            set
            {
                if (workUnit == null ||
                    workUnit.WorkUnitLeaf != value.WorkUnitLeaf)
                {
                    for (int i = 0; i < workUnits.Count; i++)
                    {
                        if (workUnits[i].WorkUnitLeaf == value.WorkUnitLeaf)
                        {
                            workUnit = workUnits[i];
                            IndexOfWorkUnit = i;
                            return;
                        }
                    }

                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        throw new Exception("The position/process to switch is not in the list of the current product / process");
                    else
                        throw new Exception("要切换的工位/工序不在当前产品/流程允许的列表中");
                }
            }
        }

        public List<WorkUnitInfo> WorkUnits
        {
            get { return workUnits; }
        }

        private void GetWorkUnitsWithCurrentProcess()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                workUnits.Clear();

                IRAPSystemClient.Instance.ufn_GetKanban_WorkUnits(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    process.T120LeafID,
                    ref workUnits,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                    throw new Exception(errText);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                throw error;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}