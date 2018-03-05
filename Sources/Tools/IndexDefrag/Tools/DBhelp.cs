using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace IndexDefrag
{
    public class DBhelp
    {
        public DBhelp(string DBName)
        {
            dBName = DBName;
            connStr = connStr = "server=" + SysParams.Instance.DBServer + ";database=" + DBName + ";uid=" + SysParams.Instance.DBUid + ";pwd=" + SysParams.Instance.DBPwd + ";Max Pool Size = 512;Enlist=true;Connection Lifetime=800;packet size=1000";
        }
        private string dBName;
        private string connStr;

        public bool TestConnection()
        {
            bool success = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand($"select top 1 from {dBName}", conn);
                    conn.Open();
                    conn.Close();
                    success = true;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return success;

        }

        /// <summary>
        /// 执行sql,返回object对象
        /// </summary>
        /// <param name="sql"></param>
        public Object GetSingle(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = 1000000;
                conn.Open();            
                object obj = cmd.ExecuteScalar();
                return obj;
            }
        }

        /// <summary>
        /// 执行sql,返回dataset
        /// </summary>
        /// <param name="sql"></param>
        public DataSet Query(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    conn.Open();
                    sda.SelectCommand.CommandTimeout = 1000;
                    sda.Fill(ds, "ds");
                    conn.Close();
                    return ds;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 执行带参数的sql语句，返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public int ExecuteSQL(string sql, SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter p in paras)
                {
                    cmd.Parameters.Add(p);
                }
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();

                return row;
            }
        }
        /// <summary>
        /// 执行带的sql语句，返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public int ExecuteSQL(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();

                return row;
            }
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="name"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        private int ExecuteProc(string name, SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(name, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in paras)
                {
                    cmd.Parameters.Add(p);
                }
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();

                return row;
            }
        }
    }
}
