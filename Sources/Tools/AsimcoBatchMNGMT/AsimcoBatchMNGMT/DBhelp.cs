using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Reflection;

namespace AsimcoBatchMNGMT
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

        /// <summary>
        /// XML转Datatable
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DataTable XML2Table(string s)
        {
            XmlDocument xdoc = new XmlDocument();
            if (s != "")
            {
                xdoc.LoadXml(s);
                XmlNode root = xdoc.FirstChild;
                DataTable _dt = new DataTable();
                if (root.Name == "Parameters")
                {
                    using (DataTable dt = new DataTable())
                    {                        
                        XmlNode node = root.FirstChild;
                        ExChangeXML od = new ExChangeXML();
                        foreach (XmlAttribute a in node.Attributes)
                        {
                            if (a.Name != null)
                            {
                                dt.Columns.Add(a.Name);
                            }
                        }
                        DataRow dataRow = dt.NewRow();
                        foreach (XmlAttribute a in node.Attributes)
                        {
                            Type type = od.GetType();
                            System.Reflection.PropertyInfo pi;
                            if (a.Name != null)
                            {
                                pi = type.GetProperty(a.Name);
                                if (pi != null)
                                {
                                    if (pi.PropertyType.FullName == "System.Int32")
                                        pi.SetValue(od, int.Parse(a.Value, null));
                                    else if (pi.PropertyType.FullName == "System.String")
                                        pi.SetValue(od, a.Value, null);
                                    else if (pi.PropertyType.FullName == "System.Int64")
                                        pi.SetValue(od, long.Parse(a.Value), null);
                                }
                                dataRow[pi.Name] = pi.GetValue(od, null);
                            }
                        }
                        dt.Rows.Add(dataRow);
                        return dt;
                    }
                }
                else if (root.Name == "Properties")
                {
                    using (DataTable dt = new DataTable())
                    {
                        DataRow dataRow = dt.NewRow();
                        Property po = new Property();
                        foreach (XmlNode n in root.ChildNodes)
                        {
                            Type type = po.GetType();
                            System.Reflection.PropertyInfo pi;
                            if (n.Name != null)
                            {
                                dt.Columns.Add(n.Name);
                                pi = type.GetProperty(n.Name);
                                if (pi != null)
                                {
                                    if (pi.PropertyType.FullName == "System.Int32")
                                        pi.SetValue(po, int.Parse(n.InnerText, null));
                                    else if (pi.PropertyType.FullName == "System.String")
                                        pi.SetValue(po, n.InnerText, null);
                                    else if (pi.PropertyType.FullName == "System.Int64")
                                        pi.SetValue(po, long.Parse(n.InnerText), null);
                                }
                                dataRow[pi.Name] = pi.GetValue(po, null);
                            }
                        }
                        dt.Rows.Add(dataRow);
                        return dt;
                    }
                }
                else
                    return null;
            }
            else
                return null;    
        }
    }
}
