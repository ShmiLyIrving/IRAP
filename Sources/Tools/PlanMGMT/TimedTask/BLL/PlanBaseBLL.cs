using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PlanMGMT.BLL
{
    public class PlanBaseBLL : BllBase
    {
        public PlanBaseBLL()
        {
            this.TableName = "utb_plan";
        }        
        public void AddMinute()
        {
            try
            {
                string sql = $"update utb_plan set CostMinutes = CostMinutes+1 where InCharge = '{Utility.ProU.Instance.PspUser.UserCode}' and Status =1";
                Mysql.Instance.ExecuteSql(sql);
            }
            catch(Exception e)
            {
                Helper.Instance.AlertError("计时失败：" + e.Message);
            }
        }
    }
}
