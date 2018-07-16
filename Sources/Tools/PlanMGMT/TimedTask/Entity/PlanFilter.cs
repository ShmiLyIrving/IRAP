// 文 件 名：PlanFilter.cs
// 功能描述：计划过滤类
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.Entity
{
     public class PlanFilter
    {
        /// <summary>
        /// 搜索开始时间
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 搜索结束时间
        /// </summary>
        public DateTime? StopDate { get; set; }
        /// <summary>
        /// 搜索负责人
        /// </summary>
        public string InCharge { get; set; }
        /// <summary>
        /// 搜索任务状态
        /// </summary>
        public short? Status { get; set; }
        /// <summary>
        /// 搜索部门ID
        /// </summary>
        public int? DeptID { get; set; }
        /// <summary>
        /// 搜索项目ID
        /// </summary>
        public int? ProjectID { get; set; }
        public PlanFilter()
        {
            this.StartDate = Helper.Instance.GetLastMondayDate();
            this.StopDate = Helper.Instance.GetNextSundayDate();
        }
        public PlanFilter(DateTime startDate,DateTime stopDate)
        {
            this.StartDate = startDate;
            this.StartDate = stopDate;
        }
        /// <summary>
        /// 生成过滤字符串
        /// </summary>
        /// <returns></returns>
        public string GenerateFilter()
        {
            bool flag = false;
            string s = "";
            if (StartDate != null && StopDate != null)
            {
                if (StopDate > StartDate)
                {
                    s += $"((PlanStart<'{StartDate}' and PlanEnd>='{StartDate}') or (PlanStart>='{StartDate}' and PlanStart<='{StopDate}')) ";
                }
                else
                {
                    Helper.Instance.AlertError("结束日期不能早于开始日期");
                    StartDate = Helper.Instance.GetMondayDate();
                    StopDate = Helper.Instance.GetNextSundayDate();
                    s += $"((PlanStart<'{StartDate}' and PlanEnd>='{StartDate}') or (PlanStart>='{StartDate}' and PlanStart<='{StopDate}')) ";
                }
            }
            else if(StartDate ==null)
            {
                Helper.Instance.AlertError("开始日期不能为空");
                StartDate = Helper.Instance.GetMondayDate();
                StopDate = Helper.Instance.GetNextSundayDate();
                s += $"((PlanStart<'{StartDate}' and PlanEnd>='{StartDate}') or (PlanStart>='{StartDate}' and PlanStart<='{StopDate}')) ";
            }
            else if(StopDate ==null)
            {
                Helper.Instance.AlertError("结束日期不能为空");
                StartDate = Helper.Instance.GetMondayDate();
                StopDate = Helper.Instance.GetNextSundayDate();
                s += $"((PlanStart<'{StartDate}' and PlanEnd>='{StartDate}') or (PlanStart>='{StartDate}' and PlanStart<='{StopDate}')) ";
            }
            
            if(!string.IsNullOrEmpty(InCharge))
            {
                flag = true;
                s += $"and (InCharge like '{InCharge}') ";
            }
            if(DeptID!=null&&DeptID!=-1)
            {
                flag = true;
                s += $"and (InCharge in (Select UserCode From utb_users where deptID ={DeptID})) ";
            }          
            if(ProjectID!=null&&ProjectID!=-1)
            {
                flag = true;
                s += $"and (ProjectID ={ProjectID}) ";
            }
            s += "and (InCharge in (select UserCode from utb_users)) ";
            if (Status != null && Status != -1)
            {
                flag = true;
                s += $"and (utb_plan.Status ={Status}) ";
            }
            if (!flag)
            {
                s = "(" + s + ") or ((utb_plan.Status <>2) and (InCharge in (select UserCode from utb_users))) ";
            }
            return s;
        }
    }
}
