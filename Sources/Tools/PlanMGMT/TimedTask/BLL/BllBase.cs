// 文 件 名：BllBase.cs
// 功能描述：Bll基类
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanMGMT.Model;

namespace PlanMGMT.BLL
{
    public class BllBase
    {
        public string TableName;
        public List<T> GetList<T>(string wheresql,string orderbysql)
        {
            string iswhere = " where ";
            if (string.IsNullOrEmpty(wheresql))
                iswhere = "";
            string isorderby = " order by ";
            if (string.IsNullOrEmpty(orderbysql))
                isorderby = "";
            List<T> temps = new List<T>();         
            string sql = "SELECT * FROM "+TableName+iswhere+wheresql+isorderby+orderbysql;
            return DTUtilis.LoadValueFromDT<T>(Mysql.Instance.Query(sql).Tables["ds"], temps);
        }
        public void Add(object obj)
        {
            string sql = DTUtilis.GetInsertSql(TableName,obj);
            Mysql.Instance.ExecuteSql(sql);
        }
        public int Count(string wheresql)
        {
            string iswhere = " where ";
            if (string.IsNullOrEmpty(wheresql))
                iswhere = "";
            string sql = "SELECT COUNT(*) FROM "+TableName+iswhere+ wheresql;
            object o = Mysql.Instance.GetSingle(sql);
            return o==null?0:int.Parse(o.ToString());
        }
        public void Update(object obj, string wheresql)
        {
            string iswhere = " where ";
            if (string.IsNullOrEmpty(wheresql))
                iswhere = "";
            string sql = DTUtilis.GetUpdateSql(TableName, obj)+iswhere+wheresql;
            Mysql.Instance.ExecuteSql(sql);
        }
        public void Delete(string wheresql)
        {
            if (string.IsNullOrEmpty(wheresql))
                return;
            string sql = "delete from " + TableName + " where " + wheresql;
            Mysql.Instance.ExecuteSql(sql);
        }
        public T GetEntity<T>(string wheresql)
        {
            if (string.IsNullOrEmpty(wheresql))
                throw new Exception();
            Type type = typeof(T);
            object o = Activator.CreateInstance(type);
            string sql = "select * from " + TableName + " where " + wheresql+" limit 1";
            return (T)(DTUtilis.LoadValueFromDT(Mysql.Instance.Query(sql).Tables["ds"],o));
        }
        
    }
}
