using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;
using PlanMGMT.Model;
using System.Windows;
using PlanMGMT.Utility;
using System.Diagnostics;

namespace PlanMGMT.BLL
{
    public class PlanBLL
    {
        private static PlanBLL _instance;
        private static object _lock = new object();//使用static object作为互斥资源
        private static readonly object _obj = new object();
        private BLL.PlanBaseBLL _bllPlan = new BLL.PlanBaseBLL();
        private BLL.SysLogBLL _bllLog = new BLL.SysLogBLL();
        public List<Plan> CurrentPlanList = new List<Plan>();
        public List<string> Expanded = new List<string>();

        #region 单例
        /// <summary>
        /// 
        /// </summary>
        public  PlanBLL()
        {        
        }

        /// <summary>
        /// 返回唯一实例
        /// </summary>
        public static PlanBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    //lock (_obj)
                    //{
                    //if (_instance == null)
                    //{
                    _instance = new PlanBLL();
                    //}
                    //}
                }
                return _instance;
            }
        }
        #endregion
        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <returns></returns>
        public List<PlanMGMT.Model.Plan> GetPlanList(string wheresql,string orderbysql)
        {
            List<PlanMGMT.Model.Plan> list = _bllPlan.GetList<Plan>(wheresql, orderbysql);
            CurrentPlanList = list;
            return CurrentPlanList;
        }
        public void StartPlan(int planid)
        {
            string sql = $"update utb_plan set Status = 1,ActualStart ='{DateTime.Now}' where PlanID ={planid}";
            Mysql.Instance.ExecuteSql(sql);
        }
        public void StopPlan(int planid)
        {
            string sql = $"update utb_plan set Status = 3 where PlanID ={planid}";
            Mysql.Instance.ExecuteSql(sql);
        }
        public void ContinuePlan(int planid)
        {
            string sql = $"update utb_plan set Status = 1 where PlanID ={planid}";
            Mysql.Instance.ExecuteSql(sql);
        }
        public void CompeletePlan(int planid)
        {
            string sql = $"update utb_plan set Status = 2,ActualEnd ='{DateTime.Now}' where PlanID ={planid}";
            Mysql.Instance.ExecuteSql(sql);
        }
        public void ItemClick(string type, Model.Plan mod)
        {
            Error error = GetEnableChange(mod);
            if (error.ErrCode != 0)
            {
                Helper.Instance.AlertError(error.ErrText);
                return;
            }
            // 1:查看 2：删除 3：开始/结束 
            if (type == "1")
            {   
                    View.PlanEdit vPlan = new View.PlanEdit();
                    vPlan.ID = mod.PlanID;
                    vPlan.ShowDialog();   
            }
            else if (type == "2")
            {
                Helper.Instance.AlertConfirm(null, "确定删除？", () =>
                {
                    try
                    {
                        _bllPlan.Delete(" PlanID=" + mod.PlanID);
                        Helper.Instance.AlertSuccess("操作成功！");
                    }
                    catch (Exception ex)
                    {
                        Helper.Instance.AlertError("操作失败！");
                        MSL.Tool.LogHelper.Instance.WriteLog("MainWindow DropList 删除选中项\r\n" + ex.ToString());
                    }
                });
            }
        }
        public Error GetEnableChange(Model.Plan plan)
        {
            Error e = new Error();
            if (Utility.ProU.Instance.PspUser.RoleID > 1)
            {
                e.ErrCode = 0;
                e.ErrText = "";
            }
            else
            {
                if (plan.InCharge == Utility.ProU.Instance.PspUser.UserCode)
                {
                    if (plan.ChangeCount == 0)
                    {
                        e.ErrCode = 0;
                        e.ErrText = "";
                    }
                    else
                    {
                        e.ErrCode = 9999;
                        e.ErrText = "你的计划修改次数已达上限，请联系主管修改";
                    }
                }
                else
                {
                    e.ErrCode = 9999;
                    e.ErrText = "您不能编辑他人的计划";
                }
            }
            return e;
        }
        public Error GetEnableTimer(Model.Plan plan)
        {
            Error e = new Error();
            if (plan.InCharge != Utility.ProU.Instance.PspUser.UserCode)
            {
                e.ErrCode = 9999;
                e.ErrText = "您无法操作他人的计划";
            }
            else
            {
                e.ErrCode = 0;
                e.ErrText = "";
            }
            return e;
        }
        /// <summary>
        /// 进行中任务数量
        /// </summary>
        /// <returns></returns>
        public int RunningTaskCnt()
        {
            int c = 0;
            string sql = $"select Count(*) from utb_plan where Status = 1 and InCharge='{ProU.Instance.PspUser.UserCode}'";
            object o = Mysql.Instance.GetSingle(sql);
            if(o!=null)
            {
                try
                {
                    c = int.Parse(o.ToString());
                }
                catch(Exception e)
                {
                    Helper.Instance.AlertError(e.Message);
                }
            }
            else
            {
                c = 0;
            }
            return c;
        }
        public int UnStartTaskCnt()
        {
            int c = 0;
            string sql = $"select Count(*) from utb_plan where Status = 0 and InCharge='{ProU.Instance.PspUser.UserCode}'";
            object o = Mysql.Instance.GetSingle(sql);
            if (o != null)
            {
                try
                {
                    c = int.Parse(o.ToString());
                }
                catch (Exception e)
                {
                    Helper.Instance.AlertError(e.Message);
                }
            }
            else
            {
                c = 0;
            }
            return c;
        }
        /// <summary>
        /// 暂停任务数量
        /// </summary>
        /// <returns></returns>
        public int StopTaskCnt()
        {
            int c = 0;
            string sql = $"select Count(*) from utb_plan where Status = 3 and InCharge='{ProU.Instance.PspUser.UserCode}'";
            object o = Mysql.Instance.GetSingle(sql);
            if (o != null)
            {
                try
                {
                    c = int.Parse(o.ToString());
                }
                catch (Exception e)
                {
                    Helper.Instance.AlertError(e.Message);
                }
            }
            else
            {
                c = 0;
            }
            return c;
        }
        /// <summary>
        /// 延期任务数量
        /// </summary>
        /// <returns></returns>
        public int PastTaskCnt()
        {
            int c = 0;
            string sql = $"select Count(*) from utb_plan where Status <> 2 and InCharge='{ProU.Instance.PspUser.UserCode}' and PlanEnd<'{DateTime.Now}'";
            object o = Mysql.Instance.GetSingle(sql);
            if (o != null)
            {
                try
                {
                    c = int.Parse(o.ToString());
                }
                catch (Exception e)
                {
                    Helper.Instance.AlertError(e.Message);
                }
            }
            else
            {
                c = 0;
            }
            return c;
        }
    }
}
