using System;
using System.Collections;
using System.Collections.Generic;
using PlanMGMT.Model;

namespace PlanMGMT.BLL
{
    /// <summary>
    /// 定时任务类
    /// </summary>
    public class AutoTaskBLL:BllBase
    {
        public AutoTaskBLL()       
        {
            this.TableName = "utb_AutoTask";
        }
    }
}
