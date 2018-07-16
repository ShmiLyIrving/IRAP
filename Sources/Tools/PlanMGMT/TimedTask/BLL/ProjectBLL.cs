using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.BLL
{
    public class ProjectBLL:BllBase
    {
        private static ProjectBLL _instance;
        private static object _lock = new object();//使用static object作为互斥资源
        private static readonly object _obj = new object();
        public List<Model.Project> projects = new List<Model.Project>();
        #region 单例
        public ProjectBLL()
        {
            this.TableName = "utb_Projects";
            projects = this.GetList<Model.Project>(null, "PlanStartTime");           
        }
        /// <summary>
        /// 返回唯一实例
        /// </summary>
        public static ProjectBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    //lock (_obj)
                    //{
                    //if (_instance == null)
                    //{
                    _instance = new ProjectBLL();
                    //}
                    //}
                }
                return _instance;
            }
        }
        #endregion
        public string GetDBProjectNameByID(int ID)
        {
            string sql = $"select ProjectName from utb_projects where ProjectID={ID}";
            object o = Mysql.Instance.GetSingle(sql);
            if(o==null)
            {
                return "";
            }
            return o.ToString();
        }
        public string GetProjectNameByID(int ID)
        {
            if (ID == 0)
            {
                return "";
            }
            else
            {
                
                return projects.Find((a) => a.ProjectID == ID)==null?"":projects.Find((a) => a.ProjectID == ID).ProjectName;
            }
        }
    }
}
