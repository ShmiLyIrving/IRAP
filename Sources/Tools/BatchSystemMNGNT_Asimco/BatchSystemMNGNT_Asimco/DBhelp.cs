using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Reflection;

namespace IRAP.Global
{
    class DBhelp
    {
        public static string ConnStr
        {
            get;set;
        }
        /// <summary>
        /// 执行sql,返回object对象
        /// </summary>
        /// <param name="sql"></param>
        public static Object getSingle(string sql)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                object obj = cmd.ExecuteScalar();
                return obj;
            }
        }

        /// <summary>
        /// 执行sql,返回dataset
        /// </summary>
        /// <param name="sql"></param>
        public static DataSet Query(string sql)         
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                conn.Open();
                sda.SelectCommand.CommandTimeout = 360;
                sda.Fill(ds, "ds");               
                conn.Close();
                return ds;
            }
        }

        /// <summary>
        /// 执行带参数的sql语句，返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static int ExecuteSQL(string sql, SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
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
        /// 执行存储过程
        /// </summary>
        /// <param name="name"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static int ExecuteProc(string name, SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
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

        public static DataTable XMLNodeAttrToTable(string strXML)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(strXML);
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] =
                    string.Format("打开 XML 字符串时发生错误：{0}", error.Message);
                throw error;
            }

            DataTable dt = new DataTable();
            XmlNode rootNode = xml.FirstChild;

            foreach (XmlNode child in rootNode.ChildNodes)
            {
                if (dt.Columns.Count <= 0)
                {
                    foreach (XmlAttribute attr in child.Attributes)
                    {
                        if (!dt.Columns.Contains(attr.Name))
                        {
                            DataColumn newColumn = dt.Columns.Add();
                            newColumn.ColumnName = attr.Name;
                            newColumn.Caption = attr.Name;
                            newColumn.DataType = typeof(string);
                        }
                    }
                }

                DataRow dr = dt.NewRow();
                foreach (XmlAttribute attr in child.Attributes)
                {
                    if (dt.Columns.Contains(attr.Name))
                    {
                        dr[attr.Name] = attr.Value;
                    }
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
