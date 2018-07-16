using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Data;
using System.Collections;

namespace PlanMGMT
{
     public class LoginBLL 
    {
        private static LoginBLL _instance;
        private static readonly object _lock = new Object();
        public List<Entity.User> InCharges = new List<Entity.User>();
        public List<Entity.User> Allusers = new List<Entity.User>();
        public List<Entity.PlanStatus> PlanStatus = new List<Entity.PlanStatus>();
        public List<Entity.Priority> Priorities = new List<Entity.Priority>();

        #region 单一实例
        /// <summary>
        /// 
        /// </summary>
        private LoginBLL()
        {
            GetAllUsers();
            GetPlanStatus();
            GetPriorities();
        }
        /// <summary>
        /// 
        /// </summary>
        ~LoginBLL()
        {
            Dispose();
        }
        /// <summary>
        /// 返回唯一实例
        /// </summary>
        public static LoginBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LoginBLL();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        public Error ssp_login(string Uid,string Pwd)
        {
            MySqlParameter[] paras = new MySqlParameter[4];
            paras[0] = new MySqlParameter("UC", MySqlDbType.VarChar, 20);
            paras[0].Value = Uid;
            paras[1] = new MySqlParameter("UP", MySqlDbType.VarChar, 100);
            paras[1].Value = Pwd;
            paras[2] = new MySqlParameter("?ErrCode", MySqlDbType.Int32, int.MaxValue, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Current,9999);
            paras[3] = new MySqlParameter("?ErrText", MySqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Current, "");
            Mysql.Instance.ExecuteProcS("ssp_login", paras);
            return new Error((int)(paras[2].Value), paras[3].Value.ToString());
        }
        public PSPUser GetUser(string Uid,string Pwd)
        {
            PSPUser p = new PSPUser();
            string sql = "SELECT a.UserCode,a.UserName,a.UserPass,a.Email,a.MPHoneNo,a.RoleID,a.deptID,b.RoleName,c.deptname "+ 
    "FROM utb_users AS a LEFT JOIN utb_roles AS b ON a.RoleID = b.RoleID LEFT JOIN utb_dept AS c ON a.`deptID` = c.`deptid` "+
	$"WHERE a.UserCode = '{Uid}' AND a.UserPass = MD5('{Pwd}');";
            DTUtilis.LoadValueFromDT(Mysql.Instance.Query(sql).Tables["ds"],p);
            return p;
        }
        public void GetInCharges()
        {
            List<Entity.User> ls = new List<Entity.User>();
            string sql = "SELECT UserCode,UserName From utb_users WHERE RoleID>1";
            InCharges=DTUtilis.LoadValueFromDT<Entity.User>(Mysql.Instance.Query(sql).Tables["ds"], ls);
        }
        public string GetDBUserNameByCode(string UserCode)
        {
            if (string.IsNullOrEmpty(UserCode))
                return "";
            string sql = $"select UserName from utb_users where UserCode ='{UserCode}'";
            object o = Mysql.Instance.GetSingle(sql);
            if (o == null)
            {
                return "";
            }
            return o.ToString();
        }
        public string GetUserNameByCode(string UserCode)
        {
            if(!string.IsNullOrEmpty(UserCode))
            {
                return Allusers.Find((a) => a.UserCode == UserCode)==null?"":Allusers.Find((a) => a.UserCode == UserCode ).UserName;
            }
            else
            {
                return "";
            }
        }
        public void GetPlanStatus()
        {           
            PlanStatus.Add(new Entity.PlanStatus(0, "未开始"));
            PlanStatus.Add(new Entity.PlanStatus(1, "进行中"));
            PlanStatus.Add(new Entity.PlanStatus(2, "已完成"));
            PlanStatus.Add(new Entity.PlanStatus(3, "暂停"));
        }
        public List<Entity.Department> GetDepts()
        {
            List<Entity.Department> ls = new List<Entity.Department>();
            string sql = "Select * from utb_dept";
            return DTUtilis.LoadValueFromDT<Entity.Department>(Mysql.Instance.Query(sql).Tables["ds"], ls);
        }
        public void GetAllUsers()
        {
            List<Entity.User> ls = new List<Entity.User>();
            string sql = "SELECT UserCode,UserName From utb_users";
            Allusers = DTUtilis.LoadValueFromDT<Entity.User>(Mysql.Instance.Query(sql).Tables["ds"], ls);
        }
        public void GetPriorities()
        {
            Priorities.Add(new Entity.Priority(0, "低"));
            Priorities.Add(new Entity.Priority(1, "一般"));
            Priorities.Add(new Entity.Priority(2, "紧急"));
            Priorities.Add(new Entity.Priority(3, "非常紧急"));
        }
    }
}
